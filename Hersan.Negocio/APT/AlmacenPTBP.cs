using Hersan.Datos.APT;
using Hersan.Entidades.APT;
using System;
using System.Collections.Generic;

namespace Hersan.Negocio.APT
{
    public class AlmacenBP
    {
        public List<AlmacenPTBE> APT_Almacenes_Obtener(int IdEmpresa)
        {
            return new AlmacenDA().APT_Almacenes_Obtener(IdEmpresa);
        }
        public int APT_Almacenes_Guardar(AlmacenPTBE obj)
        {
            return new AlmacenDA().APT_Almacenes_Guardar(obj);
        }
        public int APT_Almacenes_Actualizar(AlmacenPTBE obj)
        {
            return new AlmacenDA().APT_Almacenes_Actualizar(obj);
        }
        public List<AlmacenPTBE> APT_Almacenes_Combo(int IdEmpresa)
        {
            return new AlmacenDA().APT_Almacenes_Combo(IdEmpresa);
        }
    }
}
