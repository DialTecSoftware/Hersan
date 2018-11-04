using Hersan.Datos.Demo;
using Hersan.Entidades.Pruebas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hersan.Negocio.Demo
{
    public class PadreBP : IPadreBP
    {
        private readonly IPadreDA _Datos = null;

        public PadreBP(IPadreDA parametroServicio)
        {
            _Datos = parametroServicio;
        }


        public async Task<List<Hijo>> Usuarios_Obtiene()
        {
            return await _Datos.Usuarios_Obtiene();
        }

    }
}
