using Hersan.Entidades.Catalogos;
using Hersan.Entidades.Comun;

namespace Hersan.Entidades.CapitalHumano
{
    public class PerfilesBE
    {
        public PerfilesBE() {
            Sel = false;
            ID = 0;
            Experiencia = string.Empty;
            Puesto = new PuestosBE();
            DatosUsuario = new GeneralBE();
        }

        public bool Sel { get; set; }
        public int ID { get; set; }
        public string Experiencia { get; set; }
        public PuestosBE Puesto { get; set; }
        public GeneralBE DatosUsuario { get; set; }
    }

    public class PerfilEducacionBE
    {
        public PerfilEducacionBE()
        {
            ID = 0;
            Perfil = new PerfilesBE();
            Educacion = new EducacionBE();
            Necesaria = false;
            Preferente = false;
            DatosUsuario = new GeneralBE();
        }

        public int ID { get; set; }
        public PerfilesBE Perfil { get; set; }
        public EducacionBE Educacion { get; set; }
        public bool Necesaria { get; set; }
        public bool Preferente { get; set; }
        public GeneralBE DatosUsuario { get; set; }
    }

    public class PerfilCompetenciaBE
    {

        public PerfilCompetenciaBE()
        {
            ID = 0;
            Perfil = new PerfilesBE();
            Competencia = new CompetenciasBE();
            DatosUsuario = new GeneralBE();
        }

        public int ID { get; set; }
        public PerfilesBE Perfil { get; set; }
        public CompetenciasBE Competencia { get; set; }
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
