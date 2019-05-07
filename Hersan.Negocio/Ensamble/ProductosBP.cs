using Hersan.Datos.Ensamble;
using Hersan.Entidades.Catalogos;
using Hersan.Entidades.Ensamble;
using System.Collections.Generic;
using System.Data;

namespace Hersan.Negocio.Ensamble
{
    public class ProductosBP
    {
        public int ENS_ProductosFicha_Guardar(System.Data.DataSet Tablas, string Colores, string Reflejantes, string Accesorios, int IdUsuario)
        {
            return new ProductosDA().ENS_ProductosFicha_Guardar(Tablas, Colores, Reflejantes, Accesorios, IdUsuario);
        }
        public int ENS_ProductosFicha_Actualizar(DataSet Tablas, string Colores, string Reflejantes, string Accesorios, int IdUsuario, bool Estatus)
        {
            return new ProductosDA().ENS_ProductosFicha_Actualizar(Tablas, Colores, Reflejantes, Accesorios, IdUsuario, Estatus);
        }
        public List<ProductoEnsambleBE> ENS_ProductosFicha_Obtener(ProductoEnsambleBE obj)
        {
            return new ProductosDA().ENS_ProductosFicha_Obtener(obj);
        }
        public List<ProductoEnsambleBE> ENS_ProductosCotizacion_Combo()
        {
            return new ProductosDA().ENS_ProductosCotizacion_Combo();
        }
        public List<ColoresBE> ENS_CarcasasCotizacion_Combo(int IdFicha)
        {
            return new ProductosDA().ENS_CarcasasCotizacion_Combo(IdFicha);
        }
        public List<ReflejantesBE> ENS_ReflejanteCotizacion_Combo(int IdFicha)
        {
            return new ProductosDA().ENS_ReflejanteCotizacion_Combo(IdFicha);
        }
    }
}
