using Hersan.Entidades.APT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hersan.Datos.APT
{
    public class AlmacenDA: BaseDA
    {
        #region Constantes
        const string CONS_USP_APT_ALMACENES_GUARDAR = "APT_Almacenes_Guardar";
        const string CONS_USP_APT_ALMACENES_ACTUALIZAR = "APT_Almacenes_Actualizar";
        const string CONS_USP_APT_ALMACENES_OBTENER = "APT_Almacenes_Obtener";
        const string CONS_USP_APT_ALMACENES_COMBO = "APT_Almacenes_Combo";
        #endregion


        public List<AlmacenPTBE> APT_Almacenes_Obtener(int IdEmpresa)
        {
            List<AlmacenPTBE> oList = new List<AlmacenPTBE>();
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONS_USP_APT_ALMACENES_OBTENER, conn)) {
                        cmd.Parameters.AddWithValue("@IdEmp", IdEmpresa);

                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                AlmacenPTBE obj = new AlmacenPTBE();

                                obj.Id = int.Parse(reader["APT_Id"].ToString());
                                obj.Empresa.Id = int.Parse(reader["EMP_Id"].ToString());
                                obj.Nombre = reader["APT_Nombre"].ToString();
                                obj.Abrev = reader["APT_Abrev"].ToString();
                                obj.DatosUsuario.Estatus = bool.Parse(reader["APT_Estatus"].ToString());

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
        public int APT_Almacenes_Guardar(AlmacenPTBE obj)
        {
            int Result = 0;
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONS_USP_APT_ALMACENES_GUARDAR, conn)) {
                        cmd.Parameters.AddWithValue("@IdEmp", obj.Empresa.Id);
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
        public int APT_Almacenes_Actualizar(AlmacenPTBE obj)
        {
            int Result = 0;
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONS_USP_APT_ALMACENES_ACTUALIZAR, conn)) {
                        cmd.Parameters.AddWithValue("@Id", obj.Id);
                        cmd.Parameters.AddWithValue("@IdEmp", obj.Empresa.Id);
                        cmd.Parameters.AddWithValue("@Nombre", obj.Nombre);
                        cmd.Parameters.AddWithValue("@Abrev", obj.Abrev);
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
        public List<AlmacenPTBE> APT_Almacenes_Combo(int IdEmpresa)
        {
            List<AlmacenPTBE> oList = new List<AlmacenPTBE>();
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONS_USP_APT_ALMACENES_COMBO, conn)) {
                        cmd.Parameters.AddWithValue("@IdEmp", IdEmpresa);

                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                AlmacenPTBE obj = new AlmacenPTBE();

                                obj.Id = int.Parse(reader["APT_Id"].ToString());
                                obj.Nombre = reader["APT_Nombre"].ToString();

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
