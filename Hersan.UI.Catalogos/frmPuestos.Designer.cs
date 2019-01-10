namespace Hersan.UI.Catalogos
{
    partial class frmPuestos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPuestos));
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.txtIdDep = new System.Windows.Forms.TextBox();
            this.txtIdPuesto = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtAbrev = new System.Windows.Forms.TextBox();
            this.radCommandBar1 = new Telerik.WinControls.UI.RadCommandBar();
            this.commandBarRowElement1 = new Telerik.WinControls.UI.CommandBarRowElement();
            this.commandBarStripElement1 = new Telerik.WinControls.UI.CommandBarStripElement();
            this.btnNuevo = new Telerik.WinControls.UI.CommandBarButton();
            this.btnGuardar = new Telerik.WinControls.UI.CommandBarButton();
            this.commandBarButton3 = new Telerik.WinControls.UI.CommandBarButton();
            this.btnSalir = new Telerik.WinControls.UI.CommandBarButton();
            this.commandBarStripElement2 = new Telerik.WinControls.UI.CommandBarStripElement();
            this.commandBarLabel1 = new Telerik.WinControls.UI.CommandBarLabel();
            this.gvPuestos = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPuestos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPuestos.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radPanel1
            // 
            this.radPanel1.Controls.Add(this.txtIdDep);
            this.radPanel1.Controls.Add(this.txtIdPuesto);
            this.radPanel1.Controls.Add(this.label2);
            this.radPanel1.Controls.Add(this.label1);
            this.radPanel1.Controls.Add(this.txtNombre);
            this.radPanel1.Controls.Add(this.txtAbrev);
            this.radPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radPanel1.Location = new System.Drawing.Point(0, 56);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(515, 96);
            this.radPanel1.TabIndex = 1;
            this.radPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.radPanel1_Paint);
            // 
            // txtIdDep
            // 
            this.txtIdDep.Location = new System.Drawing.Point(364, 46);
            this.txtIdDep.Name = "txtIdDep";
            this.txtIdDep.Size = new System.Drawing.Size(80, 20);
            this.txtIdDep.TabIndex = 5;
            // 
            // txtIdPuesto
            // 
            this.txtIdPuesto.Location = new System.Drawing.Point(364, 16);
            this.txtIdPuesto.Name = "txtIdPuesto";
            this.txtIdPuesto.Size = new System.Drawing.Size(80, 20);
            this.txtIdPuesto.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Abrev. :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nombre :";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(102, 20);
            this.txtNombre.MaxLength = 40;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(166, 20);
            this.txtNombre.TabIndex = 1;
            // 
            // txtAbrev
            // 
            this.txtAbrev.Location = new System.Drawing.Point(102, 46);
            this.txtAbrev.MaxLength = 5;
            this.txtAbrev.Name = "txtAbrev";
            this.txtAbrev.Size = new System.Drawing.Size(87, 20);
            this.txtAbrev.TabIndex = 0;
            // 
            // radCommandBar1
            // 
            this.radCommandBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radCommandBar1.Location = new System.Drawing.Point(0, 0);
            this.radCommandBar1.Name = "radCommandBar1";
            this.radCommandBar1.Rows.AddRange(new Telerik.WinControls.UI.CommandBarRowElement[] {
            this.commandBarRowElement1});
            this.radCommandBar1.Size = new System.Drawing.Size(515, 56);
            this.radCommandBar1.TabIndex = 0;
            // 
            // commandBarRowElement1
            // 
            this.commandBarRowElement1.MinSize = new System.Drawing.Size(25, 25);
            this.commandBarRowElement1.Name = "commandBarRowElement1";
            this.commandBarRowElement1.Strips.AddRange(new Telerik.WinControls.UI.CommandBarStripElement[] {
            this.commandBarStripElement1,
            this.commandBarStripElement2});
            // 
            // commandBarStripElement1
            // 
            this.commandBarStripElement1.DisplayName = "commandBarStripElement1";
            this.commandBarStripElement1.Items.AddRange(new Telerik.WinControls.UI.RadCommandBarBaseItem[] {
            this.btnNuevo,
            this.btnGuardar,
            this.commandBarButton3,
            this.btnSalir});
            this.commandBarStripElement1.Name = "commandBarStripElement1";
            // 
            // btnNuevo
            // 
            this.btnNuevo.DisplayName = "commandBarButton1";
            this.btnNuevo.DrawText = true;
            this.btnNuevo.EnableBorderHighlight = false;
            this.btnNuevo.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevo.Image")));
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // btnGuardar
            // 
            this.btnGuardar.DisplayName = "commandBarButton2";
            this.btnGuardar.DrawText = true;
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // commandBarButton3
            // 
            this.commandBarButton3.DisplayName = "commandBarButton3";
            this.commandBarButton3.Image = ((System.Drawing.Image)(resources.GetObject("commandBarButton3.Image")));
            this.commandBarButton3.Name = "commandBarButton3";
            this.commandBarButton3.Text = "commandBarButton3";
            // 
            // btnSalir
            // 
            this.btnSalir.AccessibleDescription = "Salir";
            this.btnSalir.DisplayName = "commandBarButton4";
            this.btnSalir.DrawText = true;
            this.btnSalir.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Text = "Salir ";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // commandBarStripElement2
            // 
            this.commandBarStripElement2.DisplayName = "commandBarStripElement2";
            this.commandBarStripElement2.Items.AddRange(new Telerik.WinControls.UI.RadCommandBarBaseItem[] {
            this.commandBarLabel1});
            this.commandBarStripElement2.Name = "commandBarStripElement2";
            // 
            // commandBarLabel1
            // 
            this.commandBarLabel1.DisplayName = "commandBarLabel1";
            this.commandBarLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.commandBarLabel1.ForeColor = System.Drawing.Color.Navy;
            this.commandBarLabel1.Name = "commandBarLabel1";
            this.commandBarLabel1.Text = "CATALOGO DE PUESTOS ";
            // 
            // gvPuestos
            // 
            this.gvPuestos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvPuestos.Location = new System.Drawing.Point(0, 152);
            // 
            // 
            // 
            this.gvPuestos.MasterTemplate.AllowAddNewRow = false;
            this.gvPuestos.MasterTemplate.AllowColumnReorder = false;
            this.gvPuestos.MasterTemplate.AllowDeleteRow = false;
            this.gvPuestos.MasterTemplate.AllowDragToGroup = false;
            this.gvPuestos.MasterTemplate.AllowEditRow = false;
            gridViewTextBoxColumn5.FieldName = "Nombre";
            gridViewTextBoxColumn5.HeaderText = "Nombre";
            gridViewTextBoxColumn5.MaxWidth = 300;
            gridViewTextBoxColumn5.MinWidth = 150;
            gridViewTextBoxColumn5.Name = "Nombre";
            gridViewTextBoxColumn5.Width = 150;
            gridViewTextBoxColumn5.WrapText = true;
            gridViewTextBoxColumn6.FieldName = "Id_puesto";
            gridViewTextBoxColumn6.HeaderText = "ID";
            gridViewTextBoxColumn6.IsVisible = false;
            gridViewTextBoxColumn6.Name = "Id_puesto";
            gridViewTextBoxColumn7.FieldName = "Abrev";
            gridViewTextBoxColumn7.HeaderText = "Abreviatura";
            gridViewTextBoxColumn7.MaxWidth = 100;
            gridViewTextBoxColumn7.MinWidth = 80;
            gridViewTextBoxColumn7.Name = "Abrev";
            gridViewTextBoxColumn7.Width = 80;
            gridViewTextBoxColumn8.FieldName = "departamentos.Id";
            gridViewTextBoxColumn8.HeaderText = "Id_dep";
            gridViewTextBoxColumn8.MaxWidth = 100;
            gridViewTextBoxColumn8.MinWidth = 80;
            gridViewTextBoxColumn8.Name = "departamentos.Id";
            gridViewTextBoxColumn8.Width = 80;
            this.gvPuestos.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8});
            this.gvPuestos.MasterTemplate.ShowRowHeaderColumn = false;
            this.gvPuestos.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.gvPuestos.Name = "gvPuestos";
            this.gvPuestos.ShowGroupPanel = false;
            this.gvPuestos.ShowNoDataText = false;
            this.gvPuestos.ShowRowErrors = false;
            this.gvPuestos.Size = new System.Drawing.Size(515, 181);
            this.gvPuestos.TabIndex = 2;
            this.gvPuestos.Click += new System.EventHandler(this.gvPuestos_Click);
            // 
            // frmPuestos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 333);
            this.Controls.Add(this.gvPuestos);
            this.Controls.Add(this.radPanel1);
            this.Controls.Add(this.radCommandBar1);
            this.Name = "frmPuestos";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Puestos";
            this.Load += new System.EventHandler(this.frmPuestos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            this.radPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPuestos.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPuestos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Telerik.WinControls.UI.RadPanel radPanel1;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtAbrev;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIdPuesto;
        private System.Windows.Forms.TextBox txtIdDep;
        private Telerik.WinControls.UI.RadCommandBar radCommandBar1;
        private Telerik.WinControls.UI.CommandBarRowElement commandBarRowElement1;
        private Telerik.WinControls.UI.CommandBarStripElement commandBarStripElement1;
        private Telerik.WinControls.UI.CommandBarButton btnNuevo;
        private Telerik.WinControls.UI.CommandBarButton btnGuardar;
        private Telerik.WinControls.UI.CommandBarButton commandBarButton3;
        private Telerik.WinControls.UI.CommandBarButton btnSalir;
        private Telerik.WinControls.UI.CommandBarStripElement commandBarStripElement2;
        private Telerik.WinControls.UI.CommandBarLabel commandBarLabel1;
        private Telerik.WinControls.UI.RadGridView gvPuestos;
    }
}
