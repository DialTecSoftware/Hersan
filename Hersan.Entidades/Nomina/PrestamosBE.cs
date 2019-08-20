using Hersan.Entidades.CapitalHumano;
using Hersan.Entidades.Comun;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hersan.Entidades.Nomina
{
    public class PrestamosBE
    {
        public PrestamosBE()
        {
            Id = 0;
            Empleado = new EmpleadosBE();
            ImporteTotal = 0;
            Tasa = 0;
            NoPagos = 0;
            ImportePago = 0;
            SemanaAplica = 0;
            FechaAplica = DateTime.Today;
            Estatus = string.Empty;
            Detalle = new PrestamosDetalleBE();
            DatosUsuario = new GeneralBE();
        }

        public int Id { get; set; }
        public EmpleadosBE Empleado { get; set; }
        public decimal Tasa { get; set; }
        public decimal ImporteTotal { get; set; }
        public int NoPagos { get; set; }
        public decimal ImportePago { get; set; }
        public int SemanaAplica { get; set; }
        public DateTime FechaAplica { get; set; }
        public string Estatus { get; set; }
        public PrestamosDetalleBE Detalle { get; set; }
        public GeneralBE DatosUsuario { get; set; }
        
    }

    public class PrestamosDetalleBE
    {
        public PrestamosDetalleBE()
        {
            Sel = false;
            Id = 0;
            NoPago = 0;
            Semana = 0;
            Fecha = DateTime.Today;
            Capital = 0;
            Interes = 0;
            ImportePago = 0;
            Abono = 0;
            Saldo = 0;
            Estatus = string.Empty;
            DatosUsuario = new GeneralBE();
        }

        [Description("Read"), Category("Appearance")]
        public bool Sel { get; set; }
        public int Id { get; set; }
        public int NoPago { get; set; }
        public int Semana { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Capital { get; set; }
        public decimal Interes { get; set; }

        [Description("Read"), Category("Appearance")]
        public decimal ImportePago { get; set; }
        public decimal Abono { get; set; }
        public decimal Saldo { get; set; }

        [Description("Read"), Category("Appearance")]
        public string Estatus { get; set; }
        [Description("Read"), Category("Appearance")]
        public GeneralBE DatosUsuario { get; set; }

    }
}
