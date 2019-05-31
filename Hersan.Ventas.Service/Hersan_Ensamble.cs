﻿using Hersan.Datos.Ventas;
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
        public List<ServiciosBE> ENS_Servicios_Combo(int IdEntidad)
        {
            return new ServiciosBP().ENS_Servicios_Combo(IdEntidad);
        }
        public List<ServiciosBE> ENS_ServiciosCotizacion_Combo()
        {
            return new ServiciosBP().ENS_ServiciosCotizacion_Combo();
        }
        #endregion

        #region Precios
        public int ENS_Precios_Guardar(System.Data.DataTable oData, int IdUsuario)
        {
            return new PreciosBP().ENS_Precios_Guardar(oData, IdUsuario);
        }
        public List<PreciosBE> ENS_Precios_Obtener()
        {
            return new PreciosBP().ENS_Precios_Obtener();
        }
        #endregion

        #region Productos
        public int ENS_ProductosFicha_Guardar(System.Data.DataSet Tablas, string Colores, string Reflejantes, string Accesorios, int IdUsuario)
        {
            return new ProductosBP().ENS_ProductosFicha_Guardar(Tablas, Colores, Reflejantes, Accesorios, IdUsuario);
        }
        public int ENS_ProductosFicha_Actualizar(System.Data.DataSet Tablas, string Colores, string Reflejantes, string Accesorios, int IdUsuario, bool Estatus)
        {
            return new ProductosBP().ENS_ProductosFicha_Actualizar(Tablas, Colores, Reflejantes, Accesorios, IdUsuario, Estatus);
        }
        public List<ProductoEnsambleBE> ENS_ProductosFicha_Obtener(ProductoEnsambleBE obj)
        {
            return new ProductosBP().ENS_ProductosFicha_Obtener(obj);
        }
        public List<ProductoEnsambleBE> ENS_ProductosCotizacion_Combo()
        {
            return new ProductosBP().ENS_ProductosCotizacion_Combo();
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
        public int ENS_Cotizacion_Guardar(int IdCliente, System.Data.DataTable oDetalle, int IdUsuario)
        {
            return new PedidosBP().ENS_Cotizacion_Guardar(IdCliente, oDetalle, IdUsuario);
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
        #endregion
    }
}