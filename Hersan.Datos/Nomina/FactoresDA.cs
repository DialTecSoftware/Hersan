using Hersan.Entidades.Nomina;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace Hersan.Datos.Nomina
{
    public class FactoresDA : BaseDA
    {
        #region Constantes
        const string USP_NOM_FACTORES_OBTENER = "Nom_Factores_Obtener";
        const string USP_NOM_SUBSIDIOS_OBTENER = "NOM_Subsidios_Obtener";
        const string USP_NOM_ISR_SEMANAL_OBTENER = "NOM_ISR_Semanal_Obtener";
        const string USP_NOM_SEMANAS_GENERAR = "NOM_Semanas_Generar";
        const string USP_NOM_SEMANAS_OBTENER = "NOM_Semanas_Obtener";

        const string USP_NOM_CUOTAS_OBTENER = "NOM_Cuotas_Obtener";
        #endregion

        public List<FactoresBE> Nom_Factores_Obtener()
        {
            List<FactoresBE> oList = new List<FactoresBE>();
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(USP_NOM_FACTORES_OBTENER, conn)) {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                FactoresBE obj = new FactoresBE();

                                obj.Id = int.Parse(reader["FAC_Id"].ToString());
                                obj.De = decimal.Parse(reader["FAC_De"].ToString());
                                obj.Hasta = decimal.Parse(reader["FAC_Hasta"].ToString());
                                obj.Aguinaldo = int.Parse(reader["FAC_Aguinaldo"].ToString());
                                obj.Vacaciones = int.Parse(reader["FAC_Vacaciones"].ToString());
                                obj.Prima= decimal.Parse(reader["FAC_PrimaVac"].ToString());
                                obj.Factor = decimal.Parse(reader["FAC_Factor"].ToString());
                            
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
        public List<SubsidiosBE> NOM_Subsidios_Obtener()
        {
            List<SubsidiosBE> oList = new List<SubsidiosBE>();
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(USP_NOM_SUBSIDIOS_OBTENER, conn)) {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                SubsidiosBE obj = new SubsidiosBE();

                                obj.Id = int.Parse(reader["SUB_Id"].ToString());
                                obj.De = decimal.Parse(reader["SUB_De"].ToString());
                                obj.Hasta = decimal.Parse(reader["SUB_Hasta"].ToString());
                                obj.Subsidio = decimal.Parse(reader["SUB_Subsidio"].ToString());

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
        public List<ISRBE> NOM_ISR_Semanal_Obtener()
        {
            List<ISRBE> oList = new List<ISRBE>();
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(USP_NOM_ISR_SEMANAL_OBTENER, conn)) {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                ISRBE obj = new ISRBE();

                                obj.Id = int.Parse(reader["ISR_Id"].ToString());
                                obj.De = decimal.Parse(reader["ISR_De"].ToString());
                                obj.Hasta = decimal.Parse(reader["ISR_Hasta"].ToString());
                                obj.Cuota = decimal.Parse(reader["ISR_Cuota"].ToString());
                                obj.Porcentaje = decimal.Parse(reader["ISR_Porcentaje"].ToString());

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

        public List<SemanasBE> NOM_Semanas_Obtener(int Anio)
        {
            List<SemanasBE> oList = new List<SemanasBE>();
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(USP_NOM_SEMANAS_OBTENER, conn)) {
                        cmd.Parameters.AddWithValue("@Anio", Anio);

                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                SemanasBE obj = new SemanasBE();

                                obj.Id = int.Parse(reader["SEM_Id"].ToString());
                                obj.Semana = int.Parse(reader["SEM_Semana"].ToString());
                                obj.Inicia = DateTime.Parse(reader["SEM_Inicia"].ToString());
                                obj.Termina = DateTime.Parse(reader["SEM_Termina"].ToString());
                                obj.DatosUsuario.Estatus = bool.Parse(reader["SEM_Estatus"].ToString());

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
        public int NOM_Semanas_generar(int Anio)
        {
            int Result = 0;
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(USP_NOM_SEMANAS_GENERAR, conn)) {
                        cmd.Parameters.AddWithValue("@Anio", Anio);

                        cmd.CommandType = CommandType.StoredProcedure;
                        Result = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
                return Result;
            } catch (Exception ex) {
                throw ex;
            }
        }

        public List<CuotasBE> NOM_Cuotas_Obtener()
        {
            List<CuotasBE> oList = new List<CuotasBE>();
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(USP_NOM_CUOTAS_OBTENER, conn)) {

                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                CuotasBE obj = new CuotasBE();

                                obj.Id = int.Parse(reader["CUO_Id"].ToString());
                                obj.Nombre = reader["CUO_Nombre"].ToString();
                                obj.Detalle.Prestacion = reader["CDE_Prestacion"].ToString();
                                obj.Detalle.Patron = decimal.Parse(reader["CDE_Patron"].ToString());
                                obj.Detalle.Trabajador = decimal.Parse(reader["CDE_Patron"].ToString());
                                obj.Detalle.Total = decimal.Parse(reader["CDE_Trabajador"].ToString());

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
