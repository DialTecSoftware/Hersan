using Hersan.Entidades.Catalogos;
using Hersan.Entidades.Comun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hersan.Entidades.CapitalHumano
{
   
    public class DigitalizadosDetalleBE
    {
        public DigitalizadosDetalleBE()
        {
            Sel = false;
            Expediente = new ExpedientesBE();
            NombreArchivo = string.Empty;
            RutaArchivo = string.Empty;
            RutaArchivo = string.Empty;
            Documento = new DocumentosBE();
            DatosUsuario = new GeneralBE();
        }

        public bool Sel { get; set; }
        public ExpedientesBE Expediente { get; set; }
        public string NombreArchivo { get; set; }
        public string RutaOriginal;
        public string RutaArchivo { get; set; }
        public byte[] Archivo { get; set; }
        public DocumentosBE Documento { get; set; }
        public GeneralBE DatosUsuario { get; set; }
    }
        
}

