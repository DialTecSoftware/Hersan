using Hersan.Entidades.Comun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hersan.Entidades.Nomina
{
    public class FactoresBE
    {
        public FactoresBE()
        {
            Id = 0;
            De = 0;
            Hasta = 0;
            Aguinaldo = 0;
            Vacaciones = 0;
            Prima = 0;
            Factor = 0;
            DatosUsuario = new GeneralBE();
        }

        public int Id { get; set; }
        public decimal De { get; set; }
        public decimal Hasta { get; set; }
        public int Aguinaldo { get; set; }
        public int Vacaciones { get; set; }
        public decimal Prima { get; set; }
        public decimal Factor { get; set; }
        public GeneralBE DatosUsuario { get; set; }
    }

    public class SubsidiosBE
    {
        public SubsidiosBE()
        {
            Id = 0;
            De = 0;
            Hasta = 0;
            Subsidio = 0;
            DatosUsuario = new GeneralBE();
        }

        public int Id { get; set; }
        public decimal De { get; set; }
        public decimal Hasta { get; set; }
        public decimal Subsidio { get; set; }
        public GeneralBE DatosUsuario { get; set; }

    }

    public class ISRBE
    {
        public ISRBE()
        {
            Id = 0;
            De = 0;
            Hasta = 0;
            Cuota = 0;
            Porcentaje = 0;
            DatosUsuario = new GeneralBE();
        }

        public int Id { get; set; }
        public decimal De { get; set; }
        public decimal Hasta { get; set; }
        public decimal Cuota { get; set; }
        public decimal Porcentaje { get; set; }
        public GeneralBE DatosUsuario { get; set; } 
    }

    public class SemanasBE
    {
        public SemanasBE()
        {
            Id = 0;
            Semana = 0;
            Inicia = DateTime.Today;
            Termina = DateTime.Today;
            DatosUsuario = new GeneralBE();
        }
        public int Id { get; set; }
        public int Semana { get; set; }
        public DateTime Inicia { get; set; }
        public DateTime Termina { get; set; }
        public GeneralBE DatosUsuario { get; set; }
    }

    public class CuotasBE
    {
        public CuotasBE()
        {
            Id = 0;
            Nombre = string.Empty;
            Detalle = new CuotasDetalleBE();
            DatosUsuario = new GeneralBE();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public CuotasDetalleBE Detalle { get; set; }
        public GeneralBE DatosUsuario { get; set; }
    }

    public class CuotasDetalleBE
    {
        public CuotasDetalleBE()
        {
            Id = 0;
            Prestacion = string.Empty;
            Patron = 0;
            Trabajador = 0;
            Total = 0;
            DatosUsuario = new GeneralBE();
        }

        public int Id { get; set; }
        public string Prestacion { get; set; }
        public decimal Patron { get; set; }
        public decimal Trabajador { get; set; }
        public decimal Total { get; set; }
        public GeneralBE DatosUsuario { get; set; }
    }
}
