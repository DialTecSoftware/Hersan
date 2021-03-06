﻿using Hersan.Entidades.Ensamble;
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
        const string CONS_USP_ENS_COTIZACION_REPORTE = "ENS_Cotizacion_Reporte";
        const string CONS_USP_ENS_COTIZACION_REPORTEDETALLE = "ENS_Cotizacion_ReporteDetalle";
        const string CONS_USP_ENS_COTIZACION_CONSULTA = "ENS_Cotizacion_Consulta";
        const string CONS_USP_ENS_PEDIDO_CONSULTA = "ENS_Pedido_Consulta";
        #endregion

        public int ENS_Cotizacion_Guardar(PedidosBE obj, DataTable oDetalle)
        {
            int Result = 0;
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONS_USP_ENS_COTIZACION_GUARDAR, conn)) {
                        cmd.Parameters.AddWithValue("@IdCliente", obj.Cliente.Id);
                        cmd.Parameters.AddWithValue("@Moneda", obj.Moneda.Moneda);
                        cmd.Parameters.AddWithValue("@Proyecto", obj.Proyecto);
                        cmd.Parameters.AddWithValue("@Semaforo", obj.Semaforo);
                        cmd.Parameters.AddWithValue("@Condicion", obj.Condiciones.Id);
                        cmd.Parameters.AddWithValue("@Gastos", obj.Gastos);
                        cmd.Parameters.AddWithValue("@Detalle", oDetalle);
                        cmd.Parameters.AddWithValue("@IdUsuario", obj.DatosUsuario.IdUsuarioModif);

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
                        cmd.Parameters.AddWithValue("@Moneda", obj.Moneda.Moneda);
                        cmd.Parameters.AddWithValue("@IdCliente", obj.Cliente.Id);
                        cmd.Parameters.AddWithValue("@EsPedido", obj.Pedido);
                        cmd.Parameters.AddWithValue("@Proyecto", obj.Proyecto);
                        cmd.Parameters.AddWithValue("@Semaforo", obj.Semaforo);
                        cmd.Parameters.AddWithValue("@Condicion", obj.Condiciones.Id);
                        cmd.Parameters.AddWithValue("@Gastos", obj.Gastos);
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
                                obj.Cliente.VIP = bool.Parse(reader["CLI_VIP"].ToString());
                                obj.Proyecto = reader["COT_Proyecto"].ToString();
                                obj.Semaforo = int.Parse(reader["COT_Semaforo"].ToString());
                                obj.Condiciones.Id = int.Parse(reader["CEX_Id"].ToString());
                                obj.Agente.Id = int.Parse(reader["AGE_Id"].ToString());
                                obj.Agente.Nombre = reader["AGE_Nombre"].ToString();
                                obj.DatosUsuario.FechaCreacion = DateTime.Parse(reader["Fecha"].ToString());
                                obj.Moneda.Moneda = reader["MON_Moneda"].ToString();

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
                                        oDetalle.Descto = decimal.Parse(reader["COD_Descto"].ToString());
                                        oDetalle.Cantidad = int.Parse(reader["COD_Cantidad"].ToString());
                                        oDetalle.Total = (oDetalle.Cantidad * oDetalle.Precio) - oDetalle.Descto;


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
        public DataTable ENS_Cotizacion_Reporte(int IdCotiza)
        {
            DataTable oData = new DataTable("Reporte");
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONS_USP_ENS_COTIZACION_REPORTE, conn)) {
                        cmd.Parameters.AddWithValue("@Id", IdCotiza);

                        cmd.CommandType = CommandType.StoredProcedure;
                        oData.Load(cmd.ExecuteReader());
                    }
                }
                return oData;
            } catch (Exception ex) {
                throw ex;
            }
        }
        public DataTable ENS_Cotizacion_ReporteDetalle(int IdCotiza)
        {
            DataTable oData = new DataTable("Reporte");
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONS_USP_ENS_COTIZACION_REPORTEDETALLE, conn)) {
                        cmd.Parameters.AddWithValue("@Id", IdCotiza);

                        cmd.CommandType = CommandType.StoredProcedure;
                        oData.Load(cmd.ExecuteReader());
                    }
                }
                return oData;
            } catch (Exception ex) {
                throw ex;
            }
        }
        public List<PedidosBE> ENS_Cotizacion_Consulta(int IdAgente, int IdCotiza, string Inicial, string Final)
        {
            List<PedidosBE> oList = new List<PedidosBE>();
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONS_USP_ENS_COTIZACION_CONSULTA, conn)) {
                        cmd.Parameters.AddWithValue("@Agente", IdAgente);
                        cmd.Parameters.AddWithValue("@IdCotiza", IdCotiza);
                        cmd.Parameters.AddWithValue("@FechaIni", Inicial);
                        cmd.Parameters.AddWithValue("@Fechafin", Final);

                        cmd.CommandType = CommandType.StoredProcedure;

                        using (IDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                PedidosBE obj = new PedidosBE();

                                obj.Id = int.Parse(reader["COT_Id"].ToString());
                                obj.Moneda.Moneda = reader["MON_Moneda"].ToString();
                                obj.Proyecto = reader["COT_Proyecto"].ToString();
                                obj.Semaforo = int.Parse(reader["Semaforo"].ToString());
                                obj.NoPedido = int.Parse(reader["COT_Pedido"].ToString());
                                obj.DatosUsuario.FechaCreacion = DateTime.Parse(reader["COT_FechaCreacion"].ToString());
                                obj.Agente.Clave = reader["AGE_Clave"].ToString();
                                obj.Cliente.Id = int.Parse(reader["CLI_Id"].ToString());
                                obj.Cliente.Nombre = reader["CLI_Nombre"].ToString();
                                obj.Cliente.Correo1 = reader["CLI_Correo1"].ToString();
                                obj.Cliente.Correo2 = reader["CLI_Correo2"].ToString();
                                obj.Monto = decimal.Parse(reader["Monto"].ToString());
                                obj.NoPedido = int.Parse(reader["COT_Pedido"].ToString());
                                obj.Semaforo = int.Parse(reader["COT_Semaforo"].ToString());                                

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
        public List<PedidosBE> ENS_Pedido_Consulta(int IdAgente, int Pedido, string Inicial, string Final)
        {
            List<PedidosBE> oList = new List<PedidosBE>();
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONS_USP_ENS_PEDIDO_CONSULTA, conn)) {
                        cmd.Parameters.AddWithValue("@Agente", IdAgente);
                        cmd.Parameters.AddWithValue("@Pedido", Pedido);
                        cmd.Parameters.AddWithValue("@FechaIni", Inicial);
                        cmd.Parameters.AddWithValue("@Fechafin", Final);

                        cmd.CommandType = CommandType.StoredProcedure;

                        using (IDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                PedidosBE obj = new PedidosBE();

                                obj.Id = int.Parse(reader["COT_Id"].ToString());
                                obj.Moneda.Moneda = reader["MON_Moneda"].ToString();
                                obj.Proyecto = reader["COT_Proyecto"].ToString();
                                obj.Semaforo = int.Parse(reader["Semaforo"].ToString());
                                obj.NoPedido = int.Parse(reader["COT_Pedido"].ToString());
                                obj.DatosUsuario.FechaModif = DateTime.Parse(reader["COT_FechaModif"].ToString());
                                obj.Agente.Clave = reader["AGE_Clave"].ToString();
                                obj.Cliente.Id = int.Parse(reader["CLI_Id"].ToString());
                                obj.Cliente.Nombre = reader["CLI_Nombre"].ToString();
                                obj.Cliente.Correo1 = reader["CLI_Correo1"].ToString();
                                obj.Cliente.Correo2 = reader["CLI_Correo2"].ToString();
                                obj.Monto = decimal.Parse(reader["Monto"].ToString());

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
    }
}
