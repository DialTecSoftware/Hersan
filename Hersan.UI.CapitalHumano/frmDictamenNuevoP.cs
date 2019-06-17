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
using Telerik.WinControls.UI;
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
         
            lblNombre.Text = "";
            lblOcupantes.Text = "";
            txtJustif.Text = "";
            lblSueldo.Text = "";
            lblEntidad.Text = "";
            lblDepto.Text = "";
            txtIdNuevoP.Text = "0";
            
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
                var lista = oList.FindAll(item => item.Estado == "REVISADO" || item.Estado == "CAPTURADO" || item.Estado == "ACTUALIZADO");
                var dList = oList.FindAll(item => item.Estado == "ACEPTADO" || item.Estado == "RECHAZADO");
                gvDatos.DataSource = lista;
                gvDictamen.DataSource = dList;
               

            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrio un error al cargar las propuestas de puestos\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally { oCHumano = null; }
        }
        //private void CargarElementos_Dictamen()
        //{
        //    oCHumano = new WCF_CHumano.Hersan_CHumanoClient();
        //    try {
        //        DockWindow activeDocument = this.radDock1.DocumentManager.ActiveDocument;

        //        list = oCHumano.CHU_DictamenNuevoP_Obtener();
        //        gvDictamenes.DataSource = list;
        //        //gvDictamenes.ClearSelection();
               
        //        btnEliminar.Enabled = true;

        //    } catch (Exception ex) {
        //        RadMessageBox.Show("Ocurrio un error al cargar los elementos del dictamen\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
        //    } finally {
        //        oCHumano = null;
        //    }
        //}
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

                ConditionalFormattingObject obj = new ConditionalFormattingObject("MyCondition", ConditionTypes.Greater, "30", "", true);
                obj.CellForeColor = Color.White;
                obj.CellBackColor = Color.RoyalBlue;
                obj.ApplyOnSelectedRows = true;
                this.gvDatos.Columns["Estado"].ConditionalFormattingObjectList.Add(obj);

            } catch (Exception) {

                throw;
            }

        }
        private void gvDatos_CurrentRowChanged(object sender, Telerik.WinControls.UI.CurrentRowChangedEventArgs e)
        {
            try {

                if (gvDatos.RowCount > 0 && e.CurrentRow.ChildRows.Count == 0) {

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
                    txtOpinionesDG.Text = (e.CurrentRow.Cells["OpinionesDG"].Value.ToString());
                    txtOpinionesCH.Text = (e.CurrentRow.Cells["OpinionesCH"].Value.ToString());
                    string estatus = e.CurrentRow.Cells["Estado"].Value.ToString();

                    if (estatus == "REVISADO") {
                        rdbRevisiones.IsChecked = true;
                    } else if (estatus == "ACCEPTADO") {
                        rdbAceptado.IsChecked = true;

                    } else if (estatus == "RECHAZADO") {
                        rdbRechazado.IsChecked = true;
                    } else {
                        rdbRevisiones.IsChecked = rdbRechazado.IsChecked =
                            rdbAceptado.IsChecked = false;
                    }
                }
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrio un error al seleccionar el registro\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void txtPuestosCargo_TextChanged(object sender, EventArgs e)
        {

        }
       
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            oCHumano = new WCF_CHumano.Hersan_CHumanoClient();
            NuevoPuestoBE obj = new NuevoPuestoBE();

            try {
                if (rdbRevisiones.IsChecked == rdbAceptado.IsChecked == rdbRechazado.IsChecked == false) {
                    RadMessageBox.Show("Debe de selecciona un estatus para el dictamen", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                    return;
                }

                if (!ValidarCampos()) {
                    RadMessageBox.Show("Debe capturar todos los datos para continuar", this.Text, MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                    return;
                }

                if (oList.FindAll((item => item.Estado.Contains("ACEPTADO") && item.Id == int.Parse(txtIdNuevoP.Text))).Count > 0 || oList.FindAll((item => item.Estado.Contains("RECHAZADO") && item.Id == int.Parse(txtIdNuevoP.Text))).Count > 0) {
                    RadMessageBox.Show("Esta propuesta ya ha sido dictmaninada, no es posible modificarla", this.Text, MessageBoxButtons.OK, RadMessageIcon.Exclamation);
    
                    return;
                }



                if (RadMessageBox.Show("Desea guardar los datos capturados...?", this.Text, MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.Yes) {                 

                    if (rdbRevisiones.IsChecked == true)
                    {
                        obj.Estado = "1";
                    }
                    if (rdbAceptado.IsChecked == true) 
                    {
                        obj.Estado = "2";
                    }
                    if (rdbRechazado.IsChecked == true) 
                    {
                        obj.Estado ="3";
                    }

                  
                    obj.Id = int.Parse(txtIdNuevoP.Text);
                    obj.OpinionesCH = txtOpinionesCH.Text;
                    obj.OpinionesDG = txtOpinionesDG.Text;
                    obj.DatosUsuario.IdUsuarioCreo = BaseWinBP.UsuarioLogueado.ID;
                    obj.DatosUsuario.Estatus = true;


                    //PROCESO DE GUARDADO Y ACTUALIZACION
                    if (int.Parse(txtIdNuevoP.Text) > 0) {
                        int Result = oCHumano.CHU_NuevoPuesto_ActualizarDictamen(obj);
                        if (Result == 0) {
                            RadMessageBox.Show("Ocurrió un error al guardar el nuevo dictamen", this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
                        } else {
                            RadMessageBox.Show("Elemento guardado correctamente", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                            LimpiarCampos();
                            CargarNuevosPuestos();
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
                LimpiarCampos();
            } catch (Exception) {

                throw;
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
                    
                    obj.Id = int.Parse(txtIdNuevoP.Text);
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
                     

                    }
                }
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrio un error al dar de baja la solicitud\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally {
                oCHumano = null;
            }
        }

        private void gvDictamen_CurrentRowChanged(object sender, CurrentRowChangedEventArgs e)
        {
            try {


                if (gvDictamen.RowCount > 0 && e.CurrentRow.ChildRows.Count == 0) {

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
                    txtOpinionesDG.Text = (e.CurrentRow.Cells["OpinionesDG"].Value.ToString());
                    txtOpinionesCH.Text = (e.CurrentRow.Cells["OpinionesCH"].Value.ToString());
                    string estatus = e.CurrentRow.Cells["Estado"].Value.ToString();

                    if (estatus == "REVISADO") {
                        rdbRevisiones.IsChecked = true;
                    } else if (estatus == "ACEPTADO") {
                        rdbAceptado.IsChecked = true;

                    } else if (estatus == "RECHAZADO") {
                        rdbRechazado.IsChecked = true;
                    } else {
                        rdbRevisiones.IsChecked = rdbRechazado.IsChecked =
                            rdbAceptado.IsChecked = false;
                    }
                }

                } catch (Exception ex) {

                RadMessageBox.Show("Ocurrio un error al seleccionar el registro\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
    }
}

