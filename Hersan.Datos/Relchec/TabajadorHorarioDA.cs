using Hersan.Entidades.Relchec;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Hersan.Datos.Relchec
{
    class TabajadorHorarioDA : BaseDA
    {
        #region Constantes
        const string CONST_ABC_TRABAJADORHORARIO_OBTENER = "ABC_TrabajadorHorario_Obtener";
        const string CONST_ABC_TRABAJADORHORARIO_GUARDA = "ABC_TrabajadorHorario_Guarda";
        const string CONST_ABC_TRABAJADORHORARIO_ACTUALIZA = "ABC_TrabajadorHorario_Actualiza";
        const string CONST_ABC_HORARIOS_COMBO = "ABC_Horarios_Combo";
        const string CONST_CHU_EMPLEADOS_COMBO = "CHU_Empleados_Combo ";
        #endregion

        public List<TabajadorHorarioBE> ABCtTrabajadorHorario_Obtener()
        {
            List<TabajadorHorarioBE> oList = new List<TabajadorHorarioBE>();
            try
            {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL")))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_ABC_TRABAJADORHORARIO_OBTENER, conn))
                    {

                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                TabajadorHorarioBE obj = new TabajadorHorarioBE();

                                obj.Id = int.Parse(reader["TH_id"].ToString());
                                obj.Empleado = int.Parse(reader["EMP_Numero"].ToString());
                                obj.Nombres = reader["Nombres"].ToString();
                                obj.Horario.Id = int.Parse(reader["HOR_id"].ToString());
                                obj.HorarioN = reader["HorarioN"].ToString();
                                obj.DatosUsuario.Estatus = bool.Parse(reader["DEP_Estatus"].ToString());
                                //obj.Entidades.Id = int.Parse(reader["ENT_Id"].ToString());
                                //obj.Entidades.Nombre = reader["ENT_Nombre"].ToString();

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

        public int ABCTrabajadorHorario_Guardar(TabajadorHorarioBE obj)
        {
            int Result = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL")))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_ABC_TRABAJADORHORARIO_GUARDA, conn))
                    {
                        cmd.Parameters.AddWithValue("@Empleado", obj.Empleado);
                        cmd.Parameters.AddWithValue("@Horario", obj.Horario.Id);
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
        public int ABCTrabajadorHorario_Actualizar(TabajadorHorarioBE obj)
        {
            int Result = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL")))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_ABC_TRABAJADORHORARIO_ACTUALIZA, conn))
                    {
                        cmd.Parameters.AddWithValue("@Horario", obj.Horario.Id);
                        cmd.Parameters.AddWithValue("@Id", obj.Id);
                        cmd.Parameters.AddWithValue("@Empleado", obj.Empleado);
                        cmd.Parameters.AddWithValue("@Estatus", obj.DatosUsuario.Estatus);
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
        
        public List<TabajadorHorarioBE> ABCEmpleados_Combo(int Empleado)
        {
            List<TabajadorHorarioBE> oList = new List<TabajadorHorarioBE>();
            try
            {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL")))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_CHU_EMPLEADOS_COMBO, conn))
                    {
                        cmd.Parameters.AddWithValue("@Empleado", Empleado);
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                TabajadorHorarioBE obj = new TabajadorHorarioBE();

                                obj.Empleado = int.Parse(reader["EMP_Numero"].ToString());
                                obj.Nombres = reader["Nombres"].ToString();

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

    }

}
