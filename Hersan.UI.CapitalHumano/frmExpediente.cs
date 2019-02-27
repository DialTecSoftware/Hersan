using Hersan.Entidades.CapitalHumano;
using Hersan.Entidades.Catalogos;
using Hersan.Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using Telerik.WinControls;

namespace Hersan.UI.CapitalHumano
{
    public partial class frmExpediente : Telerik.WinControls.UI.RadForm
    {
        #region Variables        
        WCF_Catalogos.Hersan_CatalogosClient oCatalogos;
        CapitalHumano.WCF_CHumano.Hersan_CHumanoClient oCHumano;
        List<EntidadesBE> oEntidades = new List<EntidadesBE>();
        List<ColoniasBE> oColonia = new List<ColoniasBE>();
        List<ExpedienteFamilia> oFamilia = new List<ExpedienteFamilia>();
        List<ExpedienteEstudios> oEstudios = new List<ExpedienteEstudios>();
        List<ExpedienteEmpleos> oEmpleos = new List<ExpedienteEmpleos>();
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
            oCHumano = new WCF_CHumano.Hersan_CHumanoClient();
            DataSet oData = CrearTablasAuxiliares();
            int Result = 0;
            try {
                #region Carga Datos Expediente
                DataRow oRow = oData.Tables["Expediente"].NewRow();
                oRow["EXP_Id"] = int.Parse(txtId.Text);
                oRow["DEP_Id"] = int.Parse(cboDepto.SelectedValue.ToString());
                oRow["PUE_Id"] = int.Parse(cboPuesto.SelectedValue.ToString());
                oRow["EXP_Deseado"] = txtDeseado.Text.Trim().Length == 0 ? 0 : decimal.Parse(txtDeseado.Text);
                oRow["EXP_Aprobado"] = txtAprobado.Text.Trim().Length == 0 ? 0 : decimal.Parse(txtAprobado.Text);
                oRow["EXP_Contratado"] = cboTipoExpediente.Text != "EMPLEADO" ? "19000101" : dtFecha.Value.Year.ToString()
                    + dtFecha.Value.Month.ToString().PadLeft(2, '0') + dtFecha.Value.Day.ToString().PadLeft(2, '0');
                oRow["EXP_TipoExpediente"] = cboTipoExpediente.Text;
                oRow["EXP_Comentarios"] = txtObserva.Text;

                oData.Tables["Expediente"].Rows.Add(oRow);
                #endregion

                #region Carga Datos Personales
                oRow = oData.Tables["Personales"].NewRow();
                oRow["EXP_Id"] = int.Parse(txtId.Text);
                oRow["EDP_APaterno"] = txtAPaterno.Text;
                oRow["EDP_AMaterno"] = txtAMaterno.Text;
                oRow["EDP_Nombres"] = txtNombres.Text;
                oRow["EDP_Edad"] = txtEdad.Text.Trim().Length == 0 ? 0 : int.Parse(txtEdad.Text);
                oRow["EDP_Direccion"] = txtDomicilio.Text;
                oRow["PAI_Id"] = 1;
                oRow["EST_Id"] = int.Parse(cboEstado.SelectedValue.ToString());
                oRow["CIU_Id"] = int.Parse(cboCiudad.SelectedValue.ToString());
                oRow["COL_Id"] = int.Parse(cboColonia.SelectedValue.ToString());
                oRow["EDO_Nacimiento"] = int.Parse(cboEdoNac.SelectedValue.ToString());
                oRow["CIU_Nacimiento"] = int.Parse(cboCiudadNac.SelectedValue.ToString());
                oRow["EDP_Telefono"] = txtTelefono.Text;
                oRow["EDP_Sexo"] = cboSexo.Text.ToUpper();
                oRow["EDP_FechaNac"] = dtFecNac.Value.Year.ToString() + dtFecNac.Value.Month.ToString().PadLeft(2, '0') + dtFecNac.Value.Day.ToString().PadLeft(2, '0');
                oRow["EDP_Nacionalidad"] = txtNacionalidad.Text;
                oRow["EDP_Vive"] = cboVive.Text.ToUpper();
                oRow["EDP_Estatura"] = txtEstatura.Text.Trim().Length == 0? 0 : decimal.Parse(txtEstatura.Text);
                oRow["EDP_Peso"] = txtPeso.Text.Trim().Length == 0 ? 0 : int.Parse(txtPeso.Text);
                oRow["EDP_Depende"] = cboDependientes.Text.ToUpper();
                oRow["EDP_DepenOtros"] = txtOtrosDepen.Text;
                oRow["EDP_EdoCivil"] = cboEdoCivil.Text.ToUpper();
                oRow["EDP_EdoCivilOtros"] = txtEdoCivilOtro.Text;

                oData.Tables["Personales"].Rows.Add(oRow);
                #endregion

                #region Carga Documentos
                oRow = oData.Tables["Documentos"].NewRow();
                oRow["EXP_Id"] = int.Parse(txtId.Text);
                oRow["EDO_CURP"] = txtCurp.Text;
                oRow["EDO_Afore"] = txtAfore.Text;
                oRow["EDO_RFC"] = txtRFC.Text;
                oRow["EDO_IMSS"] = txtImss.Text;
                oRow["EDO_Servicio"] = txtCartilla.Text;
                oRow["EDO_Pasaporte"] = txtPasaporte.Text;
                oRow["EDO_Licencia"] = opLicenciaSi.IsChecked;
                oRow["EDO_NoLicencia"] = txtLicencia.Text;
                oRow["EDO_DoctoExtranjero"] = txtDoctoTrabajo.Text;

                oData.Tables["Documentos"].Rows.Add(oRow);

                #endregion

                #region Carga Familia
                oFamilia.ForEach(item => {
                    oRow = oData.Tables["Familia"].NewRow();
                    oRow["EXP_Id"] = item.IdExpediente;
                    oRow["EFA_Parentesco"] = item.Parentesco;
                    oRow["EFA_Nombre"] = item.Nombre;
                    oRow["EFA_Vivo"] = item.Vivo;
                    oRow["EFA_Dir"] = item.Direccion;
                    oRow["EFA_Ocupa"] = item.Ocupacion;
                    oRow["EFA_Edad"] = item.Edad;

                    oData.Tables["Familia"].Rows.Add(oRow);
                });
                #endregion

                #region Carga Estudios
                oEstudios.ForEach(item => {
                    oRow = oData.Tables["Estudios"].NewRow();
                    oRow["EXP_Id"] = item.IdExpediente;
                    oRow["EXE_Nivel"] = item.Nivel;
                    oRow["EXE_Nombre"] = item.Escuela;
                    oRow["EXE_Direccion"] = item.Direccion;
                    oRow["EXE_De"] = item.Desde;
                    oRow["EXE_Hasta"] = item.Hasta;
                    oRow["EXE_Anios"] = item.Anios;
                    oRow["EXE_Titulo"] = item.Titulo;
                    oRow["EXE_Actual"] = item.Actual;
                    oRow["EXE_Escuela"] = item.Actual;
                    oRow["EXE_Horario"] = item.Horario;
                    oRow["EXE_Curso"] = item.Curso;
                    oRow["EXE_Grado"] = item.Grado;

                    oData.Tables["Estudios"].Rows.Add(oRow);
                });
                #endregion

                #region Carga Empleos
                oEmpleos.ForEach(item => {
                    oRow = oData.Tables["Empleos"].NewRow();
                    oRow["EXP_Id"] = item.IdExpediente;
                    oRow["EEM_Tiempo"] = item.Tiempo;
                    oRow["EEM_Nombre"] = item.Empresa;
                    oRow["EEM_Direccion"] = item.Direccion;
                    oRow["EEM_Telefono"] = item.Telefono;
                    oRow["EEM_Puesto"] = item.Puesto;
                    oRow["EEM_SueldoInicial"] = item.SueldoIni;
                    oRow["EEM_SueldoFinal"] = item.SueldoFin;
                    oRow["EEM_Separacion"] = item.Separacion;
                    oRow["EEM_Jefe"] = item.Jefe;
                    oRow["EEM_PuestoJefe"] = item.PuestoJefe;
                    oRow["EEM_Informes"] = item.Informes;
                    oRow["EEM_Razon"] = item.Razon;
                    oRow["EEM_Comentarios"] = item.Comentarios;

                    oData.Tables["Empleos"].Rows.Add(oRow);
                });
                #endregion

                /* ALTA DE EXPEDIENTE */
                if (int.Parse(txtId.Text) == 0) {
                    //Result = oCHumano.CHU_Expedientes_Guardar(oData, BaseWinBP.UsuarioLogueado.ID);

                    if (Result != 0) {
                        RadMessageBox.Show("Expediente guardado correctamente\nEl folio asignado es: " + Result.ToString(), this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                    } else {
                        RadMessageBox.Show("Ocurrió un error al guardar el Expediente", this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
                    }
                } else {
                    //int Result = oCHumano.CHU_Perfiles_Actualiza(obj, oData);
                    if (Result != 0) {
                        RadMessageBox.Show("Expediente actualizado correctamente", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                    } else {
                        RadMessageBox.Show("Ocurrió un error al actualizar el expediente", this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
                    }
                }
                LimpiarCampos();
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al guardar el expediente\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally {
                oCHumano = null;
            }

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
        private void cboEntidad_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try {
                CargarDeptos();
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al seleccionar la entidad\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
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

        #region Métodos y Eventos TabWindows
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

        private void btnAddPariente_Click(object sender, EventArgs e)
        {
            ExpedienteFamilia obj = new ExpedienteFamilia();
            try {
                gvParientes.DataSource = null;

                obj.IdExpediente = int.Parse(txtId.Text);
                obj.Parentesco = cboParentesco.Text.ToUpper();
                obj.Nombre = txtNombrePariente.Text;
                obj.Vivo = opParienteVive.IsChecked;
                obj.Direccion = txtDireccionPariente.Text;
                obj.Ocupacion = txtOcupacionPariente.Text;
                obj.Edad = txtEdadPariente.Text.Trim().Length == 0 ? 0 : int.Parse(txtEdadPariente.Text);

                oFamilia.Add(obj);
                gvParientes.DataSource = oFamilia;

                cboParentesco.SelectedIndex = 0;
                txtNombrePariente.Text = string.Empty;
                txtDireccionPariente.Text = string.Empty;
                txtOcupacionPariente.Text = string.Empty;
                txtEdadPariente.Text = string.Empty;

            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al agregar la refenrecia familiar\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void btnAddEscuela_Click(object sender, EventArgs e)
        {
            ExpedienteEstudios obj = new ExpedienteEstudios();
            try {
                gvEstudios.DataSource = null;

                obj.IdExpediente = int.Parse(txtId.Text);
                obj.Nivel = cboEscolaridad.Text.ToUpper();
                obj.Escuela = txtEscuela.Text;
                obj.Direccion = txtDireccionEscuela.Text;
                obj.Desde = int.Parse(dtDesdeEscuela.Value.Year.ToString());
                obj.Hasta = int.Parse(dtHastaEscuela.Value.Year.ToString());
                obj.Anios = txtAniosEscuela.Text.Trim().Length > 0 ? int.Parse(txtAniosEscuela.Text) : 0;
                obj.Titulo = txtTituloEscuela.Text;
                obj.Actual = txtEstudiosEscuela.Text;
                obj.Horario = txtHorarioEscuela.Text;
                obj.Curso = txtCursoEscuela.Text;
                obj.Grado = txtGradoEscuela.Text;

                oEstudios.Add(obj);
                gvEstudios.DataSource = oEstudios;

                cboEscolaridad.SelectedIndex = 0;
                txtEscuela.Text = string.Empty;
                txtDireccionEscuela.Text = string.Empty;
                txtAniosEscuela.Text = string.Empty;
                txtTituloEscuela.Text = string.Empty;

            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al agregar la información escolar\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void btnAddEmpleo_Click(object sender, EventArgs e)
        {
            ExpedienteEmpleos obj = new ExpedienteEmpleos();
            try {
                gvEmpleos.DataSource = null;

                obj.IdExpediente = int.Parse(txtId.Text);
                obj.Tiempo = txtTiempoEmpleo.Text.Trim().Length == 0 ? 0 : int.Parse(txtTiempoEmpleo.Text);
                obj.Empresa = txtEmpresaEmpleo.Text;
                obj.Direccion = txtDireccionEmpleo.Text;
                obj.Telefono = txtTelefonoEmpleo.Text;
                obj.Puesto = txtPuestoEmpleo.Text;
                obj.SueldoIni = txtSueldoIniEmpleo.Text.Trim().Length == 0 ? 0 : decimal.Parse(txtSueldoIniEmpleo.Text);
                obj.SueldoFin = txtSueldoFinEmpleo.Text.Trim().Length == 0 ? 0 : decimal.Parse(txtSueldoFinEmpleo.Text);
                obj.Separacion = txtMotivoEmpleo.Text;
                obj.Jefe = txtJefeEmpleo.Text;
                obj.PuestoJefe = txtPuestoJefeEmpleo.Text;
                obj.Informes = opInformesSi.IsChecked ? true : false;
                obj.Razon = opInformesNo.IsChecked ? txtRazonInformes.Text : string.Empty;
                obj.Comentarios = txtComentariosJefes.Text;

                oEmpleos.Add(obj);
                gvEmpleos.DataSource = oEmpleos;

                txtTiempoEmpleo.Text = string.Empty;
                txtEmpresaEmpleo.Text = string.Empty;
                txtDireccionEmpleo.Text = string.Empty;
                txtTelefonoEmpleo.Text = string.Empty;
                txtPuestoEmpleo.Text = string.Empty;
                txtSueldoIniEmpleo.Text = string.Empty;
                txtSueldoFinEmpleo.Text = string.Empty;
                txtMotivoEmpleo.Text = string.Empty;
                txtJefeEmpleo.Text = string.Empty;
                txtPuestoJefeEmpleo.Text = string.Empty;
                txtRazonInformes.Text = string.Empty;
                txtComentariosJefes.Text = string.Empty;
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al agregar la información de empleos\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
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
                cboTipoExpediente.SelectedIndex = 0;
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
                txtEdad.Text = "0";
                txtEdadPariente.Text = string.Empty;
                txtEdoCivilOtro.Text = string.Empty;
                //txtEmpresaEmpleo.Text = string.Empty;
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

                #region RadGridView
                oFamilia.Clear();
                oEstudios.Clear();
                oEmpleos.Clear();

                gvParientes.DataSource = null;
                gvEstudios.DataSource = null;
                gvEmpleos.DataSource = null;
                #endregion
            } catch (Exception ex) {
                throw ex;
            }
        }
        private DataSet CrearTablasAuxiliares()
        {
            DataSet oDataset = new DataSet();
            DataTable oData;

            try {
                #region TABLA DE ENCABEZADO
                oData = new DataTable("Expediente");
                oData.Columns.Add("EXP_Id");
                oData.Columns.Add("DEP_Id");
                oData.Columns.Add("PUE_Id");
                oData.Columns.Add("EXP_Deseado");
                oData.Columns.Add("EXP_Aprobado");
                oData.Columns.Add("EXP_Contratado");
                oData.Columns.Add("EXP_TipoExpediente");
                oData.Columns.Add("EXP_Comentarios");

                oDataset.Tables.Add(oData);
                #endregion

                #region TABLA DE DATOS PERSONALES                
                oData = new DataTable("Personales");
                oData.Columns.Add("EXP_Id");
                oData.Columns.Add("EDP_APaterno");
                oData.Columns.Add("EDP_AMaterno");
                oData.Columns.Add("EDP_Nombres");
                oData.Columns.Add("EDP_Edad");
                oData.Columns.Add("EDP_Direccion");
                oData.Columns.Add("PAI_Id");
                oData.Columns.Add("EST_Id");
                oData.Columns.Add("CIU_Id");
                oData.Columns.Add("COL_Id");
                oData.Columns.Add("EDO_Nacimiento");
                oData.Columns.Add("CIU_Nacimiento");
                oData.Columns.Add("EDP_Telefono");
                oData.Columns.Add("EDP_Sexo");
                oData.Columns.Add("EDP_FechaNac");
                oData.Columns.Add("EDP_Nacionalidad");
                oData.Columns.Add("EDP_Vive");
                oData.Columns.Add("EDP_Estatura");
                oData.Columns.Add("EDP_Peso");
                oData.Columns.Add("EDP_Depende");
                oData.Columns.Add("EDP_DepenOtros");
                oData.Columns.Add("EDP_EdoCivil");
                oData.Columns.Add("EDP_EdoCivilOtros");

                oDataset.Tables.Add(oData);
                #endregion

                #region TABLA DE DOCUMENTOS
                oData = new DataTable("Documentos");
                oData.Columns.Add("EXP_Id");
                oData.Columns.Add("EDO_CURP");
                oData.Columns.Add("EDO_Afore");
                oData.Columns.Add("EDO_RFC");
                oData.Columns.Add("EDO_IMSS");
                oData.Columns.Add("EDO_Servicio");
                oData.Columns.Add("EDO_Pasaporte");
                oData.Columns.Add("EDO_Licencia");
                oData.Columns.Add("EDO_NoLicencia");
                oData.Columns.Add("EDO_DoctoExtranjero");

                oDataset.Tables.Add(oData);
                #endregion

                #region TABLA DE DATOS FAMILIARES
                oData = new DataTable("Familia");
                oData.Columns.Add("EXP_Id");
                oData.Columns.Add("EFA_Parentesco");
                oData.Columns.Add("EFA_Nombre");
                oData.Columns.Add("EFA_Vivo");
                oData.Columns.Add("EFA_Dir");
                oData.Columns.Add("EFA_Ocupa");
                oData.Columns.Add("EFA_Edad");

                oDataset.Tables.Add(oData);
                #endregion

                #region TABLA DE DATOS ESCOLARES
                oData = new DataTable("Estudios");
                oData.Columns.Add("EXP_Id");
                oData.Columns.Add("EXE_Nivel");
                oData.Columns.Add("EXE_Nombre");
                oData.Columns.Add("EXE_Direccion");
                oData.Columns.Add("EXE_De");
                oData.Columns.Add("EXE_Hasta");
                oData.Columns.Add("EXE_Anios");
                oData.Columns.Add("EXE_Titulo");
                oData.Columns.Add("EXE_Actual");
                oData.Columns.Add("EXE_Escuela");
                oData.Columns.Add("EXE_Horario");
                oData.Columns.Add("EXE_Curso");
                oData.Columns.Add("EXE_Grado");

                oDataset.Tables.Add(oData);
                #endregion

                #region TABLA DE DATOS DE EMPLEO
                oData = new DataTable("Empleos");
                oData.Columns.Add("EXP_Id");
                oData.Columns.Add("EEM_Tiempo");
                oData.Columns.Add("EEM_Nombre");
                oData.Columns.Add("EEM_Direccion");
                oData.Columns.Add("EEM_Telefono");
                oData.Columns.Add("EEM_Puesto");
                oData.Columns.Add("EEM_SueldoInicial");
                oData.Columns.Add("EEM_SueldoFinal");
                oData.Columns.Add("EEM_Separacion");
                oData.Columns.Add("EEM_Jefe");
                oData.Columns.Add("EEM_PuestoJefe");
                oData.Columns.Add("EEM_Informes");
                oData.Columns.Add("EEM_Razon");
                oData.Columns.Add("EEM_Comentarios");

                oDataset.Tables.Add(oData);
                #endregion

                #region TABLA DE DATOS DE SALUD
                oData = new DataTable("Salud");
                oData.Columns.Add("EXP_Id");
                oData.Columns.Add("ESA_EstadoActual");
                oData.Columns.Add("ESA_Enfermedad");
                oData.Columns.Add("ESA_Tipo");
                oData.Columns.Add("ESA_Deporte");
                oData.Columns.Add("ESA_Club");
                oData.Columns.Add("ESA_Pasatiempo");
                oData.Columns.Add("ESA_Meta");

                oDataset.Tables.Add(oData);
                #endregion

                #region TABLA DE DATOS DE CONOCIMIENTOS
                oData = new DataTable("Conocimiento" +
                    "");
                oData.Columns.Add("EXP_Id");
                oData.Columns.Add("ECO_Idioma");
                oData.Columns.Add("ECO_Porcentaje");
                oData.Columns.Add("ECO_Maquinas");
                oData.Columns.Add("ECO_Funciones");
                oData.Columns.Add("ECO_Otros");

                oDataset.Tables.Add(oData);
                #endregion

                #region TABLA DE DATOS DE REFERENCIAS
                oData = new DataTable("REFERENCIAS");
                oData.Columns.Add("EXP_Id");
                oData.Columns.Add("ERE_Nombre");
                oData.Columns.Add("ERE_Direccion");
                oData.Columns.Add("ERE_Telefono");
                oData.Columns.Add("ERE_Ocupacion");
                oData.Columns.Add("ERE_Tiempo");

                oDataset.Tables.Add(oData);
                #endregion

                #region TABLA DE DATOS DE REFERENCIAS
                oData = new DataTable("REFERENCIAS");
                oData.Columns.Add("EXP_Id");
                oData.Columns.Add("ERE_Nombre");
                oData.Columns.Add("ERE_Direccion");
                oData.Columns.Add("ERE_Telefono");
                oData.Columns.Add("ERE_Ocupacion");
                oData.Columns.Add("ERE_Tiempo");

                oDataset.Tables.Add(oData);
                #endregion

            } catch (Exception ex) {
                throw ex;
            }
            return oDataset;
        }
        #endregion

        
    }
}
