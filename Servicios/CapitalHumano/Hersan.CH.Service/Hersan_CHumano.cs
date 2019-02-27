using Hersan.CH.Contract;
using Hersan.Entidades.CapitalHumano;
using Hersan.Negocio;
using Hersan.Negocio.CapitalHumano;
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
        public int CHU_Expedientes_Guardar( DataSet Tablas, int IdUsuario)
        {
            return new ExpedientesBP().CHU_Expedientes_Guardar( Tablas, IdUsuario);
        }

        #endregion

        #region NuevoPuesto
        public List<NuevoPuestoBE> CHU_NuevoPuesto_Obtener(int IdUser)
        {
            return new NuevoPuestoBP().CHU_NuevoPuesto_Obtener( IdUser);
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
    }
}

