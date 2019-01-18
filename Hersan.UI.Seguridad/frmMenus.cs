using Hersan.Entidades.Seguridad;
using Hersan.Negocio;
using System;
using System.Windows.Forms;
using Telerik.WinControls;

namespace Hersan.UI.Seguridad
{
    public partial class frmMenus : Telerik.WinControls.UI.RadForm
    {
        WCF_Seguridad.Hersan_SeguridadClient oSeguridad;

        public frmMenus()
        {
            InitializeComponent();
        }
        private void frmMenus_Load(object sender, EventArgs e)
        {
            try {              
                CargaCombo();
                CargarGrid();
                LimpiarCampos();

            } catch (Exception ex) {
                throw ex;
            }
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            try {
                this.Close();
            } catch (Exception ex) {
                throw ex;
            }

        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try {
                LimpiarCampos();
            } catch (Exception ex) {
                throw ex;
            }

        }
        private void bntGuardar_Click(object sender, EventArgs e)
        {
            oSeguridad = new WCF_Seguridad.Hersan_SeguridadClient();
            try {
                MenusBE obj = new MenusBE() {
                    Menu = txtNombre.Text,
                    Descripcion = txtDescripcion.Text,
                    IDPadre = int.Parse(cboPadre.SelectedValue.ToString()),
                    Orden = int.Parse(txtOrden.Text),
                    NombreForma = txtForma.Text,
                    AssemblyDll = txtEnsamblado.Text,
                    AssemblyNamespace = txtEnsamblado.Text.Replace("dll", "") + txtForma.Text,
                };

                if (oSeguridad.Menu_Guardar(obj) > 0) {
                    RadMessageBox.Show("Menu agregado correctamente", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                    LimpiarCampos();
                    CargarGrid();
                } else {
                    RadMessageBox.Show("Ocurrió un error al guardar la información", this.Text, MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                }
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al agregar el menú\n"+ ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally {
                oSeguridad = null;
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try {

            } catch (Exception ex) {
                throw;
            }
        }
        private void txtOrden_KeyPress(object sender, KeyPressEventArgs e)
        {
            try {
                if (!BaseWinBP.isNumero(e.KeyChar)) {
                    e.Handled = true;
                }
            } catch (Exception ex) {
                throw ex;
            }
        }

        private void CargarGrid()
        {
            oSeguridad = new WCF_Seguridad.Hersan_SeguridadClient();
            try {
                gvMenus.DataSource = null;
                gvMenus.DataSource = oSeguridad.ObtenerMenus();
            } catch (Exception ex) {
                throw ex;
            }
        }
        private void CargaCombo()
        {
            oSeguridad = new WCF_Seguridad.Hersan_SeguridadClient();
            try {
                cboPadre.DataSource = oSeguridad.MenusPadre_Combo();
                cboPadre.DisplayMember = "Menu";
                cboPadre.ValueMember = "ID";
            } catch (Exception ex) {
                throw ex;
            } finally {
                oSeguridad = null;
            }
        }
        private void LimpiarCampos()
        {
            try {
                cboPadre.SelectedIndex = 0;
                txtDescripcion.Text = string.Empty;
                txtEnsamblado.Text = string.Empty;
                txtForma.Text = string.Empty;
                txtNombre.Text = string.Empty;
                txtOrden.Text = "1";
                txtId.Text = "0";
            } catch (Exception ex) {
                throw ex;
            }
        }

      
    }
}
