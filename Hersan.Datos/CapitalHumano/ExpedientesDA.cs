using Hersan.Entidades.CapitalHumano;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Hersan.Datos.CapitalHumano
{
    public class ExpedientesDA : BaseDA
    {

        #region Constantes
        const string CONS_USP_CHU_EXPEDIENTE_GUARDAR = "CHU_Expediente_Guardar";
        const string CONS_USP_CHU_EXPEDIENTE_OBTENER = "CHU_Expediente_Obtener";
        const string CONS_USP_CHU_EXPEDIENTE_ELIMINAR = "CHU_Expediente_Eliminar";
        const string CONS_USP_CHU_EXPEDIENTE_ACTUALIZAR = "CHU_Expediente_Actualizar";
        const string CONS_USP_CHU_EXPEDIENTE_DATOSPERSONALES_OBTENER = "CHU_Expediente_DatosPersonales_Obtener";
        const string CONS_USP_CHU_EXPEDIENTE_CONSULTAR = "CHU_Expediente_Consultar";
        const string CONS_USP_CHU_EXPEDIENTE_DOCUMENTOS_OBTENER = "CHU_Expediente_Documentos_Obtener";
        const string CONS_USP_CHU_EXPEDIENTE_FAMILIA_OBTENER = "CHU_Expediente_Familia_Obtener";
        const string CONS_USP_CHU_EXPEDIENTE_ESTUDIOS_OBTENER = "CHU_Expediente_Estudios_Obtener";
        const string CONS_USP_CHU_EXPEDIENTE_EMPLEOS_OBTENER = "CHU_Expediente_Empleos_Obtener";
        const string CONS_USP_CHU_EXPEDIENTE_SALUD_OBTENER = "CHU_Expediente_Salud_Obtener";
        const string CONS_USP_CHU_EXPEDIENTE_CONOCIMIENTOS_OBTENER = "CHU_Expediente_Conocimientos_Obtener";
        const string CONS_USP_CHU_EXPEDIENTE_REFERENCIA_OBTENER = "CHU_Expediente_Referencia_Obtener";
        const string CONS_USP_CHU_EXPEDIENTE_GENERALES_OBTENER = "CHU_Expediente_DatosGenerales_Obtener";
        const string CONS_USP_CHU_EXPEDIENTE_ECONOMICOS_OBTENER = "CHU_Expediente_DatosEconomicos_Obtener";
        #endregion

        public int CHU_Expedientes_Guardar(DataSet Tablas, int IdUsuario)
        {
            int Result = 0;
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONS_USP_CHU_EXPEDIENTE_GUARDAR, conn)) {
                        cmd.Parameters.AddWithValue("@Expediente", Tablas.Tables["Expediente"]);
                        cmd.Parameters.AddWithValue("@Datos", Tablas.Tables["Personales"]);
                        cmd.Parameters.AddWithValue("@Doctos", Tablas.Tables["Documentos"]);
                        cmd.Parameters.AddWithValue("@Familia", Tablas.Tables["Familia"]);
                        cmd.Parameters.AddWithValue("@Estudios", Tablas.Tables["Estudios"]);
                        cmd.Parameters.AddWithValue("@Empleos", Tablas.Tables["Empleos"]);
                        cmd.Parameters.AddWithValue("@Salud", Tablas.Tables["Salud"]);
                        cmd.Parameters.AddWithValue("@Conocimiento", Tablas.Tables["Conocimiento"]);
                        cmd.Parameters.AddWithValue("@Referencias", Tablas.Tables["Referencias"]);
                        cmd.Parameters.AddWithValue("@Generales", Tablas.Tables["Genarales"]);
                        cmd.Parameters.AddWithValue("@Economicos", Tablas.Tables["Economicos"]);
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
        public List<ExpedientesBE> CHU_Expedientes_Consultar(ExpedientesBE Expediente)
        {
            List<ExpedientesBE> oList = new List<ExpedientesBE>();
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONS_USP_CHU_EXPEDIENTE_OBTENER, conn)) {
                        cmd.Parameters.AddWithValue("@Id", Expediente.Id);
                        cmd.Parameters.AddWithValue("@Entidad", Expediente.Puesto.Departamentos.Entidades.Id);
                        cmd.Parameters.AddWithValue("@DEP_Id", Expediente.Puesto.Departamentos.Id);
                        cmd.Parameters.AddWithValue("@PUE_Id", Expediente.Puesto.Id);
                        cmd.Parameters.AddWithValue("@Tipo", Expediente.Tipo);
                        cmd.Parameters.AddWithValue("@APaterno", Expediente.DatosPersonales.APaterno);
                        cmd.Parameters.AddWithValue("@AMaterno", Expediente.DatosPersonales.AMaterno);
                        cmd.Parameters.AddWithValue("@Nombres", Expediente.DatosPersonales.Nombres);

                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                ExpedientesBE obj = new ExpedientesBE();

                                obj.Id = int.Parse(reader["EXP_Id"].ToString());
                                obj.Puesto.Departamentos.Entidades.Nombre = reader["ENT_Nombre"].ToString();
                                obj.Puesto.Departamentos.Id = int.Parse(reader["DEP_Id"].ToString());
                                obj.Puesto.Departamentos.Nombre = reader["DEP_Nombre"].ToString();
                                obj.Puesto.Id = int.Parse(reader["PUE_Id"].ToString());
                                obj.Puesto.Nombre = reader["PUE_Nombre"].ToString();
                                obj.Tipo = reader["EXP_TipoExpediente"].ToString();
                                obj.DatosPersonales.APaterno = reader["EDP_APaterno"].ToString();
                                obj.DatosPersonales.AMaterno= reader["EDP_AMaterno"].ToString();
                                obj.DatosPersonales.Nombres = reader["EDP_Nombres"].ToString();
                             

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
        public int CHU_Expedientes_Actualizar(int Id, DataSet Tablas, int IdUsuario)
        {
            int Result = 0;
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONS_USP_CHU_EXPEDIENTE_ACTUALIZAR, conn)) {
                        cmd.Parameters.AddWithValue("@Id", @Id);
                        cmd.Parameters.AddWithValue("@Expediente", Tablas.Tables["Expediente"]);
                        cmd.Parameters.AddWithValue("@Datos", Tablas.Tables["Personales"]);
                        cmd.Parameters.AddWithValue("@Doctos", Tablas.Tables["Documentos"]);
                        cmd.Parameters.AddWithValue("@Familia", Tablas.Tables["Familia"]);
                        cmd.Parameters.AddWithValue("@Estudios", Tablas.Tables["Estudios"]);
                        cmd.Parameters.AddWithValue("@Empleos", Tablas.Tables["Empleos"]);
                        cmd.Parameters.AddWithValue("@Salud", Tablas.Tables["Salud"]);
                        cmd.Parameters.AddWithValue("@Conocimiento", Tablas.Tables["Conocimiento"]);
                        cmd.Parameters.AddWithValue("@Referencias", Tablas.Tables["Referencias"]);
                        cmd.Parameters.AddWithValue("@Generales", Tablas.Tables["Genarales"]);
                        cmd.Parameters.AddWithValue("@Economicos", Tablas.Tables["Economicos"]);
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
        public int CHU_Expedientes_Eliminar(int Id, int IdUsuario)
        {
            int Result = 0;
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONS_USP_CHU_EXPEDIENTE_ELIMINAR, conn)) {
                        cmd.Parameters.AddWithValue("@Id", Id);
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
        public List<ExpedientesBE> CHU_Expedientes_Obtener(int IdExpediente)
        {
            List<ExpedientesBE> oList = new List<ExpedientesBE>();
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONS_USP_CHU_EXPEDIENTE_CONSULTAR, conn)) {
                        cmd.Parameters.AddWithValue("@Id", IdExpediente);

                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                ExpedientesBE obj = new ExpedientesBE();

                                obj.Id = int.Parse(reader["EXP_Id"].ToString());
                                obj.Puesto.Departamentos.Entidades.Id = int.Parse(reader["ENT_Id"].ToString());
                                obj.Puesto.Departamentos.Entidades.Nombre = reader["ENT_Nombre"].ToString();
                                obj.Puesto.Departamentos.Id = int.Parse(reader["DEP_Id"].ToString());
                                obj.Puesto.Departamentos.Nombre = reader["DEP_Nombre"].ToString();
                                obj.Puesto.Id = int.Parse(reader["PUE_Id"].ToString());
                                obj.Puesto.Nombre = reader["PUE_Nombre"].ToString();
                                obj.Tipo = reader["EXP_TipoExpediente"].ToString();
                                obj.Comentarios = reader["EXP_Comentarios"].ToString();
                                obj.RutaImagen = reader["EXP_RutaFoto"].ToString();


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
        public List<ExpedientesDatosPersonales> CHU_ExpedientesDatosPersonales_Consultar(ExpedientesDatosPersonales Expediente)
        {
            List<ExpedientesDatosPersonales> oList = new List<ExpedientesDatosPersonales>();
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONS_USP_CHU_EXPEDIENTE_DATOSPERSONALES_OBTENER, conn)) {
                        cmd.Parameters.AddWithValue("@Id", Expediente.IdExpediente);
                        cmd.Parameters.AddWithValue("@APaterno", Expediente.APaterno);
                        cmd.Parameters.AddWithValue("@AMaterno", Expediente.AMaterno);
                        cmd.Parameters.AddWithValue("@Nombre", Expediente.Nombres);

                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                ExpedientesDatosPersonales obj = new ExpedientesDatosPersonales();

                                obj.IdExpediente = int.Parse(reader["EXP_Id"].ToString());
                                obj.APaterno = reader["EDP_APaterno"].ToString();
                                obj.AMaterno = reader["EDP_AMaterno"].ToString();
                                obj.Nombres = reader["EDP_Nombres"].ToString();
                                obj.Edad = int.Parse(reader["EDP_Edad"].ToString());
                                obj.Direccion = reader["EDP_Direccion"].ToString();
                                obj.Estado.Pais.Id = int.Parse(reader["PAI_Id"].ToString());
                                obj.Estado.Id = int.Parse(reader["EST_Id"].ToString());
                                obj.Ciudad.Id = int.Parse(reader["CIU_Id"].ToString());
                                obj.Colonia.Id = int.Parse(reader["COL_Id"].ToString());
                                obj.EstadoNac.Id = int.Parse(reader["EDO_Nacimiento"].ToString());
                                obj.CiudadNac.Id = int.Parse(reader["CIU_Nacimiento"].ToString());
                                obj.Telefono = reader["EDP_Telefono"].ToString();
                                obj.Sexo = reader["EDP_Sexo"].ToString();
                                obj.FechaNac = reader["EDP_FechaNac"].ToString();
                                obj.Nacionalidad = reader["EDP_Nacionalidad"].ToString();
                                obj.ViveCon = reader["EDP_Vive"].ToString();
                                obj.Estatura =  decimal.Parse(reader["EDP_Estatura"].ToString());
                                obj.Peso = int.Parse(reader["EDP_Peso"].ToString());
                                obj.Dependientes = reader["EDP_Depende"].ToString();
                                obj.OtrosDependientes = reader["EDP_DepenOtros"].ToString();
                                obj.EdoCivil = reader["EDP_EdoCivil"].ToString();
                                obj.EdoCivilOtro = reader["EDP_EdoCivilOtros"].ToString();
                                obj.Correo = reader["EDP_Correo"].ToString();
                                //obj.Empleados.Id = int.Parse(reader["EMP_Numero"].ToString());
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
        public List<ExpedienteDocumentos> CHU_ExpedientesDocumentos_Consultar(ExpedienteDocumentos Expediente)
        {
            List<ExpedienteDocumentos> oList = new List<ExpedienteDocumentos>();
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONS_USP_CHU_EXPEDIENTE_DOCUMENTOS_OBTENER, conn)) {
                        cmd.Parameters.AddWithValue("@Id", Expediente.IdExpediente);

                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                ExpedienteDocumentos obj = new ExpedienteDocumentos();

                                obj.IdExpediente = int.Parse(reader["EXP_Id"].ToString());
                                obj.CURP = reader["EDO_CURP"].ToString();
                                obj.Afore = reader["EDO_Afore"].ToString();
                                obj.RFC = reader["EDO_RFC"].ToString();
                                obj.IMSS = reader["EDO_IMSS"].ToString();
                                obj.Servicio = reader["EDO_Servicio"].ToString();
                                obj.Pasaporte = reader["EDO_Pasaporte"].ToString();
                                obj.Licencia = bool.Parse(reader["EDO_Licencia"].ToString());
                                obj.NoLicencia = reader["EDO_NoLicencia"].ToString();
                                obj.DoctoExtranjero = reader["EDO_DoctoExtranjero"].ToString();

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
        public List<ExpedienteFamilia> CHU_Expediente_Familia_Consultar(ExpedienteFamilia Expediente)
        {
            List<ExpedienteFamilia> oList = new List<ExpedienteFamilia>();
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONS_USP_CHU_EXPEDIENTE_FAMILIA_OBTENER, conn)) {
                        cmd.Parameters.AddWithValue("@Id", Expediente.IdExpediente);

                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                ExpedienteFamilia obj = new ExpedienteFamilia();

                                obj.IdExpediente = int.Parse(reader["EXP_Id"].ToString());
                                obj.Parentesco = reader["EFA_Parentesco"].ToString();
                                obj.Nombre = reader["EFA_Nombre"].ToString();
                                obj.Vivo = bool.Parse(reader["EFA_Vivo"].ToString());
                                obj.Direccion = reader["EFA_Dir"].ToString();
                                obj.Ocupacion = reader["EFA_Ocupa"].ToString();
                                obj.Edad = int.Parse(reader["EFA_Edad"].ToString());

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
        public List<ExpedienteEstudios> CHU_Expediente_Estudios_Consultar(ExpedienteEstudios Expediente)
        {
            List<ExpedienteEstudios> oList = new List<ExpedienteEstudios>();
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONS_USP_CHU_EXPEDIENTE_ESTUDIOS_OBTENER, conn)) {
                        cmd.Parameters.AddWithValue("@Id", Expediente.IdExpediente);

                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                ExpedienteEstudios obj = new ExpedienteEstudios();

                                obj.IdExpediente = int.Parse(reader["EXP_Id"].ToString());
                                obj.Nivel = reader["EXE_Nivel"].ToString();
                                obj.Nombre = reader["EXE_Nombre"].ToString();
                                obj.Direccion = reader["EXE_Direccion"].ToString();
                                obj.Desde = int.Parse(reader["EXE_De"].ToString());
                                obj.Hasta = int.Parse(reader["EXE_Hasta"].ToString());
                                obj.Anios = int.Parse(reader["EXE_Anios"].ToString());
                                obj.Titulo = reader["EXE_Titulo"].ToString();
                                obj.Escuela = reader["EXA_Escuela"].ToString();
                                obj.Horario = reader["EXA_Horario"].ToString();
                                obj.Curso = reader["EXA_Curso"].ToString();
                                obj.Grado = reader["EXA_Grado"].ToString();

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
        public List<ExpedienteEmpleos> CHU_Expediente_Empleos_Consultar(ExpedienteEmpleos Expediente)
        {
            List<ExpedienteEmpleos> oList = new List<ExpedienteEmpleos>();
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONS_USP_CHU_EXPEDIENTE_EMPLEOS_OBTENER, conn)) {
                        cmd.Parameters.AddWithValue("@Id", Expediente.IdExpediente);

                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                ExpedienteEmpleos obj = new ExpedienteEmpleos();

                                obj.IdExpediente = int.Parse(reader["EXP_Id"].ToString());
                                obj.Tiempo = int.Parse(reader["EEM_Tiempo"].ToString());
                                obj.Empresa = reader["EEM_Nombre"].ToString();
                                obj.Direccion = reader["EEM_Direccion"].ToString();
                                obj.Telefono = reader["EEM_Telefono"].ToString();
                                obj.Puesto = reader["EEM_Puesto"].ToString();
                                obj.SueldoIni = decimal.Parse(reader["EEM_SueldoInicial"].ToString());
                                obj.SueldoFin = decimal.Parse(reader["EEM_SueldoFinal"].ToString());
                                obj.Separacion = reader["EEM_Separacion"].ToString();
                                obj.Jefe = reader["EEM_Jefe"].ToString();
                                obj.PuestoJefe = reader["EEM_PuestoJefe"].ToString();
                                obj.Informes =bool.Parse( reader["EEM_Informes"].ToString());
                                obj.Razon = reader["EEM_Razon"].ToString();
                                obj.Comentarios = reader["EEM_Comentarios"].ToString();

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
        public List<ExpedienteSalud> CHU_Expediente_Salud_Consultar(ExpedienteSalud Expediente)
        {
            List<ExpedienteSalud> oList = new List<ExpedienteSalud>();
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONS_USP_CHU_EXPEDIENTE_SALUD_OBTENER, conn)) {
                        cmd.Parameters.AddWithValue("@Id", Expediente.IdExpediente);

                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                ExpedienteSalud obj = new ExpedienteSalud();

                                obj.IdExpediente = int.Parse(reader["EXP_Id"].ToString());
                                obj.EstadoActual = reader["ESA_EstadoActual"].ToString();
                                obj.Enfermedad = bool.Parse(reader["ESA_Enfermedad"].ToString());
                                obj.Tipo = reader["ESA_Tipo"].ToString();
                                obj.Deporte = reader["ESA_Deporte"].ToString();
                                obj.Club = reader["ESA_Club"].ToString();
                                obj.Pasatiempo = reader["ESA_Pasatiempo"].ToString();
                                obj.Meta = reader["ESA_Meta"].ToString();

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
        public List<ExpedienteConocimiento> CHU_Expediente_Conocimiento_Consultar(ExpedienteConocimiento Expediente)
        {
            List<ExpedienteConocimiento> oList = new List<ExpedienteConocimiento>();
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONS_USP_CHU_EXPEDIENTE_CONOCIMIENTOS_OBTENER, conn)) {
                        cmd.Parameters.AddWithValue("@Id", Expediente.IdExpediente);

                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                ExpedienteConocimiento obj = new ExpedienteConocimiento();

                                obj.IdExpediente = int.Parse(reader["EXP_Id"].ToString());
                                obj.Idioma = reader["ECO_Idioma"].ToString();
                                obj.Porcentaje = int.Parse(reader["ECO_Porcentaje"].ToString());
                                obj.Maquinas = reader["ECO_Maquinas"].ToString();
                                obj.Funciones = reader["ECO_Funciones"].ToString();
                                obj.Software = reader["ECO_Software"].ToString();
                                obj.Otros = reader["ECO_Otros"].ToString();

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
        public List<ExpedienteReferencias> CHU_Expediente_Referencias_Consultar(ExpedienteReferencias Expediente)
        {
            List<ExpedienteReferencias> oList = new List<ExpedienteReferencias>();
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONS_USP_CHU_EXPEDIENTE_REFERENCIA_OBTENER, conn)) {
                        cmd.Parameters.AddWithValue("@Id", Expediente.IdExpediente);

                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                ExpedienteReferencias obj = new ExpedienteReferencias();

                                obj.IdExpediente = int.Parse(reader["EXP_Id"].ToString());
                                obj.Nombre = reader["ERE_Nombre"].ToString();
                                obj.Direccion = reader["ERE_Direccion"].ToString();
                                obj.Telefono = reader["ERE_Telefono"].ToString();
                                obj.Ocupacion = reader["ERE_Ocupacion"].ToString();
                                obj.Tiempo = int.Parse(reader["ERE_Tiempo"].ToString());

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
        public List<ExpedienteGenerales> CHU_Expediente_Generales_Consultar(ExpedienteGenerales Expediente)
        {
            List<ExpedienteGenerales> oList = new List<ExpedienteGenerales>();
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONS_USP_CHU_EXPEDIENTE_GENERALES_OBTENER, conn)) {
                        cmd.Parameters.AddWithValue("@Id", Expediente.IdExpediente);

                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                ExpedienteGenerales obj = new ExpedienteGenerales();

                                obj.IdExpediente = int.Parse(reader["EXP_Id"].ToString());
                                obj.Anuncio = bool.Parse(reader["EXP_Anuncio"].ToString());
                                obj.Otro = reader["EGE_Otro"].ToString();
                                obj.Parientes = bool.Parse(reader["EGE_Parientes"].ToString());
                                obj.Nombres = reader["EGE_Nombres"].ToString();
                                obj.Fianza = bool.Parse(reader["EGE_Fianza"].ToString());
                                obj.Afinazadora = reader["EGE_Afianzadora"].ToString();
                                obj.Sindicalizado = bool.Parse(reader["EGE_Sindilizado"].ToString());
                                obj.Sindicato = reader["EGE_Sindicato"].ToString();
                                obj.SeguroVida = bool.Parse(reader["EGE_SeguroVida"].ToString());
                                obj.Aseguradora = reader["EGE_Aseguradora"].ToString();
                                obj.Viajar = bool.Parse(reader["EGE_Viajar"].ToString());
                                obj.Razon = reader["EGE_Razon"].ToString();
                                obj.Residencia = bool.Parse(reader["EGE_Residencia"].ToString());
                                obj.Motivo = reader["EGE_Motivo"].ToString();
                                obj.Fecha = reader["EGE_Fecha"].ToString();

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
        public List<ExpedienteEconomicos> CHU_Expediente_Economicos_Consultar(ExpedienteEconomicos Expediente)
        {
            List<ExpedienteEconomicos> oList = new List<ExpedienteEconomicos>();
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONS_USP_CHU_EXPEDIENTE_ECONOMICOS_OBTENER, conn)) {
                        cmd.Parameters.AddWithValue("@Id", Expediente.IdExpediente);

                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                ExpedienteEconomicos obj = new ExpedienteEconomicos();

                                obj.IdExpediente = int.Parse(reader["EXP_Id"].ToString());
                                obj.OtrosIngresos = bool.Parse(reader["EDE_OtrosIngresos"].ToString());
                                obj.Nombre = reader["EDE_Nombre"].ToString();
                                obj.Monto = decimal.Parse(reader["EDE_Monto"].ToString());
                                obj.Conyuge = bool.Parse(reader["EDE_Conyugue"].ToString());
                                obj.Donde = reader["EDE_Donde"].ToString();
                                obj.Sueldo= decimal.Parse(reader["EDE_Sueldo"].ToString());
                                obj.Casa = bool.Parse(reader["EDE_Casa"].ToString());
                                obj.Valor = decimal.Parse(reader["EDE_Valor"].ToString());
                                obj.Renta = bool.Parse(reader["EDE_Renta"].ToString());
                                obj.Pago = decimal.Parse(reader["EDE_Pago"].ToString());
                                obj.Auto = bool.Parse(reader["EDE_Auto"].ToString());
                                obj.Marca = reader["EDE_Marca"].ToString();
                                obj.Modelo = reader["EDE_Modelo"].ToString();
                                obj.Deudas = bool.Parse(reader["EDE_Deudas"].ToString());
                                obj.Quien = reader["EDE_Quien"].ToString();
                                obj.Importe = decimal.Parse(reader["EDE_Importe"].ToString());
                                obj.Abono = decimal.Parse(reader["EDE_Abono"].ToString());
                                obj.Gastos = decimal.Parse(reader["EDE_Gastos"].ToString());

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
