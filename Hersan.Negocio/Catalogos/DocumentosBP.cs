using Hersan.Datos.Catalogos;
using Hersan.Entidades.Catalogos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hersan.Negocio.Catalogos
{
    public class DocumentosBP
    {
        public List<DocumentosBE> ABCDocumentos_Obtener()
        {
            return new DocumentosDA().ABCDocumentos_Obtener();
        }
        public int ABCDocumentos_Guardar(DocumentosBE obj)
        {
            return new DocumentosDA().ABCDocumentos_Guardar(obj);
        }
        public int ABCDocumentos_Actualizar(DocumentosBE obj)
        {
            return new DocumentosDA().ABCDocumentos_Actualizar(obj);
        }
        public List<DocumentosBE> ABCDocumentos_Combo()
        {
            return new DocumentosDA().ABCDocumentos_Combo();
        }
    }
}
