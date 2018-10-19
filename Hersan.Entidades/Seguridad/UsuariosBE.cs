using Hersan.Entidades.Catalogos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hersan.Entidades.Seguridad
{
    public class UsuariosBE
    {
        public UsuariosBE()
        {
            ID = 0;
            Nombre = string.Empty;
            Correo = string.Empty;
            Usuario = string.Empty;
            Contrasena = string.Empty;
            Activo = false;
            EsSuper = false;
            Rol = new RolesBE();
            Validado = false;
            SesionID = string.Empty;
            Bloqueado = true;
            Empresa = new EmpresasBE();
        }

        public int ID {
            get;
            set;
        }
        public string Nombre {
            get;
            set;
        }        
        public string Correo {
            get;
            set;
        }
        public string Usuario {
            get;
            set;
        }
        public string Contrasena {
            get;
            set;
        }
        public Boolean Activo {
            get;
            set;
        }
        public Boolean EsSuper {
            get;
            set;
        }
        public RolesBE Rol {
            get;
            set;
        }
        public bool Validado {
            get;
            set;
        }
        public string SesionID {
            get;
            set;
        }
        public bool Bloqueado {
            get;
            set;
        }
        public EmpresasBE Empresa { get; set; }
    }
}
