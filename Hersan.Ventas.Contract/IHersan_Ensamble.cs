using Hersan.Entidades.Calidad;
using Hersan.Entidades.Catalogos;
using Hersan.Entidades.Ensamble;
using Hersan.Entidades.Inyeccion;
using System.Collections.Generic;
using System.ServiceModel;

namespace Hersan.Ensamble.Contract
{
    [ServiceContract]
    public interface IHersan_Ensamble
    {
        #region Clientes
        [OperationContract]
        int ABC_Clientes_Guardar(System.Data.DataSet Tablas, string Entidades, int IdUsuario);
        [OperationContract]
        int ABC_Clientes_Actualizar(System.Data.DataSet Tablas, string Entidades, int IdUsuario, bool Estatus);
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
        int ENS_Precios_Guardar(System.Data.DataTable oData, string Moneda, int IdUsuario);
        [OperationContract]
        List<PreciosBE> ENS_Precios_Obtener(string Moneda);
        #endregion

        #region Productos
        [OperationContract]
        int ENS_ProductosFicha_Guardar(System.Data.DataSet Tablas, byte[] Imagen, string Colores, string Reflejantes, string Accesorios, int IdUsuario);
        [OperationContract]
        int ENS_ProductosFicha_Actualizar(System.Data.DataSet Tablas, byte[] Imagen, string Colores, string Reflejantes, string Accesorios, int IdUsuario, bool Estatus);
        [OperationContract]
        List<ProductoEnsambleBE> ENS_ProductosFicha_Obtener(ProductoEnsambleBE obj);
        [OperationContract]
        List<ProductoEnsambleBE> ENS_ProductosCotizacion_Combo(bool Nacional, string Moneda);
        [OperationContract]
        List<ColoresBE> ENS_CarcasasCotizacion_Combo(int IdFicha);
        [OperationContract]
        List<ReflejantesBE> ENS_ReflejanteCotizacion_Combo(int IdFicha);
        #endregion

        #region Cotizaciones y Pedidos
        [OperationContract]
        int ENS_Cotizacion_Guardar(PedidosBE obj, System.Data.DataTable oDetalle);
        [OperationContract]
        List<PedidosBE> ENS_Cotizacion_Buscar(int IdCliente, string Nombre, string Inicial, string Final);
        [OperationContract]
        List<PedidosBE> ENS_Cotizacion_Obtener(int IdCotizacion);
        [OperationContract]
        int ENS_Cotizacion_Actualizar(PedidosBE obj, System.Data.DataTable oDetalle);
        [OperationContract]
        System.Data.DataTable ENS_Cotizacion_Reporte(int IdCotiza);
        [OperationContract]
        System.Data.DataTable ENS_Cotizacion_ReporteDetalle(int IdCotiza);
        [OperationContract]
        List<PedidosBE> ENS_Cotizacion_Consulta(int IdAgente, int IdCotiza, string Inicial, string Final);
        [OperationContract]
        List<PedidosBE> ENS_Pedido_Consulta(int IdAgente, int Pedido, string Inicial, string Final);
        #endregion


        #region Calidad
        [OperationContract]
        int PRO_Inyeccion_Guardar(InyeccionBE Obj, System.Data.DataTable Detalle);
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
        int PRO_Parametros_Guardar(System.Data.DataTable Tabla);
        [OperationContract]
        ParametrosInyeccion PRO_Parametros_Obtener();

        [OperationContract]
        int CAL_InspeccionInyeccion_Guarda(CalidadBE Obj, System.Data.DataTable Detalle);
        [OperationContract]
        int CAL_InspeccionInyeccion_Actualiza(int IdInyeccion, System.Data.DataTable Detalle);

        [OperationContract]
        int CAL_ReflejantesNorma_Guardar(NormaBE Obj);
        [OperationContract]
        int CAL_ReflejantesNorma_Actualizar(NormaBE Obj);
        [OperationContract]
        List<NormaBE> CAL_ReflejantesNorma_Obtener();
        #endregion
    }
}
