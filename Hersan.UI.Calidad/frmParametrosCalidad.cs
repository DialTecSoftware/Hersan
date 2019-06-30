using Hersan.Entidades.Calidad;
using Hersan.Negocio;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace Hersan.UI.Calidad
{
    public partial class frmParametrosCalidad : Telerik.WinControls.UI.RadForm
    {
        WCF_Catalogos.Hersan_CatalogosClient oCatalogos;
        WCF_Ensamble.Hersan_EnsambleClient oEnsamble;
        List<NormaBE> oList = new List<NormaBE>();

        public frmParametrosCalidad()
        {
            InitializeComponent();
        }
        private void frmParametrosCalidad_Load(object sender, EventArgs e)
        {
            try {
                LimpiarCampos();
                CargarColores();
                CargarDatos();
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al cargar la pantalla\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try {
                LimpiarCampos();
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al limpiar los campos\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            oEnsamble = new WCF_Ensamble.Hersan_EnsambleClient();
            NormaBE obj = new NormaBE();

            try {
                if (txtNorma.Text.Trim().Length == 0 || txtLimite.Text.Trim().Length == 0) {
                    RadMessageBox.Show("Debe capturar todos los datos para continuar", this.Text, MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                    return;
                }

                foreach (GridViewRowInfo oRow in gvDatos.Rows) {
                    if (int.Parse(oRow.Cells["IdColor"].Value.ToString()) == int.Parse(cboColores.SelectedValue.ToString()) && int.Parse(txtId.Text) == 0) { 
                        RadMessageBox.Show("Ya se ha capturado la norma para el reflejante seleccionado", this.Text, MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                        LimpiarCampos();
                        return;
                    }
                }

                obj.Id = int.Parse(txtId.Text);
                obj.Color.Id = int.Parse(cboColores.SelectedValue.ToString());
                obj.Norma = int.Parse(txtNorma.Text);
                obj.Limite = decimal.Parse(txtLimite.Text);
                obj.DatosUsuario.Estatus = chkEstatus.Checked;
                obj.DatosUsuario.IdUsuarioCreo = BaseWinBP.UsuarioLogueado.ID;

                if (txtId.Text == "0") {
                    int Result = oEnsamble.CAL_ReflejantesNorma_Guardar(obj);
                    if (Result == 0) {
                        RadMessageBox.Show("Ocurrió un error al guardar el color", this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
                    } else {
                        RadMessageBox.Show("Norma asignada correctamente", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                        LimpiarCampos();
                        CargarDatos();
                    }
                } else {
                    int Result = oEnsamble.CAL_ReflejantesNorma_Actualizar(obj);
                    if (Result == 0) {
                        RadMessageBox.Show("Ocurrió un error al actualizar los datos", this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
                    } else {
                        RadMessageBox.Show("Información actualizada correctamente", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                        LimpiarCampos();
                        CargarDatos();
                    }
                }
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al actualizar la información\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally {
                oCatalogos = null;
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            oEnsamble = new WCF_Ensamble.Hersan_EnsambleClient();
            NormaBE obj = new NormaBE();
            try {
                if (chkEstatus.Checked) {
                    if (RadMessageBox.Show("Esta acción dará de baja la norma\nDesea continuar...?", this.Text, MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.Yes) {
                        obj.Id = int.Parse(txtId.Text);
                        obj.Color.Id = int.Parse(cboColores.SelectedValue.ToString());
                        obj.Norma = int.Parse(txtNorma.Text);
                        obj.Limite = decimal.Parse(txtLimite.Text);
                        obj.DatosUsuario.Estatus = false;
                        obj.DatosUsuario.IdUsuarioCreo = BaseWinBP.UsuarioLogueado.ID;

                        int Result = oEnsamble.CAL_ReflejantesNorma_Actualizar(obj);
                        if (Result == 0) {
                            RadMessageBox.Show("Ocurrió un error al modificar los datos", this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
                        } else {
                            RadMessageBox.Show("Información actualizada correctamente", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                            LimpiarCampos();
                            CargarDatos();
                        }
                    }
                }
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrio un error al dar de baja la norma\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally {
                oCatalogos = null;
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
        private void txtNorma_KeyPress(object sender, KeyPressEventArgs e)
        {
            try {
                if (!BaseWinBP.isNumero(e.KeyChar)) {
                    e.Handled = true;
                }
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al capturar la norma\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void txtLimite_KeyPress(object sender, KeyPressEventArgs e)
        {
            try {
                if (BaseWinBP.isDecimal(e.KeyChar)) {
                    e.Handled = true;
                }
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al capturar el límite inferior\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }

        }
        private void gvDatos_CurrentRowChanged(object sender, Telerik.WinControls.UI.CurrentRowChangedEventArgs e)
        {
            try {
                if (gvDatos.RowCount > 0) {
                    txtId.Text = e.CurrentRow.Cells["Id"].Value.ToString();
                    cboColores.SelectedValue = int.Parse(e.CurrentRow.Cells["IdColor"].Value.ToString());
                    txtNorma.Text = e.CurrentRow.Cells["Norma"].Value.ToString();
                    txtLimite.Text = e.CurrentRow.Cells["Limite"].Value.ToString();
                    chkEstatus.Checked = bool.Parse(e.CurrentRow.Cells["Estatus"].Value.ToString());
                }
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrio un error al seleccionar el registro\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }

        private void CargarColores()
        {
            oCatalogos = new WCF_Catalogos.Hersan_CatalogosClient();
            try {
                cboColores.DisplayMember = "Nombre";
                cboColores.ValueMember = "Id";
                cboColores.DataSource = oCatalogos.ABC_Colores_Combo();
            } catch (Exception ex) {
                throw ex;
            }
        }
        private void LimpiarCampos()
        {
            try {
                txtId.Text = "0";
                cboColores.SelectedIndex = 0;
                txtNorma.Clear();
                txtLimite.Clear();
                chkEstatus.Checked = true;
            } catch (Exception ex) {
                throw ex;
            }
        }
        private void CargarDatos()
        {
            oEnsamble = new WCF_Ensamble.Hersan_EnsambleClient();
            try {
                oList = oEnsamble.CAL_ReflejantesNorma_Obtener();
                gvDatos.DataSource = oList;
            } catch (Exception ex) {
                throw ex;
            } finally {
                oEnsamble = null;
            }
        }

    }
}
