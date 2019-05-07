using Hersan.Entidades.Catalogos;
using Hersan.Entidades.Ensamble;
using Hersan.Entidades.Ventas;
using Hersan.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.Data;
using Telerik.WinControls.UI;

namespace Hersan.UI.Ensamble
{
    public partial class frmCotizacion : Telerik.WinControls.UI.RadForm
    {
        #region Variables
        WCF_Ensamble.Hersan_EnsambleClient oEnsamble;
        private List<ClientesBE> oClientes;
        private List<ProductoEnsambleBE> oProductos = new List<ProductoEnsambleBE>();
        private List<ServiciosBE> oServicios = new List<ServiciosBE>();
        private List<ReflejantesBE> oReflejantes = new List<ReflejantesBE>();

        private List<PedidoDetalleBE> oList = new List<PedidoDetalleBE>();
        private int IdCliente = 0;

        RadMultiColumnComboBoxSelectionExtender extender = new RadMultiColumnComboBoxSelectionExtender();
        #endregion

        public frmCotizacion()
        {
            InitializeComponent();
        }
        private void frmCotizacion_Load(object sender, EventArgs e)
        {
            try {                               
                /* GRUPO POR TIPO Y ENTIDAD */
                GroupDescriptor tipo = new GroupDescriptor();
                tipo.GroupNames.Add("Tipo", ListSortDirection.Ascending);
                tipo.GroupNames.Add("Entidad", ListSortDirection.Ascending);
                this.gvDatos.GroupDescriptors.Add(tipo);

                /* SUMA DE TOTALES */
                GridViewSummaryItem summaryItem = new GridViewSummaryItem("Total","{0:C2}",GridAggregateFunction.Sum);
                GridViewSummaryRowItem summaryRowItem = new GridViewSummaryRowItem();
                summaryRowItem.Add(summaryItem);
                this.gvDatos.SummaryRowsBottom.Add(summaryRowItem);

                this.gvDatos.MasterTemplate.ShowTotals = true;


                txtFecha.Text = DateTime.Today.ToShortDateString();

                CargaProductos();
                CargaServicios();
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al cargar la pantalla\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {

        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            oEnsamble = new WCF_Ensamble.Hersan_EnsambleClient();
            int Result = 0;
            try {

                //if (!ValidarCampos()) {
                //    RadMessageBox.Show("Debe capturar todos los datos para continuar", this.Text, MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                //    return;
                //}

                if (RadMessageBox.Show("Desea guardar la información capturada...?", this.Text, MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.No)
                    return;

                /* ALTA DE COTIZACION */
                if (int.Parse(txtId.Text) == 0) {
                    Result = oEnsamble.ENS_Cotizacion_Guardar(int.Parse(txtClave.Text), CrearTablasAuxiliares(), BaseWinBP.UsuarioLogueado.ID);
                    if (Result != 0) {
                        RadMessageBox.Show("Cotización guardada correctamente, con folio: " + Result.ToString(), this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                    } else {
                        RadMessageBox.Show("Ocurrió un error al guardar la cotización", this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
                    }
                } else {
                    //Result = oEnsamble.ENS_ProductosFicha_Actualizar(CrearTablasAuxiliares(), Colores, Reflejantes, Accesorios, BaseWinBP.UsuarioLogueado.ID, true);
                    //if (Result != 0) {
                    //    RadMessageBox.Show("Ficha técnica actualizada correctamente", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                    //} else {
                    //    RadMessageBox.Show("Ocurrió un error al actualizar la ficha", this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
                    //}
                }
                //if (Result != 0) {
                //    LimpiarCampos();
                //}
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al guardar la cotización\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally {
                oEnsamble = null;
            }
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try {

            } catch (Exception ex) {
                throw ex;
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
        private void btnQuitar_Click(object sender, EventArgs e)
        {
            try {
                if (oList.FindAll(item => item.Sel == true).Count > 0) {
                    if (RadMessageBox.Show("Esta acción eliminara los elementos seleccionados\nDesea continuar...?", this.Text, MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.No)
                        return;
                } else {
                    RadMessageBox.Show("No se han agregado productos y/o servicios", this.Text, MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                    return;
                }

                if (txtId.Text == "0")
                    oList.RemoveAll(item => item.Sel == true);
                else
                    oList.ForEach(item => {
                        if (item.Sel == true)
                            item.DatosUsuario.Estatus = false;
                    });

                ActualizaGrid();
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al cargar la pantalla\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void btnTodos_Click(object sender, EventArgs e)
        {
            try {
                if (oList.Count > 0) {
                    if (RadMessageBox.Show("Esta acción eliminara todos los elementos\nDesea continuar...?", this.Text, MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.No)
                        return;
                } else {
                    RadMessageBox.Show("No se han agregado productos y/o servicios", this.Text, MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                    return;
                }

                if (txtId.Text == "0")
                    oList.Clear();
                else
                    oList.ForEach(item => item.DatosUsuario.Estatus = false);

                ActualizaGrid();
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al cargar la pantalla\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
        private void txtClave_KeyDown(object sender, KeyEventArgs e)
        {
            try {
                if (e.KeyData == Keys.F3) {
                    frmClientesBuscar ofrm = new frmClientesBuscar();
                    try {
                        ofrm.WindowState = FormWindowState.Normal;
                        ofrm.StartPosition = FormStartPosition.CenterScreen;
                        ofrm.MaximizeBox = false;
                        ofrm.MinimizeBox = false;
                        ofrm.ShowDialog();
                        IdCliente = ofrm.Id;

                        if (IdCliente > 0) {
                            CargaCliente(IdCliente);
                        }

                    } catch (Exception ex) {
                        throw ex;
                    } finally {
                        ofrm.Dispose();
                        ofrm = null;
                    }
                } else {
                    if (e.KeyData == Keys.Enter)
                        CargaCliente(int.Parse(txtClave.Text));
                }
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error en la captura\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void Numeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            try {
                if (!BaseWinBP.isNumero(e.KeyChar))
                    e.Handled = true;
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error en la captura\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void cboProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            oEnsamble = new WCF_Ensamble.Hersan_EnsambleClient();
            try {
                if (cboProductos.SelectedValue != null) {                    
                    var Ficha = oProductos.Find(item => item.Producto.Id == int.Parse(cboProductos.SelectedValue.ToString()));
                    /* COLORES DE CARCASA */
                    cboColores.DisplayMember = "Nombre";
                    cboColores.ValueMember = "Id";
                    cboColores.DataSource = oEnsamble.ENS_CarcasasCotizacion_Combo(Ficha.Id);

                    /* REFLEJANTES */
                    cboReflejantes.DisplayMember = "Nombre";
                    cboReflejantes.ValueMember = "Id";
                    cboReflejantes.DataSource = oEnsamble.ENS_ReflejanteCotizacion_Combo(Ficha.Id);
                    
                    extender.AssociatedRadMultiColumnComboBox = cboReflejantes;
                    extender.AutoCompleteBoxElement.Items.CollectionChanged += Items_CollectionChanged;

                    txtCavidades.Text = Ficha.Reflejantes.ToString();
                    txtPrecio.Text = Ficha.Precio.Precio.ToString();
                    oReflejantes.Clear();
                }
            } catch (Exception ex) {
                throw ex;
            } finally {
                oEnsamble = null;
            }
        }
        private void cboServicios_SelectedIndexChanged(object sender, EventArgs e)
        {
            try {
                if(cboServicios.SelectedValue != null) {
                    txtServicio.Text = oServicios.Find(item => item.Id == int.Parse(cboServicios.SelectedValue.ToString())).Precio.ToString();
                    txtServicio.ReadOnly = decimal.Parse(txtServicio.Text) != 0 ? true : false;
                }
            } catch (Exception ex) {
                throw ex;
            }
        }
        private void btnProductos_Click(object sender, EventArgs e)
        {
            PedidoDetalleBE oDetalle = new PedidoDetalleBE();
            try {
                if (txtCantidadP.Value > 0 && decimal.Parse(txtPrecio.Text) > 0) {
                    if (oReflejantes.Count > 0) {
                        var Aux = oList.Find(item => item.Producto.Id == int.Parse(cboProductos.SelectedValue.ToString()) && item.Tipo == "PRODUCTO");
                        if (Aux == null) {
                            var prod = oProductos.Find(item => item.Id == int.Parse(cboProductos.SelectedValue.ToString()));
                            oDetalle.Sel = false;
                            oDetalle.Tipo = "PRODUCTO";
                            oDetalle.Entidad.Nombre = prod.Entidad.Nombre;
                            oDetalle.Producto.Id = prod.Producto.Id;
                            oDetalle.Producto.Nombre = prod.Producto.Nombre;                            
                            oDetalle.Precio = decimal.Parse(txtPrecio.Text);
                            oDetalle.Cantidad = int.Parse(txtCantidadP.Text);
                            oDetalle.Total = oDetalle.Cantidad * oDetalle.Precio;                            

                            string Reflejantes = string.Empty;
                            oReflejantes.ForEach(item => {                                
                                Reflejantes += item.Nombre + " / ";
                                oDetalle.Reflejantes.Add(item);
                            });
                            oDetalle.Reflec = Reflejantes.Substring(0, Reflejantes.Length - 2);

                            oList.Add(oDetalle);

                            ActualizaGrid();
                            LimpiarProductos();
                        } else {
                            RadMessageBox.Show("No es posible agregar un producto que ya existe en el pedido", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                        }
                    } else {
                        RadMessageBox.Show("No ha seleccionado reflejantes para el producto", this.Text, MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                    }
                } else {
                    RadMessageBox.Show("La cantidad a pedir y/o el precio deben ser mayor a 0", this.Text, MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                }

            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al agregar el producto\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void btnServicios_Click(object sender, EventArgs e)
        {
            try {
                PedidoDetalleBE oDetalle = new PedidoDetalleBE();
                try {
                    if (txtCantidadS.Value > 0 && decimal.Parse(txtServicio.Text) > 0) {
                        var Aux = oList.Find(item => item.Producto.Id == int.Parse(cboServicios.SelectedValue.ToString()) && item.Tipo == "SERVICIO");
                        if (Aux == null) {
                            var prod = oServicios.Find(item => item.Id == int.Parse(cboServicios.SelectedValue.ToString()));
                            oDetalle.Sel = false;
                            oDetalle.Tipo = "SERVICIO";
                            oDetalle.Entidad.Nombre = prod.Entidad.Nombre;
                            oDetalle.Producto.Id = prod.Id;
                            oDetalle.Producto.Nombre = prod.Nombre;
                            oDetalle.Precio = decimal.Parse(txtServicio.Text);
                            oDetalle.Cantidad = int.Parse(txtCantidadS.Text);
                            oDetalle.Total = oDetalle.Cantidad * oDetalle.Precio;
                            oDetalle.Reflec = string.Empty;

                            oList.Add(oDetalle);

                            ActualizaGrid();
                            LimpiarServicios();
                        } else {
                            RadMessageBox.Show("No es posible agregar un servicio que ya existe en el pedido", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                        }
                    } else {
                        RadMessageBox.Show("La cantidad a pedir y/o el precio deben ser mayor a 0", this.Text, MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                    }

                } catch (Exception ex) {
                    RadMessageBox.Show("Ocurrió un error al agregar el servicio\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
                }
            } catch (Exception ex) {
                throw ex;
            }
        }
        private void Items_CollectionChanged(object sender, Telerik.WinControls.Data.NotifyCollectionChangedEventArgs e)
        {
            oReflejantes.Clear();
            extender.UpdateItems(sender, e);
            int Count = 0;

            try {
                foreach (GridViewRowInfo item in this.extender.AssociatedRadMultiColumnComboBox.EditorControl.Rows) {
                    if (item.Tag != null && item.Tag.ToString() == Boolean.TrueString) {
                        if (Count <= txtCantidadP.Value) {
                            ReflejantesBE obj = new ReflejantesBE();
                            obj.Id = int.Parse(item.Cells["Id"].Value.ToString());
                            obj.Nombre = item.Cells["Nombre"].Value.ToString();

                            oReflejantes.Add(obj);
                            Count += 1;
                        } else {
                            RadMessageBox.Show("Solo es posible seleccionar máximo: "+ txtCavidades.Text +" Reflejantes del producto seleccionado", this.Text, MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                            oReflejantes.Clear();
                        }
                    }
                }
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al agregar la selección\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
                oReflejantes.Clear();
            }
        }
      

        private void CargaProductos()
        {
            oEnsamble = new WCF_Ensamble.Hersan_EnsambleClient();
            try {
                oProductos = oEnsamble.ENS_ProductosCotizacion_Combo();
                cboProductos.DisplayMember = "Producto.Nombre";
                cboProductos.ValueMember = "Producto.Id";
                cboProductos.DataSource = oProductos;

                if (cboProductos != null)
                    cboProductos.SelectedIndex = 0;
            } catch (Exception ex) {
                throw ex;
            } finally {
                oEnsamble = null;
            }
        }
        private void CargaServicios()
        {
            oEnsamble = new WCF_Ensamble.Hersan_EnsambleClient();
            try {
                oServicios = oEnsamble.ENS_ServiciosCotizacion_Combo();
                cboServicios.DisplayMember = "Nombre";
                cboServicios.ValueMember = "Id";
                cboServicios.DataSource = oServicios;

                if (cboServicios != null)
                    cboServicios.SelectedIndex = 0;
            } catch (Exception ex) {
                throw ex;
            } finally {
                oEnsamble = null;
            }
        }
        private void CargaCliente(int IdCliente)
        {
            oEnsamble = new WCF_Ensamble.Hersan_EnsambleClient();
            try {
                oClientes = oEnsamble.ABC_Clientes_Obtener(IdCliente);
                if (oClientes.Count > 0) {
                    var item = oClientes[0];
                    if (item.DatosUsuario.Estatus == true) {
                        txtClave.Text = item.Id.ToString();
                        txtNombre.Text = item.Nombre;
                    } else {
                        RadMessageBox.Show("El cliente seleccionado no existe o se ha dado de baja", this.Text, MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                        txtClave.Clear();
                    }
                } else {
                    RadMessageBox.Show("La clave del cliente no existe o no está asignada al agente", this.Text, MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                    txtClave.Clear();
                }
            } catch (Exception ex) {
                throw ex;
            } finally {
                oEnsamble = null;
            }

        }
        private void LimpiarProductos()
        {
            try {
                cboProductos.SelectedIndex = -1;
                cboProductos.SelectedIndex = 0;
                txtCantidadP.Value = 1;
            } catch (Exception ex) {
                throw ex;
            }
        }
        private void LimpiarServicios()
        {
            try {
                cboServicios.SelectedIndex = -1;
                cboServicios.SelectedIndex = 0;
                txtCantidadS.Value = 1;
            } catch (Exception ex) {
                throw ex;
            }
        }
        private void ActualizaGrid()
        {
            try {
                gvDatos.DataSource = null;
                gvDatos.DataSource = oList.FindAll(item => item.DatosUsuario.Estatus == true);
            } catch (Exception ex) {
                throw ex;
            }
        }
        private DataTable CrearTablasAuxiliares()
        {
            DataTable oData;

            try {
                oData = new DataTable("Detalle");
                oData.Columns.Add("COD_Id");
                oData.Columns.Add("COT_Id");
                oData.Columns.Add("COD_Tipo");
                oData.Columns.Add("COD_Id_ProdServ");
                oData.Columns.Add("COD_Reflejantes");
                oData.Columns.Add("COD_Cantidad");
                oData.Columns.Add("COD_Precio");

                CargarTablas(ref oData);

            } catch (Exception ex) {
                throw ex;
            }
            return oData;
        }
        private void CargarTablas(ref DataTable oData)
        {
            try {
                string aux;

                foreach (var item in oList) { 
                    DataRow oRow = oData.NewRow();
                    oRow["COD_Id"] = 0;
                    oRow["COT_Id"] = 0;
                    oRow["COD_Tipo"] = item.Tipo;
                    oRow["COD_Id_ProdServ"] = item.Producto.Id;
                    if (item.Tipo == "PRODUCTO") {
                        aux = string.Empty;
                        item.Reflejantes.ForEach(x => {
                            aux += x.Id.ToString() + ",";
                        });
                        oRow["COD_Reflejantes"] = aux;
                    } else {
                        oRow["COD_Reflejantes"] = string.Empty;
                    }
                    oRow["COD_Cantidad"] = item.Cantidad;
                    oRow["COD_Precio"] = item.Precio;

                    oData.Rows.Add(oRow);
                }

            } catch (Exception ex) {
                throw ex;
            }
        }

    }
}
