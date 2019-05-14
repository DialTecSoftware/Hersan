using Hersan.Entidades.Catalogos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hersan.Entidades.Vialidad
{
    public class ProductosVialidadBE
    {

        public EntidadesBE Entidad { get; set; }
        public string Producto { get; set; }
        public string Caracteristica { get; set; }
        public decimal Precio { get; set; }
    }
}
