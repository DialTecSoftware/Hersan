using Hersan.Entidades.Comun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hersan.Entidades.Catalogos
{
   public class EquipoHerramientasBE
    {
        public EquipoHerramientasBE()
        {
            Id = 0;
            Nombre = string.Empty;
            Equipo = false;
            Herramienta = false;
            DatosUsuario = new GeneralBE();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public bool Equipo { get; set; }
        public bool Herramienta { get; set; }
        public GeneralBE DatosUsuario { get; set; }
    }
}
