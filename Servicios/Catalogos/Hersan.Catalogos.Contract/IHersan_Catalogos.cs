using Hersan.Entidades.CapitalHumano;
using Hersan.Entidades.Catalogos;
using System.Collections.Generic;
using System.ServiceModel;

namespace Hersan.Catalogos.Contract
{
    [ServiceContract]
    public interface IHersan_Catalogos
    {
        #region Empresas
        [OperationContract]
        List<EmpresasBE> ABCEmpresas_Obtener(int IdEmpresa);

        [OperationContract]
        List<EmpresasBE> ABCEmpresas_Cbo();
        #endregion

        #region Deptos
        [OperationContract]
        List<DepartamentosBE> ABCDepartamentos_Obtener();

        [OperationContract]
        int ABCDEpartamentos_Guardar(DepartamentosBE obj);

        [OperationContract]
        int ABCDEpartamentos_Actualizar(DepartamentosBE obj);

        [OperationContract]
        List<DepartamentosBE> ABCDepartamentos_Combo();
        #endregion

        #region TiposContrato
        [OperationContract]
        List<TiposContratoBE> TiposContrato_Obtener();

        [OperationContract]
        int ABCTiposContrato_Guardar(TiposContratoBE obj);

        [OperationContract]
        int ABCTiposContrato_Actualizar(TiposContratoBE obj);

        #endregion

        #region Puestos
        [OperationContract]
        List<PuestosBE> ABCPuestos_Obtener();
        [OperationContract]
        int ABCPuestos_Guardar(PuestosBE obj);
        [OperationContract]
        int ABCPuestos_Actualizar(PuestosBE obj);
        #endregion

        #region Competencias
        [OperationContract]
        List<CompetenciasBE> ABCCompetencias_Obtener();

        [OperationContract]
        int ABC_Competencias_Guardar(CompetenciasBE obj);

        [OperationContract]
        int ABCCompetencias_Actualizar(CompetenciasBE obj);

        #endregion

        #region Entidades
        [OperationContract]
        List<EntidadesBE> Entidades_Obtener();
        [OperationContract]
        int ABCEntidades_Guardar(EntidadesBE obj);
        [OperationContract]
        int ABCEntidades_Actualizar(EntidadesBE obj);

        #endregion

        #region Educacion
        [OperationContract]
        List<EducacionBE> ABCEducacion_Obtener();
        [OperationContract]
        int ABCEducacion_Guardar(EducacionBE obj);
        [OperationContract]
        int ABCEducacion_Actualizar(EducacionBE obj);

        #endregion

        #region Funciones
        [OperationContract]
        List<FuncionesBE> ABCFunciones_Obtener();
        //[OperationContract]
        //int ABCEducacion_Guardar(EducacionBE obj);
        //[OperationContract]
        //int ABCEducacion_Actualizar(EducacionBE obj);

        #endregion

    }
}
