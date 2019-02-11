using Hersan.Entidades.CapitalHumano;
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
    public partial class frmContratos : Telerik.WinControls.UI.RadForm
    {
        WCF_Catalogos.Hersan_CatalogosClient oCatalogo = new WCF_Catalogos.Hersan_CatalogosClient();

        public frmContratos()
        {
            InitializeComponent();
        }

        public void CargarContratos()
        {
            try {
                gvDatos.DataSource = oCatalogo.ABCContratos_Obtener
();

            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrio un error al cargar los contratos\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void LimpiarCampos()
        {
            try {
                txtNombre.Text = string.Empty;
                txtIdDepto.Text = "0";
                txtIdTCO.Text = "0";
                txtIdCON.Text = "0";
                cboDepto.SelectedIndex = -1;
                cboTipoCon.SelectedIndex = -1;
                chkEstatus.Checked = false;
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrio un error al limpiar los campos\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void CargarDepartamentos()
        {
            oCatalogo = new WCF_Catalogos.Hersan_CatalogosClient();
            try {
                cboDepto.ValueMember = "ID";
                cboDepto.DisplayMember = "Nombre";
                cboDepto.DataSource = oCatalogo.ABCDepartamentos_Combo(1);
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al cargar los departamentos\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally {
                oCatalogo = null;
            }
        }
        private void CargarTiposContrato()
        {
            oCatalogo = new WCF_Catalogos.Hersan_CatalogosClient();
            try {
                cboTipoCon.ValueMember = "ID";
                cboTipoCon.DisplayMember = "Nombre";
                cboTipoCon.DataSource = oCatalogo.ABCTiposcontrato_Combo();
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al cargar los tipos de contrato\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally {
                oCatalogo = null;
            }
        }


        private void frmContratos_Load(object sender, EventArgs e)
        {
            try {
                LimpiarCampos();
                CargarContratos();
                CargarDepartamentos();
                CargarTiposContrato();
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
            ContratosBE obj = new ContratosBE();
            try {
                obj.Id = int.Parse(txtIdCON.Text);
                obj.Departamentos.Id = int.Parse(cboDepto.SelectedValue.ToString());
                obj.Nombre = txtNombre.Text;
                obj.TiposContrato.Id = int.Parse(cboTipoCon.SelectedValue.ToString());
                obj.DatosUsuario.Estatus = chkEstatus.Checked;
                obj.DatosUsuario.IdUsuarioCreo = BaseWinBP.UsuarioLogueado.ID;

                //PROCESO DE GUARDADO Y ACTUALIZACION
                if (txtIdCON.Text == "0") {
                    int Result = oCatalogo.ABCContratos_Guardar(obj);
                    if (Result == 0) {
                        RadMessageBox.Show("Ocurrió un error al guardar el contrato", this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
                    } else {
                        RadMessageBox.Show("Contrato guardado correctamente", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                        LimpiarCampos();
                        CargarContratos();
                    }
                } else {
                    int Result = oCatalogo.ABCContratos_Actualizar(obj);
                    if (Result == 0) {
                        RadMessageBox.Show("Ocurrió un error al actualizar los datos", this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
                    } else {
                        RadMessageBox.Show("Información actualizada correctamente", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                        LimpiarCampos();
                        CargarContratos();
                    }
                }
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al actualizar la información\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally {
                oCatalogo = null;
            }
        }
        private void gvDatos_CurrentRowChanged(object sender, Telerik.WinControls.UI.CurrentRowChangedEventArgs e)
        {
            try {
                if (gvDatos.RowCount > 0) {
                    txtIdCON.Text = gvDatos.CurrentRow.Cells["Id"].Value.ToString();
                    txtIdDepto.Text = gvDatos.CurrentRow.Cells["Id_Dep"].Value.ToString();
                    txtNombre.Text = gvDatos.CurrentRow.Cells["Nombre"].Value.ToString();
                    txtIdTCO.Text = gvDatos.CurrentRow.Cells["Id_TCO"].Value.ToString();
                    cboDepto.SelectedValue = int.Parse(txtIdDepto.Text);
                    cboTipoCon.SelectedValue = int.Parse(txtIdTCO.Text);
                    chkEstatus.Checked = bool.Parse(gvDatos.CurrentRow.Cells["Estatus"].Value.ToString());
                }
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrio un error al seleccionar el registro\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            oCatalogo = new WCF_Catalogos.Hersan_CatalogosClient();
            ContratosBE obj = new ContratosBE();
            try {
                if (chkEstatus.Checked) {
                    if (RadMessageBox.Show("Esta acción dará de baja el contrato\nDesea continuar...?", this.Text, MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.Yes) {
                        obj.Id = int.Parse(txtIdCON.Text);
                        obj.Departamentos.Id = int.Parse(cboDepto.SelectedValue.ToString());
                        obj.Nombre = txtNombre.Text;
                        obj.TiposContrato.Id = int.Parse(cboTipoCon.SelectedValue.ToString());
                        obj.DatosUsuario.Estatus = false;
                        obj.DatosUsuario.IdUsuarioCreo = BaseWinBP.UsuarioLogueado.ID;

                        int Result = oCatalogo.ABCContratos_Actualizar(obj);
                        if (Result == 0) {
                            RadMessageBox.Show("Ocurrió un error al modificar los datos", this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
                        } else {
                            RadMessageBox.Show("Información actualizada correctamente", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                            LimpiarCampos();
                            CargarContratos();
                        }
                    }
                }
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrio un error al dar de baja el contrato\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally {
                oCatalogo = null;
            }
        }

        private void gvDatos_Click(object sender, EventArgs e)
        {

        }
    }
}
