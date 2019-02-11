using Hersan.Entidades.Catalogos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Hersan.Datos.Catalogos
{
    public class EstadosDA : BaseDA
    {

        #region Constantes
        const string CONST_ABC_ESTADOSXPAISES_OBTENER = "ABC_EstadosXPaises_Obtener";
        #endregion


        public List<EstadosBE> ABCEstados_Obtener(int IdPais)
        {
            List<EstadosBE> oList = new List<EstadosBE>();
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_ABC_ESTADOSXPAISES_OBTENER, conn)) {
                        cmd.Parameters.AddWithValue("@Pais", IdPais);

                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                EstadosBE obj = new EstadosBE();

                                obj.Id = int.Parse(reader["EST_Id"].ToString());
                                obj.Nombre = reader["EST_Nombre"].ToString();
                                obj.Abrev = reader["EST_Abrev"].ToString();
                                obj.Pais.Id = int.Parse(reader["PAI_Id"].ToString());
                                obj.Pais.Nombre = reader["PAI_Nombre"].ToString();

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
