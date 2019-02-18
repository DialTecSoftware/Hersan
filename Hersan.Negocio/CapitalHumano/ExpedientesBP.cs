using Hersan.Datos.CapitalHumano;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hersan.Negocio.CapitalHumano
{
    public class ExpedientesBP
    {
        public int CHU_Expedientes_Guardar(DataSet Tablas, int IdUsuario)
        {
            return new ExpedientesDA().CHU_Expedientes_Guardar(Tablas, IdUsuario);
        }
    }
}
