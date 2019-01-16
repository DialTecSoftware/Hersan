﻿using Hersan.Entidades.Catalogos;
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
        #endregion

        /// <summary>
        /// Obtiene el listado de Empresas
        /// </summary>
        /// <returns></returns>
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
                                obj.RegimenFiscal = reader["EMP_RegimenFiscal"].ToString();
                                obj.NoExterior = reader["EMP_NoExterior"].ToString();
                                obj.NoInterior = reader["EMP_NoInterior"].ToString();
                                obj.Estado.Id = int.Parse(reader["EST_ID"].ToString());
                                obj.Estado.Nombre = reader["EST_Nombre"].ToString();

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

        /// <summary>
        /// Obtiene el listado de Empresas Para Combo
        /// </summary>
        /// <returns></returns>
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
                                oList.Add(new EmpresasBE {
                                    Id = int.Parse(reader["EMP_ID"].ToString()),
                                    NombreComercial = reader["EMP_NombreComercial"].ToString(),
                                });
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