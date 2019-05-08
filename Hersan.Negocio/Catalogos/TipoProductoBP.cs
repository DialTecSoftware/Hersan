using Hersan.Datos.Catalogos;
using Hersan.Entidades.Catalogos;
using System;
using System.Collections.Generic;

namespace Hersan.Negocio.Catalogos
{
    public class TipoProductoBP
    {

        public int ENS_TipoProducto_Guardar(TipoProductoBE obj)
        {
            return new TipoProductoDA().ENS_TipoProducto_Guardar(obj);
        }
        public int ENS_TipoProducto_Actualizar(TipoProductoBE obj)
        {
            return new TipoProductoDA().ENS_TipoProducto_Actualizar(obj);
        }
        public List<TipoProductoBE> ENS_TipoProducto_Obtener()
        {
            return new TipoProductoDA().ENS_TipoProducto_Obtener();
        }
        public List<TipoProductoBE> ENS_TipoProducto_Combo(int IdFamilia)
        {
            return new TipoProductoDA().ENS_TipoProducto_Combo(IdFamilia);
        }

    }
}
