using Hersan.Entidades.Catalogos;
using Hersan.Entidades.Ventas;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Hersan.Ventas.Contract
{
    [ServiceContract]
    public interface IHersan_Ventas
    {
        #region Clientes
        [OperationContract]
        int ABC_Clientes_Guardar(DataSet Tablas, string Entidades, int IdUsuario);
        [OperationContract]
        List<ClientesBE> ABC_Clientes_Buscar(ClientesBE Lista, string Entidades);
        [OperationContract]
        List<ClientesBE> ABC_Clientes_Obtener(int IdCliente);
        #endregion

        #region Facturación
        [OperationContract]
        List<FormasPagoBE> ABC_FormaPago_Combo();
        [OperationContract]
        List<MetodosPagoBE> ABC_MetodoPago_Combo();
        [OperationContract]
        List<UsoCFDIBE> ABC_UsoCFDI_Combo();
        #endregion
    }
}
