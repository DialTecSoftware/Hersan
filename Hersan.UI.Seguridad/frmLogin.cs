using Hersan.Entidades.Seguridad;
using Hersan.Negocio;
using Hersan.Negocio.Seguridad;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls;

namespace Hersan.UI.Seguridad
{
    public partial class frmLogin : Telerik.WinControls.UI.RadForm
    {        
        WCF_Catalogos.Hersan_CatalogosClient oCatalogos;
        int Empresa = 0;

        public frmLogin()
        {
            InitializeComponent();            
        }
        private void frmLogin_Load(object sender, EventArgs e)
        {
            try {
                ObtenerEmpresas();
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrio un error al cargar la pantalla:" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
            }
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
                
                //SE OBTIENE EL ID DE LA EMPRESA SELECCIONADA
                Empresa = int.Parse(cboEmpresas.SelectedValue.ToString());

                if (msg.Length.Equals(0))
                {
                    WCF_Seguridad.Hersan_SeguridadClient wcf = new WCF_Seguridad.Hersan_SeguridadClient();
                    ValidaIngresoBE val = wcf.ValidaUsuario(rtxtUsuario.Text.Trim(), new EncriptadorBP().EncriptarTexto(rtxtContrasenia.Text.Trim()),Empresa);

                    if (val.EsIngresoValido)
                    {
                        BaseWinBP.ListadoMenu = wcf.ObtenerMenuUsuario(rtxtUsuario.Text.Trim(), Empresa);
                        BaseWinBP.UsuarioLogueado = wcf.ObtieneDatosUsuario(rtxtUsuario.Text.Trim(),Empresa);
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

        private void lblUsuario_Click(object sender, EventArgs e)
        {

        }
        private void ObtenerEmpresas()
        {
            oCatalogos = new WCF_Catalogos.Hersan_CatalogosClient();
            try {
                cboEmpresas.DataSource = oCatalogos.ABCEmpresas_Cbo();
                cboEmpresas.DisplayMember = "NombreComercial";
                cboEmpresas.ValueMember = "Id";
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrio un error al cargar las empresas:" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
            } finally {
                oCatalogos = null;
            }

        }

    }

}
