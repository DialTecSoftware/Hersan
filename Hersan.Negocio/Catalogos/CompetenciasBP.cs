﻿using Hersan.Datos.Catalogos;
using Hersan.Entidades.Catalogos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hersan.Negocio.Catalogos
{
    public class CompetenciasBP
    {
        public List<CompetenciasBE> ABCCompetencias_Obtener()
        {
            return new CompetenciasDA().ABCCompetencias_Obtener();
        }
    }
}
