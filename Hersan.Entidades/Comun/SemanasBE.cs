using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hersan.Entidades.Comun
{
    public class SemanasBE
    {

        public SemanasBE()
        {
            Semana = 0;
            Inicia = DateTime.Today;
            Termina = DateTime.Today;
        }

        public int Semana { get; set; }
        public DateTime Inicia { get; set; }
        public DateTime Termina { get; set; }
    }
}
