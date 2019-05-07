using Hersan.Entidades.Catalogos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Hersan.Datos.Catalogos
{
    public class FamiliasDA : BaseDA
    {
        #region Constantes
        const string CONST_USP_ENS_FAMILIAS_GUARDAR = "ENS_Familias_Guardar";
        const string CONST_USP_ENS_FAMILIAS_OBTENER = "ENS_Familias_Obtener";
        const string CONST_USP_ENS_FAMILIAS_ACTUALIZAR = "ENS_Familias_Actualizar";
        const string CONST_USP_ENS_FAMILIAS_COMBO = "ENS_Familias_Combo";
        #endregion

        public int ENS_Familias_Guardar(FamiliasBE obj)
        {
            int Result = 0;
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_USP_ENS_FAMILIAS_GUARDAR, conn)) {
                        cmd.Parameters.AddWithValue("@IdEntidad", obj.Entidad.Id);
                        cmd.Parameters.AddWithValue("@Clave", obj.Clave);
                        cmd.Parameters.AddWithValue("@Nombre", obj.Nombre);
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
        public int ENS_Familias_Actualizar(FamiliasBE obj)
        {
            int Result = 0;
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_USP_ENS_FAMILIAS_ACTUALIZAR, conn)) {
                        cmd.Parameters.AddWithValue("@Id", obj.Id);
                        cmd.Parameters.AddWithValue("@IdEntidad", obj.Entidad.Id);
                        cmd.Parameters.AddWithValue("@Clave", obj.Clave);
                        cmd.Parameters.AddWithValue("@Nombre", obj.Nombre);                        
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
        public List<FamiliasBE> ENS_Familias_Obtener()
        {
            List<FamiliasBE> oList = new List<FamiliasBE>();
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_USP_ENS_FAMILIAS_OBTENER, conn)) {

                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                FamiliasBE obj = new FamiliasBE();

                                obj.Id = int.Parse(reader["FAM_Id"].ToString());
                                obj.Entidad.Id = int.Parse(reader["ENT_Id"].ToString());
                                obj.Entidad.Nombre = reader["ENT_Nombre"].ToString();
                                obj.Clave = reader["FAM_Clave"].ToString();
                                obj.Nombre = reader["FAM_Nombre"].ToString();
                                obj.DatosUsuario.Estatus = bool.Parse(reader["FAM_Estatus"].ToString());

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
        public List<FamiliasBE> ENS_Familias_Combo(int IdEntidad)
        {
            List<FamiliasBE> oList = new List<FamiliasBE>();
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_USP_ENS_FAMILIAS_COMBO, conn)) {
                        cmd.Parameters.AddWithValue("@IdEntidad", IdEntidad);

                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                FamiliasBE obj = new FamiliasBE();

                                obj.Id = int.Parse(reader["FAM_Id"].ToString());
                                obj.Clave = reader["FAM_Clave"].ToString();
                                obj.Nombre = reader["FAM_Nombre"].ToString();

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
