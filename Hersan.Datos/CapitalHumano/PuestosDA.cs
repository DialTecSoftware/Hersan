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
  public  class PuestosDA:BaseDA
    {
        #region Constantes
        const string CONST_USP_ABC_PUESTOS_OBTENER = "ABC_Puestos_Obtener";
        const string CONST_USP_ABC_PUESTO_GUARDA = "ABC_Puesto_Guarda";
        const string CONST_USP_ABC_PUESTO_ACTUALIZA = "ABC_Puesto_Actualiza";
        const string CONST_USP_ABC_PUESTOS_COMBO = "ABC_Puestos_Combo";
        const string CONST_USP_CHU_PUESTOS_COMBO = "CHU_Puntos_Puestos";
        #endregion

        public List<PuestosBE> ABCPuestos_Obtener()
        {
            List<PuestosBE> oList = new List<PuestosBE>();
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_USP_ABC_PUESTOS_OBTENER, conn)) {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                PuestosBE obj = new PuestosBE();

                                obj.Id = int.Parse(reader["PUE_Id"].ToString());
                                obj.Nombre = reader["PUE_Nombre"].ToString();
                                obj.Abrev = reader["PUE_Abrev"].ToString();
                                obj.Puntos = decimal.Parse(reader["PUE_Puntos"].ToString());
                                obj.Departamentos.Entidades.Id = int.Parse(reader["ENT_Id"].ToString());
                                obj.Departamentos.Entidades.Nombre = reader["ENT_Nombre"].ToString();
                                obj.DatosUsuario.Estatus = bool.Parse(reader["PUE_Estatus"].ToString());
                                obj.Departamentos.Id = int.Parse(reader["DEP_Id"].ToString());
                                obj.Departamentos.Nombre = reader["DEP_Nombre"].ToString();

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
        public int ABCPuestos_Guardar(PuestosBE obj)
        {
            int Result = 0;
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_USP_ABC_PUESTO_GUARDA, conn)) {
                        cmd.Parameters.AddWithValue("@IdDepto", obj.Departamentos.Id);
                        cmd.Parameters.AddWithValue("@Nombre", obj.Nombre);
                        cmd.Parameters.AddWithValue("@Abrev", obj.Abrev);
                        cmd.Parameters.AddWithValue("@Puntos", obj.Puntos);
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
        public int ABCPuestos_Actualizar(PuestosBE obj)
        {
            int Result = 0;
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_USP_ABC_PUESTO_ACTUALIZA, conn)) {
                        cmd.Parameters.AddWithValue("@Id", obj.Id);
                        cmd.Parameters.AddWithValue("@IdDepto", obj.Departamentos.Id);
                        cmd.Parameters.AddWithValue("@Nombre", obj.Nombre);
                        cmd.Parameters.AddWithValue("@Abrev", obj.Abrev);
                        cmd.Parameters.AddWithValue("@Puntos", obj.Puntos);
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
        public List<PuestosBE> ABCPuestos_Combo(int IdDepto)
        {
            List<PuestosBE> oList = new List<PuestosBE>();
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_USP_ABC_PUESTOS_COMBO, conn)) {
                        cmd.Parameters.AddWithValue("@DEP_Id", IdDepto);

                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                PuestosBE obj = new PuestosBE();

                                obj.Id = int.Parse(reader["PUE_Id"].ToString());
                                obj.Nombre = reader["PUE_Nombre"].ToString();

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

        public List<PuestosBE> CHUPuestos_Puntos(int idPuesto)
        {
            List<PuestosBE> oList = new List<PuestosBE>();
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_USP_CHU_PUESTOS_COMBO, conn)) {
                        cmd.Parameters.AddWithValue("@IdPuesto", idPuesto);

                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                PuestosBE obj = new PuestosBE();
                                obj.Puntos = decimal.Parse(reader["PUE_Puntos"].ToString());
                              

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

