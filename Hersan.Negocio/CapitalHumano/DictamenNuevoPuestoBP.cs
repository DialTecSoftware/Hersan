using Hersan.Datos.CapitalHumano;
using Hersan.Entidades.CapitalHumano;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hersan.Negocio
{
    public class DictamenNuevoPuestoBP
    {
        public List<DictamenNuevoPuestoBE> CHU_DictamenNuevoP_Obtener()
        {
            return new DictamenNuevoPuestoDA().CHU_DictamenNuevoP_Obtener();
        }
        public int CHU_DictamenNuevoP_Guardar(DictamenNuevoPuestoBE obj)
        {
            return new DictamenNuevoPuestoDA().CHU_DictamenNuevoP_Guardar(obj);
        }
        public int CHU_DictamenNuevoP_Actualizar(DictamenNuevoPuestoBE obj)
        {
            return new DictamenNuevoPuestoDA().CHU_DictamenNuevoP_Actualizar(obj);
        }
    }
}
