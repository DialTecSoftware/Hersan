using Hersan.Datos.Ensamble;
using Hersan.Entidades.Ensamble;
using System;
using System.Collections.Generic;


namespace Hersan.Negocio.Ensamble
{
    public class ServiciosBP
    {
        public int ENS_Servicios_Guardar(ServiciosBE obj)
        {
            return new ServiciosDA().ENS_Servicios_Guardar(obj);
        }
        public int ENS_Servicios_Actualizar(ServiciosBE obj)
        {
            return new ServiciosDA().ENS_Servicios_Actualizar(obj);
        }
        public List<ServiciosBE> ENS_Servicios_Obtener()
        {
            return new ServiciosDA().ENS_Servicios_Obtener();
        }
        public List<ServiciosBE> ENS_Servicios_Combo(int IdEntidad, string Moneda)
        {
            return new ServiciosDA().ENS_Servicios_Combo(IdEntidad, Moneda);
        }
        public List<ServiciosBE> ENS_ServiciosCotizacion_Combo(string Moneda)
        {
            return new ServiciosDA().ENS_ServiciosCotizacion_Combo(Moneda);
        }
    }
}
