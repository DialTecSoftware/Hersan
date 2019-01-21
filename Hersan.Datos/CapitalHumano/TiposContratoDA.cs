
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
  public class TiposContratoDA : BaseDA
    {
        #region Constantes
        const string CONST_USP_ABC_TIPOSCONTRATO_OBTENER = "ABC_TiposContrato_Obtener";
        const string CONST_ABC_TIPOSCONTRATO_GUARDAR = "ABC_TiposContrato_Guarda";
        const string CONST_ABC_TIPOSCONTRATO_ACTUALIZAR = "ABC_TiposContrato_Actualiza";
        const string CONST_ABC_TIPOSCONTRATO_COMBO = "ABC_TiposContrato_Combo";
        #endregion

        public List<TiposContratoBE> TiposContrato_Obtener()
        {
            List<TiposContratoBE> oList = new List<TiposContratoBE>();
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_USP_ABC_TIPOSCONTRATO_OBTENER, conn)) {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                TiposContratoBE obj = new TiposContratoBE();

                                obj.Id = int.Parse(reader["TCO_ID"].ToString());
                                obj.Nombre = reader["TCO_Nombre"].ToString();
                                obj.Abrev = reader["TCO_Abrev"].ToString();
                                obj.DatosUsuario.Estatus = bool.Parse(reader["TCO_Estatus"].ToString());

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

        public int ABCTiposContrato_Guardar(TiposContratoBE obj)
        {
            int Result = 0;
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_ABC_TIPOSCONTRATO_GUARDAR , conn)) {
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


        public int ABCTiposContrato_Actualizar(TiposContratoBE obj)
        {
            int Result = 0;
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_ABC_TIPOSCONTRATO_ACTUALIZAR, conn)) {
                        cmd.Parameters.AddWithValue("@Id", obj.Id);
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

        public List<TiposContratoBE> ABCTiposcontrato_Combo()
        {
            List<TiposContratoBE> oList = new List<TiposContratoBE>();
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_ABC_TIPOSCONTRATO_COMBO, conn)) {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                TiposContratoBE obj = new TiposContratoBE();

                                obj.Id = int.Parse(reader["TCO_ID"].ToString());
                                obj.Nombre = reader["TCO_Nombre"].ToString();

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
    }
}

