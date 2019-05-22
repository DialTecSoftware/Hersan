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
        List<EmpleadosBE> eList = new List<EmpleadosBE>();
        public frmEmpleados()
        {
            InitializeComponent();
        }
        private void LimpiarCampos()
        {
            txtApellidos.Text = string.Empty;
            txtFonacot.Text = string.Empty;
            txtId.Text = "0";
            txtCuenta.Text = string.Empty;
            txtIdExp.Text ="0";
            txtInfonavit.Text = string.Empty;
            txtNombres.Text = string.Empty;
            txtNumEmp.Text = "0";
         
            txtSueldo.Text = string.Empty;
            cboEstatus.SelectedIndex = 0;
            cboTipoF.SelectedIndex = 0;
            dtFecha.Value = DateTime.Today;

        }
        private void Entero_KeyPress(object sender, KeyPressEventArgs e)
        {
            try {
                if (!BaseWinBP.isNumero(e.KeyChar))
                    e.Handled = true;
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error en la captura\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void Decimal_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
        private bool ValidarCampos()
        {
            bool Flag = true;
            try {
               
                Flag = txtSueldo.Text.Trim().Length == 0 ? false : true;
                Flag = txtFonacot.Text.Trim().Length == 0 ? false : true;
               
                Flag = txtNombres.Text.Trim().Length == 0 ? false : true;
                Flag = txtNumEmp.Text.Trim().Length == 0 ? false : true;
                Flag = txtCuenta.Text.Trim().Length == 0 ? false : true;


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

        private void CargarEmpleados()
        {

            oCHumano = new WCF_CHumano.Hersan_CHumanoClient();
           
            try {
                if (int.Parse(txtIdExp.Text) >0) {
                    var item = oCHumano.CHU_Empleados_Consultar(int.Parse(txtIdExp.Text));
                    if (item.Count > 0) {
                        txtId.Text = item[0].Id.ToString();
                        txtNumEmp.Text = item[0].Numero.ToString();
                   
                        txtCuenta.Text = item[0].NumeroCuenta;
                        txtFonacot.Text = item[0].Fonacot;
                        txtInfonavit.Text = item[0].Infonavit;
                
                        txtSueldo.Text = item[0].SueldoAprobado.ToString();
                        cboEstatus.Text = Convert.ToString(item[0].EstatusEmpleado);
                        cboTipoF.Text = Convert.ToString(item[0].TipoInfonavit);
                        dtFecha.Value = DateTime.Parse( item[0].FechaIngreso.ToString());
                        dtIMSS.Value = DateTime.Parse(item[0].FechaAltaIMSS.ToString());

                        if (item[0].Fonacot != "")
                            rdbSi.IsChecked=true;
                                             
                    }
                }
            } catch (Exception) {

                throw;
            }
        }
        private void frmEmpleados_Load(object sender, EventArgs e)
        {
            try {
                LimpiarCampos();
                txtInfonavit.Visible = true; ;
                cboTipoF.Visible = true;
                lblFona.Visible = true;

            } catch (Exception) {

                throw;
            }
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

                
                #region Entidades
                obj.Numero = int.Parse(txtNumEmp.Text);
                obj.Expedientes.Id = int.Parse(txtIdExp.Text);
                obj.EstatusEmpleado = (cboEstatus.SelectedItem.Text);
                obj.TipoInfonavit = (cboTipoF.SelectedItem.Text);
                obj.Fonacot = txtFonacot.Text;
                obj.Infonavit= txtInfonavit.Text;
                obj.NumeroCuenta = txtCuenta.Text;
                obj.FechaIngreso =  dtFecha.Value.Year.ToString() +"-"+ dtFecha.Value.Month.ToString().PadLeft(2, '0') +"-"+ dtFecha.Value.Day.ToString().PadLeft(2, '0');
                obj.FechaAltaIMSS = dtIMSS.Value.Year.ToString() + "-" + dtIMSS.Value.Month.ToString().PadLeft(2, '0') + "-" + dtIMSS.Value.Day.ToString().PadLeft(2, '0');
                obj.SueldoAprobado = decimal.Parse(txtSueldo.Text);
                obj.DatosUsuarios.IdUsuarioCreo = BaseWinBP.UsuarioLogueado.ID;
                #endregion





                //PROCESO DE GUARDADO Y ACTUALIZACION
                if (txtId.Text == "0") {
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
                LimpiarCampos();

            } catch (Exception ex) {

                RadMessageBox.Show("Ocurrio un error al limpiar los campos\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
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
                    CargarEmpleados();
                }
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al realiza la búsqueda\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }

        private void btnBuscarEMp_Click(object sender, EventArgs e)
        {
        

                int IdEmpleado = 0;
                try {
                    frmEmpleadosConsulta ofrm = new frmEmpleadosConsulta();
                    ofrm.WindowState = FormWindowState.Normal;
                    ofrm.StartPosition = FormStartPosition.CenterScreen;
                    ofrm.MaximizeBox = false;
                    ofrm.MinimizeBox = false;
                    ofrm.ShowDialog();
                IdEmpleado = ofrm.IdEmpleado;

                } catch (Exception ex) {
                    RadMessageBox.Show("Ocurrió un error al realiza la búsqueda\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
                    throw;
            }
        }

        private void radGroupBox1_Click(object sender, EventArgs e)
        {

        }

        private void rdbSi_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {

            if (rdbSi.IsChecked == true) {
                txtFonacot.Visible = true;
            } else
                txtFonacot.Visible = false;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            oCHumano = new WCF_CHumano.Hersan_CHumanoClient();
            try {
                if (txtId.Text != "0") {
                    if (RadMessageBox.Show("Desea dar de baja el empleado seleccionado...?", this.Text, MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.Yes) {
                        int Result = oCHumano.CHU_Empleados_Elimina(int.Parse(txtId.Text), BaseWinBP.UsuarioLogueado.ID);
                        if (Result != 0) {
                            RadMessageBox.Show("Empleado dado de baja  correctamente", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                        } else {
                            RadMessageBox.Show("Ocurrió un error al dar de baja el empleado", this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
                        }
                    }
                }
                LimpiarCampos();
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al dar de baja el empleado\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally {
                oCHumano = null;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            try {
                this.Close();

            } catch (Exception ex) {

                RadMessageBox.Show("Ocurió un errror al salir de la pantalla" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }

        private void documentWindow1_Click(object sender, EventArgs e)
        {

        }

        private void rdbNo_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {

        }

        private void rdbUi_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {

            if (rdbUi.IsChecked == true) {
                txtInfonavit.Visible = true; ;
                cboTipoF.Show();
                lblFona.Show();

            } else
                txtInfonavit.Visible = false; ;
                cboTipoF.Hide();
                lblFona.Hide();
        }
    }
}
