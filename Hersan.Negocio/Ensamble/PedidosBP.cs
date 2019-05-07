using Hersan.Datos.Ensamble;

namespace Hersan.Negocio.Ensamble
{
    public class PedidosBP
    {
        public int ENS_Cotizacion_Guardar(int IdCliente, System.Data.DataTable oDetalle, int IdUsuario)
        {
            return new PedidosDA().ENS_Cotizacion_Guardar(IdCliente, oDetalle, IdUsuario);
        }

    }
}
