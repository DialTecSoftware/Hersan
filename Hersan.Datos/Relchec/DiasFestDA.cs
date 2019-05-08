using Hersan.Entidades.Relchec;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hersan.Datos.Relchec
{
    public class DiasFestDa : BaseDA

    {
        #region Constantes
        const string CONST_ABC_DIASFEST_OBTENER = "ABC_DiasFest_Obtener";
        const string CONST_ABC_DIASFEST_GUARDA = "ABC_DiasFest_Guarda";
        const string CONST_ABC_DIASFEST_ACTUALIZAR = "ABC_DiasFest_Actualizar";
        #endregion

        public List<DiasFestBE> ABCDiasFest_Obtener()
        {
            List<DiasFestBE> oList = new List<DiasFestBE>();
            try
            {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL")))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_ABC_DIASFEST_OBTENER, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                DiasFestBE obj = new DiasFestBE();

                                obj.Id = int.Parse(reader["DF_Id"].ToString());
                                obj.Nombre = reader["DF_Nombre"].ToString();
                                obj.dia = DateTime.Parse(reader["DF_Dia"].ToString());
                                obj.DatosUsuario.Estatus = bool.Parse(reader["DF_Estatus"].ToString());

                                oList.Add(obj);
                            }
                        }

                    }
                }
                return oList;
            }
            catch (Exception ex)
            {
                throw ex;


            }
        }

        public int ABCDiasFest_Guarda(DiasFestBE obj)
        {
            int Result = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL")))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_ABC_DIASFEST_GUARDA, conn))
                    {
                        cmd.Parameters.AddWithValue("@Nombre", obj.Nombre);
                        cmd.Parameters.AddWithValue("@Dia", obj.dia.Year.ToString()+obj.dia.Month.ToString().PadLeft(2,'0')+ obj.dia.Day.ToString().PadLeft(2, '0'));
                        cmd.Parameters.AddWithValue("@IdUsuario", obj.DatosUsuario.IdUsuarioCreo);

                        cmd.CommandType = CommandType.StoredProcedure;
                        Result = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
                return Result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int ABCDiasFest_Actualizar(DiasFestBE obj)
        {
            int Result = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL")))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_ABC_DIASFEST_ACTUALIZAR, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", obj.Id);
                        cmd.Parameters.AddWithValue("@Nombre", obj.Nombre);
                        cmd.Parameters.AddWithValue("@Dia", obj.dia);
                        cmd.Parameters.AddWithValue("Estatus", obj.DatosUsuario.Estatus);
                        cmd.Parameters.AddWithValue("@IdUsuario", obj.DatosUsuario.IdUsuarioCreo);

                        cmd.CommandType = CommandType.StoredProcedure;
                        Result = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
                return Result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
