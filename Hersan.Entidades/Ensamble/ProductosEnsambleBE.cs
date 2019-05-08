using Hersan.Entidades.Catalogos;
using Hersan.Entidades.Comun;
using Hersan.Entidades.Ensamble;
using System.Collections.Generic;

namespace Hersan.Entidades.Ensamble
{
    public class ProductoEnsambleBE
    {
        public ProductoEnsambleBE()
        {
            Id = 0;
            Entidad = new EntidadesBE();
            Familia = new FamiliasBE();
            Producto = new TipoProductoBE();
            Reflejantes = 0;
            CantAccesorios = 0;
            Detalle = new List<ProductosCombinacion>();
            Dimensiones = new DimensionesBE();
            Accesorios = new List<AccesoriosBE>();
            Precio = new PreciosBE();
            DatosUsuario = new GeneralBE();
        }

        public int Id { get; set; }
        public EntidadesBE Entidad { get; set; }
        public FamiliasBE Familia { get; set; }
        public TipoProductoBE Producto { get; set; }
        public int Reflejantes { get; set; }
        public int CantAccesorios { get; set; }
        public List<ProductosCombinacion> Detalle { get; set; }
        public DimensionesBE Dimensiones { get; set; }
        public List<AccesoriosBE> Accesorios { get; set; }
        public PreciosBE Precio { get; set; }
        public GeneralBE DatosUsuario { get; set; }
    }

    public class ProductosCombinacion
    {
        public ProductosCombinacion()
        {
            Sel = false;
            Id = 0;
            Tipo = string.Empty;
            Concepto = string.Empty;
        }

        public bool Sel { get; set; }
        public int Id { get; set; }
        public string Tipo { get; set; }
        public string Concepto { get; set; }
    }


    
}
