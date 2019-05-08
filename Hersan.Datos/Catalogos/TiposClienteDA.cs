using Hersan.Entidades.Catalogos;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System;


namespace Hersan.Datos.Catalogos
{
    public class TiposClienteDA : BaseDA
    {
        #region Constantes
        const string CONS_USP_ABC_TIPOCLIENTE_GUARDAR = "ABC_TipoCliente_Guardar";
        const string CONS_USP_ABC_TIPOCLIENTE_ACTUALIZAR = "ABC_TipoCliente_Actualizar";
        const string CONS_USP_ABC_TIPOCLIENTE_OBTENER = "ABC_TipoCliente_Obtener";
        const string CONS_USP_ABC_TIPOCLIENTE_COMBO = "ABC_TipoCliente_Combo";
        #endregion

        public int ABC_TipoCliente_Guardar(TiposClienteBE obj)
        {
            int Result = 0;
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONS_USP_ABC_TIPOCLIENTE_GUARDAR, conn)) {                        
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
        public int ABC_TipoCliente_Actualizar(TiposClienteBE obj)
        {
            int Result = 0;
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONS_USP_ABC_TIPOCLIENTE_ACTUALIZAR, conn)) {
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
        public List<TiposClienteBE> ABC_TipoCliente_Obtener()
        {
            List<TiposClienteBE> oList = new List<TiposClienteBE>();
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONS_USP_ABC_TIPOCLIENTE_OBTENER, conn)) {

                        cmd.CommandType = CommandType.StoredProcedure;

                        /*SE OBTIENEN LOS REFLEJANTES */
                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                TiposClienteBE obj = new TiposClienteBE();

                                obj.Id = int.Parse(reader["TIC_Id"].ToString());
                                obj.Abrev= reader["TIC_Abrev"].ToString();
                                obj.Nombre = reader["TIC_Nombre"].ToString();
                                obj.DatosUsuario.Estatus = bool.Parse(reader["TIC_Estatus"].ToString());

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
        public List<TiposClienteBE> ABC_TipoCliente_Combo()
        {
            List<TiposClienteBE> oList = new List<TiposClienteBE>();
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONS_USP_ABC_TIPOCLIENTE_COMBO, conn)) {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                TiposClienteBE obj = new TiposClienteBE();

                                obj.Id = int.Parse(reader["TIC_Id"].ToString());
                                obj.Nombre = reader["TIC_Nombre"].ToString();

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
