﻿using Hersan.Entidades.Comun;

namespace Hersan.Entidades.Catalogos
{
    public class TipoProductoBE
    {

        public TipoProductoBE()
        {
            Id = 0;
            Familia = new FamiliasBE();
            Clave = string.Empty;
            Nombre = string.Empty;
            Name = string.Empty;
            Fraccion = string.Empty;
            DatosUsuario = new GeneralBE();
        }

        public int Id { get; set; }
        public FamiliasBE Familia { get; set; }
        public string Clave { get; set; }
        public string Nombre { get; set; }
        public string Name { get; set; }
        public string Fraccion { get; set; }
        public GeneralBE DatosUsuario { get; set; }
    }
}
