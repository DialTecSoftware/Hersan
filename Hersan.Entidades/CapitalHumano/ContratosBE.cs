using Hersan.Entidades.Catalogos;
using Hersan.Entidades.Comun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hersan.Entidades.CapitalHumano
{
    public class ContratosBE
    {

        public ContratosBE()
        {
            Id = 0;
            Nombre = string.Empty;
            DatosUsuario = new GeneralBE();
            Departamentos= new DepartamentosBE();
            TiposContrato = new TiposContratoBE();
        }
        public int Id { get; set; }
        public string Nombre { get; set; }
        public GeneralBE DatosUsuario { get; set; }
        public DepartamentosBE Departamentos { get; set; }
        public TiposContratoBE TiposContrato { get; set; }
    }
}
