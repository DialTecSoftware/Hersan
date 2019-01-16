﻿using Hersan.Entidades.Comun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hersan.Entidades.CapitalHumano
{
    public class FuncionesBE
    {
        public FuncionesBE()
        {
            Id = 0;
            Nombre = string.Empty;
            DatosUsuario = new GeneralBE();
        }
        public int Id { get; set; }
        public string Nombre { get; set; }
        public bool Continua { get; set; }
        public GeneralBE DatosUsuario { get; set; }
    }
}
