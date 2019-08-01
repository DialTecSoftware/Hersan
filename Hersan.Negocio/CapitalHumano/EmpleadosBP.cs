using Hersan.Datos.CapitalHumano;
using Hersan.Entidades.CapitalHumano;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hersan.Negocio.CapitalHumano
{
   public class EmpleadosBP
        
    {
        public List<EmpleadosBE> CHU_Empleados_Consultar(int IdExp)
        {
            return new EmpleadosDA().CHU_Empleados_Consultar(IdExp);
        }
        public int CHUEmpleados_Guardar(EmpleadosBE obj)
        {
            return new EmpleadosDA().CHUEmpleados_Guardar( obj);
        }
        public int CHU_EmpleadosActualizar(EmpleadosBE obj)
        {
            return new EmpleadosDA().CHU_EmpleadosActualizar(obj);
        }
        public int CHU_Empleados_Elimina(int IdEmp, int IdUsuario)
        {
            return new EmpleadosDA().CHU_Empleados_Elimina(IdEmp, IdUsuario);
        }
        public DataTable CHU_Empleados_Credencial(int IdExpediente)
        {
            return new EmpleadosDA().CHU_Empleados_Credencial(IdExpediente);
        }
        public List<EmpleadosBE> CHU_Empleados_Combo()
        {
            return new EmpleadosDA().CHU_Empleados_Combo();
        }
    }
}
