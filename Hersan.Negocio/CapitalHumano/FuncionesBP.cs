using Hersan.Datos.Catalogos;
using Hersan.Entidades.CapitalHumano;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hersan.Negocio.CapitalHumano
{
    public class FuncionesBP
    {
        public List<FuncionesBE> ABCFunciones_Obtener()
        {
            return new FuncionesDA().ABCFunciones_Obtener();
        }
    }
}
