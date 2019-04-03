using Hersan.Entidades.Ventas;
using Hersan.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace Hersan.UI.Ventas
{
    public partial class frmClientes : Telerik.WinControls.UI.RadForm
    {
        WCF_Ventas.Hersan_VentasClient oVentas;
        private int IdCliente = 0;
        private List<ClientesBE> oClientes;

        public frmClientes()
        {
            InitializeComponent();
        }
        private void frmClientes_Load(object sender, EventArgs e)
        {
            try {
                this.docContactos.Select();
                txtFecha.Text = DateTime.Now.Date.ToShortDateString();

                CargaEntidades();
                CargaFormasPago();
                CargaMetodosPago();
                CargaUsoCFDI();

                LimpiarCampos();
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al cargar la pantalla\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try {
                LimpiarCampos();
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al limpiar la pantalla\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            oVentas = new WCF_Ventas.Hersan_VentasClient();
            DataSet oData = CrearTablasAuxiliares();
            int Result = 0;
            try {

                if (RadMessageBox.Show("Desea guardar la información capturada...?", this.Text, MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.No)
                    return;

                ///* VALIDAR SI ES NUEVO O ACTUALIZACIÓN */
                //if (int.Parse(txtId.Text) == 0) {
                //    oClientes = new ClientesBE();
                //    oClientes.Id = int.Parse(txtId.Text);
                //    oClientes.Nombre = txtNombre.Text;
                //    //var oItem = oCHumano.CHU_ExpedientesDatosPersonales_Consultar(oDatosPersonales);

                //    //if (oItem.Count > 0) {
                //    //    RadMessageBox.Show("EL nombre capturado ya se encuentra en el expediente: " + oItem[0].IdExpediente, this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                //    //    oDatosPersonales = null;
                //    //    return;
                //    //}
                //}

                #region Carga Encabezado Clientes
                DataRow oRow = oData.Tables["Cliente"].NewRow();
                oRow["IdCliente"] = int.Parse(txtId.Text);
                oRow["Nombre"] = txtNombre.Text;
                oRow["RFC"] = txtRFC.Text;
                oRow["Direccion"] = txtDireccion.Text;
                oRow["Colonia"] = txtDireccion.Text;
                oRow["CP"] = txtCP.Text;
                oRow["Ciudad"] = txtCiudad.Text;
                oRow["Estado"] = txtEstado.Text;
                oRow["Telefono"] = txtTelefono.Text;
                oRow["Nacional"] = rbNacional.Checked;
                oRow["Identidad"] = txtIdentidad.Text;

                oData.Tables["Cliente"].Rows.Add(oRow);
                #endregion

                #region Carga Condiciones Comerciales
                oRow = oData.Tables["Condiciones"].NewRow();
                oRow["IdCliente"] = int.Parse(txtId.Text);
                oRow["FormaPago"] = int.Parse(cboForma.SelectedValue.ToString());
                oRow["MetodoP"] = cboMetodo.SelectedValue.ToString();
                oRow["Uso"] = cboUso.SelectedValue.ToString();
                oRow["Monto"] = decimal.Parse(txtMonto.Text);
                oRow["Dias"] = int.Parse(txtDias.Text);
                oRow["Descto"] = decimal.Parse(txtDescto.Text);

                oData.Tables["Condiciones"].Rows.Add(oRow);
                #endregion

                #region Carga Contacto Compras
                oRow = oData.Tables["Compras"].NewRow();
                oRow["CLI_Id"] = int.Parse(txtId.Text);
                oRow["CCO_Nombre"] = txtCompras.Text;
                oRow["CCO_Correo"] = txtCorreoCom.Text;
                oRow["CCO_Telefono"] = txtTelCom.Text;
                oRow["CCO_Extension"] = txtExtCom.Text;

                oData.Tables["Compras"].Rows.Add(oRow);
                #endregion

                #region Carga Contacto Pagos
                oRow = oData.Tables["Pagos"].NewRow();
                oRow["CLI_Id"] = int.Parse(txtId.Text);
                oRow["CPA_Nombre"] = txtPagos.Text;
                oRow["CPA_Correo"] = txtCorreoPag.Text;
                oRow["CPA_Telefono"] = txtTelPag.Text;
                oRow["CPA_Extension"] = txtExtPag.Text;
                oRow["CPA_Compras"] = 0;
                oRow["CPA_DiasPago"] = cboPago.SelectedText;
                oRow["CPA_Contrarecibo"] = cboRecibo.SelectedText;
                oRow["CPA_Horario"] = txtHorario.Text;
                oRow["CPA_PlazoSolicitado"] = int.Parse(txtPlazo.Text);

                oData.Tables["Pagos"].Rows.Add(oRow);
                #endregion

                #region Carga Contacto Recepción
                oRow = oData.Tables["Recepcion"].NewRow();
                oRow["CLI_Id"] = int.Parse(txtId.Text);
                oRow["CRE_Nombre"] = txtContacto1.Text;
                oRow["CRE_Puesto"] = txtPuesto1.Text;

                oData.Tables["Recepcion"].Rows.Add(oRow);

                oRow = oData.Tables["Recepcion"].NewRow();
                oRow["CLI_Id"] = int.Parse(txtId.Text);
                oRow["CRE_Nombre"] = txtContacto2.Text;
                oRow["CRE_Puesto"] = txtPuesto2.Text;

                oData.Tables["Recepcion"].Rows.Add(oRow);
                #endregion

                #region Carga Contacto Referencias
                oRow = oData.Tables["Referencias"].NewRow();
                oRow["CLI_Id"] = int.Parse(txtId.Text);
                oRow["CRF_Nombre"] = txtRefer1.Text;
                oRow["CRF_Direccion"] = txtDirec1.Text;
                oRow["CRF_Telefono"] = txtTel1.Text;
                oRow["CRF_Contacto"] = txtContac1.Text;

                oData.Tables["Referencias"].Rows.Add(oRow);

                oRow = oData.Tables["Referencias"].NewRow();
                oRow["CLI_Id"] = int.Parse(txtId.Text);
                oRow["CRF_Nombre"] = txtRefer2.Text;
                oRow["CRF_Direccion"] = txtDirec2.Text;
                oRow["CRF_Telefono"] = txtTel2.Text;
                oRow["CRF_Contacto"] = txtContac2.Text;

                oData.Tables["Referencias"].Rows.Add(oRow);
                #endregion

                #region Entidades Seleccionadas
                string Entidades = string.Empty;
                foreach (var item in lstEntidades.Items) {
                    if(item.CheckState == Telerik.WinControls.Enumerations.ToggleState.On) {
                        Entidades += item.Value.ToString() + ",";
                    }
                }
                #endregion

                /* ALTA DE CLIENTE */
                if (int.Parse(txtId.Text) == 0) {
                    Result = oVentas.ABC_Clientes_Guardar(oData, Entidades, BaseWinBP.UsuarioLogueado.ID);

                    if (Result != 0) {
                        RadMessageBox.Show("Cliente guardado correctamente\nEl No. Cliente asignado es: " + Result.ToString(), this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                    } else {
                        RadMessageBox.Show("Ocurrió un error al guardar la información", this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
                    }
                }
                //else {
                //    Result = oVentas.CHU_Expedientes_Actualizar(int.Parse(txtId.Text), oData, Foto, BaseWinBP.UsuarioLogueado.ID);
                //    if (Result != 0) {
                //        RadMessageBox.Show("Expediente actualizado correctamente", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                //    } else {
                //        RadMessageBox.Show("Ocurrió un error al actualizar el expediente", this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
                //    }
                //}
                if (Result != 0) {
                    LimpiarCampos();
                    this.docContactos.Select();
                }

            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al guardar los datos\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try {

            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al eliminar el cliente\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            frmClientesBuscar ofrm = new frmClientesBuscar();
            try {
                ofrm.WindowState = FormWindowState.Normal;
                ofrm.StartPosition = FormStartPosition.CenterScreen;
                ofrm.MaximizeBox = false;
                ofrm.MinimizeBox = false;
                ofrm.ShowDialog();
                IdCliente = ofrm.Id;

                if (IdCliente > 0) {
                    LimpiarCampos();
                    CargaCliente(IdCliente);
                }

            } catch (Exception ex) {
                throw ex;
            } finally {
                ofrm.Dispose();
                ofrm = null;
            }
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            try {
                this.Close();
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al cerrar la pantalla\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void rbNacional_CheckedChanged(object sender, EventArgs e)
        {
            try {
                gpoFactura.Enabled = rbNacional.Checked;
                txtRFC.Enabled = rbNacional.Checked;
                txtIdentidad.Enabled = !rbNacional.Checked;
            } catch (Exception ex) {
                throw ex;
            }
        }
        private void Decimal_KeyPress(object sender, KeyPressEventArgs e)
        {
            try {
                if (BaseWinBP.isDecimal(e.KeyChar))
                    e.Handled = true;
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error en la captura\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void Entero_KeyPress(object sender, KeyPressEventArgs e)
        {
            try {
                if (!BaseWinBP.isNumero(e.KeyChar))
                    e.Handled = true;
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error en la captura\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }

        private void CargaFormasPago()
        {
            oVentas = new WCF_Ventas.Hersan_VentasClient();
            try {                     
                cboForma.DisplayMember = "Descripcion";
                cboForma.ValueMember = "Id";
                cboForma.DataSource = oVentas.ABC_FormaPago_Combo();
            } catch (Exception ex) {
                throw ex;
            } finally {
                oVentas = null;
            }
        }
        private void CargaMetodosPago()
        {
            oVentas = new WCF_Ventas.Hersan_VentasClient();
            try {
                cboMetodo.DisplayMember = "Descripcion";
                cboMetodo.ValueMember = "Clave";
                cboMetodo.DataSource = oVentas.ABC_MetodoPago_Combo();
            } catch (Exception ex) {
                throw ex;
            } finally {
                oVentas = null;
            }
        }
        private void CargaUsoCFDI()
        {
            oVentas = new WCF_Ventas.Hersan_VentasClient();
            try {
                cboUso.DisplayMember = "Descripcion";
                cboUso.ValueMember = "Clave";
                cboUso.DataSource = oVentas.ABC_UsoCFDI_Combo();
            } catch (Exception ex) {
                throw ex;
            } finally {
                oVentas = null;
            }
        }
        private void CargaEntidades()
        {
            WCF_Catalogos.Hersan_CatalogosClient oCatalogos = new WCF_Catalogos.Hersan_CatalogosClient();
            try {
                lstEntidades.ValueMember = "Id";
                lstEntidades.DisplayMember = "Nombre";
                lstEntidades.DataSource = oCatalogos.Entidades_Combo(BaseWinBP.UsuarioLogueado.Empresa.Id);
            } catch (Exception ex) {
                throw ex;
            } finally {
                oCatalogos = null;
            }
        }
        private void LimpiarCampos()
        {
            try {
                #region TextBox                
                txtCiudad.Clear();
                txtClave.Clear();
                txtColonia.Clear();
                txtCompras.Clear();
                txtContac1.Clear();
                txtContac2.Clear();
                txtContacto1.Clear();
                txtContacto2.Clear();
                txtCorreoCom.Clear();
                txtCorreoPag.Clear();
                txtCP.Clear();
                txtDescto.Text = "0";
                txtDias.Text = "0";
                txtDirec1.Clear();
                txtDirec2.Clear();
                txtDireccion.Clear();
                txtEstado.Clear();
                txtExtCom.Clear();
                txtExtPag.Clear();
                txtFecha.Clear();
                txtHorario.Clear();
                txtId.Text = "0";
                txtIdentidad.Clear();
                txtMonto.Text = "0";
                txtNombre.Clear();
                txtPagos.Clear();
                txtPlazo.Text = "0";
                txtPuesto1.Clear();
                txtPuesto2.Clear();
                txtRefer1.Clear();
                txtRefer2.Clear();
                txtRFC.Clear();
                txtTel1.Clear();
                txtTel2.Clear();
                txtTelCom.Clear();
                txtTelefono.Clear();
                txtTelPag.Clear();
                #endregion

                foreach(var items in lstEntidades.Items) {
                    items.CheckState = Telerik.WinControls.Enumerations.ToggleState.Off;
                }
                cboPago.SelectedIndex = 0;
                cboRecibo.SelectedIndex = 0;
                cboForma.SelectedIndex = 0;
                cboMetodo.SelectedIndex = 0;
                cboUso.SelectedIndex = 0;

                txtNombre.Focus();
            } catch (Exception ex) {
                throw ex;
            }
        }
        private DataSet CrearTablasAuxiliares()
        {
            DataSet oDataset = new DataSet();
            DataTable oData;

            try {
                #region TABLA DE ENCABEZADO
                oData = new DataTable("Cliente");
                oData.Columns.Add("IdCliente");
                oData.Columns.Add("Nombre");
                oData.Columns.Add("RFC");
                oData.Columns.Add("Direccion");
                oData.Columns.Add("Colonia");
                oData.Columns.Add("CP");
                oData.Columns.Add("Ciudad");
                oData.Columns.Add("Estado");
                oData.Columns.Add("Telefono");
                oData.Columns.Add("Nacional");
                oData.Columns.Add("Identidad");

                oDataset.Tables.Add(oData);
                #endregion

                #region TABLA DE CONDICIONES COMERCIALES
                oData = new DataTable("Condiciones");
                oData.Columns.Add("IdCliente");
                oData.Columns.Add("FormaPago");
                oData.Columns.Add("MetodoP");
                oData.Columns.Add("Uso");
                oData.Columns.Add("Monto");
                oData.Columns.Add("Dias");
                oData.Columns.Add("Descto");

                oDataset.Tables.Add(oData);
                #endregion

                #region TABLA DE CONTACTO COMPRAS
                oData = new DataTable("Compras");
                oData.Columns.Add("CLI_Id");
                oData.Columns.Add("CCO_Nombre");
                oData.Columns.Add("CCO_Correo");
                oData.Columns.Add("CCO_Telefono");
                oData.Columns.Add("CCO_Extension");

                oDataset.Tables.Add(oData);
                #endregion

                #region TABLA DE CONTACTO DE PAGOS
                oData = new DataTable("Pagos");
                oData.Columns.Add("CLI_Id");
                oData.Columns.Add("CPA_Nombre");
                oData.Columns.Add("CPA_Correo");
                oData.Columns.Add("CPA_Telefono");
                oData.Columns.Add("CPA_Extension");
                oData.Columns.Add("CPA_Compras");
                oData.Columns.Add("CPA_DiasPago");
                oData.Columns.Add("CPA_Contrarecibo");
                oData.Columns.Add("CPA_Horario");
                oData.Columns.Add("CPA_PlazoSolicitado");

                oDataset.Tables.Add(oData);
                #endregion

                #region TABLA DE RECEPCION MCIA
                oData = new DataTable("Recepcion");
                oData.Columns.Add("CLI_Id");
                oData.Columns.Add("CRE_Nombre");
                oData.Columns.Add("CRE_Puesto");

                oDataset.Tables.Add(oData);
                #endregion

                #region TABLA DE REFERENCIAS
                oData = new DataTable("Referencias");
                oData.Columns.Add("CLI_Id");
                oData.Columns.Add("CRF_Nombre");
                oData.Columns.Add("CRF_Direccion");
                oData.Columns.Add("CRF_Telefono");
                oData.Columns.Add("CRF_Contacto");

                oDataset.Tables.Add(oData);
                #endregion
            } catch (Exception ex) {
                throw ex;
            }
            return oDataset;
        }
        private void CargaCliente(int IdCliente)
        {
            oVentas = new WCF_Ventas.Hersan_VentasClient();

            try {
                oClientes = oVentas.ABC_Clientes_Obtener(IdCliente);
                if (oClientes.Count > 0) {
                    var item = oClientes[0];

                    #region  SE CARGA EL ENCABEZADO
                    txtId.Text = item.Id.ToString();
                    txtClave.Text = item.Id.ToString();
                    txtNombre.Text = item.Nombre;
                    txtRFC.Text = item.RFC;
                    txtIdentidad.Text = item.IdFiscal;
                    txtDireccion.Text = item.Direccion;
                    txtTelefono.Text = item.Telefono;
                    txtColonia.Text = item.Colonia;
                    txtCP.Text = item.CP.ToString();
                    txtCiudad.Text = item.Ciudad;
                    txtEstado.Text = item.Estado;
                    txtFecha.Text = item.DatosUsuario.FechaCreacion.ToShortDateString();
                    #endregion

                    #region ENTIDADES
                    oClientes.ForEach(aux => {
                        aux.Entidades.ForEach(y => {
                            foreach (var x in lstEntidades.Items) {
                                if (x.Value.ToString() == y.Entidad.Id.ToString())
                                    x.CheckState = Telerik.WinControls.Enumerations.ToggleState.On;
                            }
                        });
                    });
                    #endregion

                    #region RECEPCIÓN MCIA
                    
                    #endregion

                    #region REFERENCIAS

                    #endregion
                }
            } catch (Exception ex) {
                throw ex;
            } finally {
                oVentas = null;
            }

        }
    }
}
