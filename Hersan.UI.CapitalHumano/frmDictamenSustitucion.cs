using Hersan.Entidades.CapitalHumano;
using Hersan.Entidades.Catalogos;
using Hersan.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.Data;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Docking;

namespace Hersan.UI.CapitalHumano
{
    public partial class frmDictamenSustitucion : Telerik.WinControls.UI.RadForm
    {
        WCF_CHumano.Hersan_CHumanoClient oCHumano;
        List<SolicitudPersonalBE> oList = new List<SolicitudPersonalBE>();
        List<DictamenSustitucionBE> list = new List<DictamenSustitucionBE>();
        List<EntidadesBE> oEntidades = new List<EntidadesBE>();

        public frmDictamenSustitucion()
        {
            InitializeComponent();
        }
        private void frmDictamenSustitucion_Load(object sender, EventArgs e)
        {
            try {
                lblfecha.Text = DateTime.Now.ToLongDateString();

                GroupDescriptor Entidades = new GroupDescriptor();
                Entidades.GroupNames.Add("ENT_Nombre", ListSortDirection.Ascending);
                this.gvDatos.GroupDescriptors.Add(Entidades);

                GroupDescriptor Grupo = new GroupDescriptor();
                Grupo.GroupNames.Add("ENT_Nombre", ListSortDirection.Ascending);
                this.gvDictamen.GroupDescriptors.Add(Grupo);

                ConditionalFormattingObject obj = new ConditionalFormattingObject("MyCondition", ConditionTypes.Greater, "30", "", true);
                obj.CellForeColor = Color.White;
                obj.CellBackColor = Color.RoyalBlue;
                obj.ApplyOnSelectedRows = true;
                this.gvDatos.Columns["Estado"].ConditionalFormattingObjectList.Add(obj);                

                LimpiarCampos();
                CargarSolicitudes();
                this.docSustitucion.Select();
            } catch (Exception) {
                throw;
            }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            oCHumano = new WCF_CHumano.Hersan_CHumanoClient();
            SolicitudPersonalBE obj = new SolicitudPersonalBE();
          
            try {
                if (rdbRevisiones.IsChecked == rdbAceptado.IsChecked == rdbRechazado.IsChecked == false) {
                    RadMessageBox.Show("Debe de selecciona un estatus para el dictamen", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                    return;
                }
               
                if (oList.FindAll((item => item.Estado.Contains("ACEPTADO") && item.Id == int.Parse(txtIdSu.Text))).Count > 0 || oList.FindAll((item => item.Estado.Contains("RECHAZADO") && item.Id == int.Parse(txtIdSu.Text))).Count > 0)
                  {
                    RadMessageBox.Show("Esta propuesta ya ha sido dictmaninada, no es posible modificarla", this.Text, MessageBoxButtons.OK, RadMessageIcon.Exclamation);

                    return;
                }

                if (RadMessageBox.Show("Desea guardar los datos capturados...?", this.Text, MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.Yes) {
                    if (rdbRevisiones.IsChecked == true)
                        obj.Estado = "1";
                    else
                        if (rdbAceptado.IsChecked == true)
                        obj.Estado = "2";
                    else
                    if (rdbRechazado.IsChecked == true)
                        obj.Estado = "3";
                    
                    obj.Id = int.Parse(txtIdSu.Text);
                    obj.Dictamen = txtDictamen.Text;
                    obj.DatosUsuario.IdUsuarioCreo = BaseWinBP.UsuarioLogueado.ID;
                    obj.DatosUsuario.Estatus = true;

                    #region Correo
                    //string pwd = "Catcooptest";
                    //string smtp = "smtp.GMAIL.com";
                    //string emisor = "Key.Solutions.Test@gmail.com";
                    //string destinatario = "gregory.moise@dialtec.com.mx";                  
                    //string asunto = "Respuesta a su Solicitud de Sustitución de Personal(" + DateTime.Now.ToString("dd / MMM / yyy hh: mm:ss") + ") ";
                    //string CuerpoMsg = "¡¡Favor de revisar el sistema para consultar la  y hacer las continuaciones si necesarias!!";
                    //int port = 587;
                    #endregion

                    //PROCESO DE GUARDADO Y ACTUALIZACION
                    if (int.Parse(txtIdSu.Text) > 0) {
                        int Result = oCHumano.CHU_SolicitudP_ActualizarDictamen(obj);
                        if (Result == 0) {
                            RadMessageBox.Show("Ocurrió un error al guardar un elemento en el organigrama", this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
                        } else {
                            RadMessageBox.Show("Elemento guardado correctamente", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                            LimpiarCampos();
                            CargarSolicitudes();
                            
                            //BaseWinBP.EnviarMail(emisor, destinatario, asunto, CuerpoMsg, smtp, pwd, port);
                        }
                    } 
                }

            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al actualizar la información\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally {
                oCHumano = null;
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
            SolicitudPersonalBE obj = new SolicitudPersonalBE();
            try {
               
                if (RadMessageBox.Show("Esta acción dará de baja la solicitud\nDesea continuar...?", this.Text, MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.Yes) {
                    if (rdbRevisiones.IsChecked == true) {
                        obj.Estado = "1";
                    }
                    if (rdbAceptado.IsChecked == true) {
                        obj.Estado = "2";
                    }
                    if (rdbRechazado.IsChecked == true) {
                        obj.Estado = "3";
                    }
                  
                    obj.Id = int.Parse(txtIdSu.Text);
                    
                    obj.Dictamen = txtDictamen.Text;
                    obj.DatosUsuario.IdUsuarioCreo = BaseWinBP.UsuarioLogueado.ID;
                    obj.DatosUsuario.Estatus = false;

                    int Result = oCHumano.CHU_SolicitudP_ActualizarDictamen(obj);
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
        private void btnNuevo_Click_1(object sender, EventArgs e)
        {
            try {
                LimpiarCampos();

            } catch (Exception) {

                throw;
            }
        }
        private void gvDatos_CurrentRowChanged_1(object sender, CurrentRowChangedEventArgs e)
        {
            try {
                LimpiarCampos();

                if (gvDatos.RowCount > 0 && e.CurrentRow.ChildRows.Count == 0) {
                    txtJustif.Text = e.CurrentRow.Cells["Justificacion"].Value.ToString();
                    txtIndicad.Text = e.CurrentRow.Cells["Indicadores"].Value.ToString();
                    lblSueldo.Text = "$" + (e.CurrentRow.Cells["Sueldo"].Value.ToString());
                    lblDepto.Text = (e.CurrentRow.Cells["DEP_Nombre"].Value.ToString());
                    lblEntidad.Text = (e.CurrentRow.Cells["ENT_Nombre"].Value.ToString());
                    lblContrato.Text = (e.CurrentRow.Cells["TCO_Nombre"].Value.ToString());
                    lblPuesto.Text = (e.CurrentRow.Cells["PUE_Nombre"].Value.ToString());
                    txtIdSu.Text = (e.CurrentRow.Cells["Id"].Value.ToString());
                    txtDictamen.Text = (e.CurrentRow.Cells["Dictamen"].Value.ToString());
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
        private void gvDictamen_CurrentRowChanged(object sender, CurrentRowChangedEventArgs e)
        {
            try {

                if (gvDatos.RowCount > 0 && e.CurrentRow.ChildRows.Count == 0) {
                    txtJustif.Text = e.CurrentRow.Cells["Justificacion"].Value.ToString();
                    txtIndicad.Text = e.CurrentRow.Cells["Indicadores"].Value.ToString();
                    lblSueldo.Text = "$" + (e.CurrentRow.Cells["Sueldo"].Value.ToString());
                    lblDepto.Text = (e.CurrentRow.Cells["DEP_Nombre"].Value.ToString());
                    lblEntidad.Text = (e.CurrentRow.Cells["ENT_Nombre"].Value.ToString());
                    lblContrato.Text = (e.CurrentRow.Cells["TCO_Nombre"].Value.ToString());
                    lblPuesto.Text = (e.CurrentRow.Cells["PUE_Nombre"].Value.ToString());
                    txtIdSu.Text = (e.CurrentRow.Cells["Id"].Value.ToString());
                    txtDictamen.Text = (e.CurrentRow.Cells["Dictamen"].Value.ToString());
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
        private void radDock1_ActiveWindowChanged(object sender, DockWindowEventArgs e)
        {
            try {
                if (e.DockWindow.Name.Equals("docDictamen")) {
                    if (gvDictamen.RowCount == 0) {
                        gvDictamen.DataSource = null;
                        var dList = oList.FindAll(item => item.Estado == "ACEPTADO" || item.Estado == "RECHAZADO");
                        gvDictamen.DataSource = dList;
                    } else {
                        gvDictamen.ClearSelection();
                        gvDictamen.Rows[0].IsSelected = true;
                        gvDictamen_CurrentRowChanged(new object(), new CurrentRowChangedEventArgs(null, gvDictamen.Rows[0]));
                    }
                } else {
                    if (e.DockWindow.Name.Equals("docSustitucion")) {
                        if (gvDatos.RowCount > 0) {
                            gvDatos.ClearSelection();
                            gvDatos.Rows[0].IsSelected = true;
                            gvDatos_CurrentRowChanged_1(new object(), new CurrentRowChangedEventArgs(null, gvDatos.Rows[0]));
                        }
                    }
                }
            } catch (Exception ex) {
                throw ex;
            }
        }

        private void LimpiarCampos()
        {
            try {
                txtJustif.Text = string.Empty;
                txtIndicad.Text = string.Empty;
                lblContrato.Text = string.Empty;
                lblDepto.Text = string.Empty;
                lblEntidad.Text = string.Empty;
                txtIdSu.Text = "0";
                lblPuesto.Text = string.Empty;
                lblSueldo.Text = string.Empty;
                txtIdDictam.Text = "0";
                txtDictamen.Text = string.Empty;


            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrio un error al limpiar los campos\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void CargarSolicitudes()
        {
            oCHumano = new CapitalHumano.WCF_CHumano.Hersan_CHumanoClient();
            try {
                //DockWindow activeDocumen = this.radDock1.DocumentManager.ActiveDocument;

                oList = oCHumano.CHU_SolicitudP_Obtener(BaseWinBP.UsuarioLogueado.ID);
                var lista = oList.FindAll(item => item.Estado == "REVISADO" || item.Estado == "CAPTURADO" || item.Estado == "ACTUALIZADO");
                gvDatos.DataSource = lista;

                //var dList = oList.FindAll(item => item.Estado == "ACEPTADO" || item.Estado == "RECHAZADO");
                //gvDictamen.DataSource = dList;
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrio un error al cargar las solicitudes\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally {
                oCHumano = null;
            }
        }
    }
}

