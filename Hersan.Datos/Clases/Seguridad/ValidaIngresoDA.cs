using Hersan.Data.Connection;
using Hersan.Datos.Interfaces.Seguridad;
using Hersan.Entidades.Conexion;
using Hersan.Entidades.Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hersan.Datos.Seguridad
{
    public class ValidaIngresoDA : IValidaIngresoDA
    {
        Persistencia datos = new Persistencia(CadenaConexion.SqlServeConexion);

        public async Task<List<ValidaIngresoBE>> ValidaUsuario(UsuariosBE Usuario)
        {
            var parametros = new { tab_linea_neg = "", valor2 = "" };
            var result = await datos.List<ValidaIngresoBE>(
                @"Usuarios_Obtiene",
                (UsuarioNombre, Usuario) => {
                    UsuarioNombre.Usuario = Usuario;
                    //Usuario.Asisleg_id = async;
                    return UsuarioNombre;
                },
                parametros,
                splitOn: @"Asisleg_id");

            return result.ToList();
        }
    }
}
