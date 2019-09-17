using Hersan.Entidades.Comun;

namespace Hersan.Entidades.Catalogos {
    public class ProveedorBE 
    {
        public ProveedorBE()
        {
            Id = 0;
            Empresa = new EmpresasBE();
            Nombre = string.Empty;
            Fiscal = string.Empty;
            Direccion = string.Empty;
            RFC = string.Empty;
            Telefono = string.Empty;
            Correo = string.Empty;
            Estado = new EstadosBE();
            Ciudad = new CiudadesBE();
            Colonia = new ColoniasBE();
            DatosUsuario = new GeneralBE();
        }

        public int Id { get; set; }
        public EmpresasBE Empresa { get; set; }
        public string Nombre { get; set; }
        public string Fiscal { get; set; }
        public string Direccion{ get; set; }
        public string RFC { get; set; }
        public EstadosBE Estado{ get; set; }
        public CiudadesBE Ciudad { get; set; }
        public ColoniasBE Colonia { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public GeneralBE DatosUsuario { get; set; }
    }
}
