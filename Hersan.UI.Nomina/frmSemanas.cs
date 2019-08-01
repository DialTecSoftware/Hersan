using Hersan.Entidades.Nomina;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace Hersan.UI.Nomina
{
    public partial class frmSemanas : Telerik.WinControls.UI.RadForm
    {
        WCF_Nomina.Hersan_NominaClient oNomina;
        List<SemanasBE> oList = new List<SemanasBE>();

        public frmSemanas()
        {
            InitializeComponent();
        }
        private void frmSemanas_Load(object sender, EventArgs e)
        {
            try {
                dtAnio.Value = DateTime.Today;
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al cargar la pantalla\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try {

            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al guardar los cambios\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void btnGenerar_Click(object sender, EventArgs e)
        {
            oNomina = new WCF_Nomina.Hersan_NominaClient();
            try {
                if (gvDatos.RowCount == 0) {
                    if (RadMessageBox.Show("Desea general las semanas del año ?", this.Text, MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.No)
                        return;
                    else {
                        if(oNomina.NOM_Semanas_generar(dtAnio.Value.Year) > 0) {
                            System.Threading.Tasks.Task task = new System.Threading.Tasks.Task(() =>{CargaGrid();});
                            task.Start();
                            RadMessageBox.Show("Semanas generadas correctamente", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                        } else {
                            RadMessageBox.Show("Ocurrió un error al generar las semanas del año", this.Text, MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                        }
                    }
                }
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al generar las semanas del año.\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally {
                oNomina = null;
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
        private void dtAnio_ValueChanged(object sender, EventArgs e)
        {
            try {
                CargaGrid();
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al seleccionar el año\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }


        private void CargaGrid()
        {
            oNomina = new WCF_Nomina.Hersan_NominaClient();
            try {
                oList = oNomina.NOM_Semanas_Obtener(dtAnio.Value.Year);
                gvDatos.DataSource = oList;
            } catch (Exception ex) {
                throw ex;
            }
        }

       
    }
}
