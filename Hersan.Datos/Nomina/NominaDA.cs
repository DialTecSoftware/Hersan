using Hersan.Entidades.Nomina;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Hersan.Datos.Nomina
{
    public class NominaDA : BaseDA  
    {
        #region Constantes
        const string CONS_NOM_CALCULONOMINA = "NOM_CalculoNomina";

        const string CONS_NOM_PRESTAMOS_GUARDAR = "NOM_Prestamos_Guardar";
        #endregion

        public List<NominaBE> NOM_CalculoNomina(int Semana)
        {
            List<NominaBE> oList = new List<NominaBE>();
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONS_NOM_CALCULONOMINA, conn)) {
                        cmd.Parameters.AddWithValue("@Semana",Semana);

                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                NominaBE obj = new NominaBE();

                                /* ENCABEZADO */
                                //obj.Id = int.Parse(reader["Id"].ToString());
                                obj.Semana.Semana = int.Parse(reader["Semana"].ToString());
                                obj.Empleado.Id = int.Parse(reader["IdEmpleado"].ToString());                                
                                obj.Empleado.Numero = int.Parse(reader["Empleado"].ToString());
                                obj.Empleado.Expedientes.Puesto.Departamentos.Nombre = reader["Depto"].ToString();
                                obj.Empleado.Expedientes.DatosPersonales.Nombres = reader["Nombre"].ToString();
                                obj.Total = decimal.Parse(reader["Neto"].ToString());

                                /* PERCEPCIONES */
                                obj.Empleado.SueldoDiario = decimal.Parse(reader["SdoSemana"].ToString());
                                obj.Percepciones.Asistencia = decimal.Parse(reader["Asistencia"].ToString());
                                obj.Percepciones.Puntualidad = decimal.Parse(reader["Puntualidad"].ToString());
                                obj.Percepciones.Vales = decimal.Parse(reader["Vales"].ToString());
                                obj.Percepciones.HBono = decimal.Parse(reader["HBono"].ToString());
                                obj.Percepciones.HExtra = decimal.Parse(reader["HExtra"].ToString());
                                obj.Percepciones.Total = decimal.Parse(reader["TotalPercepciones"].ToString());

                                /* DEDUCCIONES */
                                obj.Deducciones.Imss = decimal.Parse(reader["IMSS"].ToString());
                                obj.Deducciones.Fonacot = decimal.Parse(reader["Fonacot"].ToString());
                                obj.Deducciones.Infonavit = decimal.Parse(reader["Infonavit"].ToString());
                                obj.Deducciones.FAhorro = decimal.Parse(reader["FAhorro"].ToString());
                                obj.Deducciones.Aportacion = decimal.Parse(reader["Aportacion"].ToString());
                                obj.Deducciones.Prestamo.ImportePago = decimal.Parse(reader["Prestamo"].ToString());
                                obj.Deducciones.Faltas = decimal.Parse(reader["Faltas"].ToString());
                                obj.Deducciones.Pension = decimal.Parse(reader["Pension"].ToString());
                                obj.Deducciones.ISR = decimal.Parse(reader["ISR"].ToString());
                                obj.Deducciones.Total = decimal.Parse(reader["TotalDeducciones"].ToString());

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

        public int NOM_Prestamos_Guardar(PrestamosBE Obj, DataTable Detalle)
        {
            int Result = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL")))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONS_NOM_PRESTAMOS_GUARDAR, conn))
                    {
                        cmd.Parameters.AddWithValue("@IdEmpleado", Obj.Empleado.Id);
                        cmd.Parameters.AddWithValue("@Importe", Obj.ImporteTotal);
                        cmd.Parameters.AddWithValue("@Pagos", Obj.NoPagos);
                        cmd.Parameters.AddWithValue("@ImportePago", Obj.ImportePago);
                        cmd.Parameters.AddWithValue("@Semana", Obj.SemanaAplica);
                        cmd.Parameters.AddWithValue("@Tasa", Obj.Tasa);
                        cmd.Parameters.AddWithValue("@Detalle", Detalle);
                        cmd.Parameters.AddWithValue("@IdUsuario", Obj.DatosUsuario.IdUsuarioModif);

                        cmd.CommandType = CommandType.StoredProcedure;
                        Result = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
                return Result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
