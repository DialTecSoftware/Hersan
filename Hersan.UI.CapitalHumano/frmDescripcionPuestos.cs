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
        bool Flag;
        DescPuestosContactosBE obj;
        #endregion
        public frmDescripcionPuestos()
        {
            InitializeComponent();
        }
        private void CargarGrid()
        {
            oCHumano = new WCF_CHumano.Hersan_CHumanoClient();
            oList.Clear();
            Flag = false;

            try {
                if (cboDepto.Items.Count > 0 && cboDepto.SelectedValue != null) {
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
                       txtIdPerfil.Text= (oAux.Tables[0].Rows[0]["PER_Id"].ToString());
                        cboDepto.SelectedValue = int.Parse(oAux.Tables[0].Rows[0]["DEP_Id"].ToString());
                        cboPuestos.SelectedValue = int.Parse(oAux.Tables[0].Rows[0]["PUE_Id"].ToString());
                        txtExperiencia.Text = oAux.Tables[0].Rows[0]["PER_Experiencia"].ToString();
                    }
                }
                ActualizaGrid();

            } catch (Exception ex) {
                throw ex;
            } finally {
                Flag = true;
            }
        }

        private void LimpiarCampos()
        {
            txtId.Text = "0";
            txtIdPerfil.Text = "0";
            txtObjetivo.Text = String.Empty;
            txtRiesgo.Text = string.Empty;
            txtAutoridad.Text = string.Empty;
            txtClave.Text = string.Empty;
            txtCondiciones.Text = string.Empty;
            txtObservaciones.Text = string.Empty;
            txtEquipo.Text=string.Empty;
            cboContactos.SelectedIndex = 0;
            cboColaboradores.SelectedIndex = 0;
            txtEsfuerzo.Text = string.Empty;
            cboEntidad.SelectedIndex = -1;
            cboDepto.SelectedIndex = -1;
            cboSuperior.SelectedIndex = -1;
            cboPuestos.SelectedIndex = -1;
            oList.Clear();
            pList.Clear();
           
                                  
        }
        private void Estatus_RadioButton()
        {

            try {

                if (cboContactos.Items.Count > 0 && cboContactos.SelectedValue != null) {
                    var Temp = cList.FindAll(item => item.Id == int.Parse(cboContactos.SelectedValue.ToString()));
                    if (Temp[0].Interno == true) {
                        opInterno.IsChecked = true;
                    } else
                        opExterno.IsChecked = true;
                }

            } catch (Exception ex) {

                RadMessageBox.Show("Ocurió un error al cargar los contactos\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
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

        private bool ValidarCampos()
        {
            bool Flag = true;
            try {
                Flag = txtAutoridad.Text.Trim().Length == 0 ? false : true;
                Flag = txtClave.Text.Trim().Length == 0 ? false : true;
                Flag = txtCondiciones.Text.Trim().Length == 0 ? false : true;
                Flag = txtEquipo.Text.Trim().Length == 0 ? false : true;
                Flag = txtEsfuerzo.Text.Trim().Length == 0 ? false : true;
                Flag = txtExperiencia.Text.Trim().Length == 0 ? false : true;
                Flag = txtObjetivo.Text.Trim().Length == 0 ? false : true;
                Flag = txtObservaciones.Text.Trim().Length == 0 ? false : true;
                Flag = txtRiesgo.Text.Trim().Length == 0 ? false : true;

                return Flag;
            } catch (Exception ex) {
                throw ex;
            }
        }
        private void CargarGridContactos()
        {
            oCHumano = new WCF_CHumano.Hersan_CHumanoClient();
            pList.Clear();
            Flag = false;

            try {
                if (txtIdPerfil.Text!="") {
                    DataSet oAux = oCHumano.CHU_DescripcionPuestos_Obtener(int.Parse(txtIdPerfil.Text));
                    if (oAux.Tables.Count > 0) {
                        #region Detalle Grid
                        /* CONTACTOS */
                        if (oAux.Tables[1].Rows.Count > 0) {
                            foreach (DataRow oRow in oAux.Tables[1].Rows) {
                                pList.Add(new DescPuestosContactosBE() {
                                    Id = int.Parse(oRow["CON_Id"].ToString()),
                                    Concepto = oRow["CON_Nombre"].ToString(),
                                    TipoCon=oRow["TipoCon"].ToString(),
                                    Tipo = bool.Parse(oRow["CON_Interno"].ToString())


                                });
                            }
                        }
                    }
                    /* FUNCIONES */
                    if (oAux.Tables[2].Rows.Count > 0) {
                        foreach (DataRow oRow in oAux.Tables[2].Rows) {

                            txtRiesgo.Text = (oRow["DCT_Riesgos"].ToString());
                            txtEsfuerzo.Text = (oRow["DCT_EsfuerzoFisico"].ToString());
                            txtCondiciones.Text = oRow["DCT_CondicionesAmb"].ToString();
                            txtEquipo.Text = oRow["DCT_EsfuerzoFisico"].ToString();
                               
                           
                        }
                    }
                    #endregion

                    /* DATOS GENERALES DEL PERFIL */
                    if (oAux.Tables[0].Rows.Count > 0) {
                        txtId.Text = oAux.Tables[0].Rows[0]["DPU_Id"].ToString();
                        cboSuperior.SelectedValue = int.Parse(oAux.Tables[0].Rows[0]["DPU_Superior"].ToString());
                        cboInferior.SelectedValue = int.Parse(oAux.Tables[0].Rows[0]["DPU_Inferior"].ToString());
                        txtObservaciones.Text = oAux.Tables[0].Rows[0]["DPU_Observaciones"].ToString();
                        txtObjetivo.Text = oAux.Tables[0].Rows[0]["DPU_Objetivo"].ToString();
                        txtClave.Text = oAux.Tables[0].Rows[0]["DPU_Clave"].ToString();
                        txtAutoridad.Text = oAux.Tables[0].Rows[0]["DPU_Autoridad"].ToString();
                       
                        //cboColaboradores.SelectedItem.Text= oAux.Tables[0].Rows[0]["DPU_Colobaradores"].ToString();
                    }
                }
                ActualizaGrid();

            } catch (Exception ex) {
                throw ex;
            } finally {
                Flag = true;
            }
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

        private void CargarPuestos()
        {
            oCatalogos = new WCF_Catalogos.Hersan_CatalogosClient();
            try {
                cboPuestos.ValueMember = cboInferior.ValueMember = cboSuperior.ValueMember = "Id";
                cboPuestos.DisplayMember = cboSuperior.DisplayMember = cboInferior.DisplayMember = "Nombre";
                if (cboDepto.Items.Count > 0 && cboDepto.SelectedValue != null) {
                    cboPuestos.DataSource = cboInferior.DataSource = cboSuperior.DataSource = oCatalogos.ABCPuestos_Combo(int.Parse(cboDepto.SelectedValue.ToString()));

                } else
                    cboPuestos.DataSource = cboSuperior.DataSource = cboInferior.DataSource = null;
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al cargar la pantalla\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally {
                oCatalogos = null;
            }
        }
        private void frmDescripcionPuestos_Load(object sender, EventArgs e)
        {
            try {
               
                CargarEntidades();
                //CargarGrid();
                CargarCContactos();
                CargarGridContactos();
                LimpiarCampos();

            } catch (Exception) {

                throw;
            }
        }

        private void cboEntidad_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try {
                if (cboEntidad.SelectedValue != null) {
                    CargarDeptos();
                }
            } catch (Exception) {

                throw;
            }
        }

        private void cboDepto_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try {
               
                    CargarPuestos();
                

            } catch (Exception) {

                throw;
            }
        }

        private void cboPuestos_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try {

                if (Flag && cboDepto.Items.Count > 0 && cboDepto.SelectedValue != null) {
                    //LimmpiarCampos();
                    CargarGrid();
                    CargarGridContactos();
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
                Estatus_RadioButton();

            } catch (Exception ex) {

                RadMessageBox.Show("Ocurrió un error al seleccionar un contacto\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }


        private void cboContactos_SelectedIndexChanging(object sender, Telerik.WinControls.UI.Data.PositionChangingCancelEventArgs e)
        {

        }

        private void btnAddPariente_Click(object sender, EventArgs e)
        {
            obj = new DescPuestosContactosBE();
            try {
                if (pList.FindAll(item => item.Id == int.Parse(cboContactos.SelectedValue.ToString())).Count == 0) {

                    obj.Sel = false;

                    obj.Concepto = cboContactos.SelectedItem.Text;
                    obj.Id = int.Parse(cboContactos.SelectedValue.ToString());
                    obj.TipoCon = opInterno.IsChecked ? "INTERNO" : "EXTERNO";
                    obj.Tipo = true ? opInterno.IsChecked:opExterno.IsChecked;

                    pList.Add(obj);
                    ActualizaGrid();
                } else {
                    RadMessageBox.Show("No es posible agregar un item que ya existe en el perfil", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                }
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al agregar la selección\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }

        private void cboFunciones_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try {
                Estatus_RadioButton();

            } catch (Exception) {

                throw;
            }
        }

        private void btnQuitarItem_Click(object sender, EventArgs e)
        {
            try {
                if (txtId.Text == "0")
                    pList.RemoveAll(item => item.Sel == true);
                else
                    pList.ForEach(item => {
                        if (item.Sel == true)
                            item.DatosUsuario.Estatus = false;
                    });

                ActualizaGrid();
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al quitar un item\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }

        private void btnQuitarTodo_Click(object sender, EventArgs e)
        {
            try {
                if (txtId.Text == "0")
                    pList.Clear();
                else
                    pList.ForEach(item => item.DatosUsuario.Estatus = false);

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
                //if (!ValidarCampos()) {
                //    RadMessageBox.Show("Debe capturar todos los datos para continuar", this.Text, MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                //    return;
                //}

                oData.Columns.Add("Id");
                oData.Columns.Add("Tipo");
                oData.Columns.Add("Estatus");

                oData1.Columns.Add("Esfuerzo");
                oData1.Columns.Add("Riesgo");
                oData1.Columns.Add("Condicion");
                oData1.Columns.Add("Equipo");

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
                    obj.Colabordores = int.Parse(cboColaboradores.SelectedItem.ToString());
                    obj.Autoridad = txtAutoridad.Text;
                    obj.Clave = txtClave.Text;
                    obj.Superior = int.Parse(cboSuperior.SelectedValue.ToString());
                    obj.Inferior = int.Parse(cboInferior.SelectedValue.ToString());
                    obj.Objetivo = txtObjetivo.Text;
                    obj.Observaciones = txtObservaciones.Text;
                    obj.DatosUsuario.IdUsuarioCreo = BaseWinBP.UsuarioLogueado.ID;

                    DataRow oRow1 = oData1.NewRow();
                    oRow1["Esfuerzo"] = txtEsfuerzo.Text;
                    oRow1["Riesgo"] = txtRiesgo.Text;
                    oRow1["Condicion"] = txtCondiciones.Text;
                    oRow1["Equipo"] = txtEquipo.Text;

                    oData1.Rows.Add(oRow1);
              
                
                 
                #endregion
             

                /* ALTA DE PERFIL */
                if (int.Parse(txtId.Text) == 0) {
                    int Result = oCHumano.CHU_DescPuestos_Guardar(obj, oData,oData1);
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
                    LimpiarCampos();
                    CargarGrid();
                    CargarGridContactos();

                }
               

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
                    }
                }
                LimpiarCampos();
                CargarGrid();
                CargarGridContactos();
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al eliminar la descrpción del puesto\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally {
                oCHumano = null;
            }
        }
    }
    }


