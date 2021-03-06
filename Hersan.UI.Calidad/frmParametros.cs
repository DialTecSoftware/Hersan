﻿using Hersan.Entidades.Inyeccion;
using Hersan.Negocio;
using System;
using System.Windows.Forms;
using Telerik.WinControls;

namespace Hersan.UI.Calidad
{
    public partial class frmParametros : Telerik.WinControls.UI.RadForm
    {
        WCF_Ensamble.Hersan_EnsambleClient oEnsamble;

        public frmParametros()
        {
            InitializeComponent();
        }
        private void frmParametros_Load(object sender, EventArgs e)
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
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            oEnsamble = new WCF_Ensamble.Hersan_EnsambleClient();
            try {

                if (RadMessageBox.Show("Desea guardar los datos...?", this.Text, MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.Yes) {

                    #region Tabla
                    System.Data.DataTable oData = new System.Data.DataTable("Datos");
                    oData.Columns.Add("Presion1");
                    oData.Columns.Add("Presion2");
                    oData.Columns.Add("Presion3");
                    oData.Columns.Add("Velocidad1");
                    oData.Columns.Add("Velocidad2");
                    oData.Columns.Add("Velocidad3");
                    oData.Columns.Add("PosicionC1");
                    oData.Columns.Add("PosicionC2");
                    oData.Columns.Add("PresionC1");
                    oData.Columns.Add("PresionC2");
                    oData.Columns.Add("VelocidadC1");
                    oData.Columns.Add("VelocidadC2");
                    oData.Columns.Add("Posicion");
                    oData.Columns.Add("Presion");
                    oData.Columns.Add("Velocidad");
                    oData.Columns.Add("Retardo");
                    oData.Columns.Add("Zona1");
                    oData.Columns.Add("Zona2");
                    oData.Columns.Add("Zona3");
                    oData.Columns.Add("Zona4");
                    oData.Columns.Add("Observa");
                    oData.Columns.Add("Cavidades");
                    oData.Columns.Add("IdUsuario");

                    System.Data.DataRow oRow = oData.NewRow();
                    oRow["Presion1"] = txtPresion1.Text.Trim().Length != 0 ? decimal.Parse(txtPresion1.Text) : 0;
                    oRow["Presion2"] = txtPresion2.Text.Trim().Length != 0 ? decimal.Parse(txtPresion2.Text) : 0;
                    oRow["Presion3"] = txtPresion3.Text.Trim().Length != 0 ? decimal.Parse(txtPresion3.Text) : 0;
                    oRow["Velocidad1"] = txtVelocidad1.Text.Trim().Length != 0 ? decimal.Parse(txtVelocidad1.Text) : 0;
                    oRow["Velocidad2"] = txtVelocidad2.Text.Trim().Length != 0 ? decimal.Parse(txtVelocidad2.Text) : 0;
                    oRow["Velocidad3"] = txtVelocidad3.Text.Trim().Length != 0 ? decimal.Parse(txtVelocidad3.Text) : 0;
                    oRow["PosicionC1"] = txtPosicionC1.Text.Trim().Length != 0 ? decimal.Parse(txtPosicionC1.Text) : 0;
                    oRow["PosicionC2"] = txtPosicionC2.Text.Trim().Length != 0 ? decimal.Parse(txtPosicionC2.Text) : 0;
                    oRow["PresionC1"] = txtPosicionC1.Text.Trim().Length != 0 ? decimal.Parse(txtPresionC1.Text) : 0;
                    oRow["PresionC2"] = txtPosicionC2.Text.Trim().Length != 0 ? decimal.Parse(txtPresionC2.Text) : 0;
                    oRow["VelocidadC1"] = txtVelocidadC1.Text.Trim().Length != 0 ? decimal.Parse(txtVelocidadC1.Text) : 0;
                    oRow["VelocidadC2"] = txtVelocidadC2.Text.Trim().Length != 0 ? decimal.Parse(txtVelocidadC2.Text) : 0;
                    oRow["Posicion"] = txtPosicion.Text.Trim().Length != 0 ? txtPosicion.Text : "";
                    oRow["Presion"] = 0;
                    oRow["Velocidad"] = txtVelocidad.Text.Trim().Length != 0 ? decimal.Parse(txtVelocidad.Text) : 0;
                    oRow["Retardo"] = txtRetardo.Text.Trim().Length != 0 ? decimal.Parse(txtRetardo.Text) : 0;
                    oRow["Zona1"] = txtZona1.Text.Trim().Length != 0 ? decimal.Parse(txtZona1.Text) : 0;
                    oRow["Zona2"] = txtZona2.Text.Trim().Length != 0 ? decimal.Parse(txtZona2.Text) : 0;
                    oRow["Zona3"] = txtZona3.Text.Trim().Length != 0 ? decimal.Parse(txtZona3.Text) : 0;
                    oRow["Zona4"] = txtZona4.Text.Trim().Length != 0 ? decimal.Parse(txtZona4.Text) : 0;
                    oRow["Observa"] = txtObserva.Text;
                    oRow["Cavidades"] = txtCavidades.Text;
                    oRow["IdUsuario"] = BaseWinBP.UsuarioLogueado.ID;

                    oData.Rows.Add(oRow);
                    #endregion

                    if (oEnsamble.PRO_Parametros_Guardar(oData) == 0) {
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
        private void btnSalir_Click(object sender, EventArgs e)
        {
            try {
                this.Close();
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al cerrar la pantalla\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
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
        private void Control_KeyDown(object sender, KeyEventArgs e)
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
                foreach (Control ctrl in this.Controls) {
                    if (ctrl is Telerik.WinControls.UI.RadTextBox) {
                        ctrl.Text = "";
                    }
                }
            } catch (Exception ex) {
                throw ex;
            }
        }
        private void CargaDatos()
        {
            oEnsamble = new WCF_Ensamble.Hersan_EnsambleClient();
            try {
                ParametrosInyeccion Obj = oEnsamble.PRO_Parametros_Obtener();
                if (Obj != null) {
                    txtPresion1.Text = decimal.Parse(Obj.Presion1.ToString()) == 0 ? "" : Obj.Presion1.ToString();
                    txtPresion2.Text = decimal.Parse(Obj.Presion2.ToString()) == 0 ? "" : Obj.Presion2.ToString();
                    txtPresion3.Text = decimal.Parse(Obj.Presion3.ToString()) == 0 ? "" : Obj.Presion3.ToString();
                    txtVelocidad1.Text = decimal.Parse(Obj.Velocidad1.ToString()) == 0 ? "" : Obj.Velocidad1.ToString();
                    txtVelocidad2.Text = decimal.Parse(Obj.Velocidad2.ToString()) == 0 ? "" : Obj.Velocidad2.ToString();
                    txtVelocidad3.Text = decimal.Parse(Obj.Velocidad3.ToString()) == 0 ? "" : Obj.Velocidad3.ToString();
                    txtPosicionC1.Text = decimal.Parse(Obj.PosicionC1.ToString()) == 0 ? "" : Obj.PosicionC1.ToString();
                    txtPosicionC2.Text = decimal.Parse(Obj.PosicionC2.ToString()) == 0 ? "" : Obj.PosicionC2.ToString();
                    txtPresionC1.Text = decimal.Parse(Obj.PresionC1.ToString()) == 0 ? "" : Obj.PresionC1.ToString();
                    txtPresionC2.Text = decimal.Parse(Obj.PresionC2.ToString()) == 0 ? "" : Obj.PresionC2.ToString();
                    txtVelocidadC1.Text = decimal.Parse(Obj.VelocidadC1.ToString()) == 0 ? "" : Obj.VelocidadC1.ToString();
                    txtVelocidadC2.Text = decimal.Parse(Obj.VelocidadC2.ToString()) == 0 ? "" : Obj.VelocidadC2.ToString();
                    txtPosicion.Text = Obj.Posicion.ToString();
                    //txtPresion.Text = Obj.Presion.ToString();
                    txtVelocidad.Text = decimal.Parse(Obj.Velocidad.ToString()) == 0 ? "" : Obj.Velocidad.ToString();
                    txtRetardo.Text = decimal.Parse(Obj.Retardo.ToString()) == 0 ? "" : Obj.Retardo.ToString();
                    txtZona1.Text = decimal.Parse(Obj.Zona1.ToString()) == 0 ? "" : Obj.Zona1.ToString();
                    txtZona2.Text = decimal.Parse(Obj.Zona2.ToString()) == 0 ? "" : Obj.Zona2.ToString();
                    txtZona3.Text = decimal.Parse(Obj.Zona3.ToString()) == 0 ? "" : Obj.Zona3.ToString();
                    txtZona4.Text = decimal.Parse(Obj.Zona4.ToString()) == 0 ? "" : Obj.Zona4.ToString();
                    txtObserva.Text = Obj.Observa.ToString();
                    txtCavidades.Text = Obj.Cavidades.ToString();
                }
            } catch (Exception ex) {
                throw ex;
            } finally {
                oEnsamble = null;
            }
        }

        
    }
}
