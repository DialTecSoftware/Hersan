using Hersan.Datos.Catalogos;
using Hersan.Entidades.Catalogos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Hersan.Negocio.Catalogos
{
   public class OrganigramaBP
    {
        private string Ruta = @ConfigurationManager.AppSettings["Ruta"];        
        private Byte[] ObtenerXML()
        {
            try {
                string Archivo = File.ReadAllText(Ruta + @"Hersan.xml");
                byte[] bytes = System.Text.Encoding.UTF8.GetBytes(Archivo);
                //string send = Convert.ToBase64String(bytes);

                return bytes;
            } catch (Exception ex) {
                throw ex;
            }
        }

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

        public Byte[] CHU_OrganigramaXML_Obtener(int parent)
        {
            //return new OrganigramaDA().CHU_OrganigramaXML_Obtener(parent);
            XmlDocument doc = new XmlDocument();
            try {
                new OrganigramaDA().CHU_OrganigramaXML_Obtener(parent);
                //Encoding encoding = Encoding.UTF8;
                //byte[] Archivo = encoding.GetBytes(doc.OuterXml);
                //return Archivo;

                Byte[] Archivo = ObtenerXML();
                return Archivo;
            } catch (Exception ex) {
                throw ex;
            }
            
        }
    }
}
