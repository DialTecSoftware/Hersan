namespace SIAC.UI.Seguridad
{
    partial class frmCambiarContrasenia
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCambiarContrasenia));
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.txtNuevaContra = new Telerik.WinControls.UI.RadTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnCancelar = new Telerik.WinControls.UI.RadButton();
            this.btnAceptar = new Telerik.WinControls.UI.RadButton();
            this.rtxtContrasenia = new Telerik.WinControls.UI.RadTextBox();
            this.lblContrasenia = new System.Windows.Forms.Label();
            this.rtxtUsuario = new Telerik.WinControls.UI.RadTextBox();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNuevaContra)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAceptar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtContrasenia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtUsuario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radPanel1
            // 
            this.radPanel1.Controls.Add(this.txtNuevaContra);
            this.radPanel1.Controls.Add(this.label1);
            this.radPanel1.Controls.Add(this.pictureBox1);
            this.radPanel1.Controls.Add(this.btnCancelar);
            this.radPanel1.Controls.Add(this.btnAceptar);
            this.radPanel1.Controls.Add(this.rtxtContrasenia);
            this.radPanel1.Controls.Add(this.lblContrasenia);
            this.radPanel1.Controls.Add(this.rtxtUsuario);
            this.radPanel1.Controls.Add(this.lblUsuario);
            this.radPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radPanel1.Location = new System.Drawing.Point(0, 0);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(491, 165);
            this.radPanel1.TabIndex = 1;
            // 
            // txtNuevaContra
            // 
            this.txtNuevaContra.Location = new System.Drawing.Point(321, 71);
            this.txtNuevaContra.MaxLength = 15;
            this.txtNuevaContra.Name = "txtNuevaContra";
            this.txtNuevaContra.PasswordChar = '*';
            this.txtNuevaContra.Size = new System.Drawing.Size(151, 20);
            this.txtNuevaContra.TabIndex = 3;
            this.txtNuevaContra.ThemeName = "Windows7";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(163, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 16);
            this.label1.TabIndex = 12;
            this.label1.Text = "Repetir Contraseña:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(138, 156);
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.CausesValidation = false;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(191, 117);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(110, 36);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAceptar.Location = new System.Drawing.Point(353, 117);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(110, 36);
            this.btnAceptar.TabIndex = 5;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // rtxtContrasenia
            // 
            this.rtxtContrasenia.Location = new System.Drawing.Point(321, 46);
            this.rtxtContrasenia.MaxLength = 15;
            this.rtxtContrasenia.Name = "rtxtContrasenia";
            this.rtxtContrasenia.PasswordChar = '*';
            this.rtxtContrasenia.Size = new System.Drawing.Size(151, 20);
            this.rtxtContrasenia.TabIndex = 2;
            this.rtxtContrasenia.ThemeName = "Windows7";
            // 
            // lblContrasenia
            // 
            this.lblContrasenia.AutoSize = true;
            this.lblContrasenia.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContrasenia.Location = new System.Drawing.Point(163, 46);
            this.lblContrasenia.Name = "lblContrasenia";
            this.lblContrasenia.Size = new System.Drawing.Size(142, 16);
            this.lblContrasenia.TabIndex = 7;
            this.lblContrasenia.Text = "Nueva Contraseña:";
            // 
            // rtxtUsuario
            // 
            this.rtxtUsuario.Location = new System.Drawing.Point(321, 22);
            this.rtxtUsuario.MaxLength = 15;
            this.rtxtUsuario.Name = "rtxtUsuario";
            this.rtxtUsuario.PasswordChar = '*';
            this.rtxtUsuario.Size = new System.Drawing.Size(151, 20);
            this.rtxtUsuario.TabIndex = 1;
            this.rtxtUsuario.ThemeName = "Windows7";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.Location = new System.Drawing.Point(163, 22);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(153, 16);
            this.lblUsuario.TabIndex = 4;
            this.lblUsuario.Text = "Contraseña Anterior:";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmCambiarContrasenia
            // 
            this.AcceptButton = this.btnAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(491, 165);
            this.Controls.Add(this.radPanel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCambiarContrasenia";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.ShowItemToolTips = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cambiar Contraseña";
            this.ThemeName = "ControlDefault";
            this.Load += new System.EventHandler(this.frmCambiarContrasenia_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            this.radPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNuevaContra)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAceptar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtContrasenia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtUsuario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadPanel radPanel1;
        private Telerik.WinControls.UI.RadTextBox txtNuevaContra;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Telerik.WinControls.UI.RadButton btnCancelar;
        private Telerik.WinControls.UI.RadButton btnAceptar;
        private Telerik.WinControls.UI.RadTextBox rtxtContrasenia;
        private System.Windows.Forms.Label lblContrasenia;
        private Telerik.WinControls.UI.RadTextBox rtxtUsuario;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
