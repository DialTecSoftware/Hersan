using Hersan.Catalogos.Contract;
using Hersan.Entidades.Catalogos;
using Hersan.Negocio.Catalogos;
using System.Collections.Generic;

namespace Hersan.Catalogos.Service
{
    public class Hersan_Catalogos : IHersan_Catalogos
    {
        public List<EmpresasBE> ABCEmpresas_Obtener(int IdEmpresa)
        {
            return new EmpresasBP().ABCEmpresas_Obtener(IdEmpresa);
        }
        public List<EmpresasBE> ABCEmpresas_Cbo()
        {
            return new EmpresasBP().ABCEmpresas_Cbo();
        }

    }
}
