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
    public class OrganigramaDA: BaseDA
    {

        const string CONST_USP_CHU_ORGANIG_OBTENER = "CHU_Organigrama_GET";
        const string CONST_USP_CHU_ORGANIG_GUARDA = "CHU_Organigrama_Guardar";
        const string CONST_USP_CHU_ORGANIG_ACTUALIZA = "CHU_Organigrama_Actualiza";


        public List<OrganigramaBE> CHUOrganigrama_Obtener()
        {
            List<OrganigramaBE> oList = new List<OrganigramaBE>();
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_USP_CHU_ORGANIG_OBTENER, conn)) {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                OrganigramaBE obj = new OrganigramaBE();
                                obj.Nombre =reader["PUE_Nombre"].ToString();
                                obj.Padre = reader["Padre"].ToString();
                                obj.Nivel = int.Parse(reader["ORG_Nivel"].ToString());
                                obj.Id_padre = int.Parse(reader["IdPuesto"].ToString());
                                obj.Id_puesto = int.Parse(reader["Idpadre"].ToString());
                            
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
        public int CHUOrganigrama_Guardar(OrganigramaBE obj)
        {
            int Result = 0;
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_USP_CHU_ORGANIG_GUARDA, conn)) {
                        cmd.Parameters.AddWithValue("@Nivel", obj.Nivel);
                        cmd.Parameters.AddWithValue("@IdPuesto", obj.Id_puesto);
                        cmd.Parameters.AddWithValue("@IdPadre", obj.Id_padre);
                       

                        cmd.CommandType = CommandType.StoredProcedure;
                        Result = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
                return Result;
            } catch (Exception ex) {
                throw ex;
            }
        }
        public int CHUOrganigrama_Actualizar(OrganigramaBE obj)
        {
            int Result = 0;
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_USP_CHU_ORGANIG_ACTUALIZA, conn)) {
                        cmd.Parameters.AddWithValue("@Nivel", obj.Nivel);
                        cmd.Parameters.AddWithValue("@IdPuesto", obj.Id_puesto);
                        cmd.Parameters.AddWithValue("@IdPadre", obj.Id_padre);

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
