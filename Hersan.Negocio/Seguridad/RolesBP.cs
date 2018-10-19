using Hersan.Datos.Seguridad;
using Hersan.Entidades.Comun;
using Hersan.Entidades.Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hersan.Negocio.Seguridad
{
    public class RolesBP
    {

        /// <summary>
        /// Obtener Listado de Roles
        /// </summary>
        /// <returns></returns>
        public List<RolesBE> ObtieneRoles()
        {
            return new RolesDA().ObtieneRoles();
        }

        /// <summary>
        /// Guarda el nuevo Rol
        /// </summary>
        /// <param name="Rol">Nombre del rol a insertar</param>
        /// <param name="IdUsuario">Id del usuario que guarda el nuevo rol</param>
        /// <param name="Estatus">Estatus del nuevo rol</param>
        /// <returns></returns>
        public ResultadoBE GuardaRoles(string Rol, int IdEmpresa,  int IdUsuario, bool Estatus)
        {
            return new RolesDA().GuardaRoles(Rol, IdEmpresa, IdUsuario, Estatus);
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
            return new RolesDA().ActualizaRoles(IdRol, Rol, IdEmpresa, IdUsuario, Estatus);
        }
    }
}
