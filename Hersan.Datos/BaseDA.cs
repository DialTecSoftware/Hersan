using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hersan.Datos
{
    public class BaseDA
    {
        public static string RecuperarCadenaDeConexion()
        {
            return ConfigurationManager.ConnectionStrings["coneccionSQL"].ConnectionString;
        }
        public static string RecuperarCadenaDeConexion(string conexion)
        {
            return ConfigurationManager.ConnectionStrings[conexion].ConnectionString;
        }

        public static string CadenaDeConexion()
        {
            return ConfigurationManager.ConnectionStrings["coneccionSQL"].ToString();
        }
        public static string CadenaDeConexion(string conexion)
        {
            return ConfigurationManager.ConnectionStrings[conexion].ToString();
        }
    }
}
