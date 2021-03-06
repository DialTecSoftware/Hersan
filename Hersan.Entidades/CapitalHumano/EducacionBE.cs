﻿using Hersan.Entidades.Comun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hersan.Entidades.Catalogos
{
    public class EducacionBE
    {

        public EducacionBE()
        {
            Id = 0;
            Nombre = string.Empty;
            Abrev = string.Empty;
            Tipo = string.Empty;
            DatosUsuario = new GeneralBE();

        }
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Abrev { get; set; }
        public string Tipo { get; set; }
        public GeneralBE DatosUsuario { get; set; }
    }
}
