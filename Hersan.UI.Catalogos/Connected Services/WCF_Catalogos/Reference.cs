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
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Catalogos/ABCEmpresas_Obtener", ReplyAction="http://tempuri.org/IHersan_Catalogos/ABCEmpresas_ObtenerResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<Hersan.Entidades.Catalogos.EmpresasBE>> ABCEmpresas_ObtenerAsync(int IdEmpresa);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Catalogos/ABCEmpresas_Cbo", ReplyAction="http://tempuri.org/IHersan_Catalogos/ABCEmpresas_CboResponse")]
        System.Collections.Generic.List<Hersan.Entidades.Catalogos.EmpresasBE> ABCEmpresas_Cbo();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Catalogos/ABCEmpresas_Cbo", ReplyAction="http://tempuri.org/IHersan_Catalogos/ABCEmpresas_CboResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<Hersan.Entidades.Catalogos.EmpresasBE>> ABCEmpresas_CboAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Catalogos/ABCDepartamentos_Obtener", ReplyAction="http://tempuri.org/IHersan_Catalogos/ABCDepartamentos_ObtenerResponse")]
        System.Collections.Generic.List<Hersan.Entidades.Catalogos.DepartamentosBE> ABCDepartamentos_Obtener();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Catalogos/ABCDepartamentos_Obtener", ReplyAction="http://tempuri.org/IHersan_Catalogos/ABCDepartamentos_ObtenerResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<Hersan.Entidades.Catalogos.DepartamentosBE>> ABCDepartamentos_ObtenerAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Catalogos/ABCDEpartamentos_Guardar", ReplyAction="http://tempuri.org/IHersan_Catalogos/ABCDEpartamentos_GuardarResponse")]
        int ABCDEpartamentos_Guardar(Hersan.Entidades.Catalogos.DepartamentosBE obj);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Catalogos/ABCDEpartamentos_Guardar", ReplyAction="http://tempuri.org/IHersan_Catalogos/ABCDEpartamentos_GuardarResponse")]
        System.Threading.Tasks.Task<int> ABCDEpartamentos_GuardarAsync(Hersan.Entidades.Catalogos.DepartamentosBE obj);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Catalogos/ABCDEpartamentos_Actualizar", ReplyAction="http://tempuri.org/IHersan_Catalogos/ABCDEpartamentos_ActualizarResponse")]
        int ABCDEpartamentos_Actualizar(Hersan.Entidades.Catalogos.DepartamentosBE obj);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Catalogos/ABCDEpartamentos_Actualizar", ReplyAction="http://tempuri.org/IHersan_Catalogos/ABCDEpartamentos_ActualizarResponse")]
        System.Threading.Tasks.Task<int> ABCDEpartamentos_ActualizarAsync(Hersan.Entidades.Catalogos.DepartamentosBE obj);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Catalogos/TiposContrato_Obtener", ReplyAction="http://tempuri.org/IHersan_Catalogos/TiposContrato_ObtenerResponse")]
        System.Collections.Generic.List<Hersan.Entidades.Catalogos.TiposContratoBE> TiposContrato_Obtener();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Catalogos/TiposContrato_Obtener", ReplyAction="http://tempuri.org/IHersan_Catalogos/TiposContrato_ObtenerResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<Hersan.Entidades.Catalogos.TiposContratoBE>> TiposContrato_ObtenerAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Catalogos/ABCTiposContrato_Guardar", ReplyAction="http://tempuri.org/IHersan_Catalogos/ABCTiposContrato_GuardarResponse")]
        int ABCTiposContrato_Guardar(Hersan.Entidades.Catalogos.TiposContratoBE obj);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Catalogos/ABCTiposContrato_Guardar", ReplyAction="http://tempuri.org/IHersan_Catalogos/ABCTiposContrato_GuardarResponse")]
        System.Threading.Tasks.Task<int> ABCTiposContrato_GuardarAsync(Hersan.Entidades.Catalogos.TiposContratoBE obj);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Catalogos/ABCTiposContrato_Actualizar", ReplyAction="http://tempuri.org/IHersan_Catalogos/ABCTiposContrato_ActualizarResponse")]
        int ABCTiposContrato_Actualizar(Hersan.Entidades.Catalogos.TiposContratoBE obj);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Catalogos/ABCTiposContrato_Actualizar", ReplyAction="http://tempuri.org/IHersan_Catalogos/ABCTiposContrato_ActualizarResponse")]
        System.Threading.Tasks.Task<int> ABCTiposContrato_ActualizarAsync(Hersan.Entidades.Catalogos.TiposContratoBE obj);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Catalogos/ABCPuestos_Obtener", ReplyAction="http://tempuri.org/IHersan_Catalogos/ABCPuestos_ObtenerResponse")]
        System.Collections.Generic.List<Hersan.Entidades.Catalogos.PuestosBE> ABCPuestos_Obtener();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Catalogos/ABCPuestos_Obtener", ReplyAction="http://tempuri.org/IHersan_Catalogos/ABCPuestos_ObtenerResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<Hersan.Entidades.Catalogos.PuestosBE>> ABCPuestos_ObtenerAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Catalogos/ABCCompetencias_Obtener", ReplyAction="http://tempuri.org/IHersan_Catalogos/ABCCompetencias_ObtenerResponse")]
        System.Collections.Generic.List<Hersan.Entidades.CapitalHumano.CompetenciasBE> ABCCompetencias_Obtener();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Catalogos/ABCCompetencias_Obtener", ReplyAction="http://tempuri.org/IHersan_Catalogos/ABCCompetencias_ObtenerResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<Hersan.Entidades.CapitalHumano.CompetenciasBE>> ABCCompetencias_ObtenerAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Catalogos/ABC_Competencias_Guardar", ReplyAction="http://tempuri.org/IHersan_Catalogos/ABC_Competencias_GuardarResponse")]
        int ABC_Competencias_Guardar(Hersan.Entidades.CapitalHumano.CompetenciasBE obj);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Catalogos/ABC_Competencias_Guardar", ReplyAction="http://tempuri.org/IHersan_Catalogos/ABC_Competencias_GuardarResponse")]
        System.Threading.Tasks.Task<int> ABC_Competencias_GuardarAsync(Hersan.Entidades.CapitalHumano.CompetenciasBE obj);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Catalogos/ABCCompetencias_Actualizar", ReplyAction="http://tempuri.org/IHersan_Catalogos/ABCCompetencias_ActualizarResponse")]
        int ABCCompetencias_Actualizar(Hersan.Entidades.CapitalHumano.CompetenciasBE obj);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Catalogos/ABCCompetencias_Actualizar", ReplyAction="http://tempuri.org/IHersan_Catalogos/ABCCompetencias_ActualizarResponse")]
        System.Threading.Tasks.Task<int> ABCCompetencias_ActualizarAsync(Hersan.Entidades.CapitalHumano.CompetenciasBE obj);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Catalogos/Entidades_Obtener", ReplyAction="http://tempuri.org/IHersan_Catalogos/Entidades_ObtenerResponse")]
        System.Collections.Generic.List<Hersan.Entidades.Catalogos.EntidadesBE> Entidades_Obtener();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Catalogos/Entidades_Obtener", ReplyAction="http://tempuri.org/IHersan_Catalogos/Entidades_ObtenerResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<Hersan.Entidades.Catalogos.EntidadesBE>> Entidades_ObtenerAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Catalogos/ABCEntidades_Guardar", ReplyAction="http://tempuri.org/IHersan_Catalogos/ABCEntidades_GuardarResponse")]
        int ABCEntidades_Guardar(Hersan.Entidades.Catalogos.EntidadesBE obj);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Catalogos/ABCEntidades_Guardar", ReplyAction="http://tempuri.org/IHersan_Catalogos/ABCEntidades_GuardarResponse")]
        System.Threading.Tasks.Task<int> ABCEntidades_GuardarAsync(Hersan.Entidades.Catalogos.EntidadesBE obj);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Catalogos/ABCEntidades_Actualizar", ReplyAction="http://tempuri.org/IHersan_Catalogos/ABCEntidades_ActualizarResponse")]
        int ABCEntidades_Actualizar(Hersan.Entidades.Catalogos.EntidadesBE obj);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Catalogos/ABCEntidades_Actualizar", ReplyAction="http://tempuri.org/IHersan_Catalogos/ABCEntidades_ActualizarResponse")]
        System.Threading.Tasks.Task<int> ABCEntidades_ActualizarAsync(Hersan.Entidades.Catalogos.EntidadesBE obj);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Catalogos/ABCEducacion_Obtener", ReplyAction="http://tempuri.org/IHersan_Catalogos/ABCEducacion_ObtenerResponse")]
        System.Collections.Generic.List<Hersan.Entidades.Catalogos.EducacionBE> ABCEducacion_Obtener();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Catalogos/ABCEducacion_Obtener", ReplyAction="http://tempuri.org/IHersan_Catalogos/ABCEducacion_ObtenerResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<Hersan.Entidades.Catalogos.EducacionBE>> ABCEducacion_ObtenerAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Catalogos/ABCEducacion_Guardar", ReplyAction="http://tempuri.org/IHersan_Catalogos/ABCEducacion_GuardarResponse")]
        int ABCEducacion_Guardar(Hersan.Entidades.Catalogos.EducacionBE obj);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Catalogos/ABCEducacion_Guardar", ReplyAction="http://tempuri.org/IHersan_Catalogos/ABCEducacion_GuardarResponse")]
        System.Threading.Tasks.Task<int> ABCEducacion_GuardarAsync(Hersan.Entidades.Catalogos.EducacionBE obj);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Catalogos/ABCEducacion_Actualizar", ReplyAction="http://tempuri.org/IHersan_Catalogos/ABCEducacion_ActualizarResponse")]
        int ABCEducacion_Actualizar(Hersan.Entidades.Catalogos.EducacionBE obj);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Catalogos/ABCEducacion_Actualizar", ReplyAction="http://tempuri.org/IHersan_Catalogos/ABCEducacion_ActualizarResponse")]
        System.Threading.Tasks.Task<int> ABCEducacion_ActualizarAsync(Hersan.Entidades.Catalogos.EducacionBE obj);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Catalogos/ABCFunciones_Obtener", ReplyAction="http://tempuri.org/IHersan_Catalogos/ABCFunciones_ObtenerResponse")]
        System.Collections.Generic.List<Hersan.Entidades.CapitalHumano.FuncionesBE> ABCFunciones_Obtener();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_Catalogos/ABCFunciones_Obtener", ReplyAction="http://tempuri.org/IHersan_Catalogos/ABCFunciones_ObtenerResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<Hersan.Entidades.CapitalHumano.FuncionesBE>> ABCFunciones_ObtenerAsync();
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
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<Hersan.Entidades.Catalogos.EmpresasBE>> ABCEmpresas_ObtenerAsync(int IdEmpresa) {
            return base.Channel.ABCEmpresas_ObtenerAsync(IdEmpresa);
        }
        
        public System.Collections.Generic.List<Hersan.Entidades.Catalogos.EmpresasBE> ABCEmpresas_Cbo() {
            return base.Channel.ABCEmpresas_Cbo();
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<Hersan.Entidades.Catalogos.EmpresasBE>> ABCEmpresas_CboAsync() {
            return base.Channel.ABCEmpresas_CboAsync();
        }
        
        public System.Collections.Generic.List<Hersan.Entidades.Catalogos.DepartamentosBE> ABCDepartamentos_Obtener() {
            return base.Channel.ABCDepartamentos_Obtener();
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<Hersan.Entidades.Catalogos.DepartamentosBE>> ABCDepartamentos_ObtenerAsync() {
            return base.Channel.ABCDepartamentos_ObtenerAsync();
        }
        
        public int ABCDEpartamentos_Guardar(Hersan.Entidades.Catalogos.DepartamentosBE obj) {
            return base.Channel.ABCDEpartamentos_Guardar(obj);
        }
        
        public System.Threading.Tasks.Task<int> ABCDEpartamentos_GuardarAsync(Hersan.Entidades.Catalogos.DepartamentosBE obj) {
            return base.Channel.ABCDEpartamentos_GuardarAsync(obj);
        }
        
        public int ABCDEpartamentos_Actualizar(Hersan.Entidades.Catalogos.DepartamentosBE obj) {
            return base.Channel.ABCDEpartamentos_Actualizar(obj);
        }
        
        public System.Threading.Tasks.Task<int> ABCDEpartamentos_ActualizarAsync(Hersan.Entidades.Catalogos.DepartamentosBE obj) {
            return base.Channel.ABCDEpartamentos_ActualizarAsync(obj);
        }
        
        public System.Collections.Generic.List<Hersan.Entidades.Catalogos.TiposContratoBE> TiposContrato_Obtener() {
            return base.Channel.TiposContrato_Obtener();
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<Hersan.Entidades.Catalogos.TiposContratoBE>> TiposContrato_ObtenerAsync() {
            return base.Channel.TiposContrato_ObtenerAsync();
        }
        
        public int ABCTiposContrato_Guardar(Hersan.Entidades.Catalogos.TiposContratoBE obj) {
            return base.Channel.ABCTiposContrato_Guardar(obj);
        }
        
        public System.Threading.Tasks.Task<int> ABCTiposContrato_GuardarAsync(Hersan.Entidades.Catalogos.TiposContratoBE obj) {
            return base.Channel.ABCTiposContrato_GuardarAsync(obj);
        }
        
        public int ABCTiposContrato_Actualizar(Hersan.Entidades.Catalogos.TiposContratoBE obj) {
            return base.Channel.ABCTiposContrato_Actualizar(obj);
        }
        
        public System.Threading.Tasks.Task<int> ABCTiposContrato_ActualizarAsync(Hersan.Entidades.Catalogos.TiposContratoBE obj) {
            return base.Channel.ABCTiposContrato_ActualizarAsync(obj);
        }
        
        public System.Collections.Generic.List<Hersan.Entidades.Catalogos.PuestosBE> ABCPuestos_Obtener() {
            return base.Channel.ABCPuestos_Obtener();
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<Hersan.Entidades.Catalogos.PuestosBE>> ABCPuestos_ObtenerAsync() {
            return base.Channel.ABCPuestos_ObtenerAsync();
        }
        
        public System.Collections.Generic.List<Hersan.Entidades.CapitalHumano.CompetenciasBE> ABCCompetencias_Obtener() {
            return base.Channel.ABCCompetencias_Obtener();
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<Hersan.Entidades.CapitalHumano.CompetenciasBE>> ABCCompetencias_ObtenerAsync() {
            return base.Channel.ABCCompetencias_ObtenerAsync();
        }
        
        public int ABC_Competencias_Guardar(Hersan.Entidades.CapitalHumano.CompetenciasBE obj) {
            return base.Channel.ABC_Competencias_Guardar(obj);
        }
        
        public System.Threading.Tasks.Task<int> ABC_Competencias_GuardarAsync(Hersan.Entidades.CapitalHumano.CompetenciasBE obj) {
            return base.Channel.ABC_Competencias_GuardarAsync(obj);
        }
        
        public int ABCCompetencias_Actualizar(Hersan.Entidades.CapitalHumano.CompetenciasBE obj) {
            return base.Channel.ABCCompetencias_Actualizar(obj);
        }
        
        public System.Threading.Tasks.Task<int> ABCCompetencias_ActualizarAsync(Hersan.Entidades.CapitalHumano.CompetenciasBE obj) {
            return base.Channel.ABCCompetencias_ActualizarAsync(obj);
        }
        
        public System.Collections.Generic.List<Hersan.Entidades.Catalogos.EntidadesBE> Entidades_Obtener() {
            return base.Channel.Entidades_Obtener();
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<Hersan.Entidades.Catalogos.EntidadesBE>> Entidades_ObtenerAsync() {
            return base.Channel.Entidades_ObtenerAsync();
        }
        
        public int ABCEntidades_Guardar(Hersan.Entidades.Catalogos.EntidadesBE obj) {
            return base.Channel.ABCEntidades_Guardar(obj);
        }
        
        public System.Threading.Tasks.Task<int> ABCEntidades_GuardarAsync(Hersan.Entidades.Catalogos.EntidadesBE obj) {
            return base.Channel.ABCEntidades_GuardarAsync(obj);
        }
        
        public int ABCEntidades_Actualizar(Hersan.Entidades.Catalogos.EntidadesBE obj) {
            return base.Channel.ABCEntidades_Actualizar(obj);
        }
        
        public System.Threading.Tasks.Task<int> ABCEntidades_ActualizarAsync(Hersan.Entidades.Catalogos.EntidadesBE obj) {
            return base.Channel.ABCEntidades_ActualizarAsync(obj);
        }
        
        public System.Collections.Generic.List<Hersan.Entidades.Catalogos.EducacionBE> ABCEducacion_Obtener() {
            return base.Channel.ABCEducacion_Obtener();
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<Hersan.Entidades.Catalogos.EducacionBE>> ABCEducacion_ObtenerAsync() {
            return base.Channel.ABCEducacion_ObtenerAsync();
        }
        
        public int ABCEducacion_Guardar(Hersan.Entidades.Catalogos.EducacionBE obj) {
            return base.Channel.ABCEducacion_Guardar(obj);
        }
        
        public System.Threading.Tasks.Task<int> ABCEducacion_GuardarAsync(Hersan.Entidades.Catalogos.EducacionBE obj) {
            return base.Channel.ABCEducacion_GuardarAsync(obj);
        }
        
        public int ABCEducacion_Actualizar(Hersan.Entidades.Catalogos.EducacionBE obj) {
            return base.Channel.ABCEducacion_Actualizar(obj);
        }
        
        public System.Threading.Tasks.Task<int> ABCEducacion_ActualizarAsync(Hersan.Entidades.Catalogos.EducacionBE obj) {
            return base.Channel.ABCEducacion_ActualizarAsync(obj);
        }
        
        public System.Collections.Generic.List<Hersan.Entidades.CapitalHumano.FuncionesBE> ABCFunciones_Obtener() {
            return base.Channel.ABCFunciones_Obtener();
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<Hersan.Entidades.CapitalHumano.FuncionesBE>> ABCFunciones_ObtenerAsync() {
            return base.Channel.ABCFunciones_ObtenerAsync();
        }
    }
}
