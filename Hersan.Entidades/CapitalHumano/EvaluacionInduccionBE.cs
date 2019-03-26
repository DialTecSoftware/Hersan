using Hersan.Entidades.Catalogos;
using Hersan.Entidades.Comun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hersan.Entidades.CapitalHumano
{
      public   class EvaluacionInduccionBE
    {

        public EvaluacionInduccionBE()
        {
            Id = 0;
            Calificacion = 0;
            Observaciones = string.Empty;
            IdEmpleado = 0;
            Count = 0;
            DatosPersonales = new ExpedientesDatosPersonales();
            Puestos = new PuestosBE();
            Departamentos = new DepartamentosBE();
            DatosUsuario = new GeneralBE();
        }
        public int Id { get; set; }
        public int Count { get; set; }
        public decimal Calificacion { get; set; }
        public string Observaciones { get; set; }
        public int  IdEmpleado { get; set; }
        public ExpedientesDatosPersonales DatosPersonales { get; set; }
        public PuestosBE Puestos { get; set; }
        public DepartamentosBE Departamentos { get; set; }
        public GeneralBE DatosUsuario { get; set; }
        public List<PreguntasEvaluacionBE> Preguntas { get; set; }




    }

    public class PreguntasEvaluacionBE
    {
        public PreguntasEvaluacionBE()
        {
            Id = 0;
            Pregunta = string.Empty;
            Valor1 = false;
            Valor2 = false;
            Valor3 = false;
            Valor4 = false;

        }
        public int Id { get; set; }
        public string  Pregunta { get; set; }
        public bool Valor4 { get; set; }
        public bool Valor3 { get; set; }
        public bool Valor2 { get; set; }
        public bool Valor1 { get; set; }
    }
   

}
