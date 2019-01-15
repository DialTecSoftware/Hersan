using Hersan.Entidades.CapitalHumano;
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
    public class CompetenciasDA : BaseDA
    {
        #region Constantes
        const string CONST_USP_ABC_COMPETENCIAS_OBTENER = "USP_ABC_Competencias_Obtener";
        #endregion

        public List<CompetenciasBE> ABCCompetencias_Obtener()
        {
            List<CompetenciasBE> oList = new List<CompetenciasBE>();
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_USP_ABC_COMPETENCIAS_OBTENER, conn)) {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                CompetenciasBE obj = new CompetenciasBE();

                                obj.Id = int.Parse(reader["COM_ID"].ToString());
                                obj.Nombre = reader["COM_Nombre"].ToString();
                                //obj.Abrev = reader["COM_Abrev"].ToString();
                                
                                obj.Experiencia = int.Parse(reader["COM_AniosExp"].ToString());

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

