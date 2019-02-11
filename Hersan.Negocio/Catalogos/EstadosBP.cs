using Hersan.Datos.Catalogos;
using Hersan.Entidades.Catalogos;
using System.Collections.Generic;

namespace Hersan.Negocio.Catalogos
{
    public class EstadosBP
    {
        public List<EstadosBE> ABCEstados_Obtener(int IdPais)
        {
            return new EstadosDA().ABCEstados_Obtener(IdPais);
        }
    }
}
