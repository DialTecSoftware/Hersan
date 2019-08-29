using Hersan.Entidades.Nomina;
using Hersan.Negocio;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Telerik.WinControls;

namespace Hersan.UI.Nomina
{
    public partial class frmNomina : Telerik.WinControls.UI.RadForm
    {
        WCF_Nomina.Hersan_NominaClient oNomina;
        List<SemanasBE> oSemanas = new List<SemanasBE>();
        List<NominaBE> oList = new List<NominaBE>();
        List<NominaBE> oAux = new List<NominaBE>();

        public frmNomina()
        {
            InitializeComponent();
        }
        private void frmNomina_Load(object sender, EventArgs e)
        {
            try {
                CargaSemanas();
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al cargar la pantalla\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void btnCalcular_Click(object sender, EventArgs e)
        {
            oNomina = new WCF_Nomina.Hersan_NominaClient();
            try {
                oList = oNomina.NOM_CalculoNomina(int.Parse(cboSemana.Text));
                gvDatos.DataSource = oList;
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al calcular la nómina\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally { oNomina = null; }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            oNomina = new WCF_Nomina.Hersan_NominaClient();
            try {
                if(oList.FindAll(item=> item.Id >0).Count > 0) {
                    RadMessageBox.Show("La nómina de la semana seleccionada ya se encuentra guardada", this.Text, MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                    return;
                }

                if (RadMessageBox.Show("Desea guardar la nómina de la semana: "+ cboSemana.Text + "...?", this.Text, MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.Yes) {
                    //oList.ForEach(item => item.Semana.Semana = int.Parse(cboSemana.Text));
                    string Excluir = string.Empty;
                    oAux.ForEach(item => { Excluir += item.Empleado.Id + ","; });

                    int Result = oNomina.NOM_CalculoNomina_Guardar(int.Parse(cboSemana.Text), Excluir, BaseWinBP.UsuarioLogueado.ID);
                    if (Result == 0)
                        RadMessageBox.Show("Ocurrió un error al guardar la nómina de la semana: " + cboSemana.Text, this.Text, MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                    else {
                        btnCalcular_Click(new object(), new EventArgs());
                        RadMessageBox.Show("Nómina guardada correctamente", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                        
                    }
                }
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al guardar la nómina\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally { oNomina = null; }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try {
                if (oList.FindAll(item => item.Id > 0).Count > 0) {
                    RadMessageBox.Show("La nómina de la semana seleccionada ya se encuentra guardada", this.Text, MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                    return;
                }

                gvDatos.DataSource = null;
                oList.ForEach(item => {
                    if (item.Sel == true) {
                        oAux.Add(item);
                    }
                });                
                oList.RemoveAll(item => item.Sel == true);
                gvDatos.DataSource = oList;
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al eliminar el registro\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try {

            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al imprimir los recibos\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
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
        private void CboSemana_SelectedIndexChanged(object sender, EventArgs e)
        {
            oNomina = new WCF_Nomina.Hersan_NominaClient();
            try {
                if (cboSemana.SelectedValue != null) {
                    gvDatos.DataSource = null;
                    oList = oNomina.NOM_Nomina_Obtener(int.Parse(cboSemana.Text));
                    gvDatos.DataSource = oList;
                }
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al seleccionar la semana\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally { oNomina = null; }
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
