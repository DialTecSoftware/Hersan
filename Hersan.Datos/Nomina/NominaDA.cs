using Hersan.Entidades.Nomina;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace Hersan.Datos.Nomina
{
    public class NominaDA : BaseDA  
    {
        #region Constantes
        private string RutaDoctos = @ConfigurationManager.AppSettings["RutaDoctos"];

        const string CONS_NOM_CALCULONOMINA = "NOM_CalculoNomina";
        const string CONS_NOM_CALCULONOMINA_GUARDAR = "NOM_CalculoNomina_Guardar";
        const string CONS_NOM_NOMINA_OBTENER = "NOM_Nomina_Obtener";        
        const string CONS_NOM_INCIDENCIAS_GUARDAR = "NOM_Incidencias_Guardar";
        const string CONS_NOM_INCIDENCIAS_OBTENER = "NOM_Incidencias_Obtener";
        const string CONS_NOM_FONACOT_GUARDAR = "NOM_Fonacot_Guardar";
        const string CONS_NOM_PRESTAMOS_GUARDAR = "NOM_Prestamos_Guardar";
        const string CONS_NOM_PRESTAMOS_CONSULTA = "NOM_Prestamos_Consulta";
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
                                //obj.Percepciones.HBono = decimal.Parse(reader["HBono"].ToString());
                                obj.Percepciones.HExtra = decimal.Parse(reader["HExtra"].ToString());
                                obj.Percepciones.Bono = decimal.Parse(reader["Bono"].ToString());
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
        public int NOM_CalculoNomina_Guardar(int Semana, string Excluir, int IdUsuario)
        {
            int Result = 0;
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONS_NOM_CALCULONOMINA_GUARDAR, conn)) {
                        cmd.Parameters.AddWithValue("@Semana", Semana);
                        cmd.Parameters.AddWithValue("@Excluir", Excluir);
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
        public List<NominaBE> NOM_Nomina_Obtener(int Semana)
        {
            List<NominaBE> oList = new List<NominaBE>();
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONS_NOM_NOMINA_OBTENER, conn)) {
                        cmd.Parameters.AddWithValue("@Semana", Semana);

                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                NominaBE obj = new NominaBE();

                                /* ENCABEZADO */
                                obj.Id = int.Parse(reader["Id"].ToString());
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
                                //obj.Percepciones.HBono = decimal.Parse(reader["HBono"].ToString());
                                obj.Percepciones.HExtra = decimal.Parse(reader["HExtra"].ToString());
                                obj.Percepciones.Bono = decimal.Parse(reader["Bono"].ToString());
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
        public int NOM_Incidencias_Guardar(List<IncidenciasBE> Lista, List<FonacotBE> Fonacot)
        {
            int Result = 0;
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    SqlTransaction transaction;
                    transaction = conn.BeginTransaction("Tran");

                    try {
                        Lista.ForEach(item => {
                            using (SqlCommand cmd = new SqlCommand(CONS_NOM_INCIDENCIAS_GUARDAR, conn)) {
                                cmd.Connection = conn;
                                cmd.Transaction = transaction;

                                cmd.Parameters.AddWithValue("@Semana", item.Semana.Semana);
                                cmd.Parameters.AddWithValue("@IdEmpleado", item.Empleado.Id);
                                cmd.Parameters.AddWithValue("@Faltas", item.Faltas);
                                cmd.Parameters.AddWithValue("@Retardos", item.Retardos);
                                cmd.Parameters.AddWithValue("@Bono", item.Bono);
                                cmd.Parameters.AddWithValue("@Extras", item.Extra);
                                cmd.Parameters.AddWithValue("@Fonacot", item.Fonacot);
                                cmd.Parameters.AddWithValue("@IdUsuario", item.DatosUsuario.IdUsuarioCreo);

                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.ExecuteNonQuery();
                            }
                        });
                        Fonacot.ForEach(aux => {
                            using (SqlCommand cmd = new SqlCommand(CONS_NOM_FONACOT_GUARDAR, conn)) {
                                cmd.Connection = conn;
                                cmd.Transaction = transaction;

                                cmd.Parameters.AddWithValue("@Anio", aux.ANIO_EMISION);
                                cmd.Parameters.AddWithValue("@Mes", aux.MES_EMISION);
                                cmd.Parameters.AddWithValue("@NoFonacot", aux.NO_FONACOT);
                                cmd.Parameters.AddWithValue("@NSS", aux.NO_SS);
                                cmd.Parameters.AddWithValue("@RFC", aux.RFC);
                                cmd.Parameters.AddWithValue("@Nombre", aux.Nombre);
                                cmd.Parameters.AddWithValue("@NoEmpleado", aux.CLAVE_EMPLEADO);
                                cmd.Parameters.AddWithValue("@RetencionMensual", aux.RETENCION_MENSUAL);
                                cmd.Parameters.AddWithValue("@Descuento", aux.Descuento);
                                cmd.Parameters.AddWithValue("@RetencionReal", aux.RETENCION_REAL);
                                cmd.Parameters.AddWithValue("@IdUsuario", aux.IdUsuario);

                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.ExecuteNonQuery();
                            }

                        });

                        transaction.Commit();
                        Result = 1;
                    } catch (Exception ex) {
                        transaction.Rollback();
                        throw ex;
                    }                
                }
                return Result;
            } catch (Exception ex) {
                throw ex;
            }
        }
        public List<IncidenciasBE> NOM_Incidencias_Obtener(int Semana)
        {
            List<IncidenciasBE> oList = new List<IncidenciasBE>();
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(CONS_NOM_INCIDENCIAS_OBTENER, conn)) {
                        cmd.Parameters.AddWithValue("@Semana", Semana);

                        cmd.CommandType = CommandType.StoredProcedure;

                        using(SqlDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                IncidenciasBE Obj = new IncidenciasBE();

                                Obj.Empleado.Id = int.Parse(reader["EMP_Id"].ToString());
                                Obj.Empleado.Numero = int.Parse(reader["EMP_Numero"].ToString());
                                Obj.Empleado.Expedientes.Puesto.Departamentos.Nombre = reader["DEP_Nombre"].ToString();
                                Obj.Empleado.Expedientes.DatosPersonales.Nombres = reader["Nombre"].ToString();
                                Obj.Semana.Semana = int.Parse(reader["Semana"].ToString());
                                Obj.Faltas = int.Parse(reader["Faltas"].ToString());
                                Obj.Retardos = int.Parse(reader["Retardos"].ToString());
                                Obj.Bono = decimal.Parse(reader["Bono"].ToString());
                                Obj.Extra = int.Parse(reader["Extras"].ToString());
                                Obj.Fonacot = bool.Parse(reader["Fonacot"].ToString());

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
        public bool NOM_ImportarFonacot(string Archivo)
        {
            bool Result = false;
            string Ruta = RutaDoctos + Archivo;
            // make sure your sheet name is correct, here sheet name is sheet1, so you can change your sheet name if have            different
            string Tabla = "NOM_Fonacot";
            string Query = "select ANIO_EMISION, MES_EMISION, NO_FONACOT, RFC, NO_SS, NOMBRE, CLAVE_EMPLEADO, RETENCION_MENSUAL, RETENCION_REAL From [cedulaCSV]";

            try {
                //create our connection strings
                string Excelconn = @"provider=microsoft.jet.oledb.4.0;data source=" + Ruta + ";extended properties=" + "\"excel 8.0;hdr=yes;\"";
                string SQLConn = RecuperarCadenaDeConexion("coneccionSQL");

                //series of commands to bulk copy data from the excel file into our sql table
                OleDbConnection oledbconn = new OleDbConnection(Excelconn);
                OleDbCommand oledbcmd = new OleDbCommand(Query, oledbconn);
                oledbconn.Open();
            
                OleDbDataReader dr = oledbcmd.ExecuteReader();
                SqlBulkCopy bulkcopy = new SqlBulkCopy(SQLConn);
                bulkcopy.DestinationTableName = Tabla;
                while (dr.Read()) {
                    bulkcopy.WriteToServer(dr);
                }

                oledbconn.Close();
                Result = true;
            } catch (Exception ex) {
                throw ex;
            }
            return Result;
        }

        public int NOM_Prestamos_Guardar(PrestamosBE Obj, DataTable Detalle)
        {
            int Result = 0;
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONS_NOM_PRESTAMOS_GUARDAR, conn)) {
                        cmd.Parameters.AddWithValue("@IdEmpleado", Obj.Empleado.Id);
                        cmd.Parameters.AddWithValue("@Importe", Obj.ImporteTotal);
                        cmd.Parameters.AddWithValue("@Pagos", Obj.NoPagos);
                        cmd.Parameters.AddWithValue("@ImportePago", Obj.ImportePago);
                        cmd.Parameters.AddWithValue("@Semana", Obj.SemanaAplica);
                        cmd.Parameters.AddWithValue("@Tasa", Obj.Tasa);
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
        public List<PrestamosBE> NOM_Prestamos_Consulta(PrestamosBE item)
        {
            List<PrestamosBE> oList = new List<PrestamosBE>();
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONS_NOM_PRESTAMOS_CONSULTA, conn)) {
                        cmd.Parameters.AddWithValue("@IdEmpleado", item.Empleado.Id);
                        cmd.Parameters.AddWithValue("@Desde", item.SemanaAplica);
                        cmd.Parameters.AddWithValue("@Hasta", item.NoPagos);
                        cmd.Parameters.AddWithValue("@Folio", item.Id);
                        cmd.Parameters.AddWithValue("@Estatus", item.Empleado.NumeroCuenta);

                        cmd.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                PrestamosBE obj = new PrestamosBE();

                                obj.Id = int.Parse(reader["PRE_Id"].ToString());
                                obj.Empleado.Id = int.Parse(reader["EMP_Id"].ToString());
                                obj.Empleado.Numero = int.Parse(reader["EMP_Numero"].ToString());
                                obj.Empleado.Expedientes.DatosPersonales.Nombres = reader["Nombre"].ToString();
                                obj.ImporteTotal = decimal.Parse(reader["PRE_ImporteTotal"].ToString());
                                obj.NoPagos = int.Parse(reader["PRE_NumPagos"].ToString());
                                obj.ImportePago = decimal.Parse(reader["PRE_ImportePago"].ToString());
                                obj.Pagado = decimal.Parse(reader["Pagado"].ToString());
                                obj.Saldo = decimal.Parse(reader["Saldo"].ToString());
                                obj.SemanaAplica = int.Parse(reader["PRE_SemanaAplica"].ToString());
                                obj.FechaAplica = DateTime.Parse(reader["PRE_FechaPago"].ToString());
                                obj.Tasa = decimal.Parse(reader["PRE_Tasa"].ToString());
                                obj.Estatus = reader["PRE_Estatus"].ToString();
                                obj.DatosUsuario.FechaCreacion = DateTime.Parse(reader["PRE_FechaCreacion"].ToString());

                                oList.Add(obj);
                            }

                            /* Detalle de Préstamos */
                            if (reader.NextResult()) {                                
                                while (reader.Read()) {
                                    PrestamosDetalleBE Detalle = new PrestamosDetalleBE();
                                    Detalle.Id = int.Parse(reader["PRE_Id"].ToString());
                                    Detalle.NoPago = int.Parse(reader["PRD_NoPago"].ToString());
                                    Detalle.Semana = int.Parse(reader["PRD_Semana"].ToString());
                                    Detalle.Fecha = DateTime.Parse(reader["PRD_Fecha"].ToString());
                                    Detalle.Capital = decimal.Parse(reader["PRD_Capital"].ToString());
                                    Detalle.Interes = decimal.Parse(reader["PRD_Interes"].ToString());
                                    Detalle.Abono = decimal.Parse(reader["PRD_Abono"].ToString());
                                    Detalle.Saldo = decimal.Parse(reader["PRD_Saldo"].ToString());
                                    Detalle.Estatus = reader["PRD_Estatus"].ToString();

                                    oList.ForEach(Item => {
                                        if (Item.Id == Detalle.Id)
                                            Item.Detalle.Add(Detalle);
                                    });
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
