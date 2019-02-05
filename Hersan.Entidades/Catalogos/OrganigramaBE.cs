using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hersan.Entidades.Catalogos
{
   public class OrganigramaBE
    {
        public OrganigramaBE()
        {
            Nivel = 0;
            Id_padre = 0;
            Id_puesto = 0;
            Nombre = string.Empty;
            Padre = string.Empty;
        }
        public int Nivel { get; set; }
        public string Nombre { get; set; }
        public string Padre { get; set; }
        public int Id_puesto { get; set; }
        public int Id_padre { get; set; }
    }
}
