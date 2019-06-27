using Hersan.Datos;
using Hersan.Entidades.CapitalHumano;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hersan.Negocio.CapitalHumano
{
  public  class DigitalizadosBP
    {
        private string RutaDoctos = @ConfigurationManager.AppSettings["RutaDoctos"];

        private void GuardarArchivos(int Expediente, List<DigitalizadosDetalleBE> Archivos)
        {
            BinaryWriter Writer = null;
            string Name = string.Empty;
            RutaDoctos += "\\" + Expediente + "\\";
            try {
                if (!Directory.Exists(RutaDoctos))
                    Directory.CreateDirectory(RutaDoctos);

                Archivos.ForEach(item => {
                    if (item.DatosUsuario.Estatus == true) {
                        Name = RutaDoctos + item.NombreArchivo;
                        Writer = new BinaryWriter(File.OpenWrite(Name));
                        Writer.Write(item.Archivo);
                        Writer.Flush();
                        Writer.Close();
                    } else {
                        File.Delete(RutaDoctos + item.NombreArchivo);
                    }
                });
            } catch (Exception ex) {
                throw new Exception("Error al intentar guardar el archivo.", ex);
            }
        }
        private void ObtenerArchivos(int Expediente, ref List<DigitalizadosDetalleBE> oList)
        {
            string Ruta = RutaDoctos + Expediente.ToString() + "\\";
            try {
                if (!Directory.Exists(Ruta))
                    Directory.CreateDirectory(Ruta);

                DirectoryInfo Dir = new DirectoryInfo(Ruta);                
                foreach (var fi in Dir.GetFiles()) {
                    var file = oList.Find(item => item.NombreArchivo == fi.Name);
                    file.Archivo = ConvertImage.FileToByteArray(Ruta + fi.Name);
                }
            } catch (Exception ex) {
                throw new Exception("Error al intentar guardar el archivo.", ex);
            }
        }

        public List<DigitalizadosDetalleBE> CHU_Digitalizados_Obtener(int IdExp)
        {            
            try {
                List <DigitalizadosDetalleBE>  oList = new DigitalizadosDA().CHU_Digitalizados_Obtener(IdExp);
                if(oList.Count > 0)
                    ObtenerArchivos(IdExp, ref oList);

                return oList;
            } catch (Exception ex) {
                throw ex;
            }
        }
        public int CHU_Digitalizados_Guardar(int IdExpediente, DataTable Detalle, int IdUsuario, List<DigitalizadosDetalleBE> Archivos)
        {
            try {
                int Id = new DigitalizadosDA().CHU_Digitalizados_Guardar(IdExpediente, Detalle, IdUsuario);
                if (Id > 0) {
                    GuardarArchivos(IdExpediente, Archivos);
                }
                return Id;
            } catch (Exception ex) {
                throw ex;
            }
        }
    }
}
