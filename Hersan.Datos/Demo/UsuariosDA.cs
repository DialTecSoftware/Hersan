using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hersan.Data.Connection;
using Hersan.Entidades.Conexion;
using Hersan.Entidades.Seguridad;

namespace Hersan.Datos.Demo
{
    public class UsuariosDA : IUsuariosDA
    {
        Persistencia datos = new Persistencia(CadenaConexion.SqlServeConexion);

        public async Task<List<UsuariosBE>> Usuarios_Obtiene()
        {
            var result = await datos.List<UsuariosBE>("SEG_Usuarios_Obtiene");
            return result.ToList();
        }
    }
}
