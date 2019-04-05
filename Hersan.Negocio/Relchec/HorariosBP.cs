using Hersan.Datos.Relchec;
using Hersan.Entidades.Relchec;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hersan.Negocio.Relchec
{
   public class HorariosBP
    {
        public List<HorariosBE> ABCHorarios_Obtener()
        {
            return new HorariosDa().ABCHorarios_Obtener();
        }
        public int ABCHorarios_Guarda(HorariosBE obj)
        {
            return new HorariosDa().ABCHorarios_Guarda(obj);
        }
        public int ABCHorarios_Actualizar(HorariosBE obj)
        {
            return new HorariosDa().ABCHorarios_Actualiza(obj);
        }
    }
}
