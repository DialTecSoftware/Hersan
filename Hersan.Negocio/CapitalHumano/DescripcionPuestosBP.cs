using Hersan.Datos.CapitalHumano;
using Hersan.Entidades.CapitalHumano;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hersan.Negocio.CapitalHumano
{
    public class DescripcionPuestosBP
    {
        public DataSet CHU_DescripcionPuestos_Obtener(int IdPerfifl)
        {
            return new DescripcionPuestosDA().CHU_DescripcionPuestos_Obtener( IdPerfifl);
        }
        public int CHU_DescPuestos_Guardar(DescripcionPuestosBE obj, DataTable Contactos, DataTable Condiciones)
        {
            return new DescripcionPuestosDA().CHU_DescPuestos_Guardar( obj,  Contactos,  Condiciones);
        }
        public int CHU_DescPuestos_Actualizar(DescripcionPuestosBE obj, DataTable Contactos, DataTable Condiciones)
        {
            return new DescripcionPuestosDA().CHU_DescPuestos_Actualizar(obj, Contactos, Condiciones);
        }
        public int CHU_DescPuestos_Elimina(int IdDesc, int IdUsuario)
        {
            return new DescripcionPuestosDA().CHU_DescPuestos_Elimina( IdDesc,  IdUsuario);
        }
    }
}
