using Hersan.Entidades.Ensamble;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Hersan.Datos.Ventas
{
    public class ClientesDA : BaseDA
    {
        #region Constantes
        const string CONS_USP_ABC_CLIENTES_GUARDAR = "ABC_Clientes_Guardar";
        const string CONS_USP_ABC_CLIENTES_ACTUALIZAR = "ABC_Clientes_Actualizar";
        const string CONS_USP_ABC_CLIENTES_BUSCAR = "ABC_Clientes_Buscar";
        const string CONS_USP_ABC_CLIENTES_OBTENER = "ABC_Clientes_Obtener";
        const string CONS_USP_ABC_CLIENTES_AGENTES_OBTENER = "ABC_Clientes_Agentes_Obtener";
        const string CONS_USP_ABC_CLIENTESAGENTE_GUARDAR = "ABC_ClientesAgente_Guardar";
        #endregion

        public int ABC_Clientes_Guardar(DataSet Tablas, string Entidades, int IdUsuario)
        {
            int Result = 0;
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONS_USP_ABC_CLIENTES_GUARDAR, conn)) {
                        cmd.Parameters.AddWithValue("@Cliente", Tablas.Tables["Cliente"]);
                        cmd.Parameters.AddWithValue("@Condiciones", Tablas.Tables["Condiciones"]);
                        cmd.Parameters.AddWithValue("@Compras", Tablas.Tables["Compras"]);
                        cmd.Parameters.AddWithValue("@Pagos", Tablas.Tables["Pagos"]);
                        cmd.Parameters.AddWithValue("@IdEntidad", Entidades);
                        cmd.Parameters.AddWithValue("@Recepcion", Tablas.Tables["Recepcion"]);
                        cmd.Parameters.AddWithValue("@Referencias", Tablas.Tables["Referencias"]);
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
        public int ABC_Clientes_Actualizar(DataSet Tablas, string Entidades, int IdUsuario, bool Estatus)
        {
            int Result = 0;
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONS_USP_ABC_CLIENTES_ACTUALIZAR, conn)) {
                        cmd.Parameters.AddWithValue("@Cliente", Tablas.Tables["Cliente"]);
                        cmd.Parameters.AddWithValue("@Condiciones", Tablas.Tables["Condiciones"]);
                        cmd.Parameters.AddWithValue("@Compras", Tablas.Tables["Compras"]);
                        cmd.Parameters.AddWithValue("@Pagos", Tablas.Tables["Pagos"]);
                        cmd.Parameters.AddWithValue("@IdEntidad", Entidades);
                        cmd.Parameters.AddWithValue("@Recepcion", Tablas.Tables["Recepcion"]);
                        cmd.Parameters.AddWithValue("@Referencias", Tablas.Tables["Referencias"]);
                        cmd.Parameters.AddWithValue("@IdUsuario", IdUsuario);
                        cmd.Parameters.AddWithValue("@Estatus", Estatus);

                        cmd.CommandType = CommandType.StoredProcedure;
                        Result = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
                return Result;
            } catch (Exception ex) {
                throw ex;
            }
        }
        public List<ClientesBE> ABC_Clientes_Buscar(ClientesBE Lista, string Entidades)
        {
            List<ClientesBE> oList = new List<ClientesBE>();
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONS_USP_ABC_CLIENTES_BUSCAR, conn)) {
                        cmd.Parameters.AddWithValue("@IdCliente", Lista.Id);
                        cmd.Parameters.AddWithValue("@Fecha", Lista.DatosUsuario.FechaCreacion.Year.ToString() + Lista.DatosUsuario.FechaCreacion.Month.ToString().PadLeft(2,'0') 
                            + Lista.DatosUsuario.FechaCreacion.Day.ToString().PadLeft(2,'0'));
                        cmd.Parameters.AddWithValue("@Entidad", Entidades);
                        cmd.Parameters.AddWithValue("@RFC", Lista.RFC);
                        cmd.Parameters.AddWithValue("@Nombre", Lista.Nombre);
                        cmd.Parameters.AddWithValue("@Nacional", Lista.Ciudad);
                        cmd.Parameters.AddWithValue("@Estatus", Lista.Estado);

                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                ClientesBE obj = new ClientesBE();

                                //ClientesEntidadesBE oEnt = new ClientesEntidadesBE();
                                //oEnt.Entidad.Nombre = reader["ENT_Nombre"].ToString();
                                //obj.Entidades.Add(oEnt);

                                obj.Ciudad = reader["ENT_Nombre"].ToString();

                                obj.Id = int.Parse(reader["CLI_Id"].ToString());
                                obj.Nombre = reader["CLI_Nombre"].ToString();
                                obj.RFC = reader["CLI_RFC"].ToString();
                                obj.Nacional = bool.Parse(reader["CLI_Nacional"].ToString());
                                obj.DatosUsuario.Estatus = bool.Parse(reader["CLI_Estatus"].ToString());
                                obj.DatosUsuario.FechaCreacion = DateTime.Parse(reader["CLI_FechaCreacion"].ToString());

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
        public List<ClientesBE> ABC_Clientes_Obtener(int IdCliente)
        {
            List<ClientesBE> oList = new List<ClientesBE>();
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONS_USP_ABC_CLIENTES_OBTENER, conn)) {
                        cmd.Parameters.AddWithValue("@IdCliente", IdCliente);

                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                ClientesBE obj = new ClientesBE();

                                #region TABLA PRINCIPAL                                
                                /* ENCABEZADO */
                                obj.Id = int.Parse(reader["CLI_Id"].ToString());
                                obj.TipoCliente.Id = int.Parse(reader["TIC_Id"].ToString());
                                obj.DatosUsuario.FechaCreacion = DateTime.Parse(reader["CLI_FechaCreacion"].ToString());
                                obj.Nacional = bool.Parse(reader["CLI_Nacional"].ToString());
                                obj.Nombre = reader["CLI_Nombre"].ToString();
                                obj.RFC = reader["CLI_RFC"].ToString();
                                obj.IdFiscal = reader["CLI_IdentFiscal"].ToString();
                                obj.Direccion = reader["CLI_Direccion"].ToString();
                                obj.Telefono = reader["CLI_Telefono"].ToString();
                                obj.Colonia = reader["CLI_Colonia"].ToString();
                                obj.CP = int.Parse(reader["CLI_CP"].ToString());
                                obj.Ciudad = reader["CLI_Ciudad"].ToString();
                                obj.Estado = reader["CLI_Estado"].ToString();
                                obj.Pais = reader["CLI_Pais"].ToString();
                                obj.VIP = bool.Parse(reader["CLI_VIP"].ToString());
                                obj.Correo1 = reader["CLI_Correo1"].ToString();
                                obj.Correo2 = reader["CLI_Correo2"].ToString();
                                obj.Agente.Id = int.Parse(reader["AGE_Id"].ToString());
                                obj.Agente.Nombre = reader["AGE_Nombre"].ToString();
                                obj.DatosUsuario.Estatus = bool.Parse(reader["CLI_Estatus"].ToString());

                                /* CONDICIONES COMERCIALES */
                                obj.Condiciones.FormaPago = int.Parse(reader["FPA_Id"].ToString());
                                obj.Condiciones.MetodoPago = reader["MPA_Clave"].ToString();
                                obj.Condiciones.UsoCFDI = reader["UCF_Clave"].ToString();
                                obj.Condiciones.MontoCredito = decimal.Parse(reader["CON_MontoCredito"].ToString());
                                obj.Condiciones.DiasCredito = int.Parse(reader["CON_DíasCredito"].ToString());
                                obj.Condiciones.Descuento = decimal.Parse(reader["CON_Descuento"].ToString());

                                /* COMPRAS */
                                obj.Compras.Nombre = reader["CCO_Nombre"].ToString();
                                obj.Compras.Correo = reader["CCO_Correo"].ToString();
                                obj.Compras.Telefono = reader["CCO_Telefono"].ToString();
                                obj.Compras.Extension = int.Parse(reader["CCO_Extension"].ToString());

                                /* PAGOS */
                                obj.Pagos.Nombre = reader["CPA_Nombre"].ToString();
                                obj.Pagos.Correo = reader["CPA_Correo"].ToString();
                                obj.Pagos.Telefono = reader["CPA_Telefono"].ToString();
                                obj.Pagos.Extension = int.Parse(reader["CPA_Extension"].ToString());
                                obj.Pagos.DiasPago = reader["CPA_DiasPago"].ToString();
                                obj.Pagos.Contrarecibo = reader["CPA_Contrarecibo"].ToString();
                                obj.Pagos.Horario = reader["CPA_Horario"].ToString();
                                obj.Pagos.Plazo = int.Parse(reader["CPA_PlazoSolicitado"].ToString());

                                #endregion

                                oList.Add(obj);
                            }

                            if (oList.Count > 0) {
                                /* ENTIDADES */
                                if (reader.NextResult()) {
                                    while (reader.Read()) {
                                        ClientesEntidadesBE oEntidad = new ClientesEntidadesBE();
                                        if (oList[0].Entidades.FindAll(item => item.Entidad.Id == int.Parse(reader["ENT_Id"].ToString())).Count == 0) {
                                            oEntidad.Entidad.Id = int.Parse(reader["ENT_Id"].ToString());

                                            oList[0].Entidades.Add(oEntidad);
                                        }
                                    }
                                }

                                /* RECEPCION */
                                if (reader.NextResult()) {
                                    while (reader.Read()) {
                                        ClientesRecepcionBE oRecep = new ClientesRecepcionBE();
                                        if (oList[0].Recepcion.FindAll(item => item.Nombre == reader["CRE_Nombre"].ToString()).Count == 0) {
                                            oRecep.Nombre = reader["CRE_Nombre"].ToString();
                                            oRecep.Puesto = reader["CRE_Puesto"].ToString();

                                            oList[0].Recepcion.Add(oRecep);
                                        }
                                    }
                                }

                                /* REFERENCIAS */
                                if (reader.NextResult()) {
                                    while (reader.Read()) {
                                        ClientesReferenciasBE oRefer = new ClientesReferenciasBE();
                                        if (oList[0].Referencias.FindAll(item => item.Nombre == reader["CRF_Nombre"].ToString()).Count == 0) {
                                            oRefer.Nombre = reader["CRF_Nombre"].ToString();
                                            oRefer.Direccion = reader["CRF_Direccion"].ToString();
                                            oRefer.Telefono = reader["CRF_Telefono"].ToString();
                                            oRefer.Contacto = reader["CRF_Contacto"].ToString();

                                            oList[0].Referencias.Add(oRefer);
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
        public List<ClientesBE> ABC_ClientesAgente_Combo(int IdAgente)
        {
            List<ClientesBE> oList = new List<ClientesBE>();
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONS_USP_ABC_CLIENTES_AGENTES_OBTENER, conn)) {
                        cmd.Parameters.AddWithValue("@IdAgente", IdAgente);

                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                ClientesBE obj = new ClientesBE();

                                obj.Sel = false;
                                obj.Id = int.Parse(reader["CLI_Id"].ToString());
                                obj.Nombre = reader["CLI_Nombre"].ToString();
                                obj.RFC = reader["CLI_RFC"].ToString();
                                obj.VIP = bool.Parse(reader["CLI_VIP"].ToString());

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
        public int ABC_ClientesAgente_Guardar(ClientesBE obj)
        {
            int Result = 0;
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONS_USP_ABC_CLIENTESAGENTE_GUARDAR, conn)) {
                        cmd.Parameters.AddWithValue("@Id", obj.Nombre);
                        cmd.Parameters.AddWithValue("@IdAgente", obj.Agente.Id);
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
