using Hersan.Datos.Calidad;
using Hersan.Entidades.Calidad;
using Hersan.Entidades.Inyeccion;
using System;
using System.Collections.Generic;
using System.Data;

namespace Hersan.Negocio.Calidad
{
    public class CalidadBP
    {

        public int CAL_InspeccionInyeccion_Guarda(CalidadBE Obj, DataTable Detalle)
        {
            return new CalidadDA().CAL_InspeccionInyeccion_Guarda(Obj, Detalle);
        }
        public int CAL_InspeccionInyeccion_Actualiza(int IdInyeccion, DataTable Detalle)
        {
            return new CalidadDA().CAL_InspeccionInyeccion_Actualiza(IdInyeccion, Detalle);
        }
        public List<InyeccionBE> CAL_InspeccionInyeccion_Analisis(CalidadBE Obj)
        {
            return new CalidadDA().CAL_InspeccionInyeccion_Analisis(Obj);
        }
        public List<CalidadDetalleBE> CAL_InspeccionInyeccion_AnalisisDetalle(int Lista)
        {
            return new CalidadDA().CAL_InspeccionInyeccion_AnalisisDetalle(Lista);
        }

        public List<CalidadEnsambleBE> CAL_InspeccionEnsamble_Analisis(CalidadEnsambleBE Obj)
        {
            return new CalidadDA().CAL_InspeccionEnsamble_Analisis(Obj);
        }
        public List<CalidadEnsambleDetalleBE> CAL_InspeccionEnsamble_AnalisisDetalle(int Lista)
        {
            return new CalidadDA().CAL_InspeccionEnsamble_AnalisisDetalle(Lista);
        }

        public int CAL_ResguardoQA_Guardar(CalidadResguardoQA Obj, DataTable Detalle)
        {
            return new CalidadDA().CAL_ResguardoQA_Guardar(Obj, Detalle);
        }
        public int CAL_ResguardoQA_Actualizar(CalidadResguardoQA Obj, DataTable Detalle)
        {
            return new CalidadDA().CAL_ResguardoQA_Actualizar(Obj, Detalle);
        }
        public List<CalidadResguardoQA> CAL_ResguardoQA_Obtener(int IdProducto, string Fecha)
        {
            return new CalidadDA().CAL_ResguardoQA_Obtener(IdProducto, Fecha);
        }

        public List<CalidadGraficasCavidades> CAL_AnalisisInyeccion_Histograma(int Lista)
        {
            return new CalidadDA().CAL_AnalisisInyeccion_Histograma(Lista);
        }
        public List<CalidadGraficasCavidades> CAL_AnalisisInyeccion_GraficaControl(int Lista, string Fecha)
        {
            return new CalidadDA().CAL_AnalisisInyeccion_GraficaControl(Lista, Fecha);
        }
    }
}
