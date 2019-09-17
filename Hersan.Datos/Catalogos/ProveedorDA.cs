using Hersan.Entidades.Catalogos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hersan.Datos.Catalogos {
    public class ProveedorDA : BaseDA
    {
        #region Constantes
        const string CONS_ABC_PROVEEDORES_OBTENER = "ABC_Proveedores_Obtener";
        const string CONS_ABC_PROVEEDORES_GUARDAR = "ABC_Proveedores_Guardar";
        const string CONS_ABC_PROVEEDORES_ACTUALIZAR = "ABC_Proveedores_Actualizar";
        #endregion

        public int ABC_Proveedores_Guardar(ProveedorBE obj)
        {
            int Result = 0;
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONS_ABC_PROVEEDORES_GUARDAR, conn)) {
                        cmd.Parameters.AddWithValue("@IdEmpresa", obj.Empresa.Id);
                        cmd.Parameters.AddWithValue("@Nombre", obj.Nombre);
                        cmd.Parameters.AddWithValue("@Fiscal", obj.Fiscal);
                        cmd.Parameters.AddWithValue("@Direccion", obj.Direccion);
                        cmd.Parameters.AddWithValue("@IdEstado", obj.Estado.Id);
                        cmd.Parameters.AddWithValue("@IdCiudad", obj.Ciudad.Id);
                        cmd.Parameters.AddWithValue("@IdColonia", obj.Colonia.Id);
                        cmd.Parameters.AddWithValue("@RFC", obj.RFC);
                        cmd.Parameters.AddWithValue("@Telefono", obj.Telefono);
                        cmd.Parameters.AddWithValue("@Correo", obj.Correo);
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
        public int ABC_Proveedores_Actualizar(ProveedorBE obj)
        {
            int Result = 0;
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONS_ABC_PROVEEDORES_ACTUALIZAR, conn)) {
                        cmd.Parameters.AddWithValue("@Id", obj.Id);
                        cmd.Parameters.AddWithValue("@Nombre", obj.Nombre);
                        cmd.Parameters.AddWithValue("@Direccion", obj.Direccion);
                        cmd.Parameters.AddWithValue("@IdEstado", obj.Estado.Id);
                        cmd.Parameters.AddWithValue("@IdCiudad", obj.Ciudad.Id);
                        cmd.Parameters.AddWithValue("@IdColonia", obj.Colonia.Id);
                        cmd.Parameters.AddWithValue("@Telefono", obj.Telefono);
                        cmd.Parameters.AddWithValue("@Correo", obj.Correo);
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
        public List<ProveedorBE> ABC_Proveedores_Obtener(int IdEmpresa)
        {
            List<ProveedorBE> oList = new List<ProveedorBE>();
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONS_ABC_PROVEEDORES_OBTENER, conn)) {
                        cmd.Parameters.AddWithValue("@IdEmpresa", IdEmpresa);

                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                ProveedorBE obj = new ProveedorBE();

                                obj.Id = int.Parse(reader["PRO_Id"].ToString());
                                obj.Nombre = reader["PRO_NombreCorto"].ToString();
                                obj.Fiscal = reader["PRO_NombreFiscal"].ToString();
                                obj.Direccion = reader["PRO_Direccion"].ToString();
                                obj.Estado.Id = int.Parse(reader["EST_Id"].ToString());
                                obj.Estado.Nombre = reader["EST_Nombre"].ToString();
                                obj.Ciudad.Id = int.Parse(reader["CIU_Id"].ToString());
                                obj.Ciudad.Nombre = reader["CIU_Nombre"].ToString();
                                obj.Colonia.Id = int.Parse(reader["COL_Id"].ToString());
                                obj.Colonia.Nombre = reader["COL_Nombre"].ToString();
                                obj.Colonia.CP = int.Parse(reader["COL_CP"].ToString());
                                obj.RFC= reader["PRO_RFC"].ToString();
                                obj.Telefono= reader["PRO_Telefono"].ToString();
                                obj.Correo = reader["PRO_Correo"].ToString();
                                obj.DatosUsuario.Estatus = bool.Parse(reader["PRO_Estatus"].ToString());

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
