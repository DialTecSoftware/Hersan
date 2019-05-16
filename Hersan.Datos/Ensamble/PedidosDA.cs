using Hersan.Entidades.Ensamble;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Hersan.Datos.Ensamble
{
    public class PedidosDA : BaseDA
    {
        #region Constantes
        const string CONS_USP_ENS_COTIZACION_GUARDAR = "ENS_Cotizacion_Guardar";
        const string CONS_USP_ENS_COTIZACION_ACTUALIZAR = "ENS_Cotizacion_Actualizar";
        const string CONS_USP_ENS_COTIZACION_BUSCAR = "ENS_Cotizacion_Buscar";
        const string CONS_USP_ENS_COTIZACION_OBTENER = "ENS_Cotizacion_Obtener";
        #endregion


        public int ENS_Cotizacion_Guardar(int IdCliente, DataTable oDetalle, int IdUsuario)
        {
            int Result = 0;
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONS_USP_ENS_COTIZACION_GUARDAR, conn)) {
                        cmd.Parameters.AddWithValue("@IdCliente", IdCliente);
                        cmd.Parameters.AddWithValue("@Detalle", oDetalle);
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
        public int ENS_Cotizacion_Actualizar(PedidosBE obj, DataTable oDetalle)
        {
            int Result = 0;
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONS_USP_ENS_COTIZACION_ACTUALIZAR, conn)) {
                        cmd.Parameters.AddWithValue("@IdCotiza", obj.Id);
                        cmd.Parameters.AddWithValue("@IdCliente", obj.Cliente.Id);
                        cmd.Parameters.AddWithValue("@EsPedido", obj.Pedido);                                                
                        cmd.Parameters.AddWithValue("@Detalle", oDetalle);
                        cmd.Parameters.AddWithValue("@IdUsuario", obj.DatosUsuario.IdUsuarioModif);
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
        public List<PedidosBE> ENS_Cotizacion_Buscar(int IdCliente, string Nombre, string Inicial, string Final)
        {
            List<PedidosBE> oList = new List<PedidosBE>();
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONS_USP_ENS_COTIZACION_BUSCAR, conn)) {
                        cmd.Parameters.AddWithValue("@IdCliente", IdCliente);
                        cmd.Parameters.AddWithValue("@Nombre", Nombre);
                        cmd.Parameters.AddWithValue("@Inicial", Inicial);
                        cmd.Parameters.AddWithValue("@Final", Final);

                        cmd.CommandType = CommandType.StoredProcedure;

                        using(IDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                PedidosBE obj = new PedidosBE();

                                obj.Id = int.Parse(reader["COT_Id"].ToString());
                                obj.Cliente.Id = int.Parse(reader["CLI_Id"].ToString());
                                obj.Cliente.Nombre = reader["CLI_Nombre"].ToString();
                                obj.DatosUsuario.FechaCreacion = DateTime.Parse(reader["COT_FechaCreacion"].ToString());

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
        public List<PedidosBE> ENS_Cotizacion_Obtener(int IdCotizacion)
        {
            List<PedidosBE> oList = new List<PedidosBE>();
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONS_USP_ENS_COTIZACION_OBTENER, conn)) {
                        cmd.Parameters.AddWithValue("@IdCotizacion", IdCotizacion);
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (IDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                PedidosBE obj = new PedidosBE();

                                /* ENCABEZADO DE COTIZACION */
                                obj.Id = int.Parse(reader["COT_Id"].ToString());
                                obj.Cliente.Id = int.Parse(reader["CLI_Id"].ToString());
                                obj.Cliente.Nombre = reader["CLI_Nombre"].ToString();
                                obj.DatosUsuario.FechaCreacion = DateTime.Parse(reader["Fecha"].ToString());

                                oList.Add(obj);
                            }

                            if (oList.Count > 0) {
                                /* DETALLE DE COTIZACION */
                                if (reader.NextResult()) {
                                    while (reader.Read()) {
                                        PedidoDetalleBE oDetalle = new PedidoDetalleBE();
                                        oDetalle.Id = int.Parse(reader["COD_Id"].ToString());
                                        oDetalle.Tipo = reader["COD_Tipo"].ToString();
                                        oDetalle.Entidad.Nombre = reader["ENT_Nombre"].ToString();
                                        oDetalle.Producto.Id = int.Parse(reader["COD_Id_ProdServ"].ToString());
                                        oDetalle.Producto.Nombre = reader["TPR_Nombre"].ToString();
                                        oDetalle.Accesorios.Id = int.Parse(reader["ACC_Id"].ToString());
                                        oDetalle.Accesorios.Nombre = reader["ACC_Nombre"].ToString();
                                        oDetalle.Precio = decimal.Parse(reader["COD_Precio"].ToString());
                                        oDetalle.Cantidad = int.Parse(reader["COD_Cantidad"].ToString());
                                        oDetalle.Total = oDetalle.Cantidad * oDetalle.Precio;

                                        oList[0].Detalle.Add(oDetalle);
                                    }
                                }

                                /* REFLEJANTES DE COTIZACION */
                                if (oList[0].Detalle.Count > 0) {
                                    if (reader.NextResult()) {
                                        while (reader.Read()) {
                                            var aux = oList[0].Detalle.Find(item => item.Id == int.Parse(reader["COD_Id"].ToString()));
                                            if(aux != null) {
                                                aux.Reflec = reader["Tipo"].ToString();
                                                aux.Reflejantes.Add(new Entidades.Catalogos.ReflejantesBE {
                                                    Id = int.Parse(reader["COM_Id"].ToString()),
                                                    Nombre = reader["Tipo"].ToString(),
                                                });
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                return oList;
            } catch (Exception ex) {
                throw ex;
            }
        }
    }
}
