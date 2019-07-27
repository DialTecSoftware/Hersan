using Hersan.Entidades.CapitalHumano;
using Hersan.Entidades.Catalogos;
using Hersan.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.Data;
using Telerik.WinControls.UI;

namespace Hersan.UI.CapitalHumano
{
    public partial class frmPerfil : Telerik.WinControls.UI.RadForm
    {
        #region Variables
        WCF_Catalogos.Hersan_CatalogosClient oCatalogos;
        WCF_CHumano.Hersan_CHumanoClient oCHumano;
        List<PerfilDescripcionBE> oList = new List<PerfilDescripcionBE>();
        List<EntidadesBE> oEntidades = new List<EntidadesBE>();
        List<CompetenciasBE> oCompete = new List<CompetenciasBE>();
        GridViewSummaryRowItem item1 = new GridViewSummaryRowItem();
        PerfilDescripcionBE obj;
        bool Flag = true;

        decimal resultado;
        #endregion

        public frmPerfil()
        {
            InitializeComponent();
        }
        private void frmPerfil_Load(object sender, EventArgs e)
        {
            try {
                GroupDescriptor descriptor = new GroupDescriptor();
                descriptor.GroupNames.Add("Grupo", ListSortDirection.Ascending);
                grdDatos.GroupDescriptors.Add(descriptor);

                // Summatoria de datos
                GridViewSummaryRowItem item1 = new GridViewSummaryRowItem();
                item1.Add(new GridViewSummaryItem("Total", "Total:  {0:N2}", GridAggregateFunction.Sum));
                this.grdDatos.SummaryRowsBottom.Add(item1);

                LimpiarCampos();
                CargarEntidades();
                CargarEducacion();
                CargarCompetencias();

                CargarGrid();
                CalcularPuntos();
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al cargar la pantalla\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try {
                LimpiarCampos();
                cboEntidad.SelectedIndex = 0;
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al limpiar los campos\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
           
            if (grdDatos.Rows.Count <1 || grdDatosEdu.Rows.Count<1) {
                RadMessageBox.Show("Debe de agregar estudios y competencias al perfil...\n", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                return;
            }
            oCHumano = new WCF_CHumano.Hersan_CHumanoClient();
            DataTable oData = new DataTable("Datos");

            try {
                oData.Columns.Add("Id");
                oData.Columns.Add("Concepto");
                oData.Columns.Add("Tipo");
                oData.Columns.Add("Valor");
                oData.Columns.Add("Estatus");

                PerfilesBE obj = new PerfilesBE();
                oList.ForEach(item => {
                    obj.Id = txtId.Text.Trim().Length > 0 ? int.Parse(txtId.Text) : 0;
                    obj.Puesto.Departamentos.Id = int.Parse(cboDepto.SelectedValue.ToString());
                    obj.Puesto.Id = int.Parse(cboPuestos.SelectedValue.ToString());
                    obj.Experiencia = cboExperiencia.Text;
                    obj.SueldoMax = decimal.Parse(txtSueldo.Text);
                    obj.DatosUsuario.IdUsuarioCreo = BaseWinBP.UsuarioLogueado.ID;

                    #region Carga Detalle
                    DataRow oRow = oData.NewRow();
                    if (item.Grupo.Contains("EDUCACIÓN")) {
                        oRow["Id"] = item.Id;
                        oRow["Concepto"] = "EDUCACIÓN";
                        oRow["Tipo"] = item.Tipo;
                        oRow["Valor"] = item.Valor;
                        oRow["Estatus"] = item.DatosUsuario.Estatus;
                    }
                    if (item.Grupo.Contains("COMPETENCIAS")) {
                        oRow["Id"] = item.Id;
                        oRow["Concepto"] = "COMPETENCIAS";
                        oRow["Tipo"] = item.Tipo;
                        oRow["Valor"] = item.Valor;
                        oRow["Estatus"] = item.DatosUsuario.Estatus;
                    }
                    oData.Rows.Add(oRow);
                    #endregion
                });
                if (RadMessageBox.Show("Desea guardar los datos capturados...?", this.Text, MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.Yes) {
                    /* ALTA DE PERFIL */
                    if (int.Parse(txtId.Text) == 0) {
                        int Result = oCHumano.CHU_Perfiles_Guardar(obj, oData);
                        if (Result != 0) {
                            RadMessageBox.Show("Perfil guardado correctamente", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                        } else {
                            RadMessageBox.Show("Ocurrió un error al guardar el perfil", this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
                        }
                    } else {
                        int Result = oCHumano.CHU_Perfiles_Actualiza(obj, oData);
                        if (Result != 0) {
                            RadMessageBox.Show("Perfil actualizado correctamente", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                        } else {
                            RadMessageBox.Show("Ocurrió un error al actualizar el perfil", this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
                        }
                    }
       
                    LimpiarCampos();
                    cboEntidad.SelectedIndex = 0;
                } 
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al guardar el perfil\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally {
                oCHumano = null;
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            oCHumano = new WCF_CHumano.Hersan_CHumanoClient();
            try {
                if (txtId.Text != "0") {
                    if (RadMessageBox.Show("Desea eliminar el perfil seleccionado...?", this.Text, MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.Yes) {
                        int Result = oCHumano.CHU_Perfiles_Elimina(int.Parse(txtId.Text), BaseWinBP.UsuarioLogueado.ID);
                        if (Result != 0) {
                            RadMessageBox.Show("Perfil eliminado correctamente", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                        } else {
                            RadMessageBox.Show("Ocurrió un error al eliminar el perfil", this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
                        }
                        LimpiarCampos();
                        cboEntidad.SelectedIndex = 0;
                    }
                }
                
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al eliminar el perfil\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally {
                oCHumano = null;
            }
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            PerfilesBE Perfil = new PerfilesBE();
            try {
                frmPerfilConsulta ofrm = new frmPerfilConsulta();
                ofrm.WindowState = FormWindowState.Normal;
                ofrm.StartPosition = FormStartPosition.CenterScreen;
                ofrm.MaximizeBox = false;
                ofrm.MinimizeBox = false;
                ofrm.Titulo = "BUSCAR PERFIL";
                ofrm.ShowDialog();
                Perfil = ofrm.Perfil;

                if (Perfil != null) {
                    LimpiarCampos();
                    cboEntidad.SelectedValue = Perfil.Puesto.Departamentos.Entidades.Id;
                    cboDepto.SelectedValue = Perfil.Puesto.Departamentos.Id;
                    cboPuestos.SelectedValue = Perfil.Puesto.Id;
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
                RadMessageBox.Show("Ocurrió un error al cerrar la pantalla\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void btnQuitar_Click(object sender, EventArgs e)
        {
            try {

                if (oList.FindAll(item => item.Sel == true).Count > 0) {
                    if (RadMessageBox.Show("Esta acción eliminara los elementos seleccionados\nDesea continuar...?", this.Text, MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.No)
                        return;
                } else {
                    RadMessageBox.Show("No hay contacto seleccionado seleccionados", this.Text, MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                    return;
                }

                if (txtId.Text == "0")
                    oList.RemoveAll(item => item.Sel == true);
                else {
                    oList.ForEach(item => {
                        if (item.Sel == true)
                            item.DatosUsuario.Estatus = false;
                    });
                    oList.RemoveAll(item => item.DatosUsuario.Estatus == false);
                }

                ActualizaGrid();
                CalcularPuntos();

            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al quitar un item\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void btnAdd_Edu_Click(object sender, EventArgs e)
        {
            obj = new PerfilDescripcionBE();
            try {
                if (oList.FindAll(item => item.Grupo.Contains("EDUCACIÓN") && item.Id == int.Parse(cboEducacion.SelectedValue.ToString())).Count == 0) {
                    obj.Sel = false;
                    obj.Grupo = "1-EDUCACIÓN";
                    obj.Concepto = cboEducacion.SelectedItem.Text;
                    obj.Id = int.Parse(cboEducacion.SelectedValue.ToString());
                    obj.Tipo = opNecesaria.Checked ? "NECESARIA" : "PREFERENTE";
                    obj.Valor = 0;
                    oList.Add(obj);
                    ActualizaGrid();
                    CalcularPuntos();
                    //ActualizaGridEdu();
                } else {
                    RadMessageBox.Show("No es posible agregar un item que ya existe en el perfil", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                }
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al agregar la selección\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void btnAdd_Comp_Click(object sender, EventArgs e)
        {
            obj = new PerfilDescripcionBE();
            try {
                if(cboCompetencia.Text=="") {
                    RadMessageBox.Show("No hay competencia seleccionada", this.Text, MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                    return;
                }
                if (oList.FindAll(item => item.Grupo.Contains("COMPETENCIAS") && item.Id == int.Parse(cboCompetencia.SelectedValue.ToString())).Count == 0) {
                    obj.Sel = false;
                    obj.Grupo = "3-COMPETENCIAS";
                    obj.Concepto = cboCompetencia.SelectedItem.Text;
                    obj.Id = int.Parse(cboCompetencia.SelectedValue.ToString());
                    obj.Tipo = cboNivel.Text;
                    obj.Valor =decimal.Parse( cboPeso.Text);
                    //obj.Valor = decimal.Parse(cboNivel.Text) * oCompete.Find(item=> item.Id.ToString() == cboCompetencia.SelectedValue.ToString()).Ponderacion;
                    oList.Add(obj);

                    ActualizaGrid();
                    CalcularPuntos();
                } else {
                    RadMessageBox.Show("No es posible agregar un item que ya existe en el perfil", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                }
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al agregar la competencia\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void btnQuitarTodo_Click(object sender, EventArgs e)
        {
            try {
                if (oList.Count > 0) {
                    if (RadMessageBox.Show("Esta acción eliminara todos los elementos\nDesea continuar...?", this.Text, MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.No)
                        return;
                } else {
                    RadMessageBox.Show("No se han agregado contacto", this.Text, MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                    return;
                }

                if (txtId.Text == "0")
                    oList.Clear();
                else {
                    oList.ForEach(item => item.DatosUsuario.Estatus = false);
                    oList.RemoveAll(item => item.DatosUsuario.Estatus == false);
                }


                ActualizaGrid();
                CalcularPuntos();
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al quitar todos los items\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void cboEntidad_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try {
                CargarDeptos();
            } catch (Exception ex) {
                throw ex;
            }
        }
        private void cboDepto_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            oCatalogos = new WCF_Catalogos.Hersan_CatalogosClient();
            try {
              
                cboPuestos.ValueMember = "Id";
                cboPuestos.DisplayMember = "Nombre";
                if (cboDepto.Items.Count > 0 && cboDepto.SelectedValue != null) {
                    cboPuestos.DataSource = oCatalogos.ABCPuestos_Combo(int.Parse(cboDepto.SelectedValue.ToString()));
                } else
                    cboPuestos.DataSource = null;
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al cargar la pantalla\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally {
                oCatalogos = null;
            }
        }
        private void cboPuestos_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try {
              
                if (Flag && cboPuestos.Items.Count > 0 && cboPuestos.SelectedValue != null) {
                    LimpiarCampos();
                    CargarPuntos();
                    CargarGrid();
                    CalcularPuntos();
                }
                   
            } catch (Exception ex) {
                throw ex;
            }
        }
        private void grdDatos_CellEndEdit_1(object sender, GridViewCellEventArgs e)
        {
            try {
                decimal valor = 0;
                decimal pond = 0;
                decimal Suma = 0;
                decimal total = 0;

                if (grdDatos.Columns[e.ColumnIndex].Name == "Valor") {
                    foreach (GridViewRowInfo row in grdDatos.Rows) {
                        // Producto de las columnas nivel y valor

                        valor = decimal.Parse(row.Cells["Tipo"].Value.ToString());
                        pond = decimal.Parse(row.Cells["Valor"].Value.ToString());
                        total = valor * pond;
                        row.Cells["Total"].Value = total;
                        Suma += Convert.ToDecimal(row.Cells["Total"].Value);
                    }
                    resultado = Suma * decimal.Parse(txtValor.Text);
                }
                txtSueldo.Text = resultado.ToString();
            } catch (Exception) {
                throw;
            }
        }


        private void CargarPuntos()
        {
            oCatalogos = new WCF_Catalogos.Hersan_CatalogosClient();
            try {
                if (Flag && cboPuestos.Items.Count > 0 && cboPuestos.SelectedValue != null) {
                    var Temp = oCatalogos.CHUPuestos_Puntos(int.Parse(cboPuestos.SelectedValue.ToString()));
                    txtValor.Text = Temp[0].Puntos.ToString(); ;
                } else
                    txtValor.Text = "0.00";
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al cargar los puntos asociados a los p...\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally {
                oCatalogos = null;
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
        private void CargarEducacion()
        {
            oCatalogos = new WCF_Catalogos.Hersan_CatalogosClient();
            try {
                cboEducacion.DisplayMember = "Nombre";
                cboEducacion.ValueMember = "Id";
                cboEducacion.DataSource = oCatalogos.ABCEducacion_Combo();
            } catch (Exception ex) {
                throw ex;
            } finally {
                oCatalogos = null;
            }
        }
        private void CalcularPuntos()
        {
            decimal valor = 0;
            decimal pond = 0;
            decimal Suma = 0;
            decimal total = 0;

            try {
                if (grdDatos.RowCount > 0) {
                    foreach (GridViewRowInfo row in grdDatos.Rows) {
                        // Producto de las columnas nivel y valor
                        valor = decimal.Parse(row.Cells["Tipo"].Value.ToString());
                        pond = decimal.Parse(row.Cells["Valor"].Value.ToString());
                        total = valor * pond;
                        row.Cells["Total"].Value = total;
                        Suma += Convert.ToDecimal(row.Cells["Total"].Value);
                    }
                    resultado = Suma * decimal.Parse(txtValor.Text);
                    txtSueldo.Text = resultado.ToString();
                }
            } catch (Exception ex) {
                throw ex;
            }

        }
        private void CargarCompetencias()
        {
            oCatalogos = new WCF_Catalogos.Hersan_CatalogosClient();
            try {
                oCompete = oCatalogos.ABCCompetencias_Combo();
                cboCompetencia.DisplayMember = "Nombre";
                cboCompetencia.ValueMember = "Id";
                cboCompetencia.DataSource = oCompete;
            } catch (Exception ex) {
                throw ex;
            } finally {
                oCatalogos = null;
            }
        }
        private void LimpiarCampos()
        {
            try {
                oList.Clear();
                txtId.Text = "0";
                cboCompetencia.SelectedIndex = 1;
                cboEducacion.SelectedIndex = 0;
                cboExperiencia.Text = "-1";
                cboNivel.SelectedIndex = 0;
                cboPeso.SelectedIndex = 0;
                txtValor.Text = "0";
                txtSueldo.Text = "0";
      
                grdDatos.DataSource = null;
                grdDatosEdu.DataSource = null;
            } catch (Exception ex) {
                throw ex;
            }
        }
        private void ActualizaGrid()
        {
            try {
                grdDatos.DataSource = null;
                grdDatos.DataSource = oList.FindAll(item => item.DatosUsuario.Estatus == true && item.Grupo.Contains("COMPETENCIA"));

                grdDatosEdu.DataSource = null;
                grdDatosEdu.DataSource = oList.FindAll(item => item.DatosUsuario.Estatus == true && item.Grupo.Contains("EDUCACIÓN"));

            } catch (Exception ex) {
                throw ex;
            }
        }
        private void CargarGrid()
        {
            oCHumano = new WCF_CHumano.Hersan_CHumanoClient();
            oList.Clear();
            Flag = false;

            try {
                if (cboDepto.Items.Count > 0 && cboDepto.SelectedValue != null && cboPuestos.SelectedValue != null) {
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
                        txtId.Text = oAux.Tables[0].Rows[0]["PER_Id"].ToString();
                        cboDepto.SelectedValue = int.Parse(oAux.Tables[0].Rows[0]["DEP_Id"].ToString());
                        cboPuestos.SelectedValue = int.Parse(oAux.Tables[0].Rows[0]["PUE_Id"].ToString());
                        cboExperiencia.Text = oAux.Tables[0].Rows[0]["PER_Experiencia"].ToString();
                    }
                }
                ActualizaGrid();
                CalcularPuntos();
            } catch (Exception ex) {
                throw ex;
            } finally {
                Flag = true;
            }
        }

       
    }

}
    


