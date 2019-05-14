using Hersan.Entidades.Catalogos;
using Hersan.Entidades.Comun;

namespace Hersan.Entidades.Ensamble
{
    public class ServiciosBE
    {

        public ServiciosBE()
        {
            Id = 0;
            Entidad = new EntidadesBE();
            Clave = string.Empty;
            Nombre = string.Empty;
            Precio = 0;
            DatosUsuario = new GeneralBE();
        }

        public int Id { get; set; }
        public EntidadesBE Entidad { get; set; }
        public string Clave { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public GeneralBE DatosUsuario { get; set; }
    }
}
