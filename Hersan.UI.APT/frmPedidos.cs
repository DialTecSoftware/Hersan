using Hersan.Entidades.Ensamble;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace Hersan.UI.APT
{
    public partial class frmPedidos : Telerik.WinControls.UI.RadForm
    {
        WCF_Ensamble.Hersan_EnsambleClient oEnsamble;
        List<PedidosBE> oList = new List<PedidosBE>();


        public frmPedidos()
        {
            InitializeComponent();
        }
        private void frmPedidos_Load(object sender, EventArgs e)
        {
            try {
                CargarPedidos();
            } catch (Exception ex) {
                throw ex;
            }
        }
        private void btnSurtir_Click(object sender, EventArgs e)
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
        private void gvDatos_CurrentRowChanged(object sender, Telerik.WinControls.UI.CurrentRowChangedEventArgs e)
        {
            oEnsamble = new WCF_Ensamble.Hersan_EnsambleClient();
            try {
                if (gvDatos.RowCount > 0)
                    gvDetalle.DataSource = oEnsamble.ENS_Cotizacion_ReporteDetalle(int.Parse(gvDatos.CurrentRow.Cells["Id"].Value.ToString()));

            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al seleccionar el pedido\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally {
                oEnsamble = null;
            }
        }

        private void CargarPedidos()
        {
            oEnsamble = new WCF_Ensamble.Hersan_EnsambleClient();
            try {
                oList = oEnsamble.ENS_Cotizacion_Consulta(0, 0, "19000101", "29000101").FindAll(item => item.NoPedido >0);
                oList.Reverse();
                gvDatos.DataSource = oList;
            } catch (Exception ex) {
                throw ex;
            } finally {
                oEnsamble = null;
            }
        }
    }
}
