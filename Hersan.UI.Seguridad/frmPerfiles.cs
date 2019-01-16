using Hersan.Entidades.Seguridad;
using Hersan.Entidades.Comun;
using Hersan.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Hersan.Entidades.Catalogos;
using System.Data;

namespace Hersan.UI.Seguridad
{
    public partial class frmPerfiles : Telerik.WinControls.UI.RadForm
    {
        #region Variables
        WCF_Seguridad.Hersan_SeguridadClient wcf = new WCF_Seguridad.Hersan_SeguridadClient();
        WCF_Catalogos.Hersan_CatalogosClient oCatalogos;
        private int Id = 0;
        private List<MenusBE> lstMnu;
        int Empresa = 1;
        #endregion

        #region Eventos
        public frmPerfiles()
        {
            InitializeComponent();
        }
        private void frmPerfiles_Load(object sender, EventArgs e)
        {
            try{
                ObtenerEmpresas();
                cargaGrid();
            }catch (Exception ex){
                RadMessageBox.Show("Ocurrión un error al cargar la pantalla\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
            }
        }
        private void cboEmpresas_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try {
                if (int.Parse(cboEmpresas.SelectedValue.ToString()) > 0) {
                    cargaGrid();
                }
            } catch (Exception ex) {
                throw ex;
            }
        }
        private void rgvPerfiles_CurrentRowChanged(object sender, Telerik.WinControls.UI.CurrentRowChangedEventArgs e)
        {
            try{
                Id = int.Parse(e.CurrentRow.Cells["ID"].Value.ToString());
                rtxtNombre.Text = e.CurrentRow.Cells["Nombre"].Value.ToString();
                rchkActivo.Checked = (bool)e.CurrentRow.Cells["Activo"].Value;
                MuestraPermisos();
            }catch(Exception ex){
                throw ex;
            }
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Id = 0;
            rtxtNombre.Text = string.Empty;
            rchkActivo.Checked = true;
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try {
                errorProvider1.SetError(rtxtNombre, "");
                if (rtxtNombre.Text.Trim().Equals(string.Empty)) {
                    errorProvider1.SetError(rtxtNombre, "Ingrese el nombre del perfil");
                    RadMessageBox.Show("Ingrese el nombre del perfil", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                } else {
                    if (Id.Equals(0)) {
                        ResultadoBE res = wcf.GuardaRoles(rtxtNombre.Text.Trim(), Empresa, BaseWinBP.UsuarioLogueado.ID, rchkActivo.Checked);

                        if (res.EsValido) {
                            cargaGrid();
                            RadMessageBox.Show("Se guardo correctamente el perfil", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                        } else
                            RadMessageBox.Show(res.Error, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
                    } else {
                        ResultadoBE res = wcf.ActualizaRoles(Id, rtxtNombre.Text.Trim(), Empresa, BaseWinBP.UsuarioLogueado.ID, rchkActivo.Checked);

                        if (res.EsValido) {
                            cargaGrid();
                            RadMessageBox.Show("Se actualizo correctamente el perfil", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                        } else
                            RadMessageBox.Show(res.Error, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
                    }
                }
            } catch (Exception ex) {
                RadMessageBox.Show("Guardar\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancelarPermiso_Click(object sender, EventArgs e)
        {
            try{
                MuestraPermisos();
            }catch(Exception ex){
                RadMessageBox.Show("Ocurripo un error al cancelar los cambios\n"+ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void btnGuardarPermiso_Click(object sender, EventArgs e)
        {
            DataTable oData = new DataTable("Datos");
            try{
                oData.Columns.Add("IdRol");
                oData.Columns.Add("IdMenu");
                oData.Columns.Add("IdPadre");
                oData.Columns.Add("Estatus");

                lstMnu.ForEach(item => {
                    DataRow oRow = oData.NewRow();
                    oRow["IdRol"] = Id;
                    oRow["IdMenu"] = item.ID;
                    oRow["IdPadre"] = item.IDPadre;
                    oRow["Estatus"] = item.Asignado;

                    oData.Rows.Add(oRow);
                });

                /* SE GUARDAN LOS CAMBIOS */
                int Result = wcf.GuardaMenuRol(oData);

                if(Result != 0) {
                    RadMessageBox.Show("Permisos asignados correctamente", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                } else {
                    RadMessageBox.Show("Ocurrió un error al guardar los permisos", this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
                }
                MuestraPermisos();
            }catch (Exception ex){
                RadMessageBox.Show("Ocurrió un error al guardar los permisos\n"+ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void rtvPermisos_NodeCheckedChanged(object sender, TreeNodeCheckedEventArgs e)
        {
            try {
                LimpiaSelec();
                int IdMenu = int.Parse(e.Node.Value.ToString());

                MenusBE tempMnu = lstMnu.Find(p => p.ID.Equals(IdMenu));
                if (tempMnu != null) {
                    txtMenu.Text = tempMnu.ID.ToString();
                    txtNodo.Text = tempMnu.IDPadre.ToString();
                    if (e.Node.CheckState == Telerik.WinControls.Enumerations.ToggleState.Indeterminate) {
                        tempMnu.Asignado = true;
                        ChkActivo.Checked = tempMnu.Asignado;
                    } else {
                        tempMnu.Asignado = e.Node.Checked;
                        ChkActivo.Checked = tempMnu.Asignado;
                    }
                }
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al seleccionar el menú\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
            }
        }
        #endregion

        #region Metodos
        private void PermisosSeguridad()
        {
            try
            {
                //var temp = BaseWin.ListadoMenu.FirstOrDefault(p => p.ID.ToString().Equals(this.Tag));

                //if (temp != null)
                //{
                //    if (temp.PuedeAgregar)
                //    {
                //        btnNuevo.Enabled = true;
                //    }
                //    else
                //    {
                //        btnNuevo.Enabled = false;
                //    }

                //    if (temp.PuedeEditar)
                //    {
                //        btnGuardar.Enabled = true;
                //        btnGuardarPermiso.Enabled = true;
                //    }
                //    else
                //    {
                //        btnGuardar.Enabled = false;
                //        btnGuardarPermiso.Enabled = false;
                //    }


                //    if (temp.PuedeEliminar)
                //    {
                //        rchkActivo.Enabled = true;
                //    }
                //    else
                //    {
                //        rchkActivo.Enabled = false;
                //    }
                //}
            }
            catch
            {

            }
        }
        private void cargaGrid()
        {
            try {
                rgvPerfiles.DataSource = wcf.ObtieneRoles(Empresa);
            } catch (Exception ex) {
                throw ex;
            }
        }
        private void MuestraPermisos()
        {
            lstMnu = wcf.ObtenerMenuRol(Id, 0, 0);
            try{
                rtvPermisos.ChildMember = "ID";
                rtvPermisos.DisplayMember = "Menu";
                rtvPermisos.ValueMember = "ID";
                rtvPermisos.ParentMember = "IDPadre";
                rtvPermisos.DataSource = lstMnu;
                rtvPermisos.ExpandAll();

                lstMnu.ForEach(mnu => {
                    var nodo = rtvPermisos.FindNodes(p => int.Parse(p.Value.ToString()).Equals(mnu.ID)).FirstOrDefault();

                    if (nodo != null && nodo.Nodes.Count.Equals(0)) {
                        nodo.Checked = mnu.Asignado;
                        mnu.Menu = mnu.Auxiliar;
                        int IdMenu = int.Parse(nodo.Value.ToString());
                        nodo.Text = string.Format("{0}", mnu.Menu);
                    }
                });
                   
            }catch(Exception ex){
                RadMessageBox.Show("CargaPermisos\n"+ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void LimpiaSelec()
        {
            txtMenu.Text = string.Empty;
            txtNodo.Text = string.Empty;
        }
        private void ObtenerEmpresas()
        {
            oCatalogos = new WCF_Catalogos.Hersan_CatalogosClient();
            try {
                cboEmpresas.DisplayMember = "NombreComercial";
                cboEmpresas.ValueMember = "Id";
                cboEmpresas.DataSource = oCatalogos.ABCEmpresas_Cbo();
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrio un error al cargar las empresas:" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
            } finally {
                oCatalogos = null;
            }

        }
        #endregion
    }
}
