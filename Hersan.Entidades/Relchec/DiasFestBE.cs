using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hersan.Entidades.Comun;


namespace Hersan.Entidades.Relchec
{
    public class DiasFestBE
    {
        public DiasFestBE()
        {
            Id = 0;
            Nombre = string.Empty;
            dia = DateTime.Today;
            DatosUsuario = new GeneralBE();


        }
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime dia { get; set; }
        public GeneralBE DatosUsuario { get; set; }


    }
}

