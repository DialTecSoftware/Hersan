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
        public int ABCFunciones_Guardar(FuncionesBE obj)
        {
            return new FuncionesDA().ABCFunciones_Guardar(obj);
        }
        public int ABCFunciones_Actualizar(FuncionesBE obj)
        {
            return new FuncionesDA().ABCFunciones_Actualizar(obj);
        }
        public List<FuncionesBE> ABCFunciones_Combo()
        {
            return new FuncionesDA().ABCFunciones_Combo();
        }
    }
}
