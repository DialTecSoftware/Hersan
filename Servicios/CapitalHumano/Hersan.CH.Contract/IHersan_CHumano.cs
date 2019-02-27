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
        int CHU_Expedientes_Guardar(DataSet Tablas, int IdUsuario);
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
