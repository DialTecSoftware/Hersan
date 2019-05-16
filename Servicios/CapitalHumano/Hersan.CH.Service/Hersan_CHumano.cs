using Hersan.CH.Contract;
using Hersan.Entidades.CapitalHumano;
using Hersan.Entidades.Relchec;
using Hersan.Negocio.CapitalHumano;
using Hersan.Negocio.Relchec;
using System.Collections.Generic;
using System.Data;

namespace Hersan.CH.Service
{
    public class Hersan_CHumano : IHersan_CHumano
    {
        #region Perfiles
        public int CHU_Perfiles_Guardar(PerfilesBE obj, DataTable Detalle)
        {
            return new PerfilesBP().CHU_Perfiles_Guardar(obj, Detalle);
        }
        public DataSet CHU_Perfiles_Obtener(int IdDepto, int IdPuesto)
        {
            return new PerfilesBP().CHU_Perfiles_Obtener(IdDepto, IdPuesto);
        }
        public int CHU_Perfiles_Actualiza(PerfilesBE obj, DataTable Detalle)
        {
            return new PerfilesBP().CHU_Perfiles_Actualiza(obj, Detalle);
        }
        public int CHU_Perfiles_Elimina(int IdPerfil, int IdUsuario)
        {
            return new PerfilesBP().CHU_Perfiles_Elimina(IdPerfil, IdUsuario);
        }
        #endregion

        #region SolicitudPersonal
        public List<SolicitudPersonalBE> CHU_SolicitudP_Obtener(int IdUser)
        {
            return new SolicitudPersonalBP().CHU_SolicitudP_Obtener(IdUser);
        }
        public int CHU_SolicitudP_Guardar(SolicitudPersonalBE obj)
            {
                return new SolicitudPersonalBP().CHU_SolicitudP_Guardar(obj);
            }
            public int CHU_SolicitudP_Actualizar(SolicitudPersonalBE obj)
            {
                return new SolicitudPersonalBP().CHU_SolicitudP_Actualizar(obj);
            }
        #endregion

        #region DictamenSustitucion
        public List<DictamenSustitucionBE> CHUDictamenSolicitud_Obtener()
        {
            return new DictamenSustitucionBP().CHUDictamenSolicitud_Obtener();
        }
        public int CHUDictamenSolicitud__Guardar(DictamenSustitucionBE obj)
        {
            return new DictamenSustitucionBP().CHUDictamenSolicitud__Guardar(obj);
        }
        public int CHUDictamenSolicitud_Actualizar(DictamenSustitucionBE obj)
        {
            return new DictamenSustitucionBP().CHUDictamenSolicitud_Actualizar(obj);
        }
        #endregion

        #region Expedientes
        public int CHU_Expedientes_Guardar( DataSet Tablas, byte[] Imagen, int IdUsuario)
        {
            return new ExpedientesBP().CHU_Expedientes_Guardar( Tablas, Imagen, IdUsuario);
        }
        public List<ExpedientesBE> CHU_Expedientes_Consultar(ExpedientesBE Expediente)
        {
            return new ExpedientesBP().CHU_Expedientes_Consultar(Expediente);
        }
        public int CHU_Expedientes_Actualizar(int Id, DataSet Tablas, byte[] Imagen, int IdUsuario)
        {
            return new ExpedientesBP().CHU_Expedientes_Actualizar(Id, Tablas, Imagen, IdUsuario);
        }
        public int CHU_Expedientes_Eliminar(int Id, int IdUsuario)
        {
            return new ExpedientesBP().CHU_Expedientes_Eliminar(Id, IdUsuario);
        }
        public List<ExpedientesDatosPersonales> CHU_ExpedientesDatosPersonales_Consultar(ExpedientesDatosPersonales Expediente)
        {
            return new ExpedientesBP().CHU_ExpedientesDatosPersonales_Consultar(Expediente);
        }
        public List<ExpedientesBE> CHU_Expedientes_Obtener(int IdExpediente)
        {
            return new ExpedientesBP().CHU_Expedientes_Obtener(IdExpediente);
        }
        public List<ExpedienteDocumentos> CHU_ExpedientesDocumentos_Consultar(ExpedienteDocumentos Expediente)
        {
            return new ExpedientesBP().CHU_ExpedientesDocumentos_Consultar(Expediente);
        }
        public List<ExpedienteFamilia> CHU_Expediente_Familia_Consultar(ExpedienteFamilia Expediente)
        {
            return new ExpedientesBP().CHU_Expediente_Familia_Consultar(Expediente);
        }
        public List<ExpedienteEstudios> CHU_Expediente_Estudios_Consultar(ExpedienteEstudios Expediente)
        {
            return new ExpedientesBP().CHU_Expediente_Estudios_Consultar(Expediente);
        }
        public List<ExpedienteEmpleos> CHU_Expediente_Empleos_Consultar(ExpedienteEmpleos Expediente)
        {
            return new ExpedientesBP().CHU_Expediente_Empleos_Consultar(Expediente);
        }
        public List<ExpedienteSalud> CHU_Expediente_Salud_Consultar(ExpedienteSalud Expediente)
        {
            return new ExpedientesBP().CHU_Expediente_Salud_Consultar(Expediente);
        }
        public List<ExpedienteConocimiento> CHU_Expediente_Conocimiento_Consultar(ExpedienteConocimiento Expediente)
        {
            return new ExpedientesBP().CHU_Expediente_Conocimiento_Consultar(Expediente);
        }
        public List<ExpedienteReferencias> CHU_Expediente_Referencias_Consultar(ExpedienteReferencias Expediente)
        {
            return new ExpedientesBP().CHU_Expediente_Referencias_Consultar(Expediente);
        }
        public List<ExpedienteGenerales> CHU_Expediente_Generales_Consultar(ExpedienteGenerales Expediente)
        {
            return new ExpedientesBP().CHU_Expediente_Generales_Consultar(Expediente);
        }
        public List<ExpedienteEconomicos> CHU_Expediente_Economicos_Consultar(ExpedienteEconomicos Expediente)
        {
            return new ExpedientesBP().CHU_Expediente_Economicos_Consultar(Expediente);
        }
        #endregion

        #region NuevoPuesto
        public List<NuevoPuestoBE> CHU_NuevoPuesto_Obtener(int IdUser)
        {
            return new NuevoPuestoBP().CHU_NuevoPuesto_Obtener(IdUser);
        }
        public int CHU_NuevoPuesto_Guardar(NuevoPuestoBE obj)
        {
            return new NuevoPuestoBP().CHU_NuevoPuesto_Guardar(obj);
        }
        public int CHU_NuevoPuesto_Actualizar(NuevoPuestoBE obj)
        {
            return new NuevoPuestoBP().CHU_NuevoPuesto_Actualizar(obj);
        }

        #endregion

        #region DictamenNuevoPuesto
        public List<DictamenNuevoPuestoBE> CHU_DictamenNuevoP_Obtener()
        {
            return new DictamenNuevoPuestoBP().CHU_DictamenNuevoP_Obtener();
        }
        public int CHU_DictamenNuevoP_Guardar(DictamenNuevoPuestoBE obj)
        {
            return new DictamenNuevoPuestoBP().CHU_DictamenNuevoP_Guardar(obj);
        }
        public int CHU_DictamenNuevoP_Actualizar(DictamenNuevoPuestoBE obj)
        {
            return new DictamenNuevoPuestoBP().CHU_DictamenNuevoP_Actualizar(obj);
        }

        #endregion

        #region EvaluacionInduccion
        public List<EvaluacionInduccionBE> CHU_DatosEMP_Obtener(EvaluacionInduccionBE evaluacion)
        {
            return new EvaluacionInduccionBP().CHU_DatosEMP_Obtener( evaluacion);
        }
        public List<EvaluacionInduccionBE> CHU_EvaluacionInduccion_Obtener()
        {
            return new EvaluacionInduccionBP().CHU_EvaluacionInduccion_Obtener();
        }
        public List<PreguntasEvaluacionBE> CHU_ObtenerPreguntas()
        {
            return new EvaluacionInduccionBP().CHU_ObtenerPreguntas();
        }
        public int CHU_EvaluacionInduccion_Guardar(DataSet Tablas, int IdUsuario)
        {
            return new EvaluacionInduccionBP().CHU_EvaluacionInduccion_Guardar(Tablas,IdUsuario);
        }
        //public int CHU_EvaluacionInduccion_Guardar(EvaluacionInduccionBE obj)
        //{
        //    return new EvaluacionInduccionBP().CHU_DictamenNuevoP_Actualizar(obj);
        //}

        #endregion

        #region Seguimiento Canddatos
        public List<SeguimientoCandidatosBE> CHU_SeguimientoCan_Obtener()
        {
            return new SeguimientoCandidatosBP().CHU_SeguimientoCan_Obtener();
        }
        public int CHU_SeguimientoCan_Guardar(SeguimientoCandidatosBE obj)
        {
            return new SeguimientoCandidatosBP().CHU_SeguimientoCan_Guardar(obj);
        }
        public int CHU_SeguimientoCan_Actualizar(SeguimientoCandidatosBE obj)
        {
            return new SeguimientoCandidatosBP().CHU_SeguimientoCan_Actualizar(obj);
        }
        #endregion

        #region Reloj Checador
        public List<HorariosBE> ABCHorarios_Obtener()
        {
            return new HorariosBP().ABCHorarios_Obtener();
        }
        public int ABCHorarios_Guarda(HorariosBE obj)
        {
            return new HorariosBP().ABCHorarios_Guarda(obj);
        }
        public int ABCHorarios_Actualiza(HorariosBE obj)
        {
            return new HorariosBP().ABCHorarios_Actualizar(obj);
        }
        #endregion

        #region Digitalizados
     
        public DataSet CHU_Digitalizados_Obtener(int IdExp)
        {
            return new DigitalizadosBP().CHU_Digitalizados_Obtener(IdExp);
        }
        public int CHU_Digitalizados_Guardar(DigitalizadosBE obj, DataTable Detalle)
        {
            return new DigitalizadosBP().CHU_Digitalizados_Guardar(obj, Detalle);
        }
        public int CHU_Digitalizados_Actualiza(DigitalizadosBE obj, DataTable Detalle)
        {
            return new DigitalizadosBP().CHU_Digitalizados_Actualiza(obj, Detalle);
        }

        public int CHU_Digitalizados_Elimina(int IdDocs, int IdUsuario)
        {
            return new DigitalizadosBP().CHU_Digitalizados_Elimina(IdDocs, IdUsuario);
        }
        #endregion

        #region DescripcionPuestos

        public DataSet CHU_DescripcionPuestos_Obtener(int IdPerfifl)
        {
            return new DescripcionPuestosBP().CHU_DescripcionPuestos_Obtener(IdPerfifl);
        }
        public int CHU_DescPuestos_Guardar(DescripcionPuestosBE obj, DataTable Contactos, DataTable Condiciones)
        {
            return new DescripcionPuestosBP().CHU_DescPuestos_Guardar(obj, Contactos, Condiciones);
        }
        public int CHU_DescPuestos_Actualizar(DescripcionPuestosBE obj, DataTable Contactos, DataTable Condiciones)
        {
            return new DescripcionPuestosBP().CHU_DescPuestos_Actualizar(obj, Contactos, Condiciones);
        }

        public int CHU_DescPuestos_Elimina(int IdDesc, int IdUsuario)
        {
            return new DescripcionPuestosBP().CHU_DescPuestos_Elimina(IdDesc, IdUsuario);
        }
        #endregion

        #region Empleados
        public List<EmpleadosBE> CHU_Empleados_Consultar(int IdExp)
        {
            return new EmpleadosBP().CHU_Empleados_Consultar(IdExp);
        }
        public int CHUEmpleados_Guardar(EmpleadosBE obj)
        {
            return new EmpleadosBP().CHUEmpleados_Guardar(obj);
        }
        public int CHU_EmpleadosActualizar(EmpleadosBE obj)
        {
            return new EmpleadosBP().CHU_EmpleadosActualizar(obj);
        }
        public int CHU_Empleados_Elimina(int IdEmp, int IdUsuario)
        {
            return new EmpleadosBP().CHU_Empleados_Elimina(IdEmp, IdUsuario);
        }
        #endregion
    }
}

