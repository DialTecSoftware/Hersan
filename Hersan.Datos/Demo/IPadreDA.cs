using Hersan.Entidades.Pruebas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hersan.Datos.Demo
{
    public interface IPadreDA
    {
        Task<List<Hijo>> Usuarios_Obtiene();
    }
}
