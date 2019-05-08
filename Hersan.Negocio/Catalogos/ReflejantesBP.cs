using Hersan.Datos.Catalogos;
using Hersan.Entidades.Catalogos;
using System.Collections.Generic;

namespace Hersan.Negocio.Catalogos
{
    public class ReflejantesBP
    {
        public int ENS_Reflejantes_Guardar(ReflejantesBE obj)
        {
            return new ReflejantesDA().ENS_Reflejantes_Guardar(obj); 
        }
        public int ENS_Reflejantes_Actualizar(ReflejantesBE obj)
        {
            return new ReflejantesDA(). ENS_Reflejantes_Actualizar(obj);
        }
        public List<ReflejantesBE> ENS_Reflejantes_Obtener()
        {
            return new ReflejantesDA().ENS_Reflejantes_Obtener();
        }
        public List<ReflejantesBE> ENS_Reflejantes_Combo()
        {
            return new ReflejantesDA().ENS_Reflejantes_Combo();
        }
    }
}
