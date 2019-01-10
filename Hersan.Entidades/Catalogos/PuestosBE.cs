using Hersan.Entidades.Comun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hersan.Entidades.Catalogos
{
   public class PuestosBE
    {

        public PuestosBE()
        {
            Id_puesto = 0;
            Nombre = string.Empty;
            Abrev = string.Empty;
            DatosUsuario = new GeneralBE();
            departamentos = new DepartamentosBE();
        }
        public int Id_puesto { get; set; }
        public string Nombre { get; set; }
        public string Abrev { get; set; }
        public GeneralBE DatosUsuario { get; set; }
        public DepartamentosBE departamentos { get; set; }
    }
}
