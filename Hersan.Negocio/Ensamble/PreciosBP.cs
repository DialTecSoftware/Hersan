using Hersan.Datos.Ensamble;
using Hersan.Entidades.Ensamble;
using System.Collections.Generic;
using System.Data;

namespace Hersan.Negocio.Ensamble
{
    public class PreciosBP
    {
        public int ENS_Precios_Guardar(DataTable oData, string Moneda, int IdUsuario)
        {
            return new PreciosDA().ENS_Precios_Guardar(oData, Moneda, IdUsuario);
        }
        public List<PreciosBE> ENS_Precios_Obtener(string Moneda)
        {
            return new PreciosDA().ENS_Precios_Obtener(Moneda);
        }
    }
}
