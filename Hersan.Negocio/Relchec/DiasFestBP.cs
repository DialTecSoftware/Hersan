using Hersan.Datos.Relchec;
using Hersan.Entidades.Relchec;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hersan.Negocio.Relchec
{
    public class DiasFestBP
    {
        public List<DiasFestBE> ABCDiasFest_Obtener()
        {
            return new DiasFestDa().ABCDiasFest_Obtener();
        }
        public int ABCDiasFest_Guarda(DiasFestBE obj)
        {
            return new DiasFestDa().ABCDiasFest_Guarda(obj);
        }
        public int ABCDiasFest_Actualizar(DiasFestBE obj)
        {
            return new DiasFestDa().ABCDiasFest_Actualizar(obj);
        }
    }
}
