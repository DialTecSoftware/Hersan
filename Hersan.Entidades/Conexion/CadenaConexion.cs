using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace Hersan.Entidades.Conexion
{
    public class CadenaConexion
    {
        public static string SqlServeConexion = ConfigurationManager.ConnectionStrings["Hersan"].ConnectionString;        
        public static string Password = "";
    }
}
