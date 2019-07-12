using Hersan.Entidades.Calidad;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
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

        public List<CalidadGraficasValores> oHistoria { get; set; }
        public int Lista { get; set; }        
        public List<CalidadResumenBE> Resumen { get; set; }
        public bool Ensamble { get; set; }
        public bool Historica { get; set; }
        public string Inicial { get; set; }
        public string Final { get; set; }

        RadChartView chart = new RadChartView();
        
        #endregion

        public frmHistograma()
        {
            InitializeComponent();
        }
        private void frmHistograma_Load(object sender, EventArgs e)
        {
            try {
                chart.ContextMenuOpening += new ChartViewContextMenuOpeningEventHandler(Chart_ContextMenuOpening);
                if (Ensamble) {
                    string No = string.Empty;
                    for(int x= 0; x <= this.PageView.Pages.Count + 1; x++) {
                        if (x <= 4) {
                            this.PageView.Pages[x].Text = "Observación " + (x + 1).ToString();
                        } else {
                            this.PageView.Pages.RemoveAt(12-x);
                        }
                    }
                }

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
                RadMessageBox.Show("Ocurrio un error al seleccionar la grafica\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
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

        private void CargarDatos()
        {
            oEnsamble = new WCF_Ensamble.Hersan_EnsambleClient();
            try {
                if (!Ensamble) {
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
                } else {
                    if(oHistoria == null)
                        oHistoria = oEnsamble.CAL_InspeccionEnsamble_Histograma(Lista);
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
                    barSeria.DataSource = Historica  || Ensamble ? oHistoria : oList[0].Valores;
                    barSeria.ValueMember = Aux.Tag.ToString();
                    barSeria.CategoryMember = "Limite";

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
                RadMessageBox.Show("Ocurrio un error generar la gráfica\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }

        }
       
    }
}
