using Hersan.Entidades.Catalogos;
using Hersan.Entidades.Comun;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hersan.Entidades.Calidad
{
    public class EnsambleParametrosBE
    {
        public EnsambleParametrosBE()
        {
            Id = 0;
            OP = string.Empty;
            Lista = 0;
            Producto = new TipoProductoBE();
            Carcasa = new ColoresBE();
            Reflex1 = new ColoresBE();
            Reflex2 = new ColoresBE();
            Detalle = new List<EnsambleParametrosDetalleBE>();
            DatosUsuario = new GeneralBE();
        }

        public int Id { get; set; }
        public string OP { get; set; }
        public int Lista { get; set; }
        public TipoProductoBE Producto { get; set; }
        public ColoresBE Carcasa { get; set; }
        public ColoresBE Reflex1 { get; set; }
        public ColoresBE Reflex2 { get; set; }
        public List<EnsambleParametrosDetalleBE> Detalle { get; set; }
        public GeneralBE DatosUsuario { get; set; }
        

    }

    public class EnsambleParametrosDetalleBE 
    {

        public EnsambleParametrosDetalleBE()
        {
            Id = 0;
            IdParametro = 0;
            Maquina = string.Empty;
            Presion = 0;
            Energia = 0;
            Colapso = 0;
            Tiempo = string.Empty;
            Planeada = 0;
            Real = 0;
            Comentarios = string.Empty;
            Fecha = DateTime.Today;
            Estatus = false;
        }

        public int Id { get; set; }
        public int IdParametro { get; set; }
        public string Maquina { get; set; }
        public decimal Presion { get; set; }
        public decimal Energia { get; set; }
        public decimal Colapso { get; set; }
        public string Tiempo { get; set; }
        public int Planeada { get; set; }
        public int Real { get; set; }
        public string Comentarios { get; set; }
        public DateTime Fecha { get; set; }
        public bool Estatus { get; set; }
    }   
}
