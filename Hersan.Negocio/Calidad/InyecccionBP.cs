using Hersan.Datos.Calidad;
using Hersan.Entidades.Inyeccion;
using System;
using System.Collections.Generic;
using System.Data;

namespace Hersan.Negocio.Calidad
{
    public class InyecccionBP
    {
        public int PRO_Inyeccion_Guardar(InyeccionBE Obj, DataTable Detalle)
        {
            return new InyeccionDA().PRO_Inyeccion_Guardar(Obj, Detalle);
        }
        public List<InyeccionDetalleBE> PRO_Inyeccion_Obtener(InyeccionBE Obj)
        {
            return new InyeccionDA().PRO_Inyeccion_Obtener(Obj);
        }
    }
}
