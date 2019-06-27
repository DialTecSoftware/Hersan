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
            Color = new ColoresBE();
            Detalle = new InyeccionDetalleBE();
            IdUsuario = 0;
            Fecha = DateTime.Today;
        }

        public int Id { get; set; }
        public string OP { get; set; }
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
        public bool Cav1 { get; set; }
        public bool Cav2 { get; set; }
        public bool Cav3 { get; set; }
        public bool Cav4 { get; set; }
        public bool Cav5 { get; set; }
        public bool Cav6 { get; set; }
        public bool Cav7 { get; set; }
        public bool Cav8 { get; set; }
    }
}
