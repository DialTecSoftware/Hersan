using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace Hersan.UI.Calidad
{
    public partial class frmCalidadAnalisis : Telerik.WinControls.UI.RadForm
    {

        public frmCalidadAnalisis()
        {
            InitializeComponent();
        }
        private void frmCalidadAnalisis_Load(object sender, EventArgs e)
        {
            try {
                dtInicial.Value = DateTime.Today;
                dtInicial.Checked = false;
                dtFinal.Enabled = dtInicial.Checked;

                dtHInicial.Value = DateTime.Now.ToLocalTime();
                dtHInicial.Checked = false;
                dtHFinal.Enabled = dtInicial.Checked;

            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al cargar la pantalla\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }
        private void btnGrafica1_Click(object sender, EventArgs e)
        {

        }
        private void btnGrafica2_Click(object sender, EventArgs e)
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
        private void dtInicial_ValueChanged(object sender, EventArgs e)
        {
            try {
                dtFinal.Enabled = dtInicial.Checked;
                dtFinal.MinDate = dtInicial.Value;
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al seleccionar la fecha\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void dtHInicial_ValueChanged(object sender, EventArgs e)
        {
            try {
                dtHFinal.Enabled = dtHInicial.Checked;
                dtHFinal.MinDate = dtHInicial.Value;
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al seleccionar la hora\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
    }
}
