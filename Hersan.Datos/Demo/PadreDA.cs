using Hersan.Data.Connection;
using Hersan.Entidades.Conexion;
using Hersan.Entidades.Pruebas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hersan.Datos.Demo
{
    public class PadreDA : IPadreDA
    {
        Persistencia datos = new Persistencia(CadenaConexion.SqlServeConexion);

        public async Task<List<Hijo>> Usuarios_Obtiene()
        {
            var result = await datos.List<Hijo, Padre, Hijo>(
                @"Usuarios_Obtiene",
                (Hijo, Padre) => {
                    Hijo.Papa = Padre;
                    return Hijo;
                },
                 splitOn: @"Padre_id");
            return result.ToList();
        }

    }
}
