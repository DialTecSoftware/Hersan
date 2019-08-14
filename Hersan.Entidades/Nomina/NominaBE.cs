using Hersan.Entidades.CapitalHumano;
using Hersan.Entidades.Comun;


namespace Hersan.Entidades.Nomina
{
    public class NominaBE
    {
        public NominaBE()
        {
            Id = 0;
            Sel = false;
            Semana = new SemanasBE();
            Empleado = new EmpleadosBE();
            Percepciones = new PercepcionesBE();
            Deducciones = new DeduccionesBE();
            Total = 0;
            DatosUsuario = new GeneralBE();
        }

        public int Id { get; set; }
        public bool Sel { get; set; }
        public SemanasBE Semana { get; set; }
        public EmpleadosBE Empleado { get; set; }
        public PercepcionesBE Percepciones { get; set; }
        public DeduccionesBE Deducciones { get; set; }
        public decimal Total { get; set; }
        public GeneralBE DatosUsuario { get; set; }
    }

    public class PercepcionesBE
    {
        public PercepcionesBE()
        {
            Puntualidad = 0;
            Asistencia = 0;
            Vales = 0;
            HBono = 0;
            HExtra = 0;
            Total = 0;
            DatosUsuario = new GeneralBE();
        }

        public decimal Puntualidad { get; set; }
        public decimal Asistencia { get; set; }
        public decimal Vales { get; set; }
        public decimal HBono { get; set; }
        public decimal HExtra { get; set; }
        public decimal Total { get; set; }
        public GeneralBE DatosUsuario { get; set; }
    }

    public class DeduccionesBE
    {
        public DeduccionesBE()
        {
            Imss = 0;
            Fonacot = 0;
            Infonavit = 0;
            FAhorro = 0;
            Aportacion = 0;
            Prestamo = new PrestamosBE();
            Faltas = 0;
            Pension = 0;
            ISR = 0;
            Total = 0;
            DatosUsuario = new GeneralBE();
        }

        public decimal Imss { get; set; }
        public decimal Fonacot { get; set; }
        public decimal Infonavit { get; set; }
        public decimal FAhorro { get; set; }
        public decimal Aportacion { get; set; }
        public PrestamosBE Prestamo { get; set; }
        public decimal Faltas { get; set; }
        public decimal Pension { get; set; }
        public decimal ISR { get; set; }
        public decimal Total { get; set; }
        public GeneralBE DatosUsuario { get; set; }
    }

}
