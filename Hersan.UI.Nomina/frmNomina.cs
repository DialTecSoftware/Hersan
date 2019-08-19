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
    public partial class frmNomina : Telerik.WinControls.UI.RadForm
    {
        WCF_Nomina.Hersan_NominaClient oNomina;
        List<SemanasBE> oSemanas = new List<SemanasBE>();
        List<NominaBE> oList = new List<NominaBE>();

        public frmNomina()
        {
            InitializeComponent();
        }
        private void frmNomina_Load(object sender, EventArgs e)
        {
            try {
                CargaSemanas();
            } catch (Exception ex) {
                throw ex;
            }
        }
        private void btnCalcular_Click(object sender, EventArgs e)
        {
            oNomina = new WCF_Nomina.Hersan_NominaClient();
            try {
                oList = oNomina.NOM_CalculoNomina(int.Parse(cboSemana.Text));
                gvDatos.DataSource = oList;
            } catch (Exception ex) {
                throw ex;
            } finally { oNomina = null; }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {

        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }
        private void btnImprimir_Click(object sender, EventArgs e)
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


        private void CargaSemanas()
        {
            oNomina = new WCF_Nomina.Hersan_NominaClient();
            List<SemanasBE> oAux = new List<SemanasBE>();
            try {
                oSemanas = oNomina.NOM_Semanas_Obtener(DateTime.Today.Year);                

                cboSemana.ValueMember = "Id";
                cboSemana.DisplayMember = "Semana";
                cboSemana.DataSource = oSemanas;

                if (oSemanas.Count > 0) {
                    oAux = oSemanas.FindAll(item => item.Termina >= DateTime.Today && item.DatosUsuario.Estatus == true && item.Termina.Year == DateTime.Today.Year);
                    cboSemana.SelectedValue = oSemanas.Find(item => item.Id == oAux[0].Id).Id;
                }
            } catch (Exception ex) {
                throw ex;
            } finally { oNomina = null; }
        }
        
    }
}
