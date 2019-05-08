using Hersan.Entidades.Catalogos;
using Hersan.Entidades.Comun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hersan.Entidades.CapitalHumano
{
   public class NuevoPuestoBE
    {

        public NuevoPuestoBE()
        {
            Id = 0;
            Nombre = string.Empty;
            Objetivos = string.Empty;
            Indicadores = string.Empty;
            PuestosCargo = string.Empty;
            Sueldo = 0;
            Prestaciones = string.Empty;
            Necesidades = string.Empty;
            Ocupantes = 0;
            Resultados = string.Empty;
            Justificacion = string.Empty;
            Entidades = new EntidadesBE();
            Departamentos = new DepartamentosBE();
            DatosUsuario = new GeneralBE();
            Estado = string.Empty;
       



        }
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Objetivos { get; set; }
        public string  Indicadores { get; set; }
        public string  PuestosCargo { get; set; }
        public decimal Sueldo { get; set; }
        public string  Prestaciones { get; set; }
        public string Necesidades { get; set; }
        public int  Ocupantes { get; set; }
        public string  Resultados { get; set; }
        public string Justificacion { get; set; }
        public string OpinionesCH { get; set; }
        public string OpinionesDG { get; set; }
        public string Estado { get; set; }
        public EntidadesBE Entidades { get; set; }
        public DepartamentosBE Departamentos { get; set; }
        public GeneralBE DatosUsuario { get; set; }

    }
}
