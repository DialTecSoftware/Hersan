﻿using Hersan.Entidades.CapitalHumano;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hersan.Datos.Catalogos
{
    public class FuncionesDA:BaseDA
    {
        #region Constantes
        const string CONST_USP_ABC_FUNCIONES_OBTENER = "ABC_Funciones_Obtener";
        const string CONST_ABC_FUNCIONES_GUARDAR = "ABC_Funciones_Guarda";
        const string CONST_ABC_FUNCIONES_ACTUALIZAR = "ABC_Funciones_Actualiza";
        #endregion

        public List<FuncionesBE> ABCFunciones_Obtener()
        {
            List<FuncionesBE> oList = new List<FuncionesBE>();
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_USP_ABC_FUNCIONES_OBTENER, conn)) {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                FuncionesBE obj = new FuncionesBE();

                                obj.Id = int.Parse(reader["FUN_Id"].ToString());
                                obj.Nombre = reader["FUN_Nombre"].ToString();
                                obj.Continua = bool.Parse(reader["FUN_Continua"].ToString());
                                obj.DatosUsuario.Estatus = bool.Parse(reader["FUN_Estatus"].ToString());

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