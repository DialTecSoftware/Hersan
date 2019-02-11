using Hersan.Entidades.Catalogos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Hersan.Datos.Catalogos
{
    public class CiudadesDA : BaseDA
    {
        #region Constantes
        const string CONST_ABC_CIUDADESXESTADO_OBTENER = "ABC_CiudadesXEstado_Obtener";
        #endregion


        public List<CiudadesBE> ABCCiudades_Obtener(int IdEstado)
        {
            List<CiudadesBE> oList = new List<CiudadesBE>();
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_ABC_CIUDADESXESTADO_OBTENER, conn)) {
                        cmd.Parameters.AddWithValue("@EDO_ID", IdEstado);

                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                CiudadesBE obj = new CiudadesBE();

                                obj.Id = int.Parse(reader["CIU_Id"].ToString());
                                obj.Nombre = reader["CIU_Nombre"].ToString();
                                obj.Cabecera = reader["CIU_CAbecera"].ToString();

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
