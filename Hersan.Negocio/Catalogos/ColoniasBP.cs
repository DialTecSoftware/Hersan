using Hersan.Datos.Catalogos;
using Hersan.Entidades.Catalogos;
using System.Collections.Generic;

namespace Hersan.Negocio.Catalogos
{
    public class ColoniasBP
    {

        public List<ColoniasBE> ABCColonias_Obtener(int IdEstado, int IdCiudad)
        {
            return new ColoniasDA().ABCColonias_Obtener(IdEstado, IdCiudad);
        }
    }
}
