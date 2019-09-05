using Hersan.Entidades.Catalogos;
using Hersan.Entidades.Comun;
using Hersan.Entidades.Ensamble;

namespace Hersan.Entidades.APT {
    public class UbicacionesBE 
    {
        public UbicacionesBE()
        {
            Id = 0;
            Almacen = new AlmacenPTBE();
            Producto = new ProductoEnsambleBE();
            Carcasa = new ColoresBE();
            Reflejante = new ReflejantesBE();
            Rack = string.Empty;
            Fila = 0;
            Columna = 0;
            Minimo = 0;
            Maximo = 0;
            DatosUsuario = new GeneralBE();
        }

        public int Id { get; set; }
        public AlmacenPTBE Almacen { get; set; }
        public ProductoEnsambleBE Producto { get; set; }
        public ColoresBE Carcasa { get; set; }
        public ReflejantesBE Reflejante { get; set; }
        public string Rack { get; set; }
        public int Fila { get; set; }
        public int Columna { get; set; }
        public decimal Minimo { get; set; }
        public decimal Maximo { get; set; }
        public GeneralBE DatosUsuario { get; set; }
    }
}
