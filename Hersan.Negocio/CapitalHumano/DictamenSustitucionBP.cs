using Hersan.Datos.CapitalHumano;
using Hersan.Entidades.CapitalHumano;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hersan.Negocio.CapitalHumano
{
    public class DictamenSustitucionBP
    {
        public List<DictamenSustitucionBE> CHUDictamenSolicitud_Obtener()
        {
            return new DictamenSustitucionDA().CHUDictamenSolicitud_Obtener();
        }
        public int CHUDictamenSolicitud__Guardar(DictamenSustitucionBE obj)
        {
            return new DictamenSustitucionDA().CHUDictamenSolicitud__Guardar(obj);
        }
        public int CHUDictamenSolicitud_Actualizar(DictamenSustitucionBE obj)
        {
            return new DictamenSustitucionDA().CHUDictamenSolicitud_Actualizar(obj);
        }
    }
}
