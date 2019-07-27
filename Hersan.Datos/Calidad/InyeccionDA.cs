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
        const string CONS_USP_PRO_TEMPERATURAS_GUARDAR = "PRO_Temperaturas_Guardar";
        const string CONS_USP_PRO_TEMPERATURAS_OBTENER = "PRO_Temperaturas_Obtener";
        const string CONS_USP_PRO_TEMPERATURASMOLDE_GUARDAR = "PRO_TemperaturasMolde_Guardar";
        const string CONS_USP_PRO_TEMPERATURASMOLDE_OBTENER = "PRO_TemperaturasMolde_Obtener";
        const string CONS_USP_PRO_PARAMETROS_GUARDAR = "PRO_Parametros_Guardar";
        const string CONS_USP_PRO_PARAMETROS_OBTENER = "PRO_Parametros_Obtener";
        const string CONS_USP_PRO_INYECCION_CONSULTA = "PRO_Inyeccion_Consulta";
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
                                obj.Real = int.Parse(reader["Real"].ToString());
                                obj.Muestra = int.Parse(reader["Muestra"].ToString());
                                obj.Porcentaje = decimal.Parse(reader["Porcentaje"].ToString());
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
        public InyeccionBE PRO_Inyeccion_Consulta(int Lista)
        {
            InyeccionBE obj = null;
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONS_USP_PRO_INYECCION_CONSULTA, conn)) {
                        cmd.Parameters.AddWithValue("@Lista", Lista);

                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                obj = new InyeccionBE();

                                /* ENCABEZADO */
                                obj.Id = int.Parse(reader["Id"].ToString());
                                obj.OP = reader["OP"].ToString();
                                obj.Color.Nombre = reader["Color"].ToString();
                                obj.Operador = reader["Operador"].ToString();
                                obj.Muestra = int.Parse(reader["Muestra"].ToString());

                                /* DETALLE */
                                obj.Detalle.Id = int.Parse(reader["IdInspecion"].ToString());
                                obj.Detalle.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                                obj.Detalle.Piezas = int.Parse(reader["Piezas"].ToString());
                                obj.Detalle.Turno = reader["Turno"].ToString();
                                obj.Detalle.Virgen = decimal.Parse(reader["Virgen"].ToString());
                                obj.Detalle.Remolido = decimal.Parse(reader["Remolido"].ToString());
                                obj.Detalle.Master = decimal.Parse(reader["Master"].ToString());
                                obj.Detalle.Cav1 = bool.Parse(reader["CAV1"].ToString());
                                obj.Detalle.Cav2 = bool.Parse(reader["CAV2"].ToString());
                                obj.Detalle.Cav3 = bool.Parse(reader["CAV3"].ToString());
                                obj.Detalle.Cav4 = bool.Parse(reader["CAV4"].ToString());
                                obj.Detalle.Cav5 = bool.Parse(reader["CAV5"].ToString());
                                obj.Detalle.Cav6 = bool.Parse(reader["CAV6"].ToString());
                                obj.Detalle.Cav7 = bool.Parse(reader["CAV7"].ToString());
                                obj.Detalle.Cav8 = bool.Parse(reader["CAV8"].ToString());

                            }

                            if (reader.NextResult()) {
                                while (reader.Read()) {
                                    obj.Norma.Cav1 = decimal.Parse(reader["NOR_Cav1"].ToString());
                                    obj.Norma.Cav2 = decimal.Parse(reader["NOR_Cav2"].ToString());
                                    obj.Norma.Cav3 = decimal.Parse(reader["NOR_Cav3"].ToString());
                                    obj.Norma.Cav4 = decimal.Parse(reader["NOR_Cav4"].ToString());
                                    obj.Norma.Cav5 = decimal.Parse(reader["NOR_Cav5"].ToString());
                                    obj.Norma.Cav6 = decimal.Parse(reader["NOR_Cav6"].ToString());
                                    obj.Norma.Cav7 = decimal.Parse(reader["NOR_Cav7"].ToString());
                                    obj.Norma.Cav8 = decimal.Parse(reader["NOR_Cav8"].ToString());
                                }
                            }
                        }
                    }
                }
                return obj;
            } catch (Exception ex) {
                throw ex;
            }
        }

        public int PRO_Temperaturas_Guardar(TemperaturasBE Obj)
        {
            int Result = 0;
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONS_USP_PRO_TEMPERATURAS_GUARDAR, conn)) {
                        cmd.Parameters.AddWithValue("@Cav1", Obj.Cav1);
                        cmd.Parameters.AddWithValue("@Cav2", Obj.Cav2);
                        cmd.Parameters.AddWithValue("@Cav3", Obj.Cav3);
                        cmd.Parameters.AddWithValue("@Cav4", Obj.Cav4);
                        cmd.Parameters.AddWithValue("@Cav5", Obj.Cav5);
                        cmd.Parameters.AddWithValue("@Cav6", Obj.Cav6);
                        cmd.Parameters.AddWithValue("@Cav7", Obj.Cav7);
                        cmd.Parameters.AddWithValue("@Cav8", Obj.Cav8);
                        cmd.Parameters.AddWithValue("@Cav9", Obj.Cav9);
                        cmd.Parameters.AddWithValue("@Cav10", Obj.Cav10);
                        cmd.Parameters.AddWithValue("@Cav11", Obj.Cav11);
                        cmd.Parameters.AddWithValue("@Cav12", Obj.Cav12);
                        cmd.Parameters.AddWithValue("@Comentarios", Obj.Observa);
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
        public TemperaturasBE PRO_Temperaturas_Obtener()
        {
            TemperaturasBE obj = null;
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONS_USP_PRO_TEMPERATURAS_OBTENER, conn)) {

                        cmd.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                obj = new TemperaturasBE();

                                obj.Cav1 = decimal.Parse(reader["CAV1"].ToString());
                                obj.Cav2 = decimal.Parse(reader["CAV2"].ToString());
                                obj.Cav3 = decimal.Parse(reader["CAV3"].ToString());
                                obj.Cav4 = decimal.Parse(reader["CAV4"].ToString());
                                obj.Cav5 = decimal.Parse(reader["CAV5"].ToString());
                                obj.Cav6 = decimal.Parse(reader["CAV6"].ToString());
                                obj.Cav7 = decimal.Parse(reader["CAV7"].ToString());
                                obj.Cav8 = decimal.Parse(reader["CAV8"].ToString());
                                obj.Cav9 = decimal.Parse(reader["CAV9"].ToString());
                                obj.Cav10 = decimal.Parse(reader["CAV10"].ToString());
                                obj.Cav11 = decimal.Parse(reader["CAV11"].ToString());
                                obj.Cav12 = decimal.Parse(reader["CAV12"].ToString());
                                obj.Observa = reader["Comentarios"].ToString();
                            }
                        }

                    }
                }
                return obj;
            } catch (Exception ex) {
                throw ex;
            }
        }

        public int PRO_TemperaturasMolde_Guardar(TempMoldesBE Obj)
        {
            int Result = 0;
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONS_USP_PRO_TEMPERATURASMOLDE_GUARDAR, conn)) {
                        cmd.Parameters.AddWithValue("@Fija", Obj.Fija);
                        cmd.Parameters.AddWithValue("@Movil", Obj.Movil);
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
        public TempMoldesBE PRO_TemperaturasMolde_Obtener()
        {
            TempMoldesBE obj = null;
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONS_USP_PRO_TEMPERATURASMOLDE_OBTENER, conn)) {

                        cmd.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                obj = new TempMoldesBE();

                                obj.Fija = decimal.Parse(reader["Fija"].ToString());
                                obj.Movil = decimal.Parse(reader["Movil"].ToString());
                            }
                        }

                    }
                }
                return obj;
            } catch (Exception ex) {
                throw ex;
            }
        }

        public int PRO_Parametros_Guardar(DataTable Tabla)
        {
            int Result = 0;
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONS_USP_PRO_PARAMETROS_GUARDAR, conn)) {
                        cmd.Parameters.AddWithValue("@Parametos", Tabla);

                        cmd.CommandType = CommandType.StoredProcedure;
                        Result = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
                return Result;
            } catch (Exception ex) {
                throw ex;
            }
        }
        public ParametrosInyeccion PRO_Parametros_Obtener()
        {
            ParametrosInyeccion obj = null;
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONS_USP_PRO_PARAMETROS_OBTENER, conn)) {

                        cmd.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                obj = new ParametrosInyeccion();

                                obj.Presion1 = decimal.Parse(reader["Presion1"].ToString());
                                obj.Presion2 = decimal.Parse(reader["Presion2"].ToString());
                                obj.Presion3 = decimal.Parse(reader["Presion3"].ToString());
                                obj.Velocidad1 = decimal.Parse(reader["Velocidad1"].ToString());
                                obj.Velocidad2 = decimal.Parse(reader["Velocidad2"].ToString());
                                obj.Velocidad3 = decimal.Parse(reader["Velocidad3"].ToString());
                                obj.PosicionC1 = decimal.Parse(reader["PosicionC1"].ToString());
                                obj.PosicionC2 = decimal.Parse(reader["PosicionC2"].ToString());
                                obj.PresionC1 = decimal.Parse(reader["PresionC1"].ToString());
                                obj.PresionC2 = decimal.Parse(reader["PresionC2"].ToString());
                                obj.VelocidadC1 = decimal.Parse(reader["VelocidadC1"].ToString());
                                obj.VelocidadC2 = decimal.Parse(reader["VelocidadC2"].ToString());
                                obj.Posicion = reader["Posicion"].ToString();
                                obj.Presion = decimal.Parse(reader["Presion"].ToString());
                                obj.Velocidad = decimal.Parse(reader["Velocidad"].ToString());
                                obj.Retardo = decimal.Parse(reader["RetardEnfria"].ToString());
                                obj.Zona4 = decimal.Parse(reader["Zona4"].ToString());
                                obj.Zona3 = decimal.Parse(reader["Zona3"].ToString());
                                obj.Zona2 = decimal.Parse(reader["Zona2"].ToString());
                                obj.Zona1 = decimal.Parse(reader["Zona1"].ToString());
                                obj.Observa = reader["Observa"].ToString();
                                obj.Cavidades = reader["Cavidades"].ToString();
                            }
                        }

                    }
                }
                return obj;
            } catch (Exception ex) {
                throw ex;
            }
        }
      

    }
}
