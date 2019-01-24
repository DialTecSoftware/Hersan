using Hersan.Entidades.Seguridad;
using Hersan.Datos.Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hersan.Negocio.Seguridad
{
    public class RolesUsuarioBP
    {
        /// <summary>
        /// Obtener Listado de Roles usuario
        /// </summary>
        /// <returns></returns>
        public List<RolesBE> ObtieneRolesUsuario(int IdUsuario)
        {
            return new RolesUsuarioDA().ObtieneRolesUsuario(IdUsuario);
        }

        /// <summary>
        /// Guarda el rol que se le asigno al usuario
        /// </summary>
        /// <param name="IdRol"></param>
        /// <param name="IdUsuario"></param>
        public void GuardaRolesUsuario(int IdRol, int IdUsuario)
        {
             new RolesUsuarioDA().GuardaRolesUsuario(IdRol, IdUsuario);
        }
    }
}
