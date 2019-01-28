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
    public class PerfilesDA : BaseDA
    {
        #region Constantes
        const string CONST_USP_CHU_PERFILES_GUARDA = "CHU_Perfiles_Guarda";
        #endregion


        //public int CHU_Perfiles_Guardar(PerfilDescripcionBE obj)
        //{
        //    int Result = 0;
        //    try {
        //        using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
        //            conn.Open();
        //            using (SqlCommand cmd = new SqlCommand(CONST_USP_CHU_PERFILES_GUARDA, conn)) {
        //                cmd.Parameters.AddWithValue("@IdPuesto", obj.Puesto.Id);
        //                cmd.Parameters.AddWithValue("@Experiencia", obj.Descripcion);
        //                cmd.Parameters.AddWithValue("@IdEducacion", obj.Ponderacion);
        //                cmd.Parameters.AddWithValue("@Necesaria", obj.Ponderacion);
        //                cmd.Parameters.AddWithValue("@Competencia", obj.Ponderacion);
        //                cmd.Parameters.AddWithValue("@IdUsuario", obj.DatosUsuario.IdUsuarioCreo);

        //                cmd.CommandType = CommandType.StoredProcedure;
        //                Result = Convert.ToInt32(cmd.ExecuteScalar());
        //            }
        //        }
        //        return Result;
        //    } catch (Exception ex) {

        //        throw ex;
        //    }
        //}
    }
}
