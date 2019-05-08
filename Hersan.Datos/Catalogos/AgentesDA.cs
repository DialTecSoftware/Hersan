using Hersan.Entidades.Catalogos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hersan.Datos.Catalogos
{
    public class AgentesDA: BaseDA
    {
        #region Constantes
        const string CONST_ABC_AGENTES_OBTENER = "ABC_Agentes_Obtener";
        const string CONST_ABC_AGENTES_GUARDAR = "ABC_Agentes_Guardar";
        const string CONST_ABC_AGENTES_ACTUALIZAR = "ABC_Agentes_Actualizar";
        const string CONST_ABC_AGENTES_COMBO = "ABC_Agentes_Combo";
        #endregion

        public List<AgentesBE> ABC_Agentes_Obtener()
        {
            List<AgentesBE> oList = new List<AgentesBE>();
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_ABC_AGENTES_OBTENER, conn)) {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                AgentesBE obj = new AgentesBE();

                                obj.Id = int.Parse(reader["AGE_Id"].ToString());
                                obj.Nombre = reader["AGE_Nombre"].ToString();
                                obj.Clave = reader["AGE_Clave"].ToString();
                                obj.Correo = reader["AGE_Correo"].ToString();
                                obj.Comision = decimal.Parse(reader["AGE_Comision"].ToString());
                                obj.DatosUsuario.Estatus = bool.Parse(reader["AGE_Estatus"].ToString());

                                oList.Add(obj);
                            }
                        }
                    }
                }
                return oList;
            } catch (Exception ex) {
                throw ex;
            }
        }
        public int ABC_Agentes_Guardar(AgentesBE obj)
        {
            int Result = 0;
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_ABC_AGENTES_GUARDAR, conn)) {
                        cmd.Parameters.AddWithValue("@Clave", obj.Clave);
                        cmd.Parameters.AddWithValue("@Nombre", obj.Nombre);
                        cmd.Parameters.AddWithValue("@Correo", obj.Correo);
                        cmd.Parameters.AddWithValue("@Comision", obj.Comision);
                        cmd.Parameters.AddWithValue("@IdUsuario", obj.DatosUsuario.IdUsuarioCreo);

                        cmd.CommandType = CommandType.StoredProcedure;
                        Result = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
                return Result;
            } catch (Exception ex) {
                throw ex;
            }
        }
        public int ABC_Agentes_Actualizar(AgentesBE obj)
        {
            int Result = 0;
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_ABC_AGENTES_ACTUALIZAR, conn)) {
                        cmd.Parameters.AddWithValue("@Id", obj.Id);
                        cmd.Parameters.AddWithValue("@Clave", obj.Clave);
                        cmd.Parameters.AddWithValue("@Nombre", obj.Nombre);
                        cmd.Parameters.AddWithValue("@Correo", obj.Correo);
                        cmd.Parameters.AddWithValue("@Comision", obj.Comision);
                        cmd.Parameters.AddWithValue("@IdUsuario", obj.DatosUsuario.IdUsuarioCreo);
                        cmd.Parameters.AddWithValue("@Estatus", obj.DatosUsuario.Estatus);

                        cmd.CommandType = CommandType.StoredProcedure;
                        Result = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
                return Result;
            } catch (Exception ex) {
                throw ex;
            }
        }
        public List<AgentesBE> ABC_Agentes_Combo()
        {
            List<AgentesBE> oList = new List<AgentesBE>();
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_ABC_AGENTES_COMBO, conn)) {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                AgentesBE obj = new AgentesBE();

                                obj.Id = int.Parse(reader["AGE_Id"].ToString());
                                obj.Nombre = reader["AGE_Nombre"].ToString();
                                obj.Clave = reader["AGE_Clave"].ToString();

                                oList.Add(obj);
                            }
                        }
                    }
                }
                return oList;
            } catch (Exception ex) {
                throw ex;
            }
        }


    }
}
