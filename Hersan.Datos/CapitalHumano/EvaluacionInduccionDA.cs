using Hersan.Entidades.CapitalHumano;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hersan.Datos.CapitalHumano
{
  public  class EvaluacionInduccionDA:BaseDA
    {
        #region Constantes
      
        const string CONST_PreguntasEV_OBTENER = "CHU_PreguntasEvaluacion_Obtener";
        const string CONST_DatosEMP_OBTENER = "CHU_DatosEMP_Obtener";
        const string CONST_CHU_EVI_OBTENER = "CHU_EvaluacionInduccion_Obtener";
        const string CONST_CHU_EVI_GUARDAR = "CHU_EvaluacionInduccion_Guardar";
        const string CONST_CHU_EVI_ACTUALIZAR = "CHU_EvaluacionInduccion_Actualiza";
        #endregion


        public List<PreguntasEvaluacionBE> CHU_ObtenerPreguntas()
        {
            List<PreguntasEvaluacionBE> oList = new List<PreguntasEvaluacionBE>();
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_PreguntasEV_OBTENER, conn)) {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                PreguntasEvaluacionBE obj = new PreguntasEvaluacionBE();
                                obj.Id = int.Parse(reader["PEV_Id"].ToString());
                                obj.Pregunta= (reader["PEV_Preguntas"].ToString());
                                obj.Valor4 = bool.Parse(reader["PEV_Valor4"].ToString());
                                obj.Valor3 = bool.Parse(reader["PEV_Valor3"].ToString());
                                obj.Valor2 = bool.Parse(reader["PEV_Valor2"].ToString());
                                obj.Valor1 = bool.Parse(reader["PEV_Valor1"].ToString());
                                oList.Add(obj);
                            }
                        }
                    }
                }
                return oList;
            } catch (Exception) {

                throw;
            }

           
        }

        public List<EvaluacionInduccionBE> CHU_DatosEMP_Obtener(EvaluacionInduccionBE evaluacion)
        {
            List<EvaluacionInduccionBE> oList = new List<EvaluacionInduccionBE>();
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_DatosEMP_OBTENER, conn)) {

                     
                        cmd.Parameters.AddWithValue("@EMP_Num", evaluacion.IdEmpleado);
                        cmd.Parameters.AddWithValue("@ENT_Id", evaluacion.Puestos.Departamentos.Entidades.Id);
                        cmd.Parameters.AddWithValue("@DEP_Id", evaluacion.Puestos.Departamentos.Id);
                        cmd.Parameters.AddWithValue("@PUE_Id", evaluacion.Puestos.Id);
                        cmd.Parameters.AddWithValue("@APaterno", evaluacion.DatosPersonales.APaterno);
                        cmd.Parameters.AddWithValue("@AMaterno", evaluacion.DatosPersonales.AMaterno);
                        cmd.Parameters.AddWithValue("@Nombres", evaluacion.DatosPersonales.Nombres);
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                EvaluacionInduccionBE obj = new EvaluacionInduccionBE();

                                obj.DatosPersonales.IdExpediente = int.Parse(reader["EXP_Id"].ToString());
                                obj.IdEmpleado = int.Parse(reader["EMP_Numero"].ToString());
                                obj.Puestos.Departamentos.Entidades.Nombre = reader["ENT_Nombre"].ToString();
                                //obj.Puestos.Departamentos.Id = int.Parse(reader["DEP_Id"].ToString());
                                obj.Puestos.Departamentos.Nombre = reader["DEP_Nombre"].ToString();
                                //obj.Puestos.Id = int.Parse(reader["PUE_Id"].ToString());
                                obj.Puestos.Nombre = reader["PUE_Nombre"].ToString();
                                obj.DatosPersonales.APaterno = reader["EDP_APaterno"].ToString();
                                obj.DatosPersonales.AMaterno = reader["EDP_AMaterno"].ToString();
                                obj.DatosPersonales.Nombres = reader["EDP_Nombres"].ToString();
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


        public List<EvaluacionInduccionBE> CHU_EvaluacionInduccion_Obtener()
        {
            List<EvaluacionInduccionBE> oList = new List<EvaluacionInduccionBE>();
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_CHU_EVI_OBTENER, conn)) {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                EvaluacionInduccionBE obj = new EvaluacionInduccionBE();
                                obj.Id = int.Parse(reader["EVI_Id"].ToString());
                                obj.Departamentos.Nombre = reader["DEP_Nombre"].ToString();
                                obj.Puestos.Nombre = reader["PUE_Nombre"].ToString();
                                obj.DatosPersonales.AMaterno = (reader["EDP_AMaterno"].ToString());
                                obj.DatosPersonales.APaterno = (reader["EDP_APaterno"].ToString());
                                obj.DatosPersonales.Nombres = (reader["EDP_Nombres"].ToString());
                                obj.DatosPersonales.IdExpediente = int.Parse(reader["EXP_Id"].ToString());
                                obj.IdEmpleado = int.Parse(reader["EMP_Numero"].ToString());
                                obj.Observaciones= (reader["EVI_Observaciones"].ToString());
                                obj.Calificacion = decimal.Parse(reader["EVI_Observaciones"].ToString());

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
        public int CHU_EvaluacionInduccion_Guardar(DataSet Tablas, int IdUsuario)
        {
            int Result = 0;
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_CHU_EVI_GUARDAR, conn)) {
                        cmd.Parameters.AddWithValue("@Evaluacion", Tablas.Tables["Evaluacion"]);
                        cmd.Parameters.AddWithValue("@Respuestass", Tablas.Tables["Respuestass"]);
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
