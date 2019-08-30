using Hersan.Entidades.Nomina;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hersan.Datos.Nomina
{
    public class ParametrosDA : BaseDA
    {
        #region Constantes
        const string CONS_NOM_PARAMETROS_OBTENER = "Nom_Parametros_Obtener";
        const string CONS_NOM_PARAMETROS_GUARDAR = "Nom_Parametros_Guardar";
        #endregion

        public ParametrosBE Nom_Parametros_Obtener()
        {
            ParametrosBE obj = new ParametrosBE();
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONS_NOM_PARAMETROS_OBTENER, conn)) {

                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                obj.Id = int.Parse(reader["PAR_Id"].ToString());
                                obj.Ahorro = decimal.Parse(reader["PAR_Ahorro"].ToString());
                                obj.Asistencia = decimal.Parse(reader["PAR_Asistencia"].ToString());
                                obj.Dias = int.Parse(reader["PAR_Dias"].ToString());
                                obj.Horas = int.Parse(reader["PAR_Horas"].ToString());
                                obj.Faltas = int.Parse(reader["PAR_Faltas"].ToString());
                                obj.Retardos = int.Parse(reader["PAR_Retardos"].ToString());
                                obj.Puntualidad = decimal.Parse(reader["PAR_Puntualidad"].ToString());
                                obj.UMA = decimal.Parse(reader["PAR_UMA"].ToString());
                                obj.Vales = decimal.Parse(reader["PAR_Vales"].ToString());
                                obj.Interes = decimal.Parse(reader["PAR_Interes"].ToString());
                                obj.Danios = decimal.Parse(reader["PAR_SeguroDanos"].ToString());
                                obj.Extras = int.Parse(reader["PAR_HorasExtra"].ToString());
                            }
                        }
                    }
                }
                return obj;
            } catch (Exception ex) {
                throw ex;
            }
        }
        public int Nom_Parametros_Guardar(ParametrosBE item)
        {
            int Result = 0;
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONS_NOM_PARAMETROS_GUARDAR, conn)) {
                        cmd.Parameters.AddWithValue("@Dias", item.Dias);
                        cmd.Parameters.AddWithValue("@Horas", item.Horas);
                        cmd.Parameters.AddWithValue("@Faltas", item.Faltas);
                        cmd.Parameters.AddWithValue("@Retardos", item.Retardos);
                        cmd.Parameters.AddWithValue("@Vales", item.Vales);
                        cmd.Parameters.AddWithValue("@UMA", item.UMA);
                        cmd.Parameters.AddWithValue("@Asistencia", item.Asistencia);
                        cmd.Parameters.AddWithValue("@Puntualidad", item.Puntualidad);
                        cmd.Parameters.AddWithValue("@Ahorro", item.Ahorro);
                        cmd.Parameters.AddWithValue("@Interes", item.Interes);
                        cmd.Parameters.AddWithValue("@Danios", item.Danios);
                        cmd.Parameters.AddWithValue("@Extras", item.Extras);
                        cmd.Parameters.AddWithValue("@IdUsuario", item.DatosUsuario.IdUsuarioCreo);

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
