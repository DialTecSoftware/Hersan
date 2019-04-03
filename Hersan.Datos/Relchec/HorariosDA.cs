using Hersan.Entidades.Relchec;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Hersan.Datos.Relchec  
    {

    public class HorariosDa : BaseDA

    {
        #region Constantes
        const string CONST_ABC_HORARIOS_OBTENER = "ABC_Horarios_Obtener";
        const string CONST_ABC_HORARIOS_GUARDA = "ABC_Horarios_Guarda";
        const string CONST_ABC_HORARIOS_ACTUALIZA = "ABC_Horarios_Actualiza";
        #endregion

        public List<HorariosBE> ABCHorarios_Obtener()
        {
            List<HorariosBE> oList = new List<HorariosBE>();
            try
            {
                using(SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL")))
                {
                    conn.Open();
                    using (SqlCommand cmd= new SqlCommand(CONST_ABC_HORARIOS_OBTENER, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                HorariosBE obj = new HorariosBE();

                                obj.Id=int.Parse(reader["Hor_id"].ToString());
                                obj.Nombre = reader["Hor_Nombre"].ToString();
                                obj.HoraEnt = int.Parse(reader["Hor_HoraEnt"].ToString());
                                obj.MinutoEnt = int.Parse(reader["HOR_MinutoEnt"].ToString());
                                obj.HoraSalida = int.Parse(reader["Hor_HoraSalida"].ToString());
                                obj.MinutoSalida = int.Parse(reader["Hor_MinutoSalida"].ToString());
                                obj.HorSalComida = int.Parse(reader["Hor_HorSalComida"].ToString());
                                obj.MinSalComida = int.Parse(reader["Hor_MinSalComida"].ToString());
                                obj.HorEntComida = int.Parse(reader["Hor_HorEntComida"].ToString());
                                obj.MinEntComida = int.Parse(reader["Hor_MinEntComida"].ToString());
                                obj.Tolerancia = int.Parse(reader["Hor_Tolerancia"].ToString());
                                obj.DatosUsuario.Estatus = bool.Parse(reader["HOR_Estatus"].ToString());

                                oList.Add(obj);
                            }
                        }

                    }
                }
                return oList;
            }catch(Exception ex){
                throw ex;
           

            }
        }

        public int ABCHorarios_Guarda(HorariosBE obj)
        {
            int Result = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL")))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_ABC_HORARIOS_GUARDA, conn))
                    {
                        cmd.Parameters.AddWithValue("@Nombre", obj.Nombre);
                        cmd.Parameters.AddWithValue("@Horaent", obj.HoraEnt);
                        cmd.Parameters.AddWithValue("@MinutoEnt", obj.MinutoEnt);
                        cmd.Parameters.AddWithValue("@HoraSalida", obj.HoraSalida);
                        cmd.Parameters.AddWithValue("@MinutoSalida", obj.MinutoSalida);
                        cmd.Parameters.AddWithValue("@HorSalComida", obj.HorSalComida);
                        cmd.Parameters.AddWithValue("@MinSalComida", obj.MinSalComida);
                        cmd.Parameters.AddWithValue("@HorEntcomida", obj.HorEntComida);
                        cmd.Parameters.AddWithValue("@MinEntComida", obj.MinEntComida);
                        cmd.Parameters.AddWithValue("@tolerancia", obj.Tolerancia);
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

        public int ABCHorarios_Actualiza(HorariosBE obj)
        {
            int Result = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL")))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_ABC_HORARIOS_ACTUALIZA, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", obj.Id);
                        cmd.Parameters.AddWithValue("@Nombre", obj.Nombre);
                        cmd.Parameters.AddWithValue("@Horaent", obj.HoraEnt);
                        cmd.Parameters.AddWithValue("@MinutoEnt", obj.MinutoEnt);
                        cmd.Parameters.AddWithValue("@HoraSalida", obj.HoraSalida);
                        cmd.Parameters.AddWithValue("@MinutoSalida", obj.MinutoSalida);
                        cmd.Parameters.AddWithValue("@HorSalComida", obj.HorSalComida);
                        cmd.Parameters.AddWithValue("@MinSalComida", obj.MinSalComida);
                        cmd.Parameters.AddWithValue("@HorEntcomida", obj.HorEntComida);
                        cmd.Parameters.AddWithValue("@MinEntComida", obj.MinEntComida);
                        cmd.Parameters.AddWithValue("@tolerancia", obj.Tolerancia);
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