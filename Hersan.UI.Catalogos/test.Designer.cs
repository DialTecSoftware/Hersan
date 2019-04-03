namespace Hersan.UI.Catalogos
{
    partial class test
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn1 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.gvInduccion = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gvInduccion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvInduccion.MasterTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // gvInduccion
            // 
            this.gvInduccion.Location = new System.Drawing.Point(172, 79);
            // 
            // 
            // 
            this.gvInduccion.MasterTemplate.AllowAddNewRow = false;
            this.gvInduccion.MasterTemplate.AllowColumnReorder = false;
            this.gvInduccion.MasterTemplate.AllowDeleteRow = false;
            this.gvInduccion.MasterTemplate.AllowDragToGroup = false;
            this.gvInduccion.MasterTemplate.AllowEditRow = false;
            gridViewTextBoxColumn1.FieldName = "Id";
            gridViewTextBoxColumn1.HeaderText = "ID";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "Id";
            gridViewTextBoxColumn2.FieldName = "Nombre";
            gridViewTextBoxColumn2.HeaderText = "Nombre";
            gridViewTextBoxColumn2.MaxWidth = 100;
            gridViewTextBoxColumn2.MinWidth = 50;
            gridViewTextBoxColumn2.Name = "Nombre";
            gridViewTextBoxColumn2.Width = 100;
            gridViewTextBoxColumn2.WrapText = true;
            gridViewTextBoxColumn3.FieldName = "Abrev";
            gridViewTextBoxColumn3.HeaderText = "Abrev";
            gridViewTextBoxColumn3.MinWidth = 100;
            gridViewTextBoxColumn3.Name = "Abrev";
            gridViewTextBoxColumn3.Width = 100;
            gridViewCheckBoxColumn1.FieldName = "DatosUsuario.Estatus";
            gridViewCheckBoxColumn1.HeaderText = "Estatus";
            gridViewCheckBoxColumn1.MaxWidth = 100;
            gridViewCheckBoxColumn1.MinWidth = 100;
            gridViewCheckBoxColumn1.Name = "Estatus";
            gridViewCheckBoxColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCheckBoxColumn1.Width = 100;
            this.gvInduccion.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewCheckBoxColumn1});
            this.gvInduccion.MasterTemplate.ShowRowHeaderColumn = false;
            this.gvInduccion.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gvInduccion.Name = "gvInduccion";
            this.gvInduccion.ShowGroupPanel = false;
            this.gvInduccion.ShowNoDataText = false;
            this.gvInduccion.ShowRowErrors = false;
            this.gvInduccion.Size = new System.Drawing.Size(457, 293);
            this.gvInduccion.TabIndex = 18;
            // 
            // test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.gvInduccion);
            this.Name = "test";
            this.Text = "test";
            ((System.ComponentModel.ISupportInitialize)(this.gvInduccion.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvInduccion)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView gvInduccion;
    }
}