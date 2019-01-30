using Hersan.Catalogos.Contract;
using Hersan.Entidades.CapitalHumano;
using Hersan.Entidades.Catalogos;
using Hersan.Negocio.CapitalHumano;
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
        public List<DepartamentosBE> ABCDepartamentos_Combo()
        {
            return new DepartamentosBP().ABCDepartamentos_Combo();
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
        #endregion

    }
}
