using Hersan.Datos.Catalogos;
using Hersan.Entidades.Catalogos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hersan.Negocio.Catalogos
{
    public class DepartamentosBP
    {
        public List<DepartamentosBE> ABCDepartamentos_Obtener()
        {
            return new DepartamentosDA().ABCDepartamentos_Obtener();
        }
    }
}
