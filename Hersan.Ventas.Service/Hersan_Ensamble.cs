using Hersan.Datos.Ventas;
using Hersan.Entidades.Catalogos;
using Hersan.Negocio.Ventas;
using Hersan.Ensamble.Contract;
using System.Collections.Generic;
using Hersan.Negocio.Ensamble;
using Hersan.Entidades.Ensamble;
using Hersan.Entidades.Inyeccion;
using Hersan.Negocio.Calidad;
using Hersan.Entidades.Calidad;
using System.Data;

namespace Hersan.Ensamble.Service
{
    public class Hersan_Ensamble : IHersan_Ensamble
    {
        #region Clientes
        public int ABC_Clientes_Guardar(DataSet Tablas, string Entidades, int IdUsuario)
        {
            return new ClientesBP().ABC_Clientes_Guardar(Tablas, Entidades, IdUsuario);
        }
        public int ABC_Clientes_Actualizar(DataSet Tablas, string Entidades, int IdUsuario, bool Estatus)
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
        public int ENS_Precios_Guardar(DataTable oData, string Moneda, int IdUsuario)
        {
            return new PreciosBP().ENS_Precios_Guardar(oData, Moneda, IdUsuario);
        }
        public List<PreciosBE> ENS_Precios_Obtener(string Moneda)
        {
            return new PreciosBP().ENS_Precios_Obtener(Moneda);
        }
        #endregion

        #region Productos
        public int ENS_ProductosFicha_Guardar(DataSet Tablas, byte[] Imagen, string Colores, string Reflejantes, string Accesorios, int IdUsuario)
        {
            return new ProductosBP().ENS_ProductosFicha_Guardar(Tablas, Imagen, Colores, Reflejantes, Accesorios, IdUsuario);
        }
        public int ENS_ProductosFicha_Actualizar(DataSet Tablas, byte[] Imagen, string Colores, string Reflejantes, string Accesorios, int IdUsuario, bool Estatus)
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
        public int ENS_Cotizacion_Guardar(PedidosBE obj, DataTable oDetalle)
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
        public int ENS_Cotizacion_Actualizar(PedidosBE obj, DataTable oDetalle)
        {
            return new PedidosBP().ENS_Cotizacion_Actualizar(obj, oDetalle);
        }
        public DataTable ENS_Cotizacion_Reporte(int IdCotiza)
        {
            return new PedidosBP().ENS_Cotizacion_Reporte(IdCotiza);
        }
        public DataTable ENS_Cotizacion_ReporteDetalle(int IdCotiza)
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

        #region Calidad
        public int PRO_Inyeccion_Guardar(InyeccionBE Obj, DataTable Detalle)
        {
            return new InyecccionBP().PRO_Inyeccion_Guardar(Obj, Detalle);
        }
        public List<InyeccionDetalleBE> PRO_Inyeccion_Obtener(InyeccionBE Obj)
        {
            return new InyecccionBP().PRO_Inyeccion_Obtener(Obj);
        }
        public InyeccionBE PRO_Inyeccion_Consulta(int Lista)
        {
            return new InyecccionBP().PRO_Inyeccion_Consulta(Lista);
        }
        public int PRO_Temperaturas_Guardar(TemperaturasBE Obj)
        {
            return new InyecccionBP().PRO_Temperaturas_Guardar(Obj);
        }
        public TemperaturasBE PRO_Temperaturas_Obtener()
        {
            return new InyecccionBP().PRO_Temperaturas_Obtener();
        }
        public int PRO_TemperaturasMolde_Guardar(TempMoldesBE Obj)
        {
            return new InyecccionBP().PRO_TemperaturasMolde_Guardar(Obj);
        }
        public TempMoldesBE PRO_TemperaturasMolde_Obtener()
        {
            return new InyecccionBP().PRO_TemperaturasMolde_Obtener();
        }
        public int PRO_Parametros_Guardar(DataTable Tabla)
        {
            return new InyecccionBP().PRO_Parametros_Guardar(Tabla);
        }
        public ParametrosInyeccion PRO_Parametros_Obtener()
        {
            return new InyecccionBP().PRO_Parametros_Obtener();
        }


        public int CAL_InspeccionInyeccion_Guarda(CalidadBE Obj, DataTable Detalle)
        {
            return new CalidadBP().CAL_InspeccionInyeccion_Guarda(Obj, Detalle);
        }
        public int CAL_InspeccionInyeccion_Actualiza(int IdInyeccion, DataTable Detalle)
        {
            return new CalidadBP().CAL_InspeccionInyeccion_Actualiza(IdInyeccion, Detalle);
        }

        public int CAL_ReflejantesNorma_Guardar(DataTable Tabla, int IdUsuario)
        {
            return new NormaBP().CAL_ReflejantesNorma_Guardar(Tabla, IdUsuario);
        }
        public int CAL_ReflejantesNorma_Actualizar(DataTable Tabla, int IdUsuario, bool Estatus)
        {
            return new NormaBP().CAL_ReflejantesNorma_Actualizar(Tabla, IdUsuario, Estatus);
        }
        public List<NormaBE> CAL_ReflejantesNorma_Obtener()
        {
            return new NormaBP().CAL_ReflejantesNorma_Obtener();
        }
        public List<InyeccionBE> CAL_InspeccionInyeccion_Analisis(CalidadBE Obj)
        {
            return new CalidadBP().CAL_InspeccionInyeccion_Analisis(Obj);
        }
        public List<CalidadDetalleBE> CAL_InspeccionInyeccion_AnalisisDetalle(int Lista)
        {
            return new CalidadBP().CAL_InspeccionInyeccion_AnalisisDetalle(Lista);
        }

        public int PRO_Ensamble_Parametros_Guardar(EnsambleParametrosBE Obj, DataTable Detalle)
        {
            return new EnsambleBP().PRO_Ensamble_Parametros_Guardar(Obj, Detalle);
        }
        public List<EnsambleParametrosBE> PRO_Ensamble_Parametros_Obtener(EnsambleParametrosBE Obj)
        {
            return new EnsambleBP().PRO_Ensamble_Parametros_Obtener(Obj);
        }
        public List<CalidadEnsambleBE> CAL_InspeccionEnsamble_Consultar(int Lista)
        {
            return new EnsambleBP().CAL_InspeccionEnsamble_Consultar(Lista);
        }

        public int CAL_InspeccionEnsamble_Guardar(CalidadEnsambleBE Obj, DataTable Detalle)
        {
            return new EnsambleBP().CAL_InspeccionEnsamble_Guardar(Obj, Detalle);
        }
        public int CAL_InspeccionEnsamble_Actualizar(CalidadEnsambleBE Obj, DataTable Detalle)
        {
            return new EnsambleBP().CAL_InspeccionEnsamble_Actualizar(Obj, Detalle);
        }
        public List<CalidadEnsambleDetalleBE> CAL_InspeccionEnsamble_Obtener(int Lista)
        {
            return new EnsambleBP().CAL_InspeccionEnsamble_Obtener(Lista);
        }

        public List<CalidadEnsambleBE> CAL_InspeccionEnsamble_Analisis(CalidadEnsambleBE Obj)
        {
            return new CalidadBP().CAL_InspeccionEnsamble_Analisis(Obj);
        }
        public List<CalidadEnsambleDetalleBE> CAL_InspeccionEnsamble_AnalisisDetalle(int Lista)
        {
            return new CalidadBP().CAL_InspeccionEnsamble_AnalisisDetalle(Lista);
        }

        public int CAL_ResguardoQA_Guardar(CalidadResguardoQA Obj, DataTable Detalle)
        {
            return new CalidadBP().CAL_ResguardoQA_Guardar(Obj, Detalle);
        }
        public int CAL_ResguardoQA_Actualizar(CalidadResguardoQA Obj, DataTable Detalle)
        {
            return new CalidadBP().CAL_ResguardoQA_Actualizar(Obj, Detalle);
        }
        public List<CalidadResguardoQA> CAL_ResguardoQA_Obtener(int IdProducto, string Fecha)
        {
            return new CalidadBP().CAL_ResguardoQA_Obtener(IdProducto, Fecha);
        }

        public List<CalidadGraficasCavidades> CAL_AnalisisInyeccion_Histograma(int Lista)
        {
            return new CalidadBP().CAL_AnalisisInyeccion_Histograma(Lista);
        }
        public List<CalidadGraficasCavidades> CAL_AnalisisInyeccion_GraficaControl(int Lista, string Fecha)
        {
            return new CalidadBP().CAL_AnalisisInyeccion_GraficaControl(Lista, Fecha);
        }
        public List<CalidadGraficasValores> CAL_AnalisisInyeccion_Histograma_Historico(string Inicial, string Final)
        {
            return new CalidadBP().CAL_AnalisisInyeccion_Histograma_Historico(Inicial, Final);
        }
        public List<CalidadGraficaSeries> CAL_AnalisisInyeccion_GraficaSeries(string Inicial, string Final)
        {
            return new CalidadBP().CAL_AnalisisInyeccion_GraficaSeries(Inicial, Final);
        }

        public List<CalidadResguardoQADetalle> CAL_ResguardoQA_Grafica(CalidadResguardoQA Item, string Inicial, string Final)
        {
            return new CalidadBP().CAL_ResguardoQA_Grafica(Item, Inicial, Final);
        }
        #endregion
    }
}
    