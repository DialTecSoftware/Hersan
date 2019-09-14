using Hersan.Entidades.Catalogos;
using Hersan.Entidades.Comun;
using System;
using System.Collections.Generic;

namespace Hersan.Entidades.APT {
    public class OrdenCompraBE 
    {
        public OrdenCompraBE()
        {
            Id = 0;
            Almacen = new AlmacenPTBE();
            Proveedor = new ProveedorBE();
            FEntrega = DateTime.Today;
            Enviada = false;
            Detalle = new List<OrdenCompraDetalleBE>();
            DatosUsuario = new GeneralBE();
        }
        public int Id { get; set; }
        public AlmacenPTBE Almacen { get; set; }
        public ProveedorBE Proveedor { get; set; }
        public DateTime FEntrega { get; set; }
        public bool Enviada { get; set; }
        public GeneralBE DatosUsuario { get; set; }
        public List<OrdenCompraDetalleBE> Detalle { get; set; }
    }

    public class OrdenCompraDetalleBE 
    {
        public OrdenCompraDetalleBE()
        {
            Sel = false;
            Id = 0;
            Producto = new TipoProductoBE();
            Carcasa = new ColoresBE();
            Sugerido = 0;
            Solicitado = 0;
            Precio = 0;
            Comentarios = string.Empty;
            Cancelada = false;
            Reflejante = new List<OrdenCompraComponentesBE>();
            DatosUsuario = new GeneralBE();
        }

        public bool Sel { get; set; }
        public int Id { get; set; }
        public TipoProductoBE Producto { get; set; }
        public ColoresBE Carcasa { get; set; }
        public int Sugerido { get; set; }
        public int Solicitado { get; set; }
        public decimal Precio { get; set; }
        public string Comentarios { get; set; }
        public bool Cancelada { get; set; }
        public GeneralBE DatosUsuario { get; set; }
        public List<OrdenCompraComponentesBE> Reflejante { get; set; }

    }

    public class OrdenCompraComponentesBE 
    {
        public OrdenCompraComponentesBE()
        {
            Id = 0;
            Reflejante = new ReflejantesBE();
            DatosUsuario = new GeneralBE();
        }

        public int Id { get; set; }
        public ReflejantesBE Reflejante { get; set; }
        public GeneralBE DatosUsuario { get; set; }

    }
}
