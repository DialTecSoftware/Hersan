using Hersan.Entidades.Catalogos;
using Hersan.Negocio;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.Data;

namespace Hersan.UI.Catalogos
{
    public partial class frmPuestos : Telerik.WinControls.UI.RadForm
    {
        WCF_Catalogos.Hersan_CatalogosClient oCatalogo;
        List<PuestosBE> oList = new List<PuestosBE>();

        public frmPuestos()
        {
            InitializeComponent();
        }
        private void frmPuestos_Load(object sender, EventArgs e)
        {
            try {
                LimpiarCampos();
                CargarDeptos();
                CargarPuestos();
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrio un error al cargar la pantalla\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            try {
                this.Close();
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrio un error al cerrar la pantalla\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try {
                LimpiarCampos();
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrio un error al limpiar los campos\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            oCatalogo = new WCF_Catalogos.Hersan_CatalogosClient();
            PuestosBE obj = new PuestosBE();
            try {
                obj.Id = int.Parse(txtIdPuesto.Text);
                obj.Departamentos.Id = int.Parse(cboDeptos.SelectedValue.ToString());
                obj.Nombre = txtNombre.Text;
                obj.Abrev = txtAbrev.Text;
                obj.DatosUsuario.Estatus = chkEstatus.Checked;
                obj.DatosUsuario.IdUsuarioCreo = BaseWinBP.UsuarioLogueado.ID;

                //PROCESO DE GUARDADO Y ACTUALIZACION
                if (txtIdPuesto.Text == "0") {
                    int Result = oCatalogo.ABCPuestos_Guardar(obj);
                    if (Result == 0) {
                        RadMessageBox.Show("Ocurrió un error al guardar el puesto", this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
                    } else {
                        RadMessageBox.Show("Puesto guardado correctamente", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                        LimpiarCampos();
                        CargarPuestos();
                    }
                } else {
                    int Result = oCatalogo.ABCPuestos_Actualizar(obj);
                    if (Result == 0) {
                        RadMessageBox.Show("Ocurrió un error al actualizar los datos", this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
                    } else {
                        RadMessageBox.Show("Información actualizada correctamente", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                        LimpiarCampos();
                        CargarPuestos();
                    }
                }
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al actualizar la inforación\n"+ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally {
                oCatalogo = null;
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            oCatalogo = new WCF_Catalogos.Hersan_CatalogosClient();
            PuestosBE obj = new PuestosBE();
            try {
                if (chkEstatus.Checked) {
                    if (RadMessageBox.Show("Esta acción dará de baja el departamento\nDesea continuar...?", this.Text, MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.Yes) {
                        obj.Id = int.Parse(txtIdPuesto.Text);
                        obj.Departamentos.Id = int.Parse(txtIdDep.Text);
                        obj.Nombre = txtNombre.Text;
                        obj.Abrev = txtAbrev.Text;
                        obj.DatosUsuario.Estatus = false;
                        obj.DatosUsuario.IdUsuarioCreo = BaseWinBP.UsuarioLogueado.ID;

                        int Result = oCatalogo.ABCPuestos_Actualizar(obj);
                        if (Result == 0) {
                            RadMessageBox.Show("Ocurrió un error al modificar los datos", this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
                        } else {
                            RadMessageBox.Show("Información actualizada correctamente", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                            LimpiarCampos();
                            CargarPuestos();
                        }
                    }
                }
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrio un error al dar de baja el puesto\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally {
                oCatalogo = null;
            }
        }
        private void gvPuestos_CurrentRowChanged(object sender, Telerik.WinControls.UI.CurrentRowChangedEventArgs e)
        {
            try {
                if (gvPuestos.RowCount > 0 && gvPuestos.CurrentRow.ChildRows.Count == 0) {
                    txtIdPuesto.Text = gvPuestos.CurrentRow.Cells["Id"].Value.ToString();
                    txtIdDep.Text = gvPuestos.CurrentRow.Cells["IdDepto"].Value.ToString();
                    txtNombre.Text = gvPuestos.CurrentRow.Cells["Nombre"].Value.ToString();
                    txtAbrev.Text = gvPuestos.CurrentRow.Cells["Abrev"].Value.ToString();
                    cboDeptos.SelectedValue = int.Parse(txtIdDep.Text);
                    chkEstatus.Checked = bool.Parse(gvPuestos.CurrentRow.Cells["Estatus"].Value.ToString());
                }
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrio un error al seleccionar el registro\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }

        private void CargarPuestos()
        {
            oCatalogo = new WCF_Catalogos.Hersan_CatalogosClient();
            try {
                oList = oCatalogo.ABCPuestos_Obtener();
                gvPuestos.DataSource = oList;
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrio un error al cargar los puestos\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally {
                oCatalogo = null;
            }
        }
        private void CargarDeptos()
        {
            oCatalogo = new WCF_Catalogos.Hersan_CatalogosClient();
            try {
                cboDeptos.ValueMember = "Id";
                cboDeptos.DisplayMember = "Nombre";
                cboDeptos.DataSource = oCatalogo.ABCDepartamentos_Combo();
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al cargar los departamentos\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally {
                oCatalogo = null;
            }
        }
        private void LimpiarCampos()
        {
            try {
                cboDeptos.SelectedIndex = 0;
                txtIdDep.Text = "0";
                txtIdPuesto.Text = "0";
                txtNombre.Text = string.Empty;
                txtAbrev.Text = string.Empty;
                chkEstatus.Checked = false;
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrio un error al limpiar los campos\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }

        private void cboDeptos_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {

        }
    }
}
