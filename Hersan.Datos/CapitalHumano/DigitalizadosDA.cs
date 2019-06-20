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
        #endregion

        public List<DigitalizadosDetalleBE> CHU_Digitalizados_Obtener(int IdExp)
        {
            List<DigitalizadosDetalleBE> oList = new List<DigitalizadosDetalleBE>();
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_USP_CHU_DIGITALIZADOS_OBTENER, conn)) {
                        cmd.Parameters.AddWithValue("@EXP_Id", IdExp);

                        cmd.CommandType = CommandType.StoredProcedure;
                        using (IDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                DigitalizadosDetalleBE obj = new DigitalizadosDetalleBE();

                                obj.Expediente.Id = int.Parse(reader["EXP_Id"].ToString());
                                obj.Documento.Id = int.Parse(reader["DOC_Id"].ToString());
                                obj.Documento.Nombre = reader["DOC_Nombre"].ToString();
                                obj.RutaArchivo = reader["DDT_RutaArchivo"].ToString();
                                obj.NombreArchivo = System.IO.Path.GetFileName(obj.RutaArchivo);
                                obj.RutaOriginal = obj.RutaArchivo;

                                oList.Add(obj);
                            }
                        }
                    }
                }
                return oList;
            } catch (Exception) {

                throw;
            }
        }
        public int CHU_Digitalizados_Guardar(int IdExpediente,  DataTable Detalle, int IdUsuario)
        {
            int Result = 0;
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_USP_CHU_DIGITALIZADOS_GUARDA, conn)) {
                        cmd.Parameters.AddWithValue("@EXP_Id", IdExpediente);
                        cmd.Parameters.AddWithValue("@Digitalizados", Detalle);
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
