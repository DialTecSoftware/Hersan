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
   public  class ContratosDA:BaseDA
    {
        #region Constantes
        const string CONST_USP_ABC_CONTRATOS_OBTENER = "ABC_Contratos_Obtener";
        const string CONST_ABC_CONTRATOS_GUARDAR = "ABC_Contratos_Guarda";
        const string CONST_ABC_CONTRATOS_ACTUALIZAR = "ABC_Contratos_Actualiza";
        #endregion


        public List<ContratosBE> ABCContratos_Obtener()
        {
            List<ContratosBE> oList = new List<ContratosBE>();
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_USP_ABC_CONTRATOS_OBTENER, conn)) {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                ContratosBE obj = new ContratosBE();

                                obj.Id = int.Parse(reader["CON_Id"].ToString());
                                obj.Nombre = reader["CON_Nombre"].ToString();
                                obj.DatosUsuario.Estatus = bool.Parse(reader["CON_Estatus"].ToString());
                                obj.TiposContrato.Id = int.Parse(reader["TCO_Id"].ToString());
                                obj.TiposContrato.Nombre = reader["TCO_Nombre"].ToString();
                                obj.Departamentos.Id = int.Parse(reader["DEP_Id"].ToString());
                                obj.Departamentos.Nombre = reader["DEP_Nombre"].ToString();

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

        public int ABCContratos_Guardar(ContratosBE obj)
        {
            int Result = 0;
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_ABC_CONTRATOS_GUARDAR, conn)) {
                        cmd.Parameters.AddWithValue("@Id_TCO", obj.TiposContrato.Id);
                        cmd.Parameters.AddWithValue("@Id_Dep", obj.Departamentos.Id);
                        cmd.Parameters.AddWithValue("@Nombre", obj.Nombre);
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

        public int ABCContratos_Actualizar(ContratosBE obj)
        {
            int Result = 0;
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_ABC_CONTRATOS_ACTUALIZAR, conn)) {
                        cmd.Parameters.AddWithValue("@Id", obj.Id);
                        cmd.Parameters.AddWithValue("@Id_TCO", obj.TiposContrato.Id);
                        cmd.Parameters.AddWithValue("@Id_Dep", obj.Departamentos.Id);
                        cmd.Parameters.AddWithValue("@Nombre", obj.Nombre);
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
    }
}

    
