using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hersan.Entidades.Seguridad
{
    public class RolesBE
    {
        public RolesBE()
        {
            ID = 0;
            Nombre = string.Empty;
            Descripcion = string.Empty;
            Activo = true;
            EsAsignado = false;
        }
        
        public int ID {
            get;
            set;
        }
        public string Nombre {
            get;
            set;
        }
        public string Descripcion {
            get;
            set;
        }
        public bool Activo {
            get;
            set;
        }
        public bool EsAsignado {
            get;
            set;
        }
    }
}
