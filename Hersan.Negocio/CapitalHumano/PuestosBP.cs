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
        public int ABCPuestos_Guardar(PuestosBE obj)
        {
            return new PuestosDA().ABCPuestos_Guardar(obj);
        }
        public int ABCPuestos_Actualizar(PuestosBE obj)
        {
            return new PuestosDA().ABCPuestos_Actualizar(obj);
        }
        public List<PuestosBE> ABCPuestos_Combo(int IdDepto)
        {
            return new PuestosDA().ABCPuestos_Combo(IdDepto);
        }
        public List<PuestosBE> CHUPuestos_Puntos(int idPuesto)
        {
            return new PuestosDA().CHUPuestos_Puntos(idPuesto);
        }
    }
}
