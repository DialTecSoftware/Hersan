using Hersan.Datos.Nomina;
using Hersan.Entidades.Nomina;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hersan.Negocio.Nomina
{
    public class FactoresBP
    {
        public List<FactoresBE> Nom_Factores_Obtener()
        {
            return new FactoresDA().Nom_Factores_Obtener();
        }
        public List<SubsidiosBE> NOM_Subsidios_Obtener()
        {
            return new FactoresDA().NOM_Subsidios_Obtener();
        }
        public List<ISRBE> NOM_ISR_Semanal_Obtener()
        {
            return new FactoresDA().NOM_ISR_Semanal_Obtener();
        }
        public List<SemanasBE> NOM_Semanas_Obtener(int Anio)
        {
            return new FactoresDA().NOM_Semanas_Obtener(Anio);
        }
        public int NOM_Semanas_generar(int Anio)
        {
            return new FactoresDA().NOM_Semanas_generar(Anio);
        }
        public List<CuotasBE> NOM_Cuotas_Obtener()
        {
            return new FactoresDA().NOM_Cuotas_Obtener();
        }
    }
}
