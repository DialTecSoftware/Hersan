using Hersan.Entidades.Catalogos;
using Hersan.Negocio;
using System;
using System.ComponentModel;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.Data;
using Telerik.WinControls.UI;


namespace Hersan.UI.Ensamble
{
    public partial class frmProductos : Telerik.WinControls.UI.RadForm
    {
        WCF_Catalogos.Hersan_CatalogosClient oCatalogos;

        public frmProductos()
        {
            InitializeComponent();
        }
        private void frmProductos_Load(object sender, EventArgs e)
        {
            try {
                GroupDescriptor Entidades = new GroupDescriptor();
                Entidades.GroupNames.Add("Entidad", ListSortDirection.Ascending);
                Entidades.GroupNames.Add("Familia", ListSortDirection.Ascending);
                this.gvDatos.GroupDescriptors.Add(Entidades);

                LimpiarCampos();
                CargarEntidades();
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
            oCatalogos = new WCF_Catalogos.Hersan_CatalogosClient();
            TipoProductoBE obj = new TipoProductoBE();
            try {
                if (txtClave.Text.Trim().Length == 0 || txtNombre.Text.Trim().Length == 0) {
                    RadMessageBox.Show("Debe capturar todos los datos para continuar", this.Text, MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                    return;
                }
                foreach (GridViewRowInfo oRow in gvDatos.Rows) {
                    if ((oRow.Cells["Tipo"].Value.ToString() == txtNombre.Text.Trim()
                        || oRow.Cells["CveProd"].Value.ToString() == txtClave.Text.Trim())
                        && int.Parse(txtId.Text) == 0) {
                        RadMessageBox.Show("El tipo de producto capturado ya existe", this.Text, MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                        LimpiarCampos();
                        return;
                    }
                }

                obj.Id = int.Parse(txtId.Text);
                obj.Familia.Id = int.Parse(cboFamilia.SelectedValue.ToString());
                obj.Clave = txtClave.Text;
                obj.Nombre = txtNombre.Text;
                obj.Name = txtName.Text;
                obj.Fraccion = txtFraccion.Text;
                obj.DatosUsuario.Estatus = chkEstatus.Checked;
                obj.DatosUsuario.IdUsuarioCreo = BaseWinBP.UsuarioLogueado.ID;

                //PROCESO DE GUARDADO Y ACTUALIZACION
                if (txtId.Text == "0") {
                    int Result = oCatalogos.ENS_TipoProducto_Guardar(obj);
                    if (Result == 0) {
                        RadMessageBox.Show("Ocurrió un error al guardar el tipo de producto", this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
                    } else {
                        RadMessageBox.Show("Tipo de producto guardado correctamente", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                        LimpiarCampos();
                        CargarDatos();
                    }
                } else {
                    int Result = oCatalogos.ENS_TipoProducto_Actualizar(obj);
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
            oCatalogos = new WCF_Catalogos.Hersan_CatalogosClient();
            TipoProductoBE obj = new TipoProductoBE();
            try {
                if (chkEstatus.Checked) {
                    if (RadMessageBox.Show("Esta acción dará de baja el tipo de producto\nDesea continuar...?", this.Text, MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.Yes) {
                        obj.Id = int.Parse(txtId.Text);
                        obj.Familia.Id = int.Parse(cboFamilia.SelectedValue.ToString());
                        obj.Clave = txtClave.Text;
                        obj.Nombre = txtNombre.Text;
                        obj.DatosUsuario.Estatus = false;
                        obj.DatosUsuario.IdUsuarioCreo = BaseWinBP.UsuarioLogueado.ID;

                        int Result = oCatalogos.ENS_TipoProducto_Actualizar(obj);
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
                RadMessageBox.Show("Ocurrio un error al dar de baja el tipo de producto\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
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
        private void gvDatos_CurrentRowChanged(object sender, CurrentRowChangedEventArgs e)
        {
            try {
                if (gvDatos.RowCount > 0 && e.CurrentRow.ChildRows.Count == 0) {
                    txtId.Text = e.CurrentRow.Cells["Id"].Value.ToString();
                    cboEntidad.SelectedValue = int.Parse(e.CurrentRow.Cells["IdEntidad"].Value.ToString());
                    cboFamilia.SelectedValue = int.Parse(e.CurrentRow.Cells["IdFamilia"].Value.ToString());
                    txtClave.Text = e.CurrentRow.Cells["CveProd"].Value.ToString();
                    txtNombre.Text = e.CurrentRow.Cells["Tipo"].Value.ToString();
                    txtName.Text = e.CurrentRow.Cells["Name"].Value.ToString();
                    txtFraccion.Text = e.CurrentRow.Cells["Fraccion"].Value.ToString();
                    chkEstatus.Checked = bool.Parse(e.CurrentRow.Cells["Estatus"].Value.ToString());
                }
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrio un error al seleccionar el registro\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void cboEntidad_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            oCatalogos = new WCF_Catalogos.Hersan_CatalogosClient();
            try {
                if (cboEntidad.Items.Count > 0) {
                    cboFamilia.ValueMember = "Id";
                    cboFamilia.DisplayMember = "Nombre";
                    cboFamilia.DataSource = oCatalogos.ENS_Familias_Combo(int.Parse(cboEntidad.SelectedValue.ToString()));
                }
            } catch (Exception ex) {
                throw ex;
            } finally {
                oCatalogos = null;
            }
        }

        private void CargarEntidades()
        {
            oCatalogos = new WCF_Catalogos.Hersan_CatalogosClient();
            try {
                cboEntidad.ValueMember = "Id";
                cboEntidad.DisplayMember = "Nombre";
                cboEntidad.DataSource = oCatalogos.Entidades_Combo(BaseWinBP.UsuarioLogueado.Empresa.Id);
            } catch (Exception ex) {
                throw ex;
            } finally {
                oCatalogos = null;
            }
        }
        private void LimpiarCampos()
        {
            try {
                txtId.Text = "0";
                cboEntidad.SelectedIndex = 0;
                txtClave.Clear();
                txtNombre.Clear();
                txtName.Clear();
                txtFraccion.Clear();
                chkEstatus.Checked = true;
            } catch (Exception ex) {
                throw ex;
            }
        }
        private void CargarDatos()
        {
            oCatalogos = new WCF_Catalogos.Hersan_CatalogosClient();
            try {
                gvDatos.DataSource = oCatalogos.ENS_TipoProducto_Obtener();
            } catch (Exception ex) {
                throw ex;
            } finally {
                oCatalogos = null;
            }
        }        
    }
}
