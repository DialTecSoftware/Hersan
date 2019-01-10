using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hersan.Entidades.Catalogos
{
   public class CompetenciasBE
    {
        public CompetenciasBE()
        {
            Id = 0;
            Nombre = string.Empty;
            Abrev = string.Empty;
            Experiencia = 0;
            AniosExp = 0;


        }

        public int  Id { get; set; }
        public string Nombre { get; set; }
        public string Abrev { get; set; }
        public int Experiencia { get; set; }
        public int AniosExp { get; set; }
    }
}
