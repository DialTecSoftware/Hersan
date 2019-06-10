using Hersan.Datos.CapitalHumano;
using Hersan.Entidades.CapitalHumano;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hersan.Negocio.CapitalHumano
{
   public class EvaluacionInduccionBP
    {
        public List<EvaluacionInduccionBE> CHU_DatosEMP_Obtener(EvaluacionInduccionBE evaluacion)
        {
            return new EvaluacionInduccionDA().CHU_DatosEMP_Obtener(evaluacion);
        }

        public List<EvaluacionInduccionBE> CHU_EvaluacionInduccion_Obtener()
        { 
        
            return new EvaluacionInduccionDA().CHU_EvaluacionInduccion_Obtener();
        }
        public List<PreguntasEvaluacionBE> CHU_ObtenerPreguntas()
        {

            return new EvaluacionInduccionDA().CHU_ObtenerPreguntas();
        }

        public int CHU_EvaluacionInduccion_Guardar(DataSet Tablas, int IdUsuario)
        {
            return new EvaluacionInduccionDA().CHU_EvaluacionInduccion_Guardar(Tablas,IdUsuario);
        }
        public DataTable CHU_Evaluacion_ReporteDetalle(int Id)
        {
            return new EvaluacionInduccionDA().CHU_Evaluacion_ReporteDetalle(Id);
        }
    }
}
