using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hersan.Data.Connection;
using Hersan.Entidades.Conexion;
using Hersan.Entidades.Pruebas;
using Hersan.Entidades.Seguridad;

namespace Hersan.Datos.Demo
{
    public class UsuariosDA : IUsuariosDA
    {
        Persistencia datos = new Persistencia(CadenaConexion.SqlServeConexion);

        public async Task<List<UsuarioNombre>> Usuarios_Obtiene()
        {
            var parametros = new { tab_linea_neg = "", valor2 = "" };
            var result = await datos.List<UsuarioNombre,Usuario,UsuarioNombre>(
                @"Usuarios_Obtiene",
                (UsuarioNombre, Usuario) => 
                {
                    UsuarioNombre.Usuario = Usuario;
                    //Usuario.Asisleg_id = async;
                    return UsuarioNombre;
                }, 
                parametros,
                splitOn: @"Asisleg_id");

            return result.ToList();
        }

        public int InsertarParametros(/*int  valor, string x*/UsuarioNombre UsuarioNombre)
        {
            /// para cuando las entidades tengas padre e hija
            int result = datos.Execute("pruebaInsertar", Persistencia.Parametros(UsuarioNombre));
            /// para cuando tenfas pocos valores o no tenga entidades
            // var parametros = new { tab_linea_neg = valor , valor2= x};
            // int result = datos.Execute("pruebaInsertar", parametros);
            return result;
        }
    }
}
