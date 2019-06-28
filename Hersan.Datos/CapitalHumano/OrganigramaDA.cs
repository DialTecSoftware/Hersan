using Hersan.Entidades.Catalogos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Hersan.Datos.Catalogos
{
    public class OrganigramaDA: BaseDA
    {

        const string CONST_USP_CHU_ORGANIG_OBTENER = "CHU_Organigrama_GET";
        const string CONST_USP_CHU_ORGANIG_GUARDA = "CHU_Organigrama_Guarda";
        const string CONST_USP_CHU_ORGANIG_ACTUALIZA = "CHU_Organigrama_Actualiza";
        const string CONST_USP_CHU_ORGANIG_xmlOBTENER = "CHU_Organigrama_Obtener";


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
                                obj.Id = int.Parse(reader["ORG_Id"].ToString());
                                obj.NombreJefe = (reader["JefeInmediato"].ToString());
                                obj.IdJefe = int.Parse(reader["PUE_Idjefe"].ToString());
                                obj.Entidades.Nombre = (reader["ENT_Nombre"].ToString());
                                obj.Departamentos.Nombre = reader["DEP_Nombre"].ToString();
                                obj.Puestos.Nombre = reader["PUE_Nombre"].ToString();                              
                                obj.Entidades.Id = int.Parse(reader["ENT_Id"].ToString());
                                obj.Departamentos.Id = int.Parse(reader["DEP_Id"].ToString());
                                obj.Puestos.Id = int.Parse(reader["PUE_Id"].ToString());
                                obj.Nivel = int.Parse(reader["ORG_Nivel"].ToString());
                                obj.DatosUsuario.Estatus = bool.Parse(reader["ORG_Estatus"].ToString());

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
                        cmd.Parameters.AddWithValue("@Id_ENT", obj.Entidades.Id);
                        cmd.Parameters.AddWithValue("@Id_DEP", obj.Departamentos.Id);
                        cmd.Parameters.AddWithValue("@Id_PUE", obj.Puestos.Id);
                        cmd.Parameters.AddWithValue("@Id_Jefe", obj.IdJefe);
                        cmd.Parameters.AddWithValue("@Nivel", obj.Nivel);
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
        public int CHUOrganigrama_Actualizar(OrganigramaBE obj)
        {
            int Result = 0;
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_USP_CHU_ORGANIG_ACTUALIZA, conn)) {
                        cmd.Parameters.AddWithValue("@Id", obj.Id);
                        cmd.Parameters.AddWithValue("@Id_ENT", obj.Entidades.Id);
                        cmd.Parameters.AddWithValue("@Id_DEP", obj.Departamentos.Id);
                        cmd.Parameters.AddWithValue("@Id_PUE", obj.Puestos.Id);
                        cmd.Parameters.AddWithValue("@Id_Jefe", obj.IdJefe);
                        cmd.Parameters.AddWithValue("@Nivel", obj.Nivel);
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

        public DataSet CHU_OrganigramaXML_Obtener(int parent)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable oData = new DataTable("Element");
            DataSet dts = new DataSet();
            var doc = new XmlDocument();
         
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_USP_CHU_ORGANIG_xmlOBTENER, conn)) {
                      
                        cmd.Parameters.AddWithValue("@PARENT", parent);
                        cmd.CommandType = CommandType.StoredProcedure;
                        da = new SqlDataAdapter(cmd);
                       
                        da.Fill(oData);
                      
                        oData.WriteXml(@"C:\Temp\Organizacion.xml",true);
                        
                        var reader = cmd.ExecuteXmlReader();
                        if (reader.Read()) {
                           

                            doc.Load(reader);
                            doc.Save(@"C:\Temp\Hersan.xml");
                            conn.Close();
                          
                        }
                                                                                      
                    }

                }

                return dts;
            } catch (Exception ex) {

                throw ex;
            }
        }
    }
}
