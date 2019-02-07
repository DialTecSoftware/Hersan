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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn1 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.cboEntidad = new Telerik.WinControls.UI.RadDropDownList();
            this.label5 = new System.Windows.Forms.Label();
            this.chkEstatus = new System.Windows.Forms.CheckBox();
            this.cboDeptos = new Telerik.WinControls.UI.RadDropDownList();
            this.label3 = new System.Windows.Forms.Label();
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
            this.commandBarSeparator1 = new Telerik.WinControls.UI.CommandBarSeparator();
            this.btnGuardar = new Telerik.WinControls.UI.CommandBarButton();
            this.commandBarSeparator2 = new Telerik.WinControls.UI.CommandBarSeparator();
            this.btnEliminar = new Telerik.WinControls.UI.CommandBarButton();
            this.commandBarSeparator3 = new Telerik.WinControls.UI.CommandBarSeparator();
            this.btnSalir = new Telerik.WinControls.UI.CommandBarButton();
            this.commandBarSeparator4 = new Telerik.WinControls.UI.CommandBarSeparator();
            this.commandBarLabel1 = new Telerik.WinControls.UI.CommandBarLabel();
            this.gvPuestos = new Telerik.WinControls.UI.RadGridView();
            this.commandBarStripElement2 = new Telerik.WinControls.UI.CommandBarStripElement();
            this.commandBarStripElement3 = new Telerik.WinControls.UI.CommandBarStripElement();
            this.commandBarStripElement4 = new Telerik.WinControls.UI.CommandBarStripElement();
            this.commandBarStripElement5 = new Telerik.WinControls.UI.CommandBarStripElement();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboEntidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDeptos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPuestos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPuestos.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radPanel1
            // 
            this.radPanel1.Controls.Add(this.cboEntidad);
            this.radPanel1.Controls.Add(this.label5);
            this.radPanel1.Controls.Add(this.chkEstatus);
            this.radPanel1.Controls.Add(this.cboDeptos);
            this.radPanel1.Controls.Add(this.label3);
            this.radPanel1.Controls.Add(this.txtIdDep);
            this.radPanel1.Controls.Add(this.txtIdPuesto);
            this.radPanel1.Controls.Add(this.label2);
            this.radPanel1.Controls.Add(this.label1);
            this.radPanel1.Controls.Add(this.txtNombre);
            this.radPanel1.Controls.Add(this.txtAbrev);
            this.radPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radPanel1.Location = new System.Drawing.Point(0, 53);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(657, 130);
            this.radPanel1.TabIndex = 1;
            // 
            // cboEntidad
            // 
            this.cboEntidad.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.cboEntidad.Location = new System.Drawing.Point(72, 16);
            this.cboEntidad.Name = "cboEntidad";
            this.cboEntidad.Size = new System.Drawing.Size(166, 20);
            this.cboEntidad.TabIndex = 1;
            this.cboEntidad.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.cboEntidad_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Entidad:";
            // 
            // chkEstatus
            // 
            this.chkEstatus.AutoSize = true;
            this.chkEstatus.Location = new System.Drawing.Point(181, 90);
            this.chkEstatus.Name = "chkEstatus";
            this.chkEstatus.Size = new System.Drawing.Size(57, 17);
            this.chkEstatus.TabIndex = 5;
            this.chkEstatus.Text = "Activo";
            this.chkEstatus.UseVisualStyleBackColor = true;
            // 
            // cboDeptos
            // 
            this.cboDeptos.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.cboDeptos.Location = new System.Drawing.Point(72, 40);
            this.cboDeptos.Name = "cboDeptos";
            this.cboDeptos.Size = new System.Drawing.Size(233, 20);
            this.cboDeptos.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Depto.:";
            // 
            // txtIdDep
            // 
            this.txtIdDep.Location = new System.Drawing.Point(545, 37);
            this.txtIdDep.Name = "txtIdDep";
            this.txtIdDep.Size = new System.Drawing.Size(80, 20);
            this.txtIdDep.TabIndex = 5;
            this.txtIdDep.Visible = false;
            // 
            // txtIdPuesto
            // 
            this.txtIdPuesto.Location = new System.Drawing.Point(545, 14);
            this.txtIdPuesto.Name = "txtIdPuesto";
            this.txtIdPuesto.Size = new System.Drawing.Size(80, 20);
            this.txtIdPuesto.TabIndex = 4;
            this.txtIdPuesto.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Abrev. :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nombre :";
            // 
            // txtNombre
            // 
            this.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNombre.Location = new System.Drawing.Point(72, 64);
            this.txtNombre.MaxLength = 40;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(233, 20);
            this.txtNombre.TabIndex = 3;
            // 
            // txtAbrev
            // 
            this.txtAbrev.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAbrev.Location = new System.Drawing.Point(72, 87);
            this.txtAbrev.MaxLength = 5;
            this.txtAbrev.Name = "txtAbrev";
            this.txtAbrev.Size = new System.Drawing.Size(87, 20);
            this.txtAbrev.TabIndex = 4;
            // 
            // radCommandBar1
            // 
            this.radCommandBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radCommandBar1.Location = new System.Drawing.Point(0, 0);
            this.radCommandBar1.Name = "radCommandBar1";
            this.radCommandBar1.Rows.AddRange(new Telerik.WinControls.UI.CommandBarRowElement[] {
            this.commandBarRowElement1});
            this.radCommandBar1.Size = new System.Drawing.Size(657, 53);
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
            this.btnNuevo.EnableBorderHighlight = false;
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
            this.btnEliminar.DisplayName = "Eliminar";
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
            this.commandBarLabel1.Text = "CATALOGO DE PUESTOS";
            // 
            // gvPuestos
            // 
            this.gvPuestos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvPuestos.Location = new System.Drawing.Point(0, 183);
            // 
            // 
            // 
            this.gvPuestos.MasterTemplate.AllowAddNewRow = false;
            this.gvPuestos.MasterTemplate.AllowColumnReorder = false;
            this.gvPuestos.MasterTemplate.AllowDeleteRow = false;
            this.gvPuestos.MasterTemplate.AllowRowResize = false;
            this.gvPuestos.MasterTemplate.AutoExpandGroups = true;
            gridViewTextBoxColumn1.FieldName = "Id";
            gridViewTextBoxColumn1.HeaderText = "ID";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "Id";
            gridViewTextBoxColumn2.FieldName = "Departamentos.Entidades.Id";
            gridViewTextBoxColumn2.HeaderText = "IdEntidad";
            gridViewTextBoxColumn2.IsVisible = false;
            gridViewTextBoxColumn2.Name = "IdEntidad";
            gridViewTextBoxColumn3.FieldName = "Departamentos.Id";
            gridViewTextBoxColumn3.HeaderText = "IdDepto";
            gridViewTextBoxColumn3.IsVisible = false;
            gridViewTextBoxColumn3.MaxWidth = 100;
            gridViewTextBoxColumn3.MinWidth = 80;
            gridViewTextBoxColumn3.Name = "IdDepto";
            gridViewTextBoxColumn3.Width = 80;
            gridViewTextBoxColumn4.FieldName = "Departamentos.Entidades.Nombre";
            gridViewTextBoxColumn4.HeaderText = "Entidad";
            gridViewTextBoxColumn4.IsVisible = false;
            gridViewTextBoxColumn4.MaxWidth = 150;
            gridViewTextBoxColumn4.MinWidth = 100;
            gridViewTextBoxColumn4.Name = "Entidad";
            gridViewTextBoxColumn4.Width = 100;
            gridViewTextBoxColumn5.FieldName = "Departamentos.Nombre";
            gridViewTextBoxColumn5.HeaderText = "Departamento";
            gridViewTextBoxColumn5.IsVisible = false;
            gridViewTextBoxColumn5.MaxWidth = 200;
            gridViewTextBoxColumn5.MinWidth = 150;
            gridViewTextBoxColumn5.Name = "NombreDepto";
            gridViewTextBoxColumn5.Width = 150;
            gridViewTextBoxColumn5.WrapText = true;
            gridViewTextBoxColumn6.FieldName = "Nombre";
            gridViewTextBoxColumn6.HeaderText = "Puesto";
            gridViewTextBoxColumn6.MaxWidth = 300;
            gridViewTextBoxColumn6.MinWidth = 200;
            gridViewTextBoxColumn6.Name = "Nombre";
            gridViewTextBoxColumn6.Width = 200;
            gridViewTextBoxColumn6.WrapText = true;
            gridViewTextBoxColumn7.FieldName = "Abrev";
            gridViewTextBoxColumn7.HeaderText = "Abreviatura";
            gridViewTextBoxColumn7.MaxWidth = 100;
            gridViewTextBoxColumn7.MinWidth = 80;
            gridViewTextBoxColumn7.Name = "Abrev";
            gridViewTextBoxColumn7.Width = 80;
            gridViewCheckBoxColumn1.FieldName = "DatosUsuario.Estatus";
            gridViewCheckBoxColumn1.HeaderText = "Activo";
            gridViewCheckBoxColumn1.MaxWidth = 100;
            gridViewCheckBoxColumn1.MinWidth = 80;
            gridViewCheckBoxColumn1.Name = "Estatus";
            gridViewCheckBoxColumn1.Width = 80;
            this.gvPuestos.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7,
            gridViewCheckBoxColumn1});
            this.gvPuestos.MasterTemplate.ShowGroupedColumns = true;
            this.gvPuestos.MasterTemplate.ShowRowHeaderColumn = false;
            this.gvPuestos.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gvPuestos.Name = "gvPuestos";
            this.gvPuestos.ReadOnly = true;
            this.gvPuestos.ShowGroupPanel = false;
            this.gvPuestos.ShowNoDataText = false;
            this.gvPuestos.Size = new System.Drawing.Size(657, 192);
            this.gvPuestos.TabIndex = 4;
            this.gvPuestos.CurrentRowChanged += new Telerik.WinControls.UI.CurrentRowChangedEventHandler(this.gvPuestos_CurrentRowChanged);
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
            // commandBarStripElement5
            // 
            this.commandBarStripElement5.DisplayName = "commandBarStripElement5";
            this.commandBarStripElement5.Name = "commandBarStripElement5";
            // 
            // frmPuestos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 375);
            this.Controls.Add(this.gvPuestos);
            this.Controls.Add(this.radPanel1);
            this.Controls.Add(this.radCommandBar1);
            this.Name = "frmPuestos";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowIcon = false;
            this.Text = "Puestos";
            this.ThemeName = "MaterialTeal";
            this.Load += new System.EventHandler(this.frmPuestos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            this.radPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboEntidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDeptos)).EndInit();
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
        private Telerik.WinControls.UI.CommandBarButton btnEliminar;
        private Telerik.WinControls.UI.CommandBarButton btnSalir;
        private Telerik.WinControls.UI.RadGridView gvPuestos;
        private Telerik.WinControls.UI.CommandBarSeparator commandBarSeparator1;
        private Telerik.WinControls.UI.CommandBarSeparator commandBarSeparator2;
        private Telerik.WinControls.UI.CommandBarSeparator commandBarSeparator3;
        private Telerik.WinControls.UI.CommandBarSeparator commandBarSeparator4;
        private Telerik.WinControls.UI.CommandBarLabel commandBarLabel1;
        private Telerik.WinControls.UI.CommandBarStripElement commandBarStripElement2;
        private Telerik.WinControls.UI.CommandBarStripElement commandBarStripElement3;
        private Telerik.WinControls.UI.CommandBarStripElement commandBarStripElement4;
        private Telerik.WinControls.UI.CommandBarStripElement commandBarStripElement5;
        private Telerik.WinControls.UI.RadDropDownList cboDeptos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkEstatus;
        private Telerik.WinControls.UI.RadDropDownList cboEntidad;
        private System.Windows.Forms.Label label5;
    }
}
