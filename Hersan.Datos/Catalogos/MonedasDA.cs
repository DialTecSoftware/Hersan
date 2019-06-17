using Hersan.Entidades.Catalogos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Hersan.Datos.Catalogos
{
    public class MonedasDA : BaseDA
    {
        #region Constantes
        const string CONST_ABC_MONEDAS_OBTENER = "ABC_Monedas_Obtener";
        const string CONST_ABC_MONEDAS_GUARDAR = "ABC_Monedas_Guardar";
        const string CONST_ABC_MONEDAS_ACTUALIZAR = "ABC_Monedas_Actualizar";
        const string CONST_ABC_MONEDAS_COMBO = "ABC_Monedas_Combo";
        #endregion

        public List<MonedasBE> ABC_Monedas_Obtener()
        {
            List<MonedasBE> oList = new List<MonedasBE>();
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_ABC_MONEDAS_OBTENER, conn)) {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                MonedasBE obj = new MonedasBE();

                                obj.Id = int.Parse(reader["MON_Id"].ToString());
                                obj.Moneda = reader["MON_Moneda"].ToString();
                                obj.Abrev = reader["MON_Abrev"].ToString();
                                obj.TipoCambio = decimal.Parse(reader["MON_TipoCambio"].ToString());
                                obj.DatosUsuario.FechaCreacion = DateTime.Parse(reader["MON_FechaCreacion"].ToString());
                                obj.DatosUsuario.Estatus = bool.Parse(reader["MON_Estatus"].ToString());

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
        public int ABC_Monedas_Guardar(MonedasBE obj)
        {
            int Result = 0;
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_ABC_MONEDAS_GUARDAR, conn)) {
                        cmd.Parameters.AddWithValue("@Moneda", obj.Moneda);
                        cmd.Parameters.AddWithValue("@Abrev", obj.Abrev);
                        cmd.Parameters.AddWithValue("@TipoCambio", obj.TipoCambio);
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
        public int ABC_Monedas_Actualizar(MonedasBE obj)
        {
            int Result = 0;
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_ABC_MONEDAS_ACTUALIZAR, conn)) {
                        cmd.Parameters.AddWithValue("@Id", obj.Id);
                        cmd.Parameters.AddWithValue("@Moneda", obj.Moneda);
                        cmd.Parameters.AddWithValue("@Abrev", obj.Abrev);
                        cmd.Parameters.AddWithValue("@TipoCambio", obj.TipoCambio);
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
        public List<MonedasBE> ABC_Monedas_Combo()
        {
            List<MonedasBE> oList = new List<MonedasBE>();
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_ABC_MONEDAS_COMBO, conn)) {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                MonedasBE obj = new MonedasBE();

                                obj.Id = int.Parse(reader["MON_Id"].ToString());
                                obj.Moneda = reader["MON_Moneda"].ToString();
                                obj.Abrev = reader["MON_Abrev"].ToString();
                                obj.TipoCambio = decimal.Parse(reader["MON_TipoCambio"].ToString());

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
