using Hersan.Entidades.CapitalHumano;
using Hersan.Entidades.Catalogos;
using Hersan.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace Hersan.UI.CapitalHumano
{
    public partial class frmDescripcionPuestos : Telerik.WinControls.UI.RadForm
    {
        #region Variables
        WCF_Catalogos.Hersan_CatalogosClient oCatalogos;
        WCF_CHumano.Hersan_CHumanoClient oCHumano;
        List<PerfilDescripcionBE> oList = new List<PerfilDescripcionBE>();
        List<DescPuestosContactosBE> pList = new List<DescPuestosContactosBE>();
        List<DescPuestoContratoTrabajo> tList = new List<DescPuestoContratoTrabajo>();
        List<EntidadesBE> oEntidades = new List<EntidadesBE>();
        List<ContactosBE> cList = new List<ContactosBE>();
        List<PuestosBE> puList = new List<PuestosBE>();        
        bool Flag;
        decimal resultado;
        DescPuestosContactosBE obj;
        #endregion

        public frmDescripcionPuestos()
        {
            InitializeComponent();
        }              
        private void frmDescripcionPuestos_Load(object sender, EventArgs e)
        {
            try {

                // Summatoria de datos
                GridViewSummaryRowItem item1 = new GridViewSummaryRowItem();
                item1.Add(new GridViewSummaryItem("Total", "Total:  {0:N2}", GridAggregateFunction.Sum));
                this.grdDatos.SummaryRowsBottom.Add(item1);
                CargarEntidades();
                LimpiarCampos();
                LimpiarDatos();

                CargarCContactos();
                CalcularPuntos();

            } catch (Exception) {

                throw;
            }
        }
        private void cboEntidad_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try {
                if (cboEntidad.SelectedValue != null)
                    CargarDeptos();
                else
                    cboDepto.DataSource = null;
            } catch (Exception ex) {
                throw ex;
            }
        }
        private void cboDepto_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try {
                if (cboDepto.SelectedValue != null)
                    CargarPuestos();
                else
                    cboPuestos.DataSource = null;
            } catch (Exception ex) {
                throw ex;
            }
        }
        private void cboPuestos_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try {
                if (cboPuestos.Items.Count > 0 && cboPuestos.SelectedValue != null) {
                    LimpiarDatos();
                    CargarGrid();
                    CargarGridContactos();
                    CargarPuntos();
                    CalcularPuntos();
                    CargarJerarquias();
                } else {
                    cboPuestos.DataSource = null;
                    txtSuperior.Clear();
                    lstInferior.DataSource = null;
                }
            } catch (Exception ex) {
                throw ex;
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
        private void cboContactos_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try {


            } catch (Exception ex) {

                RadMessageBox.Show("Ocurrió un error al seleccionar un contacto\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void btnQuitarItem_Click(object sender, EventArgs e)
        {
            try {

                if (pList.FindAll(item => item.Sel == true).Count > 0) {
                    if (RadMessageBox.Show("Esta acción eliminara los elementos seleccionados\nDesea continuar...?", this.Text, MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.No)
                        return;
                } else {
                    RadMessageBox.Show("No hay contacto seleccionado seleccionados", this.Text, MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                    return;
                }

                if (txtId.Text == "0")
                    pList.RemoveAll(item => item.Sel == true);
                else {
                    pList.ForEach(item => {
                        if (item.Sel == true)
                            item.DatosUsuario.Estatus = false;
                    });
                    pList.RemoveAll(item => item.DatosUsuario.Estatus == false);
                }

                ActualizaGrid();

            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al quitar un item\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void btnQuitarTodo_Click(object sender, EventArgs e)
        {
            try {
                if (pList.Count > 0) {
                    if (RadMessageBox.Show("Esta acción eliminara todos los elementos\nDesea continuar...?", this.Text, MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.No)
                        return;
                } else {
                    RadMessageBox.Show("No se han agregado contacto", this.Text, MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                    return;
                }

                if (txtId.Text == "0")
                    pList.Clear();
                else {
                    pList.ForEach(item => item.DatosUsuario.Estatus = false);
                    pList.RemoveAll(item => item.DatosUsuario.Estatus == false);
                }


                ActualizaGrid();
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al quitar todos los items\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            oCHumano = new WCF_CHumano.Hersan_CHumanoClient();
            DataTable oData = new DataTable("Datos");
            DataTable oData1 = new DataTable("Donnees");

            try {
                if (!ValidarCampos()) {
                    RadMessageBox.Show("Debe capturar todos los datos para continuar", this.Text, MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                    return;
                }

                oData.Columns.Add("Id");
                oData.Columns.Add("Tipo");
                oData.Columns.Add("Estatus");

                oData1.Columns.Add("Esfuerzo");
                oData1.Columns.Add("Riesgo");
                oData1.Columns.Add("Condicion");
                oData1.Columns.Add("Equipo");
                oData1.Columns.Add("Actividades");

                #region Carga Detalle



                DescripcionPuestosBE obj = new DescripcionPuestosBE();
                pList.ForEach(item => {
                    DataRow oRow = oData.NewRow();
                    oRow["Id"] = item.Id;
                    oRow["Tipo"] = item.Tipo;
                    oRow["Estatus"] = item.DatosUsuario.Estatus;

                    oData.Rows.Add(oRow);

                });

                obj.Id = txtId.Text.Trim().Length > 0 ? int.Parse(txtId.Text) : 0;
                obj.Perfiles.Id = int.Parse(txtIdPerfil.Text);
                obj.Colabordores = cboColaboradores.SelectedIndex;
                obj.Autoridad = txtAutoridad.Text;
                obj.Objetivo = txtObjetivo.Text;
                obj.Observaciones = txtObservaciones.Text;
                obj.DatosUsuario.IdUsuarioCreo = BaseWinBP.UsuarioLogueado.ID;

                DataRow oRow1 = oData1.NewRow();
                oRow1["Esfuerzo"] = txtEsfuerzo.Text;
                oRow1["Riesgo"] = txtRiesgo.Text;
                oRow1["Condicion"] = txtCondiciones.Text;
                oRow1["Equipo"] = txtEquipo.Text;
                oRow1["Actividades"] = txtActividades.Text;

                oData1.Rows.Add(oRow1);



                #endregion


                /* ALTA DE PERFIL */
                if (int.Parse(txtId.Text) == 0) {
                    int Result = oCHumano.CHU_DescPuestos_Guardar(obj, oData, oData1);
                    if (Result != 0) {

                        RadMessageBox.Show("Descripcion de puesto guardada correctamente", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                    } else {
                        RadMessageBox.Show("Ocurrió un error al guardar la descripcion de puesto", this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
                    }
                } else {
                    int Result = oCHumano.CHU_DescPuestos_Actualizar(obj, oData, oData1);
                    if (Result != 0) {
                        RadMessageBox.Show("Descripcion de puesto actualizada correctamente", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);

                    } else {
                        RadMessageBox.Show("Ocurrió un error al actualizar la descripcion del puesto", this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
                    }


                }
                LimpiarCampos();
                CargarGrid();
                CargarGridContactos();

            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al guardar la descripcion del puesto\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally {
                oCHumano = null;
            }
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try {
                LimpiarCampos();
                LimpiarDatos();


            } catch (Exception ex) {

                RadMessageBox.Show("Ocurrió un error al limpiar los campos\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            oCHumano = new WCF_CHumano.Hersan_CHumanoClient();
            try {
                if (txtId.Text != "0") {
                    if (RadMessageBox.Show("Desea eliminar la descripción para el puesto seleccionado...?", this.Text, MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.Yes) {
                        int Result = oCHumano.CHU_DescPuestos_Elimina(int.Parse(txtId.Text), BaseWinBP.UsuarioLogueado.ID);
                        if (Result != 0) {
                            RadMessageBox.Show("Descripción de puesto eliminada correctamente", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                        } else {
                            RadMessageBox.Show("Ocurrió un error al eliminar la descripción del puesto", this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
                        }
                        LimpiarCampos();
                        CargarGrid();
                        CargarGridContactos();
                    }

                } else {
                    RadMessageBox.Show("No hay descripción de puesto seleccionado", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                }

            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al eliminar la descrpción del puesto\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally {
                oCHumano = null;
            }
        }
        private void btnAddPariente_Click_1(object sender, EventArgs e)
        {
            obj = new DescPuestosContactosBE();
            try {

                if (pList.FindAll(item => item.Id == int.Parse(cboContactos.SelectedValue.ToString())).Count == 0) {

                    obj.Sel = false;

                    obj.Concepto = cboContactos.SelectedItem.Text;
                    obj.Id = int.Parse(cboContactos.SelectedValue.ToString());
                    //obj.TipoCon = opInterno.IsChecked ? "INTERNO" : "EXTERNO";
                    obj.Tipo = true;

                    pList.Add(obj);
                    ActualizaGrid();
                } else {
                    RadMessageBox.Show("No es posible agregar un item que ya existe en el perfil", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                }
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al agregar la selección\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }

        }
        private void btnReporte_Click(object sender, EventArgs e)
        {
            try {
                if (int.Parse(txtIdPerfil.Text) > 0 && cboPuestos.SelectedIndex != -1)
                    Reporte(false);
                else
                    RadMessageBox.Show("No ha seleccionado una descripción de puesto", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al mostrar el reporte\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }

        private void CargarGrid()
        {
            oCHumano = new WCF_CHumano.Hersan_CHumanoClient();
            oList.Clear();
            Flag = false;

            try {
                if (cboDepto.SelectedValue != null) {
                    DataSet oAux = oCHumano.CHU_Perfiles_Obtener(int.Parse(cboDepto.SelectedValue.ToString()), int.Parse(cboPuestos.SelectedValue.ToString()));
                    if (oAux.Tables.Count > 0) {
                        #region Detalle Grid
                        /* EDUCACIÓN */
                        if (oAux.Tables[1].Rows.Count > 0) {
                            foreach (DataRow oRow in oAux.Tables[1].Rows) {
                                oList.Add(new PerfilDescripcionBE() {
                                    Id = int.Parse(oRow["EDU_Id"].ToString()),
                                    Grupo = "1-EDUCACIÓN",
                                    Concepto = oRow["EDU_Nombre"].ToString(),
                                    Tipo = oRow["Tipo"].ToString()
                                });
                            }
                        }
                    }
                    /* FUNCIONES */
                    if (oAux.Tables[2].Rows.Count > 0) {
                        foreach (DataRow oRow in oAux.Tables[2].Rows) {
                            oList.Add(new PerfilDescripcionBE() {
                                Id = int.Parse(oRow["COM_Id"].ToString()),
                                Grupo = "2-COMPETENCIAS",
                                Concepto = oRow["COM_Nombre"].ToString(),
                                Tipo = oRow["PCO_Nivel"].ToString(),
                                Valor = decimal.Parse(oRow["PCO_Ponderacion"].ToString())
                            });
                        }
                    }
                    #endregion

                    /* DATOS GENERALES DEL PERFIL */
                    if (oAux.Tables[0].Rows.Count > 0) {
                        txtIdPerfil.Text = (oAux.Tables[0].Rows[0]["PER_Id"].ToString());
                        lblExperiencia.Text = oAux.Tables[0].Rows[0]["PER_Experiencia"].ToString();
                    }
                }
                ActualizaGrid();

            } catch (Exception ex) {
                throw ex;
            } finally {
                Flag = true;
            }
        }
        private void LimpiarDatos()
        {
            oList.Clear();
            pList.Clear();
            txtObjetivo.Text = String.Empty;
            txtRiesgo.Text = string.Empty;
            txtAutoridad.Text = string.Empty;
            txtCondiciones.Text = string.Empty;
            txtObservaciones.Text = string.Empty;
            txtEsfuerzo.Text = string.Empty;
            txtActividades.Text = string.Empty;
            txtEquipo.Text = string.Empty;
            cboColaboradores.SelectedIndex = 0;
            gvContactos.DataSource = null;
        }
        private void LimpiarCampos()
        {
            oList.Clear();
            pList.Clear();
            txtId.Text = "0";
            txtIdPerfil.Text = "0";
            txtObjetivo.Text = String.Empty;
            lblExperiencia.Text = string.Empty;
            lblValor.Text = "0.00";
            lblSueldoMax.Text = "0.00";
            txtRiesgo.Text = string.Empty;
            txtAutoridad.Text = string.Empty;
            txtActividades.Text = string.Empty;
            txtCondiciones.Text = string.Empty;
            txtObservaciones.Text = string.Empty;
            txtEsfuerzo.Text = string.Empty;
            txtEquipo.Text = string.Empty;
            cboContactos.SelectedIndex = 0;
            cboColaboradores.SelectedIndex = 0;
            cboEntidad.SelectedIndex = -1;
            cboDepto.SelectedIndex = -1;
            cboPuestos.SelectedIndex = -1;
            grdDatos.DataSource = null;
            grdDatosEdu.DataSource = null;

        }
        private void CargarCContactos()
        {
            oCatalogos = new WCF_Catalogos.Hersan_CatalogosClient();
            try {
                cList = oCatalogos.ABCContactos_Combo();

                cboContactos.DisplayMember = "Nombre";
                cboContactos.ValueMember = "Id";
                cboContactos.DataSource = cList;



            } catch (Exception ex) {
                RadMessageBox.Show("Ocurió un error al cargar los contactos\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);

            } finally {
                oCatalogos = null;
            }

        }
        private void CalcularPuntos()
        {
            try {

                decimal valor = 0;
                decimal pond = 0;
                decimal Suma = 0;
                decimal total = 0;
                foreach (GridViewRowInfo row in grdDatos.Rows) {
                    // Producto de las columnas nivel y valor

                    valor = decimal.Parse(row.Cells["Tipo"].Value.ToString());
                    pond = decimal.Parse(row.Cells["Valor"].Value.ToString());
                    total = valor * pond;
                    row.Cells["Total"].Value = total;
                    Suma += Convert.ToDecimal(row.Cells["Total"].Value);
                }
                //Total = Suma;
                resultado = Suma * decimal.Parse(lblValor.Text);
                lblSueldoMax.Text = resultado.ToString();

            } catch (Exception) {

                throw;
            }

        }
        private bool ValidarCampos()
        {
            bool Flag = true;
            try {
                Flag = txtAutoridad.Text.Trim().Length == 0 ? false : true;
                Flag = txtCondiciones.Text.Trim().Length == 0 ? false : true;
                Flag = txtEquipo.Text.Trim().Length == 0 ? false : true;
                Flag = txtEsfuerzo.Text.Trim().Length == 0 ? false : true;
                Flag = lblExperiencia.Text.Trim().Length == 0 ? false : true;
                Flag = txtObjetivo.Text.Trim().Length == 0 ? false : true;
                Flag = txtObservaciones.Text.Trim().Length == 0 ? false : true;
                Flag = txtRiesgo.Text.Trim().Length == 0 ? false : true;
                Flag = txtActividades.Text.Trim().Length == 0 ? false : true;
                return Flag;
            } catch (Exception ex) {
                throw ex;
            }
        }
        private void CargarGridContactos()
        {
            oCHumano = new WCF_CHumano.Hersan_CHumanoClient();
            pList.Clear();
            //LimpiarCampos();
            Flag = false;

            try {
                if (txtIdPerfil.Text != "") {
                    DataSet oAux = oCHumano.CHU_DescripcionPuestos_Obtener(int.Parse(txtIdPerfil.Text));
                    if (oAux.Tables.Count > 0) {
                        #region Detalle Grid
                        /* CONTACTOS */
                        if (oAux.Tables[1].Rows.Count > 0) {
                            foreach (DataRow oRow in oAux.Tables[1].Rows) {
                                pList.Add(new DescPuestosContactosBE() {
                                    Id = int.Parse(oRow["CON_Id"].ToString()),
                                    Concepto = oRow["CON_Nombre"].ToString(),
                                    TipoCon = oRow["TipoCon"].ToString(),
                                    Tipo = bool.Parse(oRow["CON_Interno"].ToString())


                                });
                            }
                        }

                        /* FUNCIONES */
                        if (oAux.Tables[2].Rows.Count > 0) {
                            foreach (DataRow oRow in oAux.Tables[2].Rows) {

                                txtRiesgo.Text = (oRow["DCT_Riesgos"].ToString());
                                txtEsfuerzo.Text = (oRow["DCT_EsfuerzoFisico"].ToString());
                                txtCondiciones.Text = oRow["DCT_CondicionesAmb"].ToString();
                                txtEquipo.Text = oRow["DCT_EsfuerzoFisico"].ToString();
                                txtActividades.Text = oRow["DCT_Actividades"].ToString();


                            }

                        }
                        #endregion

                        /* DATOS GENERALES DEL PERFIL */
                        if (oAux.Tables[0].Rows.Count > 0) {
                            foreach (DataRow oRow in oAux.Tables[0].Rows) {
                                txtId.Text = oAux.Tables[0].Rows[0]["DPU_Id"].ToString();
                                txtObservaciones.Text = oAux.Tables[0].Rows[0]["DPU_Observaciones"].ToString();
                                txtObjetivo.Text = oAux.Tables[0].Rows[0]["DPU_Objetivo"].ToString();
                                txtAutoridad.Text = oAux.Tables[0].Rows[0]["DPU_Autoridad"].ToString();
                                cboColaboradores.SelectedIndex = int.Parse(oAux.Tables[0].Rows[0]["DPU_Colobaradores"].ToString());
                            }
                        }
                    } else {
                        oAux.Tables.Clear();
                    }
                }
                ActualizaGrid();

            } catch (Exception ex) {
                throw ex;
            } finally {
                Flag = true;
            }
        }
        private Stream Reporte(bool Correo)
        {
            oCHumano = new WCF_CHumano.Hersan_CHumanoClient();
            Stream archivo = null;
            try {
                frmViewer frm = new frmViewer();
                frm.iReport = new Reportes.rtpDescPuestos();

                frm.iReport.SetDataSource(oCHumano.CHU_DescPuesto_ReporteDetalle(int.Parse(txtIdPerfil.Text),
                    int.Parse(cboPuestos.SelectedValue.ToString()), int.Parse(cboDepto.SelectedValue.ToString())));
                //frm.iReport.SetDataSource(oCHumano.CHU_DescPuesto_ReporteDetalle2(int.Parse(txtIdPerfil.Text)));

                if (Correo) {
                    archivo = frm.iReport.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                } else {
                    //MOSTRAR EN PANTALLA
                    frm.WindowState = FormWindowState.Maximized;
                    frm.ShowDialog();
                }
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al mostrar el reporte\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally {
                oCHumano = null;
            }
            return archivo;
        }
        private void ActualizaGrid()
        {
            try {
                grdDatos.DataSource = null;
                grdDatos.DataSource = oList.FindAll(item => item.DatosUsuario.Estatus == true && item.Grupo.Contains("COMPETENCIA"));

                grdDatosEdu.DataSource = null;
                grdDatosEdu.DataSource = oList.FindAll(item => item.DatosUsuario.Estatus == true && item.Grupo.Contains("EDUCACIÓN"));

                gvContactos.DataSource = null;
                gvContactos.DataSource = pList.FindAll(item => item.DatosUsuario.Estatus == true);


            } catch (Exception ex) {
                throw ex;
            }
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
        private void CargarPuntos()
        {
            oCatalogos = new WCF_Catalogos.Hersan_CatalogosClient();
            try {
                if (Flag && cboPuestos.Items.Count > 0 && cboPuestos.SelectedValue != null) {
                    var Temp = oCatalogos.CHUPuestos_Puntos(int.Parse(cboPuestos.SelectedValue.ToString()));
                    lblValor.Text = Temp[0].Puntos.ToString(); ;
                } else
                    lblValor.Text = "0.00";
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al cargar los puntos asociados a los p...\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally {
                oCatalogos = null;
            }
        }
        private void CargarPuestos()
        {
            oCatalogos = new WCF_Catalogos.Hersan_CatalogosClient();
            try {

                if (cboDepto.Items.Count > 0 && cboDepto.SelectedValue != null) {
                    puList = oCatalogos.ABCPuestos_Combo(int.Parse(cboDepto.SelectedValue.ToString()));
                    cboPuestos.ValueMember = "Id";
                    cboPuestos.DisplayMember = "Nombre";
                    cboPuestos.DataSource = puList;

                } else
                    cboPuestos.DataSource = null;

            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al cargar la pantalla\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally {
                oCatalogos = null;
            }
        }
        private void CargarJerarquias()
        {
            oCatalogos = new WCF_Catalogos.Hersan_CatalogosClient();
            List<PuestosBE> oPuestos;
            try {
                oPuestos = oCatalogos.CH_TramoControl_Obtener(int.Parse(cboPuestos.SelectedValue.ToString()));
                if(oPuestos.Count > 0) {
                    PuestosBE Sup = oPuestos.Find(item => item.Abrev == "A");
                    txtSuperior.Text = Sup != null ? Sup.Nombre : string.Empty;

                    lstInferior.ValueMember = "Id";
                    lstInferior.DisplayMember = "Nombre";
                    lstInferior.DataSource = oPuestos.FindAll(item => item.Abrev == "B");
                } else {
                    txtSuperior.Clear();
                    lstInferior.Items.Clear();
                }
            } catch (Exception ex) {
                throw ex;
            } finally {
                oCatalogos = null;
            }
        }
    }
}
    


