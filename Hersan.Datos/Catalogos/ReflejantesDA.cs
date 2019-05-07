using Hersan.Entidades.Catalogos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Hersan.Datos.Catalogos
{
    public class ReflejantesDA : BaseDA
    {
        #region Constantes
        const string CONST_USP_ENS_COMPLEMENTOS_GUARDAR = "ENS_Reflejantes_Guardar";
        const string CONST_USP_ENS_COMPLEMENTOS_OBTENER = "ENS_Reflejantes_Obtener";
        const string CONST_USP_ENS_COMPLEMENTOS_ACTUALIZAR = "ENS_Reflejantes_Actualizar";
        const string CONST_USP_ENS_REFLEJANTES_COMBO = "ENS_Reflejantes_Combo";
        #endregion

        public int ENS_Reflejantes_Guardar(ReflejantesBE obj)
        {
            int Result = 0;
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_USP_ENS_COMPLEMENTOS_GUARDAR, conn)) {
                        cmd.Parameters.AddWithValue("@Tipo", obj.Tipo);
                        cmd.Parameters.AddWithValue("@Clave", obj.Clave);
                        cmd.Parameters.AddWithValue("@IdColor", obj.Color.Id);
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
        public int ENS_Reflejantes_Actualizar(ReflejantesBE obj)
        {
            int Result = 0;
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_USP_ENS_COMPLEMENTOS_ACTUALIZAR, conn)) {
                        cmd.Parameters.AddWithValue("@Id", obj.Id);
                        cmd.Parameters.AddWithValue("@Tipo", obj.Tipo);
                        cmd.Parameters.AddWithValue("@Clave", obj.Clave);
                        cmd.Parameters.AddWithValue("@IdColor", obj.Color.Id);
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
        public List<ReflejantesBE> ENS_Reflejantes_Obtener()
        {
            List<ReflejantesBE> oList = new List<ReflejantesBE>();
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_USP_ENS_COMPLEMENTOS_OBTENER, conn)) {

                        cmd.CommandType = CommandType.StoredProcedure;

                        /*SE OBTIENEN LOS REFLEJANTES */
                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                ReflejantesBE obj = new ReflejantesBE();

                                obj.Id = int.Parse(reader["COM_Id"].ToString());
                                obj.Tipo = reader["COM_Tipo"].ToString();
                                obj.Clave = reader["COM_Clave"].ToString();
                                obj.Color.Id = int.Parse(reader["COL_Id"].ToString());
                                obj.Color.Nombre = reader["COL_Nombre"].ToString();
                                obj.DatosUsuario.Estatus = bool.Parse(reader["COM_Estatus"].ToString());

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
        public List<ReflejantesBE> ENS_Reflejantes_Combo()
        {
            List<ReflejantesBE> oList = new List<ReflejantesBE>();
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_USP_ENS_REFLEJANTES_COMBO, conn)) {

                        cmd.CommandType = CommandType.StoredProcedure;

                        /*SE OBTIENEN LOS REFLEJANTES */
                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                ReflejantesBE obj = new ReflejantesBE();

                                obj.Id = int.Parse(reader["COM_Id"].ToString());
                                obj.Tipo = reader["Tipo"].ToString();
                                //obj.Color.Nombre = reader["COL_Nombre"].ToString();

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
