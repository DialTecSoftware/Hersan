using Hersan.Entidades.Catalogos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hersan.Datos.Ventas
{
    public class FacturacionDA : BaseDA
    {
        #region Constantes
        const string CONS_ABC_FORMAPAGO_COMBO = "ABC_FormaPago_Combo";
        const string CONS_ABC_METODOPAGO_COMBO = "ABC_MetodoPago_Combo";
        const string CONS_ABC_USOCFDI_COMBO = "ABC_UsoCFDI_Combo";
        #endregion


        public List<FormasPagoBE> ABC_FormaPago_Combo()
        {
            List<FormasPagoBE> oList = new List<FormasPagoBE>();
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONS_ABC_FORMAPAGO_COMBO, conn)) {

                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                FormasPagoBE obj = new FormasPagoBE();

                                obj.Id = int.Parse(reader["FPA_Id"].ToString());
                                obj.Descripcion = reader["FPA_Descripcion"].ToString();

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
        public List<MetodosPagoBE> ABC_MetodoPago_Combo()
        {
            List<MetodosPagoBE> oList = new List<MetodosPagoBE>();
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONS_ABC_METODOPAGO_COMBO, conn)) {

                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                MetodosPagoBE obj = new MetodosPagoBE();

                                obj.Clave = reader["MPA_Clave"].ToString();
                                obj.Descripcion = reader["MPA_Descripcion"].ToString();

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
        public List<UsoCFDIBE> ABC_UsoCFDI_Combo()
        {
            List<UsoCFDIBE> oList = new List<UsoCFDIBE>();
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONS_ABC_USOCFDI_COMBO, conn)) {

                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                UsoCFDIBE obj = new UsoCFDIBE();

                                obj.Clave = reader["UCF_Clave"].ToString();
                                obj.Descripcion = reader["UCF_Descripcion"].ToString();

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
