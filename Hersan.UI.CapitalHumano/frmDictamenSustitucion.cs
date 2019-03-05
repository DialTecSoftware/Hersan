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
using Telerik.WinControls.Data;
using Telerik.WinControls.UI.Docking;

namespace Hersan.UI.CapitalHumano
{
    public partial class frmDictamenSustitucion : Telerik.WinControls.UI.RadForm
    {
        public frmDictamenSustitucion()
        {
            InitializeComponent();
        }

        CapitalHumano.WCF_CHumano.Hersan_CHumanoClient oCHumano;
        List<SolicitudPersonalBE> oList = new List<SolicitudPersonalBE>();
        List<DictamenSustitucionBE> list = new List<DictamenSustitucionBE>();
        List<EntidadesBE> oEntidades = new List<EntidadesBE>();

        private void LimpiarCampos()
        {
            try {
                txtJustif.Text = string.Empty;
                txtIndicad.Text = string.Empty;
                lblContrato.Text = string.Empty;
                lblDepto.Text = string.Empty;
                lblEntidad.Text = string.Empty;
                txtIdSu.Text = string.Empty;
                lblPuesto.Text = string.Empty;
                lblSueldo.Text = string.Empty;
                cboResultado.SelectedValue = null; 
                txtIdDictam.Text = "0";
                txtDictamen.Text = string.Empty;
                txtObser.Text = string.Empty;

            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrio un error al limpiar los campos\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void CargarElementos_Dictamen()
        {
            oCHumano = new WCF_CHumano.Hersan_CHumanoClient();
            try {
                DockWindow activeDocument = this.radDock1.DocumentManager.ActiveDocument;

                list = oCHumano.CHUDictamenSolicitud_Obtener();
                gvDictamen.DataSource = list;
                //gvDictamen.ClearSelection();
                btnNuevo.Enabled = false;
                btnGuardar.Enabled = true;
                btnEliminar.Enabled = true;

            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrio un error al cargar los elementos del dictamen\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally {
                oCHumano = null;
            }
        }
        private void CargarSolicitudes()
        {
            oCHumano = new CapitalHumano.WCF_CHumano.Hersan_CHumanoClient();
            try {
                DockWindow activeDocumen = this.radDock1.DocumentManager.ActiveDocument;
                oList = oCHumano.CHU_SolicitudP_Obtener(BaseWinBP.UsuarioLogueado.ID);
                gvDatos.DataSource = oList;
                //gvDatos.ClearSelection();
                btnGuardar.Enabled = false;
                btnEliminar.Enabled = false;
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrio un error al cargar las solicitudes\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally { oCHumano = null; }
        }
        private bool ValidarCampos()
        {
            string myItem = cboResultado.SelectedItem.ToString();
            bool Flag = true;
            try {
                Flag = txtDictamen.Text.Trim().Length == 0 ? false : true;
                Flag = txtObser.Text.Trim().Length == 0 ? false : true;
              

                return Flag;
            } catch (Exception ex) {
                throw ex;
            }
        }

        private void frmDictamenSustitucion_Load(object sender, EventArgs e)
        {
            try {
                GroupDescriptor Entidades = new GroupDescriptor();
                Entidades.GroupNames.Add("ENT_Nombre", ListSortDirection.Ascending);
                this.gvDatos.GroupDescriptors.Add(Entidades);


                lblfecha.Text = DateTime.Now.ToLongDateString();

                btnNuevo.Enabled = false;
                documentTabStrip1.SelectedTab = this.DockSolicitud;
                CargarSolicitudes();
                txtObser.Enabled = true;
            } catch (Exception) {

                throw;
            }


        }
        private void gvDatos_CurrentRowChanged(object sender, Telerik.WinControls.UI.CurrentRowChangedEventArgs e)
        {
            try {
                LimpiarCampos();

                if (gvDatos.RowCount > 0 && e.CurrentRow.ChildRows.Count == 0 ) {
                    btnNuevo.Enabled = true;
                  
                    txtJustif.Text = e.CurrentRow.Cells["Justificacion"].Value.ToString();
                    txtIndicad.Text = e.CurrentRow.Cells["Indicadores"].Value.ToString();
                    lblSueldo.Text = "$" + (e.CurrentRow.Cells["Sueldo"].Value.ToString());
                    lblDepto.Text = (e.CurrentRow.Cells["DEP_Nombre"].Value.ToString());
                    lblEntidad.Text = (e.CurrentRow.Cells["ENT_Nombre"].Value.ToString());
                    lblContrato.Text= (e.CurrentRow.Cells["TCO_Nombre"].Value.ToString());
                    lblPuesto.Text = (e.CurrentRow.Cells["PUE_Nombre"].Value.ToString());
                    txtIdSu.Text = (e.CurrentRow.Cells["Id"].Value.ToString());
                   



                }
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrio un error al seleccionar el registro\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            oCHumano = new WCF_CHumano.Hersan_CHumanoClient();
            DictamenSustitucionBE obj = new DictamenSustitucionBE();
          
            try {
                if (!ValidarCampos()) {
                    RadMessageBox.Show("Debe capturar todos los datos para continuar", this.Text, MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                    btnGuardar.Enabled = false;
                    LimpiarCampos();
                    return;
                }

                if (list.FindAll(item => item.Solicitud.Id.ToString() == txtIdSu.Text.Trim()).Count > 0
                    && int.Parse(txtIdDictam.Text) == -1 ){
                    RadMessageBox.Show("La información capturada ya existe, no es posible guardar", this.Text, MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                    btnGuardar.Enabled = false;
                    LimpiarCampos();
                    return;
                }

           
                if (RadMessageBox.Show("Desea guardar los datos capturados...?", this.Text, MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.Yes) {
                    string myItem = cboResultado.SelectedItem.ToString();
                    if (myItem == "Aceptado") {
                        obj.Aceptado = true;
                    } else if (myItem == "Rechazado" ) {
                        obj.Aceptado = false;
                    }
                    obj.Solicitud.Id = int.Parse(txtIdSu.Text);
                    obj.Id = int.Parse(txtIdDictam.Text);
                    obj.Observaciones = txtObser.Text;
                    obj.Dictamen = txtDictamen.Text;
                    obj.DatosUsuario.IdUsuarioCreo = BaseWinBP.UsuarioLogueado.ID;
                    obj.DatosUsuario.Estatus = true;


                    //PROCESO DE GUARDADO Y ACTUALIZACION
                    if (txtIdDictam.Text == "-1") {
                        int Result = oCHumano.CHUDictamenSolicitud__Guardar(obj);
                        if (Result == 0) {
                            RadMessageBox.Show("Ocurrió un error al guardar un elemento en el organigrama", this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
                        } else {
                            RadMessageBox.Show("Elemento guardado correctamente", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                            LimpiarCampos();
                            CargarElementos_Dictamen();
                            documentTabStrip1.SelectedTab = this.DockDictamen;


                        }
                    } else {

                        int Result = oCHumano.CHUDictamenSolicitud_Actualizar(obj);
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
        private void gvDictamen_CurrentRowChanged(object sender, Telerik.WinControls.UI.CurrentRowChangedEventArgs e)
        {
            try {
              
              
                if (gvDictamen.RowCount > 0 && e.CurrentRow.ChildRows.Count == 0 ) {
                    txtIdDictam.Text = e.CurrentRow.Cells["Id"].Value.ToString();
                    txtJustif.Text = e.CurrentRow.Cells["Justificacion"].Value.ToString();
                    txtIndicad.Text = e.CurrentRow.Cells["Indicadores"].Value.ToString();
                    lblSueldo.Text = "$" + (e.CurrentRow.Cells["Sueldo"].Value.ToString());
                    lblDepto.Text = (e.CurrentRow.Cells["DEP_Nombre"].Value.ToString());
                    lblEntidad.Text = (e.CurrentRow.Cells["ENT_Nombre"].Value.ToString());
                    lblPuesto.Text = (e.CurrentRow.Cells["PUE_Nombre"].Value.ToString());
                    txtObser.Text = (e.CurrentRow.Cells["DSU_Observaciones"].Value.ToString());
                    txtDictamen.Text = (e.CurrentRow.Cells["DSU_Dictamen"].Value.ToString());
                    txtIdSu.Text = (e.CurrentRow.Cells["SPE_Id"].Value.ToString());
                 lblContrato.Text= (e.CurrentRow.Cells["TCO_Nombre"].Value.ToString());
                    if (bool.Parse(e.CurrentRow.Cells["Aceptado"].Value.ToString()) == true) {
                        cboResultado.SelectedValue = "Aceptado";
                        

                    } else {
                        cboResultado.SelectedValue = "Rechazado";
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
        private void documentTabStrip1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try {
                if (documentTabStrip1.SelectedTab == this.DockDictamen) {
                    gvDatos.DataSource = null;
                    CargarElementos_Dictamen();
                   
                } else if (documentTabStrip1.SelectedTab == this.DockSolicitud) {
                    gvDictamen.DataSource = null;
                    LimpiarCampos();
                    CargarSolicitudes();
                                
                }
            } catch (Exception) {

                throw;
            }
           

        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try {
                btnGuardar.Enabled = true;
                txtIdDictam.Text = "-1";
            } catch (Exception) {

                throw;
            }
        }
        private void radDock1_ActiveWindowChanged(object sender, DockWindowEventArgs e)
        {
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            oCHumano = new CapitalHumano.WCF_CHumano.Hersan_CHumanoClient();
            DictamenSustitucionBE obj = new DictamenSustitucionBE();
            try {
                //if (chkEstatus.Checked) {
                if (RadMessageBox.Show("Esta acción dará de baja la solicitud\nDesea continuar...?", this.Text, MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.Yes) {
                    string myItem = cboResultado.SelectedItem.ToString();
                    if (myItem == "Aceptado") {
                        obj.Aceptado = true;
                    } else if (myItem == "Rechazado") {
                        obj.Aceptado = false;
                    }
                    obj.Solicitud.Id = int.Parse(txtIdSu.Text);
                    obj.Id = int.Parse(txtIdDictam.Text);
                    obj.Observaciones = txtObser.Text;
                    obj.Dictamen = txtDictamen.Text;
                    obj.DatosUsuario.IdUsuarioCreo = BaseWinBP.UsuarioLogueado.ID;
                    obj.DatosUsuario.Estatus = false;

                    int Result = oCHumano.CHUDictamenSolicitud_Actualizar(obj);
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

