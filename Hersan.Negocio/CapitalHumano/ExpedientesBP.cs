using Hersan.Datos.CapitalHumano;
using Hersan.Entidades.CapitalHumano;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Hersan.Negocio.CapitalHumano
{
    public class ExpedientesBP
    {
        private string RutaImagen = @ConfigurationManager.AppSettings["RutaImagen"];

        private void GuardarImagen(int Expediente, Byte[] Imagen)
        {            
            BinaryWriter Writer = null;            
            string Name = RutaImagen + Expediente.ToString() + ".jpg";
            try {
                if (!Directory.Exists(RutaImagen))
                    Directory.CreateDirectory(RutaImagen);

                Writer = new BinaryWriter(File.OpenWrite(Name));
                Writer.Write(Imagen);
                Writer.Flush();
                Writer.Close();

            } catch (Exception ex) {
                throw new Exception("Error al intentar guardar el archivo.", ex);
            }
        }
        private Byte[] ObtenerImagen(int Expediente)
        {
            byte[] Foto;
            string Imagen = RutaImagen + Expediente.ToString() + ".jpg"; ;
            try {
                if (File.Exists(Imagen)) {
                    Foto = ConvertImage.FileToByteArray(Imagen);
                } else {
                    Foto = null;
                }
            } catch (Exception ex) {
                throw new Exception("Error al intentar guardar el archivo.", ex);
            }
            return Foto;
        }

        public int CHU_Expedientes_Guardar(DataSet Tablas, byte[] Imagen, int IdUsuario)
        {
            
            try {
                int Expediente = new ExpedientesDA().CHU_Expedientes_Guardar(Tablas, IdUsuario);
                if (Expediente > 0 && Imagen != null) {
                    GuardarImagen(Expediente, Imagen);
                }
               return Expediente;
            } catch (Exception ex) {
                throw ex;
            }
        }
        public List<ExpedientesBE> CHU_Expedientes_Consultar(ExpedientesBE Expediente)
        {
            return new ExpedientesDA().CHU_Expedientes_Consultar(Expediente);
        }
        public int CHU_Expedientes_Actualizar(int Id, DataSet Tablas, byte[] Imagen, int IdUsuario)
        {
            try {

                int Result = new ExpedientesDA().CHU_Expedientes_Actualizar(Id, Tablas, IdUsuario);
                if (Result > 0 && Imagen != null) {
                    GuardarImagen(Id, Imagen);
                }
                return Result;
            } catch (Exception ex) {
                throw ex;
            }
        }
        public int CHU_Expedientes_Eliminar(int Id, int IdUsuario)
        {
            return new ExpedientesDA().CHU_Expedientes_Eliminar(Id, IdUsuario);
        }
        public List<ExpedientesDatosPersonales> CHU_ExpedientesDatosPersonales_Consultar(ExpedientesDatosPersonales Expediente)
        {
            return new ExpedientesDA().CHU_ExpedientesDatosPersonales_Consultar(Expediente);
        }
        public List<ExpedientesBE> CHU_Expedientes_Obtener(int IdExpediente)
        {
            try {
                List<ExpedientesBE> Obj = new ExpedientesDA().CHU_Expedientes_Obtener(IdExpediente);
                Obj.ForEach(item => {
                    if(item.RutaImagen.Trim().Length > 0)
                        item.Foto = ObtenerImagen(item.Id);
                });

                return Obj;
            } catch (Exception ex) {
                throw ex;
            }
        }
        public List<ExpedienteDocumentos> CHU_ExpedientesDocumentos_Consultar(ExpedienteDocumentos Expediente)
        {
            return new ExpedientesDA().CHU_ExpedientesDocumentos_Consultar(Expediente);
        }
        public List<ExpedienteFamilia> CHU_Expediente_Familia_Consultar(ExpedienteFamilia Expediente)
        {
            return new ExpedientesDA().CHU_Expediente_Familia_Consultar(Expediente);
        }
        public List<ExpedienteEstudios> CHU_Expediente_Estudios_Consultar(ExpedienteEstudios Expediente)
        {
            return new ExpedientesDA().CHU_Expediente_Estudios_Consultar(Expediente);
        }
        public List<ExpedienteEmpleos> CHU_Expediente_Empleos_Consultar(ExpedienteEmpleos Expediente)
        {
            return new ExpedientesDA().CHU_Expediente_Empleos_Consultar(Expediente);
        }
        public List<ExpedienteSalud> CHU_Expediente_Salud_Consultar(ExpedienteSalud Expediente)
        {
            return new ExpedientesDA().CHU_Expediente_Salud_Consultar(Expediente);
        }
        public List<ExpedienteConocimiento> CHU_Expediente_Conocimiento_Consultar(ExpedienteConocimiento Expediente)
        {
            return new ExpedientesDA().CHU_Expediente_Conocimiento_Consultar(Expediente);
        }
        public List<ExpedienteReferencias> CHU_Expediente_Referencias_Consultar(ExpedienteReferencias Expediente)
        {
            return new ExpedientesDA().CHU_Expediente_Referencias_Consultar(Expediente);
        }
        public List<ExpedienteGenerales> CHU_Expediente_Generales_Consultar(ExpedienteGenerales Expediente)
        {
            return new ExpedientesDA().CHU_Expediente_Generales_Consultar(Expediente);
        }
        public List<ExpedienteEconomicos> CHU_Expediente_Economicos_Consultar(ExpedienteEconomicos Expediente)
        {
            return new ExpedientesDA().CHU_Expediente_Economicos_Consultar(Expediente);
        }
    }
}
