using Hersan.Entidades.Comun;
using Hersan.Entidades.Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Hersan.Seguridad.Contract
{
    [ServiceContract]
    public interface IHersan_Seguridad
    {
        #region Menus
        /// <summary>
        /// Obtiene el listado de Estados
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        List<MenusBE> ObtenerMenuUsuario(string Usuario, int Empresa);

        /// <summary>
        /// Obtiene el menu por rol
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        List<MenusBE> ObtenerMenuRol(int Rol, int Padre, int Menu);

        /// <summary>
        /// Guarda la asinagción de permisos en el menu al rol seleccionado
        /// </summary>
        /// <param name="lstMnu">listado de menus</param>
        /// <param name="Rol">Rol a asignar</param>
        /// <param name="Aplicacion">Aplicacion del menu</param>
        [OperationContract]
        void GuardaMenuRol(List<MenusBE> lstMnu, int Rol, int Menu);

        #endregion

        #region Validacion Usuario
        /// <summary>
        /// Valida que las credenciales del usuario sean correctas
        /// </summary>
        /// <param name="nomUsr">Cuenta usuario</param>
        /// <param name="Pswd">Contraseña Encriptada</param>
        /// <returns></returns>
        [OperationContract]
        ValidaIngresoBE ValidaUsuario(string nomUsr, string Pswd, int IdEmpresa);

        /// <summary>
        /// Verifica si hay bloqueo del usuario
        /// </summary>
        /// <param name="nomUsr">Cuenta usuario</param>
        /// <returns></returns>
        [OperationContract]
        ValidaIngresoBE ObtienBloqueoUsuario(string nomUsr, int IdEmpresa);

        /// <summary>
        /// Desbloquea usuario
        /// </summary>
        /// <param name="nomUsr">Cuenta usuario</param>
        [OperationContract]
        void DesbloqueaUsuario(string nomUsr);
        #endregion

        #region Usuarios

        /// <summary>
        /// Obtiene los usuarios dados de alto en el sistema
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        List<UsuariosBE> ObtieneUsuarios(int IdEmpresa);

        /// <summary>
        /// Guarda el nuevo usuario
        /// </summary>
        /// <param name="Usuario">Usuario que se va a crear</param>
        /// <param name="IdUsuarioCrea">Usuario que guarda el nuevo usuario</param>
        [OperationContract]
        ResultadoBE GuardaUsuario(UsuariosBE Usuario, int IdUsuarioCrea);

        /// <summary>
        /// Actualiza el usuario
        /// </summary>
        /// <param name="Usuario">Usuario que se va a actualizar</param>
        /// <param name="IdUsuarioMod">Usuario que actualiza</param>
        [OperationContract]
        ResultadoBE ActualizaUsuario(UsuariosBE Usuario, int IdUsuarioMod);

        /// <summary>
        /// Obtiene los datos del usuario
        /// </summary>
        /// <param name="Usuario">usuario a consultar</param>
        /// <returns></returns>
        [OperationContract]
        UsuariosBE ObtieneDatosUsuario(string Usuario, int IdEmpresa);

        [OperationContract]
        int CambiaContrasenia(UsuariosBE Usuario);
        #endregion

        #region Perfiles

        /// <summary>
        /// Obtener Listado de Roles
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        List<RolesBE> ObtieneRoles(int IdEmpresa);

        /// <summary>
        /// Guarda el nuevo Rol
        /// </summary>
        /// <param name="Rol">Nombre del rol a insertar</param>
        /// <param name="IdUsuario">Id del usuario que guarda el nuevo rol</param>
        /// <param name="Estatus">Estatus del nuevo rol</param>
        /// <returns></returns>
        [OperationContract]
        ResultadoBE GuardaRoles(string Rol, int IdEmpresa, int IdUsuario, bool Estatus);

        /// <summary>
        /// Actualiza el Rol
        /// </summary>
        /// <param name="IdRol">Id del rol a actualizar</param>
        /// <param name="Rol">Nombre del rol a actualizar</param>
        /// <param name="IdUsuario">Usuario que actualiza</param>
        /// <param name="Estatus">Estatus del rol</param>
        /// <returns></returns>
        [OperationContract]
        ResultadoBE ActualizaRoles(int IdRol, string Rol, int IdEmpresa, int IdUsuario, bool Estatus);

        #endregion

        #region Perfiles - Usuario
        /// <summary>
        /// Obtener Listado de Roles usuario
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        List<RolesBE> ObtieneRolesUsuario(int IdUsuario, int IdEmpresa);

        /// <summary>
        /// Guarda el rol que se le asigno al usuario
        /// </summary>
        /// <param name="IdRol"></param>
        /// <param name="IdUsuario"></param>
        [OperationContract]
        void GuardaRolesUsuario(int IdRol, int IdUsuario);

        #endregion
    }
}
