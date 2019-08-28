using Hersan.Datos.Nomina;
using Hersan.Entidades.Nomina;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;

namespace Hersan.Negocio.Nomina
{
    public class NominaBP
    {
        private string RutaDoctos = @ConfigurationManager.AppSettings["RutaDoctos"];
        private void GuardarArchivo(string Nombre, Byte[] Archivo)
        {
            BinaryWriter Writer = null;
            string Name = string.Empty;            
            try {
                if (!Directory.Exists(RutaDoctos))
                    Directory.CreateDirectory(RutaDoctos);

                Name = RutaDoctos + Nombre;
                Writer = new BinaryWriter(File.OpenWrite(Name));
                Writer.Write(Archivo);
                Writer.Flush();
                Writer.Close();
            } catch (Exception ex) {
                throw new Exception("Error al intentar guardar el archivo.", ex);
            }
        }
        public List<NominaBE> NOM_CalculoNomina(int Semana)
        {
            return new NominaDA().NOM_CalculoNomina(Semana);
        }
        public int NOM_Prestamos_Guardar(PrestamosBE Obj, System.Data.DataTable Detalle)
        {
            return new NominaDA().NOM_Prestamos_Guardar(Obj, Detalle);
        }
        public int NOM_Incidencias_Guardar(List<IncidenciasBE> Lista)
        {
            return new NominaDA().NOM_Incidencias_Guardar(Lista);
        }
        public List<IncidenciasBE> NOM_Incidencias_Obtener(int Semana)
        {
            return new NominaDA().NOM_Incidencias_Obtener(Semana);
        }
        public bool NOM_ImportarFonacot(string Nombre, Byte[] Archivo)
        {
            bool Result = false;
            try {
                if (Archivo != null) {
                    GuardarArchivo(Nombre, Archivo);
                    Result = new NominaDA().NOM_ImportarFonacot(Nombre);
                }
                return Result;
            } catch (Exception ex) {
                throw ex;
            }
        }
    }
}
