using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hersan.Entidades.Comun
{
    [AttributeUsage(AttributeTargets.All)]
    public class CustomAttribute : Attribute
    {
        public CustomAttribute(string text)
        {
            Tipo = text;
        }
        public string Tipo { get; set; }
    }
}
