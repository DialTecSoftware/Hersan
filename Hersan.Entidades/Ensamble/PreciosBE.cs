using Hersan.Entidades.Catalogos;
using Hersan.Entidades.Comun;

namespace Hersan.Entidades.Ensamble
{
    public class PreciosBE
    {
        public PreciosBE()
        {
            Id = 0;
            Codigo = string.Empty;
            Producto = new TipoProductoBE();
            Precio = 0;
            CantidadVol = 0;
            Volumen = 0;
            CantidadMay = 0;
            Mayoreo = 0;
            AAA = 0;
            ExWorks = 0;
            DatosUsuario = new GeneralBE();
        }

        public int Id { get; set; }
        public string Codigo { get; set; }
        public TipoProductoBE Producto { get; set; }
        public decimal Precio { get; set; }
        public int CantidadVol { get; set; }
        public decimal Volumen { get; set; }
        public int CantidadMay { get; set; }
        public decimal Mayoreo{ get; set; }
        public decimal AAA { get; set; }
        public decimal ExWorks { get; set; }
        public GeneralBE DatosUsuario { get; set; }
    }
}
