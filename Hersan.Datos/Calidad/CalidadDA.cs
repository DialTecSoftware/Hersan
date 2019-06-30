using Hersan.Entidades.Calidad;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Hersan.Datos.Calidad
{
    public class CalidadDA : BaseDA
    {
        #region Constantes
        const string CONS_USP_CAL_INSPECCIONINYECCION_GUARDA = "CAL_InspeccionInyeccion_Guarda";
        const string CONS_USP_CAL_INSPECCIONINYECCION_ACTUALIZA = "CAL_InspeccionInyeccion_Actualiza";
        const string CONS_USP_CAL_INSPECCIONINYECCION_ANALISIS = "CAL_InspeccionInyeccion_Analisis";
        #endregion

        public int CAL_InspeccionInyeccion_Guarda(CalidadBE Obj, System.Data.DataTable Detalle)
        {
            int Result = 0;
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONS_USP_CAL_INSPECCIONINYECCION_GUARDA, conn)) {
                        cmd.Parameters.AddWithValue("@IdInyeccion", Obj.Inyeccion.Id);
                        cmd.Parameters.AddWithValue("@Lista", Obj.Lista);
                        cmd.Parameters.AddWithValue("@Operador", Obj.Operador);
                        cmd.Parameters.AddWithValue("@Detalle", Detalle);
                        cmd.Parameters.AddWithValue("@IdUsuario", Obj.IdUsuario);

                        cmd.CommandType = CommandType.StoredProcedure;
                        Result = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
                return Result;
            } catch (Exception ex) {
                throw ex;
            }
        }
        public int CAL_InspeccionInyeccion_Actualiza(int IdInyeccion, System.Data.DataTable Detalle)
        {
            int Result = 0;
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONS_USP_CAL_INSPECCIONINYECCION_ACTUALIZA, conn)) {
                        cmd.Parameters.AddWithValue("@IdInspeccion", IdInyeccion);
                        cmd.Parameters.AddWithValue("@Detalle", Detalle);

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
