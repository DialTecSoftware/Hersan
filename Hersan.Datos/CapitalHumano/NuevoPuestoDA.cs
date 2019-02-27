using Hersan.Entidades.CapitalHumano;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hersan.Datos.CapitalHumano
{
    public class NuevoPuestoDA : BaseDA
    {

        #region Constantes
        const string CONST_CHU_NVP_OBTENER = "CHU_NuevoPuesto_Obtener";
        const string CONST_CHU_NVP_GUARDAR = "CHU_NuevoPuesto_Guarda";
        const string CONST_CHU_NVP_ACTUALIZAR = "CHU_NuevoPuesto_Actualiza";
        #endregion


        public List<NuevoPuestoBE> CHU_NuevoPuesto_Obtener(int IdUser)
        {
            List<NuevoPuestoBE> oList = new List<NuevoPuestoBE>();
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_CHU_NVP_OBTENER, conn)) {
                        cmd.Parameters.AddWithValue("@idUser", IdUser);
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                NuevoPuestoBE obj = new NuevoPuestoBE();

                                obj.Id = int.Parse(reader["NVP_Id"].ToString());
                                obj.Nombre= (reader["NVP_Nombre"].ToString());
                                obj.Entidades.Nombre = (reader["ENT_Nombre"].ToString());
                                obj.Departamentos.Nombre = reader["DEP_Nombre"].ToString();
                                obj.Entidades.Id = int.Parse(reader["ENT_Id"].ToString());
                                obj.Departamentos.Id = int.Parse(reader["DEP_Id"].ToString());
                                obj.Resultados = (reader["NVP_Resultados"].ToString());
                                obj.Objetivos = (reader["NVP_Objetivos"].ToString());
                                obj.Necesidades = (reader["NVP_Necesidades"].ToString());
                                obj.Prestaciones = (reader["NVP_Prestaciones"].ToString());
                                obj.Ocupantes = int.Parse(reader["NVP_Ocupantes"].ToString());
                                obj.DatosUsuario.Estatus = bool.Parse(reader["NVP_Estatus"].ToString());
                                obj.Autorizado = bool.Parse(reader["NVP_Autorizado"].ToString());
                                obj.NoAutorizado = !obj.Autorizado;
                                obj.PuestosCargo = (reader["NVP_PuestosCargo"].ToString());
                                obj.Sueldo = decimal.Parse(reader["NVP_Sueldo"].ToString());
                                obj.Justificacion = (reader["NVP_Justificacion"].ToString());
                                obj.Indicadores = (reader["NVP_Indicadores"].ToString());
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

        public int CHU_NuevoPuesto_Guardar(NuevoPuestoBE obj)
        {
            int Result = 0;
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_CHU_NVP_GUARDAR, conn)) {

                        cmd.Parameters.AddWithValue("@Id_ENT", obj.Entidades.Id);
                        cmd.Parameters.AddWithValue("@Id_DEP", obj.Departamentos.Id);
                        cmd.Parameters.AddWithValue("@Nombre", obj.Nombre);
                        cmd.Parameters.AddWithValue("@Objetivos", obj.Objetivos);
                        cmd.Parameters.AddWithValue("@Indicadores", obj.Indicadores);
                        cmd.Parameters.AddWithValue("@PuestosCargo", obj.PuestosCargo);
                        cmd.Parameters.AddWithValue("@Prestaciones", obj.Prestaciones);
                        cmd.Parameters.AddWithValue("@Sueldo", obj.Sueldo);
                        cmd.Parameters.AddWithValue("@Necesidades", obj.Necesidades);
                        cmd.Parameters.AddWithValue("@Ocupantes", obj.Ocupantes);
                        cmd.Parameters.AddWithValue("@Justificacion", obj.Justificacion);
                        cmd.Parameters.AddWithValue("@Resultados", obj.Resultados);
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
            public int CHU_NuevoPuesto_Actualizar(NuevoPuestoBE obj)
            {
                int Result = 0;
                try {
                    using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand(CONST_CHU_NVP_ACTUALIZAR, conn)) {
                            cmd.Parameters.AddWithValue("@Id", obj.Id);
                        cmd.Parameters.AddWithValue("@Id_ENT", obj.Entidades.Id);
                        cmd.Parameters.AddWithValue("@Id_DEP", obj.Departamentos.Id);
                        cmd.Parameters.AddWithValue("@Nombre", obj.Nombre);
                        cmd.Parameters.AddWithValue("@Objetivos", obj.Objetivos);
                        cmd.Parameters.AddWithValue("@Indicadores", obj.Indicadores);
                        cmd.Parameters.AddWithValue("@PuestosCargo", obj.PuestosCargo);
                        cmd.Parameters.AddWithValue("@Prestaciones", obj.Prestaciones);
                        cmd.Parameters.AddWithValue("@Sueldo", obj.Sueldo);
                        cmd.Parameters.AddWithValue("@Necesidades", obj.Necesidades);
                        cmd.Parameters.AddWithValue("@Ocupantes", obj.Ocupantes);
                        cmd.Parameters.AddWithValue("@Justificacion", obj.Justificacion);
                        cmd.Parameters.AddWithValue("@Resultados", obj.Resultados);
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
        
    }
}

    

