using Hersan.Datos.CapitalHumano;
using Hersan.Entidades.CapitalHumano;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hersan.Negocio.CapitalHumano
{
   public class EmpleadosBP
        
    {
        public int CHUEmpleados_Guardar(EmpleadosBE obj)
        {
            return new EmpleadosDA().CHUEmpleados_Guardar( obj);
        }
        public int CHU_EmpleadosActualizar(EmpleadosBE obj)
        {
            return new EmpleadosDA().CHU_EmpleadosActualizar(obj);
        }
        public List<EmpleadosBE> CHU_EMPLEADOS_COMBO()
        {
            return new EmpleadosDA().CHU_EMPLEADOS_COMBO();
        }
    }
}

