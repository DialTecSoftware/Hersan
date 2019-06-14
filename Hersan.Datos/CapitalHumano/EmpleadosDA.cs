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
        const string CONST_CHU_EMP_OBTENER = "CHU_Empleados_Consultar";
        const string CONST_CHU_EMP_GUARDAR = "CHU_Empleados_Guarda";
        const string CONST_CHU_EMP_ACTUALIZAR = "CHU_Empleados_Actualiza";
        const string CONST_CHU_EMP_ELIMINAR = "CHU_Empleados_Eliminar";
        #endregion


        public int CHUEmpleados_Guardar(EmpleadosBE obj)
        {
            int Result = 0;
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_CHU_EMP_GUARDAR, conn)) {
                        cmd.Parameters.AddWithValue("@IdExp", obj.Expedientes.Id);
                        cmd.Parameters.AddWithValue("@Numero", obj.Numero);
                        cmd.Parameters.AddWithValue("@TipoF", obj.TipoInfonavit);
                        cmd.Parameters.AddWithValue("@IMSS", obj.FechaAltaIMSS);
                        cmd.Parameters.AddWithValue("@Infonavit", obj.Infonavit);
                        cmd.Parameters.AddWithValue("@Fonacot", obj.Fonacot);
                        cmd.Parameters.AddWithValue("@Pension", obj.Pension);
                        cmd.Parameters.AddWithValue("@Ahorro", obj.Ahorro);
                        cmd.Parameters.AddWithValue("@Cuenta", obj.NumeroCuenta);
                        cmd.Parameters.AddWithValue("@EstatusEmp", obj.EstatusEmpleado);
                        cmd.Parameters.AddWithValue("@Fecha", obj.FechaIngreso);
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
                        cmd.Parameters.AddWithValue("@TipoF", obj.TipoInfonavit);
                        cmd.Parameters.AddWithValue("@IMSS", obj.FechaAltaIMSS);
                        cmd.Parameters.AddWithValue("@Infonavit", obj.Infonavit);
                        cmd.Parameters.AddWithValue("@Fonacot", obj.Fonacot);
                        cmd.Parameters.AddWithValue("@Pension", obj.Pension);
                        cmd.Parameters.AddWithValue("@Ahorro", obj.Ahorro);
                        cmd.Parameters.AddWithValue("@Cuenta", obj.NumeroCuenta);
                        cmd.Parameters.AddWithValue("@EstatusEmp", obj.EstatusEmpleado);
                        cmd.Parameters.AddWithValue("@Fecha", obj.FechaIngreso);
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
        public List<EmpleadosBE> CHU_Empleados_Consultar(int IdExp)
        {
            List<EmpleadosBE> oList = new List<EmpleadosBE>();
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_CHU_EMP_OBTENER, conn)) {
                        cmd.Parameters.AddWithValue("@IdExp", IdExp);

                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                EmpleadosBE obj = new EmpleadosBE();
                                obj.Id = int.Parse(reader["EMP_Id"].ToString());
                                obj.Numero = int.Parse(reader["EMP_Numero"].ToString());
                                obj.NumeroCuenta = reader["EMP_NumeroCuenta"].ToString();
                                obj.FechaAltaIMSS = reader["EMP_FechaAltaIMSS"].ToString();
                                obj.TipoInfonavit = reader["EMP_TipoInfonavit"].ToString();
                                obj.EstatusEmpleado = reader["EMP_EstatusEmpleado"].ToString();
                                obj.Infonavit = reader["EMP_Infonavit"].ToString();
                                obj.Fonacot = reader["EMP_Fonacot"].ToString();
                                obj.FechaIngreso = reader["EMP_FechaIngreso"].ToString();
                                obj.Pension = decimal.Parse(reader["EMP_Pension"].ToString());
                                obj.Ahorro = decimal.Parse(reader["EMP_Ahorro"].ToString());
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

        public int CHU_Empleados_Elimina(int IdEmp, int IdUsuario)
        {
            int Result = 0;
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_CHU_EMP_ELIMINAR, conn)) {
                        cmd.Parameters.AddWithValue("@Id", IdEmp);
                        cmd.Parameters.AddWithValue("@IdUsuario", IdUsuario);

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
