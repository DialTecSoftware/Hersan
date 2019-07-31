using Hersan.Entidades.Calidad;
using Hersan.Entidades.Inyeccion;
using Hersan.Negocio;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Export;

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
                    //frm.Resumen = oDetalle.Count > 0 ? oDetalle[0].Resumen : null;
                    frm.StartPosition = FormStartPosition.CenterScreen;
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
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.ShowDialog();
                } else {
                    RadMessageBox.Show("No existen datos a graficar", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                }
            } catch (Exception ex) {
                throw ex;
            }
        }
        private void btnGraph_Click(object sender, EventArgs e)
        {
           try {
                frmGraficaHistorica frm = new frmGraficaHistorica();
                frm.ShowDialog();
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
        private void gvDetalle_ContextMenuOpening(object sender, Telerik.WinControls.UI.ContextMenuOpeningEventArgs e)
        {
            try {
                if (this.gvDetalle.RowCount > 0) {
                    RadDropDownMenu Menu = new RadDropDownMenu();
                    RadMenuItem MenuItem = new RadMenuItem("Exportar a Excel");
                    MenuItem.Click += new EventHandler(MenuItem_Click);
                    Menu.Items.Add(MenuItem);
                    e.ContextMenu = Menu;
                }

            } catch (Exception ex) {
                throw ex;
            }
        }
        private void MenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();           
            try {
                saveFileDialog.Filter = "Excel files (*.xlsx)|*.xls";
                saveFileDialog.RestoreDirectory = true;                

                if (saveFileDialog.ShowDialog() != DialogResult.OK) {
                    return;
                }

                if (saveFileDialog.FileName.Equals(String.Empty)) {
                    RadMessageBox.SetThemeName(this.gvDetalle.ThemeName);
                    RadMessageBox.Show("Capture el nombre del archivo");
                    return;
                }

                string fileName = saveFileDialog.FileName;

                ExportToExcelML excelExporter = new ExportToExcelML(this.gvDetalle);
                excelExporter.SheetName = "Datos";
                excelExporter.SummariesExportOption = SummariesOption.ExportAll;

                try {
                    excelExporter.RunExport(fileName);

                    RadMessageBox.SetThemeName(this.gvDetalle.ThemeName);
                    if (RadMessageBox.Show("Los datos se han exportado correctamente. Desea abrir el archivo...?", this.Text,
                            MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.Yes) {

                        BaseWinBP.AbrirArchivoExcel(fileName);
                    }
                } catch (System.IO.IOException ex) {
                    RadMessageBox.Show(this, ex.Message, "Error I/O", MessageBoxButtons.OK, RadMessageIcon.Error);
                }
            } catch (Exception ex) {
                throw ex;
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
