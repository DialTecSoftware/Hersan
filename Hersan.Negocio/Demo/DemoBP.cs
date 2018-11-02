using Hersan.Datos.Demo;
using Hersan.Entidades.Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hersan.Negocio.Demo
{
    public class DemoBP : IDemoBP
    {
        private readonly IDemoDA _Datos = null;

        public DemoBP(IDemoDA parametroServicio)
        {
            _Datos = parametroServicio;
        }


        public async Task<List<UsuariosBE>> Usuarios_Obtiene()
        {
            return await _Datos.Usuarios_Obtiene();
        }

    }
}
