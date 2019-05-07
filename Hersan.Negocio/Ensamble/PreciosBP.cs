using Hersan.Datos.Ensamble;
using Hersan.Entidades.Ensamble;
using System.Collections.Generic;
using System.Data;

namespace Hersan.Negocio.Ensamble
{
    public class PreciosBP
    {
        public int ENS_Precios_Guardar(DataTable oData, int IdUsuario)
        {
            return new PreciosDA().ENS_Precios_Guardar(oData, IdUsuario);
        }
        public List<PreciosBE> ENS_Precios_Obtener()
        {
            return new PreciosDA().ENS_Precios_Obtener();
        }
    }
}
