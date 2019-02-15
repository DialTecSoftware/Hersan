using Hersan.Entidades.Catalogos;
using Hersan.Entidades.Comun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hersan.Entidades.CapitalHumano
{
    public class DictamenSustitucionBE
    {
        public DictamenSustitucionBE()
        {
            Id = 0;
            Dictamen = string.Empty;
            Observaciones = string.Empty;
            Aceptado = false;
            Rechazado = false;
            Solicitud = new SolicitudPersonalBE();
            DatosUsuario = new GeneralBE();
            Entidades = new EntidadesBE();
            Departamentos = new DepartamentosBE();
            Puestos = new PuestosBE();
            TiposContrato = new TiposContratoBE();
        }

        public int Id { get; set; }
        public string  Dictamen { get; set; }
        public string Observaciones { get; set; }
        public bool Aceptado { get; set; }
        public bool Rechazado { get; set; }
        public SolicitudPersonalBE Solicitud { get; set; }
        public GeneralBE DatosUsuario { get; set; }
        public EntidadesBE Entidades { get; set; }
        public PuestosBE Puestos { get; set; }
        public DepartamentosBE Departamentos { get; set; }
        public TiposContratoBE TiposContrato { get; set; }
    }
}
