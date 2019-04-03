using Hersan.Entidades.Comun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hersan.Entidades.Catalogos
{
    public class FormasPagoBE
    {
        public FormasPagoBE()
        {
            Id = 0;
            Descripcion = string.Empty;
            DatosUsuario = new GeneralBE();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }
        public GeneralBE DatosUsuario { get; set; }
    }

    public class MetodosPagoBE
    {
        public MetodosPagoBE()
        {
            Clave = string.Empty;
            Descripcion = string.Empty;
            DatosUsuario = new GeneralBE();
        }

        public string Clave { get; set; }
        public string Descripcion { get; set; }
        public GeneralBE DatosUsuario { get; set; }
    }

    public class UsoCFDIBE
    {
        public UsoCFDIBE()
        {
            Clave = string.Empty;
            Descripcion = string.Empty;
            DatosUsuario = new GeneralBE();
        }

        public string Clave { get; set; }
        public string Descripcion { get; set; }
        public GeneralBE DatosUsuario { get; set; }
    }

}
