using Hersan.Entidades.Nomina;
using Hersan.Negocio;
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
    public partial class frmParametros : Telerik.WinControls.UI.RadForm
    {
        WCF_Nomina.Hersan_NominaClient oNomina;

        public frmParametros()
        {
            InitializeComponent();
        }
        private void frmParametros_Load(object sender, EventArgs e)
        {
            try {
                CargaDatos();
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al cargar la pantalla\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void btnGuadar_Click(object sender, EventArgs e)
        {
            oNomina = new WCF_Nomina.Hersan_NominaClient();

            try {
                if (RadMessageBox.Show("Desea guardar los cambios en los parámetros..?",this.Text, MessageBoxButtons.YesNo,RadMessageIcon.Question) == DialogResult.No) {
                    return;
                }

                ParametrosBE obj = new ParametrosBE();
                obj.Id = int.Parse(txtId.Text);
                obj.Ahorro = spAhorro.Value;
                obj.Asistencia = spAsistencia.Value;
                obj.Dias = int.Parse(spDias.Value.ToString());
                obj.Horas = int.Parse(spHoras.Value.ToString());
                obj.Puntualidad = spPuntual.Value;
                obj.UMA = spUMA.Value;
                obj.Vales = spVales.Value;
                obj.DatosUsuario.IdUsuarioCreo = BaseWinBP.UsuarioLogueado.ID;

                if(oNomina.Nom_Parametros_Guardar(obj) > 0) {
                    RadMessageBox.Show("Parámetros actualizados correctamente", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                    CargaDatos();
                } else {
                    RadMessageBox.Show("Ocurrió un error al actualizar los parámetros", this.Text, MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                }                
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al actualizar los parámetros\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally { oNomina = null; }
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            try {
                this.Close();
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al cerrar la pantalla\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }

        }

        private void CargaDatos()
        {
            oNomina = new WCF_Nomina.Hersan_NominaClient();
            try {
                var obj = oNomina.Nom_Parametros_Obtener();
                if(obj != null) {
                    txtId.Text = obj.Id.ToString();
                    spAhorro.Value = obj.Ahorro;
                    spAsistencia.Value = obj.Asistencia;
                    spDias.Value = obj.Dias;
                    spHoras.Value = obj.Horas;
                    spPuntual.Value = obj.Puntualidad;
                    spUMA.Value = obj.UMA;
                    spVales.Value = obj.Vales;
                }
            } catch (Exception ex) {
                throw ex;
            } finally { oNomina = null; }
        }
    }
}
