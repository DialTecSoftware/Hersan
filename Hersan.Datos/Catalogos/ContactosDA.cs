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
    public class ContactosDA: BaseDA
    {

        #region Constantes
        const string CONST_USP_ABC_CONCTACTOS_OBTENER = "ABC_Contactos_Obtener";
        const string CONST_ABC_CONTACTOS_GUARDAR = "ABC_Contactos_Guarda";
        const string CONST_ABC_CONTACTOS_ACTUALIZAR = "ABC_Contactos_Actualiza";
        #endregion

        public List<ContactosBE> ABCContactos_Obtener()
        {
            List<ContactosBE> oList = new List<ContactosBE>();
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_USP_ABC_CONCTACTOS_OBTENER, conn)) {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                ContactosBE obj = new ContactosBE();

                                obj.Id = int.Parse(reader["CON_Id"].ToString());
                                obj.Nombre = reader["CON_Nombre"].ToString();
                                obj.Interno = bool.Parse(reader["CON_Interno"].ToString());
                                obj.Externo = !obj.Interno;
                                obj.DatosUsuario.Estatus = bool.Parse(reader["CON_Estatus"].ToString());

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
        public int ABCContactos_Guardar(ContactosBE obj)
        {
            int Result = 0;
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_ABC_CONTACTOS_GUARDAR, conn)) {
                        cmd.Parameters.AddWithValue("@Nombre", obj.Nombre);
                        cmd.Parameters.AddWithValue("@Interno", obj.Interno);
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
        public int ABCContactos_Actualizar(ContactosBE obj)
        {
            int Result = 0;
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_ABC_CONTACTOS_ACTUALIZAR, conn)) {
                        cmd.Parameters.AddWithValue("@Id", obj.Id);
                        cmd.Parameters.AddWithValue("@Nombre", obj.Nombre);
                        cmd.Parameters.AddWithValue("@Interno", obj.Interno);
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
