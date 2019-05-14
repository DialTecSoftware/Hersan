using Hersan.Datos.Catalogos;
using Hersan.Entidades.Catalogos;
using System.Collections.Generic;

namespace Hersan.Negocio.Catalogos
{
    public class FamiliasBP
    {
        public int ENS_Familias_Guardar(FamiliasBE obj)
        {
            return new FamiliasDA().ENS_Familias_Guardar(obj);
        }
        public int ENS_Familias_Actualizar(FamiliasBE obj)
        {
            return new FamiliasDA().ENS_Familias_Actualizar(obj);
        }
        public List<FamiliasBE> ENS_Familias_Obtener()
        {
            return new FamiliasDA().ENS_Familias_Obtener();
        }
        public List<FamiliasBE> ENS_Familias_Combo(int IdEntidad)
        {
            return new FamiliasDA().ENS_Familias_Combo(IdEntidad);
        }
    }
}
