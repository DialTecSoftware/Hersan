using Hersan.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace Hersan.UI.Ensamble
{
    public partial class frmCotizacionesBuscar : Telerik.WinControls.UI.RadForm
    {
        WCF_Ensamble.Hersan_EnsambleClient oEnsamble;
        public int Id { get; set; }

        public frmCotizacionesBuscar()
        {
            InitializeComponent();
        }
        private void frmCotizacionesBuscar_Load(object sender, EventArgs e)
        {
            try {
                dtInicial.Value = DateTime.Today;
                dtInicial.Checked = false;
                dtFinal.Enabled = false;

            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al abrir la pantalla\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            oEnsamble = new WCF_Ensamble.Hersan_EnsambleClient();
            try {
                int IdCliente = txtClave.Text.Trim().Length == 0 ? 0 : int.Parse(txtClave.Text);
                string Inicial = dtInicial.Checked ? dtInicial.Value.Year.ToString() + dtInicial.Value.Month.ToString().PadLeft(2, '0')
                    + dtInicial.Value.Day.ToString().PadLeft(2, '0') : "19000101";
                string Final = dtInicial.Checked ? dtFinal.Value.Year.ToString() + dtFinal.Value.Month.ToString().PadLeft(2, '0')
                    + dtFinal.Value.Day.ToString().PadLeft(2, '0') : "21000101";

                gvDatos.DataSource = oEnsamble.ENS_Cotizacion_Buscar(IdCliente,txtNombre.Text.Trim(),Inicial,Final);
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al cargar los datos\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            try {
                if (gvDatos.RowCount > 0)
                    /* SE ABRE DESDE LA PANTALLA DE ALTA DE COTIZACIONES */
                    Id = int.Parse(gvDatos.CurrentRow.Cells["IdCotizacion"].Value.ToString());
                else
                    Id = 0;

                this.Close();
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al seleccionar la cotización\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
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
        private void dtInicial_ValueChanged(object sender, EventArgs e)
        {
            try {
                dtFinal.Enabled = dtInicial.Checked;
                this.dtFinal.MinDate = dtInicial.Value;
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al seleccionar la fecha\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void txtClave_KeyPress(object sender, KeyPressEventArgs e)
        {
            try {
                if (!BaseWinBP.isNumero(e.KeyChar))
                    e.Handled = true;
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error en la captura\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
    }
}
