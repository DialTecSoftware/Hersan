using Hersan.Entidades.CapitalHumano;
using Hersan.Entidades.Comun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hersan.Entidades.Nomina {
    public class IncidenciasBE 
    {
        public IncidenciasBE()
        {
            Sel = false;
            Semana = new SemanasBE();
            Empleado = new EmpleadosBE();
            Faltas = 0;
            Retardos = 0;
            Bono = 0;
            Extra = 0;
            Fonacot = false;
            DatosUsuario = new GeneralBE();
        }

        public bool Sel { get; set; }
        public SemanasBE Semana { get; set; }
        public EmpleadosBE Empleado { get; set; }
        public int Faltas { get; set; }
        public int Retardos { get; set; }
        public decimal Bono { get; set; }
        public int Extra { get; set; }
        public bool Fonacot { get; set; }
        public bool Supervisor { get; set; }
        public bool Operador { get; set; }
        public int Horas { get; set; }
        public GeneralBE DatosUsuario { get; set; }

    }
}
