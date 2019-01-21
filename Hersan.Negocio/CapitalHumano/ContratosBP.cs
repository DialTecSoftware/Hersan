using Hersan.Datos.CapitalHumano;
using Hersan.Entidades.CapitalHumano;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hersan.Negocio.CapitalHumano
{
   public   class ContratosBP
    {
        public List<ContratosBE> ABCContratos_Obtener()
        {
            return new ContratosDA().ABCContratos_Obtener();
        }
        public int ABCContratos_Guardar(ContratosBE obj)
        {
            return new ContratosDA().ABCContratos_Guardar(obj);
        }
        public int ABCContratos_Actualizar(ContratosBE obj)
        {
            return new ContratosDA().ABCContratos_Actualizar(obj);
        }
    }
}
