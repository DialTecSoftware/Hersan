using Hersan.Entidades.Catalogos;
using Hersan.Entidades.Ensamble;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Hersan.Datos.Ensamble
{
    public class ProductosDA : BaseDA
    {
        #region Constantes
        const string CONS_ENS_PRODUCTOSFICHA_GUARDAR = "ENS_ProductosFicha_Guardar";
        const string CONS_ENS_PRODUCTOSFICHA_ACTUALIZAR = "ENS_ProductosFicha_Actualizar";
        const string CONS_ENS_PRODUCTOSFICHA_OBTENER = "ENS_ProductosFicha_Obtener";
        const string CONS_ENS_PRODUCTOSCOTIZACION_COMBO = "ENS_ProductosCotizacion_Combo";
        const string CONS_ENS_CARCASASCOTIZACION_COMBO = "ENS_CarcasasCotizacion_Combo";
        const string CONS_ENS_REFLEJANTECOTIZACION_COMBO = "ENS_ReflejanteCotizacion_Combo";
        const string CONS_ENS_CODIGOPRODUCTO_OBTENER = "ENS_CodigoProducto_Obtener";
        #endregion

        public int ENS_ProductosFicha_Guardar(DataSet Tablas, string Colores, string Reflejantes, string Accesorios, int IdUsuario)
        {
            int Result = 0;
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONS_ENS_PRODUCTOSFICHA_GUARDAR, conn)) {
                        cmd.Parameters.AddWithValue("@Ficha", Tablas.Tables["Ficha"]);
                        cmd.Parameters.AddWithValue("@Dimension", Tablas.Tables["Dimensiones"]);
                        cmd.Parameters.AddWithValue("@Color", Colores);
                        cmd.Parameters.AddWithValue("@Refejantes", Reflejantes);
                        cmd.Parameters.AddWithValue("@Accesorios", Accesorios);
                        cmd.Parameters.AddWithValue("@IdUsuario",IdUsuario);

                        cmd.CommandType = CommandType.StoredProcedure;
                        Result = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
                return Result;
            } catch (Exception ex) {
                throw ex;
            }
        }
        public int ENS_ProductosFicha_Actualizar(DataSet Tablas, string Colores, string Reflejantes, string Accesorios, int IdUsuario, bool Estatus)
        {
            int Result = 0;
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONS_ENS_PRODUCTOSFICHA_ACTUALIZAR, conn)) {
                        cmd.Parameters.AddWithValue("@Ficha", Tablas.Tables["Ficha"]);
                        cmd.Parameters.AddWithValue("@Dimension", Tablas.Tables["Dimensiones"]);
                        cmd.Parameters.AddWithValue("@Color", Colores);
                        cmd.Parameters.AddWithValue("@Refejantes", Reflejantes);
                        cmd.Parameters.AddWithValue("@Accesorios", Accesorios);
                        cmd.Parameters.AddWithValue("@IdUsuario", IdUsuario);
                        cmd.Parameters.AddWithValue("@Estatus", Estatus);

                        cmd.CommandType = CommandType.StoredProcedure;
                        Result = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
                return Result;
            } catch (Exception ex) {
                throw ex;
            }
        }
        public List<ProductoEnsambleBE> ENS_ProductosFicha_Obtener(ProductoEnsambleBE producto)
        {
            List<ProductoEnsambleBE> oList = new List<ProductoEnsambleBE>();
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONS_ENS_PRODUCTOSFICHA_OBTENER, conn)) {
                        cmd.Parameters.AddWithValue("@Id", producto.Id);
                        cmd.Parameters.AddWithValue("@IdEntidad", producto.Entidad.Id);
                        cmd.Parameters.AddWithValue("@IdFamilia", producto.Familia.Id);
                        cmd.Parameters.AddWithValue("@IdProducto", producto.Producto.Id);

                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                ProductoEnsambleBE obj = new ProductoEnsambleBE();
                                #region ENCABEZADO FICHA TECNICA
                                obj.Id = int.Parse(reader["PFI_Id"].ToString());
                                obj.Entidad.Id = int.Parse(reader["ENT_Id"].ToString());
                                obj.Familia.Id = int.Parse(reader["FAM_Id"].ToString());
                                obj.Producto.Id = int.Parse(reader["TPR_ID"].ToString());
                                obj.Reflejantes = int.Parse(reader["PFI_Reflejantes"].ToString());
                                obj.CantAccesorios = int.Parse(reader["PFI_Accesorios"].ToString());
                                obj.Dimensiones.Alto = decimal.Parse(reader["PFD_Alto"].ToString());
                                obj.Dimensiones.Largo = decimal.Parse(reader["PFD_Largo"].ToString());
                                obj.Dimensiones.Ancho  = decimal.Parse(reader["PFD_Ancho"].ToString());
                                obj.Dimensiones.Cirunferencia = decimal.Parse(reader["PFD_Circunferencia"].ToString());
                                obj.Dimensiones.Diametro = decimal.Parse(reader["PFD_Diametro"].ToString());
                                obj.Dimensiones.Peso = decimal.Parse(reader["PFD_Peso"].ToString());
                                obj.Dimensiones.Empaque = int.Parse(reader["PFD_Empaque"].ToString());
                                obj.Dimensiones.RutaImagen = reader["PFD_RutaImagen"].ToString();
                                obj.DatosUsuario.Estatus = bool.Parse(reader["PFI_Estatus"].ToString());
                                #endregion

                                oList.Add(obj);
                            }

                            if (oList.Count > 0) {
                                /* CARCASAS, REFLEJANTES Y ACCESORIOS */
                                if (reader.NextResult()) {
                                    while (reader.Read()) {
                                        ProductosCombinacion oDetalle = new ProductosCombinacion();
                                            oDetalle.Tipo = reader["TIPO"].ToString();
                                            oDetalle.Id = int.Parse(reader["Id"].ToString());

                                            oList[0].Detalle.Add(oDetalle);
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
        public List<ProductoEnsambleBE> ENS_ProductosCotizacion_Combo(bool Nacional, string Moneda)
        {
            List<ProductoEnsambleBE> oList = new List<ProductoEnsambleBE>();
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONS_ENS_PRODUCTOSCOTIZACION_COMBO, conn)) {
                        cmd.Parameters.AddWithValue("@Nacional", Nacional);
                        cmd.Parameters.AddWithValue("@Moneda", Moneda);

                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                ProductoEnsambleBE obj = new ProductoEnsambleBE();

                                obj.Id = int.Parse(reader["PFI_Id"].ToString());
                                obj.Producto.Id = int.Parse(reader["TPR_ID"].ToString());
                                obj.Entidad.Nombre = reader["ENT_Nombre"].ToString();
                                obj.Familia.Nombre = reader["FAM_Nombre"].ToString();
                                obj.Producto.Clave = reader["Codigo"].ToString();
                                obj.Producto.Nombre = reader["TPR_Nombre"].ToString();
                                obj.Reflejantes = int.Parse(reader["PFI_Reflejantes"].ToString());
                                obj.Precio.Precio = decimal.Parse(reader["Precio"].ToString());
                                obj.Precio.CantidadVol = int.Parse(reader["PRE_CantVolumen"].ToString());
                                obj.Precio.Volumen = decimal.Parse(reader["PRE_Volumen"].ToString());
                                obj.Precio.CantidadMay = int.Parse(reader["PRE_CantMayoreo"].ToString());
                                obj.Precio.Mayoreo = decimal.Parse(reader["PRE_Mayoreo"].ToString());
                                obj.Precio.AAA = decimal.Parse(reader["PRE_AAA"].ToString());

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
        public List<ColoresBE> ENS_CarcasasCotizacion_Combo(int IdFicha)
        {
            List<ColoresBE> oList = new List<ColoresBE>();
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONS_ENS_CARCASASCOTIZACION_COMBO, conn)) {
                        cmd.Parameters.AddWithValue("@IdFicha", IdFicha);

                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                ColoresBE obj = new ColoresBE();

                                obj.Id = int.Parse(reader["COL_Id"].ToString());
                                obj.Clave = reader["COL_Clave"].ToString();
                                obj.Nombre = reader["COL_Nombre"].ToString();

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
        public List<ReflejantesBE> ENS_ReflejanteCotizacion_Combo(int IdFicha)
        {
            List<ReflejantesBE> oList = new List<ReflejantesBE>();
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONS_ENS_REFLEJANTECOTIZACION_COMBO, conn)) {
                        cmd.Parameters.AddWithValue("@IdFicha", IdFicha);

                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                ReflejantesBE obj = new ReflejantesBE();

                                obj.Id = int.Parse(reader["COM_Id"].ToString());
                                obj.Clave = reader["COM_Clave"].ToString();
                                obj.Nombre = reader["Reflejante"].ToString();

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

        public string ENS_CodigoProducto_Obtener(int IdProducto, int IdCarcasa, string Reflejantes)
        {
            string Result = string.Empty;
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONS_ENS_CODIGOPRODUCTO_OBTENER, conn)) {
                        cmd.Parameters.AddWithValue("@IdProducto", IdProducto);
                        cmd.Parameters.AddWithValue("@IdCarcasa", IdCarcasa);
                        cmd.Parameters.AddWithValue("@Reflex", Reflejantes);

                        cmd.CommandType = CommandType.StoredProcedure;
                        Result = cmd.ExecuteScalar().ToString();
                    }
                }
                return Result;
            } catch (Exception ex) {
                throw ex;
            }
        }
    }
}
