﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Hersan.UI.Catalogos.WCF_Catalogos {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="WCF_Catalogos.IHersan_Catalogos")]
    public interface IHersan_Catalogos {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Catalogos/ABCEmpresas_Obtener", ReplyAction="http://tempuri.org/IHersan_Catalogos/ABCEmpresas_ObtenerResponse")]
        System.Collections.Generic.List<Hersan.Entidades.Catalogos.EmpresasBE> ABCEmpresas_Obtener(int IdEmpresa);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Catalogos/ABCEmpresas_Cbo", ReplyAction="http://tempuri.org/IHersan_Catalogos/ABCEmpresas_CboResponse")]
        System.Collections.Generic.List<Hersan.Entidades.Catalogos.EmpresasBE> ABCEmpresas_Cbo();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Catalogos/ABCDepartamentos_Obtener", ReplyAction="http://tempuri.org/IHersan_Catalogos/ABCDepartamentos_ObtenerResponse")]
        System.Collections.Generic.List<Hersan.Entidades.Catalogos.DepartamentosBE> ABCDepartamentos_Obtener();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Catalogos/ABCDEpartamentos_Guardar", ReplyAction="http://tempuri.org/IHersan_Catalogos/ABCDEpartamentos_GuardarResponse")]
        int ABCDEpartamentos_Guardar(Hersan.Entidades.Catalogos.DepartamentosBE obj);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Catalogos/ABCDEpartamentos_Actualizar", ReplyAction="http://tempuri.org/IHersan_Catalogos/ABCDEpartamentos_ActualizarResponse")]
        int ABCDEpartamentos_Actualizar(Hersan.Entidades.Catalogos.DepartamentosBE obj);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Catalogos/ABCDepartamentos_Combo", ReplyAction="http://tempuri.org/IHersan_Catalogos/ABCDepartamentos_ComboResponse")]
        System.Collections.Generic.List<Hersan.Entidades.Catalogos.DepartamentosBE> ABCDepartamentos_Combo(int IdEntidad);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Catalogos/TiposContrato_Obtener", ReplyAction="http://tempuri.org/IHersan_Catalogos/TiposContrato_ObtenerResponse")]
        System.Collections.Generic.List<Hersan.Entidades.Catalogos.TiposContratoBE> TiposContrato_Obtener();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Catalogos/ABCTiposcontrato_Combo", ReplyAction="http://tempuri.org/IHersan_Catalogos/ABCTiposcontrato_ComboResponse")]
        System.Collections.Generic.List<Hersan.Entidades.Catalogos.TiposContratoBE> ABCTiposcontrato_Combo();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Catalogos/ABCTiposContrato_Guardar", ReplyAction="http://tempuri.org/IHersan_Catalogos/ABCTiposContrato_GuardarResponse")]
        int ABCTiposContrato_Guardar(Hersan.Entidades.Catalogos.TiposContratoBE obj);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Catalogos/ABCTiposContrato_Actualizar", ReplyAction="http://tempuri.org/IHersan_Catalogos/ABCTiposContrato_ActualizarResponse")]
        int ABCTiposContrato_Actualizar(Hersan.Entidades.Catalogos.TiposContratoBE obj);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Catalogos/ABCPuestos_Obtener", ReplyAction="http://tempuri.org/IHersan_Catalogos/ABCPuestos_ObtenerResponse")]
        System.Collections.Generic.List<Hersan.Entidades.Catalogos.PuestosBE> ABCPuestos_Obtener();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Catalogos/ABCPuestos_Guardar", ReplyAction="http://tempuri.org/IHersan_Catalogos/ABCPuestos_GuardarResponse")]
        int ABCPuestos_Guardar(Hersan.Entidades.Catalogos.PuestosBE obj);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Catalogos/ABCPuestos_Actualizar", ReplyAction="http://tempuri.org/IHersan_Catalogos/ABCPuestos_ActualizarResponse")]
        int ABCPuestos_Actualizar(Hersan.Entidades.Catalogos.PuestosBE obj);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Catalogos/ABCPuestos_Combo", ReplyAction="http://tempuri.org/IHersan_Catalogos/ABCPuestos_ComboResponse")]
        System.Collections.Generic.List<Hersan.Entidades.Catalogos.PuestosBE> ABCPuestos_Combo(int IdDepto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Catalogos/CHUPuestos_Combo", ReplyAction="http://tempuri.org/IHersan_Catalogos/CHUPuestos_ComboResponse")]
        System.Collections.Generic.List<Hersan.Entidades.Catalogos.PuestosBE> CHUPuestos_Combo();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Catalogos/ABCCompetencias_Obtener", ReplyAction="http://tempuri.org/IHersan_Catalogos/ABCCompetencias_ObtenerResponse")]
        System.Collections.Generic.List<Hersan.Entidades.CapitalHumano.CompetenciasBE> ABCCompetencias_Obtener();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Catalogos/ABC_Competencias_Guardar", ReplyAction="http://tempuri.org/IHersan_Catalogos/ABC_Competencias_GuardarResponse")]
        int ABC_Competencias_Guardar(Hersan.Entidades.CapitalHumano.CompetenciasBE obj);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Catalogos/ABCCompetencias_Actualizar", ReplyAction="http://tempuri.org/IHersan_Catalogos/ABCCompetencias_ActualizarResponse")]
        int ABCCompetencias_Actualizar(Hersan.Entidades.CapitalHumano.CompetenciasBE obj);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Catalogos/ABCCompetencias_Combo", ReplyAction="http://tempuri.org/IHersan_Catalogos/ABCCompetencias_ComboResponse")]
        System.Collections.Generic.List<Hersan.Entidades.CapitalHumano.CompetenciasBE> ABCCompetencias_Combo();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Catalogos/Entidades_Obtener", ReplyAction="http://tempuri.org/IHersan_Catalogos/Entidades_ObtenerResponse")]
        System.Collections.Generic.List<Hersan.Entidades.Catalogos.EntidadesBE> Entidades_Obtener();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Catalogos/ABCEntidades_Guardar", ReplyAction="http://tempuri.org/IHersan_Catalogos/ABCEntidades_GuardarResponse")]
        int ABCEntidades_Guardar(Hersan.Entidades.Catalogos.EntidadesBE obj);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Catalogos/ABCEntidades_Actualizar", ReplyAction="http://tempuri.org/IHersan_Catalogos/ABCEntidades_ActualizarResponse")]
        int ABCEntidades_Actualizar(Hersan.Entidades.Catalogos.EntidadesBE obj);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Catalogos/Entidades_Combo", ReplyAction="http://tempuri.org/IHersan_Catalogos/Entidades_ComboResponse")]
        System.Collections.Generic.List<Hersan.Entidades.Catalogos.EntidadesBE> Entidades_Combo(int IdEmpresa);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Catalogos/ABCEducacion_Obtener", ReplyAction="http://tempuri.org/IHersan_Catalogos/ABCEducacion_ObtenerResponse")]
        System.Collections.Generic.List<Hersan.Entidades.Catalogos.EducacionBE> ABCEducacion_Obtener();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Catalogos/ABCEducacion_Guardar", ReplyAction="http://tempuri.org/IHersan_Catalogos/ABCEducacion_GuardarResponse")]
        int ABCEducacion_Guardar(Hersan.Entidades.Catalogos.EducacionBE obj);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Catalogos/ABCEducacion_Actualizar", ReplyAction="http://tempuri.org/IHersan_Catalogos/ABCEducacion_ActualizarResponse")]
        int ABCEducacion_Actualizar(Hersan.Entidades.Catalogos.EducacionBE obj);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Catalogos/ABCEducacion_Combo", ReplyAction="http://tempuri.org/IHersan_Catalogos/ABCEducacion_ComboResponse")]
        System.Collections.Generic.List<Hersan.Entidades.Catalogos.EducacionBE> ABCEducacion_Combo();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Catalogos/ABCFunciones_Obtener", ReplyAction="http://tempuri.org/IHersan_Catalogos/ABCFunciones_ObtenerResponse")]
        System.Collections.Generic.List<Hersan.Entidades.CapitalHumano.FuncionesBE> ABCFunciones_Obtener();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Catalogos/ABCFunciones_Guardar", ReplyAction="http://tempuri.org/IHersan_Catalogos/ABCFunciones_GuardarResponse")]
        int ABCFunciones_Guardar(Hersan.Entidades.CapitalHumano.FuncionesBE obj);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Catalogos/ABCFunciones_Actualizar", ReplyAction="http://tempuri.org/IHersan_Catalogos/ABCFunciones_ActualizarResponse")]
        int ABCFunciones_Actualizar(Hersan.Entidades.CapitalHumano.FuncionesBE obj);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Catalogos/ABCFunciones_Combo", ReplyAction="http://tempuri.org/IHersan_Catalogos/ABCFunciones_ComboResponse")]
        System.Collections.Generic.List<Hersan.Entidades.CapitalHumano.FuncionesBE> ABCFunciones_Combo();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Catalogos/ABCContactos_Obtener", ReplyAction="http://tempuri.org/IHersan_Catalogos/ABCContactos_ObtenerResponse")]
        System.Collections.Generic.List<Hersan.Entidades.Catalogos.ContactosBE> ABCContactos_Obtener();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Catalogos/ABCContactos_Guardar", ReplyAction="http://tempuri.org/IHersan_Catalogos/ABCContactos_GuardarResponse")]
        int ABCContactos_Guardar(Hersan.Entidades.Catalogos.ContactosBE obj);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Catalogos/ABCContactos_Actualizar", ReplyAction="http://tempuri.org/IHersan_Catalogos/ABCContactos_ActualizarResponse")]
        int ABCContactos_Actualizar(Hersan.Entidades.Catalogos.ContactosBE obj);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Catalogos/ABCEquipoHerramientas_Obtener", ReplyAction="http://tempuri.org/IHersan_Catalogos/ABCEquipoHerramientas_ObtenerResponse")]
        System.Collections.Generic.List<Hersan.Entidades.Catalogos.EquipoHerramientasBE> ABCEquipoHerramientas_Obtener();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Catalogos/ABCEquipoHerramientas_Guardar", ReplyAction="http://tempuri.org/IHersan_Catalogos/ABCEquipoHerramientas_GuardarResponse")]
        int ABCEquipoHerramientas_Guardar(Hersan.Entidades.Catalogos.EquipoHerramientasBE obj);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Catalogos/ABCEquipoHerramientas_Actualizar", ReplyAction="http://tempuri.org/IHersan_Catalogos/ABCEquipoHerramientas_ActualizarResponse")]
        int ABCEquipoHerramientas_Actualizar(Hersan.Entidades.Catalogos.EquipoHerramientasBE obj);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Catalogos/ABCContratos_Obtener", ReplyAction="http://tempuri.org/IHersan_Catalogos/ABCContratos_ObtenerResponse")]
        System.Collections.Generic.List<Hersan.Entidades.CapitalHumano.ContratosBE> ABCContratos_Obtener();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Catalogos/ABCContratos_Actualizar", ReplyAction="http://tempuri.org/IHersan_Catalogos/ABCContratos_ActualizarResponse")]
        int ABCContratos_Actualizar(Hersan.Entidades.CapitalHumano.ContratosBE obj);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Catalogos/ABCContratos_Guardar", ReplyAction="http://tempuri.org/IHersan_Catalogos/ABCContratos_GuardarResponse")]
        int ABCContratos_Guardar(Hersan.Entidades.CapitalHumano.ContratosBE obj);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Catalogos/ABCDocumentos_Obtener", ReplyAction="http://tempuri.org/IHersan_Catalogos/ABCDocumentos_ObtenerResponse")]
        System.Collections.Generic.List<Hersan.Entidades.Catalogos.DocumentosBE> ABCDocumentos_Obtener();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Catalogos/ABCDocumentos_Guardar", ReplyAction="http://tempuri.org/IHersan_Catalogos/ABCDocumentos_GuardarResponse")]
        int ABCDocumentos_Guardar(Hersan.Entidades.Catalogos.DocumentosBE obj);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Catalogos/ABCDocumentos_Actualizar", ReplyAction="http://tempuri.org/IHersan_Catalogos/ABCDocumentos_ActualizarResponse")]
        int ABCDocumentos_Actualizar(Hersan.Entidades.Catalogos.DocumentosBE obj);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Catalogos/CHUOrganigrama_Obtener", ReplyAction="http://tempuri.org/IHersan_Catalogos/CHUOrganigrama_ObtenerResponse")]
        System.Collections.Generic.List<Hersan.Entidades.Catalogos.OrganigramaBE> CHUOrganigrama_Obtener();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Catalogos/CHUOrganigrama_Guardar", ReplyAction="http://tempuri.org/IHersan_Catalogos/CHUOrganigrama_GuardarResponse")]
        int CHUOrganigrama_Guardar(Hersan.Entidades.Catalogos.OrganigramaBE obj);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Catalogos/CHUOrganigrama_Actualizar", ReplyAction="http://tempuri.org/IHersan_Catalogos/CHUOrganigrama_ActualizarResponse")]
        int CHUOrganigrama_Actualizar(Hersan.Entidades.Catalogos.OrganigramaBE obj);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IHersan_CatalogosChannel : Hersan.UI.Catalogos.WCF_Catalogos.IHersan_Catalogos, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Hersan_CatalogosClient : System.ServiceModel.ClientBase<Hersan.UI.Catalogos.WCF_Catalogos.IHersan_Catalogos>, Hersan.UI.Catalogos.WCF_Catalogos.IHersan_Catalogos {
        
        public Hersan_CatalogosClient() {
        }
        
        public Hersan_CatalogosClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Hersan_CatalogosClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Hersan_CatalogosClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Hersan_CatalogosClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Collections.Generic.List<Hersan.Entidades.Catalogos.EmpresasBE> ABCEmpresas_Obtener(int IdEmpresa) {
            return base.Channel.ABCEmpresas_Obtener(IdEmpresa);
        }
        
        public System.Collections.Generic.List<Hersan.Entidades.Catalogos.EmpresasBE> ABCEmpresas_Cbo() {
            return base.Channel.ABCEmpresas_Cbo();
        }
        
        public System.Collections.Generic.List<Hersan.Entidades.Catalogos.DepartamentosBE> ABCDepartamentos_Obtener() {
            return base.Channel.ABCDepartamentos_Obtener();
        }
        
        public int ABCDEpartamentos_Guardar(Hersan.Entidades.Catalogos.DepartamentosBE obj) {
            return base.Channel.ABCDEpartamentos_Guardar(obj);
        }
        
        public int ABCDEpartamentos_Actualizar(Hersan.Entidades.Catalogos.DepartamentosBE obj) {
            return base.Channel.ABCDEpartamentos_Actualizar(obj);
        }
        
        public System.Collections.Generic.List<Hersan.Entidades.Catalogos.DepartamentosBE> ABCDepartamentos_Combo(int IdEntidad) {
            return base.Channel.ABCDepartamentos_Combo(IdEntidad);
        }
        
        public System.Collections.Generic.List<Hersan.Entidades.Catalogos.TiposContratoBE> TiposContrato_Obtener() {
            return base.Channel.TiposContrato_Obtener();
        }
        
        public System.Collections.Generic.List<Hersan.Entidades.Catalogos.TiposContratoBE> ABCTiposcontrato_Combo() {
            return base.Channel.ABCTiposcontrato_Combo();
        }
        
        public int ABCTiposContrato_Guardar(Hersan.Entidades.Catalogos.TiposContratoBE obj) {
            return base.Channel.ABCTiposContrato_Guardar(obj);
        }
        
        public int ABCTiposContrato_Actualizar(Hersan.Entidades.Catalogos.TiposContratoBE obj) {
            return base.Channel.ABCTiposContrato_Actualizar(obj);
        }
        
        public System.Collections.Generic.List<Hersan.Entidades.Catalogos.PuestosBE> ABCPuestos_Obtener() {
            return base.Channel.ABCPuestos_Obtener();
        }
        
        public int ABCPuestos_Guardar(Hersan.Entidades.Catalogos.PuestosBE obj) {
            return base.Channel.ABCPuestos_Guardar(obj);
        }
        
        public int ABCPuestos_Actualizar(Hersan.Entidades.Catalogos.PuestosBE obj) {
            return base.Channel.ABCPuestos_Actualizar(obj);
        }
        
        public System.Collections.Generic.List<Hersan.Entidades.Catalogos.PuestosBE> ABCPuestos_Combo(int IdDepto) {
            return base.Channel.ABCPuestos_Combo(IdDepto);
        }
        
        public System.Collections.Generic.List<Hersan.Entidades.Catalogos.PuestosBE> CHUPuestos_Combo() {
            return base.Channel.CHUPuestos_Combo();
        }
        
        public System.Collections.Generic.List<Hersan.Entidades.CapitalHumano.CompetenciasBE> ABCCompetencias_Obtener() {
            return base.Channel.ABCCompetencias_Obtener();
        }
        
        public int ABC_Competencias_Guardar(Hersan.Entidades.CapitalHumano.CompetenciasBE obj) {
            return base.Channel.ABC_Competencias_Guardar(obj);
        }
        
        public int ABCCompetencias_Actualizar(Hersan.Entidades.CapitalHumano.CompetenciasBE obj) {
            return base.Channel.ABCCompetencias_Actualizar(obj);
        }
        
        public System.Collections.Generic.List<Hersan.Entidades.CapitalHumano.CompetenciasBE> ABCCompetencias_Combo() {
            return base.Channel.ABCCompetencias_Combo();
        }
        
        public System.Collections.Generic.List<Hersan.Entidades.Catalogos.EntidadesBE> Entidades_Obtener() {
            return base.Channel.Entidades_Obtener();
        }
        
        public int ABCEntidades_Guardar(Hersan.Entidades.Catalogos.EntidadesBE obj) {
            return base.Channel.ABCEntidades_Guardar(obj);
        }
        
        public int ABCEntidades_Actualizar(Hersan.Entidades.Catalogos.EntidadesBE obj) {
            return base.Channel.ABCEntidades_Actualizar(obj);
        }
        
        public System.Collections.Generic.List<Hersan.Entidades.Catalogos.EntidadesBE> Entidades_Combo(int IdEmpresa) {
            return base.Channel.Entidades_Combo(IdEmpresa);
        }
        
        public System.Collections.Generic.List<Hersan.Entidades.Catalogos.EducacionBE> ABCEducacion_Obtener() {
            return base.Channel.ABCEducacion_Obtener();
        }
        
        public int ABCEducacion_Guardar(Hersan.Entidades.Catalogos.EducacionBE obj) {
            return base.Channel.ABCEducacion_Guardar(obj);
        }
        
        public int ABCEducacion_Actualizar(Hersan.Entidades.Catalogos.EducacionBE obj) {
            return base.Channel.ABCEducacion_Actualizar(obj);
        }
        
        public System.Collections.Generic.List<Hersan.Entidades.Catalogos.EducacionBE> ABCEducacion_Combo() {
            return base.Channel.ABCEducacion_Combo();
        }
        
        public System.Collections.Generic.List<Hersan.Entidades.CapitalHumano.FuncionesBE> ABCFunciones_Obtener() {
            return base.Channel.ABCFunciones_Obtener();
        }
        
        public int ABCFunciones_Guardar(Hersan.Entidades.CapitalHumano.FuncionesBE obj) {
            return base.Channel.ABCFunciones_Guardar(obj);
        }
        
        public int ABCFunciones_Actualizar(Hersan.Entidades.CapitalHumano.FuncionesBE obj) {
            return base.Channel.ABCFunciones_Actualizar(obj);
        }
        
        public System.Collections.Generic.List<Hersan.Entidades.CapitalHumano.FuncionesBE> ABCFunciones_Combo() {
            return base.Channel.ABCFunciones_Combo();
        }
        
        public System.Collections.Generic.List<Hersan.Entidades.Catalogos.ContactosBE> ABCContactos_Obtener() {
            return base.Channel.ABCContactos_Obtener();
        }
        
        public int ABCContactos_Guardar(Hersan.Entidades.Catalogos.ContactosBE obj) {
            return base.Channel.ABCContactos_Guardar(obj);
        }
        
        public int ABCContactos_Actualizar(Hersan.Entidades.Catalogos.ContactosBE obj) {
            return base.Channel.ABCContactos_Actualizar(obj);
        }
        
        public System.Collections.Generic.List<Hersan.Entidades.Catalogos.EquipoHerramientasBE> ABCEquipoHerramientas_Obtener() {
            return base.Channel.ABCEquipoHerramientas_Obtener();
        }
        
        public int ABCEquipoHerramientas_Guardar(Hersan.Entidades.Catalogos.EquipoHerramientasBE obj) {
            return base.Channel.ABCEquipoHerramientas_Guardar(obj);
        }
        
        public int ABCEquipoHerramientas_Actualizar(Hersan.Entidades.Catalogos.EquipoHerramientasBE obj) {
            return base.Channel.ABCEquipoHerramientas_Actualizar(obj);
        }
        
        public System.Collections.Generic.List<Hersan.Entidades.CapitalHumano.ContratosBE> ABCContratos_Obtener() {
            return base.Channel.ABCContratos_Obtener();
        }
        
        public int ABCContratos_Actualizar(Hersan.Entidades.CapitalHumano.ContratosBE obj) {
            return base.Channel.ABCContratos_Actualizar(obj);
        }
        
        public int ABCContratos_Guardar(Hersan.Entidades.CapitalHumano.ContratosBE obj) {
            return base.Channel.ABCContratos_Guardar(obj);
        }
        
        public System.Collections.Generic.List<Hersan.Entidades.Catalogos.DocumentosBE> ABCDocumentos_Obtener() {
            return base.Channel.ABCDocumentos_Obtener();
        }
        
        public int ABCDocumentos_Guardar(Hersan.Entidades.Catalogos.DocumentosBE obj) {
            return base.Channel.ABCDocumentos_Guardar(obj);
        }
        
        public int ABCDocumentos_Actualizar(Hersan.Entidades.Catalogos.DocumentosBE obj) {
            return base.Channel.ABCDocumentos_Actualizar(obj);
        }
        
        public System.Collections.Generic.List<Hersan.Entidades.Catalogos.OrganigramaBE> CHUOrganigrama_Obtener() {
            return base.Channel.CHUOrganigrama_Obtener();
        }
        
        public int CHUOrganigrama_Guardar(Hersan.Entidades.Catalogos.OrganigramaBE obj) {
            return base.Channel.CHUOrganigrama_Guardar(obj);
        }
        
        public int CHUOrganigrama_Actualizar(Hersan.Entidades.Catalogos.OrganigramaBE obj) {
            return base.Channel.CHUOrganigrama_Actualizar(obj);
        }
    }
}
