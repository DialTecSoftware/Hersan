using Hersan.Entidades.Calidad;
using Hersan.Entidades.Inyeccion;
using Hersan.Negocio;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Telerik.WinControls;

namespace Hersan.UI.Calidad
{
    public partial class frmCalidadAnalisis : Telerik.WinControls.UI.RadForm
    {
        WCF_Ensamble.Hersan_EnsambleClient oEnsamble;
        WCF_Catalogos.Hersan_CatalogosClient oCatalogos;
        List<InyeccionBE> oList;
        List<CalidadDetalleBE> oDetalle;

        public frmCalidadAnalisis()
        {
            InitializeComponent();
        }
        private void frmCalidadAnalisis_Load(object sender, EventArgs e)
        {
            try {
                dtInicial.Value = DateTime.Today;
                dtInicial.Checked = false;
                dtFinal.Enabled = dtInicial.Checked;

                dtHInicial.Value = DateTime.Now.ToLocalTime();
                dtHInicial.Checked = false;
                dtHFinal.Enabled = dtInicial.Checked;

                CargarColores();
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al cargar la pantalla\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            oEnsamble = new WCF_Ensamble.Hersan_EnsambleClient();

            try {
                CalidadBE Obj = new CalidadBE();
                Obj.Inyeccion.OP = txtOp.Text;
                Obj.Inyeccion.Color.Nombre = cboColores.SelectedValue.ToString();
                Obj.Inyeccion.Detalle.Lista = txtLista.Text;
                Obj.Inyeccion.Detalle.Turno = txtTurno.Text;
                Obj.Operador = txtOperador.Text;
                Obj.Inyeccion.Fecha = DateTime.Parse(dtInicial.Checked ? dtInicial.Value.Year.ToString() + "/" + dtInicial.Value.Month.ToString().PadLeft(2, '0')
                    + "/" + dtInicial.Value.Day.ToString().PadLeft(2, '0') : "1900/01/01");
                Obj.Inyeccion.Detalle.Fecha = DateTime.Parse(dtInicial.Checked ? dtFinal.Value.Year.ToString() + "/" + dtFinal.Value.Month.ToString().PadLeft(2, '0')
                    + "/" + dtFinal.Value.Day.ToString().PadLeft(2, '0') : "2900/01/01");
                Obj.Inyeccion.Detalle.Inicio = TimeSpan.Parse(dtHInicial.Checked ? dtHInicial.Value.ToString() : "00:00:00");
                Obj.Inyeccion.Detalle.Fin = TimeSpan.Parse(dtHInicial.Checked ? dtHFinal.Value.ToString() : "23:59:00");

                oList = oEnsamble.CAL_InspeccionInyeccion_Analisis(Obj);
                if (oList.Count > 0)
                    gvDatos.DataSource = oList;
                else {
                    gvDatos.DataSource = null;
                    gvDetalle.DataSource = null;
                    gvResumen.DataSource = null; ;
                    RadMessageBox.Show("No existe información con los criterios seleccionados", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                }
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al obtener la información\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally {
                oEnsamble = null;
            }
        }
        private void btnGrafica1_Click(object sender, EventArgs e)
        {
            try {
                if (gvDetalle.RowCount > 0) {
                    frmHistograma frm = new frmHistograma();
                    frm.Lista = int.Parse(gvDatos.CurrentRow.Cells["Lista"].Value.ToString());
                    frm.Resumen = oDetalle.Count > 0 ? oDetalle[0].Resumen : null;
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    //frm.WindowState = FormWindowState.Maximized;
                    frm.ShowDialog();
                } else {
                    RadMessageBox.Show("No existen datos a graficar", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                }
            } catch (Exception ex) {
                throw ex;
            }
        }
        private void btnGrafica2_Click(object sender, EventArgs e)
        {
            try {
                if (gvDetalle.RowCount > 0) {
                    frmGraficaControl frm = new frmGraficaControl();
                    frm.Lista = int.Parse(gvDatos.CurrentRow.Cells["Lista"].Value.ToString());
                    frm.Resumen = oDetalle.Count > 0 ? oDetalle[0].Resumen : null;
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.ShowDialog();
                } else {
                    RadMessageBox.Show("No existen datos a graficar", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                }
            } catch (Exception ex) {
                throw ex;
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
        private void txtLista_KeyPress(object sender, KeyPressEventArgs e)
        {
            try {
                if (!BaseWinBP.isNumero(e.KeyChar)) {
                    e.Handled = true;
                }
            } catch (Exception ex) {
                throw ex;
            }
        }
        private void dtInicial_CheckedChanged(object sender, EventArgs e)
        {
            try {
                dtFinal.Enabled = dtInicial.Checked;
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al seleccionar la fecha\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void dtInicial_ValueChanged(object sender, EventArgs e)
        {
            try {
                dtFinal.MinDate = dtInicial.Value;
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al cambiar la fecha\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void dtHInicial_CheckedChanged(object sender, EventArgs e)
        {
            try {
                dtHFinal.Enabled = dtHInicial.Checked;
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al seleccionar la hora\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void dtHInicial_ValueChanged(object sender, EventArgs e)
        {
            try {
                dtHFinal.MinDate = dtHInicial.Value;
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al cambiar la hora\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void gvDatos_CurrentRowChanged(object sender, Telerik.WinControls.UI.CurrentRowChangedEventArgs e)
        {
            oEnsamble = new WCF_Ensamble.Hersan_EnsambleClient();
            try {
                gvDetalle.DataSource = null;
                gvResumen.DataSource = null;

                if (gvDatos.RowCount > 0) {
                    oDetalle = oEnsamble.CAL_InspeccionInyeccion_AnalisisDetalle(int.Parse(gvDatos.CurrentRow.Cells["Lista"].Value.ToString()));
                    gvDetalle.DataSource = oDetalle;
                    gvResumen.DataSource = oDetalle.Count > 0 ? oDetalle[0].Resumen : null;
                }
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al seleccionar la lista\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally {
                oEnsamble = null;
            }
        }

        private void CargarColores()
        {
            oCatalogos = new WCF_Catalogos.Hersan_CatalogosClient();
            try {
                cboColores.DisplayMember = "Nombre";
                cboColores.ValueMember = "Nombre";
                cboColores.DataSource = oCatalogos.ABC_Colores_Combo();
            } catch (Exception ex) {
                throw ex;
            } finally {
                oCatalogos = null;
            }
        }

    }
}
