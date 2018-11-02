using Hersan.Entidades.Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hersan.Datos.Interfaces.Seguridad
{
    public interface IValidaIngresoDA
    {
        
        Task<List<ValidaIngresoBE>> ValidaUsuario(UsuariosBE Usuario);

    }
}
