using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hersan.Entidades.Comun
{
    public class ResultadoBE
    {
        public ResultadoBE()
        {
            EsValido = true;
            Error = string.Empty;
            ID = 0;
        }

        /// <summary>
        /// Id del registro
        /// </summary>
        public int ID {
            get;
            set;
        }

        /// <summary>
        /// Indica si la actualización o inserción es valido
        /// </summary>
        public bool EsValido {
            get;
            set;
        }

        /// <summary>
        /// Indica cual fue el error en el intento de guardar cambios
        /// </summary>
        public string Error {
            get;
            set;
        }
    }
}
