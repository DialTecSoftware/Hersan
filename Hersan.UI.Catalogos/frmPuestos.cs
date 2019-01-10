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
    public partial class frmPuestos : Telerik.WinControls.UI.RadForm
    {
        WCF_Catalogos.Hersan_CatalogosClient oCatalogo = new WCF_Catalogos.Hersan_CatalogosClient();

        public frmPuestos()
        {
            InitializeComponent();
        }



        public void Cargar_Puestos()
        {
            try {
                gvPuestos.DataSource = oCatalogo.ABCPuestos_Obtener();
            } catch (Exception ex) {
                throw ex;
            }
        }

        private void frmPuestos_Load(object sender, EventArgs e)
        {
            try {
                Cargar_Puestos();
            } catch (Exception ex) {

                throw ex;
            }
        }

        private void radPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gvPuestos_Click(object sender, EventArgs e)
        {
            
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            try {
                this.Close();
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrio un error al cerrar la pantalla\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
    }
}
