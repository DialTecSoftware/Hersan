﻿using Hersan.Entidades.Calidad;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Telerik.Charting;
using System.ComponentModel;
using System.Drawing;

namespace Hersan.UI.Calidad
{
    public partial class frmGraficaControl : Telerik.WinControls.UI.RadForm
    {
        #region Variables y Propiedades
        WCF_Ensamble.Hersan_EnsambleClient oEnsamble;
        List<CalidadGraficasCavidades> oList;
        List<CalidadGraficaSeries> oSeries;
        public int Lista { get; set; }
        public List<CalidadResumenBE> Resumen { get; set; }
        public string Inicial { get; set; }
        public string Final{ get; set; }
        public bool Series { get; set; }
        #endregion


        public frmGraficaControl()
        {
            InitializeComponent();
        }
        private void frmHistograma_Load(object sender, EventArgs e)
        {
            try {
                if (!Series) {
                    CargarDatos();
                    GenerarGraficas();
                } else {
                    CargarSeries();
                    GenerarSerie();
                }
                
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrio un error al cargar las gráficas\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void PageView_SelectedPageChanged(object sender, EventArgs e)
        {
            try {
                if (!Series) 
                    GenerarGraficas();
                else {
                    GenerarSerie();
                }
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
        private void CargarSeries()
        {
            oEnsamble = new WCF_Ensamble.Hersan_EnsambleClient();
            try {
                oSeries = oEnsamble.CAL_AnalisisInyeccion_GraficaSeries(Inicial, Final);
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
                        LineSeries Min = new LineSeries();
                        oList[0].Valores.ForEach(item => {
                        if (Aux.Tag.ToString() == "Cav1") {
                                vMin = Resumen[0].Promedio - (3 * Resumen[0].DesvEst);
                                lineSeries.DataPoints.Add(new CategoricalDataPoint(item.Val1, item.Hora));
                                Min.DataPoints.Add(new CategoricalDataPoint(double.Parse(vMin.ToString()), item.Hora));
                            }
                            if (Aux.Tag.ToString() == "Cav2") {
                                vMin = Resumen[1].Promedio - (3 * Resumen[1].DesvEst);
                                lineSeries.DataPoints.Add(new CategoricalDataPoint(item.Val2, item.Hora));
                                Min.DataPoints.Add(new CategoricalDataPoint(double.Parse(vMin.ToString()), item.Hora));
                            }
                            if (Aux.Tag.ToString() == "Cav3") {
                                vMin = Resumen[2].Promedio - (3 * Resumen[2].DesvEst);
                                lineSeries.DataPoints.Add(new CategoricalDataPoint(item.Val3, item.Hora));
                                Min.DataPoints.Add(new CategoricalDataPoint(double.Parse(vMin.ToString()), item.Hora));
                            }
                            if (Aux.Tag.ToString() == "Cav4") {
                                vMin = Resumen[3].Promedio - (3 * Resumen[3].DesvEst);
                                lineSeries.DataPoints.Add(new CategoricalDataPoint(item.Val4, item.Hora));
                                Min.DataPoints.Add(new CategoricalDataPoint(double.Parse(vMin.ToString()), item.Hora));
                            }
                            if (Aux.Tag.ToString() == "Cav5") {
                                vMin = Resumen[4].Promedio - (3 * Resumen[4].DesvEst);
                                lineSeries.DataPoints.Add(new CategoricalDataPoint(item.Val5, item.Hora));
                                Min.DataPoints.Add(new CategoricalDataPoint(double.Parse(vMin.ToString()), item.Hora));
                            }
                            if (Aux.Tag.ToString() == "Cav6") {
                                vMin = Resumen[5].Promedio - (3 * Resumen[5].DesvEst);
                                lineSeries.DataPoints.Add(new CategoricalDataPoint(item.Val6, item.Hora));
                                Min.DataPoints.Add(new CategoricalDataPoint(double.Parse(vMin.ToString()), item.Hora));
                            }
                            if (Aux.Tag.ToString() == "Cav7") {
                                vMin = Resumen[6].Promedio - (3 * Resumen[6].DesvEst);
                                lineSeries.DataPoints.Add(new CategoricalDataPoint(item.Val7, item.Hora));
                                Min.DataPoints.Add(new CategoricalDataPoint(double.Parse(vMin.ToString()), item.Hora));
                            }
                            if (Aux.Tag.ToString() == "Cav8") {
                                vMin = Resumen[7].Promedio - (3 * Resumen[7].DesvEst);
                                lineSeries.DataPoints.Add(new CategoricalDataPoint(item.Val8, item.Hora));
                                Min.DataPoints.Add(new CategoricalDataPoint(double.Parse(vMin.ToString()), item.Hora));
                            }
                        });

                        lineSeries.LegendTitle = "Valor";
                        Min.LegendTitle = "Min";

                        chart.ShowLegend = true;
                        chart.Series.Add(lineSeries);
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
        private void GenerarSerie()
        {
            var Aux = PageView.SelectedPage;
            try {                
                if (oSeries.Count > 0) {
                    ChartPanZoomController panZoomController = new ChartPanZoomController();
                    panZoomController.PanZoomMode = ChartPanZoomMode.Horizontal;
                    chart1.View.Palette = KnownPalette.Material;

                    RadChartView chart = chart1;
                    chart.Series.Clear();
                    chart.Title = Aux.Text;
                    chart.ShowPanZoom = true;
                    chart.Controllers.Add(panZoomController);

                    //Create and add Moving Average indicator
                    BollingerBandsIndicator maIndicator = new BollingerBandsIndicator();
                    maIndicator.CategoryMember = "Fecha";
                    maIndicator.DataSource = oSeries;
                    maIndicator.Period = 1;
                    maIndicator.StandardDeviations = 1;

                    //Create and add hlc series
                    HlcSeries series = new HlcSeries();

                    if (Aux.Tag.ToString() == "Cav1") {
                        maIndicator.ValueMember = "Val1";
                        series.CloseValueMember = "Val1";
                        series.HighValueMember = "Max1";
                        series.LowValueMember = "Min1";
                    }
                    if (Aux.Tag.ToString() == "Cav2") {
                        maIndicator.ValueMember = "Val2";
                        series.CloseValueMember = "Val2";
                        series.HighValueMember = "Max2";
                        series.LowValueMember = "Min2";
                    }
                    if (Aux.Tag.ToString() == "Cav3") {
                        maIndicator.ValueMember = "Val3";
                        series.CloseValueMember = "Val3";
                        series.HighValueMember = "Max3";
                        series.LowValueMember = "Min3";
                    }
                    if (Aux.Tag.ToString() == "Cav4") {
                        maIndicator.ValueMember = "Val4";
                        series.CloseValueMember = "Val4";
                        series.HighValueMember = "Max4";
                        series.LowValueMember = "Min4";
                    }
                    if (Aux.Tag.ToString() == "Cav5") {
                        maIndicator.ValueMember = "Val5";
                        series.CloseValueMember = "Val5";
                        series.HighValueMember = "Max5";
                        series.LowValueMember = "Min5";
                    }
                    if (Aux.Tag.ToString() == "Cav6") {
                        maIndicator.ValueMember = "Val6";
                        series.CloseValueMember = "Val6";
                        series.HighValueMember = "Max6";
                        series.LowValueMember = "Min6";
                    }
                    if (Aux.Tag.ToString() == "Cav7") {
                        maIndicator.ValueMember = "Val7";
                        series.CloseValueMember = "Val7";
                        series.HighValueMember = "Max7";
                        series.LowValueMember = "Min7";
                    }
                    if (Aux.Tag.ToString() == "Cav8") {
                        maIndicator.ValueMember = "Val8";
                        series.CloseValueMember = "Val8";
                        series.HighValueMember = "Max8";
                        series.LowValueMember = "Min8";
                    }
                    maIndicator.BorderColor = Color.Red;
                    maIndicator.PointSize = SizeF.Empty;

                    chart.Series.Add(maIndicator);

                    series.CategoryMember = "Fecha";
                    series.DataSource = oSeries;
                    series.BorderColor = Color.Green;

                    chart.ShowLegend = false;
                    chart.Dock = DockStyle.Fill;
                    chart.Series.Add(series);
                    Aux.Controls.Add(chart);
                }
            } catch (Exception ex) {
                throw ex;
            } finally {
                oEnsamble = null;
            }

        }
    }
}
