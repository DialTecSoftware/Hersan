using Hersan.Entidades.Comun;


namespace Hersan.Entidades.Catalogos
{
    public class AgentesBE
    {

        public AgentesBE()
        {
            Id = 0;
            Clave = string.Empty;
            Nombre = string.Empty;
            Correo = string.Empty;
            Comision = 0;
            DatosUsuario = new GeneralBE();
        }

        public int Id { get; set; }
        public string Clave { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public decimal Comision { get; set; }
        public GeneralBE DatosUsuario { get; set; }
    }
}
