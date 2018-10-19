namespace Hersan.UI.Seguridad
{
    partial class frmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnCancelar = new Telerik.WinControls.UI.RadButton();
            this.btnAceptar = new Telerik.WinControls.UI.RadButton();
            this.rtxtContrasenia = new Telerik.WinControls.UI.RadTextBox();
            this.rtxtUsuario = new Telerik.WinControls.UI.RadTextBox();
            this.lblContrasenia = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAceptar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtContrasenia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtUsuario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // btnCancelar
            // 
            this.btnCancelar.CausesValidation = false;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(183, 91);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(110, 36);
            this.btnCancelar.TabIndex = 13;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAceptar.Location = new System.Drawing.Point(299, 91);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(110, 36);
            this.btnAceptar.TabIndex = 12;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // rtxtContrasenia
            // 
            this.rtxtContrasenia.Location = new System.Drawing.Point(238, 53);
            this.rtxtContrasenia.MaxLength = 15;
            this.rtxtContrasenia.Name = "rtxtContrasenia";
            this.rtxtContrasenia.PasswordChar = '*';
            this.rtxtContrasenia.Size = new System.Drawing.Size(172, 20);
            this.rtxtContrasenia.TabIndex = 11;
            this.rtxtContrasenia.ThemeName = "Windows7";
            this.rtxtContrasenia.Enter += new System.EventHandler(this.rtxtContrasenia_Enter);
            // 
            // rtxtUsuario
            // 
            this.rtxtUsuario.Location = new System.Drawing.Point(238, 26);
            this.rtxtUsuario.MaxLength = 15;
            this.rtxtUsuario.Name = "rtxtUsuario";
            this.rtxtUsuario.Size = new System.Drawing.Size(172, 20);
            this.rtxtUsuario.TabIndex = 10;
            this.rtxtUsuario.ThemeName = "Windows7";
            this.rtxtUsuario.Enter += new System.EventHandler(this.rtxtUsuario_Enter);
            // 
            // lblContrasenia
            // 
            this.lblContrasenia.AutoSize = true;
            this.lblContrasenia.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContrasenia.Location = new System.Drawing.Point(145, 53);
            this.lblContrasenia.Name = "lblContrasenia";
            this.lblContrasenia.Size = new System.Drawing.Size(93, 16);
            this.lblContrasenia.TabIndex = 9;
            this.lblContrasenia.Text = "Contraseña:";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.Location = new System.Drawing.Point(145, 26);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(66, 16);
            this.lblUsuario.TabIndex = 8;
            this.lblUsuario.Text = "Usuario:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(138, 153);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // frmLogin
            // 
            this.AcceptButton = this.btnAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(440, 153);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.rtxtContrasenia);
            this.Controls.Add(this.rtxtUsuario);
            this.Controls.Add(this.lblContrasenia);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLogin";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema de Información Administrativa";
            this.ThemeName = "ControlDefault";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAceptar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtContrasenia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtUsuario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ErrorProvider errorProvider1;
        private Telerik.WinControls.UI.RadButton btnCancelar;
        private Telerik.WinControls.UI.RadButton btnAceptar;
        private Telerik.WinControls.UI.RadTextBox rtxtContrasenia;
        private Telerik.WinControls.UI.RadTextBox rtxtUsuario;
        private System.Windows.Forms.Label lblContrasenia;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
