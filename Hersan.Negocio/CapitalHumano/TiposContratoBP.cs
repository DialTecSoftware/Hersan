using Hersan.Datos.Catalogos;
using Hersan.Entidades.Catalogos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hersan.Negocio.Catalogos
{
  public  class TiposContratoBP
    {
        public List<TiposContratoBE> TiposContrato_Obtener()
        {
            return new TiposContratoDA().TiposContrato_Obtener();
        }
    }
}
