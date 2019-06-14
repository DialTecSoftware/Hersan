using Hersan.Datos.CapitalHumano;
using Hersan.Entidades.CapitalHumano;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hersan.Negocio.CapitalHumano
{
   public class SolicitudPersonalBP
    {
        public List<SolicitudPersonalBE> CHU_SolicitudP_Obtener(int IdUser)
        {
            return new SolicitudPersonalDA().CHU_SolicitudP_Obtener( IdUser);
        }
        public int CHU_SolicitudP_Guardar(SolicitudPersonalBE obj)
        {
            return new SolicitudPersonalDA().CHU_SolicitudP_Guardar(obj);
        }
        public int CHU_SolicitudP_Actualizar(SolicitudPersonalBE obj)
        {
            return new SolicitudPersonalDA().CHU_SolicitudP_Actualizar(obj);
        }
        public int CHU_SolicitudP_ActualizarDictamen(SolicitudPersonalBE obj)
        {
            return new SolicitudPersonalDA().CHU_SolicitudP_ActualizarDictamen(obj);
        }
    }
}
