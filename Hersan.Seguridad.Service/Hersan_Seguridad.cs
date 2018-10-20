using Hersan.Entidades.Comun;
using Hersan.Entidades.Seguridad;
using Hersan.Negocio.Seguridad;
using Hersan.Seguridad.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hersan.Seguridad.Service
{
    public class Hersan_Seguridad : IHersan_Seguridad
    {
        #region Menus

        /// <summary>
        /// Obtiene el menu asignado al usuario
        /// </summary>
        /// <returns></returns>
        public List<MenusBE> ObtenerMenuUsuario(string Usuario, int Empresa)
        {
            return new MenusBP().ObtenerMenuUsuario(Usuario, Empresa);
        }

        /// <summary>
        /// Obtiene el menu por rol
        /// </summary>
        /// <returns></returns>

        public List<MenusBE> ObtenerMenuRol(int Rol, int Padre, int Menu)
        {
            return new MenusBP().ObtenerMenuRol(Rol, Padre, Menu);
        }

        /// <summary>
        /// Guarda la asinagción de permisos en el menu al rol seleccionado
        /// </summary>
        /// <param name="lstMnu">listado de menus</param>
        /// <param name="Rol">Rol a asignar</param>
        /// <param name="Aplicacion">Aplicacion del menu</param>
        public void GuardaMenuRol(List<MenusBE> lstMnu, int Rol, int Menu)
        {
            new MenusBP().GuardaMenuRol(lstMnu, Rol, Menu);
        }

        #endregion

        #region Validacion Usuario
        /// <summary>
        /// Valida que las credenciales del usuario sean correctas
        /// </summary>
        /// <param name="nomUsr">Cuenta usuario</param>
        /// <param name="Pswd">Contraseña Encriptada</param>
        /// <returns></returns>
        public ValidaIngresoBE ValidaUsuario(string nomUsr, string Pswd, int IdEmpresa)
        {
            return new UsuariosBP().ValidaUsuario(nomUsr, Pswd, IdEmpresa);
        }

        /// <summary>
        /// Verifica si hay bloqueo del usuario
        /// </summary>
        /// <param name="nomUsr">Cuenta usuario</param>
        /// <returns></returns>
        public ValidaIngresoBE ObtienBloqueoUsuario(string nomUsr, int IdEmpresa)
        {
            return new UsuariosBP().ObtienBloqueoUsuario(nomUsr, IdEmpresa);
        }

        /// <summary>
        /// Desbloquea usuario
        /// </summary>
        /// <param name="nomUsr">Cuenta usuario</param>
        public void DesbloqueaUsuario(string nomUsr)
        {
            new UsuariosBP().DesbloqueaUsuario(nomUsr);
        }
        #endregion

        #region Usuarios

        /// <summary>
        /// Obtiene los usuarios dados de alto en el sistema
        /// </summary>
        /// <returns></returns>
        public List<UsuariosBE> ObtieneUsuarios(int IdEmpresa)
        {
            return new UsuariosBP().ObtieneUsuarios(IdEmpresa);
        }

        /// <summary>
        /// Guarda el nuevo usuario
        /// </summary>
        /// <param name="Usuario">Usuario que se va a crear</param>
        /// <param name="IdUsuarioCrea">Usuario que guarda el nuevo usuario</param>
        public ResultadoBE GuardaUsuario(UsuariosBE Usuario, int IdUsuarioCrea)
        {
            return new UsuariosBP().GuardaUsuario(Usuario, IdUsuarioCrea);
        }

        /// <summary>
        /// Actualiza el usuario
        /// </summary>
        /// <param name="Usuario">Usuario que se va a actualizar</param>
        /// <param name="IdUsuarioMod">Usuario que actualiza</param>
        public ResultadoBE ActualizaUsuario(UsuariosBE Usuario, int IdUsuarioMod)
        {
            return new UsuariosBP().ActualizaUsuario(Usuario, IdUsuarioMod);
        }

        /// <summary>
        /// Obtiene los datos del usuario
        /// </summary>
        /// <param name="Usuario">usuario a consultar</param>
        /// <returns></returns>
        public UsuariosBE ObtieneDatosUsuario(string Usuario, int IdEmpresa)
        {
            return new UsuariosBP().ObtieneDatosUsuario(Usuario, IdEmpresa);
        }

        public int CambiaContrasenia(UsuariosBE Usuario)
        {
            return new UsuariosBP().CambiaContrasenia(Usuario);
        }
        #endregion

        #region Perfiles

        /// <summary>
        /// Obtener Listado de Roles
        /// </summary>
        /// <returns></returns>
        public List<RolesBE> ObtieneRoles(int IdEmpresa)
        {
            return new RolesBP().ObtieneRoles(IdEmpresa);
        }


        /// <summary>
        /// Guarda el nuevo Rol
        /// </summary>
        /// <param name="Rol">Nombre del rol a insertar</param>
        /// <param name="IdUsuario">Id del usuario que guarda el nuevo rol</param>
        /// <param name="Estatus">Estatus del nuevo rol</param>
        /// <returns></returns>
        public ResultadoBE GuardaRoles(string Rol, int IdEmpresa, int IdUsuario, bool Estatus)
        {
            return new RolesBP().GuardaRoles(Rol, IdEmpresa, IdUsuario, Estatus);
        }

        /// <summary>
        /// Actualiza el Rol
        /// </summary>
        /// <param name="IdRol">Id del rol a actualizar</param>
        /// <param name="Rol">Nombre del rol a actualizar</param>
        /// <param name="IdUsuario">Usuario que actualiza</param>
        /// <param name="Estatus">Estatus del rol</param>
        /// <returns></returns>
        public ResultadoBE ActualizaRoles(int IdRol, string Rol, int IdEmpresa, int IdUsuario, bool Estatus)
        {
            return new RolesBP().ActualizaRoles(IdRol, Rol, IdEmpresa, IdUsuario, Estatus);
        }

        #endregion

        #region Perfiles - Usuario

        /// <summary>
        /// Obtener Listado de Roles usuario
        /// </summary>
        /// <returns></returns>
        public List<RolesBE> ObtieneRolesUsuario(int IdUsuario, int IdEmpresa)
        {
            return new RolesUsuarioBP().ObtieneRolesUsuario(IdUsuario, IdEmpresa);
        }

        /// <summary>
        /// Guarda el rol que se le asigno al usuario
        /// </summary>
        /// <param name="IdRol"></param>
        /// <param name="IdUsuario"></param>
        public void GuardaRolesUsuario(int IdRol, int IdUsuario)
        {
            new RolesUsuarioBP().GuardaRolesUsuario(IdRol, IdUsuario);
        }

        #endregion
    }
}
