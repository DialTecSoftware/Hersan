using Hersan.Datos.Catalogos;
using Hersan.Entidades.Catalogos;
using System.Collections.Generic;

namespace Hersan.Negocio.Catalogos {
    public class ProveedorBP 
    {
        public int ABC_Proveedores_Guardar(ProveedorBE obj)
        {
            return new ProveedorDA().ABC_Proveedores_Guardar(obj);
        }
        public int ABC_Proveedores_Actualizar(ProveedorBE obj)
        {
            return new ProveedorDA().ABC_Proveedores_Actualizar(obj);
        }
        public List<ProveedorBE> ABC_Proveedores_Obtener(int IdEmpresa)
        {
            return new ProveedorDA().ABC_Proveedores_Obtener(IdEmpresa);
        }
    }
}
