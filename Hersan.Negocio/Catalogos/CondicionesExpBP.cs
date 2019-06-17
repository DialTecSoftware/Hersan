using Hersan.Datos.Catalogos;
using Hersan.Entidades.Catalogos;
using System.Collections.Generic;

namespace Hersan.Negocio.Catalogos
{
    public class CondicionesExpBP
    {
        public int ABC_CondicionesExportacion_Guardar(CondicionesExpBE obj)
        {
            return new CondicionesExpDA().ABC_CondicionesExportacion_Guardar(obj);
        }
        public int ABC_CondicionesExportacion_Actualizar(CondicionesExpBE obj)
        {
            return new CondicionesExpDA().ABC_CondicionesExportacion_Actualizar(obj);
        }
        public List<CondicionesExpBE> ABC_CondicionesExportacion_Obtener()
        {
            return new CondicionesExpDA().ABC_CondicionesExportacion_Obtener();
        }
        public List<CondicionesExpBE> ABC_CondicionesExportacion_Combo()
        {
            return new CondicionesExpDA().ABC_CondicionesExportacion_Combo();
        }
    }
}
