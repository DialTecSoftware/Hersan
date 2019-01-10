using Hersan.Datos.Catalogos;
using Hersan.Entidades.Catalogos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hersan.Negocio.Catalogos
{
   public class PuestosBP
    {
        public List<PuestosBE> ABCPuestos_Obtener()
        {
            return new PuestosDA().ABCPuestos_Obtener();
        }
    }
}
