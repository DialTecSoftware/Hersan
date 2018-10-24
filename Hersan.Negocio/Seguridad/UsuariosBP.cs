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
        public ValidaIngresoBE ValidaUsuario(string nomUsr, string Pswd, int IdEmpresa)
        {
            return new UsuariosDA_1().ValidaUsuario(nomUsr, Pswd, IdEmpresa);
        }

        /// <summary>
        /// Verifica si hay bloqueo del usuario
        /// </summary>
        /// <param name="nomUsr">Cuenta usuario</param>
        /// <returns></returns>
        public ValidaIngresoBE ObtienBloqueoUsuario(string nomUsr, int IdEmpresa)
        {
            return new UsuariosDA_1().ObtienBloqueoUsuario(nomUsr, IdEmpresa);
        }

        /// <summary>
        /// Desbloquea usuario
        /// </summary>
        /// <param name="nomUsr">Cuenta usuario</param>
        public void DesbloqueaUsuario(string nomUsr)
        {
            new UsuariosDA_1().DesbloqueaUsuario(nomUsr);
        }

        public int CambiaContrasenia(UsuariosBE Usuario)
        {
            return new UsuariosDA_1().CambiaContrasenia(Usuario);
        }             

        /// <summary>
        /// Obtiene los usuarios dados de alto en el sistema
        /// </summary>
        /// <returns></returns>
        public List<UsuariosBE> ObtieneUsuarios(int IdEmpresa)
        {
            return new UsuariosDA_1().ObtieneUsuarios(IdEmpresa);
        }

        /// <summary>
        /// Guarda el nuevo usuario
        /// </summary>
        /// <param name="Usuario">Usuario que se va a crear</param>
        /// <param name="IdUsuarioCrea">Usuario que guarda el nuevo usuario</param>
        public ResultadoBE GuardaUsuario(UsuariosBE Usuario, int IdUsuarioCrea)
        {
            return new UsuariosDA_1().GuardaUsuario(Usuario, IdUsuarioCrea);
        }


        /// <summary>
        /// Actualiza el usuario
        /// </summary>
        /// <param name="Usuario">Usuario que se va a actualizar</param>
        /// <param name="IdUsuarioMod">Usuario que actualiza</param>
        public ResultadoBE ActualizaUsuario(UsuariosBE Usuario, int IdUsuarioMod)
        {
            return new UsuariosDA_1().ActualizaUsuario(Usuario, IdUsuarioMod);
        }

        /// <summary>
        /// Obtiene los datos del usuario
        /// </summary>
        /// <param name="Usuario">usuario a consultar</param>
        /// <returns></returns>
        public UsuariosBE ObtieneDatosUsuario(string Usuario, int IdEmpresa)
        {
            return new UsuariosDA_1().ObtieneDatosUsuario(Usuario, IdEmpresa);
        }

    }
}
