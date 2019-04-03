using Hersan.Entidades.CapitalHumano;
using Hersan.Entidades.Catalogos;
using Hersan.Negocio;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Windows.Forms;
using Telerik.WinControls;

namespace Hersan.UI.CapitalHumano
{
    public partial class frmExpediente : Telerik.WinControls.UI.RadForm
    {
        #region Variables        
        public int IdExpediente { get; set; }
        WCF_Catalogos.Hersan_CatalogosClient oCatalogos;
        CapitalHumano.WCF_CHumano.Hersan_CHumanoClient oCHumano;
        List<EntidadesBE> oEntidades = new List<EntidadesBE>();
        List<ColoniasBE> oColonia = new List<ColoniasBE>();
        ExpedientesDatosPersonales oDatosPersonales;
        List<ExpedientesBE> oExpediente = new List<ExpedientesBE>();
        List<ExpedienteFamilia> oFamilia = new List<ExpedienteFamilia>();
        List<ExpedienteEstudios> oEstudios = new List<ExpedienteEstudios>();
        List<ExpedienteEmpleos> oEmpleos = new List<ExpedienteEmpleos>();
        //List<ExpedienteSalud> oSalud = new List<ExpedienteSalud>();
        bool bSalud = false;
        bool bGeneral = false;
        List<ExpedienteReferencias> oReferencias = new List<ExpedienteReferencias>();
        string RutaImagen = @ConfigurationManager.AppSettings["RutaImagen"];
        byte[] Foto;
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
                    System.IO.FileInfo oFile = new System.IO.FileInfo(oDialog.FileName);

                    if (oFile.Length > 200000)
                        RadMessageBox.Show("La imagen debe no debe ser mayor a 200Kb", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                    else {                        
                        Foto = ConvertImage.FileToByteArray(oDialog.FileName);
                        picFoto.Image = ConvertImage.ByteToImage(Foto);
                    }
                }
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al cargar la fotografía del expediente\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try {
                if (RadMessageBox.Show("Ésta acción no guardará sus cambios, desea continar...?", this.Text, MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.Yes) {
                    this.tabDatos.Select();
                    LimpiarCampos();
                }
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al limpiar los campos\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            oCHumano = new WCF_CHumano.Hersan_CHumanoClient();
            DataSet oData = CrearTablasAuxiliares();
            int Result = 0;
            try {

                if (RadMessageBox.Show("Desea guardar la información capturada...?", this.Text, MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.No)
                    return;

                /* VALIDAR SI ES NUEVO O ACTUALIZACIÓN */
                if (int.Parse(txtId.Text) == -1) {
                    oDatosPersonales = new ExpedientesDatosPersonales();
                    oDatosPersonales.IdExpediente = int.Parse(txtId.Text);
                    oDatosPersonales.APaterno = txtAPaterno.Text;
                    oDatosPersonales.AMaterno = txtAMaterno.Text;
                    oDatosPersonales.Nombres = txtNombres.Text;
                    var oItem = oCHumano.CHU_ExpedientesDatosPersonales_Consultar(oDatosPersonales);

                    if (oItem.Count > 0) {
                        RadMessageBox.Show("EL nombre capturado ya se encuentra en el expediente: " + oItem[0].IdExpediente, this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                        oDatosPersonales = null;
                        return;
                    }
                }

                #region Carga Datos Expediente
                DataRow oRow = oData.Tables["Expediente"].NewRow();
                oRow["EXP_Id"] = int.Parse(txtId.Text);
                oRow["DEP_Id"] = int.Parse(cboDepto.SelectedValue.ToString());
                oRow["PUE_Id"] = int.Parse(cboPuesto.SelectedValue.ToString());
                oRow["EXP_Deseado"] = txtDeseado.Text.Trim().Length == 0 ? 0 : decimal.Parse(txtDeseado.Text);
                oRow["EXP_Aprobado"] = txtAprobado.Text.Trim().Length == 0 ? 0 : decimal.Parse(txtAprobado.Text);                
                oRow["EXP_TipoExpediente"] = cboTipoExpediente.Text;
                oRow["EXP_Comentarios"] = txtObserva.Text;
                oRow["EXP_RutaFoto"] = RutaImagen;
                if (dtFecha.Checked && cboTipoExpediente.Text == "EMPLEADO")
                    oRow["EXP_Contratado"] = dtFecha.Value.Year.ToString() + dtFecha.Value.Month.ToString().PadLeft(2, '0') + dtFecha.Value.Day.ToString().PadLeft(2, '0');
                else
                    oRow["EXP_Contratado"] = "19000101";


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
                oRow["EDP_Estatura"] = txtEstatura.Text.Trim().Length == 0 ? 0 : decimal.Parse(txtEstatura.Text);
                oRow["EDP_Peso"] = txtPeso.Text.Trim().Length == 0 ? 0 : int.Parse(txtPeso.Text);
                oRow["EDP_Depende"] = cboDependientes.Text.ToUpper();
                oRow["EDP_DepenOtros"] = txtOtrosDepen.Text;
                oRow["EDP_EdoCivil"] = cboEdoCivil.Text.ToUpper();
                oRow["EDP_EdoCivilOtros"] = txtEdoCivilOtro.Text;
                oRow["EDP_Correo"] = txtCorreo.Text;

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
                    if (item.DatosUsuario.Estatus == true) {
                        oRow = oData.Tables["Familia"].NewRow();
                        oRow["EXP_Id"] = item.IdExpediente;
                        oRow["EFA_Parentesco"] = item.Parentesco;
                        oRow["EFA_Nombre"] = item.Nombre;
                        oRow["EFA_Vivo"] = item.Vivo;
                        oRow["EFA_Dir"] = item.Direccion;
                        oRow["EFA_Ocupa"] = item.Ocupacion;
                        oRow["EFA_Edad"] = item.Edad;

                        oData.Tables["Familia"].Rows.Add(oRow);
                    }
                });
                #endregion

                #region Carga Estudios
                oEstudios.ForEach(item => {
                    if (item.DatosUsuario.Estatus == true) {
                        oRow = oData.Tables["Estudios"].NewRow();
                        oRow["EXP_Id"] = item.IdExpediente;
                        oRow["EXE_Nivel"] = item.Nivel;
                        oRow["EXE_Nombre"] = item.Escuela;
                        oRow["EXE_Direccion"] = item.Direccion;
                        oRow["EXE_De"] = item.Desde;
                        oRow["EXE_Hasta"] = item.Hasta;
                        oRow["EXE_Anios"] = item.Anios;
                        oRow["EXE_Titulo"] = item.Titulo;
                        oRow["EXE_Actual"] = txtEstudiosEscuela.Text.Trim().Length >0 ? true : false;
                        oRow["EXE_Escuela"] = txtEstudiosEscuela.Text;
                        oRow["EXE_Horario"] = txtHorarioEscuela.Text;
                        oRow["EXE_Curso"] = txtCursoEscuela.Text;
                        oRow["EXE_Grado"] = txtGradoEscuela.Text;

                        oData.Tables["Estudios"].Rows.Add(oRow);
                    }
                });
                #endregion

                #region Carga Empleos
                oEmpleos.ForEach(item => {
                    if (item.DatosUsuario.Estatus == true) {
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
                    }
                });
                #endregion

                #region Carga Salud
                if (bSalud) {
                    oRow = oData.Tables["Salud"].NewRow();
                    oRow["EXP_Id"] = int.Parse(txtId.Text);
                    oRow["ESA_EstadoActual"] = opSaludBueno.IsChecked ? "BUENO" : opSaludMalo.IsChecked ? "MALO" : opSaludRegular.IsChecked ? "REGULAR" : string.Empty;
                    oRow["ESA_Enfermedad"] = opEnfermoSi.IsChecked;
                    oRow["ESA_Tipo"] = txtEnfermedad.Text;
                    oRow["ESA_Deporte"] = txtDeporte.Text;
                    oRow["ESA_Club"] = txtClub.Text;
                    oRow["ESA_Pasatiempo"] = txtPasatiempo.Text;
                    oRow["ESA_Meta"] = txtMetaVida.Text;

                    oData.Tables["Salud"].Rows.Add(oRow);
                }
                #endregion

                #region Carga Conocimiento
                if (bSalud) {
                    oRow = oData.Tables["Conocimiento"].NewRow();
                    oRow["EXP_Id"] = int.Parse(txtId.Text);
                    oRow["ECO_Idioma"] = txtIdiomas.Text;
                    oRow["ECO_Porcentaje"] = string.Empty;
                    oRow["ECO_Maquinas"] = txtMaquinas.Text;
                    oRow["ECO_Funciones"] = txtFunciones.Text;
                    oRow["ECO_Software"] = txtSoftware.Text;
                    oRow["ECO_Otros"] = txtOtrosTrabajos.Text;

                    oData.Tables["Conocimiento"].Rows.Add(oRow);
                }
                #endregion

                #region Carga Referencias
                oReferencias.ForEach(item => {
                    if (item.DatosUsuario.Estatus == true) {
                        oRow = oData.Tables["Referencias"].NewRow();
                        oRow["EXP_Id"] = int.Parse(txtId.Text);
                        oRow["ERE_Nombre"] = item.Nombre;
                        oRow["ERE_Direccion"] = item.Direccion;
                        oRow["ERE_Telefono"] = item.Telefono;
                        oRow["ERE_Ocupacion"] = item.Ocupacion;
                        oRow["ERE_Tiempo"] = item.Tiempo;

                        oData.Tables["Referencias"].Rows.Add(oRow);
                    }
                });
                #endregion

                #region Carga Genarales
                if (bGeneral) {
                    oRow = oData.Tables["Genarales"].NewRow();
                    oRow["EXP_Id"] = int.Parse(txtId.Text);
                    oRow["EXP_Anuncio"] = opAnuncio.IsChecked;
                    oRow["EGE_Otro"] = txtOtroMedio.Text;
                    oRow["EGE_Parientes"] = opParientesSi.IsChecked;
                    oRow["EGE_Nombres"] = txtParientesSi.Text;
                    oRow["EGE_Fianza"] = opAfianzadoSi.IsChecked;
                    oRow["EGE_Afianzadora"] = txtAfianzadoSi.Text;
                    oRow["EGE_Sindilizado"] = opSindicatoSi.IsChecked;
                    oRow["EGE_Sindicato"] = txtSindicatoSi.Text;
                    oRow["EGE_SeguroVida"] = opSeguroVidaSi.IsChecked;
                    oRow["EGE_Aseguradora"] = txtSeguroVidaSi.Text;
                    oRow["EGE_Viajar"] = opViajarSi.IsChecked;
                    oRow["EGE_Razon"] = txtViajarNo.Text;
                    oRow["EGE_Residencia"] = opCambiarSi.IsChecked;
                    oRow["EGE_Motivo"] = txtCambiarNo.Text;
                    oRow["EGE_Fecha"] = dtFechaTrabajar.Value.Year.ToString() + dtFechaTrabajar.Value.Month.ToString().PadLeft(2, '0') + dtFechaTrabajar.Value.Day.ToString().PadLeft(2, '0');

                    oData.Tables["Genarales"].Rows.Add(oRow);
                }
                #endregion

                #region Carga Economicos
                if (bGeneral) {
                    oRow = oData.Tables["Economicos"].NewRow();
                    oRow["EXP_Id"] = int.Parse(txtId.Text);
                    oRow["EDE_OtrosIngresos"] = opIngresoSi.IsChecked;
                    oRow["EDE_Nombre"] = txtIngresoSi.Text;
                    oRow["EDE_Monto"] = txtIngresoMensual.Text.Trim().Length == 0 ? 0 : decimal.Parse(txtIngresoMensual.Text);
                    oRow["EDE_Conyugue"] = opConyugeSi.IsChecked;
                    oRow["EDE_Donde"] = txtConyugeSi.Text;
                    oRow["EDE_Sueldo"] = txtPercepcionMes.Text.Trim().Length == 0 ? 0 : decimal.Parse(txtPercepcionMes.Text);
                    oRow["EDE_Casa"] = opPropiaSi.IsChecked;
                    oRow["EDE_Valor"] = txtValorAprox.Text.Trim().Length == 0 ? 0 : decimal.Parse(txtValorAprox.Text);
                    oRow["EDE_Renta"] = opRentaSi.IsChecked;
                    oRow["EDE_Pago"] = txtRentaMes.Text.Trim().Length == 0 ? 0 : decimal.Parse(txtRentaMes.Text);
                    oRow["EDE_Auto"] = opAutoSi.IsChecked;
                    oRow["EDE_Marca"] = txtMarca.Text;
                    oRow["EDE_Modelo"] = txtModelo.Text;
                    oRow["EDE_Deudas"] = opDeudaSi.IsChecked;
                    oRow["EDE_Quien"] = txtDeudaSi.Text;
                    oRow["EDE_Importe"] = txtDeudaImporte.Text.Trim().Length == 0 ? 0 : decimal.Parse(txtDeudaImporte.Text);
                    oRow["EDE_Abono"] = txtAbonoMes.Text.Trim().Length == 0 ? 0 : decimal.Parse(txtAbonoMes.Text);
                    oRow["EDE_Gastos"] = txtGastosMes.Text.Trim().Length == 0 ? 0 : decimal.Parse(txtGastosMes.Text);

                    oData.Tables["Economicos"].Rows.Add(oRow);
                }
                #endregion
                                
                /* ALTA DE EXPEDIENTE */
                if (int.Parse(txtId.Text) == -1) {
                    Result = oCHumano.CHU_Expedientes_Guardar(oData, Foto, BaseWinBP.UsuarioLogueado.ID);

                    if (Result != 0) {
                        RadMessageBox.Show("Expediente guardado correctamente\nEl folio asignado es: " + Result.ToString(), this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                    } else {
                        RadMessageBox.Show("Ocurrió un error al guardar el Expediente", this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
                    }
                } else {
                    Result = oCHumano.CHU_Expedientes_Actualizar(int.Parse(txtId.Text), oData, Foto, BaseWinBP.UsuarioLogueado.ID);
                    if (Result != 0) {
                        RadMessageBox.Show("Expediente actualizado correctamente", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                    } else {
                        RadMessageBox.Show("Ocurrió un error al actualizar el expediente", this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
                    }
                }
                if (Result != 0) {
                    LimpiarCampos();
                    this.tabDatos.Select();
                }
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al guardar el expediente\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally {
                oCHumano = null;
            }

        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            oCHumano = new WCF_CHumano.Hersan_CHumanoClient();
            try {
                if (int.Parse(txtId.Text) > 0) {
                    if (RadMessageBox.Show("Desea dar de baja el expediente actual...?", this.Text, MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.Yes) {
                        if (oCHumano.CHU_Expedientes_Eliminar(int.Parse(txtId.Text), BaseWinBP.UsuarioLogueado.ID) > 0) {
                            RadMessageBox.Show("Expediente: " + txtId.Text + ", eliminado correctamente", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                            LimpiarCampos();
                        }else
                            RadMessageBox.Show("Ocurrió un error al dar de baja ", this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
                    }
                }
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al dar de baja el expediente\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally {
                oCHumano = null;
            }
        }
        private void btnReporte_Click(object sender, EventArgs e)
        {
            //Datos obj = new Datos();
            try {
                frmViewer frm = new frmViewer();
                frm.iReport = new Reportes.rtpExpediente();
                //frm.iReport.SetDataSource(SP Origen de Datos);
                //frm.iReport.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, System.IO.Directory.GetCurrentDirectory() + @"\Ganadores_Sorteo.pdf");
                frm.VerImprimir = frmViewer.Modo.Ver;
                //frm.iReport.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, @"c:\Temp\Test.pdf");

                //MOSTRAR EN PANTALLA
                frm.WindowState = FormWindowState.Maximized;
                frm.ShowDialog();

                MessageBox.Show("Reporte generado correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                ////ABRIR ARCHIVO PDF
                //Process.Start(System.IO.Directory.GetCurrentDirectory() + @"\Ganadores_Sorteo.pdf");
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al mostrar el reporte\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } 
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int IdExpediente = 0;
            try {
                frmExpedienteConsulta ofrm = new frmExpedienteConsulta();
                ofrm.WindowState = FormWindowState.Normal;
                ofrm.StartPosition = FormStartPosition.CenterScreen;
                ofrm.MaximizeBox = false;
                ofrm.MinimizeBox = false;
                ofrm.ShowDialog();
                IdExpediente = ofrm.IdExpediente;
                this.tabDatos.Select();

                if (IdExpediente > 0) {
                    LimpiarCampos();
                    CargaExpediente(IdExpediente);
                }
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al realiza la búsqueda\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
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
            oCHumano = new WCF_CHumano.Hersan_CHumanoClient();
            try {
                switch (e.DockWindow.Name) {
                    case "tabFamilia":
                        if (gvParientes.RowCount == 0) {
                            ExpedienteFamilia oAux = new ExpedienteFamilia();
                            oAux.IdExpediente = int.Parse(txtId.Text);
                            oFamilia = oCHumano.CHU_Expediente_Familia_Consultar(oAux);
                            gvParientes.DataSource = oFamilia;
                        }
                        if (gvEstudios.RowCount == 0) {
                            ExpedienteEstudios oEst = new ExpedienteEstudios();
                            oEst.IdExpediente = int.Parse(txtId.Text);
                            oEstudios = oCHumano.CHU_Expediente_Estudios_Consultar(oEst);
                            gvEstudios.DataSource = oEstudios;
                            if(oEstudios.Count > 0) {
                                txtEstudiosEscuela.Text = oEstudios[0].Escuela;
                                txtHorarioEscuela.Text = oEstudios[0].Horario;
                                txtCursoEscuela.Text = oEstudios[0].Curso;
                                txtGradoEscuela.Text = oEstudios[0].Grado;
                            }
                        }
                        break;
                    case "tabEmpleos":
                        if (gvEmpleos.RowCount == 0) {
                            ExpedienteEmpleos oEmp = new ExpedienteEmpleos();
                            oEmp.IdExpediente = int.Parse(txtId.Text);
                            oEmpleos = oCHumano.CHU_Expediente_Empleos_Consultar(oEmp);
                            gvEmpleos.DataSource = oEmpleos;
                        }
                        break;
                    case "tabConoc":
                        #region Tab Conocimiento
                        bSalud = true;
                        ExpedienteSalud oSalud = new ExpedienteSalud();
                        oSalud.IdExpediente = int.Parse(txtId.Text);
                        var Salud = oCHumano.CHU_Expediente_Salud_Consultar(oSalud);
                        if(Salud.Count > 0) {
                            opSaludBueno.IsChecked = Salud[0].EstadoActual.ToString() == opSaludBueno.Text.ToUpper() ? true : false;
                            opSaludMalo.IsChecked = Salud[0].EstadoActual.ToString() == opSaludMalo.Text.ToUpper() ? true : false;
                            opSaludRegular.IsChecked = Salud[0].EstadoActual.ToString() == opSaludRegular.Text.ToUpper() ? true : false;
                            opEnfermoSi.IsChecked = Salud[0].Enfermedad;
                            opEnfermoNo.IsChecked = !opEnfermoSi.IsChecked;
                            txtEnfermedad.Text = Salud[0].Tipo;
                            txtDeporte.Text = Salud[0].Deporte;
                            txtClub.Text = Salud[0].Club;
                            txtPasatiempo.Text = Salud[0].Pasatiempo;
                            txtMetaVida.Text = Salud[0].Meta;
                        }

                        ExpedienteConocimiento oConoc = new ExpedienteConocimiento();
                        oConoc.IdExpediente = int.Parse(txtId.Text);
                        var Conoc = oCHumano.CHU_Expediente_Conocimiento_Consultar(oConoc);
                        if (Conoc.Count > 0) {
                            txtIdiomas.Text = Conoc[0].Idioma;
                            txtFunciones.Text = Conoc[0].Funciones;
                            txtMaquinas.Text = Conoc[0].Maquinas;
                            txtSoftware.Text = Conoc[0].Software;
                            txtOtrosTrabajos.Text = Conoc[0].Otros;
                        }

                        if (gvReferencias.RowCount == 0) {
                            ExpedienteReferencias oRef = new ExpedienteReferencias();
                            oRef.IdExpediente = int.Parse(txtId.Text);
                            oReferencias = oCHumano.CHU_Expediente_Referencias_Consultar(oRef);
                            gvReferencias.DataSource = oReferencias;
                        }
                        #endregion
                        break;
                    case "tabEconomia":
                        #region Datos Grales
                        bGeneral = true;
                        ExpedienteGenerales oGen = new ExpedienteGenerales();
                        oGen.IdExpediente = int.Parse(txtId.Text);
                        var Gral = oCHumano.CHU_Expediente_Generales_Consultar(oGen);

                        if (Gral.Count > 0) {
                            opAnuncio.IsChecked = Gral[0].Anuncio;
                            opOtroMedio.IsChecked = !opAnuncio.IsChecked;
                            txtOtroMedio.Text = Gral[0].Otro;
                            opParientesSi.IsChecked = Gral[0].Parientes;
                            opParientesNo.IsChecked = !opParientesSi.IsChecked;
                            txtParientesSi.Text = Gral[0].Nombres;
                            opAfianzadoSi.IsChecked = Gral[0].Fianza;
                            opAfianzadoNo.IsChecked = !opAfianzadoSi.IsChecked;
                            txtAfianzadoSi.Text = Gral[0].Afinazadora;
                            opSindicatoSi.IsChecked = Gral[0].Sindicalizado;
                            opSindicatoNo.IsChecked = !opSindicatoSi.IsChecked;
                            txtSindicatoSi.Text = Gral[0].Sindicato;
                            opSeguroVidaSi.IsChecked = Gral[0].SeguroVida;
                            opSeguroVidaNo.IsChecked = !opSeguroVidaSi.IsChecked;
                            txtSeguroVidaSi.Text = Gral[0].Aseguradora;
                            opViajarSi.IsChecked = Gral[0].Viajar;
                            opViajarNo.IsChecked = !opViajarSi.IsChecked;
                            txtViajarNo.Text = Gral[0].Razon;
                            opCambiarSi.IsChecked = Gral[0].Residencia;
                            opCambiarNo.IsChecked = !opCambiarSi.IsChecked;
                            txtCambiarNo.Text = Gral[0].Motivo;
                            dtFechaTrabajar.Value = DateTime.Parse(Gral[0].Fecha);
                        }
                        #endregion

                        #region Datos Económicos
                        ExpedienteEconomicos oEco = new ExpedienteEconomicos();
                        oEco.IdExpediente = int.Parse(txtId.Text);
                        var Econo = oCHumano.CHU_Expediente_Economicos_Consultar(oEco);

                        if (Econo.Count > 0) {
                            opIngresoSi.IsChecked = Econo[0].OtrosIngresos;
                            opIngresoNo.IsChecked = !opIngresoSi.IsChecked;
                            txtIngresoSi.Text = Econo[0].Nombre;
                            txtIngresoMensual.Text = Econo[0].Monto.ToString();
                            opConyugeSi.IsChecked = Econo[0].Conyuge;
                            opConyugeNo.IsChecked = !opConyugeSi.IsChecked;
                            txtConyugeSi.Text = Econo[0].Donde;
                            txtPercepcionMes.Text = Econo[0].Sueldo.ToString();
                            opPropiaSi.IsChecked = Econo[0].Casa;
                            opPropiaNo.IsChecked = !opPropiaSi.IsChecked;
                            txtValorAprox.Text = Econo[0].Valor.ToString();
                            opRentaSi.IsChecked = Econo[0].Renta;
                            opRentaNo.IsChecked = !opRentaSi.IsChecked;
                            txtRentaMes.Text = Econo[0].Pago.ToString();
                            opAutoSi.IsChecked = Econo[0].Auto;
                            opAutoNo.IsChecked = !opAutoSi.IsChecked;
                            txtModelo.Text = Econo[0].Modelo;
                            txtMarca.Text = Econo[0].Marca;
                            opDeudaSi.IsChecked = Econo[0].Deudas;
                            opDeudaNo.IsChecked = !opDeudaSi.IsChecked;
                            txtDeudaSi.Text = Econo[0].Quien;
                            txtDeudaImporte.Text = Econo[0].Importe.ToString();
                            txtAbonoMes.Text = Econo[0].Abono.ToString();
                            txtGastosMes.Text = Econo[0].Gastos.ToString();

                        }
                        #endregion
                        break;
                }

            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al seleccionar la entidad\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally {
                oCHumano = null;
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
                gvParientes.DataSource = oFamilia.FindAll(item => item.DatosUsuario.Estatus == true);

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
                gvEstudios.DataSource = oEstudios.FindAll(item => item.DatosUsuario.Estatus == true); ;

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
                gvEmpleos.DataSource = oEmpleos.FindAll(item => item.DatosUsuario.Estatus == true); ;

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
        private void btnAddReferencia_Click(object sender, EventArgs e)
        {
            ExpedienteReferencias obj = new ExpedienteReferencias();
            try {
                gvReferencias.DataSource = null;

                obj.IdExpediente = int.Parse(txtId.Text);
                obj.Nombre = txtNombreReferencia.Text;
                obj.Direccion = txtDireccionReferencia.Text;
                obj.Telefono = txtTelefonoReferencia.Text;
                obj.Ocupacion = txtOcupacionReferencia.Text;
                obj.Tiempo = txtTiempoReferencia.Text.Trim().Length == 0 ? 0 : int.Parse(txtTiempoReferencia.Text);

                oReferencias.Add(obj);
                gvReferencias.DataSource = oReferencias.FindAll(item => item.DatosUsuario.Estatus == true); ;

                txtNombreReferencia.Text = string.Empty;
                txtDireccionReferencia.Text = string.Empty;
                txtTelefonoReferencia.Text = string.Empty;
                txtOcupacionReferencia.Text = string.Empty;
                txtTiempoReferencia.Text = string.Empty;
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al agregar la referencia\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }

        private void btnQuitarFamilia_Click(object sender, EventArgs e)
        {
            try {
                if (int.Parse(txtId.Text) == -1)
                    oFamilia.RemoveAll(item => item.Sel == true);
                else
                    oFamilia.ForEach(item => {
                        if (item.Sel == true)
                            item.DatosUsuario.Estatus = false;
                    });

                gvParientes.DataSource = null;
                gvParientes.DataSource = oFamilia.FindAll(item => item.DatosUsuario.Estatus == true);
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al quitar el elemento seleccionado\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void btnQuitarEscuela_Click(object sender, EventArgs e)
        {
            try {
                if (int.Parse(txtId.Text) == -1)
                    oEstudios.RemoveAll(item => item.Sel == true);
                else
                    oEstudios.ForEach(item => {
                        if (item.Sel == true)
                            item.DatosUsuario.Estatus = false;
                    });

                gvEstudios.DataSource = null;
                gvEstudios.DataSource = oEstudios.FindAll(item => item.DatosUsuario.Estatus == true);
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al quitar el elemento seleccionado\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void btnQuitarEmpleo_Click(object sender, EventArgs e)
        {
            try {
                if (int.Parse(txtId.Text) == -1)
                    oEmpleos.RemoveAll(item => item.Sel == true);
                else
                    oEmpleos.ForEach(item => {
                        if (item.Sel == true)
                            item.DatosUsuario.Estatus = false;
                    });

                gvEmpleos.DataSource = null;
                gvEmpleos.DataSource = oEmpleos.FindAll(item => item.DatosUsuario.Estatus == true);
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al quitar el elemento seleccionado\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void btnQuitarReferencia_Click(object sender, EventArgs e)
        {
            try {
                if (int.Parse(txtId.Text) == -1)
                    oReferencias.RemoveAll(item => item.Sel == true);
                else
                    oReferencias.ForEach(item => {
                        if (item.Sel == true)
                            item.DatosUsuario.Estatus = false;
                    });

                gvReferencias.DataSource = null;
                gvReferencias.DataSource = oReferencias.FindAll(item => item.DatosUsuario.Estatus == true);
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al quitar el elemento seleccionado\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
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
                RutaImagen = string.Empty;
                Foto = null;
                picFoto.Image = null;
                bGeneral = false;
                bSalud = false;

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
                txtId.Text = "-1";
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
                oReferencias.Clear();

                gvParientes.DataSource = null;
                gvEstudios.DataSource = null;
                gvEmpleos.DataSource = null;
                gvReferencias.DataSource = null;
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
                oData.Columns.Add("EXP_RutaFoto");

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
                oData.Columns.Add("EDP_Correo");

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
                oData = new DataTable("Conocimiento");
                oData.Columns.Add("EXP_Id");
                oData.Columns.Add("ECO_Idioma");
                oData.Columns.Add("ECO_Porcentaje");
                oData.Columns.Add("ECO_Maquinas");
                oData.Columns.Add("ECO_Funciones");
                oData.Columns.Add("ECO_Software");
                oData.Columns.Add("ECO_Otros");

                oDataset.Tables.Add(oData);
                #endregion

                #region TABLA DE DATOS DE REFERENCIAS
                oData = new DataTable("Referencias");
                oData.Columns.Add("EXP_Id");
                oData.Columns.Add("ERE_Nombre");
                oData.Columns.Add("ERE_Direccion");
                oData.Columns.Add("ERE_Telefono");
                oData.Columns.Add("ERE_Ocupacion");
                oData.Columns.Add("ERE_Tiempo");

                oDataset.Tables.Add(oData);
                #endregion

                #region TABLA DE DATOS GENERALES
                oData = new DataTable("Genarales");
                oData.Columns.Add("EXP_Id");
                oData.Columns.Add("EXP_Anuncio");
                oData.Columns.Add("EGE_Otro");
                oData.Columns.Add("EGE_Parientes");
                oData.Columns.Add("EGE_Nombres");
                oData.Columns.Add("EGE_Fianza");
                oData.Columns.Add("EGE_Afianzadora");
                oData.Columns.Add("EGE_Sindilizado");
                oData.Columns.Add("EGE_Sindicato");
                oData.Columns.Add("EGE_SeguroVida");
                oData.Columns.Add("EGE_Aseguradora");
                oData.Columns.Add("EGE_Viajar");
                oData.Columns.Add("EGE_Razon");
                oData.Columns.Add("EGE_Residencia");
                oData.Columns.Add("EGE_Motivo");
                oData.Columns.Add("EGE_Fecha");

                oDataset.Tables.Add(oData);
                #endregion

                #region TABLA DE DATOS ECONOMICOS
                oData = new DataTable("Economicos");
                oData.Columns.Add("EXP_Id");
                oData.Columns.Add("EDE_OtrosIngresos");
                oData.Columns.Add("EDE_Nombre");
                oData.Columns.Add("EDE_Monto");
                oData.Columns.Add("EDE_Conyugue");
                oData.Columns.Add("EDE_Donde");
                oData.Columns.Add("EDE_Sueldo");
                oData.Columns.Add("EDE_Casa");
                oData.Columns.Add("EDE_Valor");
                oData.Columns.Add("EDE_Renta");
                oData.Columns.Add("EDE_Pago");
                oData.Columns.Add("EDE_Auto");
                oData.Columns.Add("EDE_Marca");
                oData.Columns.Add("EDE_Modelo");
                oData.Columns.Add("EDE_Deudas");
                oData.Columns.Add("EDE_Quien");
                oData.Columns.Add("EDE_Importe");
                oData.Columns.Add("EDE_Abono");
                oData.Columns.Add("EDE_Gastos");

                oDataset.Tables.Add(oData);
                #endregion

            } catch (Exception ex) {
                throw ex;
            }
            return oDataset;
        }
        private void CargaExpediente(int IdExpediente)
        {
            oCHumano = new WCF_CHumano.Hersan_CHumanoClient();

            try {
                oExpediente = oCHumano.CHU_Expedientes_Obtener(IdExpediente);
                if (oExpediente.Count > 0) {

                    #region  SE CARGA EL EXPEDIENTE
                    txtId.Text = IdExpediente.ToString();
                    cboEntidad.SelectedValue = oExpediente[0].Puesto.Departamentos.Entidades.Id;
                    cboDepto.SelectedValue = oExpediente[0].Puesto.Departamentos.Id;
                    cboPuesto.SelectedValue = oExpediente[0].Puesto.Id;
                    cboTipoExpediente.Text = oExpediente[0].Tipo;
                    txtDeseado.Text = oExpediente[0].SueldoDeseado.ToString();
                    txtAprobado.Text = oExpediente[0].SueldoAprobado.ToString();
                    txtObserva.Text = oExpediente[0].Comentarios;
                    RutaImagen = oExpediente[0].RutaImagen;
                    if (oExpediente[0].Foto != null) {
                        Foto = oExpediente[0].Foto;
                        picFoto.Image = ConvertImage.ByteToImage(Foto);
                    }
                    #endregion

                    #region  SE CARGA LOS DATOS PERSONALES
                    this.tabDatos.Select();

                    ExpedientesDatosPersonales oAux = new ExpedientesDatosPersonales();
                    oAux.IdExpediente = int.Parse(txtId.Text);
                    var Item = oCHumano.CHU_ExpedientesDatosPersonales_Consultar(oAux);

                    if (Item.Count > 0) {
                        txtAPaterno.Text = Item[0].APaterno;
                        txtAMaterno.Text = Item[0].AMaterno;
                        txtNombres.Text = Item[0].Nombres;
                        txtEdad.Text = Item[0].Edad.ToString();
                        txtDomicilio.Text = Item[0].Direccion;
                        cboEstado.SelectedValue = Item[0].Estado.Id;
                        cboCiudad.SelectedValue = Item[0].Ciudad.Id;
                        cboColonia.SelectedValue = Item[0].Colonia.Id;
                        cboEdoNac.SelectedValue = Item[0].EstadoNac.Id;
                        cboCiudadNac.SelectedValue = Item[0].CiudadNac.Id;
                        txtTelefono.Text = Item[0].Telefono;
                        cboSexo.Text = Item[0].Sexo;
                        dtFecNac.Value = DateTime.Parse(Item[0].FechaNac);
                        txtNacionalidad.Text = Item[0].Nacionalidad;
                        cboVive.Text = Item[0].ViveCon;
                        txtEstatura.Text = Item[0].Estatura.ToString();
                        txtPeso.Text = Item[0].Peso.ToString();
                        cboDependientes.Text = Item[0].Dependientes;
                        txtOtrosDepen.Text = Item[0].OtrosDependientes;
                        cboEdoCivil.Text = Item[0].EdoCivil;
                        txtEdoCivilOtro.Text = Item[0].EdoCivilOtro;
                        txtCorreo.Text = Item[0].Correo;
                    }
                    #endregion

                    #region SE CARGA LA INFO DE DOCUMENTOS
                    ExpedienteDocumentos oDoctos = new ExpedienteDocumentos();
                    oAux.IdExpediente = int.Parse(txtId.Text);
                    var oListDoctos = oCHumano.CHU_ExpedientesDocumentos_Consultar(oDoctos);

                    txtCurp.Text = oListDoctos[0].CURP;
                    txtRFC.Text = oListDoctos[0].RFC;
                    txtAfore.Text = oListDoctos[0].Afore;
                    txtImss.Text = oListDoctos[0].IMSS;
                    txtCartilla.Text = oListDoctos[0].Servicio;
                    txtPasaporte.Text = oListDoctos[0].Pasaporte;
                    opLicenciaSi.IsChecked = oListDoctos[0].Licencia;
                    opLicenciaNo.IsChecked = !opLicenciaSi.IsChecked;
                    txtLicencia.Text = oListDoctos[0].NoLicencia;
                    txtDoctoTrabajo.Text = oListDoctos[0].DoctoExtranjero;
                    #endregion
                }
            } catch (Exception ex) {
                throw ex;
            } finally {
                oCHumano = null;
            }

        }
        #endregion

    }
}
