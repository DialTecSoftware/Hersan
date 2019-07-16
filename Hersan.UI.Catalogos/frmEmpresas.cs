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
    public partial class frmEmpresas : Telerik.WinControls.UI.RadForm
    {
        WCF_Catalogos.Hersan_CatalogosClient oCatalogos;
        List<EmpresasBE> oList = new List<EmpresasBE>();
        List<ColoniasBE> oColonia = new List<ColoniasBE>();

        public frmEmpresas()
        {
            InitializeComponent();
        }
        private void frmEmpresas_Load(object sender, EventArgs e)
        {
            try {
                LimpiarCampos();
                CargarDatos();
                CargaEstados();
                CargaRegimen();
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

                if (RadMessageBox.Show("Desea guardar los datos capturados...?", this.Text, MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.Yes) {
                   

                    //PROCESO DE GUARDADO Y ACTUALIZACION
                    if (txtId.Text == "0") {
                        Result = oCatalogos.ABC_Empresas_Guarda(CrearTablasAuxiliares(false), BaseWinBP.UsuarioLogueado.ID);
                        if (Result == 0) {
                            RadMessageBox.Show("Ocurrió un error al guardar a empresa", this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
                        } else {
                            RadMessageBox.Show("Empresa guardada correctamente", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                            LimpiarCampos();
                            CargarDatos();
                        }
                    } 
                    //else {
                    //    Result = oCatalogos.ABC_Agentes_Actualizar(obj);
                    //    if (Result == 0) {
                    //        RadMessageBox.Show("Ocurrió un error al actualizar los datos", this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
                    //    } else {
                    //        RadMessageBox.Show("Información actualizada correctamente", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                    //        LimpiarCampos();
                    //        CargarDatos();
                    //    }
                    //}
                }
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrio un error al guardar la información\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally {
                oCatalogos = null;
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            oCatalogos = new WCF_Catalogos.Hersan_CatalogosClient();
            EmpresasBE obj = new EmpresasBE();

            try {
                if (RadMessageBox.Show("Esta acción dará de baja la empresa\nDesea continuar...?", this.Text, MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.Yes) {
                    obj.Id = int.Parse(txtId.Text);
                    obj.DatosUsuario.Estatus = false;
                    obj.DatosUsuario.IdUsuarioCreo = BaseWinBP.UsuarioLogueado.ID;

                    //int Result = oCatalogos.ABC_Agentes_Actualizar(obj);
                    //if (Result == 0) {
                    //    RadMessageBox.Show("Ocurrió un error al modificar los datos", this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
                    //} else {
                    //    RadMessageBox.Show("Información actualizada correctamente", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                    //    LimpiarCampos();
                    //    CargarDatos();
                    //}
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
        private void cboEstado_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
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
        private void cboCiudad_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
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
        private void cboColonia_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
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
        private void gvDatos_CurrentRowChanged(object sender, Telerik.WinControls.UI.CurrentRowChangedEventArgs e)
        {
            try {
                if (gvDatos.RowCount > 0) {
                    var obj = oList.Find(item => item.Id == int.Parse(e.CurrentRow.Cells["Id"].Value.ToString()));
                    txtId.Text = obj.Id.ToString();
                    txtComercial.Text = obj.NombreComercial;
                    txtCorreo.Text = obj.Correo;
                    txtCP.Text = obj.Colonia.CP.ToString();
                    txtDireccion.Text = obj.Direccion;
                    txtExterior.Text = obj.NoExterior;
                    txtFiscal.Text = obj.NombreFiscal;
                    txtInterior.Text = obj.NoInterior;
                    txtRFC.Text = obj.RFC;
                    txtTelefono.Text = obj.Telefonos;
                    cboCiudad.SelectedValue = obj.Ciudad.Id;
                    cboColonia.SelectedValue = obj.Colonia.Id;
                    cboEstado.SelectedValue = obj.Estado.Id;
                    cboRegimen.SelectedValue = obj.RegimenFiscal.Id;
                }
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrio un error al seleccionar el registro\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }

        private void LimpiarCampos()
        {
            try {
                //txtId.Text = "0";
                //txtCorreo.Clear();
                //txtComision.Text = "0.00";
                //txtClave.Clear();
                //txtNombre.Clear();
                //chkEstatus.Checked = true;
            } catch (Exception ex) {
                throw ex;
            }
        }
        private void CargarDatos()
        {
            oCatalogos = new WCF_Catalogos.Hersan_CatalogosClient();
            try {
                oList = oCatalogos.ABCEmpresas_Obtener(0);
                gvDatos.DataSource = oList;
            } catch (Exception ex) {
                throw ex;
            } finally {
                oCatalogos = null;
            }
        }
        private bool ValidarCampos()
        {
            return false;
            //bool Flag = true;
            //try {
            //    Flag = txtNombre.Text.Trim().Length == 0 ? false : true;
            //    return Flag;
            //} catch (Exception ex) {
            //    throw ex;
            //}
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
        private void CargaRegimen()
        {
            WCF_Ensamble.Hersan_EnsambleClient oEnsamble = new WCF_Ensamble.Hersan_EnsambleClient();
            try {
                cboRegimen.DisplayMember = "Regimen";
                cboRegimen.ValueMember = "Id";
                cboRegimen.DataSource = oEnsamble.ABC_RegimenFiscal_Combo();
            } catch (Exception ex) {
                throw ex;
            } finally {
                oCatalogos = null;
            }
        }
        private DataTable CrearTablasAuxiliares(bool Delete)
        {
            DataTable oData;

            try {
                oData = new DataTable("Empresa");
                oData.Columns.Add("EMP_ID");
                oData.Columns.Add("EMP_NombreComercial");
                oData.Columns.Add("EMP_NombreFiscal");
                oData.Columns.Add("EMP_RFC");
                oData.Columns.Add("EMP_Direccion");
                oData.Columns.Add("EMP_NoExterior");
                oData.Columns.Add("EMP_NoInterior");
                oData.Columns.Add("COL_ID");
                oData.Columns.Add("PAI_ID");
                oData.Columns.Add("EST_ID");
                oData.Columns.Add("CIU_ID");
                oData.Columns.Add("REF_Id");
                oData.Columns.Add("EMP_Telefonos");
                oData.Columns.Add("EMP_CorreoElectronico");
                oData.Columns.Add("EMP_Contacto");
                oData.Columns.Add("EMP_Estatus");

                CargarTablas(ref oData, Delete);

            } catch (Exception ex) {
                throw ex;
            }
            return oData;
        }
        private void CargarTablas(ref DataTable oData, bool Delete)
        {
            try {                
                DataRow oRow = oData.NewRow();
                oRow["EMP_ID"] = int.Parse(txtId.Text);
                oRow["EMP_NombreComercial"] = txtComercial.Text;
                oRow["EMP_NombreFiscal"] = txtFiscal.Text;
                oRow["EMP_RFC"] = txtRFC.Text;
                oRow["EMP_Direccion"] = txtDireccion.Text;
                oRow["EMP_NoExterior"] = txtExterior.Text;
                oRow["EMP_NoInterior"] = txtInterior.Text;
                oRow["COL_ID"] = int.Parse(cboColonia.SelectedValue.ToString());
                oRow["PAI_ID"] = 1;
                oRow["EST_ID"] = int.Parse(cboEstado.SelectedValue.ToString());
                oRow["CIU_ID"] = int.Parse(cboCiudad.SelectedValue.ToString());
                oRow["REF_Id"] = int.Parse(cboRegimen.SelectedValue.ToString());
                oRow["EMP_Telefonos"] = txtTelefono.Text;
                oRow["EMP_CorreoElectronico"] = txtCorreo.Text;
                oRow["EMP_Contacto"] = string.Empty;
                oRow["EMP_Estatus"] = !Delete;

                oData.Rows.Add(oRow);
                
            } catch (Exception ex) {
                throw ex;
            }
        }

      
    }
}
