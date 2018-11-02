using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace Hersan.Entidades.Conexion
{
    public class CadenaConexion
    {
        public static string SqlServeConexion = ConfigurationManager.ConnectionStrings["coneccionSQL"].ConnectionString;        
        public static string Password = "";
    }
}
