using Hersan.Entidades.Catalogos;
using Hersan.Negocio;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Telerik.WinControls;

namespace Hersan.UI.CapitalHumano
{
    public partial class frmExpediente : Telerik.WinControls.UI.RadForm
    {
        #region Variables        
        WCF_Catalogos.Hersan_CatalogosClient oCatalogos;
        List<EntidadesBE> oEntidades = new List<EntidadesBE>();
        List<ColoniasBE> oColonia = new List<ColoniasBE>();
        #endregion

        #region Eventos Globales
        public frmExpediente()
        {
            InitializeComponent();
        }
        private void frmExpediente_Load(object sender, EventArgs e)
        {
            try {
                dtFecha.Value = DateTime.Today;
                this.tabDatos.Select();

                LimpiarCampos();
                CargarEntidades();
                CargarComboEstados();
                CargarComboEstadoNac();
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al cargar la pantalla\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void btnFoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog oDialog = new OpenFileDialog();
            try {
                oDialog.Filter = "Archivos jpg (*.jpg)|*.jpg";
                oDialog.Title = "Fotografia de Expediente";

                if (oDialog.ShowDialog() == DialogResult.OK) {
                    string imagen = oDialog.FileName;
                    picFoto.Image = Image.FromFile(imagen);
                }
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al cargar la fotografía del expediente\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {

        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {

        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            try {
                this.Close();
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al cerra la pantalla\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void cboEntidad_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try {
                CargarDeptos();
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al seleccionar la entidad\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void Decimal_KeyPress(object sender, KeyPressEventArgs e)
        {
            try {
                if (BaseWinBP.isDecimal(e.KeyChar))
                    e.Handled = true;
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error en la captura\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void Entero_KeyPress(object sender, KeyPressEventArgs e)
        {
            try {
                if (!BaseWinBP.isNumero(e.KeyChar))
                    e.Handled = true;
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error en la captura\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void radDock1_ActiveWindowChanged(object sender, Telerik.WinControls.UI.Docking.DockWindowEventArgs e)
        {
            try {

            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al seleccionar la entidad\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        #endregion

        #region Métodos y Eventos TabDatos
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
        private void cboEstado_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            oCatalogos = new WCF_Catalogos.Hersan_CatalogosClient();
            try {
                cboCiudad.DisplayMember = "Nombre";
                cboCiudad.ValueMember = "Id";
                cboCiudad.DataSource = oCatalogos.ABCCiudades_Obtener(int.Parse(cboEstado.SelectedValue.ToString()));
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al seleccionar el estado\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
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
                RadMessageBox.Show("Ocurrió un error al seleccionar la ciudad\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally {
                oCatalogos = null;
            }
        }
        private void cboColonia_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try {
                if (cboColonia.SelectedValue != null)
                    txtCP.Text = oColonia.Find(item => item.Id == int.Parse(cboColonia.SelectedValue.ToString())).CP.ToString();
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al seleccionar la colonia\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void cboEdoNac_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            oCatalogos = new WCF_Catalogos.Hersan_CatalogosClient();
            try {
                cboCiudadNac.DisplayMember = "Nombre";
                cboCiudadNac.ValueMember = "Id";
                cboCiudadNac.DataSource = oCatalogos.ABCCiudades_Obtener(int.Parse(cboEdoNac.SelectedValue.ToString()));
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al seleccionar el estado\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally {
                oCatalogos = null;
            }
        }

        private void CargarComboEstados()
        {
            oCatalogos = new WCF_Catalogos.Hersan_CatalogosClient();
            try {
                //PAIS = México (1)
                cboEstado.ValueMember = "Id";
                cboEstado.DisplayMember = "Nombre";
                cboEstado.DataSource = oCatalogos.ABCEstados_Obtener(1);
            } catch (Exception ex) {
                throw ex;
            } finally {
                oCatalogos = null;
            }
        }
        private void CargarComboEstadoNac()
        {
            oCatalogos = new WCF_Catalogos.Hersan_CatalogosClient();
            try {
                //PAIS = México (1)
                cboEdoNac.ValueMember = "Id";
                cboEdoNac.DisplayMember = "Nombre";
                cboEdoNac.DataSource = oCatalogos.ABCEstados_Obtener(1);
            } catch (Exception ex) {
                throw ex;
            } finally {
                oCatalogos = null;
            }
        }
        #endregion

        #region Métodos Generales
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
        private void LimpiarCampos()
        {
            try {
                #region RadComboBox
                cboEntidad.SelectedIndex = 0;
                cboEstado.SelectedIndex = 0;
                cboEdoNac.SelectedIndex = 0;
                cboDependientes.SelectedIndex = 0;
                cboEdoCivil.SelectedIndex = 0;
                cboEscolaridad.SelectedIndex = 0;
                cboParentesco.SelectedIndex = 0;
                cboSexo.SelectedIndex = 0;
                cboVive.SelectedIndex = 0;
                #endregion

                #region RadTextBox
                txtAbonoMes.Text = string.Empty;
                txtAfianzadoSi.Text = string.Empty;
                txtAfore.Text = string.Empty;
                txtAMaterno.Text = string.Empty;
                txtAniosEscuela.Text = string.Empty;
                txtAPaterno.Text = string.Empty;
                txtAprobado.Text = string.Empty;
                txtCambiarNo.Text = string.Empty;
                txtCartilla.Text = string.Empty;
                txtClub.Text = string.Empty;
                txtComentariosJefes.Text = string.Empty;
                txtConyugeSi.Text = string.Empty;
                txtCP.Text = string.Empty;
                txtCurp.Text = string.Empty;
                txtCursoEscuela.Text = string.Empty;
                txtDeporte.Text = string.Empty;
                txtDeseado.Text = string.Empty;
                txtDeudaImporte.Text = string.Empty;
                txtDeudaSi.Text = string.Empty;
                txtDireccionEmpleo.Text = string.Empty;
                txtDireccionEscuela.Text = string.Empty;
                txtDireccionPariente.Text = string.Empty;
                txtDireccionReferencia.Text = string.Empty;
                txtDoctoTrabajo.Text = string.Empty;
                txtDomicilio.Text = string.Empty;
                txtEdad.Text = string.Empty;
                txtEdadPariente.Text = string.Empty;
                txtEdoCivilOtro.Text = string.Empty;
                txtEmpresaEmpleo.Text = string.Empty;
                txtEnfermedad.Text = string.Empty;
                txtEstatura.Text = string.Empty;
                txtEstudiosEscuela.Text = string.Empty;
                txtFunciones.Text = string.Empty;
                txtGastosMes.Text = string.Empty;
                txtGradoEscuela.Text = string.Empty;
                txtHorarioEscuela.Text = string.Empty;
                txtIdiomas.Text = string.Empty;
                txtImss.Text = string.Empty;
                txtIngresoMensual.Text = string.Empty;
                txtIngresoSi.Text = string.Empty;
                txtJefeEmpleo.Text = string.Empty;
                txtLicencia.Text = string.Empty;
                txtMaquinas.Text = string.Empty;
                txtMarca.Text = string.Empty;
                txtMetaVida.Text = string.Empty;
                txtModelo.Text = string.Empty;
                txtMotivoEmpleo.Text = string.Empty;
                txtNacionalidad.Text = string.Empty;
                txtNombrePariente.Text = string.Empty;
                txtNombreReferencia.Text = string.Empty;
                txtNombres.Text = string.Empty;
                txtObserva.Text = string.Empty;
                txtOcupacionPariente.Text = string.Empty;
                txtOcupacionReferencia.Text = string.Empty;
                txtOtroMedio.Text = string.Empty;
                txtOtrosDepen.Text = string.Empty;
                txtOtrosTrabajos.Text = string.Empty;
                txtParientesSi.Text = string.Empty;
                txtPasaporte.Text = string.Empty;
                txtPasatiempo.Text = string.Empty;
                txtPercepcionMes.Text = string.Empty;
                txtPeso.Text = string.Empty;
                txtPuestoEmpleo.Text = string.Empty;
                txtPuestoJefeEmpleo.Text = string.Empty;
                txtRazonInformes.Text = string.Empty;
                txtRentaMes.Text = string.Empty;
                txtRFC.Text = string.Empty;
                txtSeguroVidaSi.Text = string.Empty;
                txtSindicatoSi.Text = string.Empty;
                txtSoftware.Text = string.Empty;
                txtSueldoFinEmpleo.Text = string.Empty;
                txtSueldoIniEmpleo.Text = string.Empty;
                txtTelefono.Text = string.Empty;
                txtTelefonoEmpleo.Text = string.Empty;
                txtTelefonoReferencia.Text = string.Empty;
                txtTiempoEmpleo.Text = string.Empty;
                txtTiempoReferencia.Text = string.Empty;
                txtTituloEscuela.Text = string.Empty;
                txtValorAprox.Text = string.Empty;
                txtViajarNo.Text = string.Empty;
                #endregion
            } catch (Exception ex) {
                throw ex;
            }
        }

        #endregion

       
    }
}
