namespace Hersan.UI.Calidad
{
    partial class frmGraficaControl
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
            Telerik.WinControls.UI.LineSeries lineSeries1 = new Telerik.WinControls.UI.LineSeries();
            Telerik.WinControls.UI.LineSeries lineSeries2 = new Telerik.WinControls.UI.LineSeries();
            this.PageView = new Telerik.WinControls.UI.RadPageView();
            this.Page1 = new Telerik.WinControls.UI.RadPageViewPage();
            this.chart1 = new Telerik.WinControls.UI.RadChartView();
            this.Page2 = new Telerik.WinControls.UI.RadPageViewPage();
            this.Page3 = new Telerik.WinControls.UI.RadPageViewPage();
            this.Page4 = new Telerik.WinControls.UI.RadPageViewPage();
            this.Page5 = new Telerik.WinControls.UI.RadPageViewPage();
            this.Page6 = new Telerik.WinControls.UI.RadPageViewPage();
            this.Page7 = new Telerik.WinControls.UI.RadPageViewPage();
            this.Page8 = new Telerik.WinControls.UI.RadPageViewPage();
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
            this.PageView.Controls.Add(this.Page4);
            this.PageView.Controls.Add(this.Page5);
            this.PageView.Controls.Add(this.Page6);
            this.PageView.Controls.Add(this.Page7);
            this.PageView.Controls.Add(this.Page8);
            this.PageView.DefaultPage = this.Page1;
            this.PageView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PageView.Location = new System.Drawing.Point(0, 0);
            this.PageView.Name = "PageView";
            this.PageView.SelectedPage = this.Page1;
            this.PageView.Size = new System.Drawing.Size(832, 580);
            this.PageView.TabIndex = 1;
            this.PageView.SelectedPageChanged += new System.EventHandler(this.PageView_SelectedPageChanged);
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.PageView.GetChildAt(0))).ShowItemPinButton = false;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.PageView.GetChildAt(0))).StripButtons = Telerik.WinControls.UI.StripViewButtons.None;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.PageView.GetChildAt(0))).ItemAlignment = Telerik.WinControls.UI.StripViewItemAlignment.Near;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.PageView.GetChildAt(0))).ShowItemCloseButton = false;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.PageView.GetChildAt(0))).ItemSpacing = 5;
            // 
            // Page1
            // 
            this.Page1.Controls.Add(this.chart1);
            this.Page1.ItemSize = new System.Drawing.SizeF(65F, 28F);
            this.Page1.Location = new System.Drawing.Point(10, 37);
            this.Page1.Name = "Page1";
            this.Page1.Size = new System.Drawing.Size(811, 532);
            this.Page1.Tag = "Cav1";
            this.Page1.Text = "Cavidad 1";
            this.Page1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chart1
            // 
            this.chart1.AreaDesign = cartesianArea1;
            categoricalAxis1.IsPrimary = true;
            categoricalAxis1.LabelRotationAngle = 300D;
            categoricalAxis1.Title = "Tiempo";
            linearAxis1.AxisType = Telerik.Charting.AxisType.Second;
            linearAxis1.IsPrimary = true;
            linearAxis1.LabelRotationAngle = 300D;
            linearAxis1.TickOrigin = null;
            linearAxis1.Title = "Reflectividad";
            this.chart1.Axes.AddRange(new Telerik.WinControls.UI.Axis[] {
            categoricalAxis1,
            linearAxis1});
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chart1.EnableAnalytics = false;
            this.chart1.Location = new System.Drawing.Point(0, 0);
            this.chart1.Name = "chart1";
            this.chart1.SelectionMode = Telerik.WinControls.UI.ChartSelectionMode.SingleDataPoint;
            lineSeries1.HorizontalAxis = categoricalAxis1;
            lineSeries1.LabelAngle = 90D;
            lineSeries1.LabelDistanceToPoint = 15D;
            lineSeries1.VerticalAxis = linearAxis1;
            lineSeries2.HorizontalAxis = categoricalAxis1;
            lineSeries2.LabelAngle = 90D;
            lineSeries2.LabelDistanceToPoint = 15D;
            lineSeries2.LegendTitle = null;
            lineSeries2.VerticalAxis = linearAxis1;
            this.chart1.Series.AddRange(new Telerik.WinControls.UI.ChartSeries[] {
            lineSeries1,
            lineSeries2});
            this.chart1.ShowGrid = false;
            this.chart1.ShowPanZoom = true;
            this.chart1.ShowTitle = true;
            this.chart1.ShowToolTip = true;
            this.chart1.ShowTrackBall = true;
            this.chart1.Size = new System.Drawing.Size(811, 532);
            this.chart1.TabIndex = 2;
            this.chart1.Title = "Cavidad";
            this.chart1.UseDataSource = false;
            this.chart1.ContextMenuOpening += new Telerik.WinControls.UI.ChartViewContextMenuOpeningEventHandler(this.Chart_ContextMenuOpening);
            // 
            // Page2
            // 
            this.Page2.ItemSize = new System.Drawing.SizeF(65F, 28F);
            this.Page2.Location = new System.Drawing.Point(10, 37);
            this.Page2.Name = "Page2";
            this.Page2.Size = new System.Drawing.Size(811, 532);
            this.Page2.Tag = "Cav2";
            this.Page2.Text = "Cavidad 2";
            // 
            // Page3
            // 
            this.Page3.ItemSize = new System.Drawing.SizeF(65F, 28F);
            this.Page3.Location = new System.Drawing.Point(10, 37);
            this.Page3.Name = "Page3";
            this.Page3.Size = new System.Drawing.Size(811, 532);
            this.Page3.Tag = "Cav3";
            this.Page3.Text = "Cavidad 3";
            // 
            // Page4
            // 
            this.Page4.ItemSize = new System.Drawing.SizeF(65F, 28F);
            this.Page4.Location = new System.Drawing.Point(10, 37);
            this.Page4.Name = "Page4";
            this.Page4.Size = new System.Drawing.Size(811, 532);
            this.Page4.Tag = "Cav4";
            this.Page4.Text = "Cavidad 4";
            // 
            // Page5
            // 
            this.Page5.ItemSize = new System.Drawing.SizeF(65F, 28F);
            this.Page5.Location = new System.Drawing.Point(10, 37);
            this.Page5.Name = "Page5";
            this.Page5.Size = new System.Drawing.Size(811, 532);
            this.Page5.Tag = "Cav5";
            this.Page5.Text = "Cavidad 5";
            // 
            // Page6
            // 
            this.Page6.ItemSize = new System.Drawing.SizeF(65F, 28F);
            this.Page6.Location = new System.Drawing.Point(10, 37);
            this.Page6.Name = "Page6";
            this.Page6.Size = new System.Drawing.Size(811, 532);
            this.Page6.Tag = "Cav6";
            this.Page6.Text = "Cavidad 6";
            // 
            // Page7
            // 
            this.Page7.ItemSize = new System.Drawing.SizeF(65F, 28F);
            this.Page7.Location = new System.Drawing.Point(10, 37);
            this.Page7.Name = "Page7";
            this.Page7.Size = new System.Drawing.Size(811, 532);
            this.Page7.Tag = "Cav7";
            this.Page7.Text = "Cavidad 7";
            // 
            // Page8
            // 
            this.Page8.ItemSize = new System.Drawing.SizeF(65F, 28F);
            this.Page8.Location = new System.Drawing.Point(305, 4);
            this.Page8.Name = "Page8";
            this.Page8.Size = new System.Drawing.Size(523, 572);
            this.Page8.Tag = "Cav8";
            this.Page8.Text = "Cavidad 8";
            // 
            // frmGraficaControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 580);
            this.Controls.Add(this.PageView);
            this.Name = "frmGraficaControl";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowIcon = false;
            this.Text = "GRÁFICA DE CONTROL";
            this.Load += new System.EventHandler(this.frmHistograma_Load);
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
        private Telerik.WinControls.UI.RadPageViewPage Page2;
        private Telerik.WinControls.UI.RadPageViewPage Page3;
        private Telerik.WinControls.UI.RadPageViewPage Page4;
        private Telerik.WinControls.UI.RadPageViewPage Page5;
        private Telerik.WinControls.UI.RadPageViewPage Page6;
        private Telerik.WinControls.UI.RadPageViewPage Page7;
        private Telerik.WinControls.UI.RadPageViewPage Page8;
        private Telerik.WinControls.UI.RadChartView chart1;
    }
}
