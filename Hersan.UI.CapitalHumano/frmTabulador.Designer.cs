namespace Hersan.UI.CapitalHumano
{
    partial class frmTabulador
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTabulador));
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn1 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn2 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn3 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn4 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn5 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.radCommandBar1 = new Telerik.WinControls.UI.RadCommandBar();
            this.commandBarRowElement1 = new Telerik.WinControls.UI.CommandBarRowElement();
            this.commandBarStripElement1 = new Telerik.WinControls.UI.CommandBarStripElement();
            this.btnSalir = new Telerik.WinControls.UI.CommandBarButton();
            this.commandBarSeparator1 = new Telerik.WinControls.UI.CommandBarSeparator();
            this.commandBarLabel1 = new Telerik.WinControls.UI.CommandBarLabel();
            this.commandBarStripElement2 = new Telerik.WinControls.UI.CommandBarStripElement();
            this.gvDatos = new Telerik.WinControls.UI.RadGridView();
            this.commandBarStripElement3 = new Telerik.WinControls.UI.CommandBarStripElement();
            ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDatos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDatos.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radCommandBar1
            // 
            this.radCommandBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radCommandBar1.Location = new System.Drawing.Point(0, 0);
            this.radCommandBar1.Name = "radCommandBar1";
            this.radCommandBar1.Rows.AddRange(new Telerik.WinControls.UI.CommandBarRowElement[] {
            this.commandBarRowElement1});
            this.radCommandBar1.Size = new System.Drawing.Size(777, 53);
            this.radCommandBar1.TabIndex = 0;
            // 
            // commandBarRowElement1
            // 
            this.commandBarRowElement1.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.commandBarRowElement1.MinSize = new System.Drawing.Size(25, 25);
            this.commandBarRowElement1.Name = "commandBarRowElement1";
            this.commandBarRowElement1.Strips.AddRange(new Telerik.WinControls.UI.CommandBarStripElement[] {
            this.commandBarStripElement1});
            this.commandBarRowElement1.Text = "";
            this.commandBarRowElement1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.commandBarRowElement1.UseCompatibleTextRendering = false;
            // 
            // commandBarStripElement1
            // 
            this.commandBarStripElement1.DisplayName = "commandBarStripElement1";
            this.commandBarStripElement1.Items.AddRange(new Telerik.WinControls.UI.RadCommandBarBaseItem[] {
            this.btnSalir,
            this.commandBarSeparator1,
            this.commandBarLabel1});
            this.commandBarStripElement1.Name = "commandBarStripElement1";
            // 
            // 
            // 
            this.commandBarStripElement1.OverflowButton.Visibility = Telerik.WinControls.ElementVisibility.Hidden;
            this.commandBarStripElement1.StretchHorizontally = true;
            ((Telerik.WinControls.UI.RadCommandBarOverflowButton)(this.commandBarStripElement1.GetChildAt(2))).Visibility = Telerik.WinControls.ElementVisibility.Hidden;
            // 
            // btnSalir
            // 
            this.btnSalir.DisplayName = "commandBarButton1";
            this.btnSalir.DrawText = true;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // commandBarSeparator1
            // 
            this.commandBarSeparator1.DisplayName = "commandBarSeparator1";
            this.commandBarSeparator1.Name = "commandBarSeparator1";
            this.commandBarSeparator1.VisibleInOverflowMenu = false;
            // 
            // commandBarLabel1
            // 
            this.commandBarLabel1.DisplayName = "commandBarLabel1";
            this.commandBarLabel1.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Bold);
            this.commandBarLabel1.ForeColor = System.Drawing.Color.Navy;
            this.commandBarLabel1.Name = "commandBarLabel1";
            this.commandBarLabel1.StretchHorizontally = true;
            this.commandBarLabel1.Text = "TABULADOR DE SUELDOS";
            // 
            // commandBarStripElement2
            // 
            this.commandBarStripElement2.DisplayName = "commandBarStripElement2";
            this.commandBarStripElement2.Name = "commandBarStripElement2";
            // 
            // gvDatos
            // 
            this.gvDatos.AutoScroll = true;
            this.gvDatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvDatos.Location = new System.Drawing.Point(0, 53);
            // 
            // 
            // 
            this.gvDatos.MasterTemplate.AllowAddNewRow = false;
            this.gvDatos.MasterTemplate.AllowColumnHeaderContextMenu = false;
            this.gvDatos.MasterTemplate.AllowColumnReorder = false;
            this.gvDatos.MasterTemplate.AllowDeleteRow = false;
            this.gvDatos.MasterTemplate.AllowDragToGroup = false;
            this.gvDatos.MasterTemplate.AllowEditRow = false;
            this.gvDatos.MasterTemplate.AllowSearchRow = true;
            this.gvDatos.MasterTemplate.AutoGenerateColumns = false;
            gridViewTextBoxColumn1.FieldName = "Depto.Nombre";
            gridViewTextBoxColumn1.HeaderText = "Departamento";
            gridViewTextBoxColumn1.MaxWidth = 200;
            gridViewTextBoxColumn1.MinWidth = 120;
            gridViewTextBoxColumn1.Name = "Depto";
            gridViewTextBoxColumn1.Width = 120;
            gridViewTextBoxColumn2.FieldName = "Puesto.Nombre";
            gridViewTextBoxColumn2.HeaderText = "Puesto";
            gridViewTextBoxColumn2.MaxWidth = 200;
            gridViewTextBoxColumn2.MinWidth = 150;
            gridViewTextBoxColumn2.Name = "Puesto";
            gridViewTextBoxColumn2.Width = 150;
            gridViewDecimalColumn1.FieldName = "Puntaje";
            gridViewDecimalColumn1.FormatString = "{0:N2}";
            gridViewDecimalColumn1.HeaderText = "Puntaje";
            gridViewDecimalColumn1.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            gridViewDecimalColumn1.Name = "Puntaje";
            gridViewDecimalColumn1.ThousandsSeparator = true;
            gridViewTextBoxColumn3.FieldName = "Puesto.Puntos";
            gridViewTextBoxColumn3.FormatString = "{0:N0}";
            gridViewTextBoxColumn3.HeaderText = "Valor del Punto";
            gridViewTextBoxColumn3.MaxWidth = 100;
            gridViewTextBoxColumn3.MinWidth = 80;
            gridViewTextBoxColumn3.Name = "Puntos";
            gridViewTextBoxColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            gridViewTextBoxColumn3.Width = 80;
            gridViewTextBoxColumn3.WrapText = true;
            gridViewDecimalColumn2.FieldName = "Sueldo85";
            gridViewDecimalColumn2.FormatString = "{0:C2}";
            gridViewDecimalColumn2.HeaderText = "85%";
            gridViewDecimalColumn2.MaxWidth = 100;
            gridViewDecimalColumn2.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            gridViewDecimalColumn2.MinWidth = 80;
            gridViewDecimalColumn2.Name = "Sueldo85";
            gridViewDecimalColumn2.ThousandsSeparator = true;
            gridViewDecimalColumn2.Width = 80;
            gridViewDecimalColumn3.FieldName = "Sueldo90";
            gridViewDecimalColumn3.FormatString = "{0:C2}";
            gridViewDecimalColumn3.HeaderText = "90%";
            gridViewDecimalColumn3.MaxWidth = 100;
            gridViewDecimalColumn3.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            gridViewDecimalColumn3.MinWidth = 80;
            gridViewDecimalColumn3.Name = "Sueldo90";
            gridViewDecimalColumn3.ThousandsSeparator = true;
            gridViewDecimalColumn3.Width = 80;
            gridViewDecimalColumn4.FieldName = "Sueldo95";
            gridViewDecimalColumn4.FormatString = "{0:C2}";
            gridViewDecimalColumn4.HeaderText = "95%";
            gridViewDecimalColumn4.MaxWidth = 100;
            gridViewDecimalColumn4.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            gridViewDecimalColumn4.MinWidth = 80;
            gridViewDecimalColumn4.Name = "Sueldo95";
            gridViewDecimalColumn4.ThousandsSeparator = true;
            gridViewDecimalColumn4.Width = 80;
            gridViewDecimalColumn5.FieldName = "SueldoMax";
            gridViewDecimalColumn5.FormatString = "{0:C2}";
            gridViewDecimalColumn5.HeaderText = "Máximo";
            gridViewDecimalColumn5.MaxWidth = 100;
            gridViewDecimalColumn5.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            gridViewDecimalColumn5.MinWidth = 80;
            gridViewDecimalColumn5.Name = "column1";
            gridViewDecimalColumn5.ThousandsSeparator = true;
            gridViewDecimalColumn5.Width = 80;
            this.gvDatos.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewDecimalColumn1,
            gridViewTextBoxColumn3,
            gridViewDecimalColumn2,
            gridViewDecimalColumn3,
            gridViewDecimalColumn4,
            gridViewDecimalColumn5});
            this.gvDatos.MasterTemplate.ShowRowHeaderColumn = false;
            this.gvDatos.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gvDatos.Name = "gvDatos";
            this.gvDatos.ReadOnly = true;
            this.gvDatos.ShowNoDataText = false;
            this.gvDatos.Size = new System.Drawing.Size(777, 300);
            this.gvDatos.TabIndex = 1;
            // 
            // commandBarStripElement3
            // 
            this.commandBarStripElement3.DisplayName = "commandBarStripElement3";
            this.commandBarStripElement3.Name = "commandBarStripElement3";
            // 
            // frmTabulador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(777, 353);
            this.Controls.Add(this.gvDatos);
            this.Controls.Add(this.radCommandBar1);
            this.Name = "frmTabulador";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowIcon = false;
            this.Text = "TABULADOR SUELDOS";
            this.Load += new System.EventHandler(this.frmTabulador_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDatos.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDatos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadCommandBar radCommandBar1;
        private Telerik.WinControls.UI.CommandBarRowElement commandBarRowElement1;
        private Telerik.WinControls.UI.CommandBarStripElement commandBarStripElement1;
        private Telerik.WinControls.UI.CommandBarButton btnSalir;
        private Telerik.WinControls.UI.CommandBarSeparator commandBarSeparator1;
        private Telerik.WinControls.UI.CommandBarLabel commandBarLabel1;
        private Telerik.WinControls.UI.CommandBarStripElement commandBarStripElement2;
        private Telerik.WinControls.UI.RadGridView gvDatos;
        private Telerik.WinControls.UI.CommandBarStripElement commandBarStripElement3;
    }
}
