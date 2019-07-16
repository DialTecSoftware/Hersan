using Hersan.Entidades.Comun;

namespace Hersan.Entidades.Catalogos
{
    public class RegimenSATBE
    {
        public RegimenSATBE()
        {
            Id = 0;
            Regimen = string.Empty;
            Fisica = false;
            Moral = false;
            DatosUsuario = new GeneralBE();
        }

        public int Id { get; set; }
        public string Regimen { get; set; }
        public bool Fisica { get; set; }
        public bool Moral { get; set; }
        public GeneralBE DatosUsuario { get; set; }
    }
}
