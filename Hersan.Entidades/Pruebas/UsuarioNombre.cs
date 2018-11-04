using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hersan.Entidades.Pruebas
{
    public partial class UsuarioNombre
    {

        public int Asisleg_id { get; set; }


        public string AsisLeg_UsuarioNombre { get; set; }


        public string AsisLeg_UsuarioApellido { get; set; }

        public virtual Usuario Usuario { get; set; }
    }

}
