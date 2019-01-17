using Hersan.Entidades.Catalogos;
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
    public partial class frmEntidades : Telerik.WinControls.UI.RadForm
    {

        WCF_Catalogos.Hersan_CatalogosClient oCatalogo = new WCF_Catalogos.Hersan_CatalogosClient();
        public frmEntidades()
        {
            InitializeComponent();
        }

        private void frmEntidades_Load(object sender, EventArgs e)
        {
            try {
                CargarEntidades();
                CargarEmpresas();
            } catch (Exception ex) {

                RadMessageBox.Show("Ocurrio un error al cargar la pantalla\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }

        public void CargarEntidades()
        {
            try {
                gvDatos.DataSource = oCatalogo.Entidades_Obtener();
               
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrio un error al cargar las entidades\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }

        private void gvDatos_Click(object sender, EventArgs e)
        {

        }

        private void gvDatos_CurrentRowChanged(object sender, Telerik.WinControls.UI.CurrentRowChangedEventArgs e)
        {
            try {
                if (gvDatos.RowCount > 0) {
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

        private void LimpiarCampos()
        {
            try {
                txtNombre.Text = string.Empty;
                txtIdEmpresa.Text = "0";
                cboEmp.SelectedIndex = -1;
                txtId.Text = "0";
                txtAbrev.Text = string.Empty;
                chkEstatus.Checked = false;
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrio un error al limpiar los campos\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
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
            EntidadesBE obj = new EntidadesBE();
            try {
                obj.Id = int.Parse(txtId.Text);
                obj.Empresas.Id = int.Parse(cboEmp.SelectedValue.ToString());
                obj.Nombre = txtNombre.Text;
                obj.Abrev = txtAbrev.Text;
                obj.DatosUsuario.Estatus = chkEstatus.Checked;
                //obj.DatosUsuario.IdUsuarioCreo = BaseWinBP.UsuarioLogueado.ID;
                obj.DatosUsuario.IdUsuarioCreo = 2;

                //PROCESO DE GUARDADO Y ACTUALIZACION
                if (txtId.Text == "0") {
                    int Result = oCatalogo.ABCEntidades_Guardar(obj);
                    if (Result == 0) {
                        RadMessageBox.Show("Ocurrió un error al guardar la entidad", this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
                    } else {
                        RadMessageBox.Show("Entidad guardada correctamente", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                        LimpiarCampos();
                        CargarEntidades();
                    }
                } else {
                    int Result = oCatalogo.ABCEntidades_Actualizar(obj);
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
                    if (RadMessageBox.Show("Esta acción dará de baja la entidad\nDesea continuar...?", this.Text, MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.Yes) {
                        obj.Id = int.Parse(txtId.Text);
                        obj.Empresas.Id = int.Parse(txtIdEmpresa.Text);
                        obj.Nombre = txtNombre.Text;
                        obj.Abrev = txtAbrev.Text;
                        obj.DatosUsuario.Estatus = false;
                        //obj.DatosUsuario.IdUsuarioCreo = BaseWinBP.UsuarioLogueado.ID;
                        obj.DatosUsuario.IdUsuarioCreo = 3;

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

        private void commandBarLabel1_Click(object sender, EventArgs e)
        {

        }
    }
    }

