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
        List<TiposContratoBE> ABCTiposcontrato_Combo();
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
        [OperationContract]
        List<PuestosBE> ABCPuestos_Combo(int IdDepto);
        #endregion

        #region Competencias
        [OperationContract]
        List<CompetenciasBE> ABCCompetencias_Obtener();

        [OperationContract]
        int ABC_Competencias_Guardar(CompetenciasBE obj);

        [OperationContract]
        int ABCCompetencias_Actualizar(CompetenciasBE obj);

        [OperationContract]
        List<CompetenciasBE> ABCCompetencias_Combo();
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
        [OperationContract]
        List<EducacionBE> ABCEducacion_Combo();
        #endregion

        #region Funciones
        [OperationContract]
        List<FuncionesBE> ABCFunciones_Obtener();
        [OperationContract]
        int ABCFunciones_Guardar(FuncionesBE obj);
        [OperationContract]
        int ABCFunciones_Actualizar(FuncionesBE obj);

        #endregion

        #region Contactos
        [OperationContract]
        List<ContactosBE> ABCContactos_Obtener();
        [OperationContract]
        int ABCContactos_Guardar(ContactosBE obj);
        [OperationContract]
        int ABCContactos_Actualizar(ContactosBE obj);

        #endregion

        #region EquipoHerramientas
        [OperationContract]
        List<EquipoHerramientasBE> ABCEquipoHerramientas_Obtener();
        [OperationContract]
        int ABCEquipoHerramientas_Guardar(EquipoHerramientasBE obj);
        [OperationContract]
        int ABCEquipoHerramientas_Actualizar(EquipoHerramientasBE obj);

        #endregion

        #region Contratos
        [OperationContract]
        List<ContratosBE> ABCContratos_Obtener();
        [OperationContract]
        int ABCContratos_Actualizar(ContratosBE obj);
        [OperationContract]
        int ABCContratos_Guardar(ContratosBE obj);

        #endregion

        #region Documentos
        [OperationContract]
        List<DocumentosBE> ABCDocumentos_Obtener();
        [OperationContract]
        int ABCDocumentos_Guardar(DocumentosBE obj);
        [OperationContract]
        int ABCDocumentos_Actualizar(DocumentosBE obj);

        #endregion
    }
}
