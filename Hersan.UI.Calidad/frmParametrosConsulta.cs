using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Export;

namespace Hersan.UI.Calidad
{
    public partial class frmParametrosConsulta : Telerik.WinControls.UI.RadForm
    {
        WCF_Ensamble.Hersan_EnsambleClient oEnsamble;

        public frmParametrosConsulta()
        {
            InitializeComponent();
        }
        private void frmParametrosConsulta_Load(object sender, EventArgs e)
        {
            try {
                btnRefresh_Click(new object(), new EventArgs());
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al cargar la pantalla\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            oEnsamble = new WCF_Ensamble.Hersan_EnsambleClient();
            try {
                gvDatos.DataSource = oEnsamble.PRO_Parametros_Consulta();
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al cargar los datos\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally {
                oEnsamble = null;
            }
        }
        private void btnExportar_Click(object sender, EventArgs e)
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

                        Negocio.BaseWinBP.AbrirArchivoExcel(fileName);
                    }
                } catch (System.IO.IOException ex) {
                    RadMessageBox.Show(this, ex.Message, "Error I/O", MessageBoxButtons.OK, RadMessageIcon.Error);
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

       
    }
}
