using Hersan.Entidades.CapitalHumano;
using Hersan.Entidades.Catalogos;
using System;
using System.Collections.Generic;
using System.Data;
using System.ServiceModel;
using System.Xml;

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
        List<DepartamentosBE> ABCDepartamentos_Combo(int IdEntidad);
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
        [OperationContract]
        List<PuestosBE> CHUPuestos_Puntos(int idPuesto);
        [OperationContract]
        List<PuestosBE> CH_TramoControl_Obtener(int idPuesto);
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
        [OperationContract]
        List<EntidadesBE> Entidades_Combo(int IdEmpresa);
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
        [OperationContract]
        List<FuncionesBE> ABCFunciones_Combo();
        #endregion

        #region Contactos
        [OperationContract]
        List<ContactosBE> ABCContactos_Obtener();
        [OperationContract]
        int ABCContactos_Guardar(ContactosBE obj);
        [OperationContract]
        int ABCContactos_Actualizar(ContactosBE obj);
        [OperationContract]
        List<ContactosBE> ABCContactos_Combo();

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
        [OperationContract]
        List<DocumentosBE> ABCDocumentos_Combo();

        #endregion

        #region Organigrama
        [OperationContract]
        List<OrganigramaBE> CHUOrganigrama_Obtener();
        [OperationContract]
        int CHUOrganigrama_Guardar(OrganigramaBE obj);
        [OperationContract]
        int CHUOrganigrama_Actualizar(OrganigramaBE obj);
        //[OperationContract, XmlSerializerFormat]
        [OperationContract]
        Byte[] CHU_OrganigramaXML_Obtener(int parent);
        #endregion

        #region Estados
        [OperationContract]
        List<EstadosBE> ABCEstados_Obtener(int IdPais);
        #endregion

        #region Ciudades
        [OperationContract]
        List<CiudadesBE> ABCCiudades_Obtener(int IdEstado);
        #endregion

        #region Colonias
        [OperationContract]
        List<ColoniasBE> ABCColonias_Obtener(int IdEstado, int IdCiudad);
        #endregion

        #region Familias
        [OperationContract]
        int ENS_Familias_Guardar(FamiliasBE obj);
        [OperationContract]
        int ENS_Familias_Actualizar(FamiliasBE obj);
        [OperationContract]
        List<FamiliasBE> ENS_Familias_Obtener();
        [OperationContract]
        List<FamiliasBE> ENS_Familias_Combo(int IdEntidad);
        #endregion

        #region Colores
        [OperationContract]
        int ABC_Colores_Guardar(ColoresBE obj);
        [OperationContract]
        int ABC_Colores_Actualizar(ColoresBE obj);
        [OperationContract]
        List<ColoresBE> ABC_Colores_Obtener();
        [OperationContract]
        List<ColoresBE> ABC_Colores_Combo();
        #endregion

        #region Reflejantes
        [OperationContract]
        int ENS_Reflejantes_Guardar(ReflejantesBE obj);
        [OperationContract]
        int ENS_Reflejantes_Actualizar(ReflejantesBE obj);
        [OperationContract]
        List<ReflejantesBE> ENS_Reflejantes_Obtener();
        [OperationContract]
        List<ReflejantesBE> ENS_Reflejantes_Combo();
        #endregion

        #region TipoProducto
        [OperationContract]
        int ENS_TipoProducto_Guardar(TipoProductoBE obj);
        [OperationContract]
        int ENS_TipoProducto_Actualizar(TipoProductoBE obj);
        [OperationContract]
        List<TipoProductoBE> ENS_TipoProducto_Obtener();
        [OperationContract]
        List<TipoProductoBE> ENS_TipoProducto_Combo(int IdFamilia);
        #endregion

        #region Accesorios
        [OperationContract]
        int ENS_Accesorios_Guardar(AccesoriosBE obj);
        [OperationContract]
        int ENS_Accesorios_Actualizar(AccesoriosBE obj);
        [OperationContract]
        List<AccesoriosBE> ENS_Accesorios_Obtener();
        [OperationContract]
        List<AccesoriosBE> ENS_Accesorios_Combo();
        [OperationContract]
        List<AccesoriosBE> ENS_AccesoriosCotizacion_Combo(int IdFicha);
        #endregion

        #region Tipos de Clientes
        [OperationContract]
        int ABC_TipoCliente_Guardar(TiposClienteBE obj);
        [OperationContract]
        int ABC_TipoCliente_Actualizar(TiposClienteBE obj);
        [OperationContract]
        List<TiposClienteBE> ABC_TipoCliente_Obtener();
        [OperationContract]
        List<TiposClienteBE> ABC_TipoCliente_Combo();
        #endregion

        #region Agentes
        [OperationContract]
        List<AgentesBE> ABC_Agentes_Obtener();
        [OperationContract]
        int ABC_Agentes_Guardar(AgentesBE obj);
        [OperationContract]
        int ABC_Agentes_Actualizar(AgentesBE obj);
        [OperationContract]
        List<AgentesBE> ABC_Agentes_Combo();
        #endregion

        #region Condiciones Venta
        [OperationContract]
        int ABC_CondicionesExportacion_Guardar(CondicionesExpBE obj);
        [OperationContract]
        int ABC_CondicionesExportacion_Actualizar(CondicionesExpBE obj);
        [OperationContract]
        List<CondicionesExpBE> ABC_CondicionesExportacion_Obtener();
        [OperationContract]
        List<CondicionesExpBE> ABC_CondicionesExportacion_Combo();
        #endregion

        #region Monedas
        [OperationContract]
        List<MonedasBE> ABC_Monedas_Obtener();
        [OperationContract]
        int ABC_Monedas_Guardar(MonedasBE obj);
        [OperationContract]
        int ABC_Monedas_Actualizar(MonedasBE obj);
        [OperationContract]
        List<MonedasBE> ABC_Monedas_Combo();
        #endregion
    }
}
