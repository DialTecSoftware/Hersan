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
using Telerik.WinControls.Data;
using Telerik.WinControls.UI;

namespace Hersan.UI.Ventas
{
    public partial class frmCapturaPedidos : Telerik.WinControls.UI.RadForm
    {
        #region Variables
        WCF_Ventas.Hersan_VentasClient oVentas = new WCF_Ventas.Hersan_VentasClient();
        private List<ClientesBE> oClientes;
        //private PedidosBE oPedido;
        private List<PedidoDetalleBE> oList = new List<PedidoDetalleBE>();
        private PedidoDetalleBE oDetalle;
        private int IdCliente = 0;
        #endregion

        public frmCapturaPedidos()
        {
            InitializeComponent();
        }
        private void frmCapturaPedidos_Load(object sender, EventArgs e)
        {
            try {
                /* GRUPO POR ENTIDAD */
                GroupDescriptor descriptor = new GroupDescriptor();
                descriptor.GroupNames.Add("Entidad", ListSortDirection.Ascending);
                this.gvDatos.GroupDescriptors.Add(descriptor);

                /* SUMA DE CANTIDADES */
                GridViewSummaryItem summaryItem = new GridViewSummaryItem();
                summaryItem.Name = "Cantidad";
                summaryItem.Aggregate = GridAggregateFunction.Sum;

                GridViewSummaryRowItem summaryRowItem = new GridViewSummaryRowItem();
                summaryRowItem.Add(summaryItem);
                this.gvDatos.SummaryRowsBottom.Add(summaryRowItem);

                txtFecha.Text = DateTime.Today.ToShortDateString();
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al cargar la pantalla\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {

        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {

        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            try {
                this.Close();
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al cerrar la pantalla\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            oDetalle = new PedidoDetalleBE();
            try {
                if (oList.FindAll(item => item.Producto.Producto == cboProductos.Text && item.Producto.Caracteristica == cboCaract.Text).Count == 0) {
                    oDetalle.Sel = false;
                    oDetalle.Entidad.Nombre = rbVialeta.IsChecked ? "VIALETA" : "VIALIDAD";
                    oDetalle.Producto.Producto = cboProductos.Text;
                    oDetalle.Producto.Caracteristica = cboCaract.Text;
                    oDetalle.Cantidad = int.Parse(txtCantidad.Text);

                    oList.Add(oDetalle);

                    ActualizaGrid();
                } else {
                    RadMessageBox.Show("No es posible agregar un item que ya existe en el pedido", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                }
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al agregar la selección\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void btnQuitar_Click(object sender, EventArgs e)
        {
            try {
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


        private void CargaCliente(int IdCliente)
        {
            oVentas = new WCF_Ventas.Hersan_VentasClient();
            try {
                oClientes = oVentas.ABC_Clientes_Obtener(IdCliente);
                if (oClientes.Count > 0) {
                    var item = oClientes[0];

                    txtClave.Text = item.Id.ToString();
                    txtNombre.Text = item.Nombre;
                } else {
                    RadMessageBox.Show("La clave del cliente no existe o no está asignada al agente", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                    txtClave.Clear();
                }
            } catch (Exception ex) {
                throw ex;
            } finally {
                oVentas = null;
            }

        }
        private void LimpiarDetalle()
        {
            try {
                cboProductos.SelectedIndex = -1;
                cboCaract.SelectedIndex = -1;
                txtCantidad.Text = "0";
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
    }
}
