using Hersan.Entidades.Calidad;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace Hersan.UI.Calidad
{
    public partial class frmGraficaQA : Telerik.WinControls.UI.RadForm
    {
        public List<CalidadResguardoQADetalle> oList { get; set; }
        RadChartView chart = new RadChartView();

        public frmGraficaQA()
        {
            InitializeComponent();
        }
        private void frmGraficaQA_Load(object sender, EventArgs e)
        {
            try {
                chart.ContextMenuOpening += new ChartViewContextMenuOpeningEventHandler(Chart_ContextMenuOpening);
                GenerarGrafica();
            } catch (Exception ex) {
                throw ex;
            }
        }
        private void PageView_SelectedPageChanged(object sender, EventArgs e)
        {
            try {
                GenerarGrafica();
            } catch (Exception ex) {
                throw ex;
            }
        }
        private void Chart_ContextMenuOpening(object sender, ChartViewContextMenuOpeningEventArgs e)
        {
            try {
                RadContextMenu Menu = new RadContextMenu();
                RadMenuItem MenuItem = new RadMenuItem("Exportar Gráfica");
                MenuItem.Click += new EventHandler(MenuItem_Click);
                Menu.Items.Add(MenuItem);
                e.ContextMenu = Menu;
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrio un error al mostrar el menú\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void MenuItem_Click(object sender, EventArgs e)
        {
            try {
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.Filter = string.Format("Image (*.{0};)|*.{0}", "Jpeg");

                if (dialog.ShowDialog() == DialogResult.OK) {
                    this.chart.ExportToImage(dialog.FileName, new Size(800, 600), ImageFormat.Jpeg);
                    RadMessageBox.Show("Gráfica exportada correctamente", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                }
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrio un error al exportar la gráfica\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }

        private void GenerarGrafica()
        {
            try {
                var Aux = PageView.SelectedPage;

                if (Aux.Enabled) {
                    BarSeries barSeria = new BarSeries();
                    barSeria.DataSource = oList;
                    barSeria.ValueMember = Aux.Tag.ToString();
                    barSeria.CategoryMember = "Id";

                    ChartPanZoomController panZoomController = new ChartPanZoomController();
                    panZoomController.PanZoomMode = ChartPanZoomMode.Horizontal;
                    chart1.View.Palette = KnownPalette.Arctic;

                    chart = chart1;
                    chart.Series.Clear();
                    chart.Series.Add(barSeria);
                    chart.Title = Aux.Text;
                    chart.ShowPanZoom = true;
                    chart.Controllers.Add(panZoomController);

                    chart.Dock = DockStyle.Fill;
                    Aux.Controls.Add(chart);
                }
            } catch (Exception ex) {
                throw ex;
            }
        }
    }
}
