using Hersan.Entidades.Calidad;
using Hersan.Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace Hersan.UI.Calidad
{
    public partial class frmParametrosCalidad : Telerik.WinControls.UI.RadForm
    {
        WCF_Catalogos.Hersan_CatalogosClient oCatalogos;
        WCF_Ensamble.Hersan_EnsambleClient oEnsamble;
        List<NormaBE> oList = new List<NormaBE>();

        public frmParametrosCalidad()
        {
            InitializeComponent();
        }
        private void frmParametrosCalidad_Load(object sender, EventArgs e)
        {
            try {
                LimpiarCampos();
                CargarColores();
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
            oEnsamble = new WCF_Ensamble.Hersan_EnsambleClient();

            try {
                if (txtNorma.Text.Trim().Length == 0) {
                    RadMessageBox.Show("Debe capturar todos los datos para continuar", this.Text, MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                    return;
                }

                foreach (GridViewRowInfo oRow in gvDatos.Rows) {
                    if (int.Parse(oRow.Cells["IdColor"].Value.ToString()) == int.Parse(cboColores.SelectedValue.ToString()) && int.Parse(txtId.Text) == -1) { 
                        RadMessageBox.Show("Ya se ha capturado la norma para el reflejante seleccionado", this.Text, MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                        LimpiarCampos();
                        return;
                    }
                }

                //if (txtId.Text == "0") {
                int Result = oEnsamble.CAL_ReflejantesNorma_Guardar(CrearTablasAuxiliares(), BaseWinBP.UsuarioLogueado.ID);
                if (Result == 0) {
                    RadMessageBox.Show("Ocurrió un error al guardar el color", this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
                } else {
                    RadMessageBox.Show("Norma asignada correctamente", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                    LimpiarCampos();
                    CargarDatos();
                }
                //} else {
                //    int Result = oEnsamble.CAL_ReflejantesNorma_Actualizar(CrearTablasAuxiliares(), BaseWinBP.UsuarioLogueado.ID, true);
                //    if (Result == 0) {
                //        RadMessageBox.Show("Ocurrió un error al actualizar los datos", this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
                //    } else {
                //        RadMessageBox.Show("Información actualizada correctamente", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                //        LimpiarCampos();
                //        CargarDatos();
                //    }
                //}
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al actualizar la información\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally {
                oCatalogos = null;
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            oEnsamble = new WCF_Ensamble.Hersan_EnsambleClient();
            try {
                if (chkEstatus.Checked) {
                    if (RadMessageBox.Show("Esta acción dará de baja la norma seleccionada\nDesea continuar...?", this.Text, MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.Yes) {
                        oList.ForEach(item => {
                            if (item.Id == int.Parse(txtId.Text)) {
                                item.DatosUsuario.Estatus = false;
                            }
                        });

                        int Result = oEnsamble.CAL_ReflejantesNorma_Actualizar(CrearTablasAuxiliares(),BaseWinBP.UsuarioLogueado.ID,false);
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
                RadMessageBox.Show("Ocurrio un error al dar de baja la norma\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
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
        private void txtNorma_KeyPress(object sender, KeyPressEventArgs e)
        {
            try {
                if (!BaseWinBP.isNumero(e.KeyChar)) {
                    e.Handled = true;
                }
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al capturar la norma\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void txtLimite_KeyPress(object sender, KeyPressEventArgs e)
        {
            try {
                if (BaseWinBP.isDecimal(e.KeyChar)) {
                    e.Handled = true;
                }
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al capturar el límite inferior\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }

        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try {
                if (txtNorma.Text.Trim().Length > 0) {
                    if ( oList.Find(item => item.Color.Id == int.Parse(cboColores.SelectedValue.ToString())) == null ){
                        NormaBE Obj = new NormaBE();
                        Obj.Id = 0;
                        Obj.Color.Id = int.Parse(cboColores.SelectedValue.ToString());
                        Obj.Color.Nombre = cboColores.Text;
                        Obj.Norma = int.Parse(txtNorma.Text);
                        oList.Add(Obj);

                        gvDatos.DataSource = null;
                        gvDatos.DataSource = oList;
                    } else {
                        RadMessageBox.Show("Ye se ha agregado el reflejante seleccionado", this.Text, MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                    }
                } else {
                    RadMessageBox.Show("Es necesario capturar la norma", this.Text, MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                }
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al agregar los datos\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void gvDatos_CurrentRowChanged(object sender, Telerik.WinControls.UI.CurrentRowChangedEventArgs e)
        {
            try {
                if (gvDatos.RowCount > 0) {
                    txtId.Text = e.CurrentRow.Cells["Id"].Value.ToString();
                    cboColores.SelectedValue = int.Parse(e.CurrentRow.Cells["IdColor"].Value.ToString());
                    txtNorma.Text = e.CurrentRow.Cells["Norma"].Value.ToString();
                    //txtLimite.Text = e.CurrentRow.Cells["Limite"].Value.ToString();
                    chkEstatus.Checked = bool.Parse(e.CurrentRow.Cells["Estatus"].Value.ToString());
                }
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrio un error al seleccionar el registro\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }

        private void CargarColores()
        {
            oCatalogos = new WCF_Catalogos.Hersan_CatalogosClient();
            try {
                cboColores.DisplayMember = "Nombre";
                cboColores.ValueMember = "Id";
                cboColores.DataSource = oCatalogos.ABC_Colores_Combo();
            } catch (Exception ex) {
                throw ex;
            }
        }
        private void LimpiarCampos()
        {
            try {
                txtId.Text = "-1";
                cboColores.SelectedIndex = 0;
                txtNorma.Clear();
                chkEstatus.Checked = true;
            } catch (Exception ex) {
                throw ex;
            }
        }
        private void CargarDatos()
        {
            oEnsamble = new WCF_Ensamble.Hersan_EnsambleClient();
            try {
                oList = oEnsamble.CAL_ReflejantesNorma_Obtener();
                gvDatos.DataSource = oList;
            } catch (Exception ex) {
                throw ex;
            } finally {
                oEnsamble = null;
            }
        }
        private DataTable CrearTablasAuxiliares()
        {
            DataTable oData;

            try {
                oData = new System.Data.DataTable("Datos");
                oData.Columns.Add("NOR_Id");
                oData.Columns.Add("COL_Id");
                oData.Columns.Add("NOR_Norma");
                oData.Columns.Add("NOR_Cav1");
                oData.Columns.Add("NOR_Cav2");
                oData.Columns.Add("NOR_Cav3");
                oData.Columns.Add("NOR_Cav4");
                oData.Columns.Add("NOR_Cav5");
                oData.Columns.Add("NOR_Cav6");
                oData.Columns.Add("NOR_Cav7");
                oData.Columns.Add("NOR_Cav8");
                oData.Columns.Add("NOR_Estatus");

                CargarTablas(ref oData);
            } catch (Exception ex) {
                throw ex;
            }
            return oData;
        }
        private void CargarTablas(ref DataTable oData)
        {
            try {
                foreach (var item in oList) {
                    DataRow oRow = oData.NewRow();
                    oRow["NOR_Id"] = item.Id;
                    oRow["COL_Id"] = item.Color.Id;
                    if (item.Color.Id == int.Parse(cboColores.SelectedValue.ToString())) {
                        oRow["NOR_Norma"] = int.Parse(txtNorma.Text) != item.Norma ? int.Parse(txtNorma.Text) : item.Norma;
                    } else {
                        oRow["NOR_Norma"] = item.Norma;
                    }
                    oRow["NOR_Cav1"] = item.Cav1;
                    oRow["NOR_Cav2"] = item.Cav2;
                    oRow["NOR_Cav3"] = item.Cav3;
                    oRow["NOR_Cav4"] = item.Cav4;
                    oRow["NOR_Cav5"] = item.Cav5;
                    oRow["NOR_Cav6"] = item.Cav6;
                    oRow["NOR_Cav7"] = item.Cav7;
                    oRow["NOR_Cav8"] = item.Cav8;
                    oRow["NOR_Estatus"] = item.DatosUsuario.Estatus;

                    oData.Rows.Add(oRow);
                }
            } catch (Exception ex) {
                throw ex;
            }
        }

    }
}
