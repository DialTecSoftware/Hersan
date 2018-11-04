using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hersan.Data.Connection;
using Hersan.Entidades.Conexion;
using Hersan.Entidades.Pruebas;

namespace Hersan.Datos.Demo
{
    public class UsuariosDA : IUsuariosDA
    {
        Persistencia datos = new Persistencia(CadenaConexion.SqlServeConexion);

        public async Task<List<UsuarioNombre>> Usuarios_Obtiene()
            {
            var result = await datos.List<UsuarioNombre,Usuario,UsuarioNombre>(
                @"Usuarios_Obtiene",
                (UsuarioNombre, Usuario) => 
                {
                    UsuarioNombre.Usuario = Usuario;
                    return UsuarioNombre;
                },
                 splitOn: @"Asisleg_id");
            return result.ToList();
        }
    }
}
