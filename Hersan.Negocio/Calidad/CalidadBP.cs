using Hersan.Datos.Calidad;
using Hersan.Entidades.Calidad;
using System;
using System.Collections.Generic;

namespace Hersan.Negocio.Calidad
{
    public class CalidadBP
    {

        public int CAL_InspeccionInyeccion_Guarda(CalidadBE Obj, System.Data.DataTable Detalle)
        {
            return new CalidadDA().CAL_InspeccionInyeccion_Guarda(Obj, Detalle);
        }
    }
}
