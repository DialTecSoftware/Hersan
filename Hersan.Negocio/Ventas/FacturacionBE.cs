using Hersan.Datos.Ventas;
using Hersan.Entidades.Catalogos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hersan.Negocio.Ventas
{
    public class FacturacionBE
    {
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
    }
}
