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
   public class SeguimientoCandidatosDA:BaseDA
    {
        #region Constantes
        const string CONST_CHU_SCA_OBTENER = "CHU_SeguimientoCandidatos_Obtener";
        const string CONST_CHU_SCA_GUARDAR = "CHU_SeguimientoCandidatos_Guarda";
        const string CONST_CHU_SCA_ACTUALIZAR = "CHU_SeguimientoCandidatos_Actualiza";
        #endregion


        public List<SeguimientoCandidatosBE> CHU_SeguimientoCan_Obtener()
        {
            List<SeguimientoCandidatosBE> oList = new List<SeguimientoCandidatosBE>();
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_CHU_SCA_OBTENER, conn)) {
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                SeguimientoCandidatosBE obj = new SeguimientoCandidatosBE();

                                obj.Id = int.Parse(reader["SCA_Id"].ToString());
                                obj.NombreCompleto = reader["SCA_NombreCompleto"].ToString();
                                obj.Correo= reader["SCA_Correo"].ToString();
                                obj.Entidades.Nombre = (reader["ENT_Nombre"].ToString());
                                obj.Departamentos.Nombre = reader["DEP_Nombre"].ToString();
                                obj.Puestos.Nombre = reader["PUE_Nombre"].ToString();
                                obj.Entidades.Id = int.Parse(reader["ENT_Id"].ToString());
                                obj.Departamentos.Id = int.Parse(reader["DEP_Id"].ToString());
                                obj.Puestos.Id = int.Parse(reader["PUE_Id"].ToString());                               
                                obj.Proceso = bool.Parse(reader["SCA_Proceso"].ToString());
                                obj.Aceptado = bool.Parse(reader["SCA_Aceptado"].ToString());
                                obj.Rechazado = !obj.Aceptado;
                                if (bool.Parse(reader["SCA_Proceso"].ToString()) == true) 
                                    {
                                    obj.Rechazado = obj.Aceptado;
                                    }
                                obj.DatosUsuario.Estatus = bool.Parse(reader["SCA_Estatus"].ToString());
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

        public int CHU_SeguimientoCan_Guardar(SeguimientoCandidatosBE obj)
        {
            int Result = 0;
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_CHU_SCA_GUARDAR, conn)) {

                        cmd.Parameters.AddWithValue("@Id_ENT", obj.Entidades.Id);
                        cmd.Parameters.AddWithValue("@Id_DEP", obj.Departamentos.Id);
                        cmd.Parameters.AddWithValue("@Id_PUE", obj.Puestos.Id);
                        cmd.Parameters.AddWithValue("@Nombre", obj.NombreCompleto);
                        cmd.Parameters.AddWithValue("@Correo", obj.Correo);
                        cmd.Parameters.AddWithValue("@Proceso", obj.Proceso);
                        cmd.Parameters.AddWithValue("@Aceptado", obj.Aceptado);
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

        public int CHU_SeguimientoCan_Actualizar(SeguimientoCandidatosBE obj)
        {
            int Result = 0;
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_CHU_SCA_ACTUALIZAR, conn)) {
                        cmd.Parameters.AddWithValue("@Id", obj.Id);
                        cmd.Parameters.AddWithValue("@Id_ENT", obj.Entidades.Id);
                        cmd.Parameters.AddWithValue("@Id_DEP", obj.Departamentos.Id);
                        cmd.Parameters.AddWithValue("@Id_PUE", obj.Puestos.Id);
                        cmd.Parameters.AddWithValue("@Nombre", obj.NombreCompleto);
                        cmd.Parameters.AddWithValue("@Correo", obj.Correo);
                        cmd.Parameters.AddWithValue("@Proceso", obj.Proceso);
                        cmd.Parameters.AddWithValue("@Aceptado", obj.Aceptado);
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
