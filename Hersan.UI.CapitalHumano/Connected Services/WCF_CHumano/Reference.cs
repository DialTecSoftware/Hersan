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
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_CHumano/CHU_Tabulador_Puestos_Obtener", ReplyAction="http://tempuri.org/IHersan_CHumano/CHU_Tabulador_Puestos_ObtenerResponse")]
        System.Collections.Generic.List<Hersan.Entidades.CapitalHumano.TabuladorBE> CHU_Tabulador_Puestos_Obtener();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_CHumano/CHU_SolicitudP_Obtener", ReplyAction="http://tempuri.org/IHersan_CHumano/CHU_SolicitudP_ObtenerResponse")]
        System.Collections.Generic.List<Hersan.Entidades.CapitalHumano.SolicitudPersonalBE> CHU_SolicitudP_Obtener(int IdUser);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_CHumano/CHU_SolicitudP_Guardar", ReplyAction="http://tempuri.org/IHersan_CHumano/CHU_SolicitudP_GuardarResponse")]
        int CHU_SolicitudP_Guardar(Hersan.Entidades.CapitalHumano.SolicitudPersonalBE obj);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_CHumano/CHU_SolicitudP_Actualizar", ReplyAction="http://tempuri.org/IHersan_CHumano/CHU_SolicitudP_ActualizarResponse")]
        int CHU_SolicitudP_Actualizar(Hersan.Entidades.CapitalHumano.SolicitudPersonalBE obj);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_CHumano/CHU_SolicitudP_ActualizarDictamen", ReplyAction="http://tempuri.org/IHersan_CHumano/CHU_SolicitudP_ActualizarDictamenResponse")]
        int CHU_SolicitudP_ActualizarDictamen(Hersan.Entidades.CapitalHumano.SolicitudPersonalBE obj);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_CHumano/CHUDictamenSolicitud_Obtener", ReplyAction="http://tempuri.org/IHersan_CHumano/CHUDictamenSolicitud_ObtenerResponse")]
        System.Collections.Generic.List<Hersan.Entidades.CapitalHumano.DictamenSustitucionBE> CHUDictamenSolicitud_Obtener();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_CHumano/CHUDictamenSolicitud__Guardar", ReplyAction="http://tempuri.org/IHersan_CHumano/CHUDictamenSolicitud__GuardarResponse")]
        int CHUDictamenSolicitud__Guardar(Hersan.Entidades.CapitalHumano.DictamenSustitucionBE obj);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_CHumano/CHUDictamenSolicitud_Actualizar", ReplyAction="http://tempuri.org/IHersan_CHumano/CHUDictamenSolicitud_ActualizarResponse")]
        int CHUDictamenSolicitud_Actualizar(Hersan.Entidades.CapitalHumano.DictamenSustitucionBE obj);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_CHumano/CHU_Expedientes_Guardar", ReplyAction="http://tempuri.org/IHersan_CHumano/CHU_Expedientes_GuardarResponse")]
        int CHU_Expedientes_Guardar(System.Data.DataSet Tablas, byte[] Imagen, int IdUsuario);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_CHumano/CHU_Expedientes_Consultar", ReplyAction="http://tempuri.org/IHersan_CHumano/CHU_Expedientes_ConsultarResponse")]
        System.Collections.Generic.List<Hersan.Entidades.CapitalHumano.ExpedientesBE> CHU_Expedientes_Consultar(Hersan.Entidades.CapitalHumano.ExpedientesBE Expediente);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_CHumano/CHU_Expedientes_Actualizar", ReplyAction="http://tempuri.org/IHersan_CHumano/CHU_Expedientes_ActualizarResponse")]
        int CHU_Expedientes_Actualizar(int Id, System.Data.DataSet Tablas, byte[] Imagen, int IdUsuario);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_CHumano/CHU_Expedientes_Eliminar", ReplyAction="http://tempuri.org/IHersan_CHumano/CHU_Expedientes_EliminarResponse")]
        int CHU_Expedientes_Eliminar(int Id, int IdUsuario);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_CHumano/CHU_ExpedientesDatosPersonales_Consultar", ReplyAction="http://tempuri.org/IHersan_CHumano/CHU_ExpedientesDatosPersonales_ConsultarRespon" +
            "se")]
        System.Collections.Generic.List<Hersan.Entidades.CapitalHumano.ExpedientesDatosPersonales> CHU_ExpedientesDatosPersonales_Consultar(Hersan.Entidades.CapitalHumano.ExpedientesDatosPersonales Expediente);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_CHumano/CHU_Expedientes_Obtener", ReplyAction="http://tempuri.org/IHersan_CHumano/CHU_Expedientes_ObtenerResponse")]
        System.Collections.Generic.List<Hersan.Entidades.CapitalHumano.ExpedientesBE> CHU_Expedientes_Obtener(int IdExpediente);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_CHumano/CHU_ExpedientesDocumentos_Consultar", ReplyAction="http://tempuri.org/IHersan_CHumano/CHU_ExpedientesDocumentos_ConsultarResponse")]
        System.Collections.Generic.List<Hersan.Entidades.CapitalHumano.ExpedienteDocumentos> CHU_ExpedientesDocumentos_Consultar(Hersan.Entidades.CapitalHumano.ExpedienteDocumentos Expediente);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_CHumano/CHU_Expediente_Familia_Consultar", ReplyAction="http://tempuri.org/IHersan_CHumano/CHU_Expediente_Familia_ConsultarResponse")]
        System.Collections.Generic.List<Hersan.Entidades.CapitalHumano.ExpedienteFamilia> CHU_Expediente_Familia_Consultar(Hersan.Entidades.CapitalHumano.ExpedienteFamilia Expediente);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_CHumano/CHU_Expediente_Estudios_Consultar", ReplyAction="http://tempuri.org/IHersan_CHumano/CHU_Expediente_Estudios_ConsultarResponse")]
        System.Collections.Generic.List<Hersan.Entidades.CapitalHumano.ExpedienteEstudios> CHU_Expediente_Estudios_Consultar(Hersan.Entidades.CapitalHumano.ExpedienteEstudios Expediente);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_CHumano/CHU_Expediente_Empleos_Consultar", ReplyAction="http://tempuri.org/IHersan_CHumano/CHU_Expediente_Empleos_ConsultarResponse")]
        System.Collections.Generic.List<Hersan.Entidades.CapitalHumano.ExpedienteEmpleos> CHU_Expediente_Empleos_Consultar(Hersan.Entidades.CapitalHumano.ExpedienteEmpleos Expediente);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_CHumano/CHU_Expediente_Salud_Consultar", ReplyAction="http://tempuri.org/IHersan_CHumano/CHU_Expediente_Salud_ConsultarResponse")]
        System.Collections.Generic.List<Hersan.Entidades.CapitalHumano.ExpedienteSalud> CHU_Expediente_Salud_Consultar(Hersan.Entidades.CapitalHumano.ExpedienteSalud Expediente);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_CHumano/CHU_Expediente_Conocimiento_Consultar", ReplyAction="http://tempuri.org/IHersan_CHumano/CHU_Expediente_Conocimiento_ConsultarResponse")]
        System.Collections.Generic.List<Hersan.Entidades.CapitalHumano.ExpedienteConocimiento> CHU_Expediente_Conocimiento_Consultar(Hersan.Entidades.CapitalHumano.ExpedienteConocimiento Expediente);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_CHumano/CHU_Expediente_Referencias_Consultar", ReplyAction="http://tempuri.org/IHersan_CHumano/CHU_Expediente_Referencias_ConsultarResponse")]
        System.Collections.Generic.List<Hersan.Entidades.CapitalHumano.ExpedienteReferencias> CHU_Expediente_Referencias_Consultar(Hersan.Entidades.CapitalHumano.ExpedienteReferencias Expediente);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_CHumano/CHU_Expediente_Generales_Consultar", ReplyAction="http://tempuri.org/IHersan_CHumano/CHU_Expediente_Generales_ConsultarResponse")]
        System.Collections.Generic.List<Hersan.Entidades.CapitalHumano.ExpedienteGenerales> CHU_Expediente_Generales_Consultar(Hersan.Entidades.CapitalHumano.ExpedienteGenerales Expediente);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_CHumano/CHU_Expediente_Economicos_Consultar", ReplyAction="http://tempuri.org/IHersan_CHumano/CHU_Expediente_Economicos_ConsultarResponse")]
        System.Collections.Generic.List<Hersan.Entidades.CapitalHumano.ExpedienteEconomicos> CHU_Expediente_Economicos_Consultar(Hersan.Entidades.CapitalHumano.ExpedienteEconomicos Expediente);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_CHumano/CHU_NuevoPuesto_Obtener", ReplyAction="http://tempuri.org/IHersan_CHumano/CHU_NuevoPuesto_ObtenerResponse")]
        System.Collections.Generic.List<Hersan.Entidades.CapitalHumano.NuevoPuestoBE> CHU_NuevoPuesto_Obtener(int IdUser);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_CHumano/CHU_NuevoPuesto_Guardar", ReplyAction="http://tempuri.org/IHersan_CHumano/CHU_NuevoPuesto_GuardarResponse")]
        int CHU_NuevoPuesto_Guardar(Hersan.Entidades.CapitalHumano.NuevoPuestoBE obj);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_CHumano/CHU_NuevoPuesto_Actualizar", ReplyAction="http://tempuri.org/IHersan_CHumano/CHU_NuevoPuesto_ActualizarResponse")]
        int CHU_NuevoPuesto_Actualizar(Hersan.Entidades.CapitalHumano.NuevoPuestoBE obj);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_CHumano/CHU_NuevoPuesto_ActualizarDictamen", ReplyAction="http://tempuri.org/IHersan_CHumano/CHU_NuevoPuesto_ActualizarDictamenResponse")]
        int CHU_NuevoPuesto_ActualizarDictamen(Hersan.Entidades.CapitalHumano.NuevoPuestoBE obj);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_CHumano/CHU_DictamenNuevoP_Obtener", ReplyAction="http://tempuri.org/IHersan_CHumano/CHU_DictamenNuevoP_ObtenerResponse")]
        System.Collections.Generic.List<Hersan.Entidades.CapitalHumano.DictamenNuevoPuestoBE> CHU_DictamenNuevoP_Obtener();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_CHumano/CHU_DictamenNuevoP_Guardar", ReplyAction="http://tempuri.org/IHersan_CHumano/CHU_DictamenNuevoP_GuardarResponse")]
        int CHU_DictamenNuevoP_Guardar(Hersan.Entidades.CapitalHumano.DictamenNuevoPuestoBE obj);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_CHumano/CHU_DictamenNuevoP_Actualizar", ReplyAction="http://tempuri.org/IHersan_CHumano/CHU_DictamenNuevoP_ActualizarResponse")]
        int CHU_DictamenNuevoP_Actualizar(Hersan.Entidades.CapitalHumano.DictamenNuevoPuestoBE obj);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_CHumano/CHU_DatosEMP_Obtener", ReplyAction="http://tempuri.org/IHersan_CHumano/CHU_DatosEMP_ObtenerResponse")]
        System.Collections.Generic.List<Hersan.Entidades.CapitalHumano.EvaluacionInduccionBE> CHU_DatosEMP_Obtener(Hersan.Entidades.CapitalHumano.EvaluacionInduccionBE evaluacion);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_CHumano/CHU_EvaluacionInduccion_Obtener", ReplyAction="http://tempuri.org/IHersan_CHumano/CHU_EvaluacionInduccion_ObtenerResponse")]
        System.Collections.Generic.List<Hersan.Entidades.CapitalHumano.EvaluacionInduccionBE> CHU_EvaluacionInduccion_Obtener();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_CHumano/CHU_ObtenerPreguntas", ReplyAction="http://tempuri.org/IHersan_CHumano/CHU_ObtenerPreguntasResponse")]
        System.Collections.Generic.List<Hersan.Entidades.CapitalHumano.PreguntasEvaluacionBE> CHU_ObtenerPreguntas();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_CHumano/CHU_EvaluacionInduccion_Guardar", ReplyAction="http://tempuri.org/IHersan_CHumano/CHU_EvaluacionInduccion_GuardarResponse")]
        int CHU_EvaluacionInduccion_Guardar(System.Data.DataSet Tablas, int IdUsuario);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_CHumano/CHU_Evaluacion_ReporteDetalle", ReplyAction="http://tempuri.org/IHersan_CHumano/CHU_Evaluacion_ReporteDetalleResponse")]
        System.Data.DataTable CHU_Evaluacion_ReporteDetalle(int Id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_CHumano/CHU_SeguimientoCan_Obtener", ReplyAction="http://tempuri.org/IHersan_CHumano/CHU_SeguimientoCan_ObtenerResponse")]
        System.Collections.Generic.List<Hersan.Entidades.CapitalHumano.SeguimientoCandidatosBE> CHU_SeguimientoCan_Obtener();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_CHumano/CHU_SeguimientoCan_Guardar", ReplyAction="http://tempuri.org/IHersan_CHumano/CHU_SeguimientoCan_GuardarResponse")]
        int CHU_SeguimientoCan_Guardar(Hersan.Entidades.CapitalHumano.SeguimientoCandidatosBE obj);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_CHumano/CHU_SeguimientoCan_Actualizar", ReplyAction="http://tempuri.org/IHersan_CHumano/CHU_SeguimientoCan_ActualizarResponse")]
        int CHU_SeguimientoCan_Actualizar(Hersan.Entidades.CapitalHumano.SeguimientoCandidatosBE obj);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_CHumano/ABCHorarios_Obtener", ReplyAction="http://tempuri.org/IHersan_CHumano/ABCHorarios_ObtenerResponse")]
        System.Collections.Generic.List<Hersan.Entidades.Relchec.HorariosBE> ABCHorarios_Obtener();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_CHumano/ABCHorarios_Guarda", ReplyAction="http://tempuri.org/IHersan_CHumano/ABCHorarios_GuardaResponse")]
        int ABCHorarios_Guarda(Hersan.Entidades.Relchec.HorariosBE obj);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_CHumano/ABCHorarios_Actualiza", ReplyAction="http://tempuri.org/IHersan_CHumano/ABCHorarios_ActualizaResponse")]
        int ABCHorarios_Actualiza(Hersan.Entidades.Relchec.HorariosBE obj);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_CHumano/CHU_Digitalizados_Obtener", ReplyAction="http://tempuri.org/IHersan_CHumano/CHU_Digitalizados_ObtenerResponse")]
        System.Collections.Generic.List<Hersan.Entidades.CapitalHumano.DigitalizadosDetalleBE> CHU_Digitalizados_Obtener(int IdExp);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_CHumano/CHU_Digitalizados_Guardar", ReplyAction="http://tempuri.org/IHersan_CHumano/CHU_Digitalizados_GuardarResponse")]
        int CHU_Digitalizados_Guardar(int IdExpediente, System.Data.DataTable Detalle, int IdUsuario, System.Collections.Generic.List<Hersan.Entidades.CapitalHumano.DigitalizadosDetalleBE> Archivos);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_CHumano/CHU_DescripcionPuestos_Obtener", ReplyAction="http://tempuri.org/IHersan_CHumano/CHU_DescripcionPuestos_ObtenerResponse")]
        System.Data.DataSet CHU_DescripcionPuestos_Obtener(int IdPerfifl);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_CHumano/CHU_DescPuestos_Guardar", ReplyAction="http://tempuri.org/IHersan_CHumano/CHU_DescPuestos_GuardarResponse")]
        int CHU_DescPuestos_Guardar(Hersan.Entidades.CapitalHumano.DescripcionPuestosBE obj, System.Data.DataTable Contactos, System.Data.DataTable Condiciones);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_CHumano/CHU_DescPuestos_Actualizar", ReplyAction="http://tempuri.org/IHersan_CHumano/CHU_DescPuestos_ActualizarResponse")]
        int CHU_DescPuestos_Actualizar(Hersan.Entidades.CapitalHumano.DescripcionPuestosBE obj, System.Data.DataTable Contactos, System.Data.DataTable Condiciones);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_CHumano/CHU_DescPuestos_Elimina", ReplyAction="http://tempuri.org/IHersan_CHumano/CHU_DescPuestos_EliminaResponse")]
        int CHU_DescPuestos_Elimina(int IdDesc, int IdUsuario);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_CHumano/CHU_DescPuesto_ReporteDetalle", ReplyAction="http://tempuri.org/IHersan_CHumano/CHU_DescPuesto_ReporteDetalleResponse")]
        System.Data.DataTable CHU_DescPuesto_ReporteDetalle(int IdPerfil, int idPuesto, int IdDepto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_CHumano/CHU_DescPuesto_ReporteDetalle2", ReplyAction="http://tempuri.org/IHersan_CHumano/CHU_DescPuesto_ReporteDetalle2Response")]
        System.Data.DataTable CHU_DescPuesto_ReporteDetalle2(int IdPerfil);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_CHumano/CHU_Empleados_Consultar", ReplyAction="http://tempuri.org/IHersan_CHumano/CHU_Empleados_ConsultarResponse")]
        System.Collections.Generic.List<Hersan.Entidades.CapitalHumano.EmpleadosBE> CHU_Empleados_Consultar(int IdExp);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_CHumano/CHUEmpleados_Guardar", ReplyAction="http://tempuri.org/IHersan_CHumano/CHUEmpleados_GuardarResponse")]
        int CHUEmpleados_Guardar(Hersan.Entidades.CapitalHumano.EmpleadosBE obj);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_CHumano/CHU_EmpleadosActualizar", ReplyAction="http://tempuri.org/IHersan_CHumano/CHU_EmpleadosActualizarResponse")]
        int CHU_EmpleadosActualizar(Hersan.Entidades.CapitalHumano.EmpleadosBE obj);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHersan_CHumano/CHU_Empleados_Elimina", ReplyAction="http://tempuri.org/IHersan_CHumano/CHU_Empleados_EliminaResponse")]
        int CHU_Empleados_Elimina(int IdEmp, int IdUsuario);
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
        
        public System.Collections.Generic.List<Hersan.Entidades.CapitalHumano.TabuladorBE> CHU_Tabulador_Puestos_Obtener() {
            return base.Channel.CHU_Tabulador_Puestos_Obtener();
        }
        
        public System.Collections.Generic.List<Hersan.Entidades.CapitalHumano.SolicitudPersonalBE> CHU_SolicitudP_Obtener(int IdUser) {
            return base.Channel.CHU_SolicitudP_Obtener(IdUser);
        }
        
        public int CHU_SolicitudP_Guardar(Hersan.Entidades.CapitalHumano.SolicitudPersonalBE obj) {
            return base.Channel.CHU_SolicitudP_Guardar(obj);
        }
        
        public int CHU_SolicitudP_Actualizar(Hersan.Entidades.CapitalHumano.SolicitudPersonalBE obj) {
            return base.Channel.CHU_SolicitudP_Actualizar(obj);
        }
        
        public int CHU_SolicitudP_ActualizarDictamen(Hersan.Entidades.CapitalHumano.SolicitudPersonalBE obj) {
            return base.Channel.CHU_SolicitudP_ActualizarDictamen(obj);
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
        
        public int CHU_Expedientes_Guardar(System.Data.DataSet Tablas, byte[] Imagen, int IdUsuario) {
            return base.Channel.CHU_Expedientes_Guardar(Tablas, Imagen, IdUsuario);
        }
        
        public System.Collections.Generic.List<Hersan.Entidades.CapitalHumano.ExpedientesBE> CHU_Expedientes_Consultar(Hersan.Entidades.CapitalHumano.ExpedientesBE Expediente) {
            return base.Channel.CHU_Expedientes_Consultar(Expediente);
        }
        
        public int CHU_Expedientes_Actualizar(int Id, System.Data.DataSet Tablas, byte[] Imagen, int IdUsuario) {
            return base.Channel.CHU_Expedientes_Actualizar(Id, Tablas, Imagen, IdUsuario);
        }
        
        public int CHU_Expedientes_Eliminar(int Id, int IdUsuario) {
            return base.Channel.CHU_Expedientes_Eliminar(Id, IdUsuario);
        }
        
        public System.Collections.Generic.List<Hersan.Entidades.CapitalHumano.ExpedientesDatosPersonales> CHU_ExpedientesDatosPersonales_Consultar(Hersan.Entidades.CapitalHumano.ExpedientesDatosPersonales Expediente) {
            return base.Channel.CHU_ExpedientesDatosPersonales_Consultar(Expediente);
        }
        
        public System.Collections.Generic.List<Hersan.Entidades.CapitalHumano.ExpedientesBE> CHU_Expedientes_Obtener(int IdExpediente) {
            return base.Channel.CHU_Expedientes_Obtener(IdExpediente);
        }
        
        public System.Collections.Generic.List<Hersan.Entidades.CapitalHumano.ExpedienteDocumentos> CHU_ExpedientesDocumentos_Consultar(Hersan.Entidades.CapitalHumano.ExpedienteDocumentos Expediente) {
            return base.Channel.CHU_ExpedientesDocumentos_Consultar(Expediente);
        }
        
        public System.Collections.Generic.List<Hersan.Entidades.CapitalHumano.ExpedienteFamilia> CHU_Expediente_Familia_Consultar(Hersan.Entidades.CapitalHumano.ExpedienteFamilia Expediente) {
            return base.Channel.CHU_Expediente_Familia_Consultar(Expediente);
        }
        
        public System.Collections.Generic.List<Hersan.Entidades.CapitalHumano.ExpedienteEstudios> CHU_Expediente_Estudios_Consultar(Hersan.Entidades.CapitalHumano.ExpedienteEstudios Expediente) {
            return base.Channel.CHU_Expediente_Estudios_Consultar(Expediente);
        }
        
        public System.Collections.Generic.List<Hersan.Entidades.CapitalHumano.ExpedienteEmpleos> CHU_Expediente_Empleos_Consultar(Hersan.Entidades.CapitalHumano.ExpedienteEmpleos Expediente) {
            return base.Channel.CHU_Expediente_Empleos_Consultar(Expediente);
        }
        
        public System.Collections.Generic.List<Hersan.Entidades.CapitalHumano.ExpedienteSalud> CHU_Expediente_Salud_Consultar(Hersan.Entidades.CapitalHumano.ExpedienteSalud Expediente) {
            return base.Channel.CHU_Expediente_Salud_Consultar(Expediente);
        }
        
        public System.Collections.Generic.List<Hersan.Entidades.CapitalHumano.ExpedienteConocimiento> CHU_Expediente_Conocimiento_Consultar(Hersan.Entidades.CapitalHumano.ExpedienteConocimiento Expediente) {
            return base.Channel.CHU_Expediente_Conocimiento_Consultar(Expediente);
        }
        
        public System.Collections.Generic.List<Hersan.Entidades.CapitalHumano.ExpedienteReferencias> CHU_Expediente_Referencias_Consultar(Hersan.Entidades.CapitalHumano.ExpedienteReferencias Expediente) {
            return base.Channel.CHU_Expediente_Referencias_Consultar(Expediente);
        }
        
        public System.Collections.Generic.List<Hersan.Entidades.CapitalHumano.ExpedienteGenerales> CHU_Expediente_Generales_Consultar(Hersan.Entidades.CapitalHumano.ExpedienteGenerales Expediente) {
            return base.Channel.CHU_Expediente_Generales_Consultar(Expediente);
        }
        
        public System.Collections.Generic.List<Hersan.Entidades.CapitalHumano.ExpedienteEconomicos> CHU_Expediente_Economicos_Consultar(Hersan.Entidades.CapitalHumano.ExpedienteEconomicos Expediente) {
            return base.Channel.CHU_Expediente_Economicos_Consultar(Expediente);
        }
        
        public System.Collections.Generic.List<Hersan.Entidades.CapitalHumano.NuevoPuestoBE> CHU_NuevoPuesto_Obtener(int IdUser) {
            return base.Channel.CHU_NuevoPuesto_Obtener(IdUser);
        }
        
        public int CHU_NuevoPuesto_Guardar(Hersan.Entidades.CapitalHumano.NuevoPuestoBE obj) {
            return base.Channel.CHU_NuevoPuesto_Guardar(obj);
        }
        
        public int CHU_NuevoPuesto_Actualizar(Hersan.Entidades.CapitalHumano.NuevoPuestoBE obj) {
            return base.Channel.CHU_NuevoPuesto_Actualizar(obj);
        }
        
        public int CHU_NuevoPuesto_ActualizarDictamen(Hersan.Entidades.CapitalHumano.NuevoPuestoBE obj) {
            return base.Channel.CHU_NuevoPuesto_ActualizarDictamen(obj);
        }
        
        public System.Collections.Generic.List<Hersan.Entidades.CapitalHumano.DictamenNuevoPuestoBE> CHU_DictamenNuevoP_Obtener() {
            return base.Channel.CHU_DictamenNuevoP_Obtener();
        }
        
        public int CHU_DictamenNuevoP_Guardar(Hersan.Entidades.CapitalHumano.DictamenNuevoPuestoBE obj) {
            return base.Channel.CHU_DictamenNuevoP_Guardar(obj);
        }
        
        public int CHU_DictamenNuevoP_Actualizar(Hersan.Entidades.CapitalHumano.DictamenNuevoPuestoBE obj) {
            return base.Channel.CHU_DictamenNuevoP_Actualizar(obj);
        }
        
        public System.Collections.Generic.List<Hersan.Entidades.CapitalHumano.EvaluacionInduccionBE> CHU_DatosEMP_Obtener(Hersan.Entidades.CapitalHumano.EvaluacionInduccionBE evaluacion) {
            return base.Channel.CHU_DatosEMP_Obtener(evaluacion);
        }
        
        public System.Collections.Generic.List<Hersan.Entidades.CapitalHumano.EvaluacionInduccionBE> CHU_EvaluacionInduccion_Obtener() {
            return base.Channel.CHU_EvaluacionInduccion_Obtener();
        }
        
        public System.Collections.Generic.List<Hersan.Entidades.CapitalHumano.PreguntasEvaluacionBE> CHU_ObtenerPreguntas() {
            return base.Channel.CHU_ObtenerPreguntas();
        }
        
        public int CHU_EvaluacionInduccion_Guardar(System.Data.DataSet Tablas, int IdUsuario) {
            return base.Channel.CHU_EvaluacionInduccion_Guardar(Tablas, IdUsuario);
        }
        
        public System.Data.DataTable CHU_Evaluacion_ReporteDetalle(int Id) {
            return base.Channel.CHU_Evaluacion_ReporteDetalle(Id);
        }
        
        public System.Collections.Generic.List<Hersan.Entidades.CapitalHumano.SeguimientoCandidatosBE> CHU_SeguimientoCan_Obtener() {
            return base.Channel.CHU_SeguimientoCan_Obtener();
        }
        
        public int CHU_SeguimientoCan_Guardar(Hersan.Entidades.CapitalHumano.SeguimientoCandidatosBE obj) {
            return base.Channel.CHU_SeguimientoCan_Guardar(obj);
        }
        
        public int CHU_SeguimientoCan_Actualizar(Hersan.Entidades.CapitalHumano.SeguimientoCandidatosBE obj) {
            return base.Channel.CHU_SeguimientoCan_Actualizar(obj);
        }
        
        public System.Collections.Generic.List<Hersan.Entidades.Relchec.HorariosBE> ABCHorarios_Obtener() {
            return base.Channel.ABCHorarios_Obtener();
        }
        
        public int ABCHorarios_Guarda(Hersan.Entidades.Relchec.HorariosBE obj) {
            return base.Channel.ABCHorarios_Guarda(obj);
        }
        
        public int ABCHorarios_Actualiza(Hersan.Entidades.Relchec.HorariosBE obj) {
            return base.Channel.ABCHorarios_Actualiza(obj);
        }
        
        public System.Collections.Generic.List<Hersan.Entidades.CapitalHumano.DigitalizadosDetalleBE> CHU_Digitalizados_Obtener(int IdExp) {
            return base.Channel.CHU_Digitalizados_Obtener(IdExp);
        }
        
        public int CHU_Digitalizados_Guardar(int IdExpediente, System.Data.DataTable Detalle, int IdUsuario, System.Collections.Generic.List<Hersan.Entidades.CapitalHumano.DigitalizadosDetalleBE> Archivos) {
            return base.Channel.CHU_Digitalizados_Guardar(IdExpediente, Detalle, IdUsuario, Archivos);
        }
        
        public System.Data.DataSet CHU_DescripcionPuestos_Obtener(int IdPerfifl) {
            return base.Channel.CHU_DescripcionPuestos_Obtener(IdPerfifl);
        }
        
        public int CHU_DescPuestos_Guardar(Hersan.Entidades.CapitalHumano.DescripcionPuestosBE obj, System.Data.DataTable Contactos, System.Data.DataTable Condiciones) {
            return base.Channel.CHU_DescPuestos_Guardar(obj, Contactos, Condiciones);
        }
        
        public int CHU_DescPuestos_Actualizar(Hersan.Entidades.CapitalHumano.DescripcionPuestosBE obj, System.Data.DataTable Contactos, System.Data.DataTable Condiciones) {
            return base.Channel.CHU_DescPuestos_Actualizar(obj, Contactos, Condiciones);
        }
        
        public int CHU_DescPuestos_Elimina(int IdDesc, int IdUsuario) {
            return base.Channel.CHU_DescPuestos_Elimina(IdDesc, IdUsuario);
        }
        
        public System.Data.DataTable CHU_DescPuesto_ReporteDetalle(int IdPerfil, int idPuesto, int IdDepto) {
            return base.Channel.CHU_DescPuesto_ReporteDetalle(IdPerfil, idPuesto, IdDepto);
        }
        
        public System.Data.DataTable CHU_DescPuesto_ReporteDetalle2(int IdPerfil) {
            return base.Channel.CHU_DescPuesto_ReporteDetalle2(IdPerfil);
        }
        
        public System.Collections.Generic.List<Hersan.Entidades.CapitalHumano.EmpleadosBE> CHU_Empleados_Consultar(int IdExp) {
            return base.Channel.CHU_Empleados_Consultar(IdExp);
        }
        
        public int CHUEmpleados_Guardar(Hersan.Entidades.CapitalHumano.EmpleadosBE obj) {
            return base.Channel.CHUEmpleados_Guardar(obj);
        }
        
        public int CHU_EmpleadosActualizar(Hersan.Entidades.CapitalHumano.EmpleadosBE obj) {
            return base.Channel.CHU_EmpleadosActualizar(obj);
        }
        
        public int CHU_Empleados_Elimina(int IdEmp, int IdUsuario) {
            return base.Channel.CHU_Empleados_Elimina(IdEmp, IdUsuario);
        }
    }
}
