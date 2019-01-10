using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace Hersan.UI.Catalogos
{
    public partial class frmTiposContrato : Telerik.WinControls.UI.RadForm
    {

        WCF_Catalogos.Hersan_CatalogosClient oCatalogo = new WCF_Catalogos.Hersan_CatalogosClient();

        public frmTiposContrato()
        {
            InitializeComponent();
        }

        private void frmTiposContrato_Load(object sender, EventArgs e)
        {
            try {
                Cargar_TiposContrato();
            } catch (Exception ex) {

                throw ex;
            }
        }

        public void Cargar_TiposContrato()
        {
            try {
                dgvTiposContrato.DataSource = oCatalogo.TiposContrato_Obtener();
            } catch (Exception ex) {
                throw ex;
            }
        }
        private void dgvTiposContrato_Click(object sender, EventArgs e)
        {

        }

     

        private void btn_TCONuevo_Click(object sender, EventArgs e)
        {

        }

        private void btn_TCOSalir_Click(object sender, EventArgs e)
        {
            try {
                this.Close();
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrio un error al cerrar la pantalla\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
    }
}
