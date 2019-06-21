using Hersan.Entidades.Inyeccion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Hersan.Datos.Calidad
{
    public class InyeccionDA : BaseDA
    {

        #region Constantes
        const string CONS_USP_PRO_INYECCION_GUARDAR = "PRO_Inyeccion_Guardar";
        const string CONS_USP_PRO_INYECCION_OBTENER = "PRO_Inyeccion_Obtener";
        #endregion

        public int PRO_Inyeccion_Guardar(InyeccionBE Obj, DataTable Detalle)
        {
            int Result = 0;
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONS_USP_PRO_INYECCION_GUARDAR, conn)) {
                        cmd.Parameters.AddWithValue("@OP", Obj.OP);
                        cmd.Parameters.AddWithValue("@Color", Obj.Color.Nombre);
                        cmd.Parameters.AddWithValue("@Detalle", Detalle);
                        cmd.Parameters.AddWithValue("@IdUsuario", Obj.IdUsuario);

                        cmd.CommandType = CommandType.StoredProcedure;
                        Result = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
                return Result;
            } catch (Exception ex) {
                throw ex;
            }
        }
        public List<InyeccionDetalleBE> PRO_Inyeccion_Obtener(InyeccionBE Obj)
        {
            List<InyeccionDetalleBE> oList = new List<InyeccionDetalleBE>();
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONS_USP_PRO_INYECCION_OBTENER, conn)) {
                        cmd.Parameters.AddWithValue("@OP", Obj.OP);
                        cmd.Parameters.AddWithValue("@Color", Obj.Color.Nombre);


                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                InyeccionDetalleBE obj = new InyeccionDetalleBE();

                                obj.Id = int.Parse(reader["IdInyeccion"].ToString());
                                obj.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                                obj.Lista = reader["Lista"].ToString();
                                obj.Turno = reader["Turno"].ToString();
                                obj.Piezas = int.Parse(reader["Piezas"].ToString());
                                obj.Virgen = decimal.Parse(reader["Virgen"].ToString());
                                obj.Remolido = decimal.Parse(reader["Remolido"].ToString());
                                obj.Master = decimal.Parse(reader["Master"].ToString());
                                obj.Inicio = TimeSpan.Parse(reader["Inicio"].ToString());
                                obj.Fin = TimeSpan.Parse(reader["Fin"].ToString());
                                obj.Cav1 = bool.Parse(reader["CAV1"].ToString());
                                obj.Cav2 = bool.Parse(reader["CAV2"].ToString());
                                obj.Cav3 = bool.Parse(reader["CAV3"].ToString());
                                obj.Cav4 = bool.Parse(reader["CAV4"].ToString());
                                obj.Cav5 = bool.Parse(reader["CAV5"].ToString());
                                obj.Cav6 = bool.Parse(reader["CAV6"].ToString());
                                obj.Cav7 = bool.Parse(reader["CAV7"].ToString());
                                obj.Cav8 = bool.Parse(reader["CAV8"].ToString());

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
