using Hersan.Entidades.Catalogos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Hersan.Datos.Catalogos
{
    public class AccesoriosDA: BaseDA
    {

        #region Constantes
        const string CONST_USP_ENS_ACCESORIOS_GUARDAR = "ENS_Accesorios_Guardar";
        const string CONST_USP_ENS_ACCESORIOS_ACTUALIZAR = "ENS_Accesorios_Actualizar";
        const string CONST_USP_ENS_ACCESORIOS_OBTENER = "ENS_Accesorios_Obtener";
        const string CONST_USP_ENS_ACCESORIOS_COMBO = "ENS_Accesorios_Combo";
        #endregion

        public int ENS_Accesorios_Guardar(AccesoriosBE obj)
        {
            int Result = 0;
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_USP_ENS_ACCESORIOS_GUARDAR, conn)) {
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
        public int ENS_Accesorios_Actualizar(AccesoriosBE obj)
        {
            int Result = 0;
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_USP_ENS_ACCESORIOS_ACTUALIZAR, conn)) {
                        cmd.Parameters.AddWithValue("@Id", obj.Id);
                        cmd.Parameters.AddWithValue("@Clave", obj.Clave);
                        cmd.Parameters.AddWithValue("@Nombre", obj.Nombre);
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
        public List<AccesoriosBE> ENS_Accesorios_Obtener()
        {
            List<AccesoriosBE> oList = new List<AccesoriosBE>();
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_USP_ENS_ACCESORIOS_OBTENER, conn)) {

                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                AccesoriosBE obj = new AccesoriosBE();

                                obj.Id = int.Parse(reader["ACC_Id"].ToString());
                                obj.Clave = reader["ACC_Clave"].ToString();
                                obj.Nombre = reader["ACC_Nombre"].ToString();
                                obj.DatosUsuario.Estatus = bool.Parse(reader["ACC_Estatus"].ToString());

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
        public List<AccesoriosBE> ENS_Accesorios_Combo()
        {
            List<AccesoriosBE> oList = new List<AccesoriosBE>();
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_USP_ENS_ACCESORIOS_COMBO, conn)) {

                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                AccesoriosBE obj = new AccesoriosBE();

                                obj.Id = int.Parse(reader["ACC_Id"].ToString());
                                obj.Nombre = reader["ACC_Nombre"].ToString();

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
