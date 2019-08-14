using Hersan.Datos.Nomina;
using Hersan.Entidades.Nomina;
using System;
using System.Collections.Generic;


namespace Hersan.Negocio.Nomina
{
    public class NominaBP
    {
        public List<NominaBE> NOM_CalculoNomina(int Semana)
        {
            return new NominaDA().NOM_CalculoNomina(Semana);
        }
    }
}
