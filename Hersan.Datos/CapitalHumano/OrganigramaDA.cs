using Hersan.Entidades.Catalogos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml;

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

        public DataTable CHU_OrganigramaXML_Obtener(int parent)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable oData = new DataTable("Element");
            DataSet dts = new DataSet();

            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_USP_CHU_ORGANIG_xmlOBTENER, conn)) {
                      
                        cmd.Parameters.AddWithValue("@PARENT", parent);
                        cmd.CommandType = CommandType.StoredProcedure;
                        da = new SqlDataAdapter(cmd);
                       
                        da.Fill(oData);
                      
                        oData.WriteXml(@"C:\Temp\Organizacion.xml",true);
                        //oData.WriteXmlSchema(@"C:\Temp\Organizacion.xml", false);

                        XmlDocument doc = new XmlDocument();
                        string filename = @"C:\Temp\Organizaciones.xml";
                        doc.Load(@"C:\Temp\Organizacion.xml");
                        XmlWriterSettings settings = new XmlWriterSettings {
                            Indent = true,
                            IndentChars = @"    ",
                            NewLineChars = Environment.NewLine,
                            NewLineHandling = NewLineHandling.Replace,
                            OmitXmlDeclaration = true,
                            //HttpUtility.

                        }; ;
                      
                        using (var writers = XmlWriter.Create(filename, settings)) {
                           

                            doc.Save(writers);
                        }



                        ////// Save the document to a file and auto-indent the output.

                        //XmlDocument doc2 = new XmlDocument();
                        //StringBuilder output = new StringBuilder();
                        //XmlNode newBook = doc2.ImportNode(doc.DocumentElement.LastChild, true);
                        //XmlWriter writer = XmlWriter.Create(filename, settings);
                        //doc2.DocumentElement.AppendChild(newBook);

                        //doc.Save(writer);
                        ////writer.Close();



                    }
                   
                }
                return oData;
            } catch (Exception) {

                throw;
            }
        }
    }
}
