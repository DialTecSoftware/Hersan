using Hersan.Entidades.Calidad;
using Hersan.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace Hersan.UI.Calidad
{
    public partial class frmCalidadDos : Telerik.WinControls.UI.RadForm
    {
        WCF_Ensamble.Hersan_EnsambleClient oEnsamble;
        List<CalidadEnsambleDetalleBE> oList = new List<CalidadEnsambleDetalleBE>();

        public frmCalidadDos()
        {
            InitializeComponent();
        }
        private void frmCalidadDos_Load(object sender, EventArgs e)
        {
            try {
               
            } catch (Exception ex) {
                throw ex;
            }
        }
        private void txtLista_KeyPress(object sender, KeyPressEventArgs e)
        {
            try {
                if (!BaseWinBP.isNumero(e.KeyChar)) {
                    e.Handled = true;
                }
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al capturar la lista\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void txtLista_KeyDown(object sender, KeyEventArgs e)
        {
            try {
                if (e.KeyData == Keys.Enter) {
                    CargaDatos();
                    SendKeys.Send("{TAB}");
                }
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error en la captura\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void txtLista_Leave(object sender, EventArgs e)
        {
            try {
                CargaDatos();
                SendKeys.Send("{TAB}");
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error en la captura\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try {
                LimpiarCampos();
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al limpiar los campos\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            oEnsamble = new WCF_Ensamble.Hersan_EnsambleClient();
            try {
                CalidadEnsambleBE Obj = new CalidadEnsambleBE();
                Obj.Id = int.Parse(txtIdInspeccion.Text);
                Obj.Parametros.Id = int.Parse(txtId.Text);
                Obj.Operador = txtOperador.Text;
                Obj.IdUsuario = BaseWinBP.UsuarioLogueado.ID;

                if (int.Parse(txtIdInspeccion.Text) == 0) {
                    int Result = oEnsamble.CAL_InspeccionEnsamble_Guardar(Obj, ObtenerDetalle());
                    if (Result  == 0) {
                        RadMessageBox.Show("Ocurrió un error al guardar la informacion", this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
                    } else {
                        RadMessageBox.Show("Información guardada correctamente", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                        txtIdInspeccion.Text = Result.ToString();
                        CargaDatos();
                    }
                } else {
                    int Result = oEnsamble.CAL_InspeccionEnsamble_Actualizar(Obj, ObtenerDetalle());
                    if (Result == 0) {
                        RadMessageBox.Show("Ocurrió un error al guardar la informacion", this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
                    } else {
                        RadMessageBox.Show("Información guardada correctamente", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                        CargaDatos();
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
        private void gvDatos_CellFormatting(object sender, Telerik.WinControls.UI.CellFormattingEventArgs e)
        {
            try {
                if (gvDatos.RowCount > 0) {
                    if (e.ColumnIndex > 4 && e.RowIndex != -1) {
                        if (int.Parse(e.CellElement.Value.ToString()) < int.Parse(txtNorma.Text)) {
                            e.CellElement.DrawFill = true;
                            e.CellElement.BackColor = Color.Red;
                        } else {
                            e.CellElement.ResetValue(LightVisualElement.DrawFillProperty, ValueResetFlags.Local);
                            e.CellElement.ResetValue(LightVisualElement.BackColorProperty, ValueResetFlags.Local);
                        }
                    }
                }
            } catch (Exception ex) {
                throw ex;
            }
        }
        private void gvDatos_CellBeginEdit(object sender, GridViewCellCancelEventArgs e)
        {
            //if (gvDatos.CurrentRow.Cells["Lote"].Value != null) {
            //    string x = gvDatos.CurrentRow.Cells["Lote"].Value.ToString();
            //    if (oList.Find(item => item.Lote.ToString() == x) != null) {
            //        RadMessageBox.Show("El lote capturado ya existe, no es posible agregar", this.Text, MessageBoxButtons.OK,RadMessageIcon.Exclamation);
            //        e.Cancel = true;
            //        SendKeys.Send("{ESC}");
            //    }
            //}
        }
        private void gvDatos_CellEndEdit(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try {
                if (e.ColumnIndex > 4) {
                    if (int.Parse(e.Value.ToString()) < int.Parse(txtNorma.Text)) {
                        RadMessageBox.Show("NO CUMPLE LOS VALORES LA NORMA",this.Text,MessageBoxButtons.OK,RadMessageIcon.Exclamation);
                    }
                }
            } catch (Exception ex) {
                throw ex;
            }
        }

        private void LimpiarCampos()
        {
            try {
                foreach (Control ctrl in this.Controls) {
                    if (ctrl is Telerik.WinControls.UI.RadTextBox) {
                        ctrl.Text = "";
                    }
                }
                txtId.Text = "0";
                gvDatos.DataSource = null;
                
            } catch (Exception ex) {
                throw ex;
            }
        }
        private void CargaDatos()
        {
            oEnsamble = new WCF_Ensamble.Hersan_EnsambleClient();
            try {
                if (txtLista.Text.Trim().Length != 0) {
                    List<CalidadEnsambleBE> Aux = oEnsamble.CAL_InspeccionEnsamble_Consultar(int.Parse(txtLista.Text));
                    if (Aux.Count > 0) {
                        txtId.Text = Aux[0].Parametros.Id.ToString();
                        txtIdInspeccion.Text = Aux[0].Id.ToString();
                        txtOperador.Text = Aux[0].Operador;
                        txtCarcasa.Text = Aux[0].Parametros.Carcasa.Nombre;                        
                        txtNorma.Text = Aux[0].Norma.ToString();
                        txtOp.Text = Aux[0].Parametros.OP;
                        txtProducto.Text = Aux[0].Parametros.Producto.Nombre;
                        txtReflex1.Text = Aux[0].Parametros.Reflex1.Nombre;
                        txtReflex2.Text = Aux[0].Parametros.Reflex2.Nombre;
                        txtMuestra.Text = Aux[0].Muestra.ToString();
                        txtPorc.Text = "5.00";

                        CargaGrid();
                    } else
                        RadMessageBox.Show("No existen datos con los criterios seleccionados", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                } else
                    RadMessageBox.Show("Error, no ha capturado la lista", this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } catch (Exception ex) {
                throw ex;
            }
        }
        private void CargaGrid()
        {
            oEnsamble = new WCF_Ensamble.Hersan_EnsambleClient();
            try {
                oList = oEnsamble.CAL_InspeccionEnsamble_Obtener(int.Parse(txtLista.Text));
                gvDatos.DataSource = oList;
            } catch (Exception ex) {
                throw ex;
            } finally {

            }
        }
        private DataTable ObtenerDetalle()
        {
            try {
                #region Tabla
                System.Data.DataTable oData = new System.Data.DataTable("Datos");
                oData.Columns.Add("Id");
                oData.Columns.Add("IdInspeccion");
                oData.Columns.Add("Lote");
                oData.Columns.Add("Maquina");
                oData.Columns.Add("Reflejante");
                oData.Columns.Add("Obs1");
                oData.Columns.Add("Obs2");
                oData.Columns.Add("Obs3");
                oData.Columns.Add("Obs4");
                oData.Columns.Add("Obs5");

                foreach (var item in oList ) {
                    System.Data.DataRow oRow = oData.NewRow();
                    oRow["Id"] = item.Id;
                    oRow["IdInspeccion"] = item.IdInspeccion;
                    oRow["Lote"] = item.Lote;
                    oRow["Maquina"] = item.Maquina;
                    oRow["Reflejante"] = item.Reflejante;
                    oRow["Obs1"] = item.Obs1;
                    oRow["Obs2"] = item.Obs2;
                    oRow["Obs3"] = item.Obs3;
                    oRow["Obs4"] = item.Obs4;
                    oRow["Obs5"] = item.Obs5;

                    oData.Rows.Add(oRow);
                }
                #endregion

                return oData;
            } catch (Exception ex) {
                throw ex;
            }

        }
       
    }
}
