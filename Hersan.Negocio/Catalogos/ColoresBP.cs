using Hersan.Datos.Catalogos;
using Hersan.Entidades.Catalogos;
using System.Collections.Generic;

namespace Hersan.Negocio.Catalogos
{
    public class ColoresBP
    {
        public int ABC_Colores_Guardar(ColoresBE obj)
        {
            return new ColoresDA().ABC_Colores_Guardar(obj);
        }
        public int ABC_Colores_Actualizar(ColoresBE obj)
        {
            return new ColoresDA().ABC_Colores_Actualizar(obj);
        }
        public List<ColoresBE> ABC_Colores_Obtener()
        {
            return new ColoresDA().ABC_Colores_Obtener();
        }
        public List<ColoresBE> ABC_Colores_Combo()
        {
            return new ColoresDA().ABC_Colores_Combo();
        }
    }
}
