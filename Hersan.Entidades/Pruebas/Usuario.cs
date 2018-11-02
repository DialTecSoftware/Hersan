using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hersan.Entidades.Pruebas
{
    [Table("Usuario")]
    public partial class Usuario
    {

        public int Asisleg_id { get; set; }

        public int AsisLeg_Usuario { get; set; }

        //public virtual ICollection<UsuarioNombre> UsuarioNombre { get; set; }
    }

}
