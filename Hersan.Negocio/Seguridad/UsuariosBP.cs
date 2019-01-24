using Hersan.Entidades.Seguridad;
using Hersan.Datos.Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hersan.Entidades.Comun;

namespace Hersan.Negocio.Seguridad
{
    public class UsuariosBP
    {
        /// <summary>
        /// Valida que las credenciales del usuario sean correctas
        /// </summary>
        /// <param name="nomUsr">Cuenta usuario</param>
        /// <param name="Pswd">Contraseña Encriptada</param>
        /// <returns></returns>
        public ValidaIngresoBE ValidaUsuario(string nomUsr, string Pswd)
        {
            return new UsuariosDA().ValidaUsuario(nomUsr, Pswd);
        }

        /// <summary>
        /// Verifica si hay bloqueo del usuario
        /// </summary>
        /// <param name="nomUsr">Cuenta usuario</param>
        /// <returns></returns>
        public ValidaIngresoBE ObtienBloqueoUsuario(string nomUsr)
        {
            return new UsuariosDA().ObtienBloqueoUsuario(nomUsr);
        }

        /// <summary>
        /// Desbloquea usuario
        /// </summary>
        /// <param name="nomUsr">Cuenta usuario</param>
        public void DesbloqueaUsuario(string nomUsr)
        {
            new UsuariosDA().DesbloqueaUsuario(nomUsr);
        }

        public int CambiaContrasenia(UsuariosBE Usuario)
        {
            return new UsuariosDA().CambiaContrasenia(Usuario);
        }             

        /// <summary>
        /// Obtiene los usuarios dados de alto en el sistema
        /// </summary>
        /// <returns></returns>
        public List<UsuariosBE> ObtieneUsuarios()
        {
            return new UsuariosDA().ObtieneUsuarios();
        }

        /// <summary>
        /// Guarda el nuevo usuario
        /// </summary>
        /// <param name="Usuario">Usuario que se va a crear</param>
        /// <param name="IdUsuarioCrea">Usuario que guarda el nuevo usuario</param>
        public ResultadoBE GuardaUsuario(UsuariosBE Usuario, int IdUsuarioCrea)
        {
            return new UsuariosDA().GuardaUsuario(Usuario, IdUsuarioCrea);
        }


        /// <summary>
        /// Actualiza el usuario
        /// </summary>
        /// <param name="Usuario">Usuario que se va a actualizar</param>
        /// <param name="IdUsuarioMod">Usuario que actualiza</param>
        public ResultadoBE ActualizaUsuario(UsuariosBE Usuario, int IdUsuarioMod)
        {
            return new UsuariosDA().ActualizaUsuario(Usuario, IdUsuarioMod);
        }

        /// <summary>
        /// Obtiene los datos del usuario
        /// </summary>
        /// <param name="Usuario">usuario a consultar</param>
        /// <returns></returns>
        public UsuariosBE ObtieneDatosUsuario(string Usuario)
        {
            return new UsuariosDA().ObtieneDatosUsuario(Usuario);
        }

    }
}
