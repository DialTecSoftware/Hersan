using Hersan.Entidades.CapitalHumano;
using Hersan.Entidades.Catalogos;
using Hersan.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace Hersan.UI.CapitalHumano
{
    public partial class frmSeguimientoCandidatos : Telerik.WinControls.UI.RadForm
    {
        public int IdExpediente { get; set; }
        WCF_Catalogos.Hersan_CatalogosClient oCatalogos;
        CapitalHumano.WCF_CHumano.Hersan_CHumanoClient oCHumano;
        List<EntidadesBE> oEntidades = new List<EntidadesBE>();
        List<SeguimientoCandidatosBE> oList = new List<SeguimientoCandidatosBE>();


        public frmSeguimientoCandidatos()
        {
            InitializeComponent();
        }
        private string CreateBody()
        {
       
            string body = string.Empty;
            if (rdbAceptado.IsChecked == true) {
                using (StreamReader reader = new StreamReader((Directory.GetCurrentDirectory() + "/Correo/Correo_Aceptado.html"))) {
                    body = reader.ReadToEnd();
                }
            }
            if (rdbRechazado.IsChecked == true) {
                using (StreamReader reader = new StreamReader(Directory.GetCurrentDirectory() + "/Correo/Correo_Rechazado.html")) {
                    body = reader.ReadToEnd();
                }
                } 
                body = body.Replace("{Nombre}", txtNombreC.Text);
            return body;
        }

        private void LimpiarCampos()
        {
            txtCorreo.Text = string.Empty;
            txtId.Text = "-1";
            txtNombreC.Text = string.Empty;
            cboEntidad.SelectedIndex = 0;
            cboDepto.SelectedIndex = 0;
            cboPuesto.SelectedIndex = 0;
            rdbProceso.IsChecked = true;
        }
        private void CargarEntidades()
        {
            oCatalogos = new WCF_Catalogos.Hersan_CatalogosClient();
            try {
                oEntidades = oCatalogos.Entidades_Combo(BaseWinBP.UsuarioLogueado.Empresa.Id);
                oEntidades.Add(new EntidadesBE { Id = 0, Nombre = "TODAS" });
                cboEntidad.ValueMember = "Id";
                cboEntidad.DisplayMember = "Nombre";
                cboEntidad.DataSource = oEntidades;
            } catch (Exception ex) {
                throw ex;
            }
        }

        private void CargarSeguimientos()
        {
            oCHumano = new CapitalHumano.WCF_CHumano.Hersan_CHumanoClient();
            try {
                oList = oCHumano.CHU_SeguimientoCan_Obtener();
                gvDatos.DataSource = oList;
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrio un error al cargar las solicitudes\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally { oCHumano = null; }
        }
        private void CargarDeptos()
        {
            oCatalogos = new WCF_Catalogos.Hersan_CatalogosClient();
            try {
                cboDepto.ValueMember = "Id";
                cboDepto.DisplayMember = "Nombre";
                cboDepto.DataSource = oCatalogos.ABCDepartamentos_Combo(int.Parse(cboEntidad.SelectedValue.ToString()));
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al cargar los departamentos\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally {
                oCatalogos = null;
            }
        }

        private bool ValidarCampos()
        {
            bool Flag = true;
            try {
                Flag = txtCorreo.Text.Trim().Length == 0 ? false : true;
                Flag = txtNombreC.Text.Trim().Length == 0 ? false : true;
                return Flag;
            } catch (Exception ex) {
                throw ex;
            }
        }

        private void frmSeguimientoCandidatos_Load(object sender, EventArgs e)
        {
            try {
                CargarEntidades();
                CargarSeguimientos();
            } catch (Exception) {

                throw;
            }
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {


        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try {
                LimpiarCampos();
            } catch (Exception) {

                throw;
            }

        }

        private void cboDepto_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            oCatalogos = new WCF_Catalogos.Hersan_CatalogosClient();
            try {
                cboPuesto.ValueMember = "Id";
                cboPuesto.DisplayMember = "Nombre";
                if (cboDepto.Items.Count > 0 && cboDepto.SelectedValue != null) {
                    cboPuesto.DataSource = oCatalogos.ABCPuestos_Combo(int.Parse(cboDepto.SelectedValue.ToString()));
                } else
                    cboPuesto.DataSource = null;
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al seleccionar el puesto\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally {
                oCatalogos = null;
            }
        }

        private void cboEntidad_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try {
                if (cboEntidad.Items.Count > 0 && cboEntidad.SelectedValue != null) {
                    CargarDeptos();
                } else {
                    cboDepto.DataSource = null;
                }
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al seleccionar la entidad\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            oCHumano = new CapitalHumano.WCF_CHumano.Hersan_CHumanoClient();
            SeguimientoCandidatosBE obj = new SeguimientoCandidatosBE();
            try {
                if (!ValidarCampos()) {
                    RadMessageBox.Show("Debe capturar todos los datos para continuar", this.Text, MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                    return;
                }

                if (oList.FindAll(item => item.Departamentos.Entidades.Id == int.Parse(cboEntidad.SelectedValue.ToString()) && item.Departamentos.Id == int.Parse(cboDepto.SelectedValue.ToString())).Count > 0
                   && int.Parse(txtId.Text) == -1) {
                    RadMessageBox.Show("El departamento capturado ya existe, no es posible guardar", this.Text, MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                    LimpiarCampos();
                    return;
                }
                #region Entidades
                obj.Id = int.Parse(txtId.Text);
                obj.Entidades.Id = int.Parse(cboEntidad.SelectedValue.ToString());
                obj.Puestos.Id = int.Parse(cboPuesto.SelectedValue.ToString());
                obj.Departamentos.Id = int.Parse(cboDepto.SelectedValue.ToString());
                obj.Correo = (txtCorreo.Text);
                obj.Proceso = true;
                if (rdbAceptado.IsChecked) {
                    obj.Aceptado = true;
                    obj.Proceso = false;
                }

                obj.NombreCompleto = txtNombreC.Text;
                obj.DatosUsuario.IdUsuarioCreo = BaseWinBP.UsuarioLogueado.ID;
                #endregion





                //PROCESO DE GUARDADO Y ACTUALIZACION
                if (txtId.Text == "-1") {
                    int Result = oCHumano.CHU_SeguimientoCan_Guardar(obj);
                    if (Result == 0) {
                        RadMessageBox.Show("Ocurrió un error al enviar la solicitud de empleo", this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
                    } else {
                        RadMessageBox.Show("Solicitud enviada correctamente", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                        LimpiarCampos();
                        CargarSeguimientos();

                    }
                } else {
                    oCHumano = new CapitalHumano.WCF_CHumano.Hersan_CHumanoClient();
                    int Result = oCHumano.CHU_SeguimientoCan_Actualizar(obj);
                    if (Result == 0) {
                        RadMessageBox.Show("Ocurrió un error al actualizar los datos", this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
                    } else {
                        RadMessageBox.Show("Información actualizada correctamente", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                        LimpiarCampos();
                        CargarSeguimientos();
                    }
                }
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrio un error al actualizar la información\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally {

                oCHumano = null;
            }
        }

        private void gvDatos_CurrentRowChanged(object sender, Telerik.WinControls.UI.CurrentRowChangedEventArgs e)
        {
            try {

                if (gvDatos.RowCount > 0 && e.CurrentRow.ChildRows.Count == 0) {
                    txtId.Text = e.CurrentRow.Cells["Id"].Value.ToString();
                    txtNombreC.Text = e.CurrentRow.Cells["NombreCompleto"].Value.ToString();
                    txtCorreo.Text = (e.CurrentRow.Cells["Correo"].Value.ToString());
                    cboDepto.SelectedValue = int.Parse(e.CurrentRow.Cells["DEP_Id"].Value.ToString());
                    cboEntidad.SelectedValue = int.Parse(e.CurrentRow.Cells["ENT_Id"].Value.ToString());
                    cboPuesto.SelectedValue = int.Parse(e.CurrentRow.Cells["PUE_Id"].Value.ToString());
                    if (bool.Parse(e.CurrentRow.Cells["Proceso"].Value.ToString()) == true) {
                        rdbProceso.IsChecked = true;
                    }
                    if (bool.Parse(e.CurrentRow.Cells["Aceptado"].Value.ToString()) == true) {
                        rdbAceptado.IsChecked = true;
                    }
                    if (bool.Parse(e.CurrentRow.Cells["Rechazado"].Value.ToString()) == true) {
                        rdbRechazado.IsChecked = true;
                    }
                }
            } catch (Exception ex) {

                RadMessageBox.Show("Occurió un error al seleccionar el regsitro" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
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

        private void btnCorreo_Click(object sender, EventArgs e)
        {

            try {
                
                 
                    if (!rdbAceptado.IsChecked && !rdbRechazado.IsChecked) {
                    RadMessageBox.Show("Actualiza el estatus del Candidato(Rechazado o Acpetado)\n antes de enviar correo"
                                        , this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
                    return;
                }
                    #region Correo
                    string pwd = "Catcooptest";
                string smtp = "smtp.GMAIL.com";
                string emisor = "Key.Solutions.Test@gmail.com";
                string destinatario = txtCorreo.Text;
                string asunto = "Reclutamiento Hersan HiTech sapi de cv ";
                int port = 587;
                if (txtId.Text != "-1") { 
                       string CuerpoMsg = CreateBody();
                    BaseWinBP.EnviarMail(emisor, destinatario, asunto, CuerpoMsg, smtp, pwd, port);
                    RadMessageBox.Show("Correo enviado correctamente", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);                       
                  } 
                    else
                    RadMessageBox.Show("Selecciona un candidato para mandar el correo\n", this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);

                #endregion
            } catch (Exception ex) {

                RadMessageBox.Show("Ocurrió un error al mandar el correo\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            oCHumano = new CapitalHumano.WCF_CHumano.Hersan_CHumanoClient();
            SeguimientoCandidatosBE obj = new SeguimientoCandidatosBE();
            try {
                //if (chkEstatus.Checked) {
                if (RadMessageBox.Show("Esta acción dará de baja la solicitud\nDesea continuar...?", this.Text, MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.Yes) {
                }

                obj.Id = int.Parse(txtId.Text);
                obj.Entidades.Id = int.Parse(cboEntidad.SelectedValue.ToString());
                obj.Puestos.Id = int.Parse(cboPuesto.SelectedValue.ToString());
                obj.Departamentos.Id = int.Parse(cboDepto.SelectedValue.ToString());
                obj.Correo = (txtCorreo.Text);
                obj.Proceso = true;
                obj.NombreCompleto = txtNombreC.Text;
                obj.DatosUsuario.IdUsuarioCreo = BaseWinBP.UsuarioLogueado.ID;
                obj.DatosUsuario.Estatus = false;

                int Result = oCHumano.CHU_SeguimientoCan_Actualizar(obj);
                if (Result == 0) {
                    RadMessageBox.Show("Ocurrió un error al modificar los datos", this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
                } else {
                    RadMessageBox.Show("Candidato dado de baja correctamente", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                    LimpiarCampos();
                    CargarSeguimientos();
                }
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrio un error al dar de baja el candidato\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally {
                oCHumano = null;
            }
        }
    }
}

