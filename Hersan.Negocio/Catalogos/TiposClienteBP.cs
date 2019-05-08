using Hersan.Datos.Catalogos;
using Hersan.Entidades.Catalogos;
using System.Collections.Generic;

namespace Hersan.Negocio.Catalogos
{
    public class TiposClienteBP
    {
        public int ABC_TipoCliente_Guardar(TiposClienteBE obj)
        {
            return new TiposClienteDA().ABC_TipoCliente_Guardar(obj);
        }
        public int ABC_TipoCliente_Actualizar(TiposClienteBE obj)
        {
            return new TiposClienteDA().ABC_TipoCliente_Actualizar(obj);
        }
        public List<TiposClienteBE> ABC_TipoCliente_Obtener()
        {
            return new TiposClienteDA().ABC_TipoCliente_Obtener();
        }
        public List<TiposClienteBE> ABC_TipoCliente_Combo()
        {
            return new TiposClienteDA().ABC_TipoCliente_Combo();
        }
    }
}
