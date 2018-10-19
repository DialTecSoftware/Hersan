using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
//using SIAC.Entidades.Seguridad;
//using SIAC.Entidades.Comun;
//using SIAC.Negocio;
//using SIAC.UI.Base;
//using SIAC.UI.Tools;

namespace Hersan.UI.Seguridad
{
    public partial class frmPerfiles : Telerik.WinControls.UI.RadForm
    {
        #region Variables
        //WCF_Seguridad.SIAC_SeguridadClient wcf = new WCF_Seguridad.SIAC_SeguridadClient();
        private int Id = 0;
        //private List<MenusBE> lstMnu;
        private bool EsCambio = false;
        #endregion

        #region Eventos
        public frmPerfiles()
        {
            InitializeComponent();
        }
        private void frmPerfiles_Load(object sender, EventArgs e)
        {
            try
            {
                EsCambio = false;
                cboAplicacion.DisplayMember = "Aplicacion";
                cboAplicacion.ValueMember = "ID";
                cboAplicacion.DataSource = wcf.ObtieneAplicaciones();
                cboAplicacion.Enabled = true;
                cargaGrid();
            }
            catch (Exception ex)
            {
                RadMessageBox.Show("Ocurrión un error al cargar la pantalla\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
            }
        }
        private void rgvPerfiles_CurrentRowChanged(object sender, Telerik.WinControls.UI.CurrentRowChangedEventArgs e)
        {
            try
            {
                Id = int.Parse(e.CurrentRow.Cells["ID"].Value.ToString());
                rtxtNombre.Text = e.CurrentRow.Cells["Nombre"].Value.ToString();
                rchkActivo.Checked = (bool)e.CurrentRow.Cells["Activo"].Value;

                CargaPermisos();
                EsCambio = false;
            }
            catch
            {
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
            try
            {
                errorProvider1.SetError(rtxtNombre, "");

                if (rtxtNombre.Text.Trim().Equals(string.Empty))
                {
                    errorProvider1.SetError(rtxtNombre, "Ingrese el nombre del perfil");
                    RadMessageBox.Show("Ingrese el nombre del perfil", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                }
                else
                {
                    if (Id.Equals(0))
                    {
                        ResultadoBE res = wcf.GuardaRoles(rtxtNombre.Text.Trim(), BaseWin.UsuarioLogueado.ID, rchkActivo.Checked, 1);

                        if (res.EsValido)
                        {
                            cargaGrid();
                            RadMessageBox.Show("Se guardo correctamente el perfil", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                        }
                        else
                            RadMessageBox.Show(res.Error, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
                    }
                    else
                    {
                        ResultadoBE res = wcf.ActualizaRoles(Id, rtxtNombre.Text.Trim(), BaseWin.UsuarioLogueado.ID, rchkActivo.Checked);

                        if (res.EsValido)
                        {
                            cargaGrid();
                            RadMessageBox.Show("Se actualizo correctamente el perfil", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                        }
                        else
                            RadMessageBox.Show(res.Error, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
                    }
                }
            }
            catch
            {
                RadMessageBox.Show("Guardar", this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void btnCancelarPermiso_Click(object sender, EventArgs e)
        {
            try
            {
                CargaPermisos();
                EsCambio = false;
            }
            catch
            {
            }
        }
        private void cboAplicacion_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
                CargaPermisos();
                EsCambio = false;
            }
            catch
            {
            }
        }
        private void chk_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            //if (rtvPermisos.SelectedNodes.Count > 0)
            //{
            //    RadTreeNode rtnAux = new RadTreeNode();
            //    foreach (RadTreeNode rtn in rtvPermisos.SelectedNodes)
            //    {
            //        rtnAux = rtn;
            //        txtMenu.Text = string.Empty;
            //        txtNodo.Text = string.Empty;

            //        int IdMenu = int.Parse(rtn.Value.ToString());
            //        txtMenu.Text = IdMenu.ToString();

            //        var tempMnu = lstMnu.FirstOrDefault(p => p.ID.Equals(IdMenu));
            //        if (tempMnu != null)
            //        {
            //            txtNodo.Text = tempMnu.IDPadre.ToString();
            //            if (rtn.GetNodeCount(true).Equals(0))
            //            {
            //                if (rtn.Checked)
            //                {
            //                    tempMnu.PuedeAgregar = chkAgregar.Checked;
            //                    tempMnu.PuedeEditar = chkEditar.Checked;
            //                    tempMnu.PuedeEliminar = chkEliminar.Checked;
            //                }
            //            }
            //            else
            //            {
            //                tempMnu.PuedeAgregar = true;
            //                tempMnu.PuedeEditar = true;
            //                tempMnu.PuedeEliminar = true;
            //            }
            //        }
            //    }

            //    //MuestraPermisos();

            //    rtvPermisos.TreeViewElement.Update(RadTreeViewElement.UpdateActions.Reset);

            //    rtvPermisos.BringIntoView(rtnAux);
            //    EsCambio = true;
            //}
        }
        private void btnGuardarPermiso_Click(object sender, EventArgs e)
        {
            try
            {
                List<MenusBE> lstM = new List<MenusBE>();
                if (cboEmpresas.SelectedIndex > -1)
                {
                    MenusBE obj = new MenusBE();
                    obj.ID = (int)cboEmpresas.SelectedValue;
                    obj.IDPadre = int.Parse(txtNodo.Text);
                    obj.Menu = txtMenu.Text.ToString();
                    obj.Activo = ChkActivo.Checked;
                    obj.PuedeAgregar = chkAgregar.Checked;
                    obj.PuedeEditar = chkEditar.Checked;
                    obj.PuedeEliminar = chkEliminar.Checked;
                    lstM.Add(obj);
                    //wcf.GuardaMenuRol(lstM, Id, int.Parse(cboAplicacion.SelectedValue.ToString()));
                    wcf.GuardaMenuRol(lstM, Id, 0);
                    CargaPermisos();
                }
                EsCambio = true;
            }
            catch
            {
                RadMessageBox.Show("GuardarPermiso", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
            }
        }
        private void rtvPermisos_NodeCheckedChanged(object sender, TreeNodeCheckedEventArgs e)
        {
            try
            {
                int IdMenu = int.Parse(e.Node.Value.ToString());

                LimpiaSelec();

                var tempMnu = lstMnu.FirstOrDefault(p => p.ID.Equals(IdMenu));
                if (tempMnu != null)
                {
                    cboEmpresas.SelectedValue = tempMnu.ID;
                    //cboProceso.SelectedValue = tempMnu.proceso.ID;
                    chkAgregar.Checked = tempMnu.PuedeAgregar;
                    chkEditar.Checked = tempMnu.PuedeEditar;
                    chkEliminar.Checked = tempMnu.PuedeEliminar;
                    txtMenu.Text = tempMnu.ID.ToString();
                    txtNodo.Text = tempMnu.IDPadre.ToString();
                    if (e.Node.CheckState == Telerik.WinControls.Enumerations.ToggleState.Indeterminate)
                    {
                        tempMnu.Asignado = true;
                        ChkActivo.Checked = tempMnu.Asignado;
                    }
                    else
                    {
                        tempMnu.Asignado = e.Node.Checked;
                        ChkActivo.Checked = tempMnu.Asignado;
                    }
                }

                EsCambio = true;

            }
            catch
            {
                RadMessageBox.Show("rtvPermisos", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
            }
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void rtvPermisos_SelectedNodeChanged(object sender, RadTreeViewEventArgs e)
        {
            //try
            //{
            //    int IdMenu = int.Parse(e.Node.Value.ToString());
            //    LimpiaSelec();

            //    //var tempMnu = from p in lstPro where p.IdMenu.Equals(IdMenu) || p.ID.Equals(0) select p;

            //    foreach (MenusBE tempMnu in lstMnu)
            //     {
            //         if (tempMnu.ID == IdMenu)
            //        {
            //            cboPrograma.SelectedValue = tempMnu.ID;
            //            //cboProceso.SelectedValue = tempMnu.proceso.ID;
            //            chkAgregar.Checked = tempMnu.PuedeAgregar;
            //            chkEditar.Checked = tempMnu.PuedeEditar;
            //            chkEliminar.Checked = tempMnu.PuedeEliminar;
            //            txtMenu.Text = tempMnu.ID.ToString();
            //            txtNodo.Text = tempMnu.IDPadre.ToString();

            //            if (e.Node.CheckState == Telerik.WinControls.Enumerations.ToggleState.Indeterminate)
            //            {
            //                tempMnu.Asignado = true;
            //                ChkActivo.Checked = tempMnu.Asignado;
            //            }
            //            else
            //            {
            //                tempMnu.Asignado = e.Node.Checked;
            //                ChkActivo.Checked = tempMnu.Asignado;
            //            }


            //            break;
            //        }
            //     }
            //}
            //catch
            //{
            //    RadMessageBox.Show("Permisos", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
            //}
        }
        private void cboProceso_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
                //if (rtvPermisos.SelectedNodes.Count > 0)
                //{
                //    RadTreeNode rtn = rtvPermisos.SelectedNode;
                //    int IdMenu = int.Parse(rtn.Value.ToString());
                //    var tempProc = from p in lstPro where p.IdMenu.Equals(IdMenu) || p.ID.Equals(0) select p;

                //    if (tempProc != null && tempProc.Count() > 1)
                //    {
                //        var tempMnu = lstMnu.FirstOrDefault(p => p.ID.Equals(IdMenu));
                //        if (tempMnu != null)
                //        {
                //            tempMnu.proceso.ID = int.Parse(cboProceso.SelectedValue.ToString());
                //            tempMnu.proceso.Proceso = cboProceso.Text;
                //        }
                //    }

                //MuestraPermisos();

                //rtvPermisos.TreeViewElement.Update(RadTreeViewElement.UpdateActions.Reset);

                //rtvPermisos.BringIntoView(rtn);
                //EsCambio = true;
                //}

            }
            catch
            {
            }
        }
        private void cboAplicacion_SelectedIndexChanged_1(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            CargaPermisos();
        }
        private void frmPerfiles_Shown(object sender, EventArgs e)
        {
            PermisosSeguridad();
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
            List<RolesBE> roles = wcf.ObtieneRoles();
            rgvPerfiles.DataSource = roles;
        }
        private void CargaPermisos()
        {
            try
            {
                if (cboAplicacion.SelectedIndex > -1)
                {
                    lstMnu = wcf.ObtenerMenuRol(Id, int.Parse(cboAplicacion.SelectedValue.ToString()), 0, 0);

                    cboEmpresas.DisplayMember = "Menu";
                    cboEmpresas.ValueMember = "ID";
                    cboEmpresas.DataSource = lstMnu;
                    cboEmpresas.Enabled = false;

                    MuestraPermisos();
                }
            }
            catch
            {
                RadMessageBox.Show("CargaPermisos", this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void MuestraPermisos()
        {
            try
            {
                rtvPermisos.ChildMember = "ID";
                rtvPermisos.DisplayMember = "Menu";
                rtvPermisos.ValueMember = "ID";
                rtvPermisos.ParentMember = "IDPadre";
                rtvPermisos.DataSource = lstMnu;
                rtvPermisos.ExpandAll();

                foreach (MenusBE mnu in lstMnu)
                {

                    var nodo = rtvPermisos.FindNodes(p => int.Parse(p.Value.ToString()).Equals(mnu.ID)).FirstOrDefault();

                    if (nodo != null && nodo.Nodes.Count.Equals(0))
                    {
                        nodo.Checked = mnu.Asignado;

                        //string Permisos = string.Empty;
                        //string Proc = string.Empty;
                        //Permisos = mnu.PuedeAgregar ? "Agregar" : "";
                        //Permisos += mnu.PuedeEditar ? ", Editar" : "";
                        //Permisos += mnu.PuedeEliminar ? ", Eliminar" : "";

                        //Permisos = Permisos.TrimStart(',').Trim();
                        mnu.Menu = mnu.Auxiliar;

                        //if (mnu.proceso.ID > 0) {
                        //    Proc = " - Proceso: " + mnu.proceso.Proceso;
                        //} else {
                        int IdMenu = int.Parse(nodo.Value.ToString());
                        //}
                        //nodo.Text = string.Format("{0} ({1}) {2}", mnu.Menu, Permisos, Proc);
                        nodo.Text = string.Format("{0}", mnu.Menu);
                    }
                    string st = string.Empty;
                }
            }
            catch
            {
                RadMessageBox.Show("CargaPermisos", this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void LimpiaSelec()
        {
            cboEmpresas.SelectedValue = null;
            //cboProceso.SelectedValue = null;
            chkAgregar.Checked = false;
            chkEditar.Checked = false;
            chkEliminar.Checked = false;
            txtMenu.Text = string.Empty;
            txtNodo.Text = string.Empty;
        }
        #endregion
    }
}
