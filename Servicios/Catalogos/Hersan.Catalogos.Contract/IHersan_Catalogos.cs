using Hersan.Entidades.Catalogos;
using System.Collections.Generic;
using System.ServiceModel;

namespace Hersan.Catalogos.Contract
{
    [ServiceContract]
    public interface IHersan_Catalogos
    {
        [OperationContract]
        List<EmpresasBE> ABCEmpresas_Obtener(int IdEmpresa);

        [OperationContract]
        List<EmpresasBE> ABCEmpresas_Cbo();

    }
}
