﻿using Hersan.Entidades.Comun;
using Hersan.Entidades.Seguridad;
using Hersan.Negocio.Seguridad;
using Hersan.Seguridad.Contract;
using System.Collections.Generic;


namespace Hersan.Seguridad.Service
{
    public class Hersan_Seguridad : IHersan_Seguridad
    {
        #region Menus

        /// <summary>
        /// Obtiene el menu asignado al usuario
        /// </summary>
        /// <returns></returns>
        public List<MenusBE> ObtenerMenuUsuario(string Usuario)
        {
            return new MenusBP().ObtenerMenuUsuario(Usuario);
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
        public int GuardaMenuRol(System.Data.DataTable oTabla)
        {
            return new MenusBP().GuardaMenuRol(oTabla);
        }

        public List<MenusBE> ObtenerMenus()
        {
            return new MenusBP().ObtenerMenus();
        }

        public List<MenusBE> MenusPadre_Combo()
        {
            return new MenusBP().MenusPadre_Combo();
        }
        public int Menu_Guardar(MenusBE obj)
        {
            return new MenusBP().Menu_Guardar(obj);
        }
        #endregion

        #region Validacion Usuario
        /// <summary>
        /// Valida que las credenciales del usuario sean correctas
        /// </summary>
        /// <param name="nomUsr">Cuenta usuario</param>
        /// <param name="Pswd">Contraseña Encriptada</param>
        /// <returns></returns>
        public ValidaIngresoBE ValidaUsuario(string nomUsr, string Pswd)
        {
            return new UsuariosBP().ValidaUsuario(nomUsr, Pswd);
        }

        /// <summary>
        /// Verifica si hay bloqueo del usuario
        /// </summary>
        /// <param name="nomUsr">Cuenta usuario</param>
        /// <returns></returns>
        public ValidaIngresoBE ObtienBloqueoUsuario(string nomUsr)
        {
            return new UsuariosBP().ObtienBloqueoUsuario(nomUsr);
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
        public List<UsuariosBE> ObtieneUsuarios()
        {
            return new UsuariosBP().ObtieneUsuarios();
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
        public UsuariosBE ObtieneDatosUsuario(string Usuario)
        {
            return new UsuariosBP().ObtieneDatosUsuario(Usuario);
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
        public List<RolesBE> ObtieneRolesUsuario(int IdUsuario)
        {
            return new RolesUsuarioBP().ObtieneRolesUsuario(IdUsuario);
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
