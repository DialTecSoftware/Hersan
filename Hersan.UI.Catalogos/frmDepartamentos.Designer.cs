﻿namespace Hersan.UI.Catalogos
{
    partial class frmDepartamentos
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDepartamentos));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtAbrev = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.radPanel2 = new Telerik.WinControls.UI.RadPanel();
            this.gvDatos = new Telerik.WinControls.UI.RadGridView();
            this.commandBarStripElement2 = new Telerik.WinControls.UI.CommandBarStripElement();
            this.commandBarStripElement3 = new Telerik.WinControls.UI.CommandBarStripElement();
            this.commandBarStripElement4 = new Telerik.WinControls.UI.CommandBarStripElement();
            this.commandBarRowElement3 = new Telerik.WinControls.UI.CommandBarRowElement();
            this.commandBarRowElement1 = new Telerik.WinControls.UI.CommandBarRowElement();
            this.commandBarStripElement1 = new Telerik.WinControls.UI.CommandBarStripElement();
            this.btnNuevo = new Telerik.WinControls.UI.CommandBarButton();
            this.btnGuardar = new Telerik.WinControls.UI.CommandBarButton();
            this.btnEliminar = new Telerik.WinControls.UI.CommandBarButton();
            this.commandBarSeparator3 = new Telerik.WinControls.UI.CommandBarSeparator();
            this.btnSalir = new Telerik.WinControls.UI.CommandBarButton();
            this.commandBarLabel1 = new Telerik.WinControls.UI.CommandBarLabel();
            this.commandBarRowElement2 = new Telerik.WinControls.UI.CommandBarRowElement();
            this.radCommandBar1 = new Telerik.WinControls.UI.RadCommandBar();
            this.commandBarRowElement4 = new Telerik.WinControls.UI.CommandBarRowElement();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).BeginInit();
            this.radPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvDatos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDatos.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 27);
            this.label2.TabIndex = 0;
            this.label2.Text = "label2";
            // 
            // radPanel1
            // 
            this.radPanel1.Controls.Add(this.txtId);
            this.radPanel1.Controls.Add(this.txtAbrev);
            this.radPanel1.Controls.Add(this.label4);
            this.radPanel1.Controls.Add(this.txtNombre);
            this.radPanel1.Controls.Add(this.label3);
            this.radPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radPanel1.Location = new System.Drawing.Point(0, 113);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(556, 87);
            this.radPanel1.TabIndex = 1;
            this.radPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.radPanel1_Paint);
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(289, 17);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(100, 20);
            this.txtId.TabIndex = 4;
            this.txtId.Visible = false;
            // 
            // txtAbrev
            // 
            this.txtAbrev.Location = new System.Drawing.Point(59, 45);
            this.txtAbrev.MaxLength = 5;
            this.txtAbrev.Name = "txtAbrev";
            this.txtAbrev.Size = new System.Drawing.Size(67, 20);
            this.txtAbrev.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Abrev.";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(59, 17);
            this.txtNombre.MaxLength = 40;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(166, 20);
            this.txtNombre.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Nombre:";
            // 
            // radPanel2
            // 
            this.radPanel2.Controls.Add(this.gvDatos);
            this.radPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radPanel2.Location = new System.Drawing.Point(0, 200);
            this.radPanel2.Name = "radPanel2";
            this.radPanel2.Size = new System.Drawing.Size(556, 136);
            this.radPanel2.TabIndex = 2;
            // 
            // gvDatos
            // 
            this.gvDatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvDatos.Location = new System.Drawing.Point(0, 0);
            // 
            // 
            // 
            this.gvDatos.MasterTemplate.AllowAddNewRow = false;
            this.gvDatos.MasterTemplate.AllowColumnReorder = false;
            this.gvDatos.MasterTemplate.AllowDeleteRow = false;
            this.gvDatos.MasterTemplate.AllowDragToGroup = false;
            this.gvDatos.MasterTemplate.AllowEditRow = false;
            gridViewTextBoxColumn4.FieldName = "Id";
            gridViewTextBoxColumn4.HeaderText = "ID";
            gridViewTextBoxColumn4.IsVisible = false;
            gridViewTextBoxColumn4.Name = "Id";
            gridViewTextBoxColumn5.FieldName = "Nombre";
            gridViewTextBoxColumn5.HeaderText = "Nombre";
            gridViewTextBoxColumn5.MaxWidth = 300;
            gridViewTextBoxColumn5.MinWidth = 150;
            gridViewTextBoxColumn5.Name = "Nombre";
            gridViewTextBoxColumn5.Width = 150;
            gridViewTextBoxColumn5.WrapText = true;
            gridViewTextBoxColumn6.FieldName = "Abrev";
            gridViewTextBoxColumn6.HeaderText = "Abreviatura";
            gridViewTextBoxColumn6.MaxWidth = 100;
            gridViewTextBoxColumn6.MinWidth = 80;
            gridViewTextBoxColumn6.Name = "Abrev";
            gridViewTextBoxColumn6.Width = 80;
            this.gvDatos.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6});
            this.gvDatos.MasterTemplate.ShowRowHeaderColumn = false;
            this.gvDatos.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.gvDatos.Name = "gvDatos";
            this.gvDatos.ShowGroupPanel = false;
            this.gvDatos.ShowNoDataText = false;
            this.gvDatos.ShowRowErrors = false;
            this.gvDatos.Size = new System.Drawing.Size(556, 136);
            this.gvDatos.TabIndex = 0;
            this.gvDatos.Click += new System.EventHandler(this.gvDatos_Click);
            // 
            // commandBarStripElement2
            // 
            this.commandBarStripElement2.DisplayName = "commandBarStripElement2";
            this.commandBarStripElement2.Name = "commandBarStripElement2";
            // 
            // commandBarStripElement3
            // 
            this.commandBarStripElement3.DisplayName = "commandBarStripElement3";
            this.commandBarStripElement3.Name = "commandBarStripElement3";
            // 
            // commandBarStripElement4
            // 
            this.commandBarStripElement4.DisplayName = "commandBarStripElement4";
            this.commandBarStripElement4.Name = "commandBarStripElement4";
            // 
            // commandBarRowElement3
            // 
            this.commandBarRowElement3.MinSize = new System.Drawing.Size(25, 25);
            this.commandBarRowElement3.Name = "commandBarRowElement3";
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
            this.commandBarStripElement1.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.commandBarStripElement1.DisplayName = "commandBarStripElement1";
            this.commandBarStripElement1.Items.AddRange(new Telerik.WinControls.UI.RadCommandBarBaseItem[] {
            this.btnNuevo,
            this.btnGuardar,
            this.btnEliminar,
            this.commandBarSeparator3,
            this.btnSalir,
            this.commandBarLabel1});
            this.commandBarStripElement1.Name = "commandBarStripElement1";
            // 
            // 
            // 
            this.commandBarStripElement1.OverflowButton.Visibility = Telerik.WinControls.ElementVisibility.Hidden;
            this.commandBarStripElement1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.commandBarStripElement1.UseCompatibleTextRendering = false;
            ((Telerik.WinControls.UI.RadCommandBarOverflowButton)(this.commandBarStripElement1.GetChildAt(2))).Visibility = Telerik.WinControls.ElementVisibility.Hidden;
            // 
            // btnNuevo
            // 
            this.btnNuevo.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnNuevo.DisplayName = "Nuevo";
            this.btnNuevo.DrawText = true;
            this.btnNuevo.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevo.Image")));
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnNuevo.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnNuevo.UseCompatibleTextRendering = false;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnGuardar.DisplayName = "Guardar";
            this.btnGuardar.DrawText = true;
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnGuardar.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnGuardar.UseCompatibleTextRendering = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnEliminar.DisplayName = "commandBarButton3";
            this.btnEliminar.DrawText = true;
            this.btnEliminar.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminar.Image")));
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Text = "Actualizar";
            this.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnEliminar.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnEliminar.UseCompatibleTextRendering = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // commandBarSeparator3
            // 
            this.commandBarSeparator3.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.commandBarSeparator3.DisplayName = "commandBarSeparator3";
            this.commandBarSeparator3.Name = "commandBarSeparator3";
            this.commandBarSeparator3.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.commandBarSeparator3.UseCompatibleTextRendering = false;
            this.commandBarSeparator3.VisibleInOverflowMenu = false;
            // 
            // btnSalir
            // 
            this.btnSalir.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnSalir.DisplayName = "commandBarButton4";
            this.btnSalir.DrawText = true;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSalir.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnSalir.UseCompatibleTextRendering = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // commandBarLabel1
            // 
            this.commandBarLabel1.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.commandBarLabel1.DisplayName = "commandBarLabel1";
            this.commandBarLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.commandBarLabel1.ForeColor = System.Drawing.Color.Navy;
            this.commandBarLabel1.Name = "commandBarLabel1";
            this.commandBarLabel1.StretchHorizontally = true;
            this.commandBarLabel1.Text = "CATALOGO DE DEPARTAMENTOS";
            this.commandBarLabel1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.commandBarLabel1.UseCompatibleTextRendering = false;
            // 
            // commandBarRowElement2
            // 
            this.commandBarRowElement2.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.commandBarRowElement2.MinSize = new System.Drawing.Size(25, 25);
            this.commandBarRowElement2.Name = "commandBarRowElement2";
            this.commandBarRowElement2.Text = "";
            this.commandBarRowElement2.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.commandBarRowElement2.UseCompatibleTextRendering = false;
            // 
            // radCommandBar1
            // 
            this.radCommandBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radCommandBar1.Location = new System.Drawing.Point(0, 0);
            this.radCommandBar1.Name = "radCommandBar1";
            this.radCommandBar1.Rows.AddRange(new Telerik.WinControls.UI.CommandBarRowElement[] {
            this.commandBarRowElement1,
            this.commandBarRowElement2,
            this.commandBarRowElement4});
            this.radCommandBar1.Size = new System.Drawing.Size(556, 113);
            this.radCommandBar1.TabIndex = 0;
            // 
            // commandBarRowElement4
            // 
            this.commandBarRowElement4.MinSize = new System.Drawing.Size(25, 25);
            this.commandBarRowElement4.Name = "commandBarRowElement4";
            // 
            // frmDepartamentos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 336);
            this.Controls.Add(this.radPanel2);
            this.Controls.Add(this.radPanel1);
            this.Controls.Add(this.radCommandBar1);
            this.Name = "frmDepartamentos";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Departamentos";
            this.Load += new System.EventHandler(this.frmDepartamentos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            this.radPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).EndInit();
            this.radPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvDatos.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDatos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Telerik.WinControls.UI.RadPanel radPanel1;
        private System.Windows.Forms.TextBox txtAbrev;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label3;
        private Telerik.WinControls.UI.RadPanel radPanel2;
        private Telerik.WinControls.UI.RadGridView gvDatos;
        private Telerik.WinControls.UI.CommandBarStripElement commandBarStripElement2;
        private System.Windows.Forms.TextBox txtId;
        private Telerik.WinControls.UI.CommandBarStripElement commandBarStripElement3;
        private Telerik.WinControls.UI.CommandBarStripElement commandBarStripElement4;
        private Telerik.WinControls.UI.CommandBarRowElement commandBarRowElement3;
        private Telerik.WinControls.UI.CommandBarRowElement commandBarRowElement1;
        private Telerik.WinControls.UI.CommandBarStripElement commandBarStripElement1;
        private Telerik.WinControls.UI.CommandBarButton btnNuevo;
        private Telerik.WinControls.UI.CommandBarButton btnGuardar;
        private Telerik.WinControls.UI.CommandBarButton btnEliminar;
        private Telerik.WinControls.UI.CommandBarSeparator commandBarSeparator3;
        private Telerik.WinControls.UI.CommandBarButton btnSalir;
        private Telerik.WinControls.UI.CommandBarLabel commandBarLabel1;
        private Telerik.WinControls.UI.CommandBarRowElement commandBarRowElement2;
        private Telerik.WinControls.UI.RadCommandBar radCommandBar1;
        private Telerik.WinControls.UI.CommandBarRowElement commandBarRowElement4;
    }
}
