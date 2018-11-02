using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hersan.Data.Connection;
using Hersan.Entidades.Seguridad;

namespace Hersan.Datos.Demo
{
    public class DemoDA : IDemoDA
    {
        //Persistencia datos = new Persistencia(CadenaConexion.SqlServeConexion);
        Persistencia datos = new Persistencia(BaseDA.RecuperarCadenaDeConexion());
       
        public async Task<List<UsuariosBE>> Usuarios_Obtiene()
        {
            var result = await datos.List<UsuariosBE>("SEG_Usuarios_Obtiene");
            return result.ToList();
        }
    }
}
