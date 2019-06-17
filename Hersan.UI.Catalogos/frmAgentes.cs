using Hersan.Entidades.Catalogos;
using Hersan.Negocio;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Telerik.WinControls;

namespace Hersan.UI.Catalogos
{
    public partial class frmAgentes : Telerik.WinControls.UI.RadForm
    {
        WCF_Catalogos.Hersan_CatalogosClient oCatalogos;
        List<AgentesBE> oList = new List<AgentesBE>();

        public frmAgentes()
        {
            InitializeComponent();
        }
        private void frmAgentes_Load(object sender, EventArgs e)
        {
            try {

                LimpiarCampos();
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
            AgentesBE obj = new AgentesBE();
            int Result = 0;

            try {
                if (!ValidarCampos()) {
                    RadMessageBox.Show("Debe capturar todos los datos para continuar", this.Text, MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                    return;
                }
                if (oList.FindAll(item => item.Nombre.Trim() == txtNombre.Text.Trim()).Count > 0 && int.Parse(txtId.Text) == 0) {
                    RadMessageBox.Show("La información capturada ya existe, no es posible guardar", this.Text, MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                    LimpiarCampos();
                    return;
                }

                if (RadMessageBox.Show("Desea guardar los datos capturados...?", this.Text, MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.Yes) {
                    obj.Id = int.Parse(txtId.Text);
                    obj.Nombre = txtNombre.Text;
                    obj.Clave = txtClave.Text;
                    obj.Correo = txtCorreo.Text;
                    obj.Comision = decimal.Parse(txtComision.Text);
                    obj.DatosUsuario.Estatus = chkEstatus.Checked;
                    obj.DatosUsuario.IdUsuarioCreo = BaseWinBP.UsuarioLogueado.ID;

                    //PROCESO DE GUARDADO Y ACTUALIZACION
                    if (txtId.Text == "0") {
                        Result = oCatalogos.ABC_Agentes_Guardar(obj);
                        if (Result == 0) {
                            RadMessageBox.Show("Ocurrió un error al guardar el agente", this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
                        } else {
                            RadMessageBox.Show("Agente guardado correctamente", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                            LimpiarCampos();
                            CargarDatos();
                        }
                    } else {
                        Result = oCatalogos.ABC_Agentes_Actualizar(obj);
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
                RadMessageBox.Show("Ocurrio un error al actualizar la información\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally {
                oCatalogos = null;
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            oCatalogos = new WCF_Catalogos.Hersan_CatalogosClient();
            AgentesBE obj = new AgentesBE();

            try {
                if (chkEstatus.Checked) {
                    if (RadMessageBox.Show("Esta acción dará de baja al Agente\nDesea continuar...?", this.Text, MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.Yes) {
                        obj.Id = int.Parse(txtId.Text);
                        obj.Nombre = txtNombre.Text;
                        obj.Clave = txtClave.Text;
                        obj.Correo = txtCorreo.Text;
                        obj.Comision = decimal.Parse(txtComision.Text);
                        obj.DatosUsuario.Estatus = false;
                        obj.DatosUsuario.IdUsuarioCreo = BaseWinBP.UsuarioLogueado.ID;

                        int Result = oCatalogos.ABC_Agentes_Actualizar(obj);
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
                RadMessageBox.Show("Ocurrio un error al dar de baja al Agente\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
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
        private void txtComision_KeyPress(object sender, KeyPressEventArgs e)
        {
            try {
                if (BaseWinBP.isDecimal(e.KeyChar))
                    e.Handled = true;
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al capturar la comisión\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void gvDatos_CurrentRowChanged(object sender, Telerik.WinControls.UI.CurrentRowChangedEventArgs e)
        {
            try {
                if (gvDatos.RowCount > 0 ) {
                    txtId.Text = e.CurrentRow.Cells["Id"].Value.ToString();
                    txtClave.Text = e.CurrentRow.Cells["Clave"].Value.ToString();
                    txtNombre.Text = e.CurrentRow.Cells["Nombre"].Value.ToString();
                    txtCorreo.Text = e.CurrentRow.Cells["Correo"].Value.ToString();
                    txtComision.Text = e.CurrentRow.Cells["Comision"].Value.ToString();
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
                txtCorreo.Clear();
                txtComision.Text = "0.00";
                txtClave.Clear();
                txtNombre.Clear();
                chkEstatus.Checked = true;
            } catch (Exception ex) {
                throw ex;
            }
        }
        private void CargarDatos()
        {
            oCatalogos = new WCF_Catalogos.Hersan_CatalogosClient();
            try {
                oList = oCatalogos.ABC_Agentes_Obtener();
                gvDatos.DataSource = oList;
            } catch (Exception ex) {
                throw ex;
            } finally {
                oCatalogos = null;
            }
        }
        private bool ValidarCampos()
        {
            bool Flag = true;
            try {
                Flag = txtNombre.Text.Trim().Length == 0 ? false : true;
                return Flag;
            } catch (Exception ex) {
                throw ex;
            }
        }

    }
}
