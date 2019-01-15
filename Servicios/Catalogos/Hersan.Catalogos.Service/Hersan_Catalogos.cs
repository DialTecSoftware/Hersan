using Hersan.Catalogos.Contract;
using Hersan.Entidades.CapitalHumano;
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
        public int ABCDEpartamentos_Guardar(DepartamentosBE obj)
        {
            return new DepartamentosBP().ABCDEpartamentos_Guardar(obj);
        }
        public int ABCDEpartamentos_Actualizar(DepartamentosBE obj)
        {
            return new DepartamentosBP().ABCDEpartamentos_Actualizar(obj);
        }
        #endregion

        #region TiposContrato
        public List<TiposContratoBE> TiposContrato_Obtener()
        {
            return new TiposContratoBP().TiposContrato_Obtener();
        }
        public int ABCTiposContrato_Guardar(TiposContratoBE obj)
        {
            return new TiposContratoBP().ABCTiposContrato_Guardar(obj);
        }

        public int ABCTiposContrato_Actualizar(TiposContratoBE obj)
        {
            return new TiposContratoBP().ABCTiposContrato_Actualizar(obj);
        }
        #endregion

        #region Puestos
        public List<PuestosBE> ABCPuestos_Obtener()
        {
            return new PuestosBP().ABCPuestos_Obtener();
        }
        #endregion

         #region Competencias
        public List<CompetenciasBE> ABCCompetencias_Obtener()
        {
            return new CompetenciasBP().ABCCompetencias_Obtener();
        }

        public int ABC_Competencias_Guardar(CompetenciasBE obj)
        {
            return new CompetenciasBP().ABC_Competencias_Guardar(obj);
        }

        public int ABCCompetencias_Actualizar(CompetenciasBE obj)
        {
            return new CompetenciasBP().ABCCompetencias_Actualizar(obj);
        }
        #endregion



    }
}
