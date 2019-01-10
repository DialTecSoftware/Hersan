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

        #endregion
    }
}
