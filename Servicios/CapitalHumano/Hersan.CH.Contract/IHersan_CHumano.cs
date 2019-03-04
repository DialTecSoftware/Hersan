using Hersan.Entidades.CapitalHumano;
using System.Collections.Generic;
using System.Data;
using System.ServiceModel;

namespace Hersan.CH.Contract
{
    [ServiceContract]
    public interface IHersan_CHumano
    {
        #region Perfiles
        [OperationContract]
        int CHU_Perfiles_Guardar(PerfilesBE obj, DataTable Detalle);
        [OperationContract]
        DataSet CHU_Perfiles_Obtener(int IdDepto, int IdPuesto);
        [OperationContract]
        int CHU_Perfiles_Actualiza(PerfilesBE obj, DataTable Detalle);
        [OperationContract]
        int CHU_Perfiles_Elimina(int IdPerfil, int IdUsuario);
        #endregion

        #region SolicitudPersonal
        [OperationContract]
        List<SolicitudPersonalBE> CHU_SolicitudP_Obtener(int IdUser);
        [OperationContract]
        int CHU_SolicitudP_Guardar(SolicitudPersonalBE obj);
        [OperationContract]
        int CHU_SolicitudP_Actualizar(SolicitudPersonalBE obj);

        #endregion

        #region DictamenSustitucion
        [OperationContract]
        List<DictamenSustitucionBE> CHUDictamenSolicitud_Obtener();
        [OperationContract]
        int CHUDictamenSolicitud__Guardar(DictamenSustitucionBE obj);
        [OperationContract]
        int CHUDictamenSolicitud_Actualizar(DictamenSustitucionBE obj);

        #endregion

        #region Expedientes
        [OperationContract]
        int CHU_Expedientes_Guardar(DataSet Tablas, byte[] Imagen, int IdUsuario);
        [OperationContract]
        List<ExpedientesBE> CHU_Expedientes_Consultar(ExpedientesBE Expediente);
        [OperationContract]
        int CHU_Expedientes_Actualizar(int Id, DataSet Tablas, byte[] Imagen, int IdUsuario);
        [OperationContract]
        int CHU_Expedientes_Eliminar(int Id, int IdUsuario);
        [OperationContract]
        List<ExpedientesDatosPersonales> CHU_ExpedientesDatosPersonales_Consultar(ExpedientesDatosPersonales Expediente);
        [OperationContract]
        List<ExpedientesBE> CHU_Expedientes_Obtener(int IdExpediente);
        [OperationContract]
        List<ExpedienteDocumentos> CHU_ExpedientesDocumentos_Consultar(ExpedienteDocumentos Expediente);
        [OperationContract]
        List<ExpedienteFamilia> CHU_Expediente_Familia_Consultar(ExpedienteFamilia Expediente);
        [OperationContract]
        List<ExpedienteEstudios> CHU_Expediente_Estudios_Consultar(ExpedienteEstudios Expediente);
        [OperationContract]
        List<ExpedienteEmpleos> CHU_Expediente_Empleos_Consultar(ExpedienteEmpleos Expediente);
        [OperationContract]
        List<ExpedienteSalud> CHU_Expediente_Salud_Consultar(ExpedienteSalud Expediente);
        [OperationContract]
        List<ExpedienteConocimiento> CHU_Expediente_Conocimiento_Consultar(ExpedienteConocimiento Expediente);
        [OperationContract]
        List<ExpedienteReferencias> CHU_Expediente_Referencias_Consultar(ExpedienteReferencias Expediente);
        [OperationContract]
        List<ExpedienteGenerales> CHU_Expediente_Generales_Consultar(ExpedienteGenerales Expediente);
        [OperationContract]
        List<ExpedienteEconomicos> CHU_Expediente_Economicos_Consultar(ExpedienteEconomicos Expediente);
        #endregion

        #region NuevoPuesto
        [OperationContract]
        List<NuevoPuestoBE> CHU_NuevoPuesto_Obtener(int IdUser);
        [OperationContract]
        int CHU_NuevoPuesto_Guardar(NuevoPuestoBE obj);
        [OperationContract]
        int CHU_NuevoPuesto_Actualizar(NuevoPuestoBE obj);

        #endregion


        #region DictamenNuevoPuesto
        [OperationContract]
        List<DictamenNuevoPuestoBE> CHU_DictamenNuevoP_Obtener();
        [OperationContract]
        int CHU_DictamenNuevoP_Guardar(DictamenNuevoPuestoBE obj);
        [OperationContract]
        int CHU_DictamenNuevoP_Actualizar(DictamenNuevoPuestoBE obj);

        #endregion
    }
}
