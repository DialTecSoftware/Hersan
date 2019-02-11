using Hersan.Entidades.Catalogos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Hersan.Datos.Catalogos
{
    public class ColoniasDA : BaseDA
    {

        #region Constantes
        const string CONST_ABC_COLONIASXCIUDAD_OBTENER = "ABC_ColoniasXCiudad_Obtener";
        #endregion

        public List<ColoniasBE> ABCColonias_Obtener(int IdEstado, int IdCiudad)
        {
            List<ColoniasBE> oList = new List<ColoniasBE>();
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_ABC_COLONIASXCIUDAD_OBTENER, conn)) {
                        cmd.Parameters.AddWithValue("@EST_ID", IdEstado);
                        cmd.Parameters.AddWithValue("@CIU_ID", IdCiudad);

                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                ColoniasBE obj = new ColoniasBE();

                                obj.Id = int.Parse(reader["COL_ID"].ToString());
                                obj.Nombre = reader["COL_Nombre"].ToString();
                                obj.CP = int.Parse(reader["COL_CP"].ToString());

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
