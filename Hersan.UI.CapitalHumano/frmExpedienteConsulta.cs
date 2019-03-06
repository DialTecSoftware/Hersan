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
    public partial class frmExpedienteConsulta : Telerik.WinControls.UI.RadForm
    {
        public int IdExpediente { get; set; }
        public bool PopUp { get; set; }

        WCF_Catalogos.Hersan_CatalogosClient oCatalogos;
        WCF_CHumano.Hersan_CHumanoClient oCHumano;
        List<EntidadesBE> oEntidades = new List<EntidadesBE>();

        public frmExpedienteConsulta()
        {
            InitializeComponent();
        }
        private void frmExpedienteConsulta_Load(object sender, EventArgs e)
        {
            try {
                CargarEntidades();
            } catch (Exception ex) {
                throw ex;
            }
        }
        private void txtExpediente_KeyPress(object sender, KeyPressEventArgs e)
        {
            try {
                if (!BaseWinBP.isNumero(e.KeyChar))
                    e.Handled = true;
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error en la captura\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            oCHumano = new WCF_CHumano.Hersan_CHumanoClient();
            try {
                ExpedientesBE obj = new ExpedientesBE();
                obj.Id = txtExpediente.Text.Trim().Length == 0 ? 0 : int.Parse(txtExpediente.Text);
                obj.Puesto.Departamentos.Entidades.Id = cboEntidad.Enabled ? int.Parse(cboEntidad.SelectedValue.ToString()) : 0;
                obj.Puesto.Departamentos.Id = cboDepto.Enabled ? int.Parse(cboDepto.SelectedValue.ToString()) : 0;
                obj.Puesto.Id = cboPuesto.Enabled ? int.Parse(cboPuesto.SelectedValue.ToString()) : 0;
                obj.Tipo = cboTipoExpediente.Enabled ? cboTipoExpediente.Text : string.Empty;
                obj.DatosPersonales.APaterno = txtAPaterno.Text.Trim().Length == 0 ? string.Empty : txtAPaterno.Text;
                obj.DatosPersonales.AMaterno = txtAMaterno.Text.Trim().Length == 0 ? string.Empty : txtAMaterno.Text;
                obj.DatosPersonales.Nombres = txtNombres.Text.Trim().Length == 0 ? string.Empty : txtNombres.Text;
                
                gvDatos.DataSource = oCHumano.CHU_Expedientes_Consultar(obj);
            } catch (Exception ex) {
                throw ex;
            } finally {
                oCHumano = null;
            }
        }
        private void btnAbrir_Click(object sender, EventArgs e)
        {
            try {
                if (gvDatos.RowCount > 0) 
                    /* SE ABRE DESDE LA PANTALLA DE ALTA DE EXPEDIENTES */
                    IdExpediente = int.Parse(gvDatos.CurrentRow.Cells["Id"].Value.ToString());
                else
                    IdExpediente = 0;

                this.Close();
            } catch (Exception ex) {
                throw ex;
            }
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            try {
                IdExpediente = 0;
                this.Close();
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al cerra la pantalla\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void cboEntidad_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try {
                CargarDeptos();
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al seleccionar la entidad\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void cboDepto_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try {
                CargaPuestos();
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al seleccionar el puesto\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally {
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
        private void chkTipo_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            try {
                cboTipoExpediente.Enabled = chkTipo.Checked;
                cboTipoExpediente.SelectedIndex = -1;
            } catch (Exception ex) {
                throw ex;
            }
        }

        private void CargarEntidades()
        {
            oCatalogos = new WCF_Catalogos.Hersan_CatalogosClient();
            try {
                oEntidades = oCatalogos.Entidades_Combo(BaseWinBP.UsuarioLogueado.Empresa.Id);
                oEntidades.Add(new EntidadesBE { Id = 0, Nombre = "TODAS" });
                cboEntidad.ValueMember = "Id";
                cboEntidad.DisplayMember = "Nombre";
                cboEntidad.DataSource = oEntidades;
            } catch (Exception ex) {
                throw ex;
            }
        }
        private void CargarDeptos()
        {
            oCatalogos = new WCF_Catalogos.Hersan_CatalogosClient();
            try {
                cboDepto.ValueMember = "Id";
                cboDepto.DisplayMember = "Nombre";
                cboDepto.DataSource = oCatalogos.ABCDepartamentos_Combo(int.Parse(cboEntidad.SelectedValue.ToString()));
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al cargar los departamentos\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally {
                oCatalogos = null;
            }
        }
        private void CargaPuestos()
        {
            oCatalogos = new WCF_Catalogos.Hersan_CatalogosClient();
            try {
                cboPuesto.ValueMember = "Id";
                cboPuesto.DisplayMember = "Nombre";
                if (cboDepto.Items.Count > 0 && cboDepto.SelectedValue != null) {
                    cboPuesto.DataSource = oCatalogos.ABCPuestos_Combo(int.Parse(cboDepto.SelectedValue.ToString()));
                } else
                    cboPuesto.DataSource = null;
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al seleccionar el puesto\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally {
                oCatalogos = null;
            }
        }
    }
}
