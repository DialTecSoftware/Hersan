using Hersan.Entidades.Catalogos;
using Hersan.Entidades.Comun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hersan.Entidades.CapitalHumano
{
   public  class SeguimientoCandidatosBE
    {
        public SeguimientoCandidatosBE()
        {
            Id = 0;
            NombreCompleto = string.Empty;
            Correo = string.Empty;
            Aceptado = false;
            Proceso = false;
            Rechazado = false;
            Entidades = new EntidadesBE();
            Departamentos = new DepartamentosBE();
            Puestos = new PuestosBE();
            DatosUsuario = new GeneralBE();
        }
        public int Id { get; set; }
        public string NombreCompleto { get; set; }
        public string  Correo { get; set; }
        public bool Aceptado { get; set; }
        public bool Rechazado { get; set; }
        public bool Proceso { get; set; }
        public EntidadesBE Entidades { get; set; }
        public DepartamentosBE Departamentos { get; set; }
        public PuestosBE Puestos { get; set; }
        public GeneralBE DatosUsuario { get; set; }
    }
}
