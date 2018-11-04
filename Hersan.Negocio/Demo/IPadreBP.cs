using Hersan.Entidades.Pruebas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hersan.Negocio.Demo
{
   public interface IPadreBP
    {
        Task<List<Hijo>> Usuarios_Obtiene();
    }
}
