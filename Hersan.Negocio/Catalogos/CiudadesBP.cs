using Hersan.Datos.Catalogos;
using Hersan.Entidades.Catalogos;
using System.Collections.Generic;

namespace Hersan.Negocio.Catalogos
{
    public class CiudadesBP
    {

        public List<CiudadesBE> ABCCiudades_Obtener(int IdEstado)
        {
            return new CiudadesDA().ABCCiudades_Obtener(IdEstado);
        }
    }
}
