using Hersan.Entidades.Catalogos;
using Hersan.Entidades.Comun;
using System;
using System.Collections.Generic;

namespace Hersan.Entidades.CapitalHumano
{
    public class ExpedientesBE
    {

        public ExpedientesBE()
        {
            Id = 0;
            Puesto = new PuestosBE();
            SueldoAprobado = 0;
            SueldoDeseado = 0;
            FechaContratado = string.Empty;
            Candidato = false;
            Comentarios = string.Empty;
            RutaImagen = string.Empty;
            DatosPersonales = new ExpedientesDatosPersonales();
            Documentos = new ExpedienteDocumentos();
            Familia = new List<ExpedienteFamilia>();
            Estudios = new List<ExpedienteEstudios>();

            DatosUsuario = new GeneralBE();
        }

        public int Id { get; set; }
        public PuestosBE Puesto { get; set; }
        public string FechaContratado { get; set; }
        public decimal SueldoDeseado { get; set; }
        public decimal SueldoAprobado { get; set; }
        public bool Candidato { get; set; }
        public string Comentarios { get; set; }
        public string RutaImagen { get; set; }
        public GeneralBE DatosUsuario { get; set; }

        public ExpedientesDatosPersonales DatosPersonales { get; set; }
        public ExpedienteDocumentos Documentos { get; set; }
        public List<ExpedienteFamilia> Familia { get; set; }
        public List<ExpedienteEstudios> Estudios { get; set; }
        public List<ExpedienteEmpleos> Empleos { get; set; }

    }

    public class ExpedientesDatosPersonales
    {

        public ExpedientesDatosPersonales()
        {
            IdExpediente = 0;
            APaterno = string.Empty;
            AMaterno = string.Empty;
            Nombres = string.Empty;
            Edad = 0;
            Direccion = string.Empty;
            Estado = new EstadosBE();
            Ciudad = new CiudadesBE();
            Colonia = new ColoniasBE();
            EstadoNac = new EstadosBE();
            CiudadNac = new CiudadesBE();
            Telefono = string.Empty;
            Sexo = string.Empty;
            FechaNac = string.Empty;
            Nacionalidad = string.Empty;
            ViveCon = string.Empty;
            Estatura = 0;
            Peso = 0;
            Dependientes = string.Empty;
            OtrosDependientes = string.Empty;
            EdoCivil = string.Empty;
            EdoCivilOtro = string.Empty;
            DatosUsuario = new GeneralBE();
        }

        public int IdExpediente { get; set; }
        public string APaterno { get; set; }
        public string AMaterno { get; set; }
        public string Nombres { get; set; }
        public int Edad { get; set; }
        public string Direccion { get; set; }
        public EstadosBE Estado { get; set; }
        public CiudadesBE Ciudad { get; set; }
        public ColoniasBE Colonia { get; set; }
        public EstadosBE EstadoNac { get; set; }
        public CiudadesBE CiudadNac { get; set; }
        public string Telefono { get; set; }
        public string Sexo { get; set; }
        public string FechaNac { get; set; }
        public string Nacionalidad { get; set; }
        public string ViveCon { get; set; }
        public decimal Estatura { get; set; }
        public decimal Peso { get; set; }
        public string Dependientes { get; set; }
        public string OtrosDependientes { get; set; }
        public string EdoCivil { get; set; }
        public string EdoCivilOtro { get; set; }
        public GeneralBE DatosUsuario { get; set; }
    }

    public class ExpedienteDocumentos
    {
        public ExpedienteDocumentos()
        {
            IdExpediente = 0;
            CURP = string.Empty;
            Afore = string.Empty;
            RFC = string.Empty;
            IMSS = string.Empty;
            Servicio = string.Empty;
            Pasaporte = string.Empty;
            Licencia = false;
            NoLicencia = string.Empty;
            DoctoExtranjero = string.Empty;
            DatosUuario = new GeneralBE();
        }

        public int IdExpediente { get; set; }
        public string CURP { get; set; }
        public string Afore { get; set; }
        public string RFC { get; set; }
        public string IMSS { get; set; }
        public string Servicio { get; set; }
        public string Pasaporte { get; set; }
        public bool Licencia { get; set; }
        public string NoLicencia { get; set; }
        public string DoctoExtranjero { get; set; }
        public GeneralBE DatosUuario { get; set; }
    }

    public class ExpedienteFamilia
    {

        public ExpedienteFamilia()
        {
            IdExpediente = 0;
            Parentesco = string.Empty;
            Nombre = string.Empty;
            Vivo = false;
            Direccion = string.Empty;
            Ocupacion = string.Empty;
            Edad = 0;
            DatosUsuario = new GeneralBE();
        }

        public int IdExpediente { get; set; }
        public string Parentesco { get; set; }
        public string Nombre { get; set; }
        public bool Vivo { get; set; }
        public string Direccion { get; set; }
        public string Ocupacion { get; set; }
        public int Edad { get; set; }
        public GeneralBE DatosUsuario { get; set; }
    }

    public class ExpedienteEstudios
    {

        public ExpedienteEstudios()
        {
            IdExpediente = 0;
            Nivel = string.Empty;
            Nombre = string.Empty;
            Direccion = string.Empty;
            Desde = 0;
            Hasta = 0;
            Anios = 0;
            Titulo = string.Empty;
            Actual = string.Empty;
            Escuela = string.Empty;
            Horario = string.Empty;
            Curso = string.Empty;
            Grado = string.Empty;
            DatosUsuario = new GeneralBE();
        }

        public int IdExpediente { get; set; }
        public string Nivel { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public int Desde { get; set; }
        public int Hasta { get; set; }
        public int Anios { get; set; }
        public string Titulo { get; set; }
        public string Actual { get; set; }
        public string Escuela { get; set; }
        public string Horario { get; set; }
        public string Curso { get; set; }
        public string Grado { get; set; }
        public GeneralBE DatosUsuario { get; set; }
    }

    public class ExpedienteEmpleos
    {

        public ExpedienteEmpleos()
        {
            IdExpediente = 0;
            Tiempo = 0;
            Empresa = string.Empty;
            Direccion = string.Empty;
            Telefono = string.Empty;
            Puesto = string.Empty;
            SueldoIni = 0;
            SueldoFin = 0;
            Separacion = string.Empty;
            Jefe = string.Empty;
            PuestoJefe = string.Empty;
            Informes = false;
            Razon = string.Empty;
            Comentarios = string.Empty;
            DatosUsuario = new GeneralBE();
        }

        public int IdExpediente { get; set; }
        public int Tiempo { get; set; }
        public string Empresa { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Puesto { get; set; }
        public decimal SueldoIni { get; set; }
        public decimal SueldoFin { get; set; }
        public string Separacion { get; set; }
        public string Jefe { get; set; }
        public string PuestoJefe { get; set; }
        public bool Informes { get; set; }
        public string Razon { get; set; }
        public string Comentarios { get; set; }
        public GeneralBE DatosUsuario { get; set; }
    }
}