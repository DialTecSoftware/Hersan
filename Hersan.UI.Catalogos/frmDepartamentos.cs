using Hersan.Entidades.Catalogos;
using Hersan.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.Data;

namespace Hersan.UI.Catalogos
{
    public partial class frmDepartamentos : Telerik.WinControls.UI.RadForm
    {
        WCF_Catalogos.Hersan_CatalogosClient oCatalogos;
        List<DepartamentosBE> oList = new List<DepartamentosBE>();
        List<EntidadesBE> oEntidades = new List<EntidadesBE>();

        public frmDepartamentos()
        {
            InitializeComponent();
        }
        private void frmDepartamentos_Load(object sender, EventArgs e)
        {
            try {
                GroupDescriptor Entidades = new GroupDescriptor();
                Entidades.GroupNames.Add("NombreEntidad", ListSortDirection.Ascending);
                this.gvDatos.GroupDescriptors.Add(Entidades);

                LimpiarCampos();
                CargarEntidades();
                CargarDatos();
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrio un error al cargar la pantalla\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
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
            oCatalogos = new WCF_Catalogos.Hersan_CatalogosClient();
            DepartamentosBE obj = new DepartamentosBE();
            try {
                if (!ValidarCampos()) {
                    RadMessageBox.Show("Debe capturar todos los datos para continuar", this.Text, MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                    return;
                }
                if (oList.FindAll(item => item.Nombre.Trim() == txtNombre.Text.Trim() && item.Entidades.Id == int.Parse(cboEntidad.SelectedValue.ToString())).Count > 0 
                    && int.Parse(txtId.Text) == -1) {
                    RadMessageBox.Show("El departamento capturado ya existe, no es posible guardar", this.Text, MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                    LimpiarCampos();
                    return;
                }

                if (RadMessageBox.Show("Desea guardar los datos capturados...?", this.Text, MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.Yes) {                    
                    obj.Id = int.Parse(txtId.Text);
                    obj.Entidades.Id = int.Parse(cboEntidad.SelectedValue.ToString());
                    obj.Nombre = txtNombre.Text;
                    obj.Abrev = txtAbrev.Text;
                    obj.DatosUsuario.Estatus = chkEstatus.Checked;
                    obj.DatosUsuario.IdUsuarioCreo = BaseWinBP.UsuarioLogueado.ID;

                    //PROCESO DE GUARDADO Y ACTUALIZACION
                    if (txtId.Text == "-1") {
                        int Result = oCatalogos.ABCDEpartamentos_Guardar(obj);
                        if (Result == 0) {
                            RadMessageBox.Show("Ocurrió un error al guardar el departamento", this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
                        } else {
                            RadMessageBox.Show("Departamento guardado correctamente", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                            LimpiarCampos();
                            CargarDatos();
                        }
                    } else {
                        int Result = oCatalogos.ABCDEpartamentos_Actualizar(obj);
                        if (Result == 0) {
                            RadMessageBox.Show("Ocurrió un error al actualizar los datos", this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
                        } else {
                            RadMessageBox.Show("Información actualizada correctamente", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                            LimpiarCampos();
                            CargarDatos();
                        }
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
            DepartamentosBE obj = new DepartamentosBE();
            try {
                if (chkEstatus.Checked) {
                    if(RadMessageBox.Show("Esta acción dará de baja el departamento\nDesea continuar...?",this.Text, MessageBoxButtons.YesNo, RadMessageIcon.Question)== DialogResult.Yes) {
                        obj.Id = int.Parse(txtId.Text);
                        obj.Entidades.Id = int.Parse(cboEntidad.SelectedValue.ToString());
                        obj.Nombre = txtNombre.Text;
                        obj.Abrev = txtAbrev.Text;
                        obj.DatosUsuario.Estatus = false;
                        obj.DatosUsuario.IdUsuarioCreo = BaseWinBP.UsuarioLogueado.ID;

                        int Result = oCatalogos.ABCDEpartamentos_Actualizar(obj);
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
                RadMessageBox.Show("Ocurrio un error al dar de baja el departamento\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally {
                oCatalogos = null;
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
                if (gvDatos.RowCount > 0 && e.CurrentRow.ChildRows.Count == 0) {
                    cboEntidad.SelectedValue = int.Parse(e.CurrentRow.Cells["IdEntidad"].Value.ToString());
                    txtId.Text = e.CurrentRow.Cells["Id"].Value.ToString();
                    txtNombre.Text = e.CurrentRow.Cells["NombreDepto"].Value.ToString();
                    txtAbrev.Text = e.CurrentRow.Cells["Abrev"].Value.ToString();
                    chkEstatus.Checked = bool.Parse(e.CurrentRow.Cells["Estatus"].Value.ToString());
                }
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrio un error al seleccionar el registro\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }

        private void CargarDatos()
        {
            oCatalogos = new WCF_Catalogos.Hersan_CatalogosClient();
            try {
                oList = oCatalogos.ABCDepartamentos_Obtener();
                gvDatos.DataSource = oList;
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrio un error al cargar los departamentos\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally {
                oCatalogos = null;
            }
        }
        private void LimpiarCampos()
        {
            try {
                cboEntidad.SelectedIndex = 0;
                txtAbrev.Text = string.Empty;
                txtId.Text = "-1";                
                txtNombre.Text = string.Empty;
                chkEstatus.Checked = false;
                cboEntidad.SelectedIndex = 0;
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrio un error al limpiar los campos\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private bool ValidarCampos()
        {
            bool Flag = true;
            try {
                Flag = cboEntidad.SelectedValue != null ? false : true;
                Flag = txtNombre.Text.Trim().Length == 0 ? false : true;
                Flag = txtAbrev.Text.Trim().Length == 0 ? false : true;

                return Flag;
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
    }
}
