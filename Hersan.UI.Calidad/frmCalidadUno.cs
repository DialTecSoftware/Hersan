using Hersan.Entidades.Calidad;
using Hersan.Entidades.Inyeccion;
using Hersan.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace Hersan.UI.Calidad
{
    public partial class frmCalidadUno : Telerik.WinControls.UI.RadForm
    {
        WCF_Ensamble.Hersan_EnsambleClient oEnsamble;
        private List<NormaBE> oNorma = new List<NormaBE>();

        public frmCalidadUno()
        {
            InitializeComponent();
        }
        private void frmCalidadUno_Load(object sender, EventArgs e)
        {
            try {
                this.WindowState = FormWindowState.Normal;
                this.StartPosition = FormStartPosition.CenterScreen;
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al cargar la pantalla\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void txtLista_KeyPress(object sender, KeyPressEventArgs e)
        {
            try {
                if (!BaseWinBP.isNumero(e.KeyChar))
                    e.Handled = true;
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al capturar el dato\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void txtLista_KeyDown(object sender, KeyEventArgs e)
        {
            try {
                if (e.KeyData == Keys.Enter || (e.KeyCode == Keys.F3)) {
                    CargarDatos();
                }
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error en la captura\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void Control_KeyUp(object sender, KeyEventArgs e)
        {
            try {
                if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return)) {
                    ValidarNorma(sender);                    
                }
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error en la captura\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try {
                Limpiar(false);
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al limpiar los datos\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            oEnsamble = new WCF_Ensamble.Hersan_EnsambleClient();
            int Result = 0;
            bool bFlag = false;
            try {
                CalidadBE Obj = new CalidadBE();
                Obj.Lista = int.Parse(txtLista.Text);
                Obj.Inyeccion.Id = int.Parse(txtId.Text);
                Obj.Operador = txtOperador.Text;
                Obj.IdUsuario = BaseWinBP.UsuarioLogueado.ID;


                if (int.Parse(txtIdDetalle.Text) == 0)
                    Result = oEnsamble.CAL_InspeccionInyeccion_Guarda(Obj, ObtenerDetalle());
                else {
                    Result = oEnsamble.CAL_InspeccionInyeccion_Actualiza(int.Parse(txtIdDetalle.Text), ObtenerDetalle());
                    bFlag = true;
                }

                if (Result == 0) {
                    RadMessageBox.Show("Ocurrió un error al guardar la informacion", this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
                } else {
                    RadMessageBox.Show("Información guardada correctamente", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                    Limpiar(true);
                    txtLista.Focus();
                    if (bFlag)
                        txtMuestra.Text = Result.ToString();
                    else 
                        CargarDatos();
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

        private void CargarDatos()
        {
            oEnsamble = new WCF_Ensamble.Hersan_EnsambleClient();
            try {
                if (txtLista.Text.Trim().Length > 0) {
                    InyeccionBE Obj = oEnsamble.PRO_Inyeccion_Consulta(int.Parse(txtLista.Text));
                    if (Obj != null) {
                        txtId.Text = Obj.Id.ToString();
                        txtIdDetalle.Text = Obj.Detalle.Id.ToString();
                        txtOp.Text = Obj.OP;
                        txtOperador.Text = Obj.Operador;
                        txtColor.Text = Obj.Color.Nombre;
                        txtFecha.Text = Obj.Detalle.Fecha.ToShortDateString();
                        txtReal.Text = Obj.Detalle.Piezas.ToString();
                        txtTurno.Text = Obj.Detalle.Turno;
                        txtVirgen.Text = Obj.Detalle.Virgen.ToString();
                        txtRemolido.Text = Obj.Detalle.Remolido.ToString();
                        txtMaster.Text = Obj.Detalle.Master.ToString();
                        txtMuestra.Text = Obj.Muestra.ToString();

                        #region CAVIDADES                         
                        txtCav1_1.Enabled = Obj.Detalle.Cav1;
                        txtCav1_2.Enabled = Obj.Detalle.Cav1;
                        txtCav2_1.Enabled = Obj.Detalle.Cav2;
                        txtCav2_2.Enabled = Obj.Detalle.Cav2;
                        txtCav3_1.Enabled = Obj.Detalle.Cav3;
                        txtCav3_2.Enabled = Obj.Detalle.Cav3;
                        txtCav4_1.Enabled = Obj.Detalle.Cav4;
                        txtCav4_2.Enabled = Obj.Detalle.Cav4;
                        txtCav5_1.Enabled = Obj.Detalle.Cav5;
                        txtCav5_2.Enabled = Obj.Detalle.Cav5;
                        txtCav6_1.Enabled = Obj.Detalle.Cav6;
                        txtCav6_2.Enabled = Obj.Detalle.Cav6;
                        txtCav7_1.Enabled = Obj.Detalle.Cav7;
                        txtCav7_2.Enabled = Obj.Detalle.Cav7;
                        txtCav8_1.Enabled = Obj.Detalle.Cav8;
                        txtCav8_2.Enabled = Obj.Detalle.Cav8;
                        #endregion

                        #region NORMA X CAVIDAD
                        oNorma.Add(Obj.Norma);
                        #endregion

                        SendKeys.Send("{TAB}");
                    } else {
                        RadMessageBox.Show("No existe información para la lista capturada", this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
                        Limpiar(false);
                    }
                }else
                    RadMessageBox.Show("El número de lista es incorrecto o no existe", this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } catch (Exception ex) {
                throw ex;
            } finally {
                oEnsamble = null;
            }
        }
        private DataTable ObtenerDetalle()
        {
            try {
                #region Tabla
                System.Data.DataTable oData = new System.Data.DataTable("Datos");
                oData.Columns.Add("IdInspeccion");
                oData.Columns.Add("CAV1_1");
                oData.Columns.Add("CAV1_2");
                oData.Columns.Add("CAV2_1");
                oData.Columns.Add("CAV2_2");
                oData.Columns.Add("CAV3_1");
                oData.Columns.Add("CAV3_2");
                oData.Columns.Add("CAV4_1");
                oData.Columns.Add("CAV4_2");
                oData.Columns.Add("CAV5_1");
                oData.Columns.Add("CAV5_2");
                oData.Columns.Add("CAV6_1");
                oData.Columns.Add("CAV6_2");
                oData.Columns.Add("CAV7_1");
                oData.Columns.Add("CAV7_2");
                oData.Columns.Add("CAV8_1");
                oData.Columns.Add("CAV8_2");

                System.Data.DataRow oRow = oData.NewRow();
                oRow["IdInspeccion"] = 0;
                oRow["CAV1_1"] = txtCav1_1.Text.Trim().Length == 0 ? 0 : int.Parse(txtCav1_1.Text);
                oRow["CAV1_2"] = txtCav1_2.Text.Trim().Length == 0 ? 0 : int.Parse(txtCav1_2.Text);
                oRow["CAV2_1"] = txtCav2_1.Text.Trim().Length == 0 ? 0 : int.Parse(txtCav2_1.Text);
                oRow["CAV2_2"] = txtCav2_2.Text.Trim().Length == 0 ? 0 : int.Parse(txtCav2_2.Text);
                oRow["CAV3_1"] = txtCav3_1.Text.Trim().Length == 0 ? 0 : int.Parse(txtCav3_1.Text);
                oRow["CAV3_2"] = txtCav3_2.Text.Trim().Length == 0 ? 0 : int.Parse(txtCav3_2.Text);
                oRow["CAV4_1"] = txtCav4_1.Text.Trim().Length == 0 ? 0 : int.Parse(txtCav4_1.Text);
                oRow["CAV4_2"] = txtCav4_2.Text.Trim().Length == 0 ? 0 : int.Parse(txtCav4_2.Text);
                oRow["CAV5_1"] = txtCav5_1.Text.Trim().Length == 0 ? 0 : int.Parse(txtCav5_1.Text);
                oRow["CAV5_2"] = txtCav5_2.Text.Trim().Length == 0 ? 0 : int.Parse(txtCav5_2.Text);
                oRow["CAV6_1"] = txtCav6_1.Text.Trim().Length == 0 ? 0 : int.Parse(txtCav6_1.Text);
                oRow["CAV6_2"] = txtCav6_2.Text.Trim().Length == 0 ? 0 : int.Parse(txtCav6_2.Text);
                oRow["CAV7_1"] = txtCav7_1.Text.Trim().Length == 0 ? 0 : int.Parse(txtCav7_1.Text);
                oRow["CAV7_2"] = txtCav7_2.Text.Trim().Length == 0 ? 0 : int.Parse(txtCav7_2.Text);
                oRow["CAV8_1"] = txtCav8_1.Text.Trim().Length == 0 ? 0 : int.Parse(txtCav8_1.Text);
                oRow["CAV8_2"] = txtCav8_2.Text.Trim().Length == 0 ? 0 : int.Parse(txtCav8_2.Text);

                oData.Rows.Add(oRow);
                #endregion

                return oData;
            } catch (Exception ex) {
                throw ex;
            }
            
        }
        private void Limpiar(bool Detalle)
        {

            if (!Detalle) {
                txtId.Clear();
                txtColor.Clear();
                txtFecha.Clear();
                txtId.Clear();
                txtIdDetalle.Clear();
                txtLista.Clear();
                txtMaster.Clear();
                txtMuestra.Clear();
                txtOp.Clear();
                txtOperador.Clear();
                txtReal.Clear();
                txtRemolido.Clear();
                txtTurno.Clear();
                txtVirgen.Clear();
                Detalle = true;

                #region SE DESHABILITAN LAS CAVIDADES
                foreach (Control ctrl in pnlCaptura.Controls) {
                    if (ctrl is Telerik.WinControls.UI.RadTextBox) {
                        if (ctrl.Name.Contains("txtCav")) {
                            ctrl.Enabled = false;
                        }
                    }
                }               
                #endregion
            }
            if (Detalle) {
                foreach (Control ctrl in pnlCaptura.Controls) {
                    if (ctrl is Telerik.WinControls.UI.RadTextBox) {
                        if (ctrl.Name.Contains("txtCav")) {
                            ctrl.Text = "";
                            ctrl.BackColor = Color.White;
                        }
                    }
                }
            }
        }
        private void ValidarNorma(Object sender)
        {
            try {
                Control ctrl = (Telerik.WinControls.UI.RadTextBox)sender;
                if (ctrl.Text.Trim().Length > 0) {
                    switch (ctrl.Tag) {
                        case "Cav1":
                            if (decimal.Parse(ctrl.Text) < oNorma[0].Cav1) {
                                ctrl.BackColor = Color.Red;
                                RadMessageBox.Show("El reflejante capturado no cumple con la Norma", this.Text, MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                            }
                            break;
                        case "Cav2":
                            if (decimal.Parse(ctrl.Text) < oNorma[0].Cav2) {
                                ctrl.BackColor = Color.Red;
                                RadMessageBox.Show("El reflejante capturado no cumple con la Norma", this.Text, MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                            }
                            break;
                        case "Cav3":
                            if (decimal.Parse(ctrl.Text) < oNorma[0].Cav3) {
                                ctrl.BackColor = Color.Red;
                                RadMessageBox.Show("El reflejante capturado no cumple con la Norma", this.Text, MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                            }
                            break;
                        case "Cav4":
                            if (decimal.Parse(ctrl.Text) < oNorma[0].Cav4) {
                                ctrl.BackColor = Color.Red;
                                RadMessageBox.Show("El reflejante capturado no cumple con la Norma", this.Text, MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                            }
                            break;
                        case "Cav5":
                            if (decimal.Parse(ctrl.Text) < oNorma[0].Cav5) {
                                ctrl.BackColor = Color.Red;
                                RadMessageBox.Show("El reflejante no capturado cumple con la Norma", this.Text, MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                            }
                            break;
                        case "Cav6":
                            if (decimal.Parse(ctrl.Text) < oNorma[0].Cav6) {
                                ctrl.BackColor = Color.Red;
                                RadMessageBox.Show("El reflejante no capturado cumple con la Norma", this.Text, MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                            }
                            break;
                        case "Cav7":
                            if (decimal.Parse(ctrl.Text) < oNorma[0].Cav7) {
                                ctrl.BackColor = Color.Red;
                                RadMessageBox.Show("El reflejante no capturado cumple con la Norma", this.Text, MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                            }
                            break;
                        case "Cav8":
                            if (decimal.Parse(ctrl.Text) < oNorma[0].Cav8) {
                                ctrl.BackColor = Color.Red;
                                RadMessageBox.Show("El reflejante no capturado cumple con la Norma", this.Text, MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                            }
                            break;
                    }
                    SendKeys.Send("{TAB}");
                }
            } catch (Exception ex) {
                throw ex;
            }
        }
       
    }
}
