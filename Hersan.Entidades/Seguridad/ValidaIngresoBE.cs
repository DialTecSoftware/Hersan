using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hersan.Entidades.Seguridad
{
    public class ValidaIngresoBE
    {
        public ValidaIngresoBE()
        {
            EsIngresoValido = false;
            EsUsuarioBloqueado = false;
            ErrorIngreso = "Usuario y/o contraseña invalidos.";
        }

        public bool EsIngresoValido {
            get;
            set;
        }
        public bool EsUsuarioBloqueado {
            get;
            set;
        }
        public string ErrorIngreso {
            get;
            set;
        }
    }
}
