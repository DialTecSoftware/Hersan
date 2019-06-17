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
    public class TipoProductoDA : BaseDA
    {

        #region Constantes
        const string CONS_USP_ENS_TIPOPRODUCTO_GUARDAR = "ENS_TipoProducto_Guardar";
        const string CONS_USP_ENS_TIPOPRODUCTO_ACTUALIZAR = "ENS_TipoProducto_Actualizar";
        const string CONS_USP_ENS_TIPOPRODUCTO_OBTENER = "ENS_TipoProducto_Obtener";
        const string CONS_USP_ENS_TIPOPRODUCTO_COMBO = "ENS_TipoProducto_Combo";
        #endregion

        public int ENS_TipoProducto_Guardar(TipoProductoBE obj)
        {
            int Result = 0;
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONS_USP_ENS_TIPOPRODUCTO_GUARDAR, conn)) {
                        cmd.Parameters.AddWithValue("@IdFamilia", obj.Familia.Id);
                        cmd.Parameters.AddWithValue("@Clave", obj.Clave);
                        cmd.Parameters.AddWithValue("@Nombre", obj.Nombre);
                        cmd.Parameters.AddWithValue("@Name", obj.Name);
                        cmd.Parameters.AddWithValue("@Fraccion", obj.Fraccion);
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
        public int ENS_TipoProducto_Actualizar(TipoProductoBE obj)
        {
            int Result = 0;
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONS_USP_ENS_TIPOPRODUCTO_ACTUALIZAR, conn)) {
                        cmd.Parameters.AddWithValue("@Id", obj.Id);
                        cmd.Parameters.AddWithValue("@IdFamilia", obj.Familia.Id);
                        cmd.Parameters.AddWithValue("@Clave", obj.Clave);
                        cmd.Parameters.AddWithValue("@Nombre", obj.Nombre);
                        cmd.Parameters.AddWithValue("@Name", obj.Name);
                        cmd.Parameters.AddWithValue("@Fraccion", obj.Fraccion);
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
        public List<TipoProductoBE> ENS_TipoProducto_Obtener()
        {
            List<TipoProductoBE> oList = new List<TipoProductoBE>();
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONS_USP_ENS_TIPOPRODUCTO_OBTENER, conn)) {

                        cmd.CommandType = CommandType.StoredProcedure;

                        /*SE OBTIENEN LOS REFLEJANTES */
                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                TipoProductoBE obj = new TipoProductoBE();

                                obj.Id = int.Parse(reader["TPR_Id"].ToString());
                                obj.Familia.Id = int.Parse(reader["FAM_Id"].ToString());
                                obj.Familia.Clave = reader["FAM_Clave"].ToString();
                                obj.Familia.Nombre = reader["FAM_Nombre"].ToString();
                                obj.Familia.Entidad.Id = int.Parse(reader["ENT_Id"].ToString());
                                obj.Familia.Entidad.Nombre = reader["ENT_Nombre"].ToString();
                                obj.Clave = reader["TPR_Clave"].ToString();
                                obj.Nombre = reader["TPR_Nombre"].ToString();
                                obj.Name = reader["TPR_Name"].ToString();
                                obj.Fraccion = reader["TPR_Fraccion"].ToString();
                                obj.DatosUsuario.Estatus = bool.Parse(reader["TPR_Estatus"].ToString());

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
        public List<TipoProductoBE> ENS_TipoProducto_Combo(int IdFamilia)
        {
            List<TipoProductoBE> oList = new List<TipoProductoBE>();
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONS_USP_ENS_TIPOPRODUCTO_COMBO, conn)) {
                        cmd.Parameters.AddWithValue("@IdFamilia", IdFamilia);

                        cmd.CommandType = CommandType.StoredProcedure;

                        /*SE OBTIENEN LOS REFLEJANTES */
                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                TipoProductoBE obj = new TipoProductoBE();

                                obj.Id = int.Parse(reader["TPR_Id"].ToString());
                                obj.Clave = reader["TPR_Clave"].ToString();
                                obj.Nombre = reader["TPR_Nombre"].ToString();

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
