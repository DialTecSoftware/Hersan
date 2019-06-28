using Hersan.Datos.Calidad;
using Hersan.Entidades.Inyeccion;
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
        public InyeccionBE PRO_Inyeccion_Consulta(int Lista)
        {
            return new InyeccionDA().PRO_Inyeccion_Consulta(Lista);
        }
        public int PRO_Temperaturas_Guardar(TemperaturasBE Obj)
        {
            return new InyeccionDA().PRO_Temperaturas_Guardar(Obj);
        }
        public TemperaturasBE PRO_Temperaturas_Obtener()
        {
            return new InyeccionDA().PRO_Temperaturas_Obtener();
        }
        public int PRO_TemperaturasMolde_Guardar(TempMoldesBE Obj)
        {
            return new InyeccionDA().PRO_TemperaturasMolde_Guardar(Obj);
        }
        public TempMoldesBE PRO_TemperaturasMolde_Obtener()
        {
            return new InyeccionDA().PRO_TemperaturasMolde_Obtener();
        }
        public int PRO_Parametros_Guardar(DataTable Tabla)
        {
            return new InyeccionDA().PRO_Parametros_Guardar(Tabla);
        }
        public ParametrosInyeccion PRO_Parametros_Obtener()
        {
            return new InyeccionDA().PRO_Parametros_Obtener();
        }
    }
}
