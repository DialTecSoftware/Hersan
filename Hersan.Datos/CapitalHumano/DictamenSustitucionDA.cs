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
   public class DictamenSustitucionDA:BaseDA
    {
        #region Constantes
        const string CONST_CHU_DSU_OBTENER = "CHU_SolicitudDicatamen_Obtener";
        const string CONST_CHU_DSU_GUARDAR = "CHU_SolicitudDicatamen_Guarda";
        const string CONST_CHU_DSU_ACTUALIZAR = "CHU_SolicitudDicatamen_Actualiza";
        #endregion


        public List<DictamenSustitucionBE> CHUDictamenSolicitud_Obtener()
        {
            List<DictamenSustitucionBE> oList = new List<DictamenSustitucionBE>();
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_CHU_DSU_OBTENER, conn)) {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                DictamenSustitucionBE obj = new DictamenSustitucionBE();

                                obj.Id = int.Parse(reader["DSU_Id"].ToString());
                                obj.Solicitud.Id = int.Parse(reader["SPE_Id"].ToString());
                                obj.Entidades.Nombre= (reader["ENT_Nombre"].ToString());
                                obj.Departamentos.Nombre = (reader["DEP_Nombre"].ToString());
                                obj.Puestos.Nombre = (reader["PUE_Nombre"].ToString());
                                obj.TiposContrato.Nombre = (reader["TCO_Nombre"].ToString());
                                obj.Aceptado = bool.Parse(reader["DSU_Aceptado"].ToString());
                                obj.Rechazado = !obj.Aceptado;
                                obj.Solicitud.Sueldo = decimal.Parse(reader["SPE_Sueldo"].ToString());
                                obj.Solicitud.Justificacion = (reader["SPE_Justificacion"].ToString());
                                obj.Solicitud.Indicadores = (reader["SPE_Indicadores"].ToString());
                                obj.Dictamen= (reader["DSU_Dictamen"].ToString());
                                obj.Observaciones = (reader["DSU_Observaciones"].ToString());
                                obj.DatosUsuario.Estatus = bool.Parse(reader["DSU_Estatus"].ToString());

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

        public int CHUDictamenSolicitud__Guardar(DictamenSustitucionBE obj)
        {
            int Result = 0;
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_CHU_DSU_GUARDAR, conn)) {
                  
                        cmd.Parameters.AddWithValue("@Id_SPE", obj.Solicitud.Id);
                        cmd.Parameters.AddWithValue("@Dictamen", obj.Dictamen);
                        cmd.Parameters.AddWithValue("@Observaciones", obj.Dictamen);
                        cmd.Parameters.AddWithValue("@Aceptado", obj.Aceptado   );
                        cmd.Parameters.AddWithValue("@IdUsuario", obj.DatosUsuario.IdUsuarioCreo);

                        cmd.CommandType = CommandType.StoredProcedure;
                        Result = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
                return Result;
            } catch (Exception ex) {
                throw ex;
            }
        }

        public int CHUDictamenSolicitud_Actualizar(DictamenSustitucionBE obj)
        {
            int Result = 0;
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_CHU_DSU_ACTUALIZAR, conn)) {
                        cmd.Parameters.AddWithValue("@Id", obj.Id);
                        cmd.Parameters.AddWithValue("@Id_SPE", obj.Solicitud.Id);
                        cmd.Parameters.AddWithValue("@Dictamen", obj.Dictamen);
                        cmd.Parameters.AddWithValue("@Observaciones", obj.Observaciones);
                        cmd.Parameters.AddWithValue("@Aceptado", obj.Aceptado);
                        cmd.Parameters.AddWithValue("@Estatus", obj.DatosUsuario.Estatus);
                        cmd.Parameters.AddWithValue("@IdUsuario", obj.DatosUsuario.IdUsuarioCreo);

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
