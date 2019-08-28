using Hersan.Entidades.Comun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hersan.Entidades.Nomina {
    public class FonacotBE 
    {
        public FonacotBE()
        {
            ANIO_EMISION = 0;
            MES_EMISION = 0;
            NO_FONACOT = string.Empty;
            RFC = string.Empty;
            NO_SS = string.Empty;
            Nombre = string.Empty;
            CLAVE_EMPLEADO = 0;
            RETENCION_MENSUAL = 0;
            Descuento = 0;
            RETENCION_REAL = 0;
            Semanas = 0;
            IdUsuario = 0;
        }

        public int ANIO_EMISION { get; set; }
        public int MES_EMISION { get; set; }
        public string NO_FONACOT { get; set; }
        public string RFC { get; set; }
        public string NO_SS { get; set; }
        public string Nombre { get; set; }
        public int CLAVE_EMPLEADO { get; set; }
        public decimal RETENCION_MENSUAL { get; set; }
        public decimal Descuento { get; set; }
        public decimal RETENCION_REAL { get; set; }
        public int Semanas { get; set; }
        public int IdUsuario { get; set; }

    }
}
