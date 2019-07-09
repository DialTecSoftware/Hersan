using Hersan.Datos.Calidad;
using Hersan.Entidades.Calidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hersan.Negocio.Calidad
{
    public class EnsambleBP
    {
        public int PRO_Ensamble_Parametros_Guardar(EnsambleParametrosBE Obj, System.Data.DataTable Detalle)
        {
            return new EnsambleDA().PRO_Ensamble_Parametros_Guardar(Obj, Detalle);
        }
        public List<EnsambleParametrosBE> PRO_Ensamble_Parametros_Obtener(EnsambleParametrosBE Obj)
        {
            return new EnsambleDA().PRO_Ensamble_Parametros_Obtener(Obj);
        }
        public List<CalidadEnsambleBE> CAL_InspeccionEnsamble_Consultar(int Lista)
        {
            return new EnsambleDA().CAL_InspeccionEnsamble_Consultar(Lista);
        }

        public int CAL_InspeccionEnsamble_Guardar(CalidadEnsambleBE Obj, System.Data.DataTable Detalle)
        {
            return new EnsambleDA().CAL_InspeccionEnsamble_Guardar(Obj, Detalle);
        }
        public int CAL_InspeccionEnsamble_Actualizar(CalidadEnsambleBE Obj, System.Data.DataTable Detalle)
        {
            return new EnsambleDA().CAL_InspeccionEnsamble_Actualizar(Obj, Detalle);
        }
        public List<CalidadEnsambleDetalleBE> CAL_InspeccionEnsamble_Obtener(int Lista)
        {
            return new EnsambleDA().CAL_InspeccionEnsamble_Obtener(Lista);
        }
    }
}
