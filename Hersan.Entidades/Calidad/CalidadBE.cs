using Hersan.Entidades.Inyeccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hersan.Entidades.Calidad
{
    public class CalidadBE
    {
        public CalidadBE()
        {
            Id = 0;
            Lista = 0;
            Inyeccion = new InyeccionBE();
            Operador = string.Empty;
            Fecha = DateTime.Today;
            IdUsuario = 0;
            Detalle = new CalidadDetalleBE();
            Flag = false;
        }

        public int Id { get; set; }
        public int Lista { get; set; }
        public InyeccionBE Inyeccion { get; set; }
        public string Operador { get; set; }
        public DateTime Fecha { get; set; }
        public int IdUsuario { get; set; }
        public CalidadDetalleBE Detalle{ get; set; }
        public bool Flag { get; set; }
    }

    public class CalidadDetalleBE
    {
        public CalidadDetalleBE()
        {
            Id = 0;
            Hora = new TimeSpan();
            Resumen = new List<CalidadResumenBE>();
            Cav1_1 = 0;
            Cav1_2 = 0;
            Cav2_1 = 0;
            Cav2_2 = 0;
            Cav3_1 = 0;
            Cav3_2 = 0;
            Cav4_1 = 0;
            Cav4_2 = 0;
            Cav5_1 = 0;
            Cav5_2 = 0;
            Cav6_1 = 0;
            Cav6_2 = 0;
            Cav7_1 = 0;
            Cav7_2 = 0;
            Cav8_1 = 0;
            Cav8_2 = 0;
        }

        public int Id { get; set; }
        public TimeSpan Hora { get; set; }
        public int Cav1_1 { get; set; }
        public int Cav1_2 { get; set; }
        public int Cav2_1 { get; set; }
        public int Cav2_2 { get; set; }
        public int Cav3_1 { get; set; }
        public int Cav3_2 { get; set; }
        public int Cav4_1 { get; set; }
        public int Cav4_2 { get; set; }
        public int Cav5_1 { get; set; }
        public int Cav5_2 { get; set; }
        public int Cav6_1 { get; set; }
        public int Cav6_2 { get; set; }
        public int Cav7_1 { get; set; }
        public int Cav7_2 { get; set; }
        public int Cav8_1 { get; set; }
        public int Cav8_2 { get; set; }
        public List<CalidadResumenBE> Resumen { get; set; }
    }

    public class CalidadResumenBE
    {

        public CalidadResumenBE()
        {
            Cavidad = 0;
            Maximo = 0;
            Minimo = 0;
            Promedio = 0;
            DesvEst = 0;
        }

        public int Cavidad { get; set; }
        public int Maximo { get; set; }
        public int Minimo { get; set; }
        public decimal Promedio { get; set; }
        public decimal DesvEst { get; set; }
    }
}
