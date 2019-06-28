using Hersan.Catalogos.Contract;
using Hersan.Entidades.CapitalHumano;
using Hersan.Entidades.Catalogos;
using Hersan.Negocio.CapitalHumano;
using Hersan.Negocio.Catalogos;
using System.Collections.Generic;
using System.Data;
using System.Xml;

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
        public List<DepartamentosBE> ABCDepartamentos_Combo(int IdEntidad)
        {
            return new DepartamentosBP().ABCDepartamentos_Combo(IdEntidad);
        }
        #endregion

        #region TiposContrato
        public List<TiposContratoBE> TiposContrato_Obtener()
        {
            return new TiposContratoBP().TiposContrato_Obtener();
        }
        public List<TiposContratoBE> ABCTiposcontrato_Combo()
        {
            return new TiposContratoBP().ABCTiposcontrato_Combo();
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
        public int ABCPuestos_Guardar(PuestosBE obj)
        {
            return new PuestosBP().ABCPuestos_Guardar(obj);
        }
        public int ABCPuestos_Actualizar(PuestosBE obj)
        {
            return new PuestosBP().ABCPuestos_Actualizar(obj);
        }
        public List<PuestosBE> ABCPuestos_Combo(int IdDepto)
        {
            return new PuestosBP().ABCPuestos_Combo(IdDepto);
        }
        public List<PuestosBE> CHUPuestos_Puntos(int idPuesto)
        {
            return new PuestosBP().CHUPuestos_Puntos(idPuesto);
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
        public List<CompetenciasBE> ABCCompetencias_Combo()
        {
            return new CompetenciasBP().ABCCompetencias_Combo();
        }
        #endregion

        #region Entidades
        public List<EntidadesBE> Entidades_Obtener()
        {
            return new EntidadesBP().Entidades_Obtener();
        }
        public int ABCEntidades_Guardar(EntidadesBE obj)
        {
            return new EntidadesBP().ABCEntidades_Guardar(obj);
        }
        public int ABCEntidades_Actualizar(EntidadesBE obj)
        {
            return new EntidadesBP().ABCEntidades_Actualizar(obj);
        }
        public List<EntidadesBE> Entidades_Combo(int IdEmpresa)
        {
            return new EntidadesBP().Entidades_Combo(IdEmpresa);
        }
        #endregion

        #region Educacion
        public List<EducacionBE> ABCEducacion_Obtener()
        {
            return new EducacionBP().ABCEducacion_Obtener();
        }
        public int ABCEducacion_Guardar(EducacionBE obj)
        {
            return new EducacionBP().ABCEducacion_Guardar(obj);
        }
        public int ABCEducacion_Actualizar(EducacionBE obj)
        {
            return new EducacionBP().ABCEducacion_Actualizar(obj);
        }
        public List<EducacionBE> ABCEducacion_Combo()
        {
            return new EducacionBP().ABCEducacion_Combo();
        }
        #endregion

        #region Funciones
        public List<FuncionesBE> ABCFunciones_Obtener()
        {
            return new FuncionesBP().ABCFunciones_Obtener();
        }
        public int ABCFunciones_Guardar(FuncionesBE obj)
        {
            return new FuncionesBP().ABCFunciones_Guardar(obj);
        }
        public int ABCFunciones_Actualizar(FuncionesBE obj)
        {
            return new FuncionesBP().ABCFunciones_Actualizar(obj);
        }
        public List<FuncionesBE> ABCFunciones_Combo()
        {
            return new FuncionesBP().ABCFunciones_Combo();
        }
        #endregion

        #region Contactos
        public List<ContactosBE> ABCContactos_Obtener()
        {
            return new ContactosBP().ABCContactos_Obtener();
        }
        public int ABCContactos_Guardar(ContactosBE obj)
        {
            return new ContactosBP().ABCContactos_Guardar(obj);
        }
        public int ABCContactos_Actualizar(ContactosBE obj)
        {
            return new ContactosBP().ABCContactos_Actualizar(obj);
        }
        public List<ContactosBE> ABCContactos_Combo()
        {
            return new ContactosBP().ABCContactos_Combo();
        }
        #endregion

        #region EquipoHerramientas
        public List<EquipoHerramientasBE> ABCEquipoHerramientas_Obtener()
        {
            return new EquipoHerramientasBP().ABCEquipoHerramientas_Obtener();
        }
        public int ABCEquipoHerramientas_Guardar(EquipoHerramientasBE obj)
        {
            return new EquipoHerramientasBP().ABCEquipoHerramientas_Guardar(obj);
        }
        public int ABCEquipoHerramientas_Actualizar(EquipoHerramientasBE obj)
        {
            return new EquipoHerramientasBP().ABCEquipoHerramientas_Actualizar(obj);
        }
        #endregion

        #region Contratos
        public List<ContratosBE> ABCContratos_Obtener()
        {
            return new ContratosBP().ABCContratos_Obtener();
        }
        public int ABCContratos_Actualizar(ContratosBE obj)
        {
            return new ContratosBP().ABCContratos_Actualizar(obj);
        }
        public int ABCContratos_Guardar(ContratosBE obj)
        {
            return new ContratosBP().ABCContratos_Guardar(obj);
        }
        #endregion

        #region Documentos
        public List<DocumentosBE> ABCDocumentos_Obtener()
        {
            return new DocumentosBP().ABCDocumentos_Obtener();
        }
        public int ABCDocumentos_Guardar(DocumentosBE obj)
        {
            return new DocumentosBP().ABCDocumentos_Guardar(obj);
        }
        public int ABCDocumentos_Actualizar(DocumentosBE obj)
        {
            return new DocumentosBP().ABCDocumentos_Actualizar(obj);
        }
        public List<DocumentosBE> ABCDocumentos_Combo()
        {
            return new DocumentosBP().ABCDocumentos_Combo();
        }
        #endregion

        #region Organigrama
        public List<OrganigramaBE> CHUOrganigrama_Obtener()
        {
            return new OrganigramaBP().CHUOrganigrama_Obtener();
        }
        public int CHUOrganigrama_Guardar(OrganigramaBE obj)
        {
            return new OrganigramaBP().CHUOrganigrama_Guardar(obj);
        }
        public DataSet CHU_OrganigramaXML_Obtener(int parent)
        {
            return new OrganigramaBP().CHU_OrganigramaXML_Obtener(parent);
        }
        public DataSet CHU_Perfiles_Obtener(int IdDepto, int IdPuesto)
        {
            return new PerfilesBP().CHU_Perfiles_Obtener(IdDepto, IdPuesto);
        }
        public int CHUOrganigrama_Actualizar(OrganigramaBE obj)
        {
            return new OrganigramaBP().CHUOrganigrama_Actualizar(obj);
        }
        #endregion

        #region Estados
        public List<EstadosBE> ABCEstados_Obtener(int IdPais)
        {
            return new EstadosBP().ABCEstados_Obtener(IdPais);
        }
        #endregion

        #region Ciudades
        public List<CiudadesBE> ABCCiudades_Obtener(int IdEstado)
        {
            return new CiudadesBP().ABCCiudades_Obtener(IdEstado);
        }
        #endregion

        #region Colonias
        public List<ColoniasBE> ABCColonias_Obtener(int IdEstado, int IdCiudad)
        {
            return new ColoniasBP().ABCColonias_Obtener(IdEstado, IdCiudad);
        }
        #endregion

        #region Familias
        public int ENS_Familias_Guardar(FamiliasBE obj)
        {
            return new FamiliasBP().ENS_Familias_Guardar(obj);
        }
        public int ENS_Familias_Actualizar(FamiliasBE obj)
        {
            return new FamiliasBP().ENS_Familias_Actualizar(obj);
        }
        public List<FamiliasBE> ENS_Familias_Combo(int IdEntidad)
        {
            return new FamiliasBP().ENS_Familias_Combo(IdEntidad);
        }
        public List<FamiliasBE> ENS_Familias_Obtener()
        {
            return new FamiliasBP().ENS_Familias_Obtener();
        }
        #endregion

        #region Colores
        public int ABC_Colores_Guardar(ColoresBE obj)
        {
            return new ColoresBP().ABC_Colores_Guardar(obj);
        }
        public int ABC_Colores_Actualizar(ColoresBE obj)
        {
            return new ColoresBP().ABC_Colores_Actualizar(obj);
        }
        public List<ColoresBE> ABC_Colores_Obtener()
        {
            return new ColoresBP().ABC_Colores_Obtener();
        }
        public List<ColoresBE> ABC_Colores_Combo()
        {
            return new ColoresBP().ABC_Colores_Combo();
        }
        #endregion

        #region Reflejantes
        public int ENS_Reflejantes_Guardar(ReflejantesBE obj)
        {
            return new ReflejantesBP().ENS_Reflejantes_Guardar(obj);
        }
        public int ENS_Reflejantes_Actualizar(ReflejantesBE obj)
        {
            return new ReflejantesBP().ENS_Reflejantes_Actualizar(obj);
        }
        public List<ReflejantesBE> ENS_Reflejantes_Obtener()
        {
            return new ReflejantesBP().ENS_Reflejantes_Obtener();
        }
        public List<ReflejantesBE> ENS_Reflejantes_Combo()
        {
            return new ReflejantesBP().ENS_Reflejantes_Combo();
        }
        #endregion

        #region TipoProducto
        public int ENS_TipoProducto_Guardar(TipoProductoBE obj)
        {
            return new TipoProductoBP().ENS_TipoProducto_Guardar(obj);
        }
        public int ENS_TipoProducto_Actualizar(TipoProductoBE obj)
        {
            return new TipoProductoBP().ENS_TipoProducto_Actualizar(obj);
        }
        public List<TipoProductoBE> ENS_TipoProducto_Obtener()
        {
            return new TipoProductoBP().ENS_TipoProducto_Obtener();
        }
        public List<TipoProductoBE> ENS_TipoProducto_Combo(int IdFamilia)
        {
            return new TipoProductoBP().ENS_TipoProducto_Combo(IdFamilia);
        }
        #endregion

        #region Accesorios
        public int ENS_Accesorios_Guardar(AccesoriosBE obj)
        {
            return new AccesoriosBP().ENS_Accesorios_Guardar(obj);
        }
        public int ENS_Accesorios_Actualizar(AccesoriosBE obj)
        {
            return new AccesoriosBP().ENS_Accesorios_Actualizar(obj);
        }
        public List<AccesoriosBE> ENS_Accesorios_Obtener()
        {
            return new AccesoriosBP().ENS_Accesorios_Obtener();
        }
        public List<AccesoriosBE> ENS_Accesorios_Combo()
        {
            return new AccesoriosBP().ENS_Accesorios_Combo();
        }
        public List<AccesoriosBE> ENS_AccesoriosCotizacion_Combo(int IdFicha)
        {
            return new AccesoriosBP().ENS_AccesoriosCotizacion_Combo(IdFicha);
        }
        #endregion

        #region Tipos de Cliente
        public int ABC_TipoCliente_Guardar(TiposClienteBE obj)
        {
            return new TiposClienteBP().ABC_TipoCliente_Guardar(obj);
        }
        public int ABC_TipoCliente_Actualizar(TiposClienteBE obj)
        {
            return new TiposClienteBP().ABC_TipoCliente_Actualizar(obj);
        }
        public List<TiposClienteBE> ABC_TipoCliente_Obtener()
        {
            return new TiposClienteBP().ABC_TipoCliente_Obtener();
        }
        public List<TiposClienteBE> ABC_TipoCliente_Combo()
        {
            return new TiposClienteBP().ABC_TipoCliente_Combo();
        }
        #endregion

        #region Agentes
        public List<AgentesBE> ABC_Agentes_Obtener()
        {
            return new AgentesBP().ABC_Agentes_Obtener();
        }
        public int ABC_Agentes_Guardar(AgentesBE obj)
        {
            return new AgentesBP().ABC_Agentes_Guardar(obj);
        }
        public int ABC_Agentes_Actualizar(AgentesBE obj)
        {
            return new AgentesBP().ABC_Agentes_Actualizar(obj);
        }
        public List<AgentesBE> ABC_Agentes_Combo()
        {
            return new AgentesBP().ABC_Agentes_Combo();
        }
        #endregion

        #region Condiciones Venta
        public int ABC_CondicionesExportacion_Guardar(CondicionesExpBE obj)
        {
            return new CondicionesExpBP().ABC_CondicionesExportacion_Guardar(obj);
        }
        public int ABC_CondicionesExportacion_Actualizar(CondicionesExpBE obj)
        {
            return new CondicionesExpBP().ABC_CondicionesExportacion_Actualizar(obj);
        }
        public List<CondicionesExpBE> ABC_CondicionesExportacion_Obtener()
        {
            return new CondicionesExpBP().ABC_CondicionesExportacion_Obtener();
        }
        public List<CondicionesExpBE> ABC_CondicionesExportacion_Combo()
        {
            return new CondicionesExpBP().ABC_CondicionesExportacion_Combo();
        }
        #endregion

        #region Monedas
        public List<MonedasBE> ABC_Monedas_Obtener()
        {
            return new MonedasBP().ABC_Monedas_Obtener();
        }
        public int ABC_Monedas_Guardar(MonedasBE obj)
        {
            return new MonedasBP().ABC_Monedas_Guardar(obj);
        }
        public int ABC_Monedas_Actualizar(MonedasBE obj)
        {
            return new MonedasBP().ABC_Monedas_Actualizar(obj);
        }
        public List<MonedasBE> ABC_Monedas_Combo()
        {
            return new MonedasBP().ABC_Monedas_Combo();
        }
        #endregion
    }
}


