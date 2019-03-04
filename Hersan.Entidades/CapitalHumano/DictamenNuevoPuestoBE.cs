using Hersan.Entidades.Catalogos;
using Hersan.Entidades.Comun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hersan.Entidades.CapitalHumano
{
    public class DictamenNuevoPuestoBE
    {

        public DictamenNuevoPuestoBE()
        {
            Id = 0;
            OpinionesCH = string.Empty;
            OpinionesDG = string.Empty;
            Autorizado = false;
            NoAutorizado = false;
            NuevoPuesto = new NuevoPuestoBE();
            Departamentos = new DepartamentosBE();
            Entidades = new EntidadesBE();
            DatosUsuario = new GeneralBE();
        }
        public int Id { get; set; }
        public string OpinionesCH { get; set; }
        public string OpinionesDG { get; set; }
        public bool Autorizado { get; set; }
        public bool NoAutorizado { get; set; }
        public NuevoPuestoBE NuevoPuesto { get; set; }
        public DepartamentosBE Departamentos { get; set; }
        public EntidadesBE Entidades { get; set; }
        public GeneralBE DatosUsuario { get; set; }
    }
}
