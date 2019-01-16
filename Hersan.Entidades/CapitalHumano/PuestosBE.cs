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
            Id = 0;
            Nombre = string.Empty;
            Abrev = string.Empty;
            DatosUsuario = new GeneralBE();
            Departamentos = new DepartamentosBE();
        }
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Abrev { get; set; }
        public GeneralBE DatosUsuario { get; set; }
        public DepartamentosBE Departamentos { get; set; }
    }
}
