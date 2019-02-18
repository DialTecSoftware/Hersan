using System;
using System.Data;
using System.Data.SqlClient;

namespace Hersan.Datos.CapitalHumano
{
    public class ExpedientesDA : BaseDA
    {

        #region Constantes
        const string CONS_USP_CHU_EXPEDIENTE_GUARDAR = "CHU_Expediente_Guardar";
        #endregion


        public int CHU_Expedientes_Guardar(DataSet Tablas, int IdUsuario)
        {
            int Result = 0;
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONS_USP_CHU_EXPEDIENTE_GUARDAR, conn)) {
                        cmd.Parameters.AddWithValue("@Expediente", Tablas.Tables["Expediente"]);
                        cmd.Parameters.AddWithValue("@Datos", Tablas.Tables["Personales"]);
                        cmd.Parameters.AddWithValue("@Doctos", Tablas.Tables["Documentos"]);
                        cmd.Parameters.AddWithValue("@Familia", Tablas.Tables["Familia"]);
                        cmd.Parameters.AddWithValue("@Estudios", Tablas.Tables["Estudios"]);
                        cmd.Parameters.AddWithValue("@Empleos", Tablas.Tables["Empleos"]);
                        cmd.Parameters.AddWithValue("@Salud", Tablas.Tables["Salud"]);
                        cmd.Parameters.AddWithValue("@Conocimiento", Tablas.Tables["Salud"]);
                        cmd.Parameters.AddWithValue("@Referencias", Tablas.Tables["Salud"]);
                        cmd.Parameters.AddWithValue("@Economicos", Tablas.Tables["Salud"]);
                        cmd.Parameters.AddWithValue("@IdUsuario", IdUsuario);

                        cmd.CommandType = CommandType.StoredProcedure;
                        Result = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
                return Result;
            } catch (Exception ex) {
                throw ex;
            }
        }
    }
}
