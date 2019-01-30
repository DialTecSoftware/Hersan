using Hersan.Entidades.Catalogos;
using Hersan.Entidades.Comun;
using System.Collections.Generic;

namespace Hersan.Entidades.CapitalHumano
{
    public class PerfilesBE
    {
        public PerfilesBE() {
            Sel = false;
            Id = 0;
            Experiencia = string.Empty;
            Puesto = new PuestosBE();
            Educacion = new List<EducacionBE>();
            Competencia = new List<CompetenciasBE>();
            Funcion = new List<FuncionesBE>();
            DatosUsuario = new GeneralBE();
        }

        public bool Sel { get; set; }
        public int Id { get; set; }
        public string Experiencia { get; set; }
        public PuestosBE Puesto { get; set; }
        public List<EducacionBE> Educacion { get; set; }
        public List<CompetenciasBE> Competencia { get; set; }
        public List<FuncionesBE> Funcion { get; set; }
        public GeneralBE DatosUsuario { get; set; }
    }

    public class PerfilDescripcionBE
    {
        public PerfilDescripcionBE()
        {
            Sel = false;
            Id = 0;
            Puesto = new PuestosBE();
            Grupo = string.Empty;
            Concepto = string.Empty;
            Tipo = string.Empty;
            Perfil = new PerfilesBE();
            DatosUsuario = new GeneralBE();
        }

        public bool Sel { get; set; }
        public int Id { get; set; }
        public PuestosBE Puesto { get; set; }
        public string Grupo { get; set; }
        public string Concepto { get; set; }
        public string Tipo { get; set; }
        public PerfilesBE Perfil { get; set; }
        public GeneralBE DatosUsuario { get; set; }
    }
}
