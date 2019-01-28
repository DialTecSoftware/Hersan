using Hersan.Entidades.CapitalHumano;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.Data;

namespace Hersan.UI.CapitalHumano
{
    public partial class frmPerfil : Telerik.WinControls.UI.RadForm
    {
        WCF_Catalogos.Hersan_CatalogosClient oCatalogos;
        List<PerfilDescripcionBE> oList = new List<PerfilDescripcionBE>();
        PerfilDescripcionBE obj;

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
                CargarCompetencias();
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
            try {

            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al cargar la pantalla\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try {

            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al cargar la pantalla\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
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
                oList.RemoveAll(item => item.Sel == true);
                ActualizaGrid();
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al cargar la pantalla\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void btnAdd_Edu_Click(object sender, EventArgs e)
        {
            obj = new PerfilDescripcionBE();
            try {
                if (oList.FindAll(item => item.Grupo == "EDUCACIÓN" && item.Id == int.Parse(cboEducacion.SelectedValue.ToString())).Count == 0) {
                    obj.Sel = false;
                    obj.Grupo = "EDUCACIÓN";
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
            try {

            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al cargar la pantalla\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void btnAdd_Comp_Click(object sender, EventArgs e)
        {
            obj = new PerfilDescripcionBE();
            try {
                if (oList.FindAll(item => item.Grupo == "COMPETENCIAS" && item.Id == int.Parse(cboCompetencia.SelectedValue.ToString())).Count == 0) {
                    obj.Sel = false;
                    obj.Grupo = "COMPETENCIAS";
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
                if (cboDepto.Items.Count > 0) {
                    cboPuestos.ValueMember = "Id";
                    cboPuestos.DisplayMember = "Nombre";
                    cboPuestos.DataSource = oCatalogos.ABCPuestos_Combo(int.Parse(cboDepto.SelectedValue.ToString()));
                }
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al cargar la pantalla\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally {
                oCatalogos = null;
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
        private void LimpiarCampos()
        {
            try {
                cboCompetencia.SelectedIndex = 0;
                cboEducacion.SelectedIndex = 0;
                cboExperiencia.SelectedIndex = 0;
                cboDepto.SelectedIndex = 0;
            } catch (Exception ex) {
                throw ex;
            }
        }
        private void ActualizaGrid()
        {
            try {
                grdDatos.DataSource = null;
                //grdDatos.MasterTemplate.BeginUpdate();
                grdDatos.DataSource = oList;
                //grdDatos.MasterTemplate.EndUpdate();
            } catch (Exception ex) {
                throw ex;
            }
        }
        
    }
}
