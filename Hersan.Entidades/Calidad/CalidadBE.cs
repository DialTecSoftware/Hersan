using Hersan.Entidades.Catalogos;
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
            Fecha = DateTime.Today;
            Cavidad = 0;
            Maximo = 0;
            Minimo = 0;
            Promedio = 0;
            DesvEst = 0;
        }

        public DateTime Fecha { get; set; }
        public int Cavidad { get; set; }
        public int Maximo { get; set; }
        public int Minimo { get; set; }
        public decimal Promedio { get; set; }
        public decimal DesvEst { get; set; }
    }

    public class CalidadEnsambleBE
    {
        public CalidadEnsambleBE()
        {
            Id = 0;
            Norma = 0;
            Muestra = 0;
            Parametros = new EnsambleParametrosBE();
            Operador = string.Empty;
            Fecha = DateTime.Today;
            IdUsuario = 0;
            Detalle = new CalidadEnsambleDetalleBE();
        }

        public int Id { get; set; }
        public int Norma { get; set; }
        public int Muestra { get; set; }
        public EnsambleParametrosBE Parametros { get; set; }
        public string Operador { get; set; }
        public DateTime Fecha { get; set; }
        public int IdUsuario { get; set; }
        public CalidadEnsambleDetalleBE Detalle { get; set; }
    }

    public class CalidadEnsambleDetalleBE
    {
        public CalidadEnsambleDetalleBE()
        {
            Id = 0;
            IdInspeccion = 0;
            Lote = string.Empty;
            Maquina = string.Empty;
            Obs1 = 0;
            Obs2 = 0;
            Obs3 = 0;
            Obs4 = 0;
            Obs5 = 0;
            Reflejante = 0;
            Fecha = DateTime.Today;
            Resumen = new List<CalidadResumenBE>();
            IdUsuario = 0;
        }

        public int Id { get; set; }
        public int IdInspeccion { get; set; }
        public string Lote { get; set; }
        public string Maquina { get; set; }
        public int Reflejante { get; set; }
        public int Obs1 { get; set; }
        public int Obs2 { get; set; }
        public int Obs3 { get; set; }
        public int Obs4 { get; set; }
        public int Obs5 { get; set; }
        public List<CalidadResumenBE> Resumen { get; set; }
        public DateTime Fecha { get; set; }
        public int IdUsuario { get; set; }

    }

    public class CalidadResguardoQA
    {
        public CalidadResguardoQA()
        {
            Id = 0;
            Nombre = string.Empty;
            Producto = new TipoProductoBE();
            Carcasa = new ColoresBE();
            Reflex1 = new ColoresBE();
            Reflex2 = new ColoresBE();
            Piezas = 0;
            Fecha = DateTime.Today;
            IdUsuario = 0;
            Detalle = new List<CalidadResguardoQADetalle>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public TipoProductoBE Producto { get; set; }
        public ColoresBE Carcasa { get; set; }
        public ColoresBE Reflex1 { get; set; }
        public ColoresBE Reflex2 { get; set; }
        public int Piezas { get; set; }
        public DateTime Fecha { get; set; }
        public int IdUsuario { get; set; }
        public List<CalidadResguardoQADetalle> Detalle { get; set; }

    }

    public class CalidadResguardoQADetalle
    {
        public CalidadResguardoQADetalle()
        {
            Id = 0;
            IdResguardo = 0;
            Lote = string.Empty;
            Valor0 = 0;
            Valor1 = 0;
            Valor2 = 0;
            Lista = 0;
            OP = string.Empty;
            Fecha = DateTime.Today;
            IdUsuario = 0;
        }

        public int Id { get; set; }
        public int IdResguardo { get; set; }
        public string Lote { get; set; }
        public int Valor0 { get; set; }
        public int Valor1 { get; set; }
        public int Valor2 { get; set; }
        public int Lista { get; set; }
        public string OP { get; set; }
        public DateTime Fecha { get; set; }
        public int IdUsuario { get; set; }
    }

    public class CalidadGraficasCavidades
    {
        public CalidadGraficasCavidades()
        {
            Cav1 = false;
            Cav2 = false;
            Cav3 = false;
            Cav4 = false;
            Cav5 = false;
            Cav6 = false;
            Cav7 = false;
            Cav8 = false;
            Valores = new List<CalidadGraficasValores>();
        }

        public bool Cav1 { get; set; }
        public bool Cav2 { get; set; }
        public bool Cav3 { get; set; }
        public bool Cav4 { get; set; }
        public bool Cav5 { get; set; }
        public bool Cav6 { get; set; }
        public bool Cav7 { get; set; }
        public bool Cav8 { get; set; }
        public List<CalidadGraficasValores> Valores { get; set; }
        

    }

    public class CalidadGraficasValores
    {
        public CalidadGraficasValores()
        {
            Hora = new TimeSpan();
            Limite = 0;
            Val1 = 0;
            Val2 = 0;
            Val3 = 0;
            Val4 = 0;
            Val5 = 0;
            Val6 = 0;
            Val7 = 0;
            Val8 = 0;
        }

        public TimeSpan Hora { get; set; }
        public int Limite { get; set; }
        public int Val1 { get; set; }
        public int Val2 { get; set; }
        public int Val3 { get; set; }
        public int Val4 { get; set; }
        public int Val5 { get; set; }
        public int Val6 { get; set; }
        public int Val7 { get; set; }
        public int Val8 { get; set; }
    }
}
