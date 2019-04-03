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


                LimpiarCampos();
                CargarEntidades();
                CargarElementos_Organigrama();
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrio un error al cargar la pantalla\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }

        private void CargarPuestos()
        {
            oCatalogo = new CapitalHumano.WCF_Catalogos.Hersan_CatalogosClient();
            try {
                cboPuestos.ValueMember = "ID";
                cboPuestos.DisplayMember = "Nombre";
                cboPuestos.DataSource = oCatalogo.ABCPuestos_Combo(int.Parse(cboDepto.SelectedValue.ToString()));
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al cargar los puestos\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally {
                oCatalogo = null;
            }
        }

        private void CargarJefes()
        {
            oCatalogo = new CapitalHumano.WCF_Catalogos.Hersan_CatalogosClient();
            try {
                cboPadre.ValueMember = "ID";
                cboPadre.DisplayMember = "Nombre";
                cboPadre.DataSource = oCatalogo.ABCPuestos_Combo(int.Parse(cboDepto.SelectedValue.ToString()));
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al cargar los puestos\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally {
                oCatalogo = null;
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

            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al cargar las entidades\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally {
                oCatalogo = null;
            }
        }
        private void CargarDeptos()
        {
            oCatalogo = new CapitalHumano.WCF_Catalogos.Hersan_CatalogosClient();
            try {
                cboDepto.ValueMember = "Id";
                cboDepto.DisplayMember = "Nombre";
                if (cboEntidad.Items.Count > 0 && cboEntidad.SelectedValue != null) {
                    cboDepto.DataSource = oCatalogo.ABCDepartamentos_Combo(int.Parse(cboEntidad.SelectedValue.ToString()));
                } else {
                    cboDepto.DataSource = null;
                }
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al cargar los departamentos\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally {
                oCatalogo = null;
            }
        }


        private void LimpiarCampos()
        {
            try {
                btnGuardar.Text = "Actualizar";

                txtId.Text = "0";
                cboDepto.SelectedIndex = 0;
                cboEntidad.SelectedIndex = 0;
                cboPuestos.SelectedIndex = 0;
                cboPadre.SelectedIndex = 0;
                cboNivel.SelectedIndex = 0;
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
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            oCatalogo = new CapitalHumano.WCF_Catalogos.Hersan_CatalogosClient();
            OrganigramaBE obj = new OrganigramaBE();
            try {

                //if (oList.FindAll(item => item.Nombre.Trim() == txtNombre.Text.Trim() && item.Id_puesto == int.Parse(cboPuesto.SelectedValue.ToString())).Count > 0
                //    && int.Parse(txtIdPuesto.Text) == 0) {
                //    RadMessageBox.Show("La información capturada ya existe, no es posible guardar", this.Text, MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                //    LimpiarCampos();
                //    return;
                //}

                if (RadMessageBox.Show("Desea guardar los datos capturados...?", this.Text, MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.Yes) {


                    obj.Nivel = cboNivel.SelectedIndex;
                    obj.Id = int.Parse(txtId.Text);
                    obj.Entidades.Id = int.Parse(cboEntidad.SelectedValue.ToString());
                    obj.Puestos.Id = int.Parse(cboPuestos.SelectedValue.ToString());
                    obj.IdJefe = int.Parse(cboPadre.SelectedValue.ToString());
                    obj.Departamentos.Id = int.Parse(cboDepto.SelectedValue.ToString());
                    obj.DatosUsuario.Estatus = true;
                    obj.DatosUsuario.IdUsuarioCreo = BaseWinBP.UsuarioLogueado.ID;


                    //PROCESO DE GUARDADO Y ACTUALIZACION
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
                btnGuardar.Text = "Guardar";

            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrio un error al limpiar los campos\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
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

        private void cboEntidad_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try {
                if (cboEntidad.Items.Count > 0 && cboEntidad.SelectedValue != null) {
                    CargarDeptos();
                }
            } catch (Exception ex) {
                throw ex;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            oCatalogo = new CapitalHumano.WCF_Catalogos.Hersan_CatalogosClient();
            OrganigramaBE obj = new OrganigramaBE();
            try {
                //if (chkEstatus.Checked) {
                if (RadMessageBox.Show("Esta acción dará de baja el elemento\nDesea continuar...?", this.Text, MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.Yes) {
                    obj.Nivel = cboNivel.SelectedIndex;
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

        private void gvDatos_CurrentRowChanged(object sender, Telerik.WinControls.UI.CurrentRowChangedEventArgs e)
        {
            if (gvDatos.RowCount > 0 && e.CurrentRow.ChildRows.Count == 0) {

                txtId.Text = e.CurrentRow.Cells["Id"].Value.ToString();
                cboNivel.SelectedIndex = int.Parse((e.CurrentRow.Cells["Nivel"].Value.ToString()));
                cboDepto.SelectedValue = int.Parse(e.CurrentRow.Cells["DEP_Id"].Value.ToString());
                cboEntidad.SelectedValue = int.Parse(e.CurrentRow.Cells["ENT_Id"].Value.ToString());
                cboPuestos.SelectedValue = int.Parse(e.CurrentRow.Cells["PUE_Id"].Value.ToString());
                cboPadre.SelectedValue = int.Parse(e.CurrentRow.Cells["PUE_Idjefe"].Value.ToString());
                //chkEstatus.Checked = bool.Parse(e.CurrentRow.Cells["Estatus"].Value.ToString());
            }
        }

        private void cboNivel_EnabledChanged(object sender, EventArgs e)
        {

        }

        private void btnVerDiagrama_Click(object sender, EventArgs e)
        {
            //Form frm = new DiagramFirstLook.OrgChartForm();
            //frm.ShowDialog();
            //frm.WindowState = FormWindowState.Maximized;
        }

        private void cboDepto_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try {
                if (cboDepto.Items.Count > 0 && cboDepto.SelectedValue != null) {
                    CargarJefes();
                    CargarPuestos();
                   
                }
            } catch (Exception ex) {
                throw ex;
            }
        }
    }
}
