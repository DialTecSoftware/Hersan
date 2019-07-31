using Hersan.Entidades.Nomina;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace Hersan.Nomina.Contract
{
    [ServiceContract]
    public interface IHersan_Nomina
    {
        [OperationContract]
        List<FactoresBE> Nom_Factores_Obtener();
        [OperationContract]
        List<SubsidiosBE> NOM_Subsidios_Obtener();
        [OperationContract]
        List<ISRBE> NOM_ISR_Semanal_Obtener();
        [OperationContract]
        List<SemanasBE> NOM_Semanas_Obtener(int Anio);
        [OperationContract]
        int NOM_Semanas_generar(int Anio);
    }
}
