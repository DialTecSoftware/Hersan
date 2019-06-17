using Hersan.Datos.Ventas;
using Hersan.Entidades.Catalogos;
using Hersan.Negocio.Ventas;
using Hersan.Ensamble.Contract;
using System.Collections.Generic;
using Hersan.Negocio.Ensamble;
using Hersan.Entidades.Ensamble;


namespace Hersan.Ensamble.Service
{
    public class Hersan_Ensamble : IHersan_Ensamble
    {
        #region Clientes
        public int ABC_Clientes_Guardar(System.Data.DataSet Tablas, string Entidades, int IdUsuario)
        {
            return new ClientesBP().ABC_Clientes_Guardar(Tablas, Entidades, IdUsuario);
        }
        public int ABC_Clientes_Actualizar(System.Data.DataSet Tablas, string Entidades, int IdUsuario, bool Estatus)
        {
            return new ClientesBP().ABC_Clientes_Actualizar(Tablas, Entidades, IdUsuario, Estatus);
        }
        public List<ClientesBE> ABC_Clientes_Buscar(ClientesBE Lista, string Entidades)
        {
            return new ClientesBP().ABC_Clientes_Buscar(Lista, Entidades);
        }
        public List<ClientesBE> ABC_Clientes_Obtener(int IdCliente)
        {
            return new ClientesBP().ABC_Clientes_Obtener(IdCliente);
        }
        public List<ClientesBE> ABC_ClientesAgente_Combo(int IdAgente)
        {
            return new ClientesBP().ABC_ClientesAgente_Combo(IdAgente);
        }
        public int ABC_ClientesAgente_Guardar(ClientesBE obj)
        {
            return new ClientesBP().ABC_ClientesAgente_Guardar(obj);
        }
        #endregion

        #region Facturación
        public List<FormasPagoBE> ABC_FormaPago_Combo()
        {
            return new FacturacionDA().ABC_FormaPago_Combo();
        }
        public List<MetodosPagoBE> ABC_MetodoPago_Combo()
        {
            return new FacturacionDA().ABC_MetodoPago_Combo();
        }
        public List<UsoCFDIBE> ABC_UsoCFDI_Combo()
        {
            return new FacturacionDA().ABC_UsoCFDI_Combo();
        }
        #endregion

        #region Servicios
        public int ENS_Servicios_Guardar(ServiciosBE obj)
        {
            return new ServiciosBP().ENS_Servicios_Guardar(obj);
        }
        public int ENS_Servicios_Actualizar(ServiciosBE obj)
        {
            return new ServiciosBP().ENS_Servicios_Actualizar(obj);
        }
        public List<ServiciosBE> ENS_Servicios_Obtener()
        {
            return new ServiciosBP().ENS_Servicios_Obtener();
        }
        public List<ServiciosBE> ENS_Servicios_Combo(int IdEntidad, string Moneda)
        {
            return new ServiciosBP().ENS_Servicios_Combo(IdEntidad, Moneda);
        }
        public List<ServiciosBE> ENS_ServiciosCotizacion_Combo(string Moneda)
        {
            return new ServiciosBP().ENS_ServiciosCotizacion_Combo(Moneda);
        }
        #endregion

        #region Precios
        public int ENS_Precios_Guardar(System.Data.DataTable oData, string Moneda, int IdUsuario)
        {
            return new PreciosBP().ENS_Precios_Guardar(oData, Moneda, IdUsuario);
        }
        public List<PreciosBE> ENS_Precios_Obtener(string Moneda)
        {
            return new PreciosBP().ENS_Precios_Obtener(Moneda);
        }
        #endregion

        #region Productos
        public int ENS_ProductosFicha_Guardar(System.Data.DataSet Tablas, byte[] Imagen, string Colores, string Reflejantes, string Accesorios, int IdUsuario)
        {
            return new ProductosBP().ENS_ProductosFicha_Guardar(Tablas, Imagen, Colores, Reflejantes, Accesorios, IdUsuario);
        }
        public int ENS_ProductosFicha_Actualizar(System.Data.DataSet Tablas, byte[] Imagen, string Colores, string Reflejantes, string Accesorios, int IdUsuario, bool Estatus)
        {
            return new ProductosBP().ENS_ProductosFicha_Actualizar(Tablas, Imagen, Colores, Reflejantes, Accesorios, IdUsuario, Estatus);
        }
        public List<ProductoEnsambleBE> ENS_ProductosFicha_Obtener(ProductoEnsambleBE obj)
        {
            return new ProductosBP().ENS_ProductosFicha_Obtener(obj);
        }
        public List<ProductoEnsambleBE> ENS_ProductosCotizacion_Combo(bool Nacional, string Moneda)
        {
            return new ProductosBP().ENS_ProductosCotizacion_Combo(Nacional, Moneda);
        }
        public List<ColoresBE> ENS_CarcasasCotizacion_Combo(int IdFicha)
        {
            return new ProductosBP().ENS_CarcasasCotizacion_Combo(IdFicha);
        }
        public List<ReflejantesBE> ENS_ReflejanteCotizacion_Combo(int IdFicha)
        {
            return new ProductosBP().ENS_ReflejanteCotizacion_Combo(IdFicha);
        }
        #endregion

        #region Cotizaciones y Pedidos
        public int ENS_Cotizacion_Guardar(PedidosBE obj, System.Data.DataTable oDetalle)
        {
            return new PedidosBP().ENS_Cotizacion_Guardar(obj, oDetalle);
        }
        public List<PedidosBE> ENS_Cotizacion_Buscar(int IdCliente, string Nombre, string Inicial, string Final)
        {
            return new PedidosBP().ENS_Cotizacion_Buscar(IdCliente, Nombre, Inicial, Final);
        }
        public List<PedidosBE> ENS_Cotizacion_Obtener(int IdCotizacion)
        {
            return new PedidosBP().ENS_Cotizacion_Obtener(IdCotizacion);
        }
        public int ENS_Cotizacion_Actualizar(PedidosBE obj, System.Data.DataTable oDetalle)
        {
            return new PedidosBP().ENS_Cotizacion_Actualizar(obj, oDetalle);
        }
        public System.Data.DataTable ENS_Cotizacion_Reporte(int IdCotiza)
        {
            return new PedidosBP().ENS_Cotizacion_Reporte(IdCotiza);
        }
        public System.Data.DataTable ENS_Cotizacion_ReporteDetalle(int IdCotiza)
        {
            return new PedidosBP().ENS_Cotizacion_ReporteDetalle(IdCotiza);
        }
        public List<PedidosBE> ENS_Cotizacion_Consulta(int IdAgente, int IdCotiza, string Inicial, string Final)
        {
            return new PedidosBP().ENS_Cotizacion_Consulta(IdAgente, IdCotiza, Inicial, Final);
        }
        public List<PedidosBE> ENS_Pedido_Consulta(int IdAgente, int Pedido, string Inicial, string Final)
        {
            return new PedidosBP().ENS_Pedido_Consulta(IdAgente, Pedido, Inicial, Final);
        }
        #endregion
    }
}
