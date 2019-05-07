using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Hersan.Datos.Ensamble
{
    public class PedidosDA : BaseDA
    {
        #region Constantes
        const string CONS_USP_ENS_COTIZACION_GUARDAR = "ENS_Cotizacion_Guardar";
        #endregion


        public int ENS_Cotizacion_Guardar(int IdCliente, DataTable oDetalle, int IdUsuario)
        {
            int Result = 0;
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONS_USP_ENS_COTIZACION_GUARDAR, conn)) {
                        cmd.Parameters.AddWithValue("@IdCliente", IdCliente);
                        cmd.Parameters.AddWithValue("@Detalle", oDetalle);
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
