using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hersan.Entidades.Seguridad
{
    public class MenusBE
    {
        public MenusBE()
        {
            ID = 0;
            Menu = string.Empty;
            Auxiliar = string.Empty;
            Descripcion = string.Empty;
            Activo = false;
            RutaIcono = string.Empty;
            IDPadre = 0;
            UrlMenu = string.Empty;
            NombreForma = string.Empty;
            AssemblyDll = string.Empty;
            AssemblyNamespace = string.Empty;
            Asignado = false;
            Orden = 0;
            PuedeAgregar = false;
            PuedeEditar = false;
            PuedeEliminar = false;
        }

        #region Propiedades        
        public int ID {
            get;
            set;
        }        
        public string Menu {
            get;
            set;
        }
        public string Auxiliar {
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
        public string RutaIcono {
            get;
            set;
        }
        public int IDPadre {
            get;
            set;
        }
        public string UrlMenu {
            get;
            set;
        }
        public string NombreForma {
            get;
            set;
        }
        public string AssemblyDll {
            get;
            set;
        }
        public string AssemblyNamespace {
            get;
            set;
        }
        public bool Asignado {
            get;
            set;
        }
        public int Orden {
            get;
            set;
        }
        public bool PuedeAgregar {
            get;
            set;
        }
        public bool PuedeEditar {
            get;
            set;
        }
        public bool PuedeEliminar {
            get;
            set;
        }
        //public ProcesosMenuBE proceso {
        //    get;
        //    set;
        //}
        public bool Demo {
            get;
            set;
        }
        #endregion
    }
}
