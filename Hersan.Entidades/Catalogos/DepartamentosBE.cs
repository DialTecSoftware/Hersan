using Hersan.Entidades.Comun;


namespace Hersan.Entidades.Catalogos
{
    public class DepartamentosBE
    {
        public DepartamentosBE()
        {
            Id = 0;
            Entidades = new EntidadesBE();
            Nombre = string.Empty;
            Abrev = string.Empty;
            DatosUsuario = new GeneralBE();
        }

        public int Id { get; set; }
        public EntidadesBE Entidades { get; set; }
        public string Nombre { get; set; }
        public string Abrev { get; set; }
        public GeneralBE DatosUsuario { get; set; }
        
    }
}
