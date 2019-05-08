using Hersan.Entidades.Ventas;
using Hersan.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.Data;
using Telerik.WinControls.UI;

namespace Hersan.UI.Ensamble
{
    public partial class frmCapturaPedidos : Telerik.WinControls.UI.RadForm
    {
        #region Variables
        WCF_Ensamble.Hersan_EnsambleClient oVentas = new WCF_Ensamble.Hersan_EnsambleClient();
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
        private void btnQuitar_Click(object sender, EventArgs e)
        {
            try {
                if (txtClave.Text == "0")
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
                if (txtClave.Text == "0")
                    oList.Clear();
                else
                    oList.ForEach(item => item.DatosUsuario.Estatus = false);

                ActualizaGrid();
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al cargar la pantalla\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
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
