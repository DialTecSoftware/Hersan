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
   public class TrabajadorHorarioDA : BaseDA
    {
        #region Constantes
        const string CONST_ABC_TRABAJADORHORARIO_OBTENER = "ABC_TrabajadorHorario_Obtener";
        const string CONST_ABC_TRABAJADORHORARIO_GUARDA = "ABC_TrabajadorHorario_Guarda";
        const string CONST_ABC_TRABAJADORHORARIO_ACTUALIZAR = "ABC_TrabajadorHorario_Actualizar";
        const string CONST_CHU_EMPLEADOS_COMBO = "CHU_Empleados_Combo";
        
        #endregion


        public List<TrabajadorHorarioBE> ABCTrabajadorHorario_Obtener()
        {
            List<TrabajadorHorarioBE> oList = new List<TrabajadorHorarioBE>();
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
                                TrabajadorHorarioBE obj = new TrabajadorHorarioBE();

                                obj.Id = int.Parse(reader["TH_id"].ToString());
                                obj.Horarios.Id = int.Parse(reader["Hor_id"].ToString());
                                obj.Horarios.Nombre = reader["HorarioN"].ToString();
                                obj.Empleados.Numero = int.Parse(reader["Emp_Numero"].ToString());
                                obj.Empleados.Expedientes.DatosPersonales.Nombres = reader["EDP_Nombres"].ToString();
                                obj.Empleados.Expedientes.DatosPersonales.APaterno = reader["EDP_APaterno"].ToString();
                                obj.Empleados.Expedientes.DatosPersonales.AMaterno = reader["EDP_AMaterno"].ToString();
                                obj.DatosUsuario.Estatus = bool.Parse(reader["TH_Estatus"].ToString());

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
        public int ABCTrabajadorHorarios_Guarda(TrabajadorHorarioBE obj)
        {
            int Result = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL")))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_ABC_TRABAJADORHORARIO_GUARDA, conn))
                    {
                        cmd.Parameters.AddWithValue("@Empleado", obj.Empleados.Numero);
                        cmd.Parameters.AddWithValue("@Horario", obj.Horarios.Id);          
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
        public int ABCTrabajadorHorarios_Actualizar(TrabajadorHorarioBE obj)
        {
            int Result = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL")))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_ABC_TRABAJADORHORARIO_ACTUALIZAR, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", obj.Id);
                        cmd.Parameters.AddWithValue("@Empleado", obj.Empleados.Numero);
                        cmd.Parameters.AddWithValue("@Horario", obj.Horarios.Id);
                        cmd.Parameters.AddWithValue("@IdUsuario", obj.DatosUsuario.IdUsuarioCreo);
                        cmd.Parameters.AddWithValue("@Estatus", obj.DatosUsuario.Estatus);

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
