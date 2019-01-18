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
   public class EquipoHerramientasDA: BaseDA
    {


        #region Constantes
        const string CONST_USP_ABC_EHE_OBTENER = "ABC_EquipoHerramientas_Obtener";
        const string CONST_ABC_EHE_GUARDAR = "ABC_EquipoHerramientas_Guarda";
        const string CONST_ABC_EHE_ACTUALIZAR = "[ABC_EquipoHerramientas_Actualiza]";
        #endregion

        public List<EquipoHerramientasBE> ABCEquipoHerramientas_Obtener()
        {
            List<EquipoHerramientasBE> oList = new List<EquipoHerramientasBE>();
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_USP_ABC_EHE_OBTENER, conn)) {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                EquipoHerramientasBE obj = new EquipoHerramientasBE();

                                obj.Id = int.Parse(reader["EHE_Id"].ToString());
                                obj.Nombre = reader["EHE_Nombre"].ToString();
                                obj.Equipo = bool.Parse(reader["EHE_Equipo"].ToString());
                                obj.DatosUsuario.Estatus = bool.Parse(reader["EHE_Estatus"].ToString());

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
        public int ABCEquipoHerramientas_Guardar(EquipoHerramientasBE obj)
        {
            int Result = 0;
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_ABC_EHE_GUARDAR, conn)) {
                        cmd.Parameters.AddWithValue("@Nombre", obj.Nombre);
                        cmd.Parameters.AddWithValue("@Equipo", obj.Equipo);
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


        public int ABCEquipoHerramientas_Actualizar(EquipoHerramientasBE obj)
        {
            int Result = 0;
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_ABC_EHE_ACTUALIZAR, conn)) {
                        cmd.Parameters.AddWithValue("@Id", obj.Id);
                        cmd.Parameters.AddWithValue("@Nombre", obj.Nombre);
                        cmd.Parameters.AddWithValue("@Equipo", obj.Equipo);
                        cmd.Parameters.AddWithValue("@Estatus", obj.DatosUsuario.Estatus);
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
    }
}
