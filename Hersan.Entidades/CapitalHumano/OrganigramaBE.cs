using Hersan.Entidades.Comun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hersan.Entidades.Catalogos
{
   public class OrganigramaBE
    {
        public OrganigramaBE()
        {
            Id = 0;
            Nivel = 0;
            IdJefe = 0;
            NombreJefe = string.Empty;
            Entidades = new EntidadesBE();
            Departamentos = new DepartamentosBE();
            Puestos = new PuestosBE();
            DatosUsuario = new GeneralBE();
        }
        public int Id { get; set; }
        public int IdJefe { get; set; }
        public string NombreJefe { get; set; }
        public int Nivel { get; set; }
        public EntidadesBE Entidades { get; set; }
        public PuestosBE Puestos { get; set; }
        public DepartamentosBE Departamentos { get; set; }
        public GeneralBE DatosUsuario { get; set; }
    }
}
