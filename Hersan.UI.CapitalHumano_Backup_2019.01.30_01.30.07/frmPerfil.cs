﻿using Hersan.Entidades.CapitalHumano;
using Hersan.Entidades.Catalogos;
using Hersan.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.Data;

namespace Hersan.UI.CapitalHumano
{
    public partial class frmPerfil : Telerik.WinControls.UI.RadForm
    {
        #region Variables
        WCF_Catalogos.Hersan_CatalogosClient oCatalogos;
        WCF_CHumano.Hersan_CHumanoClient oCHumano;
        List<PerfilDescripcionBE> oList = new List<PerfilDescripcionBE>();
        PerfilDescripcionBE obj;
        bool Flag = true;
        #endregion

        public frmPerfil()
        {
            InitializeComponent();
        }
        private void frmPerfil_Load(object sender, EventArgs e)
        {
            try {
                GroupDescriptor descriptor = new GroupDescriptor();
                descriptor.GroupNames.Add("Grupo",  ListSortDirection.Ascending);
                grdDatos.GroupDescriptors.Add(descriptor);

                CargarDeptos();
                CargarEducacion();
                CargarFunciones();
                CargarCompetencias();

                CargarGrid();
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al cargar la pantalla\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
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
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            oCHumano = new WCF_CHumano.Hersan_CHumanoClient();
            DataTable oData = new DataTable("Datos");

            try {
                oData.Columns.Add("Id");
                oData.Columns.Add("Concepto");
                oData.Columns.Add("Tipo");
                oData.Columns.Add("Estatus");

                PerfilesBE obj = new PerfilesBE();
                oList.ForEach(item => {
                    obj.Id = int.Parse(txtId.Text);
                    obj.Puesto.Departamentos.Id = int.Parse(cboDepto.SelectedValue.ToString());
                    obj.Puesto.Id = int.Parse(cboPuestos.SelectedValue.ToString());
                    obj.Experiencia = cboExperiencia.Text;
                    obj.DatosUsuario.IdUsuarioCreo = BaseWinBP.UsuarioLogueado.ID;
                    
                    #region Carga Detalle
                    DataRow oRow = oData.NewRow();
                    if (item.Grupo.Contains("EDUCACIÓN")) {
                        oRow["Id"] = item.Id;
                        oRow["Concepto"] = "EDUCACIÓN";
                        oRow["Tipo"] = item.Tipo;
                        oRow["Estatus"] = item.DatosUsuario.Estatus;
                    }
                    if (item.Grupo.Contains("FUNCIONES")) {
                        oRow["Id"] = item.Id;
                        oRow["Concepto"] = "FUNCIONES";
                        oRow["Tipo"] = string.Empty;
                        oRow["Estatus"] = item.DatosUsuario.Estatus;
                    }
                    if (item.Grupo.Contains("COMPETENCIAS")) {
                        oRow["Id"] = item.Id;
                        oRow["Concepto"] = "COMPETENCIAS";
                        oRow["Tipo"] = string.Empty;
                        oRow["Estatus"] = item.DatosUsuario.Estatus;
                    }
                    oData.Rows.Add(oRow);
                    #endregion
                });

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
                    if (RadMessageBox.Show("Desea eliminar el perfil seleccionado...?",this.Text, MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.Yes) {
                        int Result = oCHumano.CHU_Perfiles_Elimina(int.Parse(txtId.Text), BaseWinBP.UsuarioLogueado.ID);
                        if (Result != 0) {
                            RadMessageBox.Show("Perfil eliminado correctamente", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                        } else {
                            RadMessageBox.Show("Ocurrió un error al eliminar el perfil", this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
                        }
                    }
                 }
                LimpiarCampos();
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al eliminar el perfil\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally {
                oCHumano = null;
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
                if (txtId.Text == "0")
                    oList.RemoveAll(item => item.Sel == true);
                else
                    oList.ForEach(item => {
                        if (item.Sel == true)
                            item.DatosUsuario.Estatus = false;
                    });

                ActualizaGrid();
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al cargar la pantalla\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
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
                    oList.Add(obj);

                    ActualizaGrid();
                } else {
                    RadMessageBox.Show("No es posible agregar un item que ya existe en el perfil", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                }
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al agregar la selección\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void btnAdd_For_Click(object sender, EventArgs e)
        {
            obj = new PerfilDescripcionBE();
            try {
                if (oList.FindAll(item => item.Grupo.Contains("FUNCIONES") && item.Id == int.Parse(cboFormacion.SelectedValue.ToString())).Count == 0) {
                    obj.Sel = false;
                    obj.Grupo = "2-FUNCIONES";
                    obj.Concepto = cboFormacion.SelectedItem.Text;
                    obj.Id = int.Parse(cboFormacion.SelectedValue.ToString());
                    oList.Add(obj);

                    ActualizaGrid();
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
                if (oList.FindAll(item => item.Grupo.Contains("COMPETENCIAS") && item.Id == int.Parse(cboCompetencia.SelectedValue.ToString())).Count == 0) {
                    obj.Sel = false;
                    obj.Grupo = "3-COMPETENCIAS";
                    obj.Concepto = cboCompetencia.SelectedItem.Text;
                    obj.Id = int.Parse(cboCompetencia.SelectedValue.ToString());
                    obj.Tipo = String.Empty;
                    oList.Add(obj);

                    ActualizaGrid();
                } else {
                    RadMessageBox.Show("No es posible agregar un item que ya existe en el perfil", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                }
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al agregar la competencia\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void cboDepto_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            oCatalogos = new WCF_Catalogos.Hersan_CatalogosClient();
            try {
                cboExperiencia.Text = "";
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
                if (Flag && cboPuestos.Items.Count > 0 && cboPuestos.SelectedValue != null)
                    CargarGrid();
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
                cboDepto.DataSource = oCatalogos.ABCDepartamentos_Combo();
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
        private void CargarCompetencias()
        {
            oCatalogos = new WCF_Catalogos.Hersan_CatalogosClient();
            try {
                cboCompetencia.DisplayMember = "Nombre";
                cboCompetencia.ValueMember = "Id";
                cboCompetencia.DataSource = oCatalogos.ABCCompetencias_Combo();
            } catch (Exception ex) {
                throw ex;
            } finally {
                oCatalogos = null;
            }
        }
        private void CargarFunciones()
        {
            oCatalogos = new WCF_Catalogos.Hersan_CatalogosClient();
            try {
                cboFormacion.ValueMember = "Id";
                cboFormacion.DisplayMember = "Nombre";
                cboFormacion.DataSource = oCatalogos.ABCFunciones_Combo();
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al cargar los departamentos\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally {
                oCatalogos = null;
            }
        }
        private void LimpiarCampos()
        {
            try {
                oList.Clear();
                txtId.Text = "0";
                cboCompetencia.SelectedIndex = -1;
                cboEducacion.SelectedIndex = -1;
                cboExperiencia.SelectedIndex = -1;
                cboFormacion.SelectedIndex = -1;
                cboDepto.SelectedIndex = -1;
                grdDatos.DataSource = null;
            } catch (Exception ex) {
                throw ex;
            }
        }
        private void ActualizaGrid()
        {
            try {
                grdDatos.DataSource = null;
                //grdDatos.MasterTemplate.BeginUpdate();
                grdDatos.DataSource = oList.FindAll(item=> item.DatosUsuario.Estatus == true);
                //grdDatos.MasterTemplate.EndUpdate();
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
                DataSet oAux = oCHumano.CHU_Perfiles_Obtener(int.Parse(cboDepto.SelectedValue.ToString()), int.Parse(cboPuestos.SelectedValue.ToString()));
                if (oAux.Tables.Count > 0) {
                    #region Detalle Grid
                    /* EDUCACIÓN */
                    if (oAux.Tables[1].Rows.Count > 0) {
                        foreach(DataRow oRow in oAux.Tables[1].Rows) {
                            oList.Add(new PerfilDescripcionBE() {
                                Id = int.Parse(oRow["EDU_Id"].ToString()),
                                Grupo = "1-EDUCACIÓN",
                                Concepto = oRow["EDU_Nombre"].ToString(),
                                Tipo = oRow["Tipo"].ToString()
                            });
                        }
                    }

                    /* FUNCIONES */
                    if (oAux.Tables[2].Rows.Count > 0) {
                        foreach (DataRow oRow in oAux.Tables[2].Rows) {
                            oList.Add(new PerfilDescripcionBE() {
                                Id = int.Parse(oRow["FUN_Id"].ToString()),
                                Grupo = "2-FUNCIONES",
                                Concepto = oRow["FUN_Nombre"].ToString()
                            });
                        }
                    }

                    /* FUNCIONES */
                    if (oAux.Tables[3].Rows.Count > 0) {
                        foreach (DataRow oRow in oAux.Tables[3].Rows) {
                            oList.Add(new PerfilDescripcionBE() {
                                Id = int.Parse(oRow["COM_Id"].ToString()),
                                Grupo = "3-COMPETENCIAS",
                                Concepto = oRow["COM_Nombre"].ToString()
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
            } catch (Exception ex) {
                throw ex;
            } finally {
                Flag = true;
            }
        }
    }
}
