﻿using Hersan.Entidades.APT;
using Hersan.Entidades.Calidad;
using Hersan.Entidades.Catalogos;
using Hersan.Entidades.Ensamble;
using Hersan.Entidades.Inyeccion;
using System.Collections.Generic;
using System.Data;
using System.ServiceModel;

namespace Hersan.Ensamble.Contract
{
    [ServiceContract]
    public interface IHersan_Ensamble
    {
        #region Clientes
        [OperationContract]
        int ABC_Clientes_Guardar(DataSet Tablas, string Entidades, int IdUsuario);
        [OperationContract]
        int ABC_Clientes_Actualizar(DataSet Tablas, string Entidades, int IdUsuario, bool Estatus);
        [OperationContract]
        List<ClientesBE> ABC_Clientes_Buscar(ClientesBE Lista, string Entidades);
        [OperationContract]
        List<ClientesBE> ABC_Clientes_Obtener(int IdCliente);
        [OperationContract]
        List<ClientesBE> ABC_ClientesAgente_Combo(int IdAgente);
        [OperationContract]
        int ABC_ClientesAgente_Guardar(ClientesBE obj);
        #endregion

        #region Facturación
        [OperationContract]
        List<FormasPagoBE> ABC_FormaPago_Combo();
        [OperationContract]
        List<MetodosPagoBE> ABC_MetodoPago_Combo();
        [OperationContract]
        List<UsoCFDIBE> ABC_UsoCFDI_Combo();
        [OperationContract]
        List<RegimenSATBE> ABC_RegimenFiscal_Combo();
        #endregion

        #region Servicios
        [OperationContract]
        int ENS_Servicios_Guardar(ServiciosBE obj);
        [OperationContract]
        int ENS_Servicios_Actualizar(ServiciosBE obj);
        [OperationContract]
        List<ServiciosBE> ENS_Servicios_Obtener();
        [OperationContract]
        List<ServiciosBE> ENS_Servicios_Combo(int IdEntidad, string Moneda);
        [OperationContract]
        List<ServiciosBE> ENS_ServiciosCotizacion_Combo(string Moneda);
        #endregion

        #region Precios
        [OperationContract]
        int ENS_Precios_Guardar(int IdEmpresa, DataTable oData, string Moneda, int IdUsuario);
        [OperationContract]
        List<PreciosBE> ENS_Precios_Obtener(string Moneda);
        #endregion

        #region Productos
        [OperationContract]
        int ENS_ProductosFicha_Guardar(DataSet Tablas, byte[] Imagen, string Colores, string Reflejantes, string Accesorios, int IdUsuario);
        [OperationContract]
        int ENS_ProductosFicha_Actualizar(DataSet Tablas, byte[] Imagen, string Colores, string Reflejantes, string Accesorios, int IdUsuario, bool Estatus);
        [OperationContract]
        List<ProductoEnsambleBE> ENS_ProductosFicha_Obtener(ProductoEnsambleBE obj);
        [OperationContract]
        List<ProductoEnsambleBE> ENS_ProductosCotizacion_Combo(bool Nacional, string Moneda);
        [OperationContract]
        List<ColoresBE> ENS_CarcasasCotizacion_Combo(int IdFicha);
        [OperationContract]
        List<ReflejantesBE> ENS_ReflejanteCotizacion_Combo(int IdFicha);
        [OperationContract]
        string ENS_CodigoProducto_Obtener(int IdProducto, int IdCarcasa, string Reflejantes);
        #endregion

        #region Cotizaciones y Pedidos
        [OperationContract]
        int ENS_Cotizacion_Guardar(PedidosBE obj, DataTable oDetalle);
        [OperationContract]
        List<PedidosBE> ENS_Cotizacion_Buscar(int IdCliente, string Nombre, string Inicial, string Final);
        [OperationContract]
        List<PedidosBE> ENS_Cotizacion_Obtener(int IdCotizacion);
        [OperationContract]
        int ENS_Cotizacion_Actualizar(PedidosBE obj, DataTable oDetalle);
        [OperationContract]
        DataTable ENS_Cotizacion_Reporte(int IdCotiza);
        [OperationContract]
        DataTable ENS_Cotizacion_ReporteDetalle(int IdCotiza);
        [OperationContract]
        List<PedidosBE> ENS_Cotizacion_Consulta(int IdAgente, int IdCotiza, string Inicial, string Final);
        [OperationContract]
        List<PedidosBE> ENS_Pedido_Consulta(int IdAgente, int Pedido, string Inicial, string Final);
        #endregion

        #region Módulo Calidad

        #region Pantallas Calidad        
        [OperationContract]
        int PRO_Inyeccion_Guardar(InyeccionBE Obj, DataTable Detalle);
        [OperationContract]
        List<InyeccionDetalleBE> PRO_Inyeccion_Obtener(InyeccionBE Obj);
        [OperationContract]
        InyeccionBE PRO_Inyeccion_Consulta(int Lista);
        [OperationContract]
        int PRO_Temperaturas_Guardar(TemperaturasBE Obj);
        [OperationContract]
        TemperaturasBE PRO_Temperaturas_Obtener();
        [OperationContract]
        int PRO_TemperaturasMolde_Guardar(TempMoldesBE Obj);
        [OperationContract]
        TempMoldesBE PRO_TemperaturasMolde_Obtener();
        [OperationContract]
        int PRO_Parametros_Guardar(DataTable Tabla);
        [OperationContract]
        List<TemperaturasConsBE> PRO_Temperaturas_Consulta();
        [OperationContract]
        ParametrosInyeccion PRO_Parametros_Obtener();
        [OperationContract]
        List<ParametrosInyeccion> PRO_Parametros_Consulta();

        [OperationContract]
        int CAL_InspeccionInyeccion_Guarda(CalidadBE Obj, DataTable Detalle);
        [OperationContract]
        int CAL_InspeccionInyeccion_Actualiza(int IdInyeccion, DataTable Detalle);

        [OperationContract]
        int CAL_ReflejantesNorma_Guardar(DataTable Tabla, int IdUsuario);
        [OperationContract]
        int CAL_ReflejantesNorma_Actualizar(DataTable Tabla, int IdUsuario, bool Estatus);
        [OperationContract]
        List<NormaBE> CAL_ReflejantesNorma_Obtener();
        [OperationContract]
        List<InyeccionBE> CAL_InspeccionInyeccion_Analisis(CalidadBE Obj);
        [OperationContract]
        List<CalidadDetalleBE> CAL_InspeccionInyeccion_AnalisisDetalle(int Lista);

        [OperationContract]
        int PRO_Ensamble_Parametros_Guardar(EnsambleParametrosBE Obj, DataTable Detalle);
        [OperationContract]
        List<EnsambleParametrosBE> PRO_Ensamble_Parametros_Obtener(EnsambleParametrosBE Obj);
        [OperationContract]
        List<CalidadEnsambleBE> CAL_InspeccionEnsamble_Consultar(int Lista);

        [OperationContract]
        int CAL_InspeccionEnsamble_Guardar(CalidadEnsambleBE Obj, DataTable Detalle);
        [OperationContract]
        int CAL_InspeccionEnsamble_Actualizar(CalidadEnsambleBE Obj, DataTable Detalle);
        [OperationContract]
        List<CalidadEnsambleDetalleBE> CAL_InspeccionEnsamble_Obtener(int Lista);

        [OperationContract]
        List<CalidadEnsambleBE> CAL_InspeccionEnsamble_Analisis(CalidadEnsambleBE Obj);
        [OperationContract]
        List<CalidadEnsambleDetalleBE> CAL_InspeccionEnsamble_AnalisisDetalle(int Lista);

        [OperationContract]
        int CAL_ResguardoQA_Guardar(CalidadResguardoQA Obj, DataTable Detalle);
        [OperationContract]
        int CAL_ResguardoQA_Actualizar(CalidadResguardoQA Obj, DataTable Detalle);
        [OperationContract]
        List<CalidadResguardoQA> CAL_ResguardoQA_Obtener(int IdProducto, string Fecha);
        #endregion

        #region Gráficas
        [OperationContract]
        List<CalidadGraficasCavidades> CAL_AnalisisInyeccion_Histograma(int Lista);
        [OperationContract]
        List<CalidadGraficasCavidades> CAL_AnalisisInyeccion_GraficaControl(int Lista, string Fecha);
        [OperationContract]
        List<CalidadGraficasValores> CAL_AnalisisInyeccion_Histograma_Historico(string Inicial, string Final);
        [OperationContract]
        List<CalidadGraficaSeries> CAL_AnalisisInyeccion_GraficaSeries(string Inicial, string Final);

        [OperationContract]
        List<CalidadGraficasValores> CAL_InspeccionEnsamble_Histograma(int Lista);
        [OperationContract]
        List<CalidadGraficasValores> CAL_InspeccionEnsamble_HistogramaHistorico(CalidadResguardoQA Obj, string Inicial, string Final);

        [OperationContract]
        List<CalidadResguardoQADetalle> CAL_ResguardoQA_Grafica(CalidadResguardoQA Item, string Inicial, string Final);
        #endregion

        #endregion

        #region APT
        [OperationContract]
        List<AlmacenPTBE> APT_Almacenes_Obtener(int IdEmpresa);
        [OperationContract]
        int APT_Almacenes_Guardar(AlmacenPTBE obj);
        [OperationContract]
        int APT_Almacenes_Actualizar(AlmacenPTBE obj);
        [OperationContract]
        List<AlmacenPTBE> APT_Almacenes_Combo(int IdEmpresa);
        [OperationContract]
        List<UbicacionesBE> APT_Ubicacion_Obtener();
        [OperationContract]
        int APT_Ubicacion_Guardar(UbicacionesBE obj);
        [OperationContract]
        int APT_Ubicacion_Actualizar(UbicacionesBE obj);

        #endregion
    }
}
