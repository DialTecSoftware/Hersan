using Hersan.Entidades.Ensamble;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Hersan.Datos.Ensamble
{
    public class ServiciosDA: BaseDA
    {
        #region Constantes
        const string CONS_USP_ENS_SERVICIOS_GUARDAR = "ENS_Servicios_Guardar";
        const string CONS_USP_ENS_SERVICIOS_ACTUALIZAR = "ENS_Servicios_Actualizar";
        const string CONS_USP_ENS_SERVICIOS_OBTENER = "ENS_Servicios_Obtener";
        const string CONS_USP_ENS_SERVICIOS_COMBO = "ENS_Servicios_Combo";
        const string CONS_USP_ENS_SERVICIOSCOTIZACION_COMBO = "ENS_ServiciosCotizacion_Combo";
        #endregion

        public int ENS_Servicios_Guardar(ServiciosBE obj)
        {
            int Result = 0;
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONS_USP_ENS_SERVICIOS_GUARDAR, conn)) {
                        cmd.Parameters.AddWithValue("@IdEntidad", obj.Entidad.Id);                        
                        cmd.Parameters.AddWithValue("@Clave", obj.Clave);
                        cmd.Parameters.AddWithValue("@Nombre", obj.Nombre);
                        cmd.Parameters.AddWithValue("@Precio", obj.Precio);
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
        public int ENS_Servicios_Actualizar(ServiciosBE obj)
        {
            int Result = 0;
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONS_USP_ENS_SERVICIOS_ACTUALIZAR, conn)) {
                        cmd.Parameters.AddWithValue("@Id", obj.Id);
                        cmd.Parameters.AddWithValue("@IdEntidad", obj.Entidad.Id);
                        cmd.Parameters.AddWithValue("@Clave", obj.Clave);
                        cmd.Parameters.AddWithValue("@Nombre", obj.Nombre);
                        cmd.Parameters.AddWithValue("@Precio", obj.Precio);
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
        public List<ServiciosBE> ENS_Servicios_Obtener()
        {
            List<ServiciosBE> oList = new List<ServiciosBE>();
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONS_USP_ENS_SERVICIOS_OBTENER, conn)) {

                        cmd.CommandType = CommandType.StoredProcedure;

                        /*SE OBTIENEN LOS REFLEJANTES */
                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                ServiciosBE obj = new ServiciosBE();

                                obj.Id = int.Parse(reader["SER_Id"].ToString());
                                obj.Entidad.Id = int.Parse(reader["ENT_Id"].ToString());
                                obj.Entidad.Nombre = reader["ENT_Nombre"].ToString();
                                obj.Clave = reader["SER_Clave"].ToString();
                                obj.Nombre = reader["SER_Nombre"].ToString();
                                obj.Precio = decimal.Parse(reader["SER_Precio"].ToString());
                                obj.DatosUsuario.Estatus = bool.Parse(reader["SER_Estatus"].ToString());

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
        public List<ServiciosBE> ENS_Servicios_Combo(int IdEntidad)
        {
            List<ServiciosBE> oList = new List<ServiciosBE>();
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONS_USP_ENS_SERVICIOS_COMBO, conn)) {
                        cmd.Parameters.AddWithValue("@IdEntidad", IdEntidad);

                        cmd.CommandType = CommandType.StoredProcedure;

                        /*SE OBTIENEN LOS REFLEJANTES */
                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                ServiciosBE obj = new ServiciosBE();

                                obj.Id = int.Parse(reader["SER_Id"].ToString());
                                obj.Clave = reader["SER_Clave"].ToString();
                                obj.Nombre = reader["SER_Nombre"].ToString();
                                obj.Precio = decimal.Parse(reader["SER_Precio"].ToString());

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
        public List<ServiciosBE> ENS_ServiciosCotizacion_Combo()
        {
            List<ServiciosBE> oList = new List<ServiciosBE>();
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONS_USP_ENS_SERVICIOSCOTIZACION_COMBO, conn)) {

                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                ServiciosBE obj = new ServiciosBE();

                                obj.Id = int.Parse(reader["SER_Id"].ToString());
                                obj.Entidad.Nombre = reader["ENT_Nombre"].ToString();
                                obj.Clave = reader["SER_Clave"].ToString();
                                obj.Nombre = reader["SER_Nombre"].ToString();
                                obj.Precio = decimal.Parse(reader["SER_Precio"].ToString());

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
