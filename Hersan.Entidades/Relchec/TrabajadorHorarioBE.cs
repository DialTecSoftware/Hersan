using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hersan.Entidades.CapitalHumano;
using Hersan.Entidades.Comun;

namespace Hersan.Entidades.Relchec
{
   public class TrabajadorHorarioBE
    {
        public TrabajadorHorarioBE()
        {
            Id = 0;
            Horarios  = new HorariosBE();
            Empleados = new EmpleadosBE();
            DatosUsuario = new GeneralBE();


    
        }

        public int Id { get; set; }
        public HorariosBE Horarios { get; set; }
        public EmpleadosBE Empleados { get; set; }
        public GeneralBE DatosUsuario { get; set; }
    }
}
