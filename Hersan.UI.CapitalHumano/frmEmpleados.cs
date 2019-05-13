using Hersan.Entidades.CapitalHumano;
using Hersan.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace Hersan.UI.CapitalHumano
{
    public partial class frmEmpleados : Telerik.WinControls.UI.RadForm
    {
        CapitalHumano.WCF_Catalogos.Hersan_CatalogosClient oCatalogo;
        CapitalHumano.WCF_CHumano.Hersan_CHumanoClient oCHumano;
        List<EmpleadosBE> oList = new List<EmpleadosBE>();
        List<ExpedientesBE> oExpediente = new List<ExpedientesBE>();
        public frmEmpleados()
        {
            InitializeComponent();
        }
        private void LimpiarCampos()
        {
            txtApellidos.Text = string.Empty;
            txtFonacot.Text = string.Empty;
            txtId.Text = "0";
            txtIdExp.Text ="0";
            txtInfonavit.Text = string.Empty;
            txtNombres.Text = string.Empty;
            txtNumEmp.Text = "0";
            txtRegistro.Text = string.Empty;
            txtSueldo.Text = string.Empty;
            txtSeguro.Text = string.Empty;

        }
        private bool ValidarCampos()
        {
            bool Flag = true;
            try {
                Flag = txtSeguro.Text.Trim().Length == 0 ? false : true;
                Flag = txtSueldo.Text.Trim().Length == 0 ? false : true;
                Flag = txtFonacot.Text.Trim().Length == 0 ? false : true;
                Flag = txtInfonavit.Text.Trim().Length == 0 ? false : true;
                Flag = txtNombres.Text.Trim().Length == 0 ? false : true;
                Flag = txtNumEmp.Text.Trim().Length == 0 ? false : true;


                return Flag;
            } catch (Exception ex) {
                throw ex;
            }
        }
        private void CargaExpediente(int IdExpediente)
        {
            oCHumano = new WCF_CHumano.Hersan_CHumanoClient();

            try {
                oExpediente = oCHumano.CHU_Expedientes_Obtener(IdExpediente);
                if (oExpediente.Count > 0) {

                    //  SE CARGA EL EXPEDIENTE
                    txtIdExp.Text = IdExpediente.ToString();

                    ExpedientesDatosPersonales oAux = new ExpedientesDatosPersonales();
                    oAux.IdExpediente = int.Parse(txtIdExp.Text);
                    var Item = oCHumano.CHU_ExpedientesDatosPersonales_Consultar(oAux);

                    if (Item.Count > 0) {
                        txtApellidos.Text = Item[0].APaterno + " " + Item[0].AMaterno;
                        txtNombres.Text = Item[0].Nombres;

                    }
                }
            } catch (Exception) {

                throw;
            }
        }
        private void frmEmpleados_Load(object sender, EventArgs e)
        {

        }

        private void radPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            oCatalogo = new CapitalHumano.WCF_Catalogos.Hersan_CatalogosClient();
            oCHumano = new CapitalHumano.WCF_CHumano.Hersan_CHumanoClient();
            EmpleadosBE obj = new EmpleadosBE();
            try {
                if (!ValidarCampos()) {
                    RadMessageBox.Show("Debe capturar todos los datos para continuar", this.Text, MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                    return;
                }

                if (oList.FindAll(item => item.Expedientes.Id == int.Parse(txtIdExp.Text)).Count > 0
                   && int.Parse(txtId.Text) == -1) {
                    RadMessageBox.Show("El departamento capturado ya existe, no es posible guardar", this.Text, MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                    LimpiarCampos();
                    return;
                }
                #region Entidades
                obj.Numero = int.Parse(txtNumEmp.Text);
                obj.Expedientes.Id = int.Parse(txtIdExp.Text);
                obj.EstatusEmpleado = (cboEstatus.SelectedItem.Text);
                obj.Fonacot = txtFonacot.Text;
                obj.Infonavit= txtInfonavit.Text;
                obj.NumeroCuenta = txtCuenta.Text;
                obj.RegistroFederal = txtRegistro.Text;
                obj.SeguroSocial = txtSeguro.Text;
                obj.SueldoAprobado = decimal.Parse(txtSueldo.Text);
                obj.DatosUsuarios.IdUsuarioCreo = BaseWinBP.UsuarioLogueado.ID;
                #endregion





                //PROCESO DE GUARDADO Y ACTUALIZACION
                if (txtId.Text == "-1") {
                    int Result = oCHumano.CHUEmpleados_Guardar(obj);
                    if (Result == 0) {
                        RadMessageBox.Show("Ocurrió un error al enviar la solicitud de empleo", this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
                    } else {
                        RadMessageBox.Show("Solicitud enviada correctamente", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                        LimpiarCampos();
                                           
                    }
                } else {
                    oCHumano = new CapitalHumano.WCF_CHumano.Hersan_CHumanoClient();
                    int Result = oCHumano.CHU_EmpleadosActualizar(obj);
                    if (Result == 0) {
                        RadMessageBox.Show("Ocurrió un error al actualizar los datos", this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
                    } else {
                        RadMessageBox.Show("Información actualizada correctamente", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                        LimpiarCampos();


                    }
                }
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrio un error al actualizar la información\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally {

                oCHumano = null;
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try {

            } catch (Exception) {

                throw;
            }

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int IdExpediente = 0;
            try {
                frmExpedienteConsulta ofrm = new frmExpedienteConsulta();
                ofrm.WindowState = FormWindowState.Normal;
                ofrm.StartPosition = FormStartPosition.CenterScreen;
                ofrm.MaximizeBox = false;
                ofrm.MinimizeBox = false;
                ofrm.ShowDialog();
                IdExpediente = ofrm.IdExpediente;


                if (IdExpediente > 0) {
                    LimpiarCampos();
                    CargaExpediente(IdExpediente);
                    //CargarGrid();
                }
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al realiza la búsqueda\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
    }
}
