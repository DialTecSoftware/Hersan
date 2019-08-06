using Hersan.Datos.Nomina;
using Hersan.Entidades.Nomina;
using System.Collections.Generic;

namespace Hersan.Negocio.Nomina
{
    public class ParametrosBP
    {
        public ParametrosBE Nom_Parametros_Obtener()
        {
            return new ParametrosDA().Nom_Parametros_Obtener();
        }
        public int Nom_Parametros_Guardar(ParametrosBE item)
        {
            return new ParametrosDA().Nom_Parametros_Guardar(item);
        }
    }
}
