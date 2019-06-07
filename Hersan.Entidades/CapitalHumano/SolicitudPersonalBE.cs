using Hersan.Entidades.Catalogos;
using Hersan.Entidades.Comun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hersan.Entidades.CapitalHumano
{
   public class SolicitudPersonalBE
    {

        public SolicitudPersonalBE()
        {
            Id = 0;
            Sueldo = 0;
            Indicadores = string.Empty;
            Dictamen = string.Empty;
            Observaciones = string.Empty;
            Autorizado = false;
            Justificacion = string.Empty;
            Entidades = new EntidadesBE();
            Departamentos = new DepartamentosBE();
            TiposContrato = new TiposContratoBE();
            Puestos = new PuestosBE();
            DatosUsuario = new GeneralBE();


        }
        public int Id { get; set; }
        public decimal Sueldo { get; set; }
        public string Indicadores { get; set; }
        public string  Justificacion { get; set; }
        public string Dictamen { get; set; }
        public string Observaciones { get; set; }
        public bool Autorizado { get; set; }
        public bool NoAutorizado { get; set; }
        public EntidadesBE Entidades { get; set; }
        public PuestosBE Puestos { get; set; }
        public DepartamentosBE Departamentos { get; set; }
        public TiposContratoBE  TiposContrato { get; set; }
        public GeneralBE DatosUsuario { get; set; }
    }
}
