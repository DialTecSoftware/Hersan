using Hersan.Entidades.Catalogos;
using Hersan.Entidades.Comun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hersan.Entidades.CapitalHumano
{
   public class DigitalizadosBE
    {
        public DigitalizadosBE()
        {
            Id = 0;
            Empleados = new EmpleadosBE();
            Expedientes = new ExpedientesBE();
            DatosUsuario = new GeneralBE();
           
        }
        public int Id { get; set; }
        public EmpleadosBE Empleados { get; set; }
        public ExpedientesBE Expedientes { get; set; }
        public List<DigitalizadosDetalleBE> Digitalizados { get; set; }
        public GeneralBE DatosUsuario { get; set; }
    }


    public class DigitalizadosDetalleBE
    {
        public DigitalizadosDetalleBE()
        {
            Id = 0;
            Tipo = string.Empty;
            Sel = false;
            RutaArchivo = string.Empty;
            IdTipo = 0;
            Digitalizados = new DigitalizadosBE();
            DatosUsuario = new GeneralBE();
        }
        public int Id { get; set; }
        public string Tipo { get; set; }
        public string RutaArchivo { get; set; }
        public bool Sel { get; set; }
        public int IdTipo { get; set; }
        public DigitalizadosBE Digitalizados { get; set; }
        public GeneralBE DatosUsuario { get; set; }
    }
        
}

