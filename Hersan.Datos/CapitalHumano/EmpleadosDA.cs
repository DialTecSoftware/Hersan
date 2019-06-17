using Hersan.Entidades.CapitalHumano;
using Hersan.Entidades.Catalogos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hersan.Datos.CapitalHumano
{
  public  class EmpleadosDA: BaseDA
    {
        #region Constantes
        const string CONST_CHU_EMP_OBTENER = "ABC_EquipoHerramientas_Obtener";
        const string CONST_CHU_EMP_GUARDAR = "CHU_Empleados_Guarda";
        const string CONST_CHU_EMP_ACTUALIZAR = "CHU_Empleados_Actualiza";
        const string CONST_CHU_EMPLEADOS_COMBO = "CHU_Empleados_Combo";
        #endregion


        public int CHUEmpleados_Guardar(EmpleadosBE obj)
        {
            int Result = 0;
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_CHU_EMP_GUARDAR, conn)) {
                        cmd.Parameters.AddWithValue("@Numero", obj.Numero);
                        cmd.Parameters.AddWithValue("@Seguro", obj.SeguroSocial);
                        cmd.Parameters.AddWithValue("@registro", obj.RegistroFederal);
                        cmd.Parameters.AddWithValue("@Infonavit", obj.Infonavit);
                        cmd.Parameters.AddWithValue("@Fonacot", obj.Fonacot);
                        cmd.Parameters.AddWithValue("@Sueldo", obj.SueldoAprobado);
                        cmd.Parameters.AddWithValue("@Cuenta", obj.NumeroCuenta);
                        cmd.Parameters.AddWithValue("@EstatusEmp", obj.EstatusEmpleado);
                        //cmd.Parameters.AddWithValue("@Fecha", obj.FechaIngreso);
                        cmd.Parameters.AddWithValue("@IdUsuario", obj.DatosUsuarios.IdUsuarioCreo);

                        cmd.CommandType = CommandType.StoredProcedure;
                        Result = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
                return Result;
            } catch (Exception ex) {
                throw ex;
            }
        }
        public int CHU_EmpleadosActualizar(EmpleadosBE obj)
        {
            int Result = 0;
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_CHU_EMP_ACTUALIZAR, conn)) {
                        cmd.Parameters.AddWithValue("@Numero", obj.Numero);
                        cmd.Parameters.AddWithValue("@IdExp", obj.Expedientes.Id);
                        cmd.Parameters.AddWithValue("@Seguro", obj.SeguroSocial);
                        cmd.Parameters.AddWithValue("@Registro", obj.RegistroFederal);
                        cmd.Parameters.AddWithValue("@Infonavit", obj.Infonavit);
                        cmd.Parameters.AddWithValue("@Fonacot", obj.Fonacot);
                        cmd.Parameters.AddWithValue("@Sueldo", obj.SueldoAprobado);
                        cmd.Parameters.AddWithValue("@Cuenta", obj.NumeroCuenta);
                        cmd.Parameters.AddWithValue("@EstatusEmp", obj.EstatusEmpleado);
                        //cmd.Parameters.AddWithValue("@Fecha", obj.FechaIngreso);
                        cmd.Parameters.AddWithValue("@IdUsuario", obj.DatosUsuarios.IdUsuarioCreo);

                        cmd.CommandType = CommandType.StoredProcedure;
                        Result = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
                return Result;
            } catch (Exception ex) {
                throw ex;
            }
        }
        public List<EmpleadosBE> CHU_EMPLEADOS_COMBO()
        {
            List<EmpleadosBE> oList = new List<EmpleadosBE>();
            try
            {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL")))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_CHU_EMPLEADOS_COMBO, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                EmpleadosBE obj = new EmpleadosBE();

                                obj.Numero = int.Parse(reader["EMP_Numero"].ToString());
                                obj.Expedientes.Id = int.Parse(reader["EXP_Id"].ToString());
                                obj.Expedientes.DatosPersonales.Nombres = reader["EDP_Nombres"].ToString();
                                obj.Expedientes.DatosPersonales.APaterno = reader["EDP_APaterno"].ToString();
                                obj.Expedientes.DatosPersonales.AMaterno = reader["EDP_AMaterno"].ToString();


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
