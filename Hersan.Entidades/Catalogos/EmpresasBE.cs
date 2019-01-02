using Hersan.Entidades.Comun;

namespace Hersan.Entidades.Catalogos
{
    public class EmpresasBE
    {
        public EmpresasBE() {
            Id = 0;
            NombreComercial = string.Empty;
            NombreFiscal = string.Empty;
            RFC = string.Empty;
            Direccion = string.Empty;
            NoExterior = string.Empty;
            NoInterior = string.Empty;
            RegimenFiscal = string.Empty;
            Telefonos = string.Empty;
            Correo = string.Empty;
            Contacto = string.Empty;
            Estado = new EstadosBE();
            Ciudad = new CiudadesBE();
            Colonia = new ColoniasBE();
            DatosUsuario = new GeneralBE();
        }

        public int Id { get; set; }
        public string NombreComercial { get; set; }
        public string NombreFiscal { get; set; }
        public string RFC { get; set; }
        public string Direccion { get; set; }
        public string NoExterior  { get; set; }
        public string NoInterior { get; set; }
        public string RegimenFiscal { get; set; }
        public string Telefonos { get; set; }
        public string Correo { get; set; }
        public string Contacto { get; set; }
        public EstadosBE Estado { get; set; }
        public CiudadesBE Ciudad { get; set; }
        public ColoniasBE Colonia { get; set; }
        public GeneralBE DatosUsuario { get; set; }

    }
}