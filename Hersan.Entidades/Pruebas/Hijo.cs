using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hersan.Entidades.Pruebas
{
    public class Hijo
    {
        public int Hijo_Id { get; set; }
        public string Hijo_Nombre { get; set; }
        public string Hijo_Apellido { get; set; }
        public virtual Padre Papa { get; set; }

    }
}
