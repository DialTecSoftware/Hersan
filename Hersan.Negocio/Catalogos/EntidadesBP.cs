using Hersan.Datos.Catalogos;
using Hersan.Entidades.Catalogos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hersan.Negocio.Catalogos
{
   public class EntidadesBP
    {

        public List<EntidadesBE> Entidades_Obtener()
        {
            return new EntidadesDA().Entidades_Obtener();
        }
        public int ABCEntidades_Guardar(EntidadesBE obj)
        {
            return new EntidadesDA().ABCEntidades_Guardar(obj);
        }
        public int ABCEntidades_Actualizar(EntidadesBE obj)
        {
            return new EntidadesDA().ABCEntidades_Actualizar(obj);
        }
        public List<EntidadesBE> Entidades_Combo(int IdEmpresa)
        {
            return new EntidadesDA().Entidades_Combo(IdEmpresa);
        }
    }
}
