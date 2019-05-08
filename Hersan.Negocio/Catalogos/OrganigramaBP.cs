using Hersan.Datos.Catalogos;
using Hersan.Entidades.Catalogos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hersan.Negocio.Catalogos
{
   public class OrganigramaBP
    {
        public List<OrganigramaBE> CHUOrganigrama_Obtener()
        {
            return new OrganigramaDA().CHUOrganigrama_Obtener();
        }
        public int CHUOrganigrama_Guardar(OrganigramaBE obj)
        {
            return new OrganigramaDA().CHUOrganigrama_Guardar(obj);
        }
        public int CHUOrganigrama_Actualizar(OrganigramaBE obj)
        {
            return new OrganigramaDA().CHUOrganigrama_Actualizar(obj);
        }

        public DataTable CHU_OrganigramaXML_Obtener(int parent)
        {
            return new OrganigramaDA().CHU_OrganigramaXML_Obtener(parent);
        }
    }
}
