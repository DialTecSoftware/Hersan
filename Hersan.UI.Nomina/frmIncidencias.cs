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
    public partial class frmIncidencias : Telerik.WinControls.UI.RadForm
    {
        WCF_Nomina.Hersan_NominaClient oNomina;
        List<SemanasBE> oSemanas = new List<SemanasBE>();
        List<IncidenciasBE> oList = new List<IncidenciasBE>();

        public frmIncidencias()
        {
            InitializeComponent();
        }
        private void FrmIncidencias_Load(object sender, EventArgs e)
        {
            try {
                CargaSemanas();
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al cargar la pantalla\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            try {
                CargaDatos();
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al cargar la pantalla\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            oNomina = new WCF_Nomina.Hersan_NominaClient();
            try {
                if (oList.FindAll(item=> item.Semana.Semana == int.Parse(cboSemana.Text)).Count == 0) {
                    if (RadMessageBox.Show("Desea guardar las incidencias de la semana...?", this.Text, MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.Yes) {
                        oList.ForEach(item => item.Semana.Semana = int.Parse(cboSemana.Text));
                        int Result = oNomina.NOM_Incidencias_Guardar(oList);
                        if (Result == 0)
                            RadMessageBox.Show("Ocurrió un error al guardar las incidencias", this.Text, MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                        else {
                            RadMessageBox.Show("Incidencias guardadas correctamente", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                            CargaDatos();
                        }
                    }
                } else
                    RadMessageBox.Show("Las incidencias ya se encuentran guardadas y no pueden modificarse", this.Text, MessageBoxButtons.OK, RadMessageIcon.Exclamation);
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al guardar las incidencias\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally { oNomina = null; }
        }
        private void BtnBorrar_Click(object sender, EventArgs e)
        {
            try {
                gvDatos.DataSource = null;
                oList.RemoveAll(item => item.Sel == true);
                gvDatos.DataSource = oList;
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al borrar los registros\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void BtnSalir_Click(object sender, EventArgs e)
        {
            try {
                this.Close();
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al cerrar la pantalla\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void CboSemana_SelectedIndexChanged(object sender, EventArgs e)
        {
            try {
                CargaDatos();
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al seleccionar la semana\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
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
        private void CargaDatos()
        {
            oNomina = new WCF_Nomina.Hersan_NominaClient();
            try {
                oList = oNomina.NOM_Incidencias_Obtener(int.Parse(cboSemana.Text));
                gvDatos.DataSource = oList;
            } catch (Exception ex) {
                throw ex;
            } finally {
                oNomina = null;
            }
         }
        
    }
}
