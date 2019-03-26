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
    public partial class frmPuestos : Telerik.WinControls.UI.RadForm
    {
        WCF_Catalogos.Hersan_CatalogosClient oCatalogo;
        List<PuestosBE> oList = new List<PuestosBE>();
        List<EntidadesBE> oEntidades = new List<EntidadesBE>();

        public frmPuestos()
        {
            InitializeComponent();
        }
        private void frmPuestos_Load(object sender, EventArgs e)
        {
            try {
                GroupDescriptor Entidades = new GroupDescriptor();
                Entidades.GroupNames.Add("Entidad", ListSortDirection.Ascending);
                GroupDescriptor Depto = new GroupDescriptor();
                Depto.GroupNames.Add("NombreDepto", ListSortDirection.Ascending);
                this.gvPuestos.GroupDescriptors.Add(Entidades);
                this.gvPuestos.GroupDescriptors.Add(Depto);

                LimpiarCampos();
                CargarEntidades();
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
                if (!ValidarCampos()) {
                    RadMessageBox.Show("Debe capturar todos los datos para continuar", this.Text, MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                    return;
                }
                if (oList.FindAll(item => item.Nombre.Trim() == txtNombre.Text.Trim() && item.Departamentos.Entidades.Id == int.Parse(cboEntidad.SelectedValue.ToString()) 
                    && item.Departamentos.Id == int.Parse(cboDeptos.SelectedValue.ToString())).Count > 0
                    && int.Parse(txtIdPuesto.Text) == 0) {
                    RadMessageBox.Show("La información capturada ya existe, no es posible guardar", this.Text, MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                    LimpiarCampos();
                    return;
                }

                if (RadMessageBox.Show("Desea guardar los datos capturados...?", this.Text, MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.Yes) {
                    obj.Id = int.Parse(txtIdPuesto.Text);
                    obj.Departamentos.Id = int.Parse(cboDeptos.SelectedValue.ToString());
                    obj.Nombre = txtNombre.Text;
                    obj.Abrev = txtAbrev.Text;
                    obj.Puntos =decimal.Parse( txtPuntos.Text);
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
            PuestosBE obj = new PuestosBE();
            try {
                if (chkEstatus.Checked) {
                    if (RadMessageBox.Show("Esta acción dará de baja el puesto\nDesea continuar...?", this.Text, MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.Yes) {
                        obj.Id = int.Parse(txtIdPuesto.Text);
                        obj.Departamentos.Id = int.Parse(txtIdDep.Text);
                        obj.Nombre = txtNombre.Text;
                        obj.Abrev = txtAbrev.Text;
                        obj.Puntos = decimal.Parse(txtPuntos.Text);
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
                if (gvPuestos.RowCount > 0 && e.CurrentRow.ChildRows.Count == 0) {
                    cboEntidad.SelectedValue = int.Parse(gvPuestos.CurrentRow.Cells["IdEntidad"].Value.ToString());
                    txtIdPuesto.Text = e.CurrentRow.Cells["Id"].Value.ToString();
                    txtIdDep.Text = e.CurrentRow.Cells["IdDepto"].Value.ToString();
                    txtNombre.Text = e.CurrentRow.Cells["Nombre"].Value.ToString();
                    txtAbrev.Text = e.CurrentRow.Cells["Abrev"].Value.ToString();
                    cboDeptos.SelectedValue = int.Parse(txtIdDep.Text);
                    chkEstatus.Checked = bool.Parse(e.CurrentRow.Cells["Estatus"].Value.ToString());
                    txtPuntos.Text = (e.CurrentRow.Cells["Puntos"].Value).ToString();
                }
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrio un error al seleccionar el registro\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void cboEntidad_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try {
                CargarDeptos();
            } catch (Exception ex) {
                throw ex;
            }
        }

        private void CargarEntidades()
        {
            oCatalogo = new WCF_Catalogos.Hersan_CatalogosClient();
            try {
                oEntidades = oCatalogo.Entidades_Combo(BaseWinBP.UsuarioLogueado.Empresa.Id);
                oEntidades.Add(new EntidadesBE { Id = 0, Nombre = "TODAS" });
                cboEntidad.ValueMember = "Id";
                cboEntidad.DisplayMember = "Nombre";
                cboEntidad.DataSource = oEntidades;
            } catch (Exception ex) {
                throw ex;
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
                cboDeptos.DataSource = oCatalogo.ABCDepartamentos_Combo(int.Parse(cboEntidad.SelectedValue.ToString()));
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al cargar los departamentos\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally {
                oCatalogo = null;
            }
        }
        private void LimpiarCampos()
        {
            try {
                cboEntidad.SelectedIndex = 0;
                cboDeptos.SelectedIndex = 0;
                txtIdDep.Text = "0";
                txtIdPuesto.Text = "0";
                txtPuntos.Text = "0";
                txtNombre.Text = string.Empty;
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
                Flag = txtPuntos.Text.Trim().Length == 0 ? false : true;
                return Flag;
            } catch (Exception ex) {
                throw ex;
            }
        }
       
    }
}
