﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Hersan.UI.Calidad.WCF_Ensamble {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="WCF_Ensamble.IHersan_Ensamble")]
    public interface IHersan_Ensamble {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Ensamble/ABC_Clientes_Guardar", ReplyAction="http://tempuri.org/IHersan_Ensamble/ABC_Clientes_GuardarResponse")]
        int ABC_Clientes_Guardar(System.Data.DataSet Tablas, string Entidades, int IdUsuario);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Ensamble/ABC_Clientes_Actualizar", ReplyAction="http://tempuri.org/IHersan_Ensamble/ABC_Clientes_ActualizarResponse")]
        int ABC_Clientes_Actualizar(System.Data.DataSet Tablas, string Entidades, int IdUsuario, bool Estatus);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Ensamble/ABC_Clientes_Buscar", ReplyAction="http://tempuri.org/IHersan_Ensamble/ABC_Clientes_BuscarResponse")]
        System.Collections.Generic.List<Hersan.Entidades.Ensamble.ClientesBE> ABC_Clientes_Buscar(Hersan.Entidades.Ensamble.ClientesBE Lista, string Entidades);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Ensamble/ABC_Clientes_Obtener", ReplyAction="http://tempuri.org/IHersan_Ensamble/ABC_Clientes_ObtenerResponse")]
        System.Collections.Generic.List<Hersan.Entidades.Ensamble.ClientesBE> ABC_Clientes_Obtener(int IdCliente);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Ensamble/ABC_ClientesAgente_Combo", ReplyAction="http://tempuri.org/IHersan_Ensamble/ABC_ClientesAgente_ComboResponse")]
        System.Collections.Generic.List<Hersan.Entidades.Ensamble.ClientesBE> ABC_ClientesAgente_Combo(int IdAgente);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Ensamble/ABC_ClientesAgente_Guardar", ReplyAction="http://tempuri.org/IHersan_Ensamble/ABC_ClientesAgente_GuardarResponse")]
        int ABC_ClientesAgente_Guardar(Hersan.Entidades.Ensamble.ClientesBE obj);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Ensamble/ABC_FormaPago_Combo", ReplyAction="http://tempuri.org/IHersan_Ensamble/ABC_FormaPago_ComboResponse")]
        System.Collections.Generic.List<Hersan.Entidades.Catalogos.FormasPagoBE> ABC_FormaPago_Combo();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Ensamble/ABC_MetodoPago_Combo", ReplyAction="http://tempuri.org/IHersan_Ensamble/ABC_MetodoPago_ComboResponse")]
        System.Collections.Generic.List<Hersan.Entidades.Catalogos.MetodosPagoBE> ABC_MetodoPago_Combo();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Ensamble/ABC_UsoCFDI_Combo", ReplyAction="http://tempuri.org/IHersan_Ensamble/ABC_UsoCFDI_ComboResponse")]
        System.Collections.Generic.List<Hersan.Entidades.Catalogos.UsoCFDIBE> ABC_UsoCFDI_Combo();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Ensamble/ENS_Servicios_Guardar", ReplyAction="http://tempuri.org/IHersan_Ensamble/ENS_Servicios_GuardarResponse")]
        int ENS_Servicios_Guardar(Hersan.Entidades.Ensamble.ServiciosBE obj);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Ensamble/ENS_Servicios_Actualizar", ReplyAction="http://tempuri.org/IHersan_Ensamble/ENS_Servicios_ActualizarResponse")]
        int ENS_Servicios_Actualizar(Hersan.Entidades.Ensamble.ServiciosBE obj);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Ensamble/ENS_Servicios_Obtener", ReplyAction="http://tempuri.org/IHersan_Ensamble/ENS_Servicios_ObtenerResponse")]
        System.Collections.Generic.List<Hersan.Entidades.Ensamble.ServiciosBE> ENS_Servicios_Obtener();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Ensamble/ENS_Servicios_Combo", ReplyAction="http://tempuri.org/IHersan_Ensamble/ENS_Servicios_ComboResponse")]
        System.Collections.Generic.List<Hersan.Entidades.Ensamble.ServiciosBE> ENS_Servicios_Combo(int IdEntidad, string Moneda);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Ensamble/ENS_ServiciosCotizacion_Combo", ReplyAction="http://tempuri.org/IHersan_Ensamble/ENS_ServiciosCotizacion_ComboResponse")]
        System.Collections.Generic.List<Hersan.Entidades.Ensamble.ServiciosBE> ENS_ServiciosCotizacion_Combo(string Moneda);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Ensamble/ENS_Precios_Guardar", ReplyAction="http://tempuri.org/IHersan_Ensamble/ENS_Precios_GuardarResponse")]
        int ENS_Precios_Guardar(System.Data.DataTable oData, string Moneda, int IdUsuario);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Ensamble/ENS_Precios_Obtener", ReplyAction="http://tempuri.org/IHersan_Ensamble/ENS_Precios_ObtenerResponse")]
        System.Collections.Generic.List<Hersan.Entidades.Ensamble.PreciosBE> ENS_Precios_Obtener(string Moneda);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Ensamble/ENS_ProductosFicha_Guardar", ReplyAction="http://tempuri.org/IHersan_Ensamble/ENS_ProductosFicha_GuardarResponse")]
        int ENS_ProductosFicha_Guardar(System.Data.DataSet Tablas, byte[] Imagen, string Colores, string Reflejantes, string Accesorios, int IdUsuario);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Ensamble/ENS_ProductosFicha_Actualizar", ReplyAction="http://tempuri.org/IHersan_Ensamble/ENS_ProductosFicha_ActualizarResponse")]
        int ENS_ProductosFicha_Actualizar(System.Data.DataSet Tablas, byte[] Imagen, string Colores, string Reflejantes, string Accesorios, int IdUsuario, bool Estatus);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Ensamble/ENS_ProductosFicha_Obtener", ReplyAction="http://tempuri.org/IHersan_Ensamble/ENS_ProductosFicha_ObtenerResponse")]
        System.Collections.Generic.List<Hersan.Entidades.Ensamble.ProductoEnsambleBE> ENS_ProductosFicha_Obtener(Hersan.Entidades.Ensamble.ProductoEnsambleBE obj);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Ensamble/ENS_ProductosCotizacion_Combo", ReplyAction="http://tempuri.org/IHersan_Ensamble/ENS_ProductosCotizacion_ComboResponse")]
        System.Collections.Generic.List<Hersan.Entidades.Ensamble.ProductoEnsambleBE> ENS_ProductosCotizacion_Combo(bool Nacional, string Moneda);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Ensamble/ENS_CarcasasCotizacion_Combo", ReplyAction="http://tempuri.org/IHersan_Ensamble/ENS_CarcasasCotizacion_ComboResponse")]
        System.Collections.Generic.List<Hersan.Entidades.Catalogos.ColoresBE> ENS_CarcasasCotizacion_Combo(int IdFicha);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Ensamble/ENS_ReflejanteCotizacion_Combo", ReplyAction="http://tempuri.org/IHersan_Ensamble/ENS_ReflejanteCotizacion_ComboResponse")]
        System.Collections.Generic.List<Hersan.Entidades.Catalogos.ReflejantesBE> ENS_ReflejanteCotizacion_Combo(int IdFicha);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Ensamble/ENS_Cotizacion_Guardar", ReplyAction="http://tempuri.org/IHersan_Ensamble/ENS_Cotizacion_GuardarResponse")]
        int ENS_Cotizacion_Guardar(Hersan.Entidades.Ensamble.PedidosBE obj, System.Data.DataTable oDetalle);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Ensamble/ENS_Cotizacion_Buscar", ReplyAction="http://tempuri.org/IHersan_Ensamble/ENS_Cotizacion_BuscarResponse")]
        System.Collections.Generic.List<Hersan.Entidades.Ensamble.PedidosBE> ENS_Cotizacion_Buscar(int IdCliente, string Nombre, string Inicial, string Final);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Ensamble/ENS_Cotizacion_Obtener", ReplyAction="http://tempuri.org/IHersan_Ensamble/ENS_Cotizacion_ObtenerResponse")]
        System.Collections.Generic.List<Hersan.Entidades.Ensamble.PedidosBE> ENS_Cotizacion_Obtener(int IdCotizacion);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Ensamble/ENS_Cotizacion_Actualizar", ReplyAction="http://tempuri.org/IHersan_Ensamble/ENS_Cotizacion_ActualizarResponse")]
        int ENS_Cotizacion_Actualizar(Hersan.Entidades.Ensamble.PedidosBE obj, System.Data.DataTable oDetalle);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Ensamble/ENS_Cotizacion_Reporte", ReplyAction="http://tempuri.org/IHersan_Ensamble/ENS_Cotizacion_ReporteResponse")]
        System.Data.DataTable ENS_Cotizacion_Reporte(int IdCotiza);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Ensamble/ENS_Cotizacion_ReporteDetalle", ReplyAction="http://tempuri.org/IHersan_Ensamble/ENS_Cotizacion_ReporteDetalleResponse")]
        System.Data.DataTable ENS_Cotizacion_ReporteDetalle(int IdCotiza);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Ensamble/ENS_Cotizacion_Consulta", ReplyAction="http://tempuri.org/IHersan_Ensamble/ENS_Cotizacion_ConsultaResponse")]
        System.Collections.Generic.List<Hersan.Entidades.Ensamble.PedidosBE> ENS_Cotizacion_Consulta(int IdAgente, int IdCotiza, string Inicial, string Final);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Ensamble/ENS_Pedido_Consulta", ReplyAction="http://tempuri.org/IHersan_Ensamble/ENS_Pedido_ConsultaResponse")]
        System.Collections.Generic.List<Hersan.Entidades.Ensamble.PedidosBE> ENS_Pedido_Consulta(int IdAgente, int Pedido, string Inicial, string Final);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Ensamble/PRO_Inyeccion_Guardar", ReplyAction="http://tempuri.org/IHersan_Ensamble/PRO_Inyeccion_GuardarResponse")]
        int PRO_Inyeccion_Guardar(Hersan.Entidades.Inyeccion.InyeccionBE Obj, System.Data.DataTable Detalle);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Ensamble/PRO_Inyeccion_Obtener", ReplyAction="http://tempuri.org/IHersan_Ensamble/PRO_Inyeccion_ObtenerResponse")]
        System.Collections.Generic.List<Hersan.Entidades.Inyeccion.InyeccionDetalleBE> PRO_Inyeccion_Obtener(Hersan.Entidades.Inyeccion.InyeccionBE Obj);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Ensamble/PRO_Inyeccion_Consulta", ReplyAction="http://tempuri.org/IHersan_Ensamble/PRO_Inyeccion_ConsultaResponse")]
        Hersan.Entidades.Inyeccion.InyeccionBE PRO_Inyeccion_Consulta(int Lista);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Ensamble/PRO_Temperaturas_Guardar", ReplyAction="http://tempuri.org/IHersan_Ensamble/PRO_Temperaturas_GuardarResponse")]
        int PRO_Temperaturas_Guardar(Hersan.Entidades.Inyeccion.TemperaturasBE Obj);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Ensamble/PRO_Temperaturas_Obtener", ReplyAction="http://tempuri.org/IHersan_Ensamble/PRO_Temperaturas_ObtenerResponse")]
        Hersan.Entidades.Inyeccion.TemperaturasBE PRO_Temperaturas_Obtener();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Ensamble/PRO_TemperaturasMolde_Guardar", ReplyAction="http://tempuri.org/IHersan_Ensamble/PRO_TemperaturasMolde_GuardarResponse")]
        int PRO_TemperaturasMolde_Guardar(Hersan.Entidades.Inyeccion.TempMoldesBE Obj);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Ensamble/PRO_TemperaturasMolde_Obtener", ReplyAction="http://tempuri.org/IHersan_Ensamble/PRO_TemperaturasMolde_ObtenerResponse")]
        Hersan.Entidades.Inyeccion.TempMoldesBE PRO_TemperaturasMolde_Obtener();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Ensamble/PRO_Parametros_Guardar", ReplyAction="http://tempuri.org/IHersan_Ensamble/PRO_Parametros_GuardarResponse")]
        int PRO_Parametros_Guardar(System.Data.DataTable Tabla);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Ensamble/PRO_Parametros_Obtener", ReplyAction="http://tempuri.org/IHersan_Ensamble/PRO_Parametros_ObtenerResponse")]
        Hersan.Entidades.Inyeccion.ParametrosInyeccion PRO_Parametros_Obtener();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Ensamble/CAL_InspeccionInyeccion_Guarda", ReplyAction="http://tempuri.org/IHersan_Ensamble/CAL_InspeccionInyeccion_GuardaResponse")]
        int CAL_InspeccionInyeccion_Guarda(Hersan.Entidades.Calidad.CalidadBE Obj, System.Data.DataTable Detalle);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Ensamble/CAL_InspeccionInyeccion_Actualiza", ReplyAction="http://tempuri.org/IHersan_Ensamble/CAL_InspeccionInyeccion_ActualizaResponse")]
        int CAL_InspeccionInyeccion_Actualiza(int IdInyeccion, System.Data.DataTable Detalle);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Ensamble/CAL_ReflejantesNorma_Guardar", ReplyAction="http://tempuri.org/IHersan_Ensamble/CAL_ReflejantesNorma_GuardarResponse")]
        int CAL_ReflejantesNorma_Guardar(System.Data.DataTable Tabla, int IdUsuario);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Ensamble/CAL_ReflejantesNorma_Actualizar", ReplyAction="http://tempuri.org/IHersan_Ensamble/CAL_ReflejantesNorma_ActualizarResponse")]
        int CAL_ReflejantesNorma_Actualizar(System.Data.DataTable Tabla, int IdUsuario, bool Estatus);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Ensamble/CAL_ReflejantesNorma_Obtener", ReplyAction="http://tempuri.org/IHersan_Ensamble/CAL_ReflejantesNorma_ObtenerResponse")]
        System.Collections.Generic.List<Hersan.Entidades.Calidad.NormaBE> CAL_ReflejantesNorma_Obtener();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Ensamble/CAL_InspeccionInyeccion_Analisis", ReplyAction="http://tempuri.org/IHersan_Ensamble/CAL_InspeccionInyeccion_AnalisisResponse")]
        System.Collections.Generic.List<Hersan.Entidades.Inyeccion.InyeccionBE> CAL_InspeccionInyeccion_Analisis(Hersan.Entidades.Calidad.CalidadBE Obj);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Ensamble/CAL_InspeccionInyeccion_AnalisisDetalle", ReplyAction="http://tempuri.org/IHersan_Ensamble/CAL_InspeccionInyeccion_AnalisisDetalleRespon" +
            "se")]
        System.Collections.Generic.List<Hersan.Entidades.Calidad.CalidadDetalleBE> CAL_InspeccionInyeccion_AnalisisDetalle(int Lista);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Ensamble/PRO_Ensamble_Parametros_Guardar", ReplyAction="http://tempuri.org/IHersan_Ensamble/PRO_Ensamble_Parametros_GuardarResponse")]
        int PRO_Ensamble_Parametros_Guardar(Hersan.Entidades.Calidad.EnsambleParametrosBE Obj, System.Data.DataTable Detalle);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Ensamble/PRO_Ensamble_Parametros_Obtener", ReplyAction="http://tempuri.org/IHersan_Ensamble/PRO_Ensamble_Parametros_ObtenerResponse")]
        System.Collections.Generic.List<Hersan.Entidades.Calidad.EnsambleParametrosBE> PRO_Ensamble_Parametros_Obtener(Hersan.Entidades.Calidad.EnsambleParametrosBE Obj);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Ensamble/CAL_InspeccionEnsamble_Consultar", ReplyAction="http://tempuri.org/IHersan_Ensamble/CAL_InspeccionEnsamble_ConsultarResponse")]
        System.Collections.Generic.List<Hersan.Entidades.Calidad.CalidadEnsambleBE> CAL_InspeccionEnsamble_Consultar(int Lista);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Ensamble/CAL_InspeccionEnsamble_Guardar", ReplyAction="http://tempuri.org/IHersan_Ensamble/CAL_InspeccionEnsamble_GuardarResponse")]
        int CAL_InspeccionEnsamble_Guardar(Hersan.Entidades.Calidad.CalidadEnsambleBE Obj, System.Data.DataTable Detalle);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Ensamble/CAL_InspeccionEnsamble_Actualizar", ReplyAction="http://tempuri.org/IHersan_Ensamble/CAL_InspeccionEnsamble_ActualizarResponse")]
        int CAL_InspeccionEnsamble_Actualizar(Hersan.Entidades.Calidad.CalidadEnsambleBE Obj, System.Data.DataTable Detalle);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Ensamble/CAL_InspeccionEnsamble_Obtener", ReplyAction="http://tempuri.org/IHersan_Ensamble/CAL_InspeccionEnsamble_ObtenerResponse")]
        System.Collections.Generic.List<Hersan.Entidades.Calidad.CalidadEnsambleDetalleBE> CAL_InspeccionEnsamble_Obtener(int Lista);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Ensamble/CAL_InspeccionEnsamble_Analisis", ReplyAction="http://tempuri.org/IHersan_Ensamble/CAL_InspeccionEnsamble_AnalisisResponse")]
        System.Collections.Generic.List<Hersan.Entidades.Calidad.CalidadEnsambleBE> CAL_InspeccionEnsamble_Analisis(Hersan.Entidades.Calidad.CalidadEnsambleBE Obj);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Ensamble/CAL_InspeccionEnsamble_AnalisisDetalle", ReplyAction="http://tempuri.org/IHersan_Ensamble/CAL_InspeccionEnsamble_AnalisisDetalleRespons" +
            "e")]
        System.Collections.Generic.List<Hersan.Entidades.Calidad.CalidadEnsambleDetalleBE> CAL_InspeccionEnsamble_AnalisisDetalle(int Lista);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Ensamble/CAL_ResguardoQA_Guardar", ReplyAction="http://tempuri.org/IHersan_Ensamble/CAL_ResguardoQA_GuardarResponse")]
        int CAL_ResguardoQA_Guardar(Hersan.Entidades.Calidad.CalidadResguardoQA Obj, System.Data.DataTable Detalle);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Ensamble/CAL_ResguardoQA_Actualizar", ReplyAction="http://tempuri.org/IHersan_Ensamble/CAL_ResguardoQA_ActualizarResponse")]
        int CAL_ResguardoQA_Actualizar(Hersan.Entidades.Calidad.CalidadResguardoQA Obj, System.Data.DataTable Detalle);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Ensamble/CAL_ResguardoQA_Obtener", ReplyAction="http://tempuri.org/IHersan_Ensamble/CAL_ResguardoQA_ObtenerResponse")]
        System.Collections.Generic.List<Hersan.Entidades.Calidad.CalidadResguardoQA> CAL_ResguardoQA_Obtener(int IdProducto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Ensamble/CAL_AnalisisInyeccion_Histograma", ReplyAction="http://tempuri.org/IHersan_Ensamble/CAL_AnalisisInyeccion_HistogramaResponse")]
        System.Collections.Generic.List<Hersan.Entidades.Calidad.CalidadGraficasCavidades> CAL_AnalisisInyeccion_Histograma(int Lista);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IHersan_EnsambleChannel : Hersan.UI.Calidad.WCF_Ensamble.IHersan_Ensamble, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Hersan_EnsambleClient : System.ServiceModel.ClientBase<Hersan.UI.Calidad.WCF_Ensamble.IHersan_Ensamble>, Hersan.UI.Calidad.WCF_Ensamble.IHersan_Ensamble {
        
        public Hersan_EnsambleClient() {
        }
        
        public Hersan_EnsambleClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Hersan_EnsambleClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Hersan_EnsambleClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Hersan_EnsambleClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public int ABC_Clientes_Guardar(System.Data.DataSet Tablas, string Entidades, int IdUsuario) {
            return base.Channel.ABC_Clientes_Guardar(Tablas, Entidades, IdUsuario);
        }
        
        public int ABC_Clientes_Actualizar(System.Data.DataSet Tablas, string Entidades, int IdUsuario, bool Estatus) {
            return base.Channel.ABC_Clientes_Actualizar(Tablas, Entidades, IdUsuario, Estatus);
        }
        
        public System.Collections.Generic.List<Hersan.Entidades.Ensamble.ClientesBE> ABC_Clientes_Buscar(Hersan.Entidades.Ensamble.ClientesBE Lista, string Entidades) {
            return base.Channel.ABC_Clientes_Buscar(Lista, Entidades);
        }
        
        public System.Collections.Generic.List<Hersan.Entidades.Ensamble.ClientesBE> ABC_Clientes_Obtener(int IdCliente) {
            return base.Channel.ABC_Clientes_Obtener(IdCliente);
        }
        
        public System.Collections.Generic.List<Hersan.Entidades.Ensamble.ClientesBE> ABC_ClientesAgente_Combo(int IdAgente) {
            return base.Channel.ABC_ClientesAgente_Combo(IdAgente);
        }
        
        public int ABC_ClientesAgente_Guardar(Hersan.Entidades.Ensamble.ClientesBE obj) {
            return base.Channel.ABC_ClientesAgente_Guardar(obj);
        }
        
        public System.Collections.Generic.List<Hersan.Entidades.Catalogos.FormasPagoBE> ABC_FormaPago_Combo() {
            return base.Channel.ABC_FormaPago_Combo();
        }
        
        public System.Collections.Generic.List<Hersan.Entidades.Catalogos.MetodosPagoBE> ABC_MetodoPago_Combo() {
            return base.Channel.ABC_MetodoPago_Combo();
        }
        
        public System.Collections.Generic.List<Hersan.Entidades.Catalogos.UsoCFDIBE> ABC_UsoCFDI_Combo() {
            return base.Channel.ABC_UsoCFDI_Combo();
        }
        
        public int ENS_Servicios_Guardar(Hersan.Entidades.Ensamble.ServiciosBE obj) {
            return base.Channel.ENS_Servicios_Guardar(obj);
        }
        
        public int ENS_Servicios_Actualizar(Hersan.Entidades.Ensamble.ServiciosBE obj) {
            return base.Channel.ENS_Servicios_Actualizar(obj);
        }
        
        public System.Collections.Generic.List<Hersan.Entidades.Ensamble.ServiciosBE> ENS_Servicios_Obtener() {
            return base.Channel.ENS_Servicios_Obtener();
        }
        
        public System.Collections.Generic.List<Hersan.Entidades.Ensamble.ServiciosBE> ENS_Servicios_Combo(int IdEntidad, string Moneda) {
            return base.Channel.ENS_Servicios_Combo(IdEntidad, Moneda);
        }
        
        public System.Collections.Generic.List<Hersan.Entidades.Ensamble.ServiciosBE> ENS_ServiciosCotizacion_Combo(string Moneda) {
            return base.Channel.ENS_ServiciosCotizacion_Combo(Moneda);
        }
        
        public int ENS_Precios_Guardar(System.Data.DataTable oData, string Moneda, int IdUsuario) {
            return base.Channel.ENS_Precios_Guardar(oData, Moneda, IdUsuario);
        }
        
        public System.Collections.Generic.List<Hersan.Entidades.Ensamble.PreciosBE> ENS_Precios_Obtener(string Moneda) {
            return base.Channel.ENS_Precios_Obtener(Moneda);
        }
        
        public int ENS_ProductosFicha_Guardar(System.Data.DataSet Tablas, byte[] Imagen, string Colores, string Reflejantes, string Accesorios, int IdUsuario) {
            return base.Channel.ENS_ProductosFicha_Guardar(Tablas, Imagen, Colores, Reflejantes, Accesorios, IdUsuario);
        }
        
        public int ENS_ProductosFicha_Actualizar(System.Data.DataSet Tablas, byte[] Imagen, string Colores, string Reflejantes, string Accesorios, int IdUsuario, bool Estatus) {
            return base.Channel.ENS_ProductosFicha_Actualizar(Tablas, Imagen, Colores, Reflejantes, Accesorios, IdUsuario, Estatus);
        }
        
        public System.Collections.Generic.List<Hersan.Entidades.Ensamble.ProductoEnsambleBE> ENS_ProductosFicha_Obtener(Hersan.Entidades.Ensamble.ProductoEnsambleBE obj) {
            return base.Channel.ENS_ProductosFicha_Obtener(obj);
        }
        
        public System.Collections.Generic.List<Hersan.Entidades.Ensamble.ProductoEnsambleBE> ENS_ProductosCotizacion_Combo(bool Nacional, string Moneda) {
            return base.Channel.ENS_ProductosCotizacion_Combo(Nacional, Moneda);
        }
        
        public System.Collections.Generic.List<Hersan.Entidades.Catalogos.ColoresBE> ENS_CarcasasCotizacion_Combo(int IdFicha) {
            return base.Channel.ENS_CarcasasCotizacion_Combo(IdFicha);
        }
        
        public System.Collections.Generic.List<Hersan.Entidades.Catalogos.ReflejantesBE> ENS_ReflejanteCotizacion_Combo(int IdFicha) {
            return base.Channel.ENS_ReflejanteCotizacion_Combo(IdFicha);
        }
        
        public int ENS_Cotizacion_Guardar(Hersan.Entidades.Ensamble.PedidosBE obj, System.Data.DataTable oDetalle) {
            return base.Channel.ENS_Cotizacion_Guardar(obj, oDetalle);
        }
        
        public System.Collections.Generic.List<Hersan.Entidades.Ensamble.PedidosBE> ENS_Cotizacion_Buscar(int IdCliente, string Nombre, string Inicial, string Final) {
            return base.Channel.ENS_Cotizacion_Buscar(IdCliente, Nombre, Inicial, Final);
        }
        
        public System.Collections.Generic.List<Hersan.Entidades.Ensamble.PedidosBE> ENS_Cotizacion_Obtener(int IdCotizacion) {
            return base.Channel.ENS_Cotizacion_Obtener(IdCotizacion);
        }
        
        public int ENS_Cotizacion_Actualizar(Hersan.Entidades.Ensamble.PedidosBE obj, System.Data.DataTable oDetalle) {
            return base.Channel.ENS_Cotizacion_Actualizar(obj, oDetalle);
        }
        
        public System.Data.DataTable ENS_Cotizacion_Reporte(int IdCotiza) {
            return base.Channel.ENS_Cotizacion_Reporte(IdCotiza);
        }
        
        public System.Data.DataTable ENS_Cotizacion_ReporteDetalle(int IdCotiza) {
            return base.Channel.ENS_Cotizacion_ReporteDetalle(IdCotiza);
        }
        
        public System.Collections.Generic.List<Hersan.Entidades.Ensamble.PedidosBE> ENS_Cotizacion_Consulta(int IdAgente, int IdCotiza, string Inicial, string Final) {
            return base.Channel.ENS_Cotizacion_Consulta(IdAgente, IdCotiza, Inicial, Final);
        }
        
        public System.Collections.Generic.List<Hersan.Entidades.Ensamble.PedidosBE> ENS_Pedido_Consulta(int IdAgente, int Pedido, string Inicial, string Final) {
            return base.Channel.ENS_Pedido_Consulta(IdAgente, Pedido, Inicial, Final);
        }
        
        public int PRO_Inyeccion_Guardar(Hersan.Entidades.Inyeccion.InyeccionBE Obj, System.Data.DataTable Detalle) {
            return base.Channel.PRO_Inyeccion_Guardar(Obj, Detalle);
        }
        
        public System.Collections.Generic.List<Hersan.Entidades.Inyeccion.InyeccionDetalleBE> PRO_Inyeccion_Obtener(Hersan.Entidades.Inyeccion.InyeccionBE Obj) {
            return base.Channel.PRO_Inyeccion_Obtener(Obj);
        }
        
        public Hersan.Entidades.Inyeccion.InyeccionBE PRO_Inyeccion_Consulta(int Lista) {
            return base.Channel.PRO_Inyeccion_Consulta(Lista);
        }
        
        public int PRO_Temperaturas_Guardar(Hersan.Entidades.Inyeccion.TemperaturasBE Obj) {
            return base.Channel.PRO_Temperaturas_Guardar(Obj);
        }
        
        public Hersan.Entidades.Inyeccion.TemperaturasBE PRO_Temperaturas_Obtener() {
            return base.Channel.PRO_Temperaturas_Obtener();
        }
        
        public int PRO_TemperaturasMolde_Guardar(Hersan.Entidades.Inyeccion.TempMoldesBE Obj) {
            return base.Channel.PRO_TemperaturasMolde_Guardar(Obj);
        }
        
        public Hersan.Entidades.Inyeccion.TempMoldesBE PRO_TemperaturasMolde_Obtener() {
            return base.Channel.PRO_TemperaturasMolde_Obtener();
        }
        
        public int PRO_Parametros_Guardar(System.Data.DataTable Tabla) {
            return base.Channel.PRO_Parametros_Guardar(Tabla);
        }
        
        public Hersan.Entidades.Inyeccion.ParametrosInyeccion PRO_Parametros_Obtener() {
            return base.Channel.PRO_Parametros_Obtener();
        }
        
        public int CAL_InspeccionInyeccion_Guarda(Hersan.Entidades.Calidad.CalidadBE Obj, System.Data.DataTable Detalle) {
            return base.Channel.CAL_InspeccionInyeccion_Guarda(Obj, Detalle);
        }
        
        public int CAL_InspeccionInyeccion_Actualiza(int IdInyeccion, System.Data.DataTable Detalle) {
            return base.Channel.CAL_InspeccionInyeccion_Actualiza(IdInyeccion, Detalle);
        }
        
        public int CAL_ReflejantesNorma_Guardar(System.Data.DataTable Tabla, int IdUsuario) {
            return base.Channel.CAL_ReflejantesNorma_Guardar(Tabla, IdUsuario);
        }
        
        public int CAL_ReflejantesNorma_Actualizar(System.Data.DataTable Tabla, int IdUsuario, bool Estatus) {
            return base.Channel.CAL_ReflejantesNorma_Actualizar(Tabla, IdUsuario, Estatus);
        }
        
        public System.Collections.Generic.List<Hersan.Entidades.Calidad.NormaBE> CAL_ReflejantesNorma_Obtener() {
            return base.Channel.CAL_ReflejantesNorma_Obtener();
        }
        
        public System.Collections.Generic.List<Hersan.Entidades.Inyeccion.InyeccionBE> CAL_InspeccionInyeccion_Analisis(Hersan.Entidades.Calidad.CalidadBE Obj) {
            return base.Channel.CAL_InspeccionInyeccion_Analisis(Obj);
        }
        
        public System.Collections.Generic.List<Hersan.Entidades.Calidad.CalidadDetalleBE> CAL_InspeccionInyeccion_AnalisisDetalle(int Lista) {
            return base.Channel.CAL_InspeccionInyeccion_AnalisisDetalle(Lista);
        }
        
        public int PRO_Ensamble_Parametros_Guardar(Hersan.Entidades.Calidad.EnsambleParametrosBE Obj, System.Data.DataTable Detalle) {
            return base.Channel.PRO_Ensamble_Parametros_Guardar(Obj, Detalle);
        }
        
        public System.Collections.Generic.List<Hersan.Entidades.Calidad.EnsambleParametrosBE> PRO_Ensamble_Parametros_Obtener(Hersan.Entidades.Calidad.EnsambleParametrosBE Obj) {
            return base.Channel.PRO_Ensamble_Parametros_Obtener(Obj);
        }
        
        public System.Collections.Generic.List<Hersan.Entidades.Calidad.CalidadEnsambleBE> CAL_InspeccionEnsamble_Consultar(int Lista) {
            return base.Channel.CAL_InspeccionEnsamble_Consultar(Lista);
        }
        
        public int CAL_InspeccionEnsamble_Guardar(Hersan.Entidades.Calidad.CalidadEnsambleBE Obj, System.Data.DataTable Detalle) {
            return base.Channel.CAL_InspeccionEnsamble_Guardar(Obj, Detalle);
        }
        
        public int CAL_InspeccionEnsamble_Actualizar(Hersan.Entidades.Calidad.CalidadEnsambleBE Obj, System.Data.DataTable Detalle) {
            return base.Channel.CAL_InspeccionEnsamble_Actualizar(Obj, Detalle);
        }
        
        public System.Collections.Generic.List<Hersan.Entidades.Calidad.CalidadEnsambleDetalleBE> CAL_InspeccionEnsamble_Obtener(int Lista) {
            return base.Channel.CAL_InspeccionEnsamble_Obtener(Lista);
        }
        
        public System.Collections.Generic.List<Hersan.Entidades.Calidad.CalidadEnsambleBE> CAL_InspeccionEnsamble_Analisis(Hersan.Entidades.Calidad.CalidadEnsambleBE Obj) {
            return base.Channel.CAL_InspeccionEnsamble_Analisis(Obj);
        }
        
        public System.Collections.Generic.List<Hersan.Entidades.Calidad.CalidadEnsambleDetalleBE> CAL_InspeccionEnsamble_AnalisisDetalle(int Lista) {
            return base.Channel.CAL_InspeccionEnsamble_AnalisisDetalle(Lista);
        }
        
        public int CAL_ResguardoQA_Guardar(Hersan.Entidades.Calidad.CalidadResguardoQA Obj, System.Data.DataTable Detalle) {
            return base.Channel.CAL_ResguardoQA_Guardar(Obj, Detalle);
        }
        
        public int CAL_ResguardoQA_Actualizar(Hersan.Entidades.Calidad.CalidadResguardoQA Obj, System.Data.DataTable Detalle) {
            return base.Channel.CAL_ResguardoQA_Actualizar(Obj, Detalle);
        }
        
        public System.Collections.Generic.List<Hersan.Entidades.Calidad.CalidadResguardoQA> CAL_ResguardoQA_Obtener(int IdProducto) {
            return base.Channel.CAL_ResguardoQA_Obtener(IdProducto);
        }
        
        public System.Collections.Generic.List<Hersan.Entidades.Calidad.CalidadGraficasCavidades> CAL_AnalisisInyeccion_Histograma(int Lista) {
            return base.Channel.CAL_AnalisisInyeccion_Histograma(Lista);
        }
    }
}
