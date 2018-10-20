using Hersan.Entidades.Comun;
using Hersan.Entidades.Seguridad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hersan.Datos.Seguridad
{
    public class RolesDA : BaseDA
    {
        #region Constantes
        private const string CSTR_SP_OBTIENEROLES = "SEG_Roles_Obtiene";
        private const string CSTR_SP_GUARDAROLES = "SEG_Roles_Inserta";
        private const string CSTR_SP_ACTUALIZAROLES = "SEG_Roles_Actualiza";
        #endregion

        /// <summary>
        /// Obtener Listado de Roles
        /// </summary>
        /// <returns></returns>
        public List<RolesBE> ObtieneRoles(int IdEmpresa)
        {
            try
            {
                List<RolesBE> lst = new List<RolesBE>();
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion()))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CSTR_SP_OBTIENEROLES, conn))
                    {
                        cmd.Parameters.AddWithValue("@Emp_Id", IdEmpresa);
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                RolesBE obj = new RolesBE();
                                obj.ID = int.Parse(reader["ROL_IdRol"].ToString());
                                obj.Nombre = reader["ROL_Rol"].ToString();
                                obj.Activo = bool.Parse(reader["ROL_Estatus"].ToString());

                                lst.Add(obj);
                            }
                        }
                    }
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Guarda el nuevo Rol
        /// </summary>
        /// <param name="Rol">Nombre del rol a insertar</param>
        /// <param name="IdUsuario">Id del usuario que guarda el nuevo rol</param>
        /// <param name="Estatus">Estatus del nuevo rol</param>
        /// <returns></returns>
        public ResultadoBE GuardaRoles(string Rol, int IdEmpresa, int IdUsuario, bool Estatus)
        {
            ResultadoBE res = new ResultadoBE();
            try{
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion()))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CSTR_SP_GUARDAROLES, conn))
                    {
                                                
                        cmd.Parameters.AddWithValue("@Rol", Rol);
                        cmd.Parameters.AddWithValue("@Emp_Id", IdEmpresa);
                        cmd.Parameters.AddWithValue("@Idusuario", IdUsuario);
                        cmd.Parameters.AddWithValue("@Estatus", Estatus);

                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.ExecuteNonQuery();
                    }
                }
            }catch (Exception ex){
                res.EsValido = true;
                res.Error = ex.Message;
            }

            return res;
        }

        /// <summary>
        /// Actualiza el Rol
        /// </summary>
        /// <param name="IdRol">Id del rol a actualizar</param>
        /// <param name="Rol">Nombre del rol a actualizar</param>
        /// <param name="IdUsuario">Usuario que actualiza</param>
        /// <param name="Estatus">Estatus del rol</param>
        /// <returns></returns>
        public ResultadoBE ActualizaRoles(int IdRol, string Rol, int IdEmpresa, int IdUsuario, bool Estatus)
        {
            ResultadoBE res = new ResultadoBE();
            try
            {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion()))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CSTR_SP_ACTUALIZAROLES, conn))
                    {
                        int param = 0;
                        cmd.Parameters.AddWithValue("@IdRol", IdRol);
                        cmd.Parameters.AddWithValue("@Rol", Rol);
                        cmd.Parameters.AddWithValue("@EMP_Id", IdEmpresa);
                        cmd.Parameters.AddWithValue("@Idusuario", IdUsuario);
                        cmd.Parameters.AddWithValue("@Estatus", Estatus);

                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.ExecuteNonQuery();
                    }
                }
                return res;
            }
            catch (Exception ex)
            {
                res.EsValido = true;
                res.Error = ex.Message;
            }

            return res;
        }
    }
}
