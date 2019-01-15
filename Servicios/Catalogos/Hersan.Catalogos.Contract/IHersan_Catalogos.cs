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

        #endregion

        #region Puestos
        [OperationContract]
        List<PuestosBE> ABCPuestos_Obtener();

        [OperationContract]
        int ABCPuestos_Guardar(PuestosBE obj);

        [OperationContract]
        int ABCPuestos_Actualizar(PuestosBE obj);
        #endregion


    }
}
