using Hersan.Entidades.Calidad;
using Hersan.Entidades.Inyeccion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Hersan.Datos.Calidad
{
    public class CalidadDA : BaseDA
    {
        #region Constantes
        const string CONS_USP_CAL_INSPECCIONINYECCION_GUARDA = "CAL_InspeccionInyeccion_Guarda";
        const string CONS_USP_CAL_INSPECCIONINYECCION_ACTUALIZA = "CAL_InspeccionInyeccion_Actualiza";
        const string CONS_USP_CAL_INSPECCIONINYECCION_ANALISIS = "CAL_InspeccionInyeccion_Analisis";
        const string CONS_USP_CAL_INSPECCIONINYECCION_ANALISIS_DETALLE = "CAL_InspeccionInyeccion_Analisis_Detalle";
        #endregion

        public int CAL_InspeccionInyeccion_Guarda(CalidadBE Obj, System.Data.DataTable Detalle)
        {
            int Result = 0;
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONS_USP_CAL_INSPECCIONINYECCION_GUARDA, conn)) {
                        cmd.Parameters.AddWithValue("@IdInyeccion", Obj.Inyeccion.Id);
                        cmd.Parameters.AddWithValue("@Lista", Obj.Lista);
                        cmd.Parameters.AddWithValue("@Operador", Obj.Operador);
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
        public int CAL_InspeccionInyeccion_Actualiza(int IdInyeccion, System.Data.DataTable Detalle)
        {
            int Result = 0;
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONS_USP_CAL_INSPECCIONINYECCION_ACTUALIZA, conn)) {
                        cmd.Parameters.AddWithValue("@IdInspeccion", IdInyeccion);
                        cmd.Parameters.AddWithValue("@Detalle", Detalle);

                        cmd.CommandType = CommandType.StoredProcedure;
                        Result = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
                return Result;
            } catch (Exception ex) {
                throw ex;
            }
        }
        public List<InyeccionBE> CAL_InspeccionInyeccion_Analisis(CalidadBE Obj)
        {
            List<InyeccionBE> oList = new List<InyeccionBE>();
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONS_USP_CAL_INSPECCIONINYECCION_ANALISIS, conn)) {
                        cmd.Parameters.AddWithValue("@OP", Obj.Inyeccion.OP);
                        cmd.Parameters.AddWithValue("@COLOR", Obj.Inyeccion.Color.Nombre);
                        cmd.Parameters.AddWithValue("@Lista", Obj.Inyeccion.Detalle.Lista);
                        cmd.Parameters.AddWithValue("@Turno", Obj.Inyeccion.Detalle.Turno);
                        cmd.Parameters.AddWithValue("@Operador", Obj.Operador);
                        cmd.Parameters.AddWithValue("@Inicial", Obj.Inyeccion.Fecha);
                        cmd.Parameters.AddWithValue("@Final", Obj.Inyeccion.Detalle.Fecha);
                        cmd.Parameters.AddWithValue("@HInicial", Obj.Inyeccion.Detalle.Inicio);
                        cmd.Parameters.AddWithValue("@HIFinal", Obj.Inyeccion.Detalle.Fin);

                        cmd.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                InyeccionBE item = new InyeccionBE();

                                item.Id = int.Parse(reader["IdInyeccion"].ToString());
                                item.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                                item.OP = reader["OP"].ToString();
                                item.Detalle.Lista = reader["Lista"].ToString();
                                item.Detalle.Turno = reader["Turno"].ToString();
                                item.Operador = reader["Operador"].ToString();
                                item.Detalle.Piezas = int.Parse(reader["Piezas"].ToString());
                                item.Detalle.Virgen = int.Parse(reader["Virgen"].ToString());
                                item.Detalle.Remolido = int.Parse(reader["Remolido"].ToString());
                                item.Detalle.Master = int.Parse(reader["Master"].ToString());
                                item.Detalle.Inicio = TimeSpan.Parse(reader["Inicio"].ToString());
                                item.Detalle.Fin = TimeSpan.Parse(reader["Fin"].ToString());
                                item.Detalle.Real = int.Parse(reader["Real"].ToString());
                                item.Detalle.Muestra = int.Parse(reader["Muestra"].ToString());
                                item.Detalle.Cav1 = bool.Parse(reader["Cav1"].ToString());
                                item.Detalle.Cav2 = bool.Parse(reader["Cav2"].ToString());
                                item.Detalle.Cav3 = bool.Parse(reader["Cav3"].ToString());
                                item.Detalle.Cav4 = bool.Parse(reader["Cav4"].ToString());
                                item.Detalle.Cav5 = bool.Parse(reader["Cav5"].ToString());
                                item.Detalle.Cav6 = bool.Parse(reader["Cav6"].ToString());
                                item.Detalle.Cav7 = bool.Parse(reader["Cav7"].ToString());
                                item.Detalle.Cav8 = bool.Parse(reader["Cav8"].ToString());
                                item.Detalle.Porcentaje = decimal.Parse(reader["Porcentaje"].ToString());

                                oList.Add(item);
                            }

                        }
                        
                    }
                }
                return oList;
            } catch (Exception ex) {
                throw ex;
            }
        }
        public List<CalidadDetalleBE> CAL_InspeccionInyeccion_AnalisisDetalle(int Lista)
        {
            List<CalidadDetalleBE> oList = new List<CalidadDetalleBE>();
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONS_USP_CAL_INSPECCIONINYECCION_ANALISIS_DETALLE, conn)) {
                        cmd.Parameters.AddWithValue("@Lista", Lista);

                        cmd.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                CalidadDetalleBE item = new CalidadDetalleBE();

                                item.Hora = TimeSpan.Parse(reader["Hora"].ToString());
                                item.Cav1_1 = int.Parse(reader["Cav1"].ToString());
                                item.Cav2_1 = int.Parse(reader["Cav2"].ToString());
                                item.Cav3_1 = int.Parse(reader["Cav3"].ToString());
                                item.Cav4_1 = int.Parse(reader["Cav4"].ToString());
                                item.Cav5_1 = int.Parse(reader["Cav5"].ToString());
                                item.Cav6_1 = int.Parse(reader["Cav6"].ToString());
                                item.Cav7_1 = int.Parse(reader["Cav7"].ToString());
                                item.Cav8_1 = int.Parse(reader["Cav8"].ToString());

                                oList.Add(item);
                            }

                            if (oList.Count > 0) {
                                /* RESÚMEN */
                                if (reader.NextResult()) {
                                    while (reader.Read()) {
                                        CalidadResumenBE oDetalle = new CalidadResumenBE();
                                        oDetalle.Cavidad = int.Parse(reader["Cav"].ToString());
                                        oDetalle.Maximo = int.Parse(reader["Maximo"].ToString());
                                        oDetalle.Minimo = int.Parse(reader["Minimo"].ToString());
                                        oDetalle.Promedio = decimal.Parse(reader["Promedio"].ToString());
                                        oDetalle.DesvEst = decimal.Parse(reader["DesvE"].ToString());

                                        oList[0].Resumen.Add(oDetalle);
                                    }
                                }
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
