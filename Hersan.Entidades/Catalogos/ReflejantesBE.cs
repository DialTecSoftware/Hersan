using Hersan.Entidades.Comun;
using System.Collections.Generic;

namespace Hersan.Entidades.Catalogos
{
    public class ReflejantesBE
    {
        public ReflejantesBE()
        {
            Id = 0;
            Sel = false;
            Tipo = string.Empty;
            Clave = string.Empty;
            Nombre = string.Empty;
            Color = new ColoresBE();
            DatosUsuario = new GeneralBE();
        }

        public int Id { get; set; }
        public bool Sel { get; set; }
        public string Tipo { get; set; }
        public string Clave { get; set; }
        public string Nombre { get; set; }
        public ColoresBE Color { get; set; }
        public GeneralBE DatosUsuario { get; set; }
    }
}
