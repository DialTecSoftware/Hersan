using Hersan.Datos.CapitalHumano;
using Hersan.Entidades.CapitalHumano;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hersan.Negocio.CapitalHumano
{
   public class SeguimientoCandidatosBP
    {
        public List<SeguimientoCandidatosBE> CHU_SeguimientoCan_Obtener()
        {
            return new SeguimientoCandidatosDA().CHU_SeguimientoCan_Obtener();
        }
        public int CHU_SeguimientoCan_Guardar(SeguimientoCandidatosBE obj)
        {
            return new SeguimientoCandidatosDA().CHU_SeguimientoCan_Guardar(obj);
        }
        public int CHU_SeguimientoCan_Actualizar(SeguimientoCandidatosBE obj)
        {
            return new SeguimientoCandidatosDA().CHU_SeguimientoCan_Actualizar(obj);
        }
    }
}
