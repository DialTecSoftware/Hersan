using Hersan.Entidades.Seguridad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hersan.Datos.Seguridad
{
    public class RolesUsuarioDA : BaseDA
    {
        #region Constantes
        private const string CSTR_SP_ROLESUSUARIOS_OBTIENE = "SEG_RolesUsuarios_Obtiene";
        private const string CSTR_SP_ROLESUSUARIOS_GUARDA = "SEG_RolesUsuarios_Guarda";
        private const string CSTR_USP_ROLESUSUARIOS_ELIMINA = "SEG_RolesUsuarios_Elimina";
        #endregion

        /// <summary>
        /// Obtener Listado de Roles usuario
        /// </summary>
        /// <returns></returns>
        public List<RolesBE> ObtieneRolesUsuario(int IdUsuario)
        {
            try {
                List<RolesBE> lst = new List<RolesBE>();
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion())) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CSTR_SP_ROLESUSUARIOS_OBTIENE, conn)) {
                        cmd.Parameters.AddWithValue("@IdUsuario", IdUsuario);

                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                RolesBE obj = new RolesBE
                                {
                                    ID = int.Parse(reader["Rol_IdRol"].ToString()),
                                    Nombre = reader["Rol_Rol"].ToString(),
                                    EsAsignado = bool.Parse(reader["Asignado"].ToString())
                                };
                                lst.Add(obj);
                            }
                        }
                    }
                }
                return lst;
            } catch (Exception ex) {
                throw ex;
            }
        }

        /// <summary>
        /// Guarda el rol que se le asigno al usuario
        /// </summary>
        /// <param name="IdRol"></param>
        /// <param name="IdUsuario"></param>
        public void GuardaRolesUsuario(int IdRol, int IdUsuario)
        {
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlTransaction tran = conn.BeginTransaction()) {
                        using (SqlCommand cmd = new SqlCommand(CSTR_USP_ROLESUSUARIOS_ELIMINA, conn)) {
                            cmd.Parameters.AddWithValue("@IdUsuario", IdUsuario);                            

                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Transaction = tran;
                            cmd.ExecuteNonQuery();
                        }

                        using (SqlCommand cmd = new SqlCommand(CSTR_SP_ROLESUSUARIOS_GUARDA, conn)) {
                            cmd.Parameters.AddWithValue("@IdRol", IdRol);
                            cmd.Parameters.AddWithValue("@IdUsuario", IdUsuario);

                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Transaction = tran;
                            cmd.ExecuteNonQuery();
                        }

                        tran.Commit();
                    }
                }
            } catch (Exception ex) {
                throw ex;
            }
        }
    }
}
