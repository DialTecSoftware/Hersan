using Hersan.Entidades.Catalogos;
using Hersan.Entidades.Comun;

namespace Hersan.Entidades.Calidad
{
    public class NormaBE
    {
        public NormaBE()
        {
            Id = 0;
            Color = new ColoresBE();
            Norma = 0;
            Limite = 0;
            DatosUsuario = new GeneralBE();
        }

        public int Id { get; set; }
        public ColoresBE Color { get; set; }
        public int Norma { get; set; }
        public decimal Limite { get; set; }
        public GeneralBE DatosUsuario { get; set; }
    }
}
