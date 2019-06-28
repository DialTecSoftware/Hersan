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
        bool Flag;

        public frmCalidadUno()
        {
            InitializeComponent();
        }
        private void frmCalidadUno_Load(object sender, EventArgs e)
        {
            try {
                this.WindowState = FormWindowState.Normal;
                this.StartPosition = FormStartPosition.CenterScreen;
                Flag = true;
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
                if (e.KeyData == Keys.Enter || e.KeyData == Keys.F3) {
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
                    SendKeys.Send("{TAB}");
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
            try {

                if (RadMessageBox.Show("Desea guardar los datos...?", this.Text, MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.Yes) {

                    CalidadBE Obj = new CalidadBE();
                    Obj.Lista = int.Parse(txtLista.Text);
                    Obj.Inyeccion.Id = int.Parse(txtId.Text);
                    Obj.Operador = txtOperador.Text;
                    Obj.IdUsuario = BaseWinBP.UsuarioLogueado.ID;
                    Obj.Flag = Flag;

                    int Result = oEnsamble.CAL_InspeccionInyeccion_Guarda(Obj, ObtenerDetalle());
                    if (Result == 0) {
                        RadMessageBox.Show("Ocurrió un error al guardar la informacion", this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
                    } else {
                        RadMessageBox.Show("Información guardada correctamente", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                        Limpiar(true);
                        txtLista.Focus();
                        Flag = false;
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


        private void CargarDatos()
        {
            oEnsamble = new WCF_Ensamble.Hersan_EnsambleClient();
            try {
                if (txtLista.Text.Trim().Length > 0) {
                    InyeccionBE Obj = oEnsamble.PRO_Inyeccion_Consulta(int.Parse(txtLista.Text));
                    if(Obj != null) {
                        txtId.Text = Obj.Id.ToString();
                        txtOp.Text = Obj.OP;
                        txtColor.Text = Obj.Color.Nombre;
                        txtFecha.Text = Obj.Detalle.Fecha.ToShortDateString();
                        txtReal.Text = Obj.Detalle.Real.ToString();
                        txtTurno.Text = Obj.Detalle.Turno;
                        txtVirgen.Text = Obj.Detalle.Virgen.ToString();
                        txtRemolido.Text = Obj.Detalle.Remolido.ToString();
                        txtMaster.Text = Obj.Detalle.Master.ToString();

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

                        SendKeys.Send("{TAB}");
                    } else 
                        RadMessageBox.Show("No existe información para la lista capturada", this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
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
            foreach (Control ctrl in this.Controls) {
                if (ctrl is Telerik.WinControls.UI.RadTextBox) {
                    if (Detalle) {
                        if (ctrl.Name.Contains("txtCav"))
                            ctrl.Text = "0.00";
                    } else {
                        ctrl.Text = string.Empty;
                    }

                }
            }
        }

        private void txtOperador_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
