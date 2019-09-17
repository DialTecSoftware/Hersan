using Hersan.Entidades.Catalogos;
using Hersan.Negocio;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Telerik.WinControls;

namespace Hersan.UI.Catalogos
{
    public partial class frmProveedor : Telerik.WinControls.UI.RadForm
    {
        WCF_Catalogos.Hersan_CatalogosClient oCatalogos;
        List<ProveedorBE> oList = new List<ProveedorBE>();
        List<ColoniasBE> oColonia = new List<ColoniasBE>();

        public frmProveedor()
        {
            InitializeComponent();
        }
        private void FrmProveedor_Load(object sender, EventArgs e)
        {
            try {
                LimpiarCampos();                
                CargaEstados();
                CargarDatos();
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al cargar la pantalla\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            try {
                LimpiarCampos();
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al limpiar los campos\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            oCatalogos = new WCF_Catalogos.Hersan_CatalogosClient();
            int Result = 0;

            try {
                if (!ValidarCampos()) {
                    RadMessageBox.Show("Debe capturar todos los datos para continuar", this.Text, MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                    return;
                }
                if (oList.FindAll(item => item.RFC.Trim() == txtRFC.Text.Trim()).Count > 0 && int.Parse(txtId.Text) == 0) {
                    RadMessageBox.Show("La información capturada ya existe, no es posible guardar", this.Text, MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                    LimpiarCampos();
                    return;
                }

                ProveedorBE obj = new ProveedorBE();
                obj.Id = int.Parse(txtId.Text);
                obj.Empresa.Id = BaseWinBP.UsuarioLogueado.Empresa.Id;
                obj.Nombre = txtComercial.Text;
                obj.Fiscal = txtFiscal.Text;
                obj.RFC = txtRFC.Text;
                obj.Correo = txtCorreo.Text;
                obj.Telefono = txtTelefono.Text;
                obj.Direccion = txtDireccion.Text;
                obj.Estado.Id = int.Parse(cboEstado.SelectedValue.ToString());
                obj.Ciudad.Id = int.Parse(cboCiudad.SelectedValue.ToString());
                obj.Colonia.Id = int.Parse(cboColonia.SelectedValue.ToString());
                obj.DatosUsuario.IdUsuarioCreo = BaseWinBP.UsuarioLogueado.ID;
                obj.DatosUsuario.Estatus = chkEstatus.Checked;

                if (RadMessageBox.Show("Desea guardar los datos capturados...?", this.Text, MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.Yes) {
                    //PROCESO DE GUARDADO Y ACTUALIZACION
                    if (txtId.Text == "0") {
                        Result = oCatalogos.ABC_Proveedores_Guardar(obj);
                        if (Result == 0) {
                            RadMessageBox.Show("Ocurrió un error al guardar el proveedor", this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
                        } else {
                            RadMessageBox.Show("Proveedor guardado correctamente", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                            LimpiarCampos();
                            CargarDatos();
                        }
                    } else {
                        Result = oCatalogos.ABC_Proveedores_Actualizar(obj);
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
                RadMessageBox.Show("Ocurrio un error al guardar la información\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally {
                oCatalogos = null;
            }
        }
        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            oCatalogos = new WCF_Catalogos.Hersan_CatalogosClient();
            try {
                if (RadMessageBox.Show("Esta acción dará de baja al proveedor\nDesea continuar...?", this.Text, MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.Yes) {
                    ProveedorBE obj = new ProveedorBE();
                    obj.Id = int.Parse(txtId.Text);
                    obj.Nombre = txtComercial.Text;
                    obj.Correo = txtCorreo.Text;
                    obj.Telefono = txtTelefono.Text;
                    obj.Direccion = txtDireccion.Text;
                    obj.Estado.Id = int.Parse(cboEstado.SelectedValue.ToString());
                    obj.Ciudad.Id = int.Parse(cboCiudad.SelectedValue.ToString());
                    obj.Colonia.Id = int.Parse(cboColonia.SelectedValue.ToString());
                    obj.DatosUsuario.IdUsuarioCreo = BaseWinBP.UsuarioLogueado.ID;
                    obj.DatosUsuario.Estatus = false;
                    
                    if (oCatalogos.ABC_Proveedores_Actualizar(obj) == 0) {
                        RadMessageBox.Show("Ocurrió un error al dar de baja al proveedor", this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
                    } else {
                        RadMessageBox.Show("Información actualizada correctamente", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                        LimpiarCampos();
                        CargarDatos();
                    }
                }
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrio un error al dar de baja al proveedor\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally {
                oCatalogos = null;
            }
        }
        private void BtnSalir_Click(object sender, EventArgs e)
        {
            try {
                this.Close();
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al cerrar la pantalla\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void CboEstado_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            oCatalogos = new WCF_Catalogos.Hersan_CatalogosClient();
            try {
                if (cboEstado.SelectedValue != null) {
                    cboCiudad.ValueMember = "Id";
                    cboCiudad.DisplayMember = "Nombre";
                    cboCiudad.DataSource = oCatalogos.ABCCiudades_Obtener(int.Parse(cboEstado.SelectedValue.ToString()));
                }
            } catch (Exception ex) {
                throw ex;
            } finally {
                oCatalogos = null;
            }
        }
        private void CboCiudad_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            oCatalogos = new WCF_Catalogos.Hersan_CatalogosClient();
            try {
                if (cboCiudad.SelectedValue != null) {
                    oColonia = oCatalogos.ABCColonias_Obtener(int.Parse(cboEstado.SelectedValue.ToString()), int.Parse(cboCiudad.SelectedValue.ToString()));
                    cboColonia.ValueMember = "Id";
                    cboColonia.DisplayMember = "Nombre";
                    cboColonia.DataSource = oColonia;
                }
            } catch (Exception ex) {
                throw ex;
            } finally {
                oCatalogos = null;
            }
        }
        private void CboColonia_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try {
                if (cboColonia.SelectedValue != null) {
                    txtCP.Text = oColonia.Find(item => item.Id == int.Parse(cboColonia.SelectedValue.ToString())).CP.ToString();
                }
            } catch (Exception ex) {
                throw ex;
            } finally {
                oCatalogos = null;
            }
        }
        private void GvDatos_CurrentRowChanged(object sender, Telerik.WinControls.UI.CurrentRowChangedEventArgs e)
        {
            try {
                if (gvDatos.RowCount > 0 && e.CurrentRow.ChildRows.Count == 0) {
                    var obj = oList.Find(item => item.Id == int.Parse(e.CurrentRow.Cells["Id"].Value.ToString()));
                    txtId.Text = obj.Id.ToString();
                    txtComercial.Text = obj.Nombre;
                    txtCorreo.Text = obj.Correo;
                    txtCP.Text = obj.Colonia.CP.ToString();
                    txtDireccion.Text = obj.Direccion;
                    txtFiscal.Text = obj.Fiscal;
                    txtRFC.Text = obj.RFC;
                    txtTelefono.Text = obj.Telefono;
                    cboEstado.SelectedValue = obj.Estado.Id;
                    cboCiudad.SelectedValue = obj.Ciudad.Id;
                    cboColonia.SelectedValue = obj.Colonia.Id;
                    chkEstatus.Checked = obj.DatosUsuario.Estatus;
                }
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrio un error al seleccionar el registro\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }


        private void LimpiarCampos()
        {
            try {
                foreach (Control ctrl in this.radPanel1.Controls) {
                    if (ctrl is Telerik.WinControls.UI.RadTextBox) {
                        ctrl.Text = "";
                    }
                }
                txtId.Text = "0";
                txtCorreo.Clear();
                cboEstado.SelectedIndex = 0;
                cboCiudad.SelectedIndex = 0;
                cboColonia.SelectedIndex = 0;

                gvDatos.ClearSelection();
            } catch (Exception ex) {
                throw ex;
            }
        }
        private void CargarDatos()
        {
            oCatalogos = new WCF_Catalogos.Hersan_CatalogosClient();
            try {
                oList = oCatalogos.ABC_Proveedores_Obtener(BaseWinBP.UsuarioLogueado.Empresa.Id);
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
                Flag = txtRFC.Text.Trim().Length == 0 || txtFiscal.Text.Trim().Length == 0 ? false : true;
                return Flag;
            } catch (Exception ex) {
                throw ex;
            }
        }
        private void CargaEstados()
        {
            oCatalogos = new WCF_Catalogos.Hersan_CatalogosClient();
            try {
                cboEstado.DisplayMember = "Nombre";
                cboEstado.ValueMember = "Id";
                cboEstado.DataSource = oCatalogos.ABCEstados_Obtener(1);
            } catch (Exception ex) {
                throw ex;
            } finally {
                oCatalogos = null;
            }
        }

    }
}
