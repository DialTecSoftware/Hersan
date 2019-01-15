
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
  public class TiposContratoDA : BaseDA
    {
        #region Constantes
        const string CONST_USP_ABC_TIPOSCONTRATO_OBTENER = "USP_ABC_TiposContrato_Obtener";
        #endregion

        public List<TiposContratoBE> TiposContrato_Obtener()
        {
            List<TiposContratoBE> oList = new List<TiposContratoBE>();
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_USP_ABC_TIPOSCONTRATO_OBTENER, conn)) {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                TiposContratoBE obj = new TiposContratoBE();

                                obj.Id = int.Parse(reader["TCO_ID"].ToString());
                                obj.Nombre = reader["TCO_Nombre"].ToString();
                                obj.Abrev = reader["TCO_Abrev"].ToString();

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

