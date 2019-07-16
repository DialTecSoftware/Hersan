using Hersan.Datos.Catalogos;
using Hersan.Entidades.Catalogos;
using System.Collections.Generic;
using System.Data;

namespace Hersan.Negocio.Catalogos
{
    public class EmpresasBP
    {
        public List<EmpresasBE> ABCEmpresas_Obtener(int IdEmpresa)
        {
            return new EmpresasDA().ABCEmpresas_Obtener(IdEmpresa);
        }
        public List<EmpresasBE> ABCEmpresas_Cbo()
        {
            return new EmpresasDA().ABCEmpresas_Cbo();
        }
        public int ABC_Empresas_Guarda(DataTable Empresa, int IdUsuario)
        {
            return new EmpresasDA().ABC_Empresas_Guarda(Empresa, IdUsuario);
        }
        public int ABC_Empresas_Actualizar(DataTable Empresa, int IdUsuario)
        {
            return new EmpresasDA().ABC_Empresas_Actualizar(Empresa, IdUsuario);
        }
    }
}
