using Hersan.Datos.Catalogos;
using Hersan.Entidades.Catalogos;
using System;
using System.Collections.Generic;

namespace Hersan.Negocio.Catalogos
{
    public class AccesoriosBP
    {

        public int ENS_Accesorios_Guardar(AccesoriosBE obj)
        {
            return new AccesoriosDA().ENS_Accesorios_Guardar(obj);
        }
        public int ENS_Accesorios_Actualizar(AccesoriosBE obj)
        {
            return new AccesoriosDA().ENS_Accesorios_Actualizar(obj);
        }
        public List<AccesoriosBE> ENS_Accesorios_Obtener()
        {
            return new AccesoriosDA().ENS_Accesorios_Obtener();
        }
        public List<AccesoriosBE> ENS_Accesorios_Combo()
        {
            return new AccesoriosDA().ENS_Accesorios_Combo();
        }
        public List<AccesoriosBE> ENS_AccesoriosCotizacion_Combo(int IdFicha)
        {
            return new AccesoriosDA().ENS_AccesoriosCotizacion_Combo(IdFicha);
        }
    }
}
