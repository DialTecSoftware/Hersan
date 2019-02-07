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

namespace Hersan.UI.Catalogos
{
    public partial class frmTiposContrato : Telerik.WinControls.UI.RadForm
    {

        WCF_Catalogos.Hersan_CatalogosClient oCatalogo = new WCF_Catalogos.Hersan_CatalogosClient();

        public frmTiposContrato()
        {
            InitializeComponent();
        }
        private void frmTiposContrato_Load(object sender, EventArgs e)
        { try {
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
        private void btnSalir_Click(object sender, EventArgs e)
        {
            try {
                this.Close();
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrio un error al cerrar la pantalla\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            oCatalogo = new WCF_Catalogos.Hersan_CatalogosClient();
            TiposContratoBE obj = new TiposContratoBE();
            try {
                if (!ValidarCampos()) {
                    RadMessageBox.Show("Debe capturar todos los datos para continuar", this.Text, MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                    return;
                }
                obj.Id = int.Parse(txtId.Text);
                obj.Nombre = txtNombre.Text;
                obj.Abrev = txtAbrev.Text;
                obj.DatosUsuario.Estatus = chkEstatus.Checked;
                obj.DatosUsuario.IdUsuarioCreo = BaseWinBP.UsuarioLogueado.ID;

                //PROCESO DE GUARDADO Y ACTUALIZACION
                if (txtId.Text == "0") {
                    int Result = oCatalogo.ABCTiposContrato_Guardar(obj);
                    if (Result == 0) {
                        RadMessageBox.Show("Ocurrió un error al guardar el tipo de contrato", this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
                    } else {
                        RadMessageBox.Show("Departamento guardado correctamente", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                        LimpiarCampos();
                        CargarDatos();
                    }
                } else {
                    int Result = oCatalogo.ABCTiposContrato_Actualizar(obj);
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
                oCatalogo = null;
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            oCatalogo = new WCF_Catalogos.Hersan_CatalogosClient();
            TiposContratoBE obj = new TiposContratoBE();
            try {
                if (chkEstatus.Checked) {
                    if (RadMessageBox.Show("Esta acción dará de baja el tipo de contrato\nDesea continuar...?", this.Text, MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.Yes) {
                        obj.Id = int.Parse(txtId.Text);
                        obj.Nombre = txtNombre.Text;
                        obj.Abrev = txtAbrev.Text;
                        obj.DatosUsuario.Estatus = false;
                        //obj.DatosUsuario.IdUsuarioCreo = BaseWinBP.UsuarioLogueado.ID;
                        obj.DatosUsuario.IdUsuarioCreo = 2;

                        int Result = oCatalogo.ABCTiposContrato_Actualizar(obj);
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
                RadMessageBox.Show("Ocurrio un error al dar de baja el tipo de contrato\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally {
                oCatalogo = null;
            }
        }
      

        public void CargarDatos()
        {
            try {
                gvDatos.DataSource = oCatalogo.TiposContrato_Obtener();
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al cargar los tipos de contrato\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void LimpiarCampos()
        {
            try {
                txtNombre.Text = string.Empty;
                txtId.Text = "0";
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
                Flag = txtNombre.Text.Trim().Length == 0 ? false : true;
                Flag = txtAbrev.Text.Trim().Length == 0 ? false : true;

                return Flag;
            } catch (Exception ex) {
                throw ex;
            }
        }

        private void gvDatos_CurrentRowChanged_1(object sender, Telerik.WinControls.UI.CurrentRowChangedEventArgs e)
        {
            try {
                if (gvDatos.RowCount > 0) {
                    txtId.Text = gvDatos.Rows[e.CurrentRow.Index].Cells["Id"].Value.ToString();
                    txtNombre.Text = gvDatos.Rows[e.CurrentRow.Index].Cells["Nombre"].Value.ToString();
                    txtAbrev.Text = gvDatos.Rows[e.CurrentRow.Index].Cells["Abrev"].Value.ToString();
                    chkEstatus.Checked = bool.Parse(gvDatos.Rows[e.CurrentRow.Index].Cells["Estatus"].Value.ToString());
                }
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrio un error al seleccionar el registro\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
    }
}
