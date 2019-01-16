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
        public int ABCTiposContrato_Guardar(TiposContratoBE obj)
        {
            return new TiposContratoDA().ABCTiposContrato_Guardar(obj);
        }
        public int ABCTiposContrato_Actualizar(TiposContratoBE obj)
        {
            return new TiposContratoDA().ABCTiposContrato_Actualizar(obj);
        }
    }
}
