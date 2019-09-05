using Hersan.Datos.APT;
using Hersan.Entidades.APT;
using System.Collections.Generic;

namespace Hersan.Negocio.APT {
    public class UbicacionesBP 
    {

        public List<UbicacionesBE> APT_Ubicacion_Obtener()
        {
            return new UbicacionesDA().APT_Ubicacion_Obtener();
        }
        public int APT_Ubicacion_Guardar(UbicacionesBE obj)
        {
            return new UbicacionesDA().APT_Ubicacion_Guardar(obj);
        }
        public int APT_Ubicacion_Actualizar(UbicacionesBE obj)
        {
            return new UbicacionesDA().APT_Ubicacion_Actualizar(obj);
        }
    }
}
