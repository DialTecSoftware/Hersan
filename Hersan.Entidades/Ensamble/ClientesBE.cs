using Hersan.Entidades.Catalogos;
using Hersan.Entidades.Comun;
using System.Collections.Generic;

namespace Hersan.Entidades.Ensamble
{
    public class ClientesBE
    {
        public ClientesBE()
        {
            Sel = false;
            Id = 0;
            Nombre = string.Empty;
            RFC = string.Empty;
            IdFiscal = string.Empty;
            Direccion = string.Empty;
            Telefono = string.Empty;
            Colonia = string.Empty;
            CP = 0;
            Ciudad = string.Empty;
            Estado = string.Empty;
            Nacional = true;
            VIP = false;
            Correo1 = string.Empty;
            Correo2 = string.Empty;
            Agente = new AgentesBE();
            TipoCliente = new TiposClienteBE();
            Entidades = new List<ClientesEntidadesBE>();
            Condiciones = new ClientesCondicionesBE();
            Compras = new ClientesComprasBE();
            Pagos = new ClientesPagosBE();
            Recepcion = new List<ClientesRecepcionBE>();
            Referencias = new List<ClientesReferenciasBE>();
            DatosUsuario = new GeneralBE();
        }

        public bool Sel { get; set; }
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string RFC { get; set; }
        public string IdFiscal { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Colonia { get; set; }
        public int CP { get; set; }
        public string Ciudad { get; set; }
        public string Estado { get; set; }
        public bool Nacional { get; set; }
        public bool VIP { get; set; }
        public string Correo1 { get; set; }
        public string Correo2 { get; set; }
        public AgentesBE Agente { get; set; }
        public TiposClienteBE TipoCliente{ get; set; }
        public List<ClientesEntidadesBE> Entidades { get; set; }
        public ClientesCondicionesBE Condiciones { get; set; }
        public ClientesComprasBE Compras { get; set; }
        public ClientesPagosBE Pagos { get; set; }
        public List<ClientesRecepcionBE> Recepcion { get; set; }
        public List<ClientesReferenciasBE> Referencias { get; set; }
        public GeneralBE DatosUsuario { get; set; }
    }

    public class ClientesCondicionesBE
    {
        public int IdCliente { get; set; }
        public ClientesCondicionesBE() { }
        public int FormaPago { get; set; }
        public string MetodoPago{ get; set; }
        public string UsoCFDI { get; set; }
        public decimal MontoCredito{ get; set; }
        public int DiasCredito { get; set; }
        public decimal Descuento { get; set; }
        public GeneralBE DatosUsuario { get; set; }
    }

    public class ClientesComprasBE
    {
        public ClientesComprasBE()
        {
            IdCliente = 0;
            Nombre = string.Empty;
            Correo = string.Empty;
            Telefono = string.Empty;
            Extension = 0;
            DatosUsuario = new GeneralBE();
        }

        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public int Extension { get; set; }
        public GeneralBE DatosUsuario { get; set; }

    }

    public class ClientesPagosBE
    {
        public ClientesPagosBE()
        {
            IdCliente = 0;
            Nombre = string.Empty;
            Correo = string.Empty;
            Telefono = string.Empty;
            Extension = 0;
            DiasPago = string.Empty;
            Contrarecibo = string.Empty;
            Horario = string.Empty;
            Plazo = 0;
            DatosUsuario = new GeneralBE();
        }

        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public int Extension { get; set; }
        public string DiasPago { get; set; }
        public string Contrarecibo { get; set; }
        public string Horario { get; set; }
        public int Plazo { get; set; }
        public GeneralBE DatosUsuario { get; set; }

    }

    public class ClientesEntidadesBE
    {
        public ClientesEntidadesBE()
        {
            IdCliente = 0;
            Entidad = new EntidadesBE();
            DatosUsuario = new GeneralBE();
        }

        public int IdCliente { get; set; }
        public EntidadesBE Entidad { get; set; }
        public GeneralBE DatosUsuario { get; set; }
    }

    public class ClientesRecepcionBE
    {
        public ClientesRecepcionBE()
        {
            IdCliente = 0;
            Nombre = string.Empty;
            Puesto = string.Empty;
            DatosUsuario = new GeneralBE();
        }

        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string Puesto { get; set; }
        public GeneralBE DatosUsuario { get; set; }

    }

    public class ClientesReferenciasBE
    {
        public ClientesReferenciasBE()
        {
            IdCliente = 0;
            Nombre = string.Empty;
            Direccion = string.Empty;
            Telefono = string.Empty;
            Contacto = string.Empty;
            DatosUsuario = new GeneralBE();
        }

        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Contacto { get; set; }
        public GeneralBE DatosUsuario { get; set; }

    }
}
