using Hersan.Datos.Ventas;
using Hersan.Entidades.Catalogos;
using Hersan.Entidades.Ventas;
using Hersan.Negocio.Ventas;
using Hersan.Ventas.Contract;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hersan.Ventas.Service
{
    public class Hersan_Ventas : IHersan_Ventas
    {
        #region Clientes
        public int ABC_Clientes_Guardar(System.Data.DataSet Tablas, string Entidades, int IdUsuario)
        {
            return new ClientesBP().ABC_Clientes_Guardar(Tablas, Entidades, IdUsuario);
        }
        public List<ClientesBE> ABC_Clientes_Buscar(ClientesBE Lista, string Entidades)
        {
            return new ClientesBP().ABC_Clientes_Buscar(Lista, Entidades);
        }
        public List<ClientesBE> ABC_Clientes_Obtener(int IdCliente)
        {
            return new ClientesBP().ABC_Clientes_Obtener(IdCliente);
        }
        #endregion

        #region Facturación
        public List<FormasPagoBE> ABC_FormaPago_Combo()
        {
            return new FacturacionDA().ABC_FormaPago_Combo();
        }
        public List<MetodosPagoBE> ABC_MetodoPago_Combo()
        {
            return new FacturacionDA().ABC_MetodoPago_Combo();
        }
        public List<UsoCFDIBE> ABC_UsoCFDI_Combo()
        {
            return new FacturacionDA().ABC_UsoCFDI_Combo();
        }
        #endregion
    }
}
