﻿using Hersan.Entidades.Comun;

namespace Hersan.Entidades.CapitalHumano
{
    public class CompetenciasBE
    {
        public CompetenciasBE()
        {
            Id = 0;
            Nombre = string.Empty;
            Descripcion = string.Empty;
            Experiencia = 0;
            DatosUsuario = new GeneralBE();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Experiencia { get; set; }
        public GeneralBE DatosUsuario { get; set; }
    }
}
