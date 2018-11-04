using Hersan.Entidades.Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hersan.Negocio.Demo
{
    public interface IDemoBP
    {
        Task<List<UsuariosBE>> Usuarios_Obtiene();
    }
}
