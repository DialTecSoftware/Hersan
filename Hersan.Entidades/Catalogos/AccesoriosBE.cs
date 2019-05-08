using Hersan.Entidades.Comun;

namespace Hersan.Entidades.Catalogos
{
    public class AccesoriosBE
    {
        public AccesoriosBE()
        {
            Id = 0;
            Clave = string.Empty;
            Nombre = string.Empty;
            DatosUsuario = new GeneralBE();
        }

        public int Id { get; set; }
        public string Clave { get; set; }
        public string Nombre { get; set; }
        public GeneralBE DatosUsuario { get; set; }
    }
}
