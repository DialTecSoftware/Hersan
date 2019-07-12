using Hersan.Entidades.Calidad;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace Hersan.UI.Calidad
{
    public partial class frmGraficaQA : Telerik.WinControls.UI.RadForm
    {
        public List<CalidadResguardoQADetalle> oList { get; set; }

        public frmGraficaQA()
        {
            InitializeComponent();
        }
        private void frmGraficaQA_Load(object sender, EventArgs e)
        {
            try {
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

        private void GenerarGrafica()
        {
            try {
                var Aux = PageView.SelectedPage;

                if (Aux.Enabled) {
                    BarSeries barSeria = new BarSeries();
                    barSeria.DataSource = oList;
                    barSeria.ValueMember = Aux.Tag.ToString();
                    barSeria.CategoryMember = "Lote";

                    ChartPanZoomController panZoomController = new ChartPanZoomController();
                    panZoomController.PanZoomMode = ChartPanZoomMode.Horizontal;
                    chart1.View.Palette = KnownPalette.Arctic;

                    RadChartView chart = chart1;
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
