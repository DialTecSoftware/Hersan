using Hersan.Entidades.Catalogos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Hersan.Datos.Catalogos {
    public class EmpresasDA : BaseDA
    {
        #region Constantes
        const string CONST_ABC_EMPRESAS_OBTENER = "ABC_Empresas_Obtener";
        const string CONST_ABC_EMPRESAS_COMBO = "ABC_Empresas_Combo";
        const string CONST_ABC_EMPRESAS_GUARDA = "ABC_Empresas_Guarda";
        #endregion


        public List<EmpresasBE> ABCEmpresas_Obtener(int IdEmpresa)
        {
            try {
                List<EmpresasBE> oList = new List<EmpresasBE>();

                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_ABC_EMPRESAS_OBTENER, conn)) {
                        cmd.Parameters.AddWithValue("@IdEmpresa", IdEmpresa);

                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                EmpresasBE obj = new EmpresasBE();

                                obj.Id = int.Parse(reader["EMP_ID"].ToString());
                                obj.NombreComercial = reader["EMP_NombreComercial"].ToString();
                                obj.NombreFiscal = reader["EMP_NombreFiscal"].ToString();
                                obj.Direccion = reader["EMP_Direccion"].ToString();
                                obj.RFC = reader["EMP_RFC"].ToString();
                                obj.Telefonos = reader["EMP_Telefonos"].ToString();
                                obj.Correo = reader["EMP_CorreoElectronico"].ToString();
                                obj.Contacto = reader["EMP_Contacto"].ToString();
                                obj.RegimenFiscal.Id = int.Parse(reader["REF_Id"].ToString());
                                obj.RegimenFiscal.Regimen = reader["RegimenFiscal"].ToString();
                                obj.NoExterior = reader["EMP_NoExterior"].ToString();
                                obj.NoInterior = reader["EMP_NoInterior"].ToString();
                                obj.Pais.Id = int.Parse(reader["PAI_ID"].ToString());
                                obj.Pais.Nombre = reader["PAI_Nombre"].ToString();
                                obj.Estado.Id = int.Parse(reader["EST_ID"].ToString());
                                obj.Estado.Nombre = reader["EST_Nombre"].ToString();
                                obj.Ciudad.Id = int.Parse(reader["CIU_ID"].ToString());
                                obj.Ciudad.Nombre = reader["CIU_Nombre"].ToString();
                                obj.Colonia.Id = int.Parse(reader["COL_ID"].ToString());
                                obj.Colonia.Nombre = reader["COL_Nombre"].ToString();
                                obj.Colonia.CP = int.Parse(reader["COL_CP"].ToString());


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
        public List<EmpresasBE> ABCEmpresas_Cbo()
        {
            try {
                List<EmpresasBE> oList = new List<EmpresasBE>();

                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_ABC_EMPRESAS_COMBO, conn)) {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                EmpresasBE obj = new EmpresasBE();

                                obj.Id = int.Parse(reader["EMP_ID"].ToString());
                                    obj.NombreComercial = reader["EMP_NombreComercial"].ToString();
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
        public int ABC_Empresas_Guarda(DataTable Empresa, int IdUsuario)
        {
            try {
                int Result = 0;

                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_ABC_EMPRESAS_GUARDA, conn)) {
                        cmd.Parameters.AddWithValue("@Empresa", Empresa);
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
