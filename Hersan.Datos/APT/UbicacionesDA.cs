using Hersan.Entidades.APT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hersan.Datos.APT {
    public class UbicacionesDA : BaseDA
    {
        #region Constantes
        const string CONS_APT_UBICACION_GUARDAR = "APT_Ubicacion_Guardar";
        const string CONS_APT_UBICACION_ACTUALIZAR = "APT_Ubicacion_Actualizar";
        const string CONS_APT_UBICACION_OBTENER = "APT_Ubicacion_Obtener";
        const string CONS_APT_UBICACION_COMBO = "APT_Ubicacion_Combo";
        #endregion

        public List<UbicacionesBE> APT_Ubicacion_Obtener()
        {
            List<UbicacionesBE> oList = new List<UbicacionesBE>();
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONS_APT_UBICACION_OBTENER, conn)) {

                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                UbicacionesBE obj = new UbicacionesBE();

                                obj.Id = int.Parse(reader["UBI_Id"].ToString());
                                obj.Almacen.Id = int.Parse(reader["APT_Id"].ToString());
                                obj.Almacen.Nombre = reader["APT_Nombre"].ToString();
                                obj.Producto.Codigo = reader["Codigo"].ToString();
                                obj.Producto.Producto.Id = int.Parse(reader["TPR_Id"].ToString());
                                obj.Producto.Producto.Nombre = reader["Producto"].ToString();
                                obj.Carcasa.Id = int.Parse(reader["IdCarcasa"].ToString());
                                obj.Carcasa.Nombre = reader["Carcasa"].ToString();
                                obj.Reflejante.Tipo = reader["COM_Tipo"].ToString();
                                obj.Reflejante.Nombre = reader["Reflejante"].ToString();
                                obj.Reflejante.Clave = reader["IdComp"].ToString();
                                obj.Rack = reader["UBI_Rack"].ToString();
                                obj.Fila = int.Parse(reader["UBI_Fila"].ToString());
                                obj.Columna = int.Parse(reader["UBI_Columna"].ToString());
                                obj.Minimo = decimal.Parse(reader["UBI_Mínimo"].ToString());
                                obj.Maximo = decimal.Parse(reader["UBI_Maximo"].ToString());
                                obj.DatosUsuario.Estatus = bool.Parse(reader["UBI_Estatus"].ToString());
                                

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
        public int APT_Ubicacion_Guardar(UbicacionesBE obj)
        {
            int Result = 0;
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONS_APT_UBICACION_GUARDAR, conn)) {
                        cmd.Parameters.AddWithValue("@IdEmpresa", obj.Almacen.Empresa.Id);
                        cmd.Parameters.AddWithValue("@IdAlmacen", obj.Almacen.Id);
                        cmd.Parameters.AddWithValue("@IdProducto", obj.Producto.Id);
                        cmd.Parameters.AddWithValue("@IdColor", obj.Carcasa.Id);
                        cmd.Parameters.AddWithValue("@IdReflex", obj.Reflejante.Nombre);
                        cmd.Parameters.AddWithValue("@Rack", obj.Rack);
                        cmd.Parameters.AddWithValue("@Fila", obj.Fila);
                        cmd.Parameters.AddWithValue("@Columna", obj.Columna);
                        cmd.Parameters.AddWithValue("@Minimo", obj.Minimo);
                        cmd.Parameters.AddWithValue("@Maximo", obj.Maximo);
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
        public int APT_Ubicacion_Actualizar(UbicacionesBE obj)
        {
            int Result = 0;
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONS_APT_UBICACION_ACTUALIZAR, conn)) {
                        cmd.Parameters.AddWithValue("@Id", obj.Id);
                        cmd.Parameters.AddWithValue("@Rack", obj.Rack);
                        cmd.Parameters.AddWithValue("@Fila", obj.Fila);
                        cmd.Parameters.AddWithValue("@Columna", obj.Columna);
                        cmd.Parameters.AddWithValue("@Minimo", obj.Minimo);
                        cmd.Parameters.AddWithValue("@Maximo", obj.Maximo);
                        cmd.Parameters.AddWithValue("@IdUsuario", obj.DatosUsuario.IdUsuarioModif);
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
