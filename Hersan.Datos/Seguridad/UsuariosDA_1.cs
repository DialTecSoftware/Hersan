using Hersan.Entidades.Comun;
using Hersan.Entidades.Seguridad;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hersan.Datos.Seguridad
{
    public class UsuariosDA_1 : BaseDA
    {
        #region Constantes
        private const string CSTR_SP_USUARIOS_DATOSVALIDACION = "SEG_Usuarios_DatosValidacion";
        private const string CSTR_SP_BLOQUEODESBLOQUEO = "SEG_Usuarios_BloqueaDesbloquea";
        private const string CSTR_SP_OBTIENEBLOQUEOUSUARIO = "SEG_Usuarios_ObtieneBloqueo";
        private const string CSTR_SP_USUARIOS_OBTIENEUSUARIO = "SEG_Usuarios_ObtieneUsuario";
        private const string CSTR_SP_USUARIOS_OBTIENE = "SEG_Usuarios_Obtiene";
        private const string CSTR_SP_USUARIOS_GUARDA = "SEG_Usuarios_Guarda";
        private const string CSTR_SP_USUARIOS_ACTUALIZA = "SEG_Usuarios_Actualiza";
        private const string CSTR_SP_USUARIOS_CAMBIACONTRASENIA = "SEG_Usuarios_CambiaContrasenia";
        #endregion

        #region Validacion Usuario
        /// <summary>
        /// Valida que las credenciales del usuario sean correctas
        /// </summary>
        /// <param name="nomUsr">Cuenta usuario</param>
        /// <param name="Pswd">Contraseña Encriptada</param>
        /// <returns></returns>
        public ValidaIngresoBE ValidaUsuario(string nomUsr, string Pswd, int IdEmpresa)
        {
            ValidaIngresoBE val = new ValidaIngresoBE();
            bool valida = false;
            string pssEncr = string.Empty;
            int intentos = int.Parse(ConfigurationManager.AppSettings["NumInten"].ToString());
            int minutos = int.Parse(ConfigurationManager.AppSettings["MinBloqueo"].ToString());
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion())) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CSTR_SP_USUARIOS_DATOSVALIDACION, conn)) {
                        cmd.Parameters.AddWithValue("@Usuario", nomUsr);
                        cmd.Parameters.AddWithValue("@Emp_Id", IdEmpresa);

                        cmd.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            if (reader.Read())
                                pssEncr = reader["USU_Contrasenia"].ToString();
                        }
                    }

                    if (!pssEncr.Equals(string.Empty)) {
                        EncriptadorDA enc = new EncriptadorDA();
                        string clvRecibida = enc.DesencriptarTexto(Pswd);
                        string clvAlmacenada = enc.DesencriptarTexto(pssEncr);

                        if (!clvRecibida.Equals(string.Empty))
                            valida = clvRecibida.Equals(clvAlmacenada);

                        if (intentos > 0) {
                            using (SqlCommand cmd = new SqlCommand(CSTR_SP_BLOQUEODESBLOQUEO, conn)) {
                                cmd.Parameters.AddWithValue("@Usuario", nomUsr);
                                cmd.Parameters.AddWithValue("@Emp_Id", IdEmpresa);
                                cmd.Parameters.AddWithValue("@minutos", minutos);
                                cmd.Parameters.AddWithValue("@intentos", intentos);

                                if (valida)
                                    valida = !((ValidaIngresoBE)ObtienBloqueoUsuario(nomUsr, IdEmpresa)).EsUsuarioBloqueado;

                                cmd.Parameters.Add("@bloquea", SqlDbType.Bit).Value = !valida;

                                cmd.CommandType = CommandType.StoredProcedure;

                                if (valida) {
                                    cmd.ExecuteNonQuery();
                                } else {
                                    using (SqlDataReader reader = cmd.ExecuteReader()) {
                                        if (reader.Read()) {
                                            int numinten = 0;
                                            int.TryParse(reader["usu_NumInten"].ToString(), out numinten);
                                            if (reader["usu_FecBloqueo"] != System.DBNull.Value) {
                                                DateTime dtFActual = DateTime.Parse(reader["FECACTUAL"].ToString());
                                                DateTime dtFDBlo = DateTime.Parse(reader["usu_FecDesBloq"].ToString());

                                                val.EsUsuarioBloqueado = true;
                                                double res = Math.Ceiling(dtFDBlo.Subtract(dtFActual).TotalMinutes);
                                                val.ErrorIngreso = "La cuenta se encuentra bloqueda, intentelo de nuevo en " + res +
                                                    (res > 1 ? " minutos." : " minuto.");
                                            } else {
                                                val.ErrorIngreso = (intentos - numinten) > 0 ? "Usuario y/o contraseña invalidos. la cuenta será bloqueada al intento " +
                                                                                                intentos.ToString() + ". Intento " + numinten.ToString() + " de " + intentos.ToString() :
                                                                                                "Usuario y/o contraseña invalidos. la cuenta esta bloqueada.";
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                    if (valida) {
                        val.EsIngresoValido = true;
                        val.ErrorIngreso = string.Empty;
                    }
                }

                return val;
            } catch {
                return val;
            }
        }

        /// <summary>
        /// Verifica si hay bloqueo del usuario
        /// </summary>
        /// <param name="nomUsr">Cuenta usuario</param>
        /// <returns></returns>
        public ValidaIngresoBE ObtienBloqueoUsuario(string nomUsr, int IdEmpresa)
        {
            ValidaIngresoBE val = new ValidaIngresoBE();
            val.ErrorIngreso = string.Empty;
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion())) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CSTR_SP_OBTIENEBLOQUEOUSUARIO, conn)) {
                        cmd.Parameters.AddWithValue("@Usuario", nomUsr);
                        cmd.Parameters.AddWithValue("@Emp_Id", IdEmpresa);

                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            if (reader.Read()) {
                                if (reader["usu_FecBloqueo"] != System.DBNull.Value) {
                                    DateTime dtFActual = DateTime.Parse(reader["FECACTUAL"].ToString());
                                    DateTime dtFDBlo = DateTime.Parse(reader["usu_FecDesBloq"].ToString());
                                    double res = Math.Ceiling(dtFDBlo.Subtract(dtFActual).TotalMinutes);

                                    if (res > 0) {
                                        val.EsUsuarioBloqueado = true;
                                        val.ErrorIngreso = "Cuenta bloqueda. ¿Desea Desbloquear?";
                                    }
                                }
                            }
                        }
                    }
                }
                return val;
            } catch {
                return val;
            }
        }

        /// <summary>
        /// Desbloquea usuario
        /// </summary>
        /// <param name="nomUsr">Cuenta usuario</param>
        public void DesbloqueaUsuario(string nomUsr)
        {
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion())) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CSTR_SP_BLOQUEODESBLOQUEO, conn)) {
                        cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar).Value = nomUsr;
                        cmd.Parameters.Add("@minutos", SqlDbType.Int).Value = 0;
                        cmd.Parameters.Add("@intentos", SqlDbType.Int).Value = 0;
                        cmd.Parameters.Add("@bloquea", SqlDbType.Bit).Value = false;

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.ExecuteNonQuery();
                    }

                }
            } catch (Exception ex) {
                throw ex;
            }
        }

        public int CambiaContrasenia(UsuariosBE Usuario)
        {
            try {
                int Result = 0;
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion())) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CSTR_SP_USUARIOS_CAMBIACONTRASENIA, conn)) {
                        cmd.Parameters.AddWithValue("@Usuario", Usuario.ID);
                        cmd.Parameters.AddWithValue("@Emp_Id", Usuario.Empresa.Id);
                        cmd.Parameters.AddWithValue("@Contrasenia", Usuario.Contrasena);

                        cmd.CommandType = CommandType.StoredProcedure;
                        Result = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
                
                return Result;
            } catch (Exception ex) {
                throw ex;
            }
        }
        #endregion

        #region Datos Usuarios

        /// <summary>
        /// Obtiene los usuarios dados de alto en el sistema
        /// </summary>
        /// <returns></returns>
        public List<UsuariosBE> ObtieneUsuarios(int IdEmpresa)
        {
            try {
                List<UsuariosBE> lst = new List<UsuariosBE>();
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion())) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CSTR_SP_USUARIOS_OBTIENE, conn)) {
                        cmd.Parameters.AddWithValue("@Emp_Id", IdEmpresa);

                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                UsuariosBE obj = new UsuariosBE();
                                obj.ID = int.Parse(reader["USU_IdUsuario"].ToString());
                                obj.Nombre = reader["USU_Nombre"].ToString();
                                obj.Correo = reader["USU_EMail"].ToString();
                                obj.Usuario = reader["USU_Usuario"].ToString();
                                obj.Contrasena = reader["USU_Contrasenia"].ToString();
                                obj.Activo = Boolean.Parse(reader["USU_Estatus"].ToString());
                                obj.Bloqueado = Boolean.Parse(reader["Bloqueado"].ToString());
                                lst.Add(obj);
                            }
                        }
                    }
                }
                return lst;
            } catch (Exception ex) {
                throw ex;
            }
        }

        /// <summary>
        /// Guarda el nuevo usuario
        /// </summary>
        /// <param name="Usuario">Usuario que se va a crear</param>
        /// <param name="IdUsuarioCrea">Usuario que guarda el nuevo usuario</param>
        public ResultadoBE GuardaUsuario(UsuariosBE Usuario, int IdUsuarioCrea)
        {
            ResultadoBE res = new ResultadoBE();
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion())) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CSTR_SP_USUARIOS_GUARDA, conn)) {
                        cmd.Parameters.AddWithValue("@Nombre", Usuario.Nombre);
                        cmd.Parameters.AddWithValue("@EMail", Usuario.Correo);
                        cmd.Parameters.AddWithValue("@IdCrea", IdUsuarioCrea);
                        cmd.Parameters.AddWithValue("@Usuario", Usuario.Usuario);
                        cmd.Parameters.AddWithValue("@Contrasenia", Usuario.Contrasena);
                        cmd.Parameters.AddWithValue("@estatus", Usuario.Activo);
                        cmd.Parameters.AddWithValue("@Emp_Id", Usuario.Empresa.Id);
                        //cmd.Parameters.Add("@IdDepto", SqlDbType.Int).Value = Usuario.Depto.ID;

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.ExecuteNonQuery();
                    }
                }

                res.EsValido = true;
                res.Error = string.Empty;
            } catch (SqlException ex) {
                res.EsValido = false;
                res.Error = ex.Message;
            } catch (Exception ex) {
                throw ex;
            }

            return res;
        }


        /// <summary>
        /// Actualiza el usuario
        /// </summary>
        /// <param name="Usuario">Usuario que se va a actualizar</param>
        /// <param name="IdUsuarioMod">Usuario que actualiza</param>
        public ResultadoBE ActualizaUsuario(UsuariosBE Usuario, int IdUsuarioMod)
        {
            ResultadoBE res = new ResultadoBE();
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion())) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CSTR_SP_USUARIOS_ACTUALIZA, conn)) {
                        cmd.Parameters.AddWithValue("@IdUsuario", Usuario.ID);
                        cmd.Parameters.AddWithValue("@Nombre", Usuario.Nombre);
                        cmd.Parameters.AddWithValue("@EMail", Usuario.Correo);
                        cmd.Parameters.AddWithValue("@IdModif", IdUsuarioMod);
                        cmd.Parameters.AddWithValue("@Usuario", Usuario.Usuario);
                        cmd.Parameters.AddWithValue("@Contrasenia", Usuario.Contrasena);
                        cmd.Parameters.AddWithValue("@estatus", Usuario.Activo);
                        cmd.Parameters.AddWithValue("@Emp_Id", Usuario.Empresa.Id);
                        //cmd.Parameters.Add("@IdDepto", SqlDbType.Int).Value = Usuario.Depto.ID;

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.ExecuteNonQuery();
                    }
                }

                res.EsValido = true;
                res.Error = string.Empty;
            } catch (SqlException ex) {
                res.EsValido = false;
                res.Error = ex.Message;
            } catch (Exception ex) {
                throw ex;
            }

            return res;
        }


        /// <summary>
        /// Obtiene los datos del usuario
        /// </summary>
        /// <param name="Usuario">usuario a consultar</param>
        /// <returns></returns>
        public UsuariosBE ObtieneDatosUsuario(string Usuario, int IdEmpresa)
        {
            try {
                UsuariosBE obj = new UsuariosBE();
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion())) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CSTR_SP_USUARIOS_OBTIENEUSUARIO, conn)) {
                        cmd.Parameters.AddWithValue("@Usuario", Usuario);
                        cmd.Parameters.AddWithValue("@Emp_Id", IdEmpresa);

                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            if (reader.Read()) {
                                obj.ID = int.Parse(reader["USU_IdUsuario"].ToString());
                                obj.Nombre = reader["USU_Nombre"].ToString();
                                obj.Correo = reader["USU_EMail"].ToString();
                                obj.Usuario = reader["USU_Usuario"].ToString();
                                obj.Activo = Boolean.Parse(reader["USU_Estatus"].ToString());
                                obj.EsSuper = Boolean.Parse(reader["USU_Super"].ToString());
                                obj.Rol.ID = int.Parse(reader["ROL_IdRol"].ToString());
                                obj.Rol.Nombre = reader["ROL_Rol"].ToString();

                                obj.Validado = true;
                            }
                        }
                    }
                }
                return obj;
            } catch (Exception ex) {
                throw ex;
            }
        }

        #endregion
    }
}
