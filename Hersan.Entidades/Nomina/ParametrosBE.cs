using Hersan.Entidades.Comun;

namespace Hersan.Entidades.Nomina
{
    public class ParametrosBE
    {
        public ParametrosBE()
        {
            Id = 0;
            Dias = 0;
            Horas = 0;
            Faltas = 0;
            Retardos = 0;
            Vales = 0;
            Asistencia = 0;
            Puntualidad = 0;
            Ahorro = 0;
            Interes = 0;
            Danios = 0;
            Extras = 0;
            DatosUsuario = new GeneralBE();
        }

        public int Id { get; set; }
        public int Dias { get; set; }
        public int Horas { get; set; }
        public int Faltas { get; set; }
        public int Retardos { get; set; }
        public decimal Vales { get; set; }
        public decimal UMA { get; set; }
        public decimal Asistencia { get; set; }
        public decimal Puntualidad { get; set; }
        public decimal Ahorro { get; set; }
        public decimal Interes { get; set; }
        public decimal Danios { get; set; }
        public int Extras { get; set; }
        public GeneralBE DatosUsuario { get; set; }
    }
}
