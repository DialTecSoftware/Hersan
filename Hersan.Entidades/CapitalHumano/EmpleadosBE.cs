using Hersan.Entidades.Comun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hersan.Entidades.CapitalHumano
{
  public  class EmpleadosBE
    {

        public EmpleadosBE()
        {
            Numero = 0;
            Expedientes = new ExpedientesBE();
            Infonavit = string.Empty;
            Fonacot = string.Empty;
            SeguroSocial = string.Empty;
            RegistroFederal = string.Empty;
            NumeroCuenta = string.Empty;
            SueldoAprobado = 0;
            EstatusEmpleado = string.Empty;
            FechaIngreso = DateTime.Today;
            DatosUsuarios = new GeneralBE();
        }

        public int Numero { get; set; }
        public ExpedientesBE Expedientes { get; set; }
        public string Infonavit { get; set; }
        public string Fonacot { get; set; }
        public string SeguroSocial { get; set; }
        public string RegistroFederal { get; set; }
        public string NumeroCuenta { get; set; }
        public decimal SueldoAprobado { get; set; }
        public string EstatusEmpleado { get; set; }
        public DateTime FechaIngreso { get; set; }
        public GeneralBE DatosUsuarios { get; set; }
    }
}
