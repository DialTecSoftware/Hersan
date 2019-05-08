using Hersan.Entidades.Catalogos;
using System.Collections.Generic;

namespace Hersan.Entidades.Ensamble
{
    public class DimensionesBE
    {
        public DimensionesBE()
        {
            Alto = 0;
            Largo = 0;
            Ancho = 0;
            Cirunferencia = 0;
            Diametro = 0;
            Empaque = 0;
            Peso = 0;
            RutaImagen = string.Empty;
        }
        
        public decimal Alto { get; set; }
        public decimal Largo { get; set; }
        public decimal Ancho { get; set; }
        public decimal Cirunferencia { get; set; }
        public decimal Diametro { get; set; }
        public int Empaque { get; set; }
        public decimal Peso { get; set; }
        public string RutaImagen { get; set; }
        public byte[] Imagen { get; set; }
    }
}
