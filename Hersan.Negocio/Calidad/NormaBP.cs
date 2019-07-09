using Hersan.Datos.Calidad;
using Hersan.Entidades.Calidad;
using System.Collections.Generic;
using System.Data;

namespace Hersan.Negocio.Calidad
{
    public class NormaBP
    {
        public int CAL_ReflejantesNorma_Guardar(DataTable Tabla, int IdUsuario)
        {
            return new NormaDA().CAL_ReflejantesNorma_Guardar(Tabla, IdUsuario);
        }
        public int CAL_ReflejantesNorma_Actualizar(DataTable Tabla, int IdUsuario, bool Estatus)
        {
            return new NormaDA().CAL_ReflejantesNorma_Actualizar(Tabla, IdUsuario, Estatus);
        }
        public List<NormaBE> CAL_ReflejantesNorma_Obtener()
        {
            return new NormaDA().CAL_ReflejantesNorma_Obtener();
        }
    }
}
