using Hersan.Entidades.Calidad;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Telerik.Charting;

namespace Hersan.UI.Calidad
{
    public partial class frmGraficaControl : Telerik.WinControls.UI.RadForm
    {
        WCF_Ensamble.Hersan_EnsambleClient oEnsamble;
        List<CalidadGraficasCavidades> oList;
        public int Lista { get; set; }
        public List<CalidadResumenBE> Resumen { get; set; }

        public frmGraficaControl()
        {
            InitializeComponent();
        }
        private void frmHistograma_Load(object sender, EventArgs e)
        {
            try {
                CargarDatos();
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
                oList = oEnsamble.CAL_AnalisisInyeccion_GraficaControl(Lista, "20190708");
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
        private void GenerarGraficas()
        {
            try {
                if (oList.Count > 0) {
                    var Aux = PageView.SelectedPage;
                    decimal vMax = 0;
                    decimal vMin = 0;


                    if (Aux.Enabled) {
                        ChartPanZoomController panZoomController = new ChartPanZoomController();
                        panZoomController.PanZoomMode = ChartPanZoomMode.Horizontal;
                        chart1.View.Palette = KnownPalette.Material;

                        RadChartView chart = chart1;
                        chart.Series.Clear();
                        chart.Title = Aux.Text;
                        chart.ShowPanZoom = true;
                        chart.Controllers.Add(panZoomController);

                        LineSeries lineSeries = new LineSeries();
                        LineSeries Max = new LineSeries();
                        LineSeries Min = new LineSeries();
                        oList[0].Valores.ForEach(item => {
                        if (Aux.Tag.ToString() == "Cav1") {
                                vMax = Resumen[0].Promedio + (3 * Resumen[0].DesvEst);
                                vMin = Resumen[0].Promedio - (3 * Resumen[0].DesvEst);
                                Max.DataPoints.Add(new CategoricalDataPoint(double.Parse(vMax.ToString()), item.Hora));
                                lineSeries.DataPoints.Add(new CategoricalDataPoint(item.Val1, item.Hora));
                                Min.DataPoints.Add(new CategoricalDataPoint(double.Parse(vMin.ToString()), item.Hora));
                            }
                            if (Aux.Tag.ToString() == "Cav2") {
                                vMax = Resumen[1].Promedio + (3 * Resumen[1].DesvEst);
                                vMin = Resumen[1].Promedio - (3 * Resumen[1].DesvEst);
                                Max.DataPoints.Add(new CategoricalDataPoint(double.Parse(vMax.ToString()), item.Hora));
                                lineSeries.DataPoints.Add(new CategoricalDataPoint(item.Val2, item.Hora));
                                Min.DataPoints.Add(new CategoricalDataPoint(double.Parse(vMin.ToString()), item.Hora));
                            }
                            if (Aux.Tag.ToString() == "Cav3") {
                                vMax = Resumen[2].Promedio + (3 * Resumen[2].DesvEst);
                                vMin = Resumen[2].Promedio - (3 * Resumen[2].DesvEst);
                                Max.DataPoints.Add(new CategoricalDataPoint(double.Parse(vMax.ToString()), item.Hora));
                                lineSeries.DataPoints.Add(new CategoricalDataPoint(item.Val3, item.Hora));
                                Min.DataPoints.Add(new CategoricalDataPoint(double.Parse(vMin.ToString()), item.Hora));
                            }
                            if (Aux.Tag.ToString() == "Cav4") {
                                vMax = Resumen[3].Promedio + (3 * Resumen[3].DesvEst);
                                vMin = Resumen[3].Promedio - (3 * Resumen[3].DesvEst);
                                Max.DataPoints.Add(new CategoricalDataPoint(double.Parse(vMax.ToString()), item.Hora));
                                lineSeries.DataPoints.Add(new CategoricalDataPoint(item.Val4, item.Hora));
                                Min.DataPoints.Add(new CategoricalDataPoint(double.Parse(vMin.ToString()), item.Hora));
                            }
                            if (Aux.Tag.ToString() == "Cav5") {
                                vMax = Resumen[4].Promedio + (3 * Resumen[4].DesvEst);
                                vMin = Resumen[4].Promedio - (3 * Resumen[4].DesvEst);
                                Max.DataPoints.Add(new CategoricalDataPoint(double.Parse(vMax.ToString()), item.Hora));
                                lineSeries.DataPoints.Add(new CategoricalDataPoint(item.Val5, item.Hora));
                                Min.DataPoints.Add(new CategoricalDataPoint(double.Parse(vMin.ToString()), item.Hora));
                            }
                            if (Aux.Tag.ToString() == "Cav6") {
                                vMax = Resumen[5].Promedio + (3 * Resumen[5].DesvEst);
                                vMin = Resumen[5].Promedio - (3 * Resumen[5].DesvEst);
                                Max.DataPoints.Add(new CategoricalDataPoint(double.Parse(vMax.ToString()), item.Hora));
                                lineSeries.DataPoints.Add(new CategoricalDataPoint(item.Val6, item.Hora));
                                Min.DataPoints.Add(new CategoricalDataPoint(double.Parse(vMin.ToString()), item.Hora));
                            }
                            if (Aux.Tag.ToString() == "Cav7") {
                                vMax = Resumen[6].Promedio + (3 * Resumen[6].DesvEst);
                                vMin = Resumen[6].Promedio - (3 * Resumen[6].DesvEst);
                                Max.DataPoints.Add(new CategoricalDataPoint(double.Parse(vMax.ToString()), item.Hora));
                                lineSeries.DataPoints.Add(new CategoricalDataPoint(item.Val7, item.Hora));
                                Min.DataPoints.Add(new CategoricalDataPoint(double.Parse(vMin.ToString()), item.Hora));
                            }
                            if (Aux.Tag.ToString() == "Cav8") {
                                vMax = Resumen[7].Promedio + (3 * Resumen[7].DesvEst);
                                vMin = Resumen[7].Promedio - (3 * Resumen[7].DesvEst);
                                Max.DataPoints.Add(new CategoricalDataPoint(double.Parse(vMax.ToString()), item.Hora));
                                lineSeries.DataPoints.Add(new CategoricalDataPoint(item.Val8, item.Hora));
                                Min.DataPoints.Add(new CategoricalDataPoint(double.Parse(vMin.ToString()), item.Hora));
                            }
                        });

                        chart.Series.Add(lineSeries);
                        chart.Series.Add(Max);
                        chart.Series.Add(Min);
                        chart.Dock = DockStyle.Fill;
                        Aux.Controls.Add(chart);
                    }
                } else {
                    RadMessageBox.Show("No existen datos a graficar", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                }
            } catch (Exception ex) {
                throw ex;
            }

        }
    }
}
