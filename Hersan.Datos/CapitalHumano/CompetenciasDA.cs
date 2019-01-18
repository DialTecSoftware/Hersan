using Hersan.Entidades.CapitalHumano;
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
    public class CompetenciasDA : BaseDA
    {
        #region Constantes
        const string CONST_USP_ABC_COMPETENCIAS_OBTENER = "ABC_Competencias_Obtener";
        const string CONST_ABC_COMPETENCIAS_GUARDAR = "ABC_Competencias_Guarda";
        const string CONST_ABC_COMPETENCIAS_ACTUALIZA = "ABC_Competencias_Actualiza";
        #endregion

        public List<CompetenciasBE> ABCCompetencias_Obtener()
        {
            List<CompetenciasBE> oList = new List<CompetenciasBE>();
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_USP_ABC_COMPETENCIAS_OBTENER, conn)) {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                CompetenciasBE obj = new CompetenciasBE();

                                obj.Id = int.Parse(reader["COM_ID"].ToString());
                                obj.Nombre = reader["COM_Nombre"].ToString();
                                obj.Descripcion = reader["COM_Descripcion"].ToString();
                                obj.Ponderacion= int.Parse(reader["COM_Ponderacion"].ToString());
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

        public int ABC_Competencias_Guardar(CompetenciasBE obj)
        {
            int Result = 0;
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_ABC_COMPETENCIAS_GUARDAR, conn)) {
                        cmd.Parameters.AddWithValue("@Nombre", obj.Nombre);
                        cmd.Parameters.AddWithValue("@Descripcion", obj.Descripcion);
                        cmd.Parameters.AddWithValue("@Ponderacion", obj.Ponderacion);
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


        public int ABCCompetencias_Actualizar(CompetenciasBE obj)
        {
            int Result = 0;
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_ABC_COMPETENCIAS_ACTUALIZA, conn)) {
                        cmd.Parameters.AddWithValue("@Id", obj.Id);
                        cmd.Parameters.AddWithValue("@Nombre", obj.Nombre);
                        cmd.Parameters.AddWithValue("@Descripcion", obj.Descripcion);
                        cmd.Parameters.AddWithValue("@Ponderacion", obj.Ponderacion);
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



