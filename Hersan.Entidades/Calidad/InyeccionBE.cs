using Hersan.Entidades.Catalogos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hersan.Entidades.Inyeccion
{
    public class InyeccionBE
    {
        public InyeccionBE()
        {
            Id = 0;
            OP = string.Empty;
            Operador = string.Empty;
            Muestra = 0;
            Color = new ColoresBE();
            Detalle = new InyeccionDetalleBE();
            IdUsuario = 0;
            Fecha = DateTime.Today;
        }

        public int Id { get; set; }
        public string OP { get; set; }
        public string Operador { get; set; }
        public int Muestra { get; set; }
        public int IdUsuario { get; set; }
        public DateTime Fecha { get; set; }
        public ColoresBE Color { get; set; }
        public InyeccionDetalleBE Detalle { get; set; }
    }

    public class InyeccionDetalleBE
    {
        public InyeccionDetalleBE()
        {
            Id = 0;
            Fecha = DateTime.Today;
            Lista = string.Empty;
            Turno = string.Empty;
            Piezas = 0;
            Virgen = 0;
            Remolido = 0;
            Master = 0;
            Inicio = new TimeSpan();
            Fin = new TimeSpan();
            Real = 0;
            Muestra = 0;
            Porcentaje = 0;
            Cav1 = false;
            Cav2 = false;
            Cav3 = false;
            Cav4 = false;
            Cav5 = false;
            Cav6 = false;
            Cav7 = false;
            Cav8 = false;
        }

        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Lista { get; set; }
        public string Turno { get; set; }
        public int Piezas { get; set; }
        public decimal Virgen { get; set; }
        public decimal Remolido { get; set; }
        public decimal Master { get; set; }
        public TimeSpan Inicio { get; set; }
        public TimeSpan Fin { get; set; }
        public int Real { get; set; }
        public int Muestra { get; set; }
        public decimal Porcentaje { get; set; }
        public bool Cav1 { get; set; }
        public bool Cav2 { get; set; }
        public bool Cav3 { get; set; }
        public bool Cav4 { get; set; }
        public bool Cav5 { get; set; }
        public bool Cav6 { get; set; }
        public bool Cav7 { get; set; }
        public bool Cav8 { get; set; }
    }

    public class TemperaturasBE
    {
        public TemperaturasBE()
        {
            Cav1 = 0;
            Cav2 = 0;
            Cav3 = 0;
            Cav4 = 0;
            Cav5 = 0;
            Cav6 = 0;
            Cav7 = 0;
            Cav8 = 0;
            Cav9 = 0;
            Cav10 = 0;
            Cav11 = 0;
            Cav12 = 0;
            Observa = string.Empty;
            IdUsuario = 0;

        }

        public decimal Cav1 { get; set; }
        public decimal Cav2 { get; set; }
        public decimal Cav3 { get; set; }
        public decimal Cav4 { get; set; }
        public decimal Cav5 { get; set; }
        public decimal Cav6 { get; set; }
        public decimal Cav7 { get; set; }
        public decimal Cav8 { get; set; }
        public decimal Cav9 { get; set; }
        public decimal Cav10 { get; set; }
        public decimal Cav11 { get; set; }
        public decimal Cav12 { get; set; }
        public string  Observa { get; set; }
        public int IdUsuario{ get; set; }
    }

    public class TempMoldesBE
    {

        public TempMoldesBE()
        {
            Fija = 0;
            Movil = 0;
            IdUsuario = 0;
        }

        public decimal Fija { get; set; }
        public decimal Movil { get; set; }
        public int IdUsuario { get; set; }
    }

    public class ParametrosInyeccion
    {

        public ParametrosInyeccion()
        {
            Presion1 = 0;
            Presion2 = 0;
            Presion3 = 0;
            Velocidad1 = 0;
            Velocidad2 = 0;
            Velocidad3 = 0;
            PosicionC1 = 0;
            PosicionC2 = 0;
            VelocidadC1 = 0;
            VelocidadC2 = 0;
            Posicion = 0;
            Presion = 0;
            Velocidad = 0;
            Retardo = 0;
            Zona1 = 0;
            Zona2 = 0;
            Zona3 = 0;
            Zona4 = 0;
            IdUsuario = 0;
        }

        public decimal Presion1 { get; set; }
        public decimal Presion2 { get; set; }
        public decimal Presion3 { get; set; }
        public decimal Velocidad1 { get; set; }
        public decimal Velocidad2 { get; set; }
        public decimal Velocidad3 { get; set; }
        public decimal PosicionC1 { get; set; }
        public decimal PosicionC2 { get; set; }
        public decimal PresionC1 { get; set; }
        public decimal PresionC2 { get; set; }
        public decimal VelocidadC1 { get; set; }
        public decimal VelocidadC2 { get; set; }
        public decimal Posicion { get; set; }
        public decimal Presion { get; set; }
        public decimal Velocidad { get; set; }
        public decimal Retardo { get; set; }
        public decimal Zona4 { get; set; }
        public decimal Zona3 { get; set; }
        public decimal Zona2 { get; set; }
        public decimal Zona1 { get; set; }
        public int IdUsuario{ get; set; }
    }
}