using Hersan.Entidades.Catalogos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Hersan.Datos.Catalogos
{
    public class DepartamentosDA : BaseDA
    {
        #region Constantes
        const string CONST_USP_ABC_DEPARTAMENTOS_OBTENER = "USP_ABC_Departamentos_Obtener";
        #endregion

        public List<DepartamentosBE> ABCDepartamentos_Obtener()
        {
            List<DepartamentosBE> oList = new List<DepartamentosBE>();
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_USP_ABC_DEPARTAMENTOS_OBTENER, conn)) {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                DepartamentosBE obj = new DepartamentosBE();

                                obj.Id = int.Parse(reader["DEP_ID"].ToString());
                                obj.Nombre = reader["DEP_Nombre"].ToString();
                                obj.Abrev = reader["DEP_Abrev"].ToString();

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
