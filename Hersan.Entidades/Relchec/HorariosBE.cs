using Hersan.Entidades.Comun;

namespace Hersan.Entidades.Relchec
{
    public class HorariosBE
    {
        public HorariosBE()
        {
            Id = 0;
            Nombre = string.Empty;
            HoraEnt = string.Empty;
            HoraSalida = string.Empty;
            HorSalComida = string.Empty;
            HorEntComida = string.Empty;
            Tolerancia = 0;
             DatosUsuario = new GeneralBE();
                                                          
             
        }
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string HoraEnt { get; set; }
        public string HoraSalida { get; set; }
        public string HorSalComida { get; set; }
        public string HorEntComida { get; set; }
        public int Tolerancia { get; set; }
        public GeneralBE DatosUsuario { get; set; }


    }
}
