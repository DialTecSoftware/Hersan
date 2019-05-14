using Hersan.Entidades.Comun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hersan.Entidades.CapitalHumano
{
    public class DescripcionPuestosBE
    {
        public DescripcionPuestosBE()
        {
            Id = 0;
            Perfiles = new PerfilesBE();
            Colabordores = 0;
            Superior = 0;
            Inferior = 0;
            Clave = string.Empty;
            Objetivo = string.Empty;
            Autoridad = string.Empty;
            Observaciones = string.Empty;
            DatosUsuario = new GeneralBE();
        }
        public int Id { get; set; }
        public PerfilesBE Perfiles { get; set; }
        public GeneralBE DatosUsuario { get; set; }
        public int Colabordores { get; set; }
        public int Superior { get; set; }
        public int Inferior { get; set; }
        public string Clave { get; set; }
        public string Objetivo { get; set; }
        public string Autoridad { get; set; }
        public string Observaciones { get; set; }

    }



    public class DescPuestosContactosBE
     {
        public DescPuestosContactosBE()
        {
            Id = 0;
            Tipo = false;
            TipoCon = string.Empty;
            Sel = false;
            Concepto = string.Empty;
            Perfiles = new PerfilesBE();
            DatosUsuario = new GeneralBE();
        }
        
        public int Id { get; set; }
        public bool Tipo { get; set; }
        public string TipoCon { get; set; }
        public bool Sel { get; set; }
        public string Concepto { get; set; }
        public PerfilesBE Perfiles { get; set; }
        public GeneralBE DatosUsuario { get; set; }
    }

    public class DescPuestoContratoTrabajo
    {
        public DescPuestoContratoTrabajo()
        {
            EsfuerzoFisico = string.Empty;
            Riesgos = string.Empty;
            CondicionesAmb = string.Empty;
            EquipoRequerido = string.Empty;
        }
        public  string EsfuerzoFisico { get; set; }
        public string Riesgos { get; set; }
        public string CondicionesAmb { get; set; }
        public string EquipoRequerido { get; set; }
    }
     
}
