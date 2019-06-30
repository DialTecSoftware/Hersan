using Hersan.Datos.Calidad;
using Hersan.Entidades.Calidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hersan.Negocio.Calidad
{
    public class NormaBP
    {
        public int CAL_ReflejantesNorma_Guardar(NormaBE Obj)
        {
            return new NormaDA().CAL_ReflejantesNorma_Guardar(Obj);
        }
        public int CAL_ReflejantesNorma_Actualizar(NormaBE Obj)
        {
            return new NormaDA().CAL_ReflejantesNorma_Actualizar(Obj);
        }
        public List<NormaBE> CAL_ReflejantesNorma_Obtener()
        {
            return new NormaDA().CAL_ReflejantesNorma_Obtener();
        }
    }
}
