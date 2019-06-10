using Hersan.Entidades.Ensamble;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Hersan.Datos.Ensamble
{
    public class PreciosDA : BaseDA
    {
        #region Constantes
        const string CONS_USP_ENS_PRECIOS_GUARDAR = "ENS_Precios_Guardar";
        const string CONS_USP_ENS_PRECIOS_OBTENER = "ENS_Precios_Obtener";
        #endregion

        public int ENS_Precios_Guardar(DataTable oData, string Moneda, int IdUsuario)
        {
            int Result = 0;
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONS_USP_ENS_PRECIOS_GUARDAR, conn)) {
                        cmd.Parameters.AddWithValue("@Precios", oData);
                        cmd.Parameters.AddWithValue("@Moneda", Moneda);
                        cmd.Parameters.AddWithValue("@IdUsuario", IdUsuario);

                        cmd.CommandType = CommandType.StoredProcedure;
                        Result = Convert.ToInt32(cmd.ExecuteScalar());

                    }
                }
                return Result;
            } catch (Exception ex) {
                throw ex;
            }
        }
        public List<PreciosBE> ENS_Precios_Obtener(string Moneda)
        {
            List<PreciosBE> oList = new List<PreciosBE>();
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONS_USP_ENS_PRECIOS_OBTENER, conn)) {
                        cmd.Parameters.AddWithValue("@Moneda", Moneda);

                        cmd.CommandType = CommandType.StoredProcedure;

                        /*SE OBTIENEN LOS PRECIOS */
                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                PreciosBE obj = new PreciosBE();

                                obj.Id = int.Parse(reader["PRE_Id"].ToString());
                                obj.Codigo = reader["CODIGO"].ToString();
                                obj.Producto.Id = int.Parse(reader["TPR_Id"].ToString());
                                obj.Producto.Familia.Entidad.Id = int.Parse(reader["ENT_Id"].ToString());
                                obj.Producto.Familia.Entidad.Nombre = reader["ENT_Nombre"].ToString();
                                obj.Producto.Familia.Id = int.Parse(reader["FAM_Id"].ToString());
                                obj.Producto.Familia.Nombre = reader["FAM_Nombre"].ToString();
                                obj.Producto.Nombre = reader["TPR_Nombre"].ToString();
                                obj.Precio = decimal.Parse(reader["PRE_Precio"].ToString());
                                obj.CantidadVol = int.Parse(reader["PRE_CantVolumen"].ToString());
                                obj.Volumen = decimal.Parse(reader["PRE_Volumen"].ToString());
                                obj.CantidadMay = int.Parse(reader["PRE_CantMayoreo"].ToString());
                                obj.Mayoreo = decimal.Parse(reader["PRE_Mayoreo"].ToString());
                                obj.AAA = decimal.Parse(reader["PRE_AAA"].ToString());

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
