using Hersan.Entidades.Catalogos;
using Hersan.Entidades.Comun;

namespace Hersan.Entidades.APT
{
    public class AlmacenPTBE
    {
        public AlmacenPTBE()
        {
            Id = 0;
            Empresa = new EmpresasBE();
            Nombre = string.Empty;
            Abrev = string.Empty;
            DatosUsuario = new GeneralBE();
        }

        public int Id { get; set; }
        public EmpresasBE Empresa { get; set; }
        public string Nombre { get; set; }
        public string Abrev { get; set; }
        public GeneralBE DatosUsuario { get; set; }
    }
}
