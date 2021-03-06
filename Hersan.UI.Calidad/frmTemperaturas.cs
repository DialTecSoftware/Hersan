﻿using Hersan.Entidades.Inyeccion;
using Hersan.Negocio;
using System;
using System.Windows.Forms;
using Telerik.WinControls;

namespace Hersan.UI.Calidad
{
    public partial class frmTemperaturas : Telerik.WinControls.UI.RadForm
    {
        WCF_Ensamble.Hersan_EnsambleClient oEnsamble;

        public frmTemperaturas()
        {
            InitializeComponent();
        }
        private void frmTemperaturas_Load(object sender, EventArgs e)
        {
            try {
                this.WindowState = FormWindowState.Normal;
                this.StartPosition = FormStartPosition.CenterScreen;

                Iniciales();
                CargaDatos();
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al cargar la pantalla\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void Decimal_KeyPress(object sender, KeyPressEventArgs e)
        {
            try {
                if (BaseWinBP.isDecimal(e.KeyChar))
                    e.Handled = true;
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al capturar el dato\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
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
        private void btnSave_Click(object sender, EventArgs e)
        {
            oEnsamble = new WCF_Ensamble.Hersan_EnsambleClient();
            try {

                if (RadMessageBox.Show("Desea guardar los datos...?", this.Text, MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.Yes) {

                    TemperaturasBE Obj = new TemperaturasBE();
                    Obj.Cav1 = txtCav1.Text.Trim().Length > 0 ? decimal.Parse(txtCav1.Text) : 0;
                    Obj.Cav2 = txtCav2.Text.Trim().Length > 0 ? decimal.Parse(txtCav2.Text) : 0;
                    Obj.Cav3 = txtCav3.Text.Trim().Length > 0 ? decimal.Parse(txtCav3.Text) : 0;
                    Obj.Cav4 = txtCav4.Text.Trim().Length > 0 ? decimal.Parse(txtCav4.Text) : 0;
                    Obj.Cav5 = txtCav5.Text.Trim().Length > 0 ? decimal.Parse(txtCav5.Text) : 0;
                    Obj.Cav6 = txtCav6.Text.Trim().Length > 0 ? decimal.Parse(txtCav6.Text) : 0;
                    Obj.Cav7 = txtCav7.Text.Trim().Length > 0 ? decimal.Parse(txtCav7.Text) : 0;
                    Obj.Cav8 = txtCav8.Text.Trim().Length > 0 ? decimal.Parse(txtCav8.Text) : 0;
                    Obj.Cav9 = txtCav9.Text.Trim().Length > 0 ? decimal.Parse(txtCav9.Text) : 0;
                    Obj.Cav10 = txtCav10.Text.Trim().Length > 0 ? decimal.Parse(txtCav10.Text) : 0;
                    Obj.Cav11 = txtCav11.Text.Trim().Length > 0 ? decimal.Parse(txtCav11.Text) : 0;
                    Obj.Cav12 = txtCav12.Text.Trim().Length > 0 ? decimal.Parse(txtCav12.Text) : 0;
                    Obj.Observa = txtObserva.Text;
                    Obj.IdUsuario = BaseWinBP.UsuarioLogueado.ID;

                    int Result = oEnsamble.PRO_Temperaturas_Guardar(Obj);
                    if (Result == 0) {
                        RadMessageBox.Show("Ocurrió un error al guardar la informacion", this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
                    } else {
                        RadMessageBox.Show("Información guardada correctamente", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                    }
                }
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al guardar los datos\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally {
                oEnsamble = null;
            }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            oEnsamble = new WCF_Ensamble.Hersan_EnsambleClient();
            try {
                if (RadMessageBox.Show("Desea guardar los datos...?", this.Text, MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.Yes) {

                    TempMoldesBE Obj = new TempMoldesBE();
                    Obj.Fija = txtFija.Text.Trim().Length > 0 ? decimal.Parse(txtFija.Text) : 0;
                    Obj.Movil = txtMovil.Text.Trim().Length > 0 ? decimal.Parse(txtMovil.Text) : 0;
                    Obj.IdUsuario = BaseWinBP.UsuarioLogueado.ID;

                    int Result = oEnsamble.PRO_TemperaturasMolde_Guardar(Obj);
                    if (Result == 0) {
                        RadMessageBox.Show("Ocurrió un error al guardar la informacion", this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
                    } else {
                        RadMessageBox.Show("Información guardada correctamente", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                    }
                }
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al guardar los datos\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally {
                oEnsamble = null;
            }
        }
        private void Contol_KeyDown(object sender, KeyEventArgs e)
        {
            try {
                if (e.KeyData == Keys.Enter) {
                    SendKeys.Send("{TAB}");
                }
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error en la captura\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }


        private void Iniciales()
        {
            try {
                foreach (Control ctrl in this.radGroupBox1.Controls) {
                    if (ctrl is Telerik.WinControls.UI.RadTextBox) {
                        ctrl.Text = "";
                    }
                }                
                txtFija.Clear();
                txtMovil.Clear();
            } catch (Exception ex) {
                throw ex;
            }
        }
        private void CargaDatos()
        {
            oEnsamble = new WCF_Ensamble.Hersan_EnsambleClient();
            try {
                TemperaturasBE Obj = oEnsamble.PRO_Temperaturas_Obtener();
                if(Obj != null) {
                    txtCav1.Text = decimal.Parse(Obj.Cav1.ToString()) == 0 ? "" : Obj.Cav1.ToString();
                    txtCav2.Text = decimal.Parse(Obj.Cav2.ToString()) == 0 ? "" : Obj.Cav2.ToString();
                    txtCav3.Text = decimal.Parse(Obj.Cav3.ToString()) == 0 ? "" : Obj.Cav3.ToString();
                    txtCav4.Text = decimal.Parse(Obj.Cav4.ToString()) == 0 ? "" : Obj.Cav4.ToString();
                    txtCav5.Text = decimal.Parse(Obj.Cav5.ToString()) == 0 ? "" : Obj.Cav5.ToString();
                    txtCav6.Text = decimal.Parse(Obj.Cav6.ToString()) == 0 ? "" : Obj.Cav6.ToString();
                    txtCav7.Text = decimal.Parse(Obj.Cav7.ToString()) == 0 ? "" : Obj.Cav7.ToString();
                    txtCav8.Text = decimal.Parse(Obj.Cav8.ToString()) == 0 ? "" : Obj.Cav8.ToString();
                    txtCav9.Text = decimal.Parse(Obj.Cav9.ToString()) == 0 ? "" : Obj.Cav9.ToString();
                    txtCav10.Text = decimal.Parse(Obj.Cav10.ToString()) == 0 ? "" : Obj.Cav10.ToString();
                    txtCav11.Text = decimal.Parse(Obj.Cav11.ToString()) == 0 ? "" : Obj.Cav11.ToString();
                    txtCav12.Text = decimal.Parse(Obj.Cav12.ToString()) == 0 ? "" : Obj.Cav12.ToString();
                    txtObserva.Text = Obj.Observa;
                }

                TempMoldesBE aux = oEnsamble.PRO_TemperaturasMolde_Obtener();
                if(aux != null) {
                    txtFija.Text = decimal.Parse(aux.Fija.ToString()) == 0 ? "" : aux.Fija.ToString();
                    txtMovil.Text = decimal.Parse(aux.Movil.ToString()) == 0 ? "" : aux.Movil.ToString();
                } 
            } catch (Exception ex) {
                throw ex;
            } finally {
                oEnsamble = null;
            }
        }

    }
}
