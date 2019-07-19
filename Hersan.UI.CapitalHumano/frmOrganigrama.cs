using Hersan.Entidades.Catalogos;
using Hersan.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.Data;

namespace Hersan.UI.CapitalHumano
{
    public partial class frmOrganigrama : Telerik.WinControls.UI.RadForm
    {
        CapitalHumano.WCF_Catalogos.Hersan_CatalogosClient oCatalogo;
        List<OrganigramaBE> oList = new List<OrganigramaBE>();
        List<EntidadesBE> oEntidades = new List<EntidadesBE>();
        List<EntidadesBE> oEntidadesJefe = new List<EntidadesBE>();

        public frmOrganigrama()
        {
            InitializeComponent();
        }
        private void frmOrganigrama_Load(object sender, EventArgs e)
        {

            try {
                GroupDescriptor Entidades = new GroupDescriptor();
                Entidades.GroupNames.Add("ENT_Nombre", ListSortDirection.Ascending);
                this.gvDatos.GroupDescriptors.Add(Entidades);

                radCheckBox1.Checked = true;

                LimpiarCampos();
                CargarEntidades();
                CargarElementos_Organigrama();
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrio un error al cargar la pantalla\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            oCatalogo = new CapitalHumano.WCF_Catalogos.Hersan_CatalogosClient();
            OrganigramaBE obj = new OrganigramaBE();
            try {
                if (RadMessageBox.Show("Desea guardar los datos capturados...?", this.Text, MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.Yes) {
                    obj.Id = int.Parse(txtId.Text);
                    obj.Entidades.Id = int.Parse(cboEntidad.SelectedValue.ToString());
                    obj.Puestos.Id = int.Parse(cboPuestos.SelectedValue.ToString());
                    obj.IdJefe = radCheckBox1.Checked ? 0 : cboPadre.SelectedValue != null ? int.Parse(cboPadre.SelectedValue.ToString()) : 0;
                    obj.Departamentos.Id = int.Parse(cboDepto.SelectedValue.ToString());
                    obj.DatosUsuario.Estatus = true;
                    obj.DatosUsuario.IdUsuarioCreo = BaseWinBP.UsuarioLogueado.ID;

                    if (txtId.Text == "0") {
                        int Result = oCatalogo.CHUOrganigrama_Guardar(obj);
                        if (Result == 0) {
                            RadMessageBox.Show("Ocurrió un error al guardar un elemento en el organigrama", this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
                        } else {
                            RadMessageBox.Show("Elemento guardado correctamente", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                            LimpiarCampos();
                            CargarElementos_Organigrama();

                        }
                    } else {

                        int Result = oCatalogo.CHUOrganigrama_Actualizar(obj);
                        if (Result == 0) {
                            RadMessageBox.Show("Ocurrió un error al actualizar los datos", this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
                        } else {
                            RadMessageBox.Show("Información actualizada correctamente", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                            LimpiarCampos();
                            CargarElementos_Organigrama();

                        }
                    }
                }

            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al actualizar la información\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally {
                oCatalogo = null;
            }
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try {
                LimpiarCampos();
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrio un error al limpiar los campos\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            oCatalogo = new CapitalHumano.WCF_Catalogos.Hersan_CatalogosClient();
            OrganigramaBE obj = new OrganigramaBE();
            try {
                //if (chkEstatus.Checked) {
                if (RadMessageBox.Show("Esta acción dará de baja el elemento\nDesea continuar...?", this.Text, MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.Yes) {
                    obj.Id = int.Parse(txtId.Text);
                    obj.Entidades.Id = int.Parse(cboEntidad.SelectedValue.ToString());
                    obj.Puestos.Id = int.Parse(cboPuestos.SelectedValue.ToString());
                    obj.IdJefe = int.Parse(cboPadre.SelectedValue.ToString());
                    obj.Departamentos.Id = int.Parse(cboDepto.SelectedValue.ToString());
                    obj.DatosUsuario.Estatus = false;
                    obj.DatosUsuario.IdUsuarioModif = BaseWinBP.UsuarioLogueado.ID;

                    int Result = oCatalogo.CHUOrganigrama_Actualizar(obj);
                    if (Result == 0) {
                        RadMessageBox.Show("Ocurrió un error al modificar los datos", this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
                    } else {
                        RadMessageBox.Show("Información actualizada correctamente", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                        LimpiarCampos();
                        CargarElementos_Organigrama();

                    }
                }
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrio un error al dar de baja la solicitud\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally {
                oCatalogo = null;
            }
        }
        private void btnVerDiagrama_Click(object sender, EventArgs e)
        {
            Form frm = new OrgChartForm();
            frm.ShowDialog();
            frm.WindowState = FormWindowState.Maximized;
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            try {
                this.Close();
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrio un error al cerrar la pantalla\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void cboEntidad_SelectedValueChanged(object sender, EventArgs e)
        {
            oCatalogo = new WCF_Catalogos.Hersan_CatalogosClient();
            try {
                cboDepto.ValueMember = "Id";
                cboDepto.DisplayMember = "Nombre";
                cboDepto.DataSource = oCatalogo.ABCDepartamentos_Combo(int.Parse(cboEntidad.SelectedValue.ToString()));
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al cargar los departamentos\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally {
                oCatalogo = null;
            }
        }
        private void cboEntidadJefe_SelectedValueChanged(object sender, EventArgs e)
        {
            oCatalogo = new WCF_Catalogos.Hersan_CatalogosClient();
            try {
                cboDeptoJefe.ValueMember = "Id";
                cboDeptoJefe.DisplayMember = "Nombre";
                cboDeptoJefe.DataSource = oCatalogo.ABCDepartamentos_Combo(int.Parse(cboEntidadJefe.SelectedValue.ToString()));
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al cargar los departamentos\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally {
                oCatalogo = null;
            }
        }
        private void gvDatos_CurrentRowChanged(object sender, Telerik.WinControls.UI.CurrentRowChangedEventArgs e)
        {
            try {
                if (gvDatos.RowCount > 0 && e.CurrentRow.ChildRows.Count == 0) {
                    txtId.Text = e.CurrentRow.Cells["Id"].Value.ToString();
                    cboEntidad.SelectedValue = int.Parse(e.CurrentRow.Cells["ENT_Id"].Value.ToString());
                    cboDepto.SelectedValue = int.Parse(e.CurrentRow.Cells["DEP_Id"].Value.ToString());
                    cboPuestos.SelectedValue = int.Parse(e.CurrentRow.Cells["PUE_Id"].Value.ToString());
                    //cboPadre.SelectedValue = int.Parse(e.CurrentRow.Cells["PUE_Idjefe"].Value.ToString());
                }
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrio un error al seleccionar el registro" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void cboDepto_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            oCatalogo = new CapitalHumano.WCF_Catalogos.Hersan_CatalogosClient();
            try {
                if (cboDepto.Items.Count > 0 && cboDepto.SelectedValue != null) {
                    cboPuestos.ValueMember = "ID";
                    cboPuestos.DisplayMember = "Nombre";
                    cboPuestos.DataSource = oCatalogo.ABCPuestos_Combo(int.Parse(cboDepto.SelectedValue.ToString()));
                } else {
                    cboPuestos.DataSource = null;
                }
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al cargar los puestos\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally {
                oCatalogo = null;
            }
        }
        private void cboDeptoJefe_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            oCatalogo = new CapitalHumano.WCF_Catalogos.Hersan_CatalogosClient();
            try {
                if (cboDeptoJefe.Items.Count > 0 && cboDeptoJefe.SelectedValue != null) {
                    cboPadre.ValueMember = "ID";
                    cboPadre.DisplayMember = "Nombre";
                    cboPadre.DataSource = oCatalogo.ABCPuestos_Combo(int.Parse(cboDeptoJefe.SelectedValue.ToString()));
                } else {
                    cboPadre.DataSource = null;
                }
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al cargar los puestos\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally {
                oCatalogo = null;
            }
        }
        private void radCheckBox1_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            try {
                gpoJefe.Enabled = !radCheckBox1.Checked;
            } catch (Exception ex) {
                throw ex;
            }
        }

        private void CargarEntidades()
        {
            oCatalogo = new CapitalHumano.WCF_Catalogos.Hersan_CatalogosClient();
            try {
                oEntidades = oCatalogo.Entidades_Combo(BaseWinBP.UsuarioLogueado.Empresa.Id);
                oEntidades.Add(new EntidadesBE { Id = 0, Nombre = "TODAS" });
                cboEntidad.ValueMember = "Id";
                cboEntidad.DisplayMember = "Nombre";
                cboEntidad.DataSource = oEntidades;

                if (oCatalogo == null) oCatalogo = new WCF_Catalogos.Hersan_CatalogosClient();
                oEntidadesJefe = oCatalogo.Entidades_Combo(BaseWinBP.UsuarioLogueado.Empresa.Id);
                oEntidadesJefe.Add(new EntidadesBE { Id = 0, Nombre = "TODAS" });
                cboEntidadJefe.ValueMember = "Id";
                cboEntidadJefe.DisplayMember = "Nombre";
                cboEntidadJefe.DataSource = oEntidadesJefe;
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al cargar las entidades\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally {
                oCatalogo = null;
            }
        }
        private void LimpiarCampos()
        {
            try {
                txtId.Text = "0";
                cboEntidad.SelectedIndex = 0;
                cboEntidadJefe.SelectedIndex = 0;
                chkEstatus.Checked = false;
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrio un error al limpiar los campos\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void CargarElementos_Organigrama()
        {
            oCatalogo = new CapitalHumano.WCF_Catalogos.Hersan_CatalogosClient();
            try {
                oList = oCatalogo.CHUOrganigrama_Obtener();
                gvDatos.DataSource = oList;

                
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrio un error al cargar los elementos del organigrama\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally {
                oCatalogo = null;
            }
        }

    }
}
