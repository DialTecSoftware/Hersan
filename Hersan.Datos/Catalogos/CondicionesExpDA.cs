using Hersan.Entidades.Catalogos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Hersan.Datos.Catalogos
{
    public class CondicionesExpDA : BaseDA
    {
        #region Constantes
        const string CONST_ABC_CONDICIONESEXPORTACION_GUARDAR = "ABC_CondicionesExportacion_Guardar";
        const string CONST_ABC_CONDICIONESEXPORTACION_ACTUALIZAR = "ABC_CondicionesExportacion_Actualizar";
        const string CONST_ABC_CONDICIONESEXPORTACION_OBTENER = "ABC_CondicionesExportacion_Obtener";
        const string CONST_ABC_CONDICIONESEXPORTACION_COMBO = "ABC_CondicionesExportacion_Combo";
        #endregion

        public int ABC_CondicionesExportacion_Guardar (CondicionesExpBE obj)
        {
            int Result = 0;
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_ABC_CONDICIONESEXPORTACION_GUARDAR, conn)) {
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
        public int ABC_CondicionesExportacion_Actualizar(CondicionesExpBE obj)
        {
            int Result = 0;
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_ABC_CONDICIONESEXPORTACION_ACTUALIZAR, conn)) {
                        cmd.Parameters.AddWithValue("@Id", obj.Id);
                        cmd.Parameters.AddWithValue("@Nombre", obj.Nombre);
                        cmd.Parameters.AddWithValue("@Abrev", obj.Abrev);
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
        public List<CondicionesExpBE> ABC_CondicionesExportacion_Obtener()
        {
            List<CondicionesExpBE> oList = new List<CondicionesExpBE>();
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_ABC_CONDICIONESEXPORTACION_OBTENER, conn)) {

                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                CondicionesExpBE obj = new CondicionesExpBE();

                                obj.Id = int.Parse(reader["CEX_Id"].ToString());                                
                                obj.Nombre = reader["CEX_Nombre"].ToString();
                                obj.Abrev = reader["CEX_Abrev"].ToString();
                                obj.DatosUsuario.Estatus = bool.Parse(reader["CEX_Estatus"].ToString());

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
        public List<CondicionesExpBE> ABC_CondicionesExportacion_Combo()
        {
            List<CondicionesExpBE> oList = new List<CondicionesExpBE>();
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_ABC_CONDICIONESEXPORTACION_COMBO, conn)) {

                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                CondicionesExpBE obj = new CondicionesExpBE();

                                obj.Id = int.Parse(reader["CEX_Id"].ToString());
                                obj.Nombre = reader["CEX_Nombre"].ToString();
                                obj.Abrev = reader["CEX_Abrev"].ToString();

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
