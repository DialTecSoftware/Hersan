using Hersan.Entidades.CapitalHumano;
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
    public partial class frmFunciones : Telerik.WinControls.UI.RadForm
    {
        WCF_Catalogos.Hersan_CatalogosClient oCatalogo = new WCF_Catalogos.Hersan_CatalogosClient();
        public frmFunciones()
        {
            InitializeComponent();
        }

        private void frmFunciones_Load(object sender, EventArgs e)
        {
            try {
                Cargar();

            } catch (Exception ex) {

                throw ex;
            }
        }

        public void Cargar()
        {
            try {
                gvDatos.DataSource = oCatalogo.ABCFunciones_Obtener();
            } catch (Exception ex) {
                throw ex;
            }
        }


        private void LimpiarCampos()
        {
            try {
                txtNombre.Text = string.Empty;
                txtId.Text = "0";
                chkEstatus.Checked = false;
                chkContinua.Checked = false;
            } catch (Exception ex) {
                throw ex;
            }
        }

        private void gvDatos_CurrentRowChanged(object sender, Telerik.WinControls.UI.CurrentRowChangedEventArgs e)
        {
            try {
                if (gvDatos.RowCount > 0) {
                    txtId.Text = gvDatos.Rows[e.CurrentRow.Index].Cells["Id"].Value.ToString();
                    txtNombre.Text = gvDatos.Rows[e.CurrentRow.Index].Cells["Nombre"].Value.ToString();
                    chkEstatus.Checked = bool.Parse(gvDatos.Rows[e.CurrentRow.Index].Cells["Estatus"].Value.ToString());
                    chkContinua.Checked = bool.Parse(gvDatos.Rows[e.CurrentRow.Index].Cells["Continua"].Value.ToString());
                }
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrio un error al cerrar la pantalla\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
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
            FuncionesBE obj = new FuncionesBE();
            try {
                obj.Id = int.Parse(txtId.Text);
                obj.Nombre = txtNombre.Text;
                obj.Continua = chkContinua.Checked;
                obj.DatosUsuario.Estatus = chkEstatus.Checked;
                //obj.DatosUsuario.IdUsuarioCreo = BaseWinBP.UsuarioLogueado.ID;
                obj.DatosUsuario.IdUsuarioCreo = 1;

                //PROCESO DE GUARDADO Y ACTUALIZACION
                if (txtId.Text == "0") {
                    int Result = oCatalogo.ABCFunciones_Guardar(obj);
                    if (Result == 0) {
                        RadMessageBox.Show("Ocurrió un error al guardar la función", this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
                    } else {
                        RadMessageBox.Show("Educacion guardada correctamente", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                        LimpiarCampos();
                        Cargar();
                    }
                } else {
                    int Result = oCatalogo.ABCFunciones_Actualizar(obj);
                    if (Result == 0) {
                        RadMessageBox.Show("Ocurrió un error al actualizar los datos", this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
                    } else {
                        RadMessageBox.Show("Información actualizada correctamente", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                        LimpiarCampos();
                        Cargar();
                    }
                }
            } catch (Exception ex) {
                throw;
            } finally {
                oCatalogo = null;
            }
        
    }




        private void btnEliminar_Click(object sender, EventArgs e)
        {
            FuncionesBE obj = new FuncionesBE();
            try {
                if (chkEstatus.Checked) {
                    if (RadMessageBox.Show("Esta acción dará de baja la función\nDesea continuar...?", this.Text, MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.Yes) {
                        obj.Id = int.Parse(txtId.Text);
                        obj.Nombre = txtNombre.Text;
                        obj.Continua = false;
                        obj.DatosUsuario.Estatus = false;
                        //obj.DatosUsuario.IdUsuarioCreo = BaseWinBP.UsuarioLogueado.ID;
                        obj.DatosUsuario.IdUsuarioCreo = 2;

                        int Result = oCatalogo.ABCFunciones_Actualizar(obj);
                        if (Result == 0) {
                            RadMessageBox.Show("Ocurrió un error al modificar los datos", this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
                        } else {
                            RadMessageBox.Show("Información actualizada correctamente", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                            LimpiarCampos();
                            Cargar();
                        }
                    }
                }
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrio un error al cerrar la pantalla\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally {
                oCatalogo = null;
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
    }
}
