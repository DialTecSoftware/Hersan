using Hersan.Entidades.Comun;

namespace Hersan.Entidades.CapitalHumano
{
    public class FuncionesBE
    {
        public FuncionesBE()
        {
            Id = 0;
            Nombre = string.Empty;
            Continua = false;
            Periodica = false;
            DatosUsuario = new GeneralBE();
        }
        public int Id { get; set; }
        public string Nombre { get; set; }
        public bool Continua { get; set; }
        public bool Periodica { get; set; }
        public GeneralBE DatosUsuario { get; set; }
    }
}
