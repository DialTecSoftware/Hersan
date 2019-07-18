using Hersan.Entidades.Calidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hersan.Datos.Calidad
{
    public class EnsambleDA : BaseDA
    {
        #region Constantes
        const string CONS_USP_PRO_ENSAMBLE_PARAMETROS_GUARDAR = "PRO_Ensamble_Parametros_Guardar";
        const string CONS_USP_PRO_ENSAMBLE_PARAMETROS_OBTENER = "PRO_Ensamble_Parametros_Obtener";

        const string CONS_USP_CAL_INSPECCIONENSAMBLE_GUARDAR = "CAL_InspeccionEnsamble_Guardar";
        const string CONS_USP_CAL_INSPECCIONENSAMBLE_ACTUALIZAR = "CAL_InspeccionEnsamble_Actualizar";
        const string CONS_USP_CAL_INSPECCIONENSAMBLE_OBTENER = "CAL_InspeccionEnsamble_Obtener";
        const string CONS_USP_CAL_INSPECCIONENSAMBLE_CONSULTAR = "CAL_InspeccionEnsamble_Consultar";
        #endregion

        public int PRO_Ensamble_Parametros_Guardar(EnsambleParametrosBE Obj, DataTable Detalle)
        {
            int Result = 0;
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONS_USP_PRO_ENSAMBLE_PARAMETROS_GUARDAR, conn)) {
                        cmd.Parameters.AddWithValue("@OP", Obj.OP);
                        cmd.Parameters.AddWithValue("@Lista", Obj.Lista);
                        cmd.Parameters.AddWithValue("@IdProd", Obj.Producto.Id);
                        cmd.Parameters.AddWithValue("@IdColor", Obj.Carcasa.Id);
                        cmd.Parameters.AddWithValue("@Reflejante1", Obj.Reflex1.Id);
                        cmd.Parameters.AddWithValue("@Reflejante2", Obj.Reflex2.Id);
                        cmd.Parameters.AddWithValue("@Detalle", Detalle);
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
        public List<EnsambleParametrosBE>  PRO_Ensamble_Parametros_Obtener(EnsambleParametrosBE Obj)
        {
            List<EnsambleParametrosBE> oList = new List<EnsambleParametrosBE>();
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONS_USP_PRO_ENSAMBLE_PARAMETROS_OBTENER, conn)) {
                        cmd.Parameters.AddWithValue("@OP", Obj.OP);
                        cmd.Parameters.AddWithValue("@Lista", Obj.Lista);
                        //cmd.Parameters.AddWithValue("@IdProd", Obj.Producto.Id);

                        cmd.CommandType = CommandType.StoredProcedure;
                        
                        using (SqlDataReader reader= cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                EnsambleParametrosBE Enc = new EnsambleParametrosBE();

                                Enc.Id = int.Parse(reader["Id"].ToString());
                                Enc.Producto.Id = int.Parse(reader["TPR_Id"].ToString());
                                Enc.Carcasa.Id = int.Parse(reader["COL_Id"].ToString());
                                Enc.Reflex1.Id = int.Parse(reader["COLR1_Id"].ToString());
                                Enc.Reflex2.Id = int.Parse(reader["COLR2_Id"].ToString());

                                oList.Add(Enc);
                            }

                            if (oList.Count > 0) {
                                if (reader.NextResult()) {
                                    while (reader.Read()) {
                                        EnsambleParametrosDetalleBE Item = new EnsambleParametrosDetalleBE();

                                        Item.Id = int.Parse(reader["IdDetalle"].ToString());
                                        Item.IdParametro = int.Parse(reader["IdParametro"].ToString());
                                        Item.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                                        Item.Maquina = reader["Maquina"].ToString();
                                        Item.Presion = decimal.Parse(reader["Presion"].ToString());
                                        Item.Energia = decimal.Parse(reader["Energia"].ToString());
                                        Item.Colapso = reader["Colapso"].ToString();
                                        Item.Tiempo = reader["Tiempo"].ToString();
                                        Item.Planeada = int.Parse(reader["Planeada"].ToString());
                                        Item.Real = int.Parse(reader["Real"].ToString());
                                        Item.Comentarios = reader["Comentarios"].ToString();
                                        Item.Estatus = bool.Parse(reader["Estatus"].ToString());

                                        oList[0].Detalle.Add(Item);
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
        
        public int CAL_InspeccionEnsamble_Guardar(CalidadEnsambleBE Obj, DataTable Detalle)
        {
            int Result = 0;
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONS_USP_CAL_INSPECCIONENSAMBLE_GUARDAR, conn)) {
                        cmd.Parameters.AddWithValue("@IdParametro", Obj.Parametros.Id);
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
        public int CAL_InspeccionEnsamble_Actualizar(CalidadEnsambleBE Obj, System.Data.DataTable Detalle)
        {
            int Result = 0;
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONS_USP_CAL_INSPECCIONENSAMBLE_ACTUALIZAR, conn)) {
                        cmd.Parameters.AddWithValue("@IdInspeccion", Obj.Id);
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
        public List<CalidadEnsambleDetalleBE> CAL_InspeccionEnsamble_Obtener(int Lista)
        {
            List<CalidadEnsambleDetalleBE> oList = new List<CalidadEnsambleDetalleBE>();
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONS_USP_CAL_INSPECCIONENSAMBLE_OBTENER, conn)) {
                        cmd.Parameters.AddWithValue("@Lista", Lista);

                        cmd.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                CalidadEnsambleDetalleBE item = new CalidadEnsambleDetalleBE();

                                item.Id = int.Parse(reader["Id"].ToString());
                                item.IdInspeccion = int.Parse(reader["IdInpeccion"].ToString());
                                item.Lote = reader["Lote"].ToString();
                                item.Maquina = reader["Maquina"].ToString();
                                item.Reflejante = int.Parse(reader["Reflejante"].ToString());
                                item.Obs1 = int.Parse(reader["Obs1"].ToString());
                                item.Obs2 = int.Parse(reader["Obs2"].ToString());
                                item.Obs3 = int.Parse(reader["Obs3"].ToString());
                                item.Obs4 = int.Parse(reader["Obs4"].ToString());
                                item.Obs5 = int.Parse(reader["Obs5"].ToString());

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
        public List<CalidadEnsambleBE> CAL_InspeccionEnsamble_Consultar(int Lista)
        {
            List<CalidadEnsambleBE> oList = new List<CalidadEnsambleBE>();
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONS_USP_CAL_INSPECCIONENSAMBLE_CONSULTAR, conn)) {
                        cmd.Parameters.AddWithValue("@Lista", Lista);

                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                CalidadEnsambleBE Obj = new CalidadEnsambleBE();

                                Obj.Id = int.Parse(reader["IdInspeccion"].ToString());
                                Obj.Parametros.Id = int.Parse(reader["Id"].ToString());
                                Obj.Parametros.OP = reader["OP"].ToString();
                                Obj.Parametros.Producto.Nombre = reader["TPR_Nombre"].ToString();
                                Obj.Parametros.Carcasa.Nombre = reader["COL_Nombre"].ToString();
                                Obj.Parametros.Reflex1.Nombre = reader["Reflex1"].ToString();
                                Obj.Parametros.Reflex2.Nombre = reader["Reflex2"].ToString();
                                Obj.Operador = reader["Operador"].ToString();
                                Obj.Norma = int.Parse(reader["Norma"].ToString());
                                Obj.Muestra = int.Parse(reader["Muestra"].ToString());

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
