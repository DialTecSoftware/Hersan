using Hersan.Entidades.Catalogos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hersan.Entidades.Ventas
{
    public class ProductosBE
    {
        public ProductosBE()
        {
            Entidad = new EntidadesBE();
            Producto = string.Empty;
            Caracteristica = string.Empty;
            Precio = 0;
        }

        public EntidadesBE Entidad { get; set; }
        public string Producto { get; set; }
        public string Caracteristica { get; set; }
        public decimal Precio { get; set; }
    }
}
