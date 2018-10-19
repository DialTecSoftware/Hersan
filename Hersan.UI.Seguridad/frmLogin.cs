using Hersan.Entidades;
using Hersan.Entidades.Seguridad;
using Hersan.Negocio;
using Hersan.Negocio.Seguridad;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace Hersan.UI.Seguridad
{
    public partial class frmLogin : Telerik.WinControls.UI.RadForm
    {        
        public frmLogin()
        {
            InitializeComponent();            
        }       
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try {
                #region Validaciones Acceso Al Sistema
                string msg = string.Empty;
                errorProvider1.SetError(rtxtUsuario, "");
                errorProvider1.SetError(rtxtContrasenia, "");

                if (rtxtUsuario.Text.Trim().Length.Equals(0))
                {
                    msg = "- Ingrese el usuario" + Environment.NewLine;
                    errorProvider1.SetError(rtxtUsuario, "Ingrese el usuario");
                }

                if (rtxtContrasenia.Text.Trim().Length.Equals(0))
                {
                    msg += "- Ingrese la contraseña";
                    errorProvider1.SetError(rtxtContrasenia, "Ingrese la contraseña");
                }

                if (msg.Length.Equals(0))
                {
                    //WCF_Seguridad.SIAC_SeguridadClient wcf = new WCF_Seguridad.SIAC_SeguridadClient();
                    ValidaIngresoBE val = wcf.ValidaUsuario(rtxtUsuario.Text.Trim(), new EncriptadorBP().EncriptarTexto(rtxtContrasenia.Text.Trim()));

                    if (val.EsIngresoValido)
                    {
                        BaseWinBP.ListadoMenu = wcf.ObtenerMenuUsuario(rtxtUsuario.Text.Trim(), BaseWinBP.Sistema);
                        BaseWinBP.UsuarioLogueado = wcf.ObtieneDatosUsuario(rtxtUsuario.Text.Trim());
                    }
                    else
                    {
                        RadMessageBox.Show(val.ErrorIngreso, this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                        this.DialogResult = DialogResult.None;
                    }
                }
                else
                {
                    RadMessageBox.Show("Datos Obligatorios" + Environment.NewLine + msg, this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                    this.DialogResult = DialogResult.None;
                }
                #endregion


                //WCF_Seguridad.SIAC_SeguridadClient wcf = new WCF_Seguridad.SIAC_SeguridadClient();

                BaseWinBP.ListadoMenu = wcf.ObtenerMenusDemo();
                BaseWinBP.UsuarioLogueado = wcf.ObtieneDatosUsuario("admin");

                this.DialogResult = DialogResult.OK;
                this.Close();                   
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrio un error al validar al usuario:" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                this.DialogResult = DialogResult.None;
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void rtxtUsuario_Enter(object sender, EventArgs e)
        {
            try {
                rtxtUsuario.SelectionStart = 0;
                rtxtUsuario.SelectionLength = rtxtUsuario.Text.Length;

            } catch {
                RadMessageBox.Show("Ocurrio un error al Seleccionar el Usuario");
            }
        }
        private void rtxtContrasenia_Enter(object sender, EventArgs e)
        {
            try {
                rtxtContrasenia.SelectionStart = 0;
                rtxtContrasenia.SelectionLength = rtxtContrasenia.Text.Length;
            } catch {
                RadMessageBox.Show("Ocurrio un error al Seleccionar la Contraseña");
            }
        }
    }

}
