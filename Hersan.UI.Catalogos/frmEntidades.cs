using Hersan.Entidades.Catalogos;
using Hersan.Negocio;
using System;
using System.Windows.Forms;
using Telerik.WinControls;

namespace Hersan.UI.Catalogos
{
    public partial class frmEntidades : Telerik.WinControls.UI.RadForm
    {
        WCF_Catalogos.Hersan_CatalogosClient oCatalogo;

        public frmEntidades()
        {
            InitializeComponent();
        }
        private void frmEntidades_Load(object sender, EventArgs e)
        {
            try {
                LimpiarCampos();
                CargarEntidades();
                CargarEmpresas();
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrio un error al cargar la pantalla\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void btnNuevo(object sender, EventArgs e)
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
            EntidadesBE obj = new EntidadesBE();
            int Result = 0;

            try {
                if (!ValidarCampos()) {
                    RadMessageBox.Show("Debe capturar todos los datos para continuar", this.Text, MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                    return;
                }

                obj.Id = int.Parse(txtId.Text);
                obj.Empresas.Id = int.Parse(cboEmp.SelectedValue.ToString());
                obj.Nombre = txtNombre.Text;
                obj.Abrev = txtAbrev.Text;
                obj.DatosUsuario.Estatus = chkEstatus.Checked;
                obj.DatosUsuario.IdUsuarioCreo = BaseWinBP.UsuarioLogueado.ID;

                //PROCESO DE GUARDADO Y ACTUALIZACION
                if (txtId.Text == "0") {
                    Result = oCatalogo.ABCEntidades_Guardar(obj);
                    if (Result == 0) {
                        RadMessageBox.Show("Ocurrió un error al guardar la entidad", this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
                    } else {
                        RadMessageBox.Show("Entidad guardada correctamente", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                        LimpiarCampos();
                        CargarEntidades();
                    }
                } else {
                    Result = oCatalogo.ABCEntidades_Actualizar(obj);
                    if (Result == 0) {
                        RadMessageBox.Show("Ocurrió un error al actualizar los datos", this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
                    } else {
                        RadMessageBox.Show("Información actualizada correctamente", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                        LimpiarCampos();
                        CargarEntidades();
                    }
                }
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al actualizar la información\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally {
                oCatalogo = null;
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            oCatalogo = new WCF_Catalogos.Hersan_CatalogosClient();
            EntidadesBE obj = new EntidadesBE();
            try {
                if (chkEstatus.Checked) {
                    if (!ValidarCampos()) {
                        RadMessageBox.Show("Debe capturar todos los datos para continuar", this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
                        return;
                    }

                    if (RadMessageBox.Show("Esta acción dará de baja la entidad\nDesea continuar...?", this.Text, MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.Yes) {
                        obj.Id = int.Parse(txtId.Text);
                        obj.Empresas.Id = int.Parse(txtIdEmpresa.Text);
                        obj.Nombre = txtNombre.Text;
                        obj.Abrev = txtAbrev.Text;
                        obj.DatosUsuario.Estatus = false;
                        obj.DatosUsuario.IdUsuarioCreo = BaseWinBP.UsuarioLogueado.ID;

                        int Result = oCatalogo.ABCEntidades_Actualizar(obj);
                        if (Result == 0) {
                            RadMessageBox.Show("Ocurrió un error al modificar los datos", this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
                        } else {
                            RadMessageBox.Show("Información actualizada correctamente", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                            LimpiarCampos();
                            CargarEntidades();
                        }
                    }
                }
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrio un error al dar de baja la entidad\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally {
                oCatalogo = null;
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
        private void gvDatos_CurrentRowChanged(object sender, Telerik.WinControls.UI.CurrentRowChangedEventArgs e)
        {
            try {
                if (gvDatos.RowCount > 0 && gvDatos.CurrentRow.ChildRows.Count == 0) {
                    txtId.Text = gvDatos.CurrentRow.Cells["Id"].Value.ToString();
                    txtIdEmpresa.Text = gvDatos.CurrentRow.Cells["Id_Emp"].Value.ToString();
                    txtNombre.Text = gvDatos.CurrentRow.Cells["Nombre"].Value.ToString();
                    txtAbrev.Text = gvDatos.CurrentRow.Cells["Abrev"].Value.ToString();
                    cboEmp.SelectedValue = int.Parse(txtIdEmpresa.Text);
                    chkEstatus.Checked = bool.Parse(gvDatos.CurrentRow.Cells["Estatus"].Value.ToString());
                }
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrio un error al seleccionar el registro\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }

        private void CargarEmpresas()
        {
            oCatalogo = new WCF_Catalogos.Hersan_CatalogosClient();
            try {
                cboEmp.ValueMember = "ID";
                cboEmp.DisplayMember = "NombreComercial";
                cboEmp.DataSource = oCatalogo.ABCEmpresas_Cbo();
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al cargar las empresas\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally {
                oCatalogo = null;
            }
        }
        public void CargarEntidades()
        {
            oCatalogo = new WCF_Catalogos.Hersan_CatalogosClient();
            try {
                gvDatos.DataSource = oCatalogo.Entidades_Obtener();
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrio un error al cargar las entidades\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally { oCatalogo = null; }
        }
        private void LimpiarCampos()
        {
            try {
                txtId.Text = "0";
                txtIdEmpresa.Text = "0";
                txtNombre.Text = string.Empty;
                cboEmp.SelectedIndex = -1;
                txtAbrev.Text = string.Empty;
                chkEstatus.Checked = false;
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrio un error al limpiar los campos\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private bool ValidarCampos()
        {
            bool Flag = true;
            try {
                Flag = cboEmp.SelectedIndex == -1 ? false : true;
                Flag = txtNombre.Text.Trim().Length  == 0 ? false : true;
                Flag = txtAbrev.Text.Trim().Length == 0 ? false : true;

                return Flag;
            } catch (Exception ex) {
                throw ex;
            }
        }
    }
}

