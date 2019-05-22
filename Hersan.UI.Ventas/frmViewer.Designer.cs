namespace Hersan.UI.Ensamble
{
    partial class frmViewer
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
            this.rptviewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.rptCotizacion1 = new Hersan.UI.Ensamble.Reportes.rptCotizacion();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // rptviewer
            // 
            this.rptviewer.ActiveViewIndex = -1;
            this.rptviewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rptviewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.rptviewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rptviewer.Location = new System.Drawing.Point(0, 0);
            this.rptviewer.Name = "rptviewer";
            this.rptviewer.Size = new System.Drawing.Size(484, 322);
            this.rptviewer.TabIndex = 0;
            // 
            // frmViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 322);
            this.Controls.Add(this.rptviewer);
            this.Name = "frmViewer";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowIcon = false;
            this.Text = "REPORTES";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer rptviewer;
        public Reportes.rptCotizacion rptCotizacion1;
    }
}
