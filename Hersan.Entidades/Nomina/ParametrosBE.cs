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
            Vales = 0;
            Asistencia = 0;
            Puntualidad = 0;
            Ahorro = 0;
            DatosUsuario = new GeneralBE();
        }

        public int Id { get; set; }
        public int Dias { get; set; }
        public int Horas { get; set; }
        public decimal Vales { get; set; }
        public decimal UMA { get; set; }
        public decimal Asistencia { get; set; }
        public decimal Puntualidad { get; set; }
        public decimal Ahorro { get; set; }
        public GeneralBE DatosUsuario { get; set; }
    }
}
