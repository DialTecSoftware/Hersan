using Hersan.Entidades.Catalogos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hersan.Datos.Catalogos
{
  public  class PuestosDA:BaseDA
    {

        #region Constantes
        const string CONST_USP_ABC_PUESTOS_OBTENER = "USP_ABC_Puestos_Obtener";
        #endregion

        public List<PuestosBE> ABCPuestos_Obtener()
        {
            List<PuestosBE> oList = new List<PuestosBE>();
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_USP_ABC_PUESTOS_OBTENER, conn)) {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                PuestosBE obj = new PuestosBE();

                                obj.Id_puesto = int.Parse(reader["PUE_Id"].ToString());
                                obj.departamentos.Id= int.Parse(reader["DEP_Id"].ToString());
                                obj.Nombre = reader["PUE_Nombre"].ToString();
                                obj.Abrev = reader["PUE_Abrev"].ToString();

                                oList.Add(obj);
                            }
                        }
                    }
                }
                return oList;
            } catch (Exception ex) {
                throw ex;
            }
        }
    }
}

