using Hersan.Entidades.Catalogos;
using Hersan.Entidades.Comun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hersan.Entidades.Ventas
{
    public class PedidosBE
    {

        public PedidosBE()
        {
            Id = 0;
            Cliente = new ClientesBE();
            Agente = 0;
            Cotizacion = true;
            Detalle = new List<PedidoDetalleBE>();
            DatosUsuario = new GeneralBE();
        }

        public int Id { get; set; }
        public ClientesBE Cliente { get; set; }
        public int Agente { get; set; }       
        public bool Cotizacion { get; set; }
        public List<PedidoDetalleBE> Detalle { get; set; }
        public GeneralBE DatosUsuario { get; set; }
    }

    public class PedidoDetalleBE
    {
        public PedidoDetalleBE()
        {
            Id = 0;
            Sel = false;
            Entidad = new EntidadesBE();
            Producto = new ProductosVialetaBE();
            Cantidad = 0;
            Precio = 0;
            DatosUsuario = new GeneralBE();
        }

        public int Id { get; set; }
        public bool Sel { get; set; }
        public EntidadesBE Entidad { get; set; }
        public ProductosVialetaBE Producto { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public GeneralBE DatosUsuario { get; set; }
    }
}
