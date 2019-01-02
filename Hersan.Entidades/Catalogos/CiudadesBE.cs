using Hersan.Entidades.Comun;

namespace Hersan.Entidades.Catalogos {
    public class CiudadesBE 
    {
        public CiudadesBE() {
            Estado = new EstadosBE();
            Id = 0;
            Nombre = string.Empty;
            Cabecera = string.Empty;
            DatosUsuario = new GeneralBE();
        }

        public EstadosBE Estado { get; set; }
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Cabecera { get; set; }
        public GeneralBE DatosUsuario { get; set; }

    }
}
