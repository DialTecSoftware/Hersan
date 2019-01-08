using Hersan.Datos.Catalogos;
using Hersan.Entidades.Catalogos;
using System.Collections.Generic;

namespace Hersan.Negocio.Catalogos
{
    public class EmpresasBP
    {
        public List<EmpresasBE> ABCEmpresas_Obtener(int IdEmpresa)
        {
            return new EmpresasDA().ABCEmpresas_Obtener(IdEmpresa);
        }
        public List<EmpresasBE> ABCEmpresas_Cbo()
        {
            return new EmpresasDA().ABCEmpresas_Cbo();
        }
    }
}
