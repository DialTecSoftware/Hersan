namespace Hersan.UI.Calidad
{
    partial class frmGraficaQA
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.WinControls.UI.CartesianArea cartesianArea1 = new Telerik.WinControls.UI.CartesianArea();
            Telerik.WinControls.UI.CategoricalAxis categoricalAxis1 = new Telerik.WinControls.UI.CategoricalAxis();
            Telerik.WinControls.UI.LinearAxis linearAxis1 = new Telerik.WinControls.UI.LinearAxis();
            Telerik.WinControls.UI.BarSeries barSeries1 = new Telerik.WinControls.UI.BarSeries();
            Telerik.WinControls.UI.BarSeries barSeries2 = new Telerik.WinControls.UI.BarSeries();
            this.PageView = new Telerik.WinControls.UI.RadPageView();
            this.Page1 = new Telerik.WinControls.UI.RadPageViewPage();
            this.chart1 = new Telerik.WinControls.UI.RadChartView();
            this.Page2 = new Telerik.WinControls.UI.RadPageViewPage();
            this.Page3 = new Telerik.WinControls.UI.RadPageViewPage();
            ((System.ComponentModel.ISupportInitialize)(this.PageView)).BeginInit();
            this.PageView.SuspendLayout();
            this.Page1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // PageView
            // 
            this.PageView.Controls.Add(this.Page1);
            this.PageView.Controls.Add(this.Page2);
            this.PageView.Controls.Add(this.Page3);
            this.PageView.DefaultPage = this.Page1;
            this.PageView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PageView.Location = new System.Drawing.Point(0, 0);
            this.PageView.Name = "PageView";
            this.PageView.SelectedPage = this.Page1;
            this.PageView.Size = new System.Drawing.Size(781, 448);
            this.PageView.TabIndex = 1;
            this.PageView.SelectedPageChanged += new System.EventHandler(this.PageView_SelectedPageChanged);
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.PageView.GetChildAt(0))).StripButtons = Telerik.WinControls.UI.StripViewButtons.None;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.PageView.GetChildAt(0))).ItemAlignment = Telerik.WinControls.UI.StripViewItemAlignment.Near;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.PageView.GetChildAt(0))).ItemFitMode = Telerik.WinControls.UI.StripViewItemFitMode.None;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.PageView.GetChildAt(0))).ItemSpacing = 0;
            // 
            // Page1
            // 
            this.Page1.Controls.Add(this.chart1);
            this.Page1.ItemSize = new System.Drawing.SizeF(56F, 28F);
            this.Page1.Location = new System.Drawing.Point(10, 37);
            this.Page1.Name = "Page1";
            this.Page1.Size = new System.Drawing.Size(760, 400);
            this.Page1.Tag = "Valor0";
            this.Page1.Text = "Valor 0°";
            this.Page1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chart1
            // 
            this.chart1.AreaDesign = cartesianArea1;
            categoricalAxis1.IsPrimary = true;
            categoricalAxis1.LabelRotationAngle = 300D;
            categoricalAxis1.Title = "Reflectividad";
            linearAxis1.AxisType = Telerik.Charting.AxisType.Second;
            linearAxis1.IsPrimary = true;
            linearAxis1.LabelRotationAngle = 300D;
            linearAxis1.TickOrigin = null;
            linearAxis1.Title = "Frecuencia";
            this.chart1.Axes.AddRange(new Telerik.WinControls.UI.Axis[] {
            categoricalAxis1,
            linearAxis1});
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chart1.EnableAnalytics = false;
            this.chart1.Location = new System.Drawing.Point(0, 0);
            this.chart1.Name = "chart1";
            this.chart1.SelectionMode = Telerik.WinControls.UI.ChartSelectionMode.SingleDataPoint;
            barSeries1.HorizontalAxis = categoricalAxis1;
            barSeries1.LabelMode = Telerik.WinControls.UI.BarLabelModes.Top;
            barSeries1.LegendTitle = null;
            barSeries1.ShowLabels = true;
            barSeries1.VerticalAxis = linearAxis1;
            barSeries2.HorizontalAxis = categoricalAxis1;
            barSeries2.LabelMode = Telerik.WinControls.UI.BarLabelModes.Top;
            barSeries2.LegendTitle = null;
            barSeries2.ShowLabels = true;
            barSeries2.VerticalAxis = linearAxis1;
            this.chart1.Series.AddRange(new Telerik.WinControls.UI.ChartSeries[] {
            barSeries1,
            barSeries2});
            this.chart1.ShowGrid = false;
            this.chart1.ShowPanZoom = true;
            this.chart1.ShowTitle = true;
            this.chart1.ShowTrackBall = true;
            this.chart1.Size = new System.Drawing.Size(760, 400);
            this.chart1.TabIndex = 1;
            this.chart1.Title = "Valor";
            this.chart1.UseDataSource = false;
            // 
            // Page2
            // 
            this.Page2.ItemSize = new System.Drawing.SizeF(62F, 28F);
            this.Page2.Location = new System.Drawing.Point(10, 37);
            this.Page2.Name = "Page2";
            this.Page2.Size = new System.Drawing.Size(760, 400);
            this.Page2.Tag = "Valor1";
            this.Page2.Text = "Valor 20°";
            // 
            // Page3
            // 
            this.Page3.ItemSize = new System.Drawing.SizeF(66F, 28F);
            this.Page3.Location = new System.Drawing.Point(10, 37);
            this.Page3.Name = "Page3";
            this.Page3.Size = new System.Drawing.Size(760, 400);
            this.Page3.Tag = "Valor2";
            this.Page3.Text = "Valor -20°";
            // 
            // frmGraficaQA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(781, 448);
            this.Controls.Add(this.PageView);
            this.Name = "frmGraficaQA";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowIcon = false;
            this.Text = "HISTOGRAMA";
            this.Load += new System.EventHandler(this.frmGraficaQA_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PageView)).EndInit();
            this.PageView.ResumeLayout(false);
            this.Page1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadPageView PageView;
        private Telerik.WinControls.UI.RadPageViewPage Page1;
        private Telerik.WinControls.UI.RadChartView chart1;
        private Telerik.WinControls.UI.RadPageViewPage Page2;
        private Telerik.WinControls.UI.RadPageViewPage Page3;
    }
}
