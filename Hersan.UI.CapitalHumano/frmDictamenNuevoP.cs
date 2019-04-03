using Hersan.Entidades.CapitalHumano;
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
using Telerik.WinControls.UI.Docking;

namespace Hersan.UI.CapitalHumano
{
    public partial class frmDictamenNuevoP : Telerik.WinControls.UI.RadForm
    {

        CapitalHumano.WCF_CHumano.Hersan_CHumanoClient oCHumano;
        List<NuevoPuestoBE> oList = new List<NuevoPuestoBE>();
        List<EntidadesBE> oEntidades = new List<EntidadesBE>();
        List<DictamenNuevoPuestoBE> list = new List<DictamenNuevoPuestoBE>();

        private void LimpiarCampos()
        {
            list.Clear();
            txtId.Text = "0";
            lblNombre.Text = "";
            lblOcupantes.Text = "";
            txtJustif.Text = "";
            lblSueldo.Text = "";
            lblEntidad.Text = "";
            lblDepto.Text = "";
            txtIdNuevoP.Text = "";
            txtIndicad.Text = "";
            txtJustif.Text = "";
            txtNecesidades.Text = "";
            txtObjetivos.Text = "";
            txtPrestaciones.Text = "";
            txtPuestosCargo.Text = "";
            txtResultados.Text = "";
            txtOpinionesCH.Text = "";
            txtOpinionesDG.Text = "";
            
         

        }
        private void CargarNuevosPuestos()
        {
            oCHumano = new CapitalHumano.WCF_CHumano.Hersan_CHumanoClient();
            try {
                oList = oCHumano.CHU_NuevoPuesto_Obtener(BaseWinBP.UsuarioLogueado.ID);
                gvDatos.DataSource = oList;
                //gvDatos.ClearSelection();
                btnGuardar.Enabled = false;
                btnEliminar.Enabled = false;

            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrio un error al cargar las propuestas de puestos\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally { oCHumano = null; }
        }
        private void CargarElementos_Dictamen()
        {
            oCHumano = new WCF_CHumano.Hersan_CHumanoClient();
            try {
                DockWindow activeDocument = this.radDock1.DocumentManager.ActiveDocument;

                list = oCHumano.CHU_DictamenNuevoP_Obtener();
                gvDictamenes.DataSource = list;
                //gvDictamenes.ClearSelection();
                btnNuevo.Enabled = false;
                btnGuardar.Enabled = true;
                btnEliminar.Enabled = true;

            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrio un error al cargar los elementos del dictamen\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally {
                oCHumano = null;
            }
        }
        private bool ValidarCampos()
        {
            bool Flag = true;
            try {
                Flag = txtOpinionesCH.Text.Trim().Length == 0 ? false : true;
                Flag = txtOpinionesDG.Text.Trim().Length == 0 ? false : true;


                return Flag;
            } catch (Exception ex) {
                throw ex;
            }
        }
        public frmDictamenNuevoP()
        {
            InitializeComponent();
        }

        private void frmDictamenNuevoP_Load(object sender, EventArgs e)
        {
            try {
                CargarNuevosPuestos();
                lblfecha.Text = DateTime.Now.ToLongDateString();
                btnNuevo.Enabled = false;
                rdbAceptado.IsChecked = true;
                documentTabStrip1.SelectedTab = this.DockNuevoP;

            } catch (Exception) {

                throw;
            }

        }
        private void gvDatos_CurrentRowChanged(object sender, Telerik.WinControls.UI.CurrentRowChangedEventArgs e)
        {
            try {

                if (gvDatos.RowCount > 0 && e.CurrentRow.ChildRows.Count == 0) {
                    btnNuevo.Enabled = true;
                    txtIdNuevoP.Text = e.CurrentRow.Cells["Id"].Value.ToString();
                    txtJustif.Text = e.CurrentRow.Cells["Justificacion"].Value.ToString();
                    lblNombre.Text = e.CurrentRow.Cells["Nombre"].Value.ToString();
                    txtIndicad.Text = e.CurrentRow.Cells["Indicadores"].Value.ToString();
                    lblSueldo.Text = (e.CurrentRow.Cells["Sueldo"].Value.ToString());
                    lblDepto.Text = (e.CurrentRow.Cells["DEP_Nombre"].Value.ToString());
                    lblEntidad.Text = (e.CurrentRow.Cells["ENT_Nombre"].Value.ToString());
                    lblOcupantes.Text = (e.CurrentRow.Cells["Ocupantes"].Value.ToString());
                    txtResultados.Text = (e.CurrentRow.Cells["Resultados"].Value.ToString());
                    txtObjetivos.Text = (e.CurrentRow.Cells["Objetivos"].Value.ToString());
                    txtPrestaciones.Text = e.CurrentRow.Cells["Prestaciones"].Value.ToString();
                    txtNecesidades.Text = (e.CurrentRow.Cells["Necesidades"].Value.ToString());
                    txtPuestosCargo.Text = (e.CurrentRow.Cells["PuestosCargo"].Value.ToString());
                }
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrio un error al seleccionar el registro\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void txtPuestosCargo_TextChanged(object sender, EventArgs e)
        {

        }
        private void documentTabStrip1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try {
                if (documentTabStrip1.SelectedTab == this.DockDictamen) {
                    gvDatos.DataSource = null;
                    LimpiarCampos();
                    CargarElementos_Dictamen();

                } else if (documentTabStrip1.SelectedTab == this.DockNuevoP) {
                    gvDictamenes.DataSource = null;
                    LimpiarCampos();
                    CargarNuevosPuestos();

                }
            } catch (Exception) {

                throw;
            }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            oCHumano = new WCF_CHumano.Hersan_CHumanoClient();
            DictamenNuevoPuestoBE obj = new DictamenNuevoPuestoBE();

            try {
                if (!ValidarCampos()) {
                    RadMessageBox.Show("Debe capturar todos los datos para continuar", this.Text, MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                    btnGuardar.Enabled = false;
                    LimpiarCampos();
                    return;
                }
                list = oCHumano.CHU_DictamenNuevoP_Obtener();
                if (list.FindAll(item => item.NuevoPuesto.Id.ToString() == txtIdNuevoP.Text.Trim()).Count > 0
                   && int.Parse(txtId.Text) == -1) {
                    RadMessageBox.Show("La información capturada ya existe, no es posible guardar", this.Text, MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                    btnGuardar.Enabled = false;
                    LimpiarCampos();
                    return;
                }



                if (RadMessageBox.Show("Desea guardar los datos capturados...?", this.Text, MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.Yes) {
                    bool myItem = rdbAceptado.IsChecked;
                    if (rdbAceptado.IsChecked == true) {
                        obj.Autorizado = true;
                    } else {
                        obj.Autorizado = false;
                    }

                    obj.NuevoPuesto.Id = int.Parse(txtIdNuevoP.Text);
                    obj.Id = int.Parse(txtId.Text);
                    obj.OpinionesCH = txtOpinionesCH.Text;
                    obj.OpinionesDG = txtOpinionesDG.Text;
                    obj.DatosUsuario.IdUsuarioCreo = BaseWinBP.UsuarioLogueado.ID;
                    obj.DatosUsuario.Estatus = true;


                    //PROCESO DE GUARDADO Y ACTUALIZACION
                    if (txtId.Text == "-1") {
                        int Result = oCHumano.CHU_DictamenNuevoP_Guardar(obj);
                        if (Result == 0) {
                            RadMessageBox.Show("Ocurrió un error al guardar el nuevo dictamen", this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
                        } else {
                            RadMessageBox.Show("Elemento guardado correctamente", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                            LimpiarCampos();
                            CargarElementos_Dictamen();
                            documentTabStrip1.SelectedTab = this.DockDictamen;


                        }
                    } else {

                        int Result = oCHumano.CHU_DictamenNuevoP_Actualizar(obj);
                        if (Result == 0) {
                            RadMessageBox.Show("Ocurrió un error al actualizar los datos", this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
                        } else {
                            RadMessageBox.Show("Información actualizada correctamente", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                            LimpiarCampos();
                            CargarElementos_Dictamen();
                            documentTabStrip1.SelectedTab = this.DockDictamen;


                        }
                    }
                }

            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al actualizar la información\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally {
                oCHumano = null;
            }
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try {
                btnGuardar.Enabled = true;
                txtId.Text = "-1";
            } catch (Exception) {

                throw;
            }
        }
        private void gvDictamenes_CurrentRowChanged(object sender, Telerik.WinControls.UI.CurrentRowChangedEventArgs e)
        {
            try {
                if (gvDictamenes.RowCount > 0 && e.CurrentRow.ChildRows.Count == 0) {

                    txtIdNuevoP.Text = e.CurrentRow.Cells["Id_NVP"].Value.ToString();
                    txtId.Text = e.CurrentRow.Cells["Id"].Value.ToString();
                    txtJustif.Text = e.CurrentRow.Cells["Justificacion"].Value.ToString();
                    lblNombre.Text = e.CurrentRow.Cells["Nombre"].Value.ToString();
                    txtIndicad.Text = e.CurrentRow.Cells["Indicadores"].Value.ToString();
                    lblSueldo.Text = (e.CurrentRow.Cells["Sueldo"].Value.ToString());
                    lblDepto.Text = (e.CurrentRow.Cells["DEP_Nombre"].Value.ToString());
                    lblEntidad.Text = (e.CurrentRow.Cells["ENT_Nombre"].Value.ToString());
                    lblOcupantes.Text = (e.CurrentRow.Cells["Ocupantes"].Value.ToString());
                    txtResultados.Text = (e.CurrentRow.Cells["Resultados"].Value.ToString());
                    txtObjetivos.Text = (e.CurrentRow.Cells["Objetivos"].Value.ToString());
                    txtPrestaciones.Text = e.CurrentRow.Cells["Prestaciones"].Value.ToString();
                    txtNecesidades.Text = (e.CurrentRow.Cells["Necesidades"].Value.ToString());
                    txtOpinionesCH.Text = (e.CurrentRow.Cells["OpinionesCH"].Value.ToString());
                    txtOpinionesDG.Text = (e.CurrentRow.Cells["OpinionesDG"].Value.ToString());
                    txtPuestosCargo.Text = (e.CurrentRow.Cells["PuestosCargo"].Value.ToString());
                    bool myItem =bool.Parse (e.CurrentRow.Cells["Autorizado"].Value.ToString());
                  
                    if (myItem == true) {
                        rdbAceptado.IsChecked = true;
                    } else {
                        rdbRechazado.IsChecked = true;
                    }

                }
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrio un error al seleccionar el registro\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
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
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            oCHumano = new CapitalHumano.WCF_CHumano.Hersan_CHumanoClient();
            DictamenNuevoPuestoBE obj = new DictamenNuevoPuestoBE();
            try {
                //if (chkEstatus.Checked) {
                if (RadMessageBox.Show("Esta acción dará de baja la solicitud\nDesea continuar...?", this.Text, MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.Yes) {
                    bool myItem = rdbAceptado.IsChecked;
                    if (rdbAceptado.IsChecked == true) {
                        obj.Autorizado = true;
                    } else {
                        obj.Autorizado = false;
                    }
                    obj.NuevoPuesto.Id = int.Parse(txtIdNuevoP.Text);
                    obj.Id = int.Parse(txtId.Text);
                    obj.OpinionesCH = txtOpinionesCH.Text;
                    obj.OpinionesDG = txtOpinionesDG.Text;
                    obj.DatosUsuario.IdUsuarioCreo = BaseWinBP.UsuarioLogueado.ID;
                    obj.DatosUsuario.Estatus = false;

                    int Result = oCHumano.CHU_DictamenNuevoP_Actualizar(obj);
                    if (Result == 0) {
                        RadMessageBox.Show("Ocurrió un error al modificar los datos", this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
                    } else {
                        RadMessageBox.Show("Información actualizada correctamente", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                        LimpiarCampos();
                        CargarElementos_Dictamen();

                    }
                }
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrio un error al dar de baja la solicitud\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally {
                oCHumano = null;
            }
        }
    }
}

