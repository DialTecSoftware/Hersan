using Hersan.Datos.Catalogos;
using Hersan.Entidades.Catalogos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hersan.Negocio.Catalogos
{
   public class EducacionBP
    {
        public List<EducacionBE> ABCEducacion_Obtener()
        {
            return new EducacionDA().ABCEducacion_Obtener();
        }
        public int ABCEducacion_Guardar(EducacionBE obj)
        {
            return new EducacionDA().ABCEducacion_Guardar(obj);
        }
        public int ABCEducacion_Actualizar(EducacionBE obj)
        {
            return new EducacionDA().ABCEducacion_Actualizar(obj);
        }

    }
}
