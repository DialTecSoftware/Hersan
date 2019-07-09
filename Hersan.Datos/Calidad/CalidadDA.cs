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

        const string CONS_USP_CAL_INSPECCIONENSAMBLE_ANALISIS = "CAL_InspeccionEnsamble_Analisis";
        const string CONS_USP_CAL_INSPECCIONENSAMBLE_ANALISIS_DETALLE = "CAL_InspeccionEnsamble_Analisis_Detalle";

        const string CONS_USP_CAL_RESGUARDOQA_GUARDAR = "CAL_ResguardoQA_Guardar";
        const string CONS_USP_CAL_RESGUARDOQA_ACTUALIZAR = "CAL_ResguardoQA_Actualizar";
        const string CONS_USP_CAL_RESGUARDOQA_OBTENER = "CAL_ResguardoQA_Obtener";

        const string CONS_USP_CAL_ANALISISINYECCION_HISTOGRAMA = "CAL_AnalisisInyeccion_Histograma";
        const string CONS_USP_CAL_ANALISISINYECCION_GRAFICACONTROL = "CAL_AnalisisInyeccion_GraficaControl";
        #endregion

        public int CAL_InspeccionInyeccion_Guarda(CalidadBE Obj, DataTable Detalle)
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
        public int CAL_InspeccionInyeccion_Actualiza(int IdInyeccion, DataTable Detalle)
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

        public List<CalidadEnsambleBE> CAL_InspeccionEnsamble_Analisis(CalidadEnsambleBE Obj)
        {
            List<CalidadEnsambleBE> oList = new List<CalidadEnsambleBE>();
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONS_USP_CAL_INSPECCIONENSAMBLE_ANALISIS, conn)) {
                        cmd.Parameters.AddWithValue("@OP", Obj.Parametros.OP);
                        cmd.Parameters.AddWithValue("@Lista", Obj.Parametros.Lista);
                        cmd.Parameters.AddWithValue("@IdProd", Obj.Parametros.Producto.Id);
                        cmd.Parameters.AddWithValue("@IdColor", Obj.Parametros.Carcasa.Id);
                        cmd.Parameters.AddWithValue("@IdRef1", Obj.Parametros.Reflex1.Id);
                        cmd.Parameters.AddWithValue("@IdRef2", Obj.Parametros.Reflex2.Id);
                        cmd.Parameters.AddWithValue("@Operador", Obj.Operador);
                        cmd.Parameters.AddWithValue("@Inicial", Obj.Parametros.DatosUsuario.FechaCreacion);
                        cmd.Parameters.AddWithValue("@Final", Obj.Parametros.DatosUsuario.FechaModif);

                        cmd.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                CalidadEnsambleBE item = new CalidadEnsambleBE();

                                item.Id = int.Parse(reader["Id"].ToString());
                                item.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                                item.Parametros.OP = reader["OP"].ToString();
                                item.Parametros.Lista = int.Parse(reader["Lista"].ToString());
                                item.Parametros.Producto.Nombre = reader["TPR_Nombre"].ToString();
                                item.Parametros.Carcasa.Nombre = reader["Carcasa"].ToString();
                                item.Parametros.Reflex1.Nombre = reader["Reflex1"].ToString();
                                item.Parametros.Reflex2.Nombre = reader["Reflex2"].ToString();
                                item.Operador = reader["Operador"].ToString();

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
        public List<CalidadEnsambleDetalleBE> CAL_InspeccionEnsamble_AnalisisDetalle(int Lista)
        {
            List<CalidadEnsambleDetalleBE> oList = new List<CalidadEnsambleDetalleBE>();
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONS_USP_CAL_INSPECCIONENSAMBLE_ANALISIS_DETALLE, conn)) {
                        cmd.Parameters.AddWithValue("@Lista", Lista);

                        cmd.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                CalidadEnsambleDetalleBE item = new CalidadEnsambleDetalleBE();

                                item.Lote = reader["Lote"].ToString();
                                item.Reflejante = int.Parse(reader["Reflejante"].ToString());
                                item.Obs1 = int.Parse(reader["Obs1"].ToString());
                                item.Obs2 = int.Parse(reader["Obs2"].ToString());
                                item.Obs3 = int.Parse(reader["Obs3"].ToString());
                                item.Obs4 = int.Parse(reader["Obs4"].ToString());
                                item.Obs5 = int.Parse(reader["Obs5"].ToString());

                                oList.Add(item);
                            }

                            if (oList.Count > 0) {
                                /* RESÚMEN */
                                if (reader.NextResult()) {
                                    while (reader.Read()) {
                                        CalidadResumenBE oDetalle = new CalidadResumenBE();
                                        oDetalle.Fecha = DateTime.Parse(reader["Fecha"].ToString());
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

        public int CAL_ResguardoQA_Guardar(CalidadResguardoQA Obj, DataTable Detalle)
        {
            int Result = 0;
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONS_USP_CAL_RESGUARDOQA_GUARDAR, conn)) {
                        cmd.Parameters.AddWithValue("@Nombre", Obj.Nombre);
                        cmd.Parameters.AddWithValue("@IdProducto", Obj.Producto.Id);
                        cmd.Parameters.AddWithValue("@IdCarcasa", Obj.Carcasa.Id);
                        cmd.Parameters.AddWithValue("@Reflex1", Obj.Reflex1.Id);
                        cmd.Parameters.AddWithValue("@Reflex2", Obj.Reflex2.Id);
                        cmd.Parameters.AddWithValue("@Piezas", Obj.Piezas);
                        cmd.Parameters.AddWithValue("@Fecha", Obj.Fecha);
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
        public int CAL_ResguardoQA_Actualizar(CalidadResguardoQA Obj, DataTable Detalle)
        {
            int Result = 0;
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONS_USP_CAL_RESGUARDOQA_ACTUALIZAR, conn)) {
                        cmd.Parameters.AddWithValue("@Id", Obj.Id);
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
        public List<CalidadResguardoQA> CAL_ResguardoQA_Obtener(int IdProducto, string Fecha)
        {
            List<CalidadResguardoQA> oList = new List<CalidadResguardoQA>();
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONS_USP_CAL_RESGUARDOQA_OBTENER, conn)) {
                        cmd.Parameters.AddWithValue("@IdProducto", IdProducto);
                        cmd.Parameters.AddWithValue("@Fecha", Fecha);

                        cmd.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                CalidadResguardoQA Obj = new CalidadResguardoQA();

                                Obj.Id = int.Parse(reader["RES_Id"].ToString());
                                Obj.Nombre = reader["Nombre"].ToString();
                                Obj.Producto.Id = int.Parse(reader["TPR_Id"].ToString());
                                Obj.Carcasa.Id = int.Parse(reader["COL_Id"].ToString());
                                Obj.Reflex1.Id = int.Parse(reader["Reflex1"].ToString());
                                Obj.Reflex2.Id = int.Parse(reader["Reflex2"].ToString());
                                Obj.Piezas = int.Parse(reader["Piezas"].ToString());

                                oList.Add(Obj);
                            }

                            if (oList.Count > 0) {
                                if (reader.NextResult()) {
                                    while (reader.Read()) {
                                        CalidadResguardoQADetalle Item = new CalidadResguardoQADetalle();
                                        
                                        Item.Id = int.Parse(reader["RDE_Id"].ToString());
                                        Item.IdResguardo = int.Parse(reader["RES_Id"].ToString());
                                        Item.Lote = reader["Lote"].ToString();
                                        Item.Valor0 = int.Parse(reader["Valor0"].ToString());
                                        Item.Valor1 = int.Parse(reader["Valor1"].ToString());
                                        Item.Valor2 = int.Parse(reader["Valor2"].ToString());
                                        Item.Lista = int.Parse(reader["Lista"].ToString());
                                        Item.Promedio = int.Parse(reader["Promedio"].ToString());
                                        Item.Minimo = int.Parse(reader["Minimo"].ToString());
                                        Item.Maximo = int.Parse(reader["Maximo"].ToString());
                                        Item.OP = reader["OP"].ToString();

                                        oList[0].Detalle.Add(Item);                                    }
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


        public List<CalidadGraficasCavidades> CAL_AnalisisInyeccion_Histograma(int Lista)
        {
            List<CalidadGraficasCavidades> oList = new List<CalidadGraficasCavidades>();
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONS_USP_CAL_ANALISISINYECCION_HISTOGRAMA, conn)) {
                        cmd.Parameters.AddWithValue("@Lista", Lista);

                        cmd.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                CalidadGraficasCavidades Obj = new CalidadGraficasCavidades();

                                Obj.Cav1 = bool.Parse(reader["Cav1"].ToString());
                                Obj.Cav2 = bool.Parse(reader["Cav2"].ToString());
                                Obj.Cav3 = bool.Parse(reader["Cav3"].ToString());
                                Obj.Cav4 = bool.Parse(reader["Cav4"].ToString());
                                Obj.Cav5 = bool.Parse(reader["Cav5"].ToString());
                                Obj.Cav6 = bool.Parse(reader["Cav6"].ToString());
                                Obj.Cav7 = bool.Parse(reader["Cav7"].ToString());
                                Obj.Cav8 = bool.Parse(reader["Cav8"].ToString());

                                oList.Add(Obj);

                                if (oList.Count > 0) {
                                    if (reader.NextResult()) {
                                        while (reader.Read()) {
                                            CalidadGraficasValores Item = new CalidadGraficasValores();

                                            Item.Limite = int.Parse(reader["Superior"].ToString());
                                            Item.Val1 = int.Parse(reader["Val1"].ToString());
                                            Item.Val2 = int.Parse(reader["Val2"].ToString());
                                            Item.Val3 = int.Parse(reader["Val3"].ToString());
                                            Item.Val4 = int.Parse(reader["Val4"].ToString());
                                            Item.Val5 = int.Parse(reader["Val5"].ToString());
                                            Item.Val6 = int.Parse(reader["Val6"].ToString());
                                            Item.Val7 = int.Parse(reader["Val7"].ToString());
                                            Item.Val8 = int.Parse(reader["Val8"].ToString());

                                            oList[0].Valores.Add(Item);
                                        }
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
        public List<CalidadGraficasCavidades> CAL_AnalisisInyeccion_GraficaControl(int Lista, string Fecha)
        {
            List<CalidadGraficasCavidades> oList = new List<CalidadGraficasCavidades>();
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONS_USP_CAL_ANALISISINYECCION_GRAFICACONTROL, conn)) {
                        cmd.Parameters.AddWithValue("@Lista", Lista);
                        cmd.Parameters.AddWithValue("@Fecha", Fecha);

                        cmd.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                CalidadGraficasCavidades Obj = new CalidadGraficasCavidades();

                                Obj.Cav1 = bool.Parse(reader["Cav1"].ToString());
                                Obj.Cav2 = bool.Parse(reader["Cav2"].ToString());
                                Obj.Cav3 = bool.Parse(reader["Cav3"].ToString());
                                Obj.Cav4 = bool.Parse(reader["Cav4"].ToString());
                                Obj.Cav5 = bool.Parse(reader["Cav5"].ToString());
                                Obj.Cav6 = bool.Parse(reader["Cav6"].ToString());
                                Obj.Cav7 = bool.Parse(reader["Cav7"].ToString());
                                Obj.Cav8 = bool.Parse(reader["Cav8"].ToString());

                                oList.Add(Obj);

                                if (oList.Count > 0) {
                                    if (reader.NextResult()) {
                                        while (reader.Read()) {
                                            CalidadGraficasValores Item = new CalidadGraficasValores();

                                            Item.Hora = TimeSpan.Parse(reader["Hora"].ToString());
                                            Item.Val1 = int.Parse(reader["Cav1"].ToString());
                                            Item.Val2 = int.Parse(reader["Cav2"].ToString());
                                            Item.Val3 = int.Parse(reader["Cav3"].ToString());
                                            Item.Val4 = int.Parse(reader["Cav4"].ToString());
                                            Item.Val5 = int.Parse(reader["Cav5"].ToString());
                                            Item.Val6 = int.Parse(reader["Cav6"].ToString());
                                            Item.Val7 = int.Parse(reader["Cav7"].ToString());
                                            Item.Val8 = int.Parse(reader["Cav8"].ToString());

                                            oList[0].Valores.Add(Item);
                                        }
                                    }

                                    /* VALORES DE LA NORMA POR CAVIDAD */
                                    if (reader.NextResult()) {
                                        while (reader.Read()) {
                                            Obj.Norma.Cav1 = decimal.Parse(reader["NOR_Cav1"].ToString());
                                            Obj.Norma.Cav2 = decimal.Parse(reader["NOR_Cav2"].ToString());
                                            Obj.Norma.Cav3 = decimal.Parse(reader["NOR_Cav3"].ToString());
                                            Obj.Norma.Cav4 = decimal.Parse(reader["NOR_Cav4"].ToString());
                                            Obj.Norma.Cav5 = decimal.Parse(reader["NOR_Cav5"].ToString());
                                            Obj.Norma.Cav6 = decimal.Parse(reader["NOR_Cav6"].ToString());
                                            Obj.Norma.Cav7 = decimal.Parse(reader["NOR_Cav7"].ToString());
                                            Obj.Norma.Cav8 = decimal.Parse(reader["NOR_Cav8"].ToString());
                                        }
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
