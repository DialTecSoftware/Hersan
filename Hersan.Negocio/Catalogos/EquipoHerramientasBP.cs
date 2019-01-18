using Hersan.Datos.Catalogos;
using Hersan.Entidades.Catalogos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hersan.Negocio.Catalogos
{
 public   class EquipoHerramientasBP
    {
        public List<EquipoHerramientasBE> ABCEquipoHerramientas_Obtener()
        {
            return new EquipoHerramientasDA().ABCEquipoHerramientas_Obtener();
        }
        public int ABCEquipoHerramientas_Guardar(EquipoHerramientasBE obj)
        {
            return new EquipoHerramientasDA().ABCEquipoHerramientas_Guardar(obj);
        }
        public int ABCEquipoHerramientas_Actualizar(EquipoHerramientasBE obj)
        {
            return new EquipoHerramientasDA().ABCEquipoHerramientas_Actualizar(obj);
        }
    }
}
