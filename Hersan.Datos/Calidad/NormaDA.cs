using Hersan.Entidades.Calidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Hersan.Datos.Calidad
{
    public class NormaDA : BaseDA
    {
        #region Constantes
        const string CONS_USP_CAL_REFLEJANTESNORMA_GUARDAR = "CAL_ReflejantesNorma_Guardar";
        const string CONS_USP_CAL_REFLEJANTESNORMA_ACTUALIZAR = "CAL_ReflejantesNorma_Actualizar";
        const string CONS_USP_CAL_REFLEJANTESNORMA_OBTENER = "CAL_ReflejantesNorma_Obtener";
        #endregion

        public int CAL_ReflejantesNorma_Guardar(NormaBE Obj)
        {
            int Result = 0;
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONS_USP_CAL_REFLEJANTESNORMA_GUARDAR, conn)) {
                        cmd.Parameters.AddWithValue("@IdColor", Obj.Color.Id);
                        cmd.Parameters.AddWithValue("@Norma", Obj.Norma);
                        cmd.Parameters.AddWithValue("@Limite", Obj.Limite);
                        cmd.Parameters.AddWithValue("@IdUsuario", Obj.DatosUsuario.IdUsuarioCreo);

                        cmd.CommandType = CommandType.StoredProcedure;
                        Result = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
                return Result;
            } catch (Exception ex) {
                throw ex;
            }
        }
        public int CAL_ReflejantesNorma_Actualizar(NormaBE Obj)
        {
            int Result = 0;
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONS_USP_CAL_REFLEJANTESNORMA_ACTUALIZAR, conn)) {
                        cmd.Parameters.AddWithValue("@Id", Obj.Id);
                        cmd.Parameters.AddWithValue("@IdColor", Obj.Color.Id);
                        cmd.Parameters.AddWithValue("@Norma", Obj.Norma);
                        cmd.Parameters.AddWithValue("@Limite", Obj.Limite);
                        cmd.Parameters.AddWithValue("@IdUsuario", Obj.DatosUsuario.IdUsuarioCreo);
                        cmd.Parameters.AddWithValue("@Estatus", Obj.DatosUsuario.Estatus);

                        cmd.CommandType = CommandType.StoredProcedure;
                        Result = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
                return Result;
            } catch (Exception ex) {
                throw ex;
            }
        }
        public List<NormaBE> CAL_ReflejantesNorma_Obtener()
        {
            List<NormaBE> oList = new List<NormaBE>();
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONS_USP_CAL_REFLEJANTESNORMA_OBTENER, conn)) {

                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                NormaBE Obj = new NormaBE();

                                Obj.Id = int.Parse(reader["NOR_Id"].ToString());
                                Obj.Color.Id = int.Parse(reader["COL_Id"].ToString());
                                Obj.Color.Nombre = reader["COL_Nombre"].ToString();
                                Obj.Norma = int.Parse(reader["NOR_Norma"].ToString());
                                Obj.Limite = decimal.Parse(reader["NOR_Limite"].ToString());
                                Obj.DatosUsuario.Estatus = bool.Parse(reader["NOR_Estatus"].ToString());

                                oList.Add(Obj);
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
