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
   public class EntidadesDA :BaseDA
    {
        #region Constantes
        const string CONST_USP_ABC_ENTIDADES_OBTENER = "ABC_Entidades_Obtener";
        const string CONST_ABC_ENTIDADES_GUARDAR = "ABC_Entidades_Guarda";
        const string CONST_ABC_ENTIDADES_ACTUALIZAR = "ABC_Entidades_Actualiza";
        #endregion


        public List<EntidadesBE>  Entidades_Obtener()
        {
            List<EntidadesBE> oList = new List<EntidadesBE>();
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_USP_ABC_ENTIDADES_OBTENER, conn)) {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                EntidadesBE obj = new EntidadesBE();

                                obj.Id = int.Parse(reader["ENT_Id"].ToString());
                               
                                obj.Nombre = reader["ENT_Nombre"].ToString();
                                obj.Abrev = reader["ENT_Abrev"].ToString();
                                obj.DatosUsuario.Estatus = bool.Parse(reader["ENT_Estatus"].ToString());
                                obj.Empresas.Id = int.Parse(reader["EMP_Id"].ToString());
                                obj.Empresas.NombreComercial= reader["EMP_NombreComercial"].ToString();

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

        public int ABCEntidades_Guardar(EntidadesBE obj)
        {
            int Result = 0;
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_ABC_ENTIDADES_GUARDAR, conn)) {
                        cmd.Parameters.AddWithValue("@Id_Emp", obj.Empresas.Id);
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

        public int ABCEntidades_Actualizar(EntidadesBE obj)
        {
            int Result = 0;
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_ABC_ENTIDADES_ACTUALIZAR, conn)) {
                        cmd.Parameters.AddWithValue("@Id", obj.Id);
                        cmd.Parameters.AddWithValue("@Id_Emp", obj.Empresas.Id);
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
    }
}
