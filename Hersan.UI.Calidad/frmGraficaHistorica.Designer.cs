namespace Hersan.UI.Calidad
{
    partial class frmGraficaHistorica
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGraficaHistorica));
            this.btnHistograma = new Telerik.WinControls.UI.RadButton();
            this.btnSeries = new Telerik.WinControls.UI.RadButton();
            this.label1 = new System.Windows.Forms.Label();
            this.dtDesde = new Telerik.WinControls.UI.RadDateTimePicker();
            this.dtHasta = new Telerik.WinControls.UI.RadDateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.btnHistograma)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSeries)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDesde)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtHasta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // btnHistograma
            // 
            this.btnHistograma.Image = ((System.Drawing.Image)(resources.GetObject("btnHistograma.Image")));
            this.btnHistograma.Location = new System.Drawing.Point(68, 86);
            this.btnHistograma.Name = "btnHistograma";
            this.btnHistograma.Size = new System.Drawing.Size(97, 40);
            this.btnHistograma.TabIndex = 0;
            this.btnHistograma.Text = "Histograma";
            this.btnHistograma.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnHistograma.Click += new System.EventHandler(this.btnHistograma_Click);
            // 
            // btnSeries
            // 
            this.btnSeries.Image = ((System.Drawing.Image)(resources.GetObject("btnSeries.Image")));
            this.btnSeries.Location = new System.Drawing.Point(208, 86);
            this.btnSeries.Name = "btnSeries";
            this.btnSeries.Size = new System.Drawing.Size(97, 40);
            this.btnSeries.TabIndex = 1;
            this.btnSeries.Text = "Series";
            this.btnSeries.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSeries.Click += new System.EventHandler(this.btnSeries_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(24, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 41;
            this.label1.Text = "Desde:";
            // 
            // dtDesde
            // 
            this.dtDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDesde.Location = new System.Drawing.Point(68, 31);
            this.dtDesde.Name = "dtDesde";
            this.dtDesde.Size = new System.Drawing.Size(92, 20);
            this.dtDesde.TabIndex = 42;
            this.dtDesde.TabStop = false;
            this.dtDesde.Text = "10/07/2019";
            this.dtDesde.Value = new System.DateTime(2019, 7, 10, 13, 27, 8, 630);
            this.dtDesde.ValueChanged += new System.EventHandler(this.dtDesde_ValueChanged);
            // 
            // dtHasta
            // 
            this.dtHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtHasta.Location = new System.Drawing.Point(230, 31);
            this.dtHasta.Name = "dtHasta";
            this.dtHasta.Size = new System.Drawing.Size(92, 20);
            this.dtHasta.TabIndex = 44;
            this.dtHasta.TabStop = false;
            this.dtHasta.Text = "10/07/2019";
            this.dtHasta.Value = new System.DateTime(2019, 7, 10, 13, 27, 8, 630);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(189, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 43;
            this.label2.Text = "Hasta:";
            // 
            // frmGraficaHistorica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 140);
            this.Controls.Add(this.dtHasta);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtDesde);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSeries);
            this.Controls.Add(this.btnHistograma);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmGraficaHistorica";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "GRAFICAS HISTÓRICAS";
            this.Load += new System.EventHandler(this.frmGraficaHistorica_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnHistograma)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSeries)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDesde)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtHasta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadButton btnHistograma;
        private Telerik.WinControls.UI.RadButton btnSeries;
        private System.Windows.Forms.Label label1;
        private Telerik.WinControls.UI.RadDateTimePicker dtDesde;
        private Telerik.WinControls.UI.RadDateTimePicker dtHasta;
        private System.Windows.Forms.Label label2;
    }
}
