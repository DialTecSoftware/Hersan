using Hersan.Datos.Catalogos;
using Hersan.Entidades.Catalogos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hersan.Negocio.Catalogos
{
    public class DepartamentosBP
    {
        public List<DepartamentosBE> ABCDepartamentos_Obtener()
        {
            return new DepartamentosDA().ABCDepartamentos_Obtener();
        }
        public int ABCDEpartamentos_Guardar(DepartamentosBE obj)
        {
            return new DepartamentosDA().ABCDEpartamentos_Guardar(obj);
        }
        public int ABCDEpartamentos_Actualizar(DepartamentosBE obj)
        {
            return new DepartamentosDA().ABCDEpartamentos_Actualizar(obj);
        }
        public List<DepartamentosBE> ABCDepartamentos_Combo(int IdEntidad)
        {
            return new DepartamentosDA().ABCDepartamentos_Combo(IdEntidad);
        }
    }
}
