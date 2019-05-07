using Hersan.Datos.Catalogos;
using Hersan.Entidades.Catalogos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hersan.Negocio.Catalogos
{
   public class ContactosBP
    {
        public List<ContactosBE> ABCContactos_Obtener()
        {
            return new ContactosDA().ABCContactos_Obtener();
        }
        public int ABCContactos_Guardar(ContactosBE obj)
        {
            return new ContactosDA().ABCContactos_Guardar(obj);
        }
        public int ABCContactos_Actualizar(ContactosBE obj)
        {
            return new ContactosDA().ABCContactos_Actualizar(obj);
        }
        public List<ContactosBE> ABCContactos_Combo()
        {
            return new ContactosDA().ABCContactos_Combo();
        }
    }
}
