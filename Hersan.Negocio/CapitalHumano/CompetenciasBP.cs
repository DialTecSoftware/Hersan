using Hersan.Datos.Catalogos;
using Hersan.Entidades.CapitalHumano;
using Hersan.Entidades.Catalogos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hersan.Negocio.Catalogos
{
    public class CompetenciasBP
    {
        public List<CompetenciasBE> ABCCompetencias_Obtener()
        {
            return new CompetenciasDA().ABCCompetencias_Obtener();
        }
        public int ABC_Competencias_Guardar(CompetenciasBE obj)
        {
            return new CompetenciasDA().ABC_Competencias_Guardar(obj);
        }
        public int ABCCompetencias_Actualizar(CompetenciasBE obj)
        {
            return new CompetenciasDA().ABCCompetencias_Actualizar(obj);
        }
    }
}
