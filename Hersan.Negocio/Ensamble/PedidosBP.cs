using Hersan.Datos.Ensamble;
using Hersan.Entidades.Ensamble;
using System.Collections.Generic;

namespace Hersan.Negocio.Ensamble
{
    public class PedidosBP
    {
        public int ENS_Cotizacion_Guardar(int IdCliente, string Proyecto, System.Data.DataTable oDetalle, int IdUsuario)
        {
            return new PedidosDA().ENS_Cotizacion_Guardar(IdCliente, Proyecto, oDetalle, IdUsuario);
        }
        public List<PedidosBE> ENS_Cotizacion_Buscar(int IdCliente, string Nombre, string Inicial, string Final)
        {
            return new PedidosDA().ENS_Cotizacion_Buscar(IdCliente, Nombre, Inicial, Final);
        }
        public List<PedidosBE> ENS_Cotizacion_Obtener(int IdCotizacion)
        {
            return new PedidosDA().ENS_Cotizacion_Obtener(IdCotizacion);
        }
        public int ENS_Cotizacion_Actualizar(PedidosBE obj, System.Data.DataTable oDetalle)
        {
            return new PedidosDA().ENS_Cotizacion_Actualizar(obj, oDetalle);
        }
        public System.Data.DataTable ENS_Cotizacion_Reporte(int IdCotiza)
        {
            return new PedidosDA().ENS_Cotizacion_Reporte(IdCotiza);
        }
        public System.Data.DataTable ENS_Cotizacion_ReporteDetalle(int IdCotiza)
        {
            return new PedidosDA().ENS_Cotizacion_ReporteDetalle(IdCotiza);
        }
    }
}
