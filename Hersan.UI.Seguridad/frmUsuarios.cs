using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Text.RegularExpressions;
using SIAC.Entidades.Seguridad;
using SIAC.Entidades.Comun;
using SIAC.Negocio;
using SIAC.Negocio.Seguridad;
using SIAC.UI.Base;
//using SIAC.UI.Tools;

namespace SIAC.UI.Seguridad
{
    public partial class frmUsuarios : Telerik.WinControls.UI.RadForm
    {
        #region Variables
        WCF_Seguridad.SIAC_SeguridadClient wcf = new WCF_Seguridad.SIAC_SeguridadClient();        
        List<UsuariosBE> lstUsuarios;
        Regex reg = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

        private int Id = 0;
        private string usr = string.Empty;
        private List<RolesBE> lstRoles;
        #endregion

        #region Eventos
        public frmUsuarios()
        {
            InitializeComponent();
        }
        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            try{
                cargaGrid();
            }catch(Exception ex){
                RadMessageBox.Show("Ocurrió un error al cargar la forma\n"+ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void btnUnlock_Click(object sender, EventArgs e)
        {
            try {
                wcf.DesbloqueaUsuario(usr);
                RadMessageBox.Show("Se desbloqueo correctamente el usuario", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                btnRefrescar_Click(null, null);
            } catch(Exception ex){
                RadMessageBox.Show("Ocurrió un error al desbloquear al usuario\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            try {
                this.Close();
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al cerrar la forma\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void rgvUsuarios_CurrentRowChanged(object sender, Telerik.WinControls.UI.CurrentRowChangedEventArgs e)
        {
            try
            {
                Id = int.Parse(e.CurrentRow.Cells["ID"].Value.ToString());
                rtxtNombre.Text = e.CurrentRow.Cells["Nombre"].Value.ToString();
                rtxtUsuario.Text = e.CurrentRow.Cells["Usuario"].Value.ToString();
                usr = rtxtUsuario.Text;
                rtxtCorreo.Text = e.CurrentRow.Cells["Correo"].Value.ToString();

                var temp = lstUsuarios.FirstOrDefault(p => p.ID.Equals(Id));
                string Contrasenia = string.Empty;

                if (temp != null)
                    Contrasenia = new EncriptadorBP().DesencriptarTexto(temp.Contrasena);

                rtxtContrasenia.Text = Contrasenia;
                rtxtRepContrasenia.Text = Contrasenia;
                rtxtRepCorreo.Text = e.CurrentRow.Cells["Correo"].Value.ToString();
                rchkActivo.Checked = (bool)e.CurrentRow.Cells["Activo"].Value;

                MuestraPefiles();

            }catch(Exception ex){
                RadMessageBox.Show("Ocurrió un error al seleccionar el registro\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }

        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try {
                Id = 0;
                usr = string.Empty;
                rtxtNombre.Text = string.Empty;
                rtxtUsuario.Text = string.Empty;
                rtxtContrasenia.Text = string.Empty;
                rtxtRepContrasenia.Text = string.Empty;
                rtxtCorreo.Text = string.Empty;
                rtxtRepCorreo.Text = string.Empty;
                rchkActivo.Checked = true;

                LimpiaError();

                rgvUsuarios.ClearSelection();
                MuestraPefiles();
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al limpiar los campos\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            try{
                cargaGrid();
                LimpiaError();
            }catch(Exception ex){
                RadMessageBox.Show("Ocurrió un error al refrescar los datos\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try{
                string msg = string.Empty;
                LimpiaError();

                if (rtxtNombre.Text.Trim().Equals(string.Empty)) {
                    errorProvider1.SetError(rtxtNombre, "Ingrese el nombre");
                    msg = "- Ingrese el nombre" + Environment.NewLine;
                }

                if (rtxtUsuario.Text.Trim().Equals(string.Empty)){
                    errorProvider1.SetError(rtxtUsuario, "Ingrese el usuario");
                    msg += "- Ingrese el usuario" + Environment.NewLine;
                }

                if (rtxtContrasenia.Text.Trim().Equals(string.Empty)){
                    errorProvider1.SetError(rtxtContrasenia, "Ingrese la contraseña");
                    msg += "- Ingrese la contraseña" + Environment.NewLine;
                }else 
                    if (!rtxtContrasenia.Text.Trim().Equals(rtxtRepContrasenia.Text.Trim())){
                        errorProvider1.SetError(rtxtRepContrasenia, "Las contraseñas no coinciden");
                        msg += "- Las contraseñas no coinciden" + Environment.NewLine;
                    }

                if (rtxtCorreo.Text.Trim().Equals(string.Empty)){
                    errorProvider1.SetError(rtxtCorreo, "Ingrese el correo eléctronico");
                    msg += "- Ingrese el correo eléctronico" + Environment.NewLine;
                }else 
                    if (!reg.IsMatch(rtxtCorreo.Text.Trim())){
                        errorProvider1.SetError(rtxtCorreo, "Correo eléctronico invalido");
                        msg += "- Correo eléctronico invalido" + Environment.NewLine;
                    }else 
                        if (!rtxtCorreo.Text.Trim().Equals(rtxtRepCorreo.Text.Trim())) {
                            errorProvider1.SetError(rtxtRepCorreo, "Los correos no coinciden");
                            msg += "- Los correos no coinciden" + Environment.NewLine;
                        }

                errorProvider1.SetError(rtxtCorreo, "");
                if (!reg.IsMatch(rtxtCorreo.Text.Trim())){
                    errorProvider1.SetError(rtxtCorreo, "Correo eléctronico invalido");
                    msg += "Correo eléctronico invalido" + Environment.NewLine;
                }

                errorProvider1.SetError(rtxtRepContrasenia, "");
                if (!rtxtContrasenia.Text.Trim().Equals(rtxtRepContrasenia.Text.Trim())){
                    errorProvider1.SetError(rtxtRepContrasenia, "Las contraseñas no coinciden");
                    msg += "Las contraseñas no coinciden" + Environment.NewLine;
                }

                if (msg.Equals(string.Empty)){
                    UsuariosBE us = new UsuariosBE();
                    us.ID = Id;
                    us.Nombre = rtxtNombre.Text.Trim();
                    us.Usuario = rtxtUsuario.Text.Trim();
                    us.Contrasena = new EncriptadorBP().EncriptarTexto(rtxtContrasenia.Text.Trim());
                    us.Correo = rtxtCorreo.Text.Trim();
                    us.Activo = rchkActivo.Checked;

                    ResultadoBE res = new ResultadoBE();

                    //Si Id = 0, entonces es un usuario nuevo
                    if (Id.Equals(0)){
                        res = wcf.GuardaUsuario(us, BaseWin.UsuarioLogueado.ID);
                        msg = "Se guardo correctamente el nuevo usuario";
                    }else{
                        res = wcf.ActualizaUsuario(us, BaseWin.UsuarioLogueado.ID);
                        msg = "Se actualizo correctamente el usuario";
                    }

                    if (res.EsValido){
                        RadMessageBox.Show("Se actualizo correctamente el usuario", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                        btnRefrescar_Click(null, null);
                    }else
                        RadMessageBox.Show(res.Error, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
                }else
                    RadMessageBox.Show(msg, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }catch (Exception ex){                
                RadMessageBox.Show("Ocurrió un error al guardar los datos\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void rtxtRepCorreo_TextChanged(object sender, EventArgs e)
        {
            try {
                errorProvider1.SetError(rtxtRepCorreo, "");
                if (!rtxtCorreo.Text.Trim().Equals(rtxtRepCorreo.Text.Trim())) {
                    errorProvider1.SetError(rtxtRepContrasenia, "Las correos no coinciden");
                }
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al capturar el correo\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);                
            }
        }
        private void rtvPerfiles_CreateNodeElement(object sender, Telerik.WinControls.UI.CreateTreeNodeElementEventArgs e)
        {
            try {
                e.Node.CheckType = Telerik.WinControls.UI.CheckType.RadioButton;
                int IdRol = int.Parse(e.Node.Value.ToString());

                var temp = lstRoles.FirstOrDefault(p => p.ID.Equals(IdRol));
                if (temp != null) {
                    e.Node.Checked = temp.EsAsignado;
                }
            } catch (Exception ex) {
                throw ex;
            }
        }
        private void btnCancelarPermiso_Click(object sender, EventArgs e)
        {
            try {
                MuestraPefiles();
            } catch (Exception ex ){
                throw ex;
            }
        }
        private void btnGuardarPermiso_Click(object sender, EventArgs e)
        {
            try {
                if (rtvPerfiles.SelectedNodes.Count.Equals(1) && !Id.Equals(0)) {
                    wcf.GuardaRolesUsuario(int.Parse(rtvPerfiles.SelectedNode.Value.ToString()), Id);
                    RadMessageBox.Show("Se asigno correctamente el perfil", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                }
            } catch (Exception ex) {
                throw ex;
            }
        }
        #endregion

        #region Métodos
        private void LimpiaError()
        {
            errorProvider1.SetError(rtxtNombre, "");
            errorProvider1.SetError(rtxtUsuario, "");
            errorProvider1.SetError(rtxtContrasenia, "");
            errorProvider1.SetError(rtxtRepContrasenia, "");
            errorProvider1.SetError(rtxtCorreo, "");
            errorProvider1.SetError(rtxtRepCorreo, "");
        }
        private void MuestraPefiles()
        {
            lstRoles = wcf.ObtieneRolesUsuario(Id);
            rtvPerfiles.DisplayMember = "Nombre";
            rtvPerfiles.ValueMember = "ID";
            rtvPerfiles.DataSource = lstRoles;
            rtvPerfiles.ExpandAll();

            rcbPerfiles.Enabled = !Id.Equals(0);
            rtvPerfiles.Enabled = !Id.Equals(0);

        }
        private void cargaGrid()
        {
            lstUsuarios = wcf.ObtieneUsuarios();
            rgvUsuarios.DataSource = null;
            rgvUsuarios.DataSource = lstUsuarios;
            rgvUsuarios.Columns["Activo"].BestFit();
        }
        #endregion
    }
}
