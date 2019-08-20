namespace Hersan.UI.Nomina {
    partial class frmViewer {
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
            if (disposing && (components != null)) {
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
            this.rptViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.iReport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // rptViewer
            // 
            this.rptViewer.ActiveViewIndex = -1;
            this.rptViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rptViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.rptViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rptViewer.Location = new System.Drawing.Point(0, 0);
            this.rptViewer.Name = "rptViewer";
            this.rptViewer.ShowCloseButton = false;
            this.rptViewer.ShowCopyButton = false;
            this.rptViewer.ShowGroupTreeButton = false;
            this.rptViewer.ShowLogo = false;
            this.rptViewer.ShowTextSearchButton = false;
            this.rptViewer.Size = new System.Drawing.Size(668, 501);
            this.rptViewer.TabIndex = 0;
            this.rptViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // frmViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 501);
            this.Controls.Add(this.rptViewer);
            this.Name = "frmViewer";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "REPORTE";
            this.Load += new System.EventHandler(this.frmViewer_Load);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer rptViewer;
        public CrystalDecisions.CrystalReports.Engine.ReportDocument iReport;
    }
}
