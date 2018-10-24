using Hersan.Datos.Demo;
using Hersan.Entidades.Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hersan.Negocio.Demo
{
    public class UsuariosBP : IUsuariosBP
    {
        private readonly IUsuariosDA _Datos = null;

        public UsuariosBP(IUsuariosDA parametroServicio)
        {
            _Datos = parametroServicio;
        }


        public async Task<List<UsuariosBE>> Usuarios_Obtiene()
        {
            return await _Datos.Usuarios_Obtiene();
        }

    }
}
