using Hersan.Entidades.Comun;

namespace Hersan.Entidades.Catalogos {
    public class ColoniasBE 
    {
        public ColoniasBE() {
            Estado = new EstadosBE();
            Ciudad = new CiudadesBE();
            Id = 0;
            Nombre = string.Empty;
            CP = 0;
            DatosUsuario = new GeneralBE();
        }

        public EstadosBE Estado { get; set; }
        public CiudadesBE Ciudad { get; set; }
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int CP { get; set; }
        public GeneralBE DatosUsuario { get; set; }
    }
}
