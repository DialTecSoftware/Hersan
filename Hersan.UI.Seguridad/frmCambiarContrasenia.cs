using Hersan.Entidades.Seguridad;
using Hersan.Negocio;
using Hersan.Negocio.Seguridad;
using System;
using System.Windows.Forms;
using Telerik.WinControls;

namespace Hersan.UI.Seguridad
{
    public partial class frmCambiarContrasenia : Telerik.WinControls.UI.RadForm
    {
        WCF_Seguridad.Hersan_SeguridadClient wcf = new WCF_Seguridad.Hersan_SeguridadClient();
        int Empresa = BaseWinBP.UsuarioLogueado.Empresa.Id;

        public frmCambiarContrasenia()
        {
            InitializeComponent();
        }
        private void frmCambiarContrasenia_Load(object sender, EventArgs e)
        {
            try {
                this.WindowState = FormWindowState.Normal;
                this.StartPosition = FormStartPosition.CenterParent;
            } catch (Exception ex) {
                throw ex;
            }
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try {
                UsuariosBE Usuario = BaseWinBP.UsuarioLogueado;
                errorProvider1.SetError(rtxtUsuario, "");
                errorProvider1.SetError(rtxtContrasenia, "");
                errorProvider1.SetError(txtNuevaContra, "");
                string msg = string.Empty;

                if (rtxtUsuario.Text.Trim().Length.Equals(0)) {
                    msg = "- Ingrese la contraseña anterior" + Environment.NewLine;
                    errorProvider1.SetError(rtxtUsuario, "Ingrese la contraseña anterior");
                }

                if (rtxtContrasenia.Text.Trim().Length.Equals(0)) {
                    msg += "- Ingrese la nueva contraseña" + Environment.NewLine;
                    errorProvider1.SetError(rtxtContrasenia, "Ingrese la nueva contraseña");
                }

                if (txtNuevaContra.Text.Trim().Length.Equals(0)) {
                    msg += "- Repita la nueva contraseña" + Environment.NewLine;
                    errorProvider1.SetError(rtxtContrasenia, "Repipta la nueva contraseña");
                }

                if (!rtxtContrasenia.Text.Trim().Equals(txtNuevaContra.Text.Trim())) {
                    msg += "- Las contraseñas no coinciden";
                    errorProvider1.SetError(rtxtContrasenia, "Las contraseñas no coinciden");
                }


                if (msg.Length.Equals(0)) {
                    if (RadMessageBox.Show("Esta acción cambiará la contraseña y cerrará el sistema\nDesea continuar...?", this.Text, MessageBoxButtons.YesNo, RadMessageIcon.Question) == System.Windows.Forms.DialogResult.Yes) {
                        //WCF_Seguridad.SIAC_SeguridadClient wcf = new WCF_Seguridad.SIAC_SeguridadClient();

                        //Se valida primero el usuario
                        ValidaIngresoBE val = wcf.ValidaUsuario(Usuario.Usuario, new EncriptadorBP().EncriptarTexto(rtxtUsuario.Text.Trim()));
                        if (val.EsIngresoValido) {
                            //Se cambia el password y se sale de la aplicación
                            Usuario.Contrasena = new EncriptadorBP().EncriptarTexto(txtNuevaContra.Text.Trim());
                            if (wcf.CambiaContrasenia(Usuario) == 0) {
                                RadMessageBox.Show("Ocurrió un error, la contraseña no puede ser cambiada", this.Text, MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                                this.Close();
                            } else {
                                RadMessageBox.Show("Contraseña cambiada correctamente, ahora el sistema se cerrará", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                                Application.Exit();
                            }
                        } else {
                            RadMessageBox.Show("La contraseña capturada es incorrecta\ncorrija e intente de nuevo", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                        }
                    } else
                        this.Close();
                } else {
                    RadMessageBox.Show("Datos Obligatorios" + Environment.NewLine + msg, this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                    this.DialogResult = DialogResult.None;
                }
            } catch (Exception ex) {
                throw ex;
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try {
                this.Close();
            } catch (Exception ex) {
                throw ex;
            }
        }
    }
}
