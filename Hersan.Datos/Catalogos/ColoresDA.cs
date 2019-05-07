using Hersan.Entidades.Catalogos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Hersan.Datos.Catalogos
{
    public class ColoresDA: BaseDA
    {

        #region Constantes
        const string CONST_USP_ABC_COLORES_GUARDAR = "ABC_Colores_Guardar";
        const string CONST_USP_ABC_COLORES_ACTUALIZAR = "ABC_Colores_Actualizar";
        const string CONST_USP_ABC_COLORES_OBTENER = "ABC_Colores_Obtener";
        const string CONST_USP_ABC_COLORES_COMBO = "ABC_Colores_Combo";
        #endregion

        public int ABC_Colores_Guardar(ColoresBE obj)
        {
            int Result = 0;
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_USP_ABC_COLORES_GUARDAR, conn)) {
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
        public int ABC_Colores_Actualizar(ColoresBE obj)
        {
            int Result = 0;
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_USP_ABC_COLORES_ACTUALIZAR, conn)) {
                        cmd.Parameters.AddWithValue("@Id", obj.Id);
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
        public List<ColoresBE> ABC_Colores_Obtener()
        {
            List<ColoresBE> oList = new List<ColoresBE>();
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_USP_ABC_COLORES_OBTENER, conn)) {

                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                ColoresBE obj = new ColoresBE();

                                obj.Id = int.Parse(reader["COL_Id"].ToString());
                                obj.Clave = reader["COL_Clave"].ToString();
                                obj.Nombre = reader["COL_Nombre"].ToString();
                                obj.DatosUsuario.Estatus = bool.Parse(reader["COL_Estatus"].ToString());
                            
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
        public List<ColoresBE> ABC_Colores_Combo()
        {
            List<ColoresBE> oList = new List<ColoresBE>();
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_USP_ABC_COLORES_COMBO, conn)) {

                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                ColoresBE obj = new ColoresBE();

                                obj.Id = int.Parse(reader["COL_Id"].ToString());
                                obj.Nombre = reader["COL_Nombre"].ToString();

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
