using Hersan.Entidades.Comun;

namespace Hersan.Entidades.Catalogos
{
    public class FamiliasBE
    {
        public FamiliasBE()
        {
            Id = 0;
            Clave = string.Empty;
            Nombre = string.Empty;
            Entidad = new EntidadesBE();
            DatosUsuario = new GeneralBE();
        }

        public int Id { get; set; }
        public EntidadesBE Entidad { get; set; }
        public string Clave { get; set; }
        public string Nombre { get; set; }
        public GeneralBE DatosUsuario { get; set; }
    }
}