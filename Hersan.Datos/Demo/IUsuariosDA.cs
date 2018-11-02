using Hersan.Entidades.Pruebas;
using Hersan.Entidades.Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hersan.Datos.Demo
{
    public interface IUsuariosDA
    {
        Task<List<UsuarioNombre>> Usuarios_Obtiene();
        int InsertarParametros(UsuarioNombre UsuarioNombre);
    }
}
