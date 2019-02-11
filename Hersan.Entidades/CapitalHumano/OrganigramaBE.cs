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
            Estatus = false;
            Entidades = new EntidadesBE();
            Departamentos = new DepartamentosBE();
            Puestos = new PuestosBE();
        }
        public int Id { get; set; }
        public int IdJefe { get; set; }
        public string NombreJefe { get; set; }
        public int Nivel { get; set; }
        public bool Estatus { get; set; }
        public EntidadesBE Entidades { get; set; }
        public PuestosBE Puestos { get; set; }
        public DepartamentosBE Departamentos { get; set; }

    }
}
