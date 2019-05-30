using Hersan.Entidades.Catalogos;
using Hersan.Entidades.Comun;
using System.Collections.Generic;

namespace Hersan.Entidades.Ensamble
{
    public class PedidosBE
    {

        public PedidosBE()
        {
            Id = 0;
            Cliente = new ClientesBE();
            Agente = new AgentesBE();
            Semaforo = 0;
            Condiciones = new CondicionesExpBE();
            Pedido = false;
            NoPedido = 0;
            Proyecto = string.Empty;
            Monto = 0;
            Detalle = new List<PedidoDetalleBE>();
            DatosUsuario = new GeneralBE();
        }

        public int Id { get; set; }
        public ClientesBE Cliente { get; set; }
        public AgentesBE Agente { get; set; }
        public int Semaforo { get; set; }
        public CondicionesExpBE Condiciones { get; set; }
        public bool Pedido { get; set; }
        public int NoPedido { get; set; }
        public string Proyecto { get; set; }
        public decimal Monto { get; set; }
        public List<PedidoDetalleBE> Detalle { get; set; }
        public GeneralBE DatosUsuario { get; set; }
    }

    public class PedidoDetalleBE
    {
        public PedidoDetalleBE()
        {
            Id = 0;
            Sel = false;
            Tipo = string.Empty;
            Entidad = new EntidadesBE();
            Producto = new TipoProductoBE();
            Reflejantes = new List<ReflejantesBE>();
            Accesorios = new AccesoriosBE();
            Servicio = new ServiciosBE();
            Reflec = string.Empty;
            Cantidad = 0;
            Precio = 0;
            Total = 0;
            DatosUsuario = new GeneralBE();
        }

        public int Id { get; set; }
        public bool Sel { get; set; }
        public string Tipo { get; set; }
        public EntidadesBE Entidad { get; set; }
        public TipoProductoBE Producto { get; set; }
        public List<ReflejantesBE> Reflejantes { get; set; }
        public AccesoriosBE Accesorios { get; set; }
        public ServiciosBE Servicio { get; set; }
        public string Reflec { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Total { get; set; }
        public GeneralBE DatosUsuario { get; set; }
    }
}
