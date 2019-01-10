using Hersan.Catalogos.Contract;
using Hersan.Entidades.Catalogos;
using Hersan.Negocio.Catalogos;
using System.Collections.Generic;

namespace Hersan.Catalogos.Service
{
    public class Hersan_Catalogos : IHersan_Catalogos
    {
        #region Empresas
        public List<EmpresasBE> ABCEmpresas_Obtener(int IdEmpresa)
        {
            return new EmpresasBP().ABCEmpresas_Obtener(IdEmpresa);
        }
        public List<EmpresasBE> ABCEmpresas_Cbo()
        {
            return new EmpresasBP().ABCEmpresas_Cbo();
        }
        #endregion

        #region Deptos
        public List<DepartamentosBE> ABCDepartamentos_Obtener()
        {
            return new DepartamentosBP().ABCDepartamentos_Obtener();
        }
        #endregion

        #region Deptos
        public List<TiposContratoBE> TiposContrato_Obtener()
        {
            return new TiposContratoBP().TiposContrato_Obtener();
        }
        #endregion

        #region Puestos
        public List<PuestosBE> ABCPuestos_Obtener()
        {
            return new PuestosBP().ABCPuestos_Obtener();
        }
        #endregion

    
    }
}
