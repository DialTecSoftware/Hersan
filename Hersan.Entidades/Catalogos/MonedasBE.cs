using Hersan.Entidades.Comun;


namespace Hersan.Entidades.Catalogos
{
    public class MonedasBE
    {
        public MonedasBE()
        {
            Id = 0;
            Moneda = string.Empty;
            Abrev = string.Empty;
            TipoCambio = 0;
            DatosUsuario = new GeneralBE();
        }

        public int Id { get; set; }
        public string Moneda { get; set; }
        public string Abrev { get; set; }
        public decimal TipoCambio { get; set; }
        public GeneralBE DatosUsuario { get; set; }
    }
}
