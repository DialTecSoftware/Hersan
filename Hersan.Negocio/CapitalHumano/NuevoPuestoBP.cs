using Hersan.Datos.CapitalHumano;
using Hersan.Entidades.CapitalHumano;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hersan.Negocio.CapitalHumano
{
    public class NuevoPuestoBP
    {
        public List<NuevoPuestoBE> CHU_NuevoPuesto_Obtener(int IdUser)
        {
            return new NuevoPuestoDA().CHU_NuevoPuesto_Obtener( IdUser);
        }
        public int CHU_NuevoPuesto_Guardar(NuevoPuestoBE obj)
        {
            return new NuevoPuestoDA().CHU_NuevoPuesto_Guardar(obj);
        }
        public int CHU_NuevoPuesto_Actualizar(NuevoPuestoBE obj)
        {
            return new NuevoPuestoDA().CHU_NuevoPuesto_Actualizar(obj);
        }
        public int CHU_NuevoPuesto_ActualizarDictamen(NuevoPuestoBE obj)
        {
            return new NuevoPuestoDA().CHU_NuevoPuesto_ActualizarDictamen(obj);
        }
    }
}
