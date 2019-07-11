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
    public class DescripcionPuestosDA:BaseDA
    {
        #region Constantes
        const string CONST_USP_CHU_DESCPUESTO_GUARDA = "CHU_DescripcionPuestos_Guarda";
        const string CONST_USP_CHU_DESCPUESTO_OBTENER = "CHU_DescripcionPuestos_Obtener";
        const string CONST_USP_CHU_DESCPUESTO_ACTUALIZA = "CHU_DescripcionPuestos_Actualiza";
        const string CONST_USP_CHU_DESCPUESTO_ELIMINAR = "CHU_DescripcionPuestos_Eliminar";
        const string CONST_USP_CHU_DESCPUESTO_REPORTE1 = "CHU_RptDescPuestos_Obtener";
        const string CONST_USP_CHU_DESCPUESTO_REPORTE2 = "CHU_RptDescPuestos2_Obtener";        
        #endregion


        public DataSet CHU_DescripcionPuestos_Obtener(int IdPerfifl)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet oData = new DataSet();

            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_USP_CHU_DESCPUESTO_OBTENER, conn)) {
                        cmd.Parameters.AddWithValue("@IdPerfil", IdPerfifl);

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
        public int CHU_DescPuestos_Guardar(DescripcionPuestosBE obj, DataTable Contactos, DataTable Condiciones)
        {
            int Result = 0;
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_USP_CHU_DESCPUESTO_GUARDA, conn)) {
                        cmd.Parameters.AddWithValue("@IdPerfil", obj.Perfiles.Id);
                        cmd.Parameters.AddWithValue("@Colaboradores", obj.Colabordores);
                        cmd.Parameters.AddWithValue("@Clave", obj.Clave);
                        cmd.Parameters.AddWithValue("@Autoridad", obj.Autoridad);
                        cmd.Parameters.AddWithValue("@Superior", obj.Superior);
                        cmd.Parameters.AddWithValue("@Inferior", obj.Inferior);
                        cmd.Parameters.AddWithValue("@Objetivo", obj.Objetivo);
                        cmd.Parameters.AddWithValue("@Observaciones", obj.Observaciones);
                        cmd.Parameters.AddWithValue("@Contactos", Contactos);
                        cmd.Parameters.AddWithValue("@CondicionesT", Condiciones);
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
        public int CHU_DescPuestos_Actualizar(DescripcionPuestosBE obj, DataTable Contactos, DataTable Condiciones)
        {
            int Result = 0;
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_USP_CHU_DESCPUESTO_ACTUALIZA, conn)) {
                        cmd.Parameters.AddWithValue("@Id", obj.Id);
                        cmd.Parameters.AddWithValue("@IdPerfil", obj.Perfiles.Id);
                        cmd.Parameters.AddWithValue("@Colaboradores", obj.Colabordores);
                        cmd.Parameters.AddWithValue("@Clave", obj.Clave);
                        cmd.Parameters.AddWithValue("@Autoridad", obj.Autoridad);
                        cmd.Parameters.AddWithValue("@Superior", obj.Superior);
                        cmd.Parameters.AddWithValue("@Inferior", obj.Inferior);
                        cmd.Parameters.AddWithValue("@Objetivo", obj.Objetivo);
                        cmd.Parameters.AddWithValue("@Observaciones", obj.Observaciones);
                        cmd.Parameters.AddWithValue("@Contactos", Contactos);
                        cmd.Parameters.AddWithValue("@CondicionesT", Condiciones);
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
        public int CHU_DescPuestos_Elimina(int IdDesc, int IdUsuario)
        {
            int Result = 0;
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_USP_CHU_DESCPUESTO_ELIMINAR, conn)) {
                        cmd.Parameters.AddWithValue("@Id", IdDesc);
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
        public DataTable CHU_DescPuesto_ReporteDetalle(int IdPerfil,int idPuesto,int IdDepto)
        {
            DataTable oData = new DataTable("Reporte");
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_USP_CHU_DESCPUESTO_REPORTE1, conn)) {
                        cmd.Parameters.AddWithValue("@IdPerfil", IdPerfil);
                        cmd.Parameters.AddWithValue("@IdPuesto", idPuesto);
                        cmd.Parameters.AddWithValue("@IdDep",IdDepto);

                        cmd.CommandType = CommandType.StoredProcedure;
                        oData.Load(cmd.ExecuteReader());
                    }
                 
                }
                return oData;
            } catch (Exception ex) {
                throw ex;
            }
        }
        public DataTable CHU_DescPuesto_ReporteDetalle2(int IdPerfil)
        {
            DataTable oData = new DataTable("Reporte2");
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_USP_CHU_DESCPUESTO_REPORTE1, conn)) {
                        cmd.Parameters.AddWithValue("@IdPerfil", IdPerfil);
                        cmd.CommandType = CommandType.StoredProcedure;
                        oData.Load(cmd.ExecuteReader());
                    }

                }
                return oData;
            } catch (Exception ex) {
                throw ex;
            }
        }


    }
}
