using Hersan.Entidades.Comun;


namespace Hersan.Entidades.Catalogos
{
   public class TiposContratoBE
    {

        public TiposContratoBE()
        {
            Id = 0;
            Nombre = string.Empty;
            Abrev = string.Empty;
            DatosUsuario = new GeneralBE();
        }


        public int Id { get; set; }
        public string  Nombre { get; set; }
        public string Abrev { get; set; }
        public GeneralBE DatosUsuario { get; set; }
    }
}
