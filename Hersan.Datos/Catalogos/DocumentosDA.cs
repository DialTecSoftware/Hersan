﻿using Hersan.Entidades.Catalogos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hersan.Datos.Catalogos
{
    public class DocumentosDA: BaseDA
    {

        #region Constantes
        const string CONST_USP_ABC_DOC_OBTENER = "ABC_Documentos_Obtener";
        const string CONST_ABC_DOC_GUARDAR = "ABC_Documentos_Guarda";
        const string CONST_ABC_DOC_ACTUALIZAR = "ABC_Documentos_Actualiza";
        const string CONST_ABC_DOC_COMBO = "ABC_Documentos_Combo";
        #endregion

        public List<DocumentosBE> ABCDocumentos_Obtener()
        {
            List<DocumentosBE> oList = new List<DocumentosBE>();
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_USP_ABC_DOC_OBTENER, conn)) {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                DocumentosBE obj = new DocumentosBE();

                                obj.Id = int.Parse(reader["DOC_Id"].ToString());
                                obj.Nombre = reader["DOC_Nombre"].ToString();
                                obj.Abrev =(reader["DOC_Abrev"].ToString());
                                obj.DatosUsuario.Estatus = bool.Parse(reader["DOC_Estatus"].ToString());

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

        public int ABCDocumentos_Guardar(DocumentosBE obj)
        {
            int Result = 0;
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_ABC_DOC_GUARDAR, conn)) {
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

        public int ABCDocumentos_Actualizar(DocumentosBE obj)
        {
            int Result = 0;
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_ABC_DOC_ACTUALIZAR, conn)) {
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

        public List<DocumentosBE> ABCDocumentos_Combo()
        {
            List<DocumentosBE> oList = new List<DocumentosBE>();
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_ABC_DOC_COMBO, conn)) {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                DocumentosBE obj = new DocumentosBE();

                                obj.Id = int.Parse(reader["DOC_ID"].ToString());
                                obj.Nombre = reader["DOC_Nombre"].ToString();

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
