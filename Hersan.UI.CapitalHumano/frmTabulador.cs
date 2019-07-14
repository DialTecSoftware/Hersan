using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace Hersan.UI.CapitalHumano
{
    public partial class frmTabulador : Telerik.WinControls.UI.RadForm
    {
        WCF_CHumano.Hersan_CHumanoClient oCHumano;

        public frmTabulador()
        {
            InitializeComponent();
        }
        private void frmTabulador_Load(object sender, EventArgs e)
        {
            oCHumano = new WCF_CHumano.Hersan_CHumanoClient();
            try {
                gvDatos.DataSource = oCHumano.CHU_Tabulador_Puestos_Obtener();
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al cargar la pantalla\n"+ ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
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

    }
}
