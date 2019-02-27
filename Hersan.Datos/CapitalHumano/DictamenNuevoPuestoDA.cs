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
    public class DictamenNuevoPuestoDA:BaseDA
    {

        #region Constantes
        const string CONST_CHU_DNP_OBTENER = "CHU_DictamenNuevoP_Obtener";
        const string CONST_CHU_DNP_GUARDAR = "CHU_DictamenNuevoP_Guarda";
        const string CONST_CHU_DNP_ACTUALIZAR = "CHU_DictamenNuevoP_Actualiza";
        #endregion


        public List<DictamenNuevoPuestoBE> CHU_DictamenNuevoP_Obtener()
        {
            List<DictamenNuevoPuestoBE> oList = new List<DictamenNuevoPuestoBE>();
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_CHU_DNP_OBTENER, conn)) {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                DictamenNuevoPuestoBE obj = new DictamenNuevoPuestoBE();

                                obj.Id = int.Parse(reader["DNP_Id"].ToString());
                                obj.NuevoPuesto.Id = int.Parse(reader["NVP_Id"].ToString());
                                obj.NuevoPuesto.Nombre = (reader["NVP_Nombre"].ToString());
                                obj.Entidades.Nombre = (reader["ENT_Nombre"].ToString());
                                obj.Departamentos.Nombre = reader["DEP_Nombre"].ToString();
                                obj.OpinionesCH = (reader["DNP_OpinionesCH"].ToString());
                                obj.OpinionesDG = (reader["DNP_OpinionesDG"].ToString());
                                obj.NuevoPuesto.Resultados = (reader["NVP_Resultados"].ToString());
                                obj.NuevoPuesto.Objetivos = (reader["NVP_Objetivos"].ToString());
                                obj.NuevoPuesto.Necesidades = (reader["NVP_Necesidades"].ToString());
                                obj.NuevoPuesto.Prestaciones = (reader["NVP_Prestaciones"].ToString());
                                obj.NuevoPuesto.Ocupantes = int.Parse(reader["NVP_Ocupantes"].ToString());
                                obj.DatosUsuario.Estatus = bool.Parse(reader["DNP_Estatus"].ToString());
                                obj.Autorizado = bool.Parse(reader["DNP_Autorizado"].ToString());
                                obj.NoAutorizado = !obj.Autorizado;
                                obj.NuevoPuesto.PuestosCargo = (reader["NVP_PuestosCargo"].ToString());
                                obj.NuevoPuesto.Sueldo = decimal.Parse(reader["NVP_Sueldo"].ToString());
                                obj.NuevoPuesto.Justificacion = (reader["NVP_Justificacion"].ToString());
                                obj.NuevoPuesto.Indicadores = (reader["NVP_Indicadores"].ToString());
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


        public int CHU_DictamenNuevoP_Guardar(DictamenNuevoPuestoBE obj)
        {
            int Result = 0;
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_CHU_DNP_GUARDAR, conn)) {

                        cmd.Parameters.AddWithValue("@Id_NVP", obj.NuevoPuesto.Id);
                        cmd.Parameters.AddWithValue("@OpinionesCH", obj.OpinionesCH);
                        cmd.Parameters.AddWithValue("@OpinionesDG", obj.OpinionesDG);
                        cmd.Parameters.AddWithValue("@Autorizado", obj.Autorizado);
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

        public int CHU_DictamenNuevoP_Actualizar(DictamenNuevoPuestoBE obj)
        {
            int Result = 0;
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_CHU_DNP_ACTUALIZAR, conn)) {
                        cmd.Parameters.AddWithValue("@Id", obj.Id);
                        cmd.Parameters.AddWithValue("@Id_NVP", obj.NuevoPuesto.Id);
                        cmd.Parameters.AddWithValue("@OpinionesCH", obj.OpinionesCH);
                        cmd.Parameters.AddWithValue("@OpinionesDG", obj.OpinionesDG);
                        cmd.Parameters.AddWithValue("@Autorizado", obj.Autorizado);
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
    }
}
