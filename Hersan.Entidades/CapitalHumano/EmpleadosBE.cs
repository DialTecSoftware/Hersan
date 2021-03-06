﻿using Hersan.Entidades.Comun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hersan.Entidades.CapitalHumano
{
  public  class EmpleadosBE
    {

        public EmpleadosBE()
        {
            Id = 0;
            Numero = 0;
            Expedientes = new ExpedientesBE();
            Infonavit = string.Empty;
            Fonacot = string.Empty;
            TipoInfonavit = string.Empty;
            FechaAltaIMSS = string.Empty;
            NumeroCuenta = string.Empty;
            Pension = 0;
            Ahorro = 0;
            SueldoDiario = 0;
            SueldoDiarioIntegrado = 0;
            EstatusEmpleado = string.Empty;
            FechaIngreso = string.Empty;
            DatosUsuarios = new GeneralBE();
        }
        public int Id { get; set; }
        public int Numero { get; set; }
        public ExpedientesBE Expedientes { get; set; }
        public string Infonavit { get; set; }
        public string Fonacot { get; set; }
        public string TipoInfonavit { get; set; }
        public string FechaAltaIMSS { get; set; }
        public string NumeroCuenta { get; set; }
        public decimal Pension { get; set; }
        public decimal Ahorro { get; set; }
        public decimal SueldoDiario { get; set; }
        public decimal SueldoDiarioIntegrado { get; set; }
        public string EstatusEmpleado { get; set; }
        public string FechaIngreso { get; set; }
        public GeneralBE DatosUsuarios { get; set; }
    }
}
