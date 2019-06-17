using Hersan.Datos.Relchec;
using Hersan.Entidades.Relchec;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hersan.Negocio.Relchec
{
   public class TrabajadorHorarioBP
    {
        public List<TrabajadorHorarioBE> ABCTrabajadorHorarios_Obtener()
        {
            return new TrabajadorHorarioDA().ABCTrabajadorHorario_Obtener();
        }
        public int ABCTrabajadorHorario_Guarda(TrabajadorHorarioBE obj)
        {
            return new TrabajadorHorarioDA().ABCTrabajadorHorarios_Guarda(obj);
        }
        public int ABCTrabajadorHorario_Actualizar(TrabajadorHorarioBE obj)
        {
            return new TrabajadorHorarioDA().ABCTrabajadorHorarios_Actualizar(obj);
        }
      
    }
}

