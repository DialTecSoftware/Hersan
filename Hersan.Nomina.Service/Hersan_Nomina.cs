using Hersan.Entidades.Nomina;
using Hersan.Negocio.Nomina;
using Hersan.Nomina.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hersan.Nomina.Service
{
    public class Hersan_Nomina: IHersan_Nomina
    {
        public List<FactoresBE> Nom_Factores_Obtener()
        {
            return new FactoresBP().Nom_Factores_Obtener();
        }
        public List<SubsidiosBE> NOM_Subsidios_Obtener()
        {
            return new FactoresBP().NOM_Subsidios_Obtener();
        }
        public List<ISRBE> NOM_ISR_Semanal_Obtener()
        {
            return new FactoresBP().NOM_ISR_Semanal_Obtener();
        }
        public List<SemanasBE> NOM_Semanas_Obtener(int Anio)
        {
            return new FactoresBP().NOM_Semanas_Obtener(Anio);
        }
        public int NOM_Semanas_generar(int Anio)
        {
            return new FactoresBP().NOM_Semanas_generar(Anio);
        }
    }
}
