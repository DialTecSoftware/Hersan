using Hersan.Entidades.Comun;

namespace Hersan.Entidades.Catalogos {
    public class EstadosBE 
    {
        public EstadosBE() {
            Pais = new PaisesBE();
            Id = 0;
            Nombre = string.Empty;
            Abrev = string.Empty;
            DatosUsuario = new GeneralBE();
        }

        public PaisesBE Pais { get; set; }
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Abrev { get; set; }
        public GeneralBE DatosUsuario { get; set; }
    }
}
