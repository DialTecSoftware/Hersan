using Hersan.Entidades.CapitalHumano;
using Hersan.Negocio;
using System;
using System.Collections.Generic;
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
            txtFonacot.Text = "0";
            txtId.Text = "0";
            txtCuenta.Text ="0000-0000-0000-0000";
            txtIdExp.Text ="0";
            txtInfonavit.Text = "0";
            txtNombres.Text = string.Empty;
            txtNumEmp.Text = "0";
            txtcantidad.Text = "0";
            txtPension.Text = "0";
            txtSueldoDiario.Text = "0.00";
            txtSueldoIntegrado.Text = "0.00";
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
            try {
                if (BaseWinBP.isDecimal(e.KeyChar)) {
                    e.Handled = true;
                }
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrio un error al capturar la ponderación\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private bool ValidarCampos()
        {
            bool Flag = true;
            try {
               
            
                Flag = txtApellidos.Text.Trim().Length == 0 ? false : true;                      
                Flag = txtNombres.Text.Trim().Length == 0 ? false : true;
               


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
                        txtcantidad.Text = item[0].Ahorro.ToString();
                        txtCuenta.Text = item[0].NumeroCuenta;
                        txtSueldoDiario.Text = item[0].SueldoDiario.ToString();
                        txtSueldoIntegrado.Text = item[0].SueldoDiarioIntegrado.ToString();
                        if (item[0].Ahorro > 0) 
                        {
                            SiVoluntario.IsChecked = true;
                        }
                        txtFonacot.Text = item[0].Fonacot;
                        txtInfonavit.Text = item[0].Infonavit;
                
                        txtPension.Text = item[0].Pension.ToString();
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
                

                NoVoluntario.IsChecked = false;
                rdbNo.IsChecked = false;
                rdbNon.IsChecked = false;
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
                if ((rdbUi.IsChecked==true && txtInfonavit.Text=="") || (rdbSi.IsChecked==true && txtFonacot.Text=="") || (SiVoluntario.IsChecked==true && txtcantidad.Text == "")) {
                    RadMessageBox.Show("Al decir que sí existe el dato debe de capturarlo o selecciona No para cotinuar ", this.Text, MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                    return;
                }

                if (!ValidarCampos()) {
                    RadMessageBox.Show("Debe capturar todos los datos para continuar", this.Text, MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                    return;
                }
                if (oList.FindAll(item=> item.Numero== int.Parse(txtNumEmp.Text)).Count >0 ) 
                {
                    RadMessageBox.Show(" Ya existe un empleado con este numero\n Ingresa un ...", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                }

                
                #region Entidades
                obj.Numero = int.Parse(txtNumEmp.Text);
                obj.Expedientes.Id = int.Parse(txtIdExp.Text);
                obj.EstatusEmpleado = (cboEstatus.SelectedItem.Text);
                obj.TipoInfonavit = (cboTipoF.SelectedItem.Text);
                obj.Fonacot = txtFonacot.Text.Trim().Length==0 ? "0": txtFonacot.Text;
                obj.Infonavit= txtInfonavit.Text.Trim().Length == 0 ? "0" :txtInfonavit.Text;
                obj.NumeroCuenta = txtInfonavit.Text.Trim().Length == 0 ? "0" : txtCuenta.Text;
                obj.FechaIngreso =  dtFecha.Value.Year.ToString() +"-"+ dtFecha.Value.Month.ToString().PadLeft(2, '0') +"-"+ dtFecha.Value.Day.ToString().PadLeft(2, '0');
                obj.FechaAltaIMSS = dtIMSS.Value.Year.ToString() + "-" + dtIMSS.Value.Month.ToString().PadLeft(2, '0') + "-" + dtIMSS.Value.Day.ToString().PadLeft(2, '0');
                obj.Pension = txtPension.Text.Trim().Length == 0 ? 0: decimal.Parse(txtPension.Text);
                obj.Ahorro = txtcantidad.Text.Trim().Length==0? 0: decimal.Parse(txtcantidad.Text);
                obj.SueldoDiario = txtSueldoDiario.Text.Trim().Length ==0 ? 0: decimal.Parse(txtSueldoDiario.Text);
                obj.SueldoDiarioIntegrado = 0;
                obj.DatosUsuarios.IdUsuarioCreo = BaseWinBP.UsuarioLogueado.ID;
                #endregion



                if (RadMessageBox.Show("Desea guardar los datos capturados...?", this.Text, MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.Yes) {

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
                lblNumfona.Visible = true;
            } else
            if (rdbSi.IsChecked == false) {
                txtFonacot.Visible = false;
                lblNumfona.Visible = false;
            }
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
                lblinfonavit.Visible = true;

            } else
              if (rdbUi.IsChecked == false)
            {
                txtInfonavit.Visible = false; ;
                cboTipoF.Hide();
                lblFona.Hide();
                lblinfonavit.Visible = false;
            }
           

           
        }

        private void cboTipoF_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (cboTipoF.SelectedIndex == 0)
            {
                lblinfonavit.Text = "Cuota:";
            }
            else
            if (cboTipoF.SelectedIndex == 1)
            {
                lblinfonavit.Text = "Porc :";

            }
            else
            if (cboTipoF.SelectedIndex == 2) 
            {
                lblinfonavit.Text = "VSM :";
            }

        }

        private void SiVoluntario_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (SiVoluntario.IsChecked==true) 
            {
                lblcantidad.Visible = true;
                txtcantidad.Visible = true;
            }
            else
                if (SiVoluntario.IsChecked==false) {
                lblcantidad.Visible = false;
                txtcantidad.Visible = false;
            }
        }

        private void radGroupBox3_Click(object sender, EventArgs e)
        {

        }
    }
}
