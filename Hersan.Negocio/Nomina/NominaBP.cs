﻿using Hersan.Datos.Nomina;
using Hersan.Entidades.Nomina;
using System;
using System.Collections.Generic;


namespace Hersan.Negocio.Nomina
{
    public class NominaBP
    {
        public List<NominaBE> NOM_CalculoNomina(int Semana)
        {
            return new NominaDA().NOM_CalculoNomina(Semana);
        }

        public int NOM_Prestamos_Guardar(PrestamosBE Obj, System.Data.DataTable Detalle)
        {
            return new NominaDA().NOM_Prestamos_Guardar(Obj, Detalle);
        }

        public int NOM_Incidencias_Guardar(List<IncidenciasBE> Lista)
        {
            return new NominaDA().NOM_Incidencias_Guardar(Lista);
        }
        public List<IncidenciasBE> NOM_Incidencias_Obtener(int Semana)
        {
            return new NominaDA().NOM_Incidencias_Obtener(Semana);
        }
    }
}
