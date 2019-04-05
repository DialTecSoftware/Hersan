using Hersan.Entidades.Comun;

namespace Hersan.Entidades.Relchec
{
    public class HorariosBE
    {
        public HorariosBE()
        {
            Id = 0;
            Nombre = string.Empty;
            HoraEnt = 0;
            MinutoEnt = 0;
            HoraSalida = 0;
            MinutoSalida = 0;
            HorSalComida = 0;
            MinSalComida = 0;
            HorEntComida = 0;
            MinEntComida = 0;
            Tolerancia = 0;
             DatosUsuario = new GeneralBE();
                                                          
             
        }
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int HoraEnt { get; set; }
        public int MinutoEnt { get; set; }
        public int HoraSalida { get; set; }
        public int MinutoSalida { get; set; }
        public int HorSalComida { get; set; }
        public int MinSalComida { get; set; }
        public int HorEntComida { get; set; }
        public int MinEntComida { get; set; }
        public int Tolerancia { get; set; }
        public GeneralBE DatosUsuario { get; set; }


    }
}
