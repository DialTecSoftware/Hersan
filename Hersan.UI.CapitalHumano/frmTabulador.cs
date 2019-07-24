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
using Telerik.WinControls.UI.Export;

namespace Hersan.UI.CapitalHumano
{
    public partial class frmTabulador : Telerik.WinControls.UI.RadForm
    {
        WCF_CHumano.Hersan_CHumanoClient oCHumano;

        public frmTabulador()
        {
            InitializeComponent();
        }
        private void frmTabulador_Load(object sender, EventArgs e)
        {
            oCHumano = new WCF_CHumano.Hersan_CHumanoClient();
            try {
                gvDatos.DataSource = oCHumano.CHU_Tabulador_Puestos_Obtener();
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al cargar la pantalla\n"+ ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
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
        private void gvDatos_ContextMenuOpening(object sender, Telerik.WinControls.UI.ContextMenuOpeningEventArgs e)
        {
            try {
                if (this.gvDatos.RowCount > 0) {
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
                    RadMessageBox.SetThemeName(this.gvDatos.ThemeName);
                    RadMessageBox.Show("Capture el nombre del archivo");
                    return;
                }

                string fileName = saveFileDialog.FileName;

                ExportToExcelML excelExporter = new ExportToExcelML(this.gvDatos);
                excelExporter.SheetName = "Datos";
                excelExporter.SummariesExportOption = SummariesOption.ExportAll;

                try {
                    excelExporter.RunExport(fileName);

                    RadMessageBox.SetThemeName(this.gvDatos.ThemeName);
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
    }
}
