using Hersan.Entidades.Nomina;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace Hersan.Nomina.Contract
{
    [ServiceContract]
    public interface IHersan_Nomina
    {
        #region Nomina
        [OperationContract]
        List<FactoresBE> Nom_Factores_Obtener();
        [OperationContract]
        List<SubsidiosBE> NOM_Subsidios_Obtener();
        [OperationContract]
        List<NominaBE> NOM_Nomina_Obtener(int Semana);
        [OperationContract]
        List<ISRBE> NOM_ISR_Semanal_Obtener();
        [OperationContract]
        List<SemanasBE> NOM_Semanas_Obtener(int Anio);
        [OperationContract]
        int NOM_Semanas_generar(int Anio);
        [OperationContract]
        List<CuotasBE> NOM_Cuotas_Obtener();

        [OperationContract]
        ParametrosBE Nom_Parametros_Obtener();
        [OperationContract]
        int Nom_Parametros_Guardar(ParametrosBE item);

        [OperationContract]
        List<NominaBE> NOM_CalculoNomina(int Semana);

        [OperationContract]
        int NOM_CalculoNomina_Guardar(int Semana, string Excluir, int IdUsuario);
        #endregion

        #region Préstamos
        [OperationContract]
        int NOM_Prestamos_Guardar(PrestamosBE Obj, System.Data.DataTable Detalle);
        [OperationContract]
        List<PrestamosBE> NOM_Prestamos_Consulta(PrestamosBE item);
        #endregion

        #region Incidencias
        [OperationContract]
        int NOM_Incidencias_Guardar(List<IncidenciasBE> Lista, List<FonacotBE> Fonacot);
        [OperationContract]
        List<IncidenciasBE> NOM_Incidencias_Obtener(int Semana);
        [OperationContract]
        bool NOM_ImportarFonacot(string Nombre, Byte[] Archivo);
        #endregion
    }
}
