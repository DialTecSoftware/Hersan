using Hersan.Entidades.CapitalHumano;
using Hersan.Entidades.Catalogos;
using Hersan.Negocio;
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
    public partial class frmEmpleadosConsulta : Telerik.WinControls.UI.RadForm
    {
        public int IdEmpleado { get; set; }
        CapitalHumano.WCF_Catalogos.Hersan_CatalogosClient oCatalogo;
        CapitalHumano.WCF_CHumano.Hersan_CHumanoClient oCHumano;
        List<EvaluacionInduccionBE> oList = new List<EvaluacionInduccionBE>();
        List<EntidadesBE> oEntidades = new List<EntidadesBE>();
        public frmEmpleadosConsulta()
        {
            InitializeComponent();
        }



        private void CargarEntidades()
        {
            oCatalogo = new CapitalHumano.WCF_Catalogos.Hersan_CatalogosClient();
            try {
                oEntidades = oCatalogo.Entidades_Combo(BaseWinBP.UsuarioLogueado.Empresa.Id);
                oEntidades.Add(new EntidadesBE { Id = 0, Nombre = "TODAS" });
                cboEntidad.ValueMember = "Id";
                cboEntidad.DisplayMember = "Nombre";
                cboEntidad.DataSource = oEntidades;

            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al cargar las entidades\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally {
                oCatalogo = null;
            }
        }
        private void CargarDeptos()
        {
            oCatalogo = new WCF_Catalogos.Hersan_CatalogosClient();
            try {
                cboDepto.ValueMember = "Id";
                cboDepto.DisplayMember = "Nombre";
                cboDepto.DataSource = oCatalogo.ABCDepartamentos_Combo(int.Parse(cboEntidad.SelectedValue.ToString()));
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al cargar los departamentos\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally {
                oCatalogo = null;
            }
        }
        private void CargaPuestos()
        {
            oCatalogo = new WCF_Catalogos.Hersan_CatalogosClient();
            try {
                cboPuesto.ValueMember = "Id";
                cboPuesto.DisplayMember = "Nombre";
                if (cboDepto.Items.Count > 0 && cboDepto.SelectedValue != null) {
                    cboPuesto.DataSource = oCatalogo.ABCPuestos_Combo(int.Parse(cboDepto.SelectedValue.ToString()));
                } else
                    cboPuesto.DataSource = null;
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al seleccionar el puesto\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally {
                oCatalogo = null;
            }
        }


        private void toolWindow2_Click(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

            oCHumano = new WCF_CHumano.Hersan_CHumanoClient();
            try {
                EvaluacionInduccionBE obj = new EvaluacionInduccionBE();
                obj.IdExp = txtIdEMP.Text.Trim().Length == 0 ? 0 : int.Parse(txtIdEMP.Text);
                obj.Puestos.Departamentos.Entidades.Id = cboEntidad.Enabled ? int.Parse(cboEntidad.SelectedValue.ToString()) : 0;
                obj.Puestos.Departamentos.Id = cboDepto.Enabled ? int.Parse(cboDepto.SelectedValue.ToString()) : 0;
                obj.Puestos.Id = cboPuesto.Enabled ? int.Parse(cboPuesto.SelectedValue.ToString()) : 0;
            
                obj.DatosPersonales.APaterno = txtAPaterno.Text.Trim().Length == 0 ? string.Empty : txtAPaterno.Text;
                obj.DatosPersonales.AMaterno = txtAMaterno.Text.Trim().Length == 0 ? string.Empty : txtAMaterno.Text;
                obj.DatosPersonales.Nombres = txtNombres.Text.Trim().Length == 0 ? string.Empty : txtNombres.Text;

                gvDatos.DataSource = oCHumano.CHU_DatosEMP_Obtener(obj);
            } catch (Exception ex) {
                throw ex;
            } finally {
                oCHumano = null;
            }
        }

        private void chkEntidad_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            try {
                cboEntidad.Enabled = chkEntidad.Checked;
                if (!chkEntidad.Checked) {
                    chkDepto.Checked = chkEntidad.Checked;
                }
            } catch (Exception ex) {
                throw ex;
            }
        }

        private void chkDepto_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            try {
                cboDepto.Enabled = chkDepto.Checked;
                if (!chkDepto.Checked)
                    chkPuesto.Checked = false;
                else
                    chkEntidad.Checked = true;
            } catch (Exception ex) {
                throw ex;
            }
        }

        private void chkPuesto_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            try {
                cboPuesto.Enabled = chkPuesto.Checked;
                if (!chkPuesto.Checked)
                    chkDepto.Checked = false;
                else
                    chkDepto.Checked = true;
            } catch (Exception ex) {
                throw ex;
            }
        }

        private void frmEmpleadosConsulta_Load(object sender, EventArgs e)
        {
            try {
                CargarEntidades();
            } catch (Exception) {

                throw;
            }
        }

        private void cboEntidad_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try {
                CargarDeptos();
            } catch (Exception ex) {
                throw ex;
            }
        }

   

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            try {
                if (gvDatos.RowCount > 0)
                    /* SE ABRE DESDE LA PANTALLA DE EVALUACION DE INDUCCION */
                    IdEmpleado = int.Parse(gvDatos.CurrentRow.Cells["EMP_Num"].Value.ToString());
                else
                    IdEmpleado = 0;

                this.Close();
            } catch (Exception ex) {
                throw ex;
            }
        }

        private void cboDepto_SelectedIndexChanged_1(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try {
                CargaPuestos();
            } catch (Exception ex) {
                throw ex;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            try {

                this.Close();
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al cerra la pantalla\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
    }
}
