﻿namespace Hersan.UI.Catalogos
{
    partial class frmContactos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmContactos));
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn1 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn2 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.radCommandBar1 = new Telerik.WinControls.UI.RadCommandBar();
            this.commandBarRowElement1 = new Telerik.WinControls.UI.CommandBarRowElement();
            this.commandBarStripElement1 = new Telerik.WinControls.UI.CommandBarStripElement();
            this.btnNuevo = new Telerik.WinControls.UI.CommandBarButton();
            this.commandBarSeparator1 = new Telerik.WinControls.UI.CommandBarSeparator();
            this.btnGuardar = new Telerik.WinControls.UI.CommandBarButton();
            this.commandBarSeparator2 = new Telerik.WinControls.UI.CommandBarSeparator();
            this.btnEliminar = new Telerik.WinControls.UI.CommandBarButton();
            this.commandBarSeparator3 = new Telerik.WinControls.UI.CommandBarSeparator();
            this.btnSalir = new Telerik.WinControls.UI.CommandBarButton();
            this.commandBarSeparator4 = new Telerik.WinControls.UI.CommandBarSeparator();
            this.commandBarLabel1 = new Telerik.WinControls.UI.CommandBarLabel();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.chkInterno = new System.Windows.Forms.CheckBox();
            this.chkEstatus = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.gvDatos = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
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
            this.radCommandBar1.Size = new System.Drawing.Size(497, 56);
            this.radCommandBar1.TabIndex = 0;
            // 
            // commandBarRowElement1
            // 
            this.commandBarRowElement1.MinSize = new System.Drawing.Size(25, 25);
            this.commandBarRowElement1.Name = "commandBarRowElement1";
            this.commandBarRowElement1.Strips.AddRange(new Telerik.WinControls.UI.CommandBarStripElement[] {
            this.commandBarStripElement1});
            // 
            // commandBarStripElement1
            // 
            this.commandBarStripElement1.DisplayName = "commandBarStripElement1";
            this.commandBarStripElement1.Items.AddRange(new Telerik.WinControls.UI.RadCommandBarBaseItem[] {
            this.btnNuevo,
            this.commandBarSeparator1,
            this.btnGuardar,
            this.commandBarSeparator2,
            this.btnEliminar,
            this.commandBarSeparator3,
            this.btnSalir,
            this.commandBarSeparator4,
            this.commandBarLabel1});
            this.commandBarStripElement1.Name = "commandBarStripElement1";
            // 
            // 
            // 
            this.commandBarStripElement1.OverflowButton.Visibility = Telerik.WinControls.ElementVisibility.Hidden;
            this.commandBarStripElement1.StretchHorizontally = true;
            ((Telerik.WinControls.UI.RadCommandBarOverflowButton)(this.commandBarStripElement1.GetChildAt(2))).Visibility = Telerik.WinControls.ElementVisibility.Hidden;
            // 
            // btnNuevo
            // 
            this.btnNuevo.DisplayName = "commandBarButton1";
            this.btnNuevo.DrawText = true;
            this.btnNuevo.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevo.Image")));
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // commandBarSeparator1
            // 
            this.commandBarSeparator1.DisplayName = "commandBarSeparator1";
            this.commandBarSeparator1.Name = "commandBarSeparator1";
            this.commandBarSeparator1.VisibleInOverflowMenu = false;
            // 
            // btnGuardar
            // 
            this.btnGuardar.DisplayName = "commandBarButton2";
            this.btnGuardar.DrawText = true;
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // commandBarSeparator2
            // 
            this.commandBarSeparator2.DisplayName = "commandBarSeparator2";
            this.commandBarSeparator2.Name = "commandBarSeparator2";
            this.commandBarSeparator2.VisibleInOverflowMenu = false;
            // 
            // btnEliminar
            // 
            this.btnEliminar.DisplayName = "commandBarButton3";
            this.btnEliminar.DrawText = true;
            this.btnEliminar.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminar.Image")));
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // commandBarSeparator3
            // 
            this.commandBarSeparator3.DisplayName = "commandBarSeparator3";
            this.commandBarSeparator3.Name = "commandBarSeparator3";
            this.commandBarSeparator3.VisibleInOverflowMenu = false;
            // 
            // btnSalir
            // 
            this.btnSalir.DisplayName = "commandBarButton4";
            this.btnSalir.DrawText = true;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // commandBarSeparator4
            // 
            this.commandBarSeparator4.DisplayName = "commandBarSeparator4";
            this.commandBarSeparator4.Name = "commandBarSeparator4";
            this.commandBarSeparator4.VisibleInOverflowMenu = false;
            // 
            // commandBarLabel1
            // 
            this.commandBarLabel1.DisplayName = "commandBarLabel1";
            this.commandBarLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.commandBarLabel1.ForeColor = System.Drawing.Color.Navy;
            this.commandBarLabel1.Name = "commandBarLabel1";
            this.commandBarLabel1.StretchHorizontally = true;
            this.commandBarLabel1.Text = "CATALOGO DE CONTACTOS";
            // 
            // radPanel1
            // 
            this.radPanel1.Controls.Add(this.chkInterno);
            this.radPanel1.Controls.Add(this.chkEstatus);
            this.radPanel1.Controls.Add(this.label1);
            this.radPanel1.Controls.Add(this.txtId);
            this.radPanel1.Controls.Add(this.txtNombre);
            this.radPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radPanel1.Location = new System.Drawing.Point(0, 56);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(497, 73);
            this.radPanel1.TabIndex = 1;
            // 
            // chkInterno
            // 
            this.chkInterno.AutoSize = true;
            this.chkInterno.Location = new System.Drawing.Point(12, 46);
            this.chkInterno.Name = "chkInterno";
            this.chkInterno.Size = new System.Drawing.Size(64, 17);
            this.chkInterno.TabIndex = 13;
            this.chkInterno.Text = "Interno";
            this.chkInterno.UseVisualStyleBackColor = true;
            // 
            // chkEstatus
            // 
            this.chkEstatus.AutoSize = true;
            this.chkEstatus.Location = new System.Drawing.Point(302, 21);
            this.chkEstatus.Name = "chkEstatus";
            this.chkEstatus.Size = new System.Drawing.Size(57, 17);
            this.chkEstatus.TabIndex = 14;
            this.chkEstatus.Text = "Activo";
            this.chkEstatus.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Contacto:";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(416, 20);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(54, 20);
            this.txtId.TabIndex = 11;
            this.txtId.Visible = false;
            // 
            // txtNombre
            // 
            this.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNombre.Location = new System.Drawing.Point(75, 19);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(221, 20);
            this.txtNombre.TabIndex = 10;
            // 
            // gvDatos
            // 
            this.gvDatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvDatos.Location = new System.Drawing.Point(0, 129);
            // 
            // 
            // 
            this.gvDatos.MasterTemplate.AllowAddNewRow = false;
            this.gvDatos.MasterTemplate.AllowColumnReorder = false;
            this.gvDatos.MasterTemplate.AllowDeleteRow = false;
            this.gvDatos.MasterTemplate.AllowDragToGroup = false;
            this.gvDatos.MasterTemplate.AllowEditRow = false;
            gridViewTextBoxColumn1.FieldName = "Id";
            gridViewTextBoxColumn1.HeaderText = "ID";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "Id";
            gridViewTextBoxColumn2.FieldName = "Nombre";
            gridViewTextBoxColumn2.HeaderText = "Nombre";
            gridViewTextBoxColumn2.MaxWidth = 300;
            gridViewTextBoxColumn2.MinWidth = 200;
            gridViewTextBoxColumn2.Name = "Nombre";
            gridViewTextBoxColumn2.Width = 200;
            gridViewTextBoxColumn2.WrapText = true;
            gridViewCheckBoxColumn1.FieldName = "Interno";
            gridViewCheckBoxColumn1.HeaderText = "Interno";
            gridViewCheckBoxColumn1.MinWidth = 100;
            gridViewCheckBoxColumn1.Name = "Interno";
            gridViewCheckBoxColumn1.Width = 100;
            gridViewCheckBoxColumn2.FieldName = "DatosUsuario.Estatus";
            gridViewCheckBoxColumn2.HeaderText = "Estatus";
            gridViewCheckBoxColumn2.MaxWidth = 100;
            gridViewCheckBoxColumn2.MinWidth = 100;
            gridViewCheckBoxColumn2.Name = "Estatus";
            gridViewCheckBoxColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCheckBoxColumn2.Width = 100;
            this.gvDatos.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewCheckBoxColumn1,
            gridViewCheckBoxColumn2});
            this.gvDatos.MasterTemplate.ShowRowHeaderColumn = false;
            this.gvDatos.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gvDatos.Name = "gvDatos";
            this.gvDatos.ShowGroupPanel = false;
            this.gvDatos.ShowNoDataText = false;
            this.gvDatos.ShowRowErrors = false;
            this.gvDatos.Size = new System.Drawing.Size(497, 196);
            this.gvDatos.TabIndex = 5;
            this.gvDatos.CurrentRowChanged += new Telerik.WinControls.UI.CurrentRowChangedEventHandler(this.gvDatos_CurrentRowChanged);
            // 
            // frmContactos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 325);
            this.Controls.Add(this.gvDatos);
            this.Controls.Add(this.radPanel1);
            this.Controls.Add(this.radCommandBar1);
            this.Name = "frmContactos";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowIcon = false;
            this.Text = "Contactos";
            this.ThemeName = "MaterialTeal";
            this.Load += new System.EventHandler(this.Contactos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            this.radPanel1.PerformLayout();
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
        private Telerik.WinControls.UI.CommandBarButton btnNuevo;
        private Telerik.WinControls.UI.CommandBarSeparator commandBarSeparator1;
        private Telerik.WinControls.UI.CommandBarButton btnGuardar;
        private Telerik.WinControls.UI.CommandBarSeparator commandBarSeparator2;
        private Telerik.WinControls.UI.CommandBarButton btnEliminar;
        private Telerik.WinControls.UI.CommandBarSeparator commandBarSeparator3;
        private Telerik.WinControls.UI.CommandBarButton btnSalir;
        private Telerik.WinControls.UI.CommandBarSeparator commandBarSeparator4;
        private Telerik.WinControls.UI.CommandBarLabel commandBarLabel1;
        private Telerik.WinControls.UI.RadPanel radPanel1;
        private Telerik.WinControls.UI.RadGridView gvDatos;
        private System.Windows.Forms.CheckBox chkInterno;
        private System.Windows.Forms.CheckBox chkEstatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtNombre;
    }
}
