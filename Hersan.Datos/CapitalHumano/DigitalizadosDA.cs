using Hersan.Entidades.CapitalHumano;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hersan.Datos
{
    public class DigitalizadosDA : BaseDA
    {
        #region Constantes
        const string CONST_USP_CHU_DIGITALIZADOS_GUARDA = "CHU_Digitalizados_Guarda";
        const string CONST_USP_CHU_DIGITALIZADOS_OBTENER = "CHU_Digitalizados_Obtener";
        const string CONST_USP_CHU_DIGITALIZADOS_ACTUALIZA = "CHU_Digitalizados_Actualiza";
        const string CONST_USP_DIGITALIZADOS_PERFILES_ELIMINAR = "CHU_Digitalizados_Eliminar";
        #endregion


        public DataSet CHU_Digitalizados_Obtener(int IdExp)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet oData = new DataSet();

            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_USP_CHU_DIGITALIZADOS_OBTENER, conn)) {
                        cmd.Parameters.AddWithValue("@EXP_Id", IdExp);

                        cmd.CommandType = CommandType.StoredProcedure;
                        da = new SqlDataAdapter(cmd);
                        da.Fill(oData);
                    }
                }
                return oData;
            } catch (Exception) {

                throw;
            }
        }



        public int CHU_Digitalizados_Guardar(DigitalizadosBE obj, DataTable Detalle)
        {
            int Result = 0;
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_USP_CHU_DIGITALIZADOS_GUARDA, conn)) {
                        cmd.Parameters.AddWithValue("@EXP_Id", obj.Expedientes.Id);
                        cmd.Parameters.AddWithValue("@Digitalizados", Detalle);
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


      
        public int CHU_Digitalizados_Actualiza(DigitalizadosBE obj, DataTable Detalle)
        {
            int Result = 0;
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_USP_CHU_DIGITALIZADOS_ACTUALIZA, conn)) {
                        cmd.Parameters.AddWithValue("@IdDoc", obj.Id);
                        cmd.Parameters.AddWithValue("@EXP_Id", obj.Expedientes.Id);
                        cmd.Parameters.AddWithValue("@Digitalizados", Detalle);
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
        public int CHU_Digitalizados_Elimina(int IdDocs, int IdUsuario)
        {
            int Result = 0;
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_USP_DIGITALIZADOS_PERFILES_ELIMINAR, conn)) {
                        cmd.Parameters.AddWithValue("@Id", IdDocs);
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
