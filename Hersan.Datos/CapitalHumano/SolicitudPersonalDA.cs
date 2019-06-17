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
    public class SolicitudPersonalDA: BaseDA
    {
        #region Constantes
        const string CONST_CHU_SPE_OBTENER = "CHU_SolicitudPersonal_Obtener";
        const string CONST_CHU_SPE_GUARDAR = "CHU_SolicitudPersonal_Guarda";
        const string CONST_CHU_SPE_ACTUALIZAR = "CHU_SolicitudPersonal_Actualiza";
        const string CONST_CHU_SPE_ACTUALIZARDICTAMEN = "CHU_SolicitudPersonal_ActualizaDictamen";
        #endregion
        

        public List<SolicitudPersonalBE> CHU_SolicitudP_Obtener(int IdUser)
        {
            List<SolicitudPersonalBE> oList = new List<SolicitudPersonalBE>();
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_CHU_SPE_OBTENER, conn)) {
                       
                        cmd.Parameters.AddWithValue("@idUser", IdUser);
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                SolicitudPersonalBE obj = new SolicitudPersonalBE();
                               
                                obj.Id = int.Parse(reader["SPE_Id"].ToString());
                                obj.Entidades.Nombre = (reader["ENT_Nombre"].ToString());
                                obj.Departamentos.Nombre = reader["DEP_Nombre"].ToString();
                                obj.Puestos.Nombre = reader["PUE_Nombre"].ToString();
                                obj.TiposContrato.Nombre = reader["TCO_Nombre"].ToString();
                                obj.Entidades.Id = int.Parse(reader["ENT_Id"].ToString());
                                obj.Departamentos.Id = int.Parse(reader["DEP_Id"].ToString());
                                obj.Puestos.Id = int.Parse(reader["PUE_Id"].ToString());
                                obj.TiposContrato.Id = int.Parse(reader["TCO_Id"].ToString());
                                obj.Dictamen = (reader["SPE_Dictamen"].ToString());
                                obj.DatosUsuario.Estatus = bool.Parse(reader["SPE_Estatus"].ToString());
                                obj.Sueldo = decimal.Parse(reader["SPE_Sueldo"].ToString());
                                obj.Justificacion = (reader["SPE_Justificacion"].ToString());
                                obj.Indicadores = (reader["SPE_Indicadores"].ToString());
                                obj.Estado = (reader["Estado"].ToString());
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

        public int CHU_SolicitudP_Guardar(SolicitudPersonalBE obj)
        {
            int Result = 0;
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_CHU_SPE_GUARDAR, conn)) {
                   
                        cmd.Parameters.AddWithValue("@Id_ENT", obj.Entidades.Id);
                        cmd.Parameters.AddWithValue("@Id_DEP", obj.Departamentos.Id);
                        cmd.Parameters.AddWithValue("@Id_PUE", obj.Puestos.Id);
                        cmd.Parameters.AddWithValue("@Id_TCO", obj.TiposContrato.Id);                     
                        cmd.Parameters.AddWithValue("@Sueldo", obj.Sueldo);
                        cmd.Parameters.AddWithValue("@Indicadores", obj.Indicadores);                    
                        cmd.Parameters.AddWithValue("@Justificacion", obj.Justificacion);
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

        public int CHU_SolicitudP_Actualizar(SolicitudPersonalBE obj)
        {
            int Result = 0;
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_CHU_SPE_ACTUALIZAR, conn)) {
                        cmd.Parameters.AddWithValue("@Id", obj.Id);
                        cmd.Parameters.AddWithValue("@Id_ENT", obj.Entidades.Id);
                        cmd.Parameters.AddWithValue("@Id_DEP", obj.Departamentos.Id);
                        cmd.Parameters.AddWithValue("@Id_PUE", obj.Puestos.Id);
                        cmd.Parameters.AddWithValue("@Id_TCO", obj.TiposContrato.Id);
                        cmd.Parameters.AddWithValue("@Sueldo", obj.Sueldo);
                        cmd.Parameters.AddWithValue("@Indicadores", obj.Indicadores);
                        cmd.Parameters.AddWithValue("@Justificacion", obj.Justificacion);
                        cmd.Parameters.AddWithValue("@IdUsuario", obj.DatosUsuario.IdUsuarioCreo);
                        cmd.Parameters.AddWithValue("@Estatus", obj.DatosUsuario.Estatus);

                        cmd.CommandType = CommandType.StoredProcedure;
                        Result = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
                return Result;
            } catch (Exception ex) {
                throw ex;
            }
        }

        public int CHU_SolicitudP_ActualizarDictamen(SolicitudPersonalBE obj)
        {
            int Result = 0;
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_CHU_SPE_ACTUALIZARDICTAMEN, conn)) {
                        cmd.Parameters.AddWithValue("@Id", obj.Id);
                        cmd.Parameters.AddWithValue("@Dictamen", obj.Dictamen);
                        cmd.Parameters.AddWithValue("@Estado", obj.Estado);
                        cmd.Parameters.AddWithValue("@IdUsuario", obj.DatosUsuario.IdUsuarioCreo);
                        cmd.Parameters.AddWithValue("@Estatus", obj.DatosUsuario.Estatus);

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
