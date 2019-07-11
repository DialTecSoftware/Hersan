using Hersan.Entidades.Calidad;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace Hersan.UI.Calidad
{
    public partial class frmHistograma : Telerik.WinControls.UI.RadForm
    {
        #region Variables y Propiedades
        WCF_Ensamble.Hersan_EnsambleClient oEnsamble;
        List<CalidadGraficasCavidades> oList;
        List<CalidadGraficasValores> oHistoria;
        public int Lista { get; set; }
        public List<CalidadResumenBE> Resumen { get; set; }
        public bool Historica { get; set; }
        public string Inicial { get; set; }
        public string Final { get; set; }
        #endregion

        public frmHistograma()
        {
            InitializeComponent();
        }
        private void frmHistograma_Load(object sender, EventArgs e)
        {
            try {
                if (!Historica) {
                    CargarDatos();
                } else {
                    CargaHistorica();
                }

                GenerarGraficas();
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrio un error al cargar las gráficas\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void PageView_SelectedPageChanged(object sender, EventArgs e)
        {
            try {
                GenerarGraficas();
            } catch (Exception ex) {
                throw ex;
            }
        }

        private void CargarDatos()
        {
            oEnsamble = new WCF_Ensamble.Hersan_EnsambleClient();
            try {
                oList = oEnsamble.CAL_AnalisisInyeccion_Histograma(Lista);
                //gvResumen.DataSource = Resumen;

                if (oList.Count > 0) {
                    foreach (var crtl in PageView.Pages) {
                        if (crtl.Name.Contains("1"))
                            crtl.Enabled = oList[0].Cav1;
                        else if (crtl.Name.Contains("2"))
                            crtl.Enabled = oList[0].Cav2;
                        else if (crtl.Name.Contains("3"))
                            crtl.Enabled = oList[0].Cav3;
                        else if (crtl.Name.Contains("4"))
                            crtl.Enabled = oList[0].Cav4;
                        else if (crtl.Name.Contains("5"))
                            crtl.Enabled = oList[0].Cav5;
                        else if (crtl.Name.Contains("6"))
                            crtl.Enabled = oList[0].Cav6;
                        else if (crtl.Name.Contains("7"))
                            crtl.Enabled = oList[0].Cav7;
                        else if (crtl.Name.Contains("8"))
                            crtl.Enabled = oList[0].Cav8;
                    }
                }
            } catch (Exception ex) {
                throw ex;
            } finally {
                oEnsamble = null;
            }
        }
        private void CargaHistorica()
        {
            oEnsamble = new WCF_Ensamble.Hersan_EnsambleClient();
            try {
                oHistoria = oEnsamble.CAL_AnalisisInyeccion_Histograma_Historico(Inicial, Final);
            } catch (Exception ex) {
                throw ex;
            } finally {
                oEnsamble = null;
            }
        }
        private void GenerarGraficas()
        {
            try {

                var Aux = PageView.SelectedPage;

                if (Aux.Enabled) {
                    BarSeries barSeria = new BarSeries();
                    barSeria.DataSource = Historica ? oHistoria : oList[0].Valores;
                    barSeria.ValueMember = Aux.Tag.ToString();
                    barSeria.CategoryMember = "Limite";

                    ChartPanZoomController panZoomController = new ChartPanZoomController();
                    panZoomController.PanZoomMode = ChartPanZoomMode.Horizontal;
                    chart1.View.Palette = KnownPalette.Arctic;

                    RadChartView chart = chart1;
                    chart.Series.Clear();
                    chart.Series.Add(barSeria);
                    chart.Title = Aux.Text;
                    chart.ShowPanZoom = true;
                    chart.Controllers.Add(panZoomController);

                    //foreach (var series in chart.Series) {
                    //    series.ShowLabels = true;
                    //}

                    chart.Dock = DockStyle.Fill;
                    Aux.Controls.Add(chart);
                }
            } catch (Exception ex) {
                throw ex;
            }

        }
        
    }
}
