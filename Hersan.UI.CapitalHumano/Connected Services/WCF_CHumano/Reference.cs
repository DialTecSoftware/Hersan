﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Hersan.UI.CapitalHumano.WCF_CHumano {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="WCF_CHumano.IHersan_CHumano")]
    public interface IHersan_CHumano {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_CHumano/CHU_Perfiles_Guardar", ReplyAction="http://tempuri.org/IHersan_CHumano/CHU_Perfiles_GuardarResponse")]
        int CHU_Perfiles_Guardar(Hersan.Entidades.CapitalHumano.PerfilesBE obj, System.Data.DataTable Detalle);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_CHumano/CHU_Perfiles_Obtener", ReplyAction="http://tempuri.org/IHersan_CHumano/CHU_Perfiles_ObtenerResponse")]
        System.Data.DataSet CHU_Perfiles_Obtener(int IdDepto, int IdPuesto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_CHumano/CHU_Perfiles_Actualiza", ReplyAction="http://tempuri.org/IHersan_CHumano/CHU_Perfiles_ActualizaResponse")]
        int CHU_Perfiles_Actualiza(Hersan.Entidades.CapitalHumano.PerfilesBE obj, System.Data.DataTable Detalle);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_CHumano/CHU_Perfiles_Elimina", ReplyAction="http://tempuri.org/IHersan_CHumano/CHU_Perfiles_EliminaResponse")]
        int CHU_Perfiles_Elimina(int IdPerfil, int IdUsuario);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_CHumano/CHU_SolicitudP_Obtener", ReplyAction="http://tempuri.org/IHersan_CHumano/CHU_SolicitudP_ObtenerResponse")]
        System.Collections.Generic.List<Hersan.Entidades.CapitalHumano.SolicitudPersonalBE> CHU_SolicitudP_Obtener();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_CHumano/CHU_SolicitudP_Guardar", ReplyAction="http://tempuri.org/IHersan_CHumano/CHU_SolicitudP_GuardarResponse")]
        int CHU_SolicitudP_Guardar(Hersan.Entidades.CapitalHumano.SolicitudPersonalBE obj);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_CHumano/CHU_SolicitudP_Actualizar", ReplyAction="http://tempuri.org/IHersan_CHumano/CHU_SolicitudP_ActualizarResponse")]
        int CHU_SolicitudP_Actualizar(Hersan.Entidades.CapitalHumano.SolicitudPersonalBE obj);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_CHumano/CHUDictamenSolicitud_Obtener", ReplyAction="http://tempuri.org/IHersan_CHumano/CHUDictamenSolicitud_ObtenerResponse")]
        System.Collections.Generic.List<Hersan.Entidades.CapitalHumano.DictamenSustitucionBE> CHUDictamenSolicitud_Obtener();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_CHumano/CHUDictamenSolicitud__Guardar", ReplyAction="http://tempuri.org/IHersan_CHumano/CHUDictamenSolicitud__GuardarResponse")]
        int CHUDictamenSolicitud__Guardar(Hersan.Entidades.CapitalHumano.DictamenSustitucionBE obj);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_CHumano/CHUDictamenSolicitud_Actualizar", ReplyAction="http://tempuri.org/IHersan_CHumano/CHUDictamenSolicitud_ActualizarResponse")]
        int CHUDictamenSolicitud_Actualizar(Hersan.Entidades.CapitalHumano.DictamenSustitucionBE obj);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IHersan_CHumanoChannel : Hersan.UI.CapitalHumano.WCF_CHumano.IHersan_CHumano, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Hersan_CHumanoClient : System.ServiceModel.ClientBase<Hersan.UI.CapitalHumano.WCF_CHumano.IHersan_CHumano>, Hersan.UI.CapitalHumano.WCF_CHumano.IHersan_CHumano {
        
        public Hersan_CHumanoClient() {
        }
        
        public Hersan_CHumanoClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Hersan_CHumanoClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Hersan_CHumanoClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Hersan_CHumanoClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public int CHU_Perfiles_Guardar(Hersan.Entidades.CapitalHumano.PerfilesBE obj, System.Data.DataTable Detalle) {
            return base.Channel.CHU_Perfiles_Guardar(obj, Detalle);
        }
        
        public System.Data.DataSet CHU_Perfiles_Obtener(int IdDepto, int IdPuesto) {
            return base.Channel.CHU_Perfiles_Obtener(IdDepto, IdPuesto);
        }
        
        public int CHU_Perfiles_Actualiza(Hersan.Entidades.CapitalHumano.PerfilesBE obj, System.Data.DataTable Detalle) {
            return base.Channel.CHU_Perfiles_Actualiza(obj, Detalle);
        }
        
        public int CHU_Perfiles_Elimina(int IdPerfil, int IdUsuario) {
            return base.Channel.CHU_Perfiles_Elimina(IdPerfil, IdUsuario);
        }
        
        public System.Collections.Generic.List<Hersan.Entidades.CapitalHumano.SolicitudPersonalBE> CHU_SolicitudP_Obtener() {
            return base.Channel.CHU_SolicitudP_Obtener();
        }
        
        public int CHU_SolicitudP_Guardar(Hersan.Entidades.CapitalHumano.SolicitudPersonalBE obj) {
            return base.Channel.CHU_SolicitudP_Guardar(obj);
        }
        
        public int CHU_SolicitudP_Actualizar(Hersan.Entidades.CapitalHumano.SolicitudPersonalBE obj) {
            return base.Channel.CHU_SolicitudP_Actualizar(obj);
        }
        
        public System.Collections.Generic.List<Hersan.Entidades.CapitalHumano.DictamenSustitucionBE> CHUDictamenSolicitud_Obtener() {
            return base.Channel.CHUDictamenSolicitud_Obtener();
        }
        
        public int CHUDictamenSolicitud__Guardar(Hersan.Entidades.CapitalHumano.DictamenSustitucionBE obj) {
            return base.Channel.CHUDictamenSolicitud__Guardar(obj);
        }
        
        public int CHUDictamenSolicitud_Actualizar(Hersan.Entidades.CapitalHumano.DictamenSustitucionBE obj) {
            return base.Channel.CHUDictamenSolicitud_Actualizar(obj);
        }
    }
}
