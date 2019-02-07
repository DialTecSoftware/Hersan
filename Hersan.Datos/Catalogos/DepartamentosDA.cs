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
        const string CONST_ABC_DEPARTAMENTOS_OBTENER = "ABC_Departamentos_Obtener";
        const string CONST_ABC_DEPARTAMENTOS_GUARDAR = "ABC_Departamentos_Guarda";
        const string CONST_ABC_DEPARTAMENTOS_ACTUALIZA = "ABC_Departamentos_Actualiza";
        const string CONST_ABC_DEPARTAMENTOS_COMBO = "ABC_Departamentos_Combo";
        #endregion

        public List<DepartamentosBE> ABCDepartamentos_Obtener()
        {
            List<DepartamentosBE> oList = new List<DepartamentosBE>();
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_ABC_DEPARTAMENTOS_OBTENER, conn)) {

                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                DepartamentosBE obj = new DepartamentosBE();

                                obj.Id = int.Parse(reader["DEP_ID"].ToString());
                                obj.Nombre = reader["DEP_Nombre"].ToString();
                                obj.Abrev = reader["DEP_Abrev"].ToString();
                                obj.DatosUsuario.Estatus = bool.Parse(reader["DEP_Estatus"].ToString());
                                obj.Entidades.Id = int.Parse(reader["ENT_Id"].ToString());
                                obj.Entidades.Nombre = reader["ENT_Nombre"].ToString();

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
        public int ABCDEpartamentos_Guardar(DepartamentosBE obj)
        {
            int Result = 0;
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_ABC_DEPARTAMENTOS_GUARDAR, conn)) {
                        cmd.Parameters.AddWithValue("@IdEnt", obj.Entidades.Id);
                        cmd.Parameters.AddWithValue("@Nombre", obj.Nombre);
                        cmd.Parameters.AddWithValue("@Abrev", obj.Abrev);
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
        public int ABCDEpartamentos_Actualizar(DepartamentosBE obj)
        {
            int Result = 0;
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_ABC_DEPARTAMENTOS_ACTUALIZA, conn)) {
                        cmd.Parameters.AddWithValue("@IdEnt", obj.Entidades.Id);
                        cmd.Parameters.AddWithValue("@Id", obj.Id);
                        cmd.Parameters.AddWithValue("@Nombre", obj.Nombre);
                        cmd.Parameters.AddWithValue("@Abrev", obj.Abrev);
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
        public List<DepartamentosBE> ABCDepartamentos_Combo(int IdEntidad)
        {
            List<DepartamentosBE> oList = new List<DepartamentosBE>();
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_ABC_DEPARTAMENTOS_COMBO, conn)) {
                        cmd.Parameters.AddWithValue("@IdEnt", IdEntidad);
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                DepartamentosBE obj = new DepartamentosBE();

                                obj.Id = int.Parse(reader["DEP_ID"].ToString());
                                obj.Nombre = reader["DEP_Nombre"].ToString();

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
