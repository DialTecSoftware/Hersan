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
            Cav1 = 0;
            Cav2 = 0;
            Cav3 = 0;
            Cav4 = 0;
            Cav5 = 0;
            Cav6 = 0;
            Cav7 = 0;
            Cav8 = 0;
            DatosUsuario = new GeneralBE();
        }

        public int Id { get; set; }
        public ColoresBE Color { get; set; }
        public int Norma { get; set; }
        public decimal Cav1 { get; set; }
        public decimal Cav2 { get; set; }
        public decimal Cav3 { get; set; }
        public decimal Cav4 { get; set; }
        public decimal Cav5 { get; set; }
        public decimal Cav6 { get; set; }
        public decimal Cav7 { get; set; }
        public decimal Cav8 { get; set; }
        public GeneralBE DatosUsuario { get; set; }
    }
}
