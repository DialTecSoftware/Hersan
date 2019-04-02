using Hersan.Entidades.CapitalHumano;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hersan.Datos.CapitalHumano
{
    public class PerfilesDA : BaseDA
    {
        #region Constantes
        const string CONST_USP_CHU_PERFILES_GUARDA = "CHU_Perfiles_Guarda";
        const string CONST_USP_CHU_PERFILES_OBTENER = "CHU_Perfiles_Obtener";
        const string CONST_USP_CHU_PERFILES_ACTUALIZA = "CHU_Perfiles_Actualiza";
        const string CONST_USP_CHU_PERFILES_ELIMINAR = "CHU_Perfiles_Eliminar";
        #endregion

        public int CHU_Perfiles_Guardar(PerfilesBE obj, DataTable Detalle)
        {
            int Result = 0;
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_USP_CHU_PERFILES_GUARDA, conn)) {
                        cmd.Parameters.AddWithValue("@IdDepto", obj.Puesto.Departamentos.Id);
                        cmd.Parameters.AddWithValue("@IdPuesto", obj.Puesto.Id);
                        cmd.Parameters.AddWithValue("@Experiencia", obj.Experiencia);
                        cmd.Parameters.AddWithValue("@SueldoMax", obj.SueldoMax);
                        cmd.Parameters.AddWithValue("@Detalle", Detalle);
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
        public DataSet CHU_Perfiles_Obtener(int IdDepto, int IdPuesto)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet oData = new DataSet();
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_USP_CHU_PERFILES_OBTENER, conn)) {
                        cmd.Parameters.AddWithValue("@IdDepto", IdDepto);
                        cmd.Parameters.AddWithValue("@IdPuesto", IdPuesto);

                        cmd.CommandType = CommandType.StoredProcedure;
                        da = new SqlDataAdapter(cmd);
                        da.Fill(oData);

                        //using (SqlDataReader reader = cmd.ExecuteReader()) {
                        //    while (reader.Read()) {
                        //        PerfilesBE obj = new PerfilesBE();

                        //        obj.Id = int.Parse(reader["COM_ID"].ToString());
                        //        obj.Experiencia = reader["PER_Experiencia"].ToString();
                        //        obj.Puesto.Departamentos.Id = int.Parse(reader["DEP_Id"].ToString());
                        //        obj.Puesto.Id = int.Parse(reader["PUE_Id"].ToString());

                        //        obj.Educacion.Add(new Entidades.Catalogos.EducacionBE() { Id = int.Parse(reader["EDU_Id"].ToString()),
                        //            Tipo = reader["EDU_Id"].ToString(), Nombre = reader["EDU_Nombre"].ToString()
                        //        });

                        //        obj.Funcion.Add(new FuncionesBE { Id = int.Parse(reader["FUN_Id"].ToString()),
                        //            Nombre = reader["FUN_Nombre"].ToString()
                        //        });

                        //        obj.Competencia.Add(new CompetenciasBE{ Id = int.Parse(reader["COM_Id"].ToString()),
                        //            Nombre = reader["COM_Nombre"].ToString()
                        //        });

                        //        oList.Add(obj);
                        //    }
                        //}
                    }
                }
                return oData;
            } catch (Exception ex) {
                throw ex;
            }
        }
        public int CHU_Perfiles_Actualiza(PerfilesBE obj, DataTable Detalle)
        {
            int Result = 0;
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_USP_CHU_PERFILES_ACTUALIZA, conn)) {
                        cmd.Parameters.AddWithValue("@IdPerfil", obj.Id);
                        cmd.Parameters.AddWithValue("@Experiencia", obj.Experiencia);
                        cmd.Parameters.AddWithValue("@SueldoMax", obj.SueldoMax);
                        cmd.Parameters.AddWithValue("@Detalle", Detalle);
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
        public int CHU_Perfiles_Elimina(int IdPerfil, int IdUsuario)
        {
            int Result = 0;
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_USP_CHU_PERFILES_ELIMINAR, conn)) {
                        cmd.Parameters.AddWithValue("@IdPerfil", IdPerfil);
                        cmd.Parameters.AddWithValue("@IdUsuario", IdUsuario);

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
