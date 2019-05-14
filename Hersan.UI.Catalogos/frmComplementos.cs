using Hersan.Entidades.Catalogos;
using Hersan.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.Data;
using Telerik.WinControls.UI;

namespace Hersan.UI.Catalogos
{
    public partial class frmComplementos : Telerik.WinControls.UI.RadForm
    {
        WCF_Catalogos.Hersan_CatalogosClient oCatalogos;

        public frmComplementos()
        {
            InitializeComponent();
        }
        private void frmComplementos_Load(object sender, EventArgs e)
        {
            try {
                GroupDescriptor Reflejante = new GroupDescriptor();
                Reflejante.GroupNames.Add("Tipo", ListSortDirection.Ascending);
                this.gvDatos.GroupDescriptors.Add(Reflejante);

                LimpiarCampos();
                CargaColores();
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
            ReflejantesBE obj = new ReflejantesBE();

            try {
                if (txtClave.Text.Trim().Length == 0 ) {
                    RadMessageBox.Show("Debe capturar todos los datos para continuar", this.Text, MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                    return;
                }
                foreach (GridViewRowInfo oRow in gvDatos.Rows) {
                    if (oRow.Cells["Tipo"].Value.ToString() == cboTipo.Text 
                        && oRow.Cells["Clave"].Value.ToString() == txtClave.Text.Trim()
                        && oRow.Cells["IdColor"].Value.ToString() == cboColores.SelectedValue.ToString() 
                        && txtId.Text == "0") {
                        RadMessageBox.Show("El reflejante capturado ya existe", this.Text, MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                        LimpiarCampos();
                        return;
                    }
                }

                obj.Id = int.Parse(txtId.Text);
                obj.Clave = txtClave.Text;
                obj.Tipo = cboTipo.Text;
                obj.Color.Id = int.Parse(cboColores.SelectedValue.ToString());
                obj.DatosUsuario.Estatus = chkEstatus.Checked;
                obj.DatosUsuario.IdUsuarioCreo = BaseWinBP.UsuarioLogueado.ID;


                //PROCESO DE GUARDADO Y ACTUALIZACION
                if (txtId.Text == "0") {
                    int Result = oCatalogos.ENS_Reflejantes_Guardar(obj);
                    if (Result == 0) {
                        RadMessageBox.Show("Ocurrió un error al guardar el reflejante", this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
                    } else {
                        RadMessageBox.Show("Reflejante guardado correctamente", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                        LimpiarCampos();
                        CargarDatos();
                    }
                } else {
                    int Result = oCatalogos.ENS_Reflejantes_Actualizar(obj);
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
            ReflejantesBE obj = new ReflejantesBE();
            try {
                if (chkEstatus.Checked) {
                    if (RadMessageBox.Show("Esta acción dará de baja el reflejante\nDesea continuar...?", this.Text, MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.Yes) {
                        obj.Id = int.Parse(txtId.Text);
                        obj.Color.Id = int.Parse(cboColores.SelectedValue.ToString());
                        obj.Tipo = cboTipo.Text;
                        obj.Clave = txtClave.Text;
                        obj.DatosUsuario.Estatus = false;
                        obj.DatosUsuario.IdUsuarioCreo = BaseWinBP.UsuarioLogueado.ID;

                        int Result = oCatalogos.ENS_Reflejantes_Actualizar(obj);
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
                RadMessageBox.Show("Ocurrio un error al dar de baja el reflejante\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
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
                    cboColores.SelectedValue = int.Parse(e.CurrentRow.Cells["IdColor"].Value.ToString());
                    txtClave.Text = e.CurrentRow.Cells["Clave"].Value.ToString();
                    cboTipo.Text = e.CurrentRow.Cells["Tipo"].Value.ToString();
                    chkEstatus.Checked = bool.Parse(e.CurrentRow.Cells["Estatus"].Value.ToString());
                }
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrio un error al seleccionar el registro\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }

        private void LimpiarCampos()
        {
            try {
                txtId.Text = "0";                
                cboColores.SelectedIndex = -1;
                cboTipo.SelectedIndex = -1;
                txtClave.Clear();
                chkEstatus.Checked = true;
            } catch (Exception ex) {
                throw ex;
            }
        }
        private void CargaColores()
        {
            oCatalogos = new WCF_Catalogos.Hersan_CatalogosClient();
            try {                
                cboColores.ValueMember = "Id";
                cboColores.DisplayMember = "Nombre";
                cboColores.DataSource = oCatalogos.ABC_Colores_Combo();
            } catch (Exception ex) {
                throw ex;
            } finally {
                oCatalogos = null;
            }
        }
        private void CargarDatos()
        {
            oCatalogos = new WCF_Catalogos.Hersan_CatalogosClient();
            try {
                gvDatos.DataSource = oCatalogos.ENS_Reflejantes_Obtener(); 
            } catch (Exception ex) {
                throw ex;
            } finally {
                oCatalogos = null;
            }
        }

    }
}
