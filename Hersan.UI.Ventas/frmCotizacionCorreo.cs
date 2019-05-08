using Hersan.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace Hersan.UI.Ensamble
{
    public partial class frmCotizacionCorreo : Telerik.WinControls.UI.RadForm
    {
        public string Correo { get; set; }
        public Stream Archivo{ get; set; }
        public string Id { get; set; }
        public string Tipo { get; set; }

        public frmCotizacionCorreo()
        {
            InitializeComponent();
        }
        private void btnEnviar_Click(object sender, EventArgs e)
        {
            try {
                string Body = "Estimado Cliente:\n\nBuen día.\n\nDe acuerdo con su solicitud, adjunto encontrará " + Tipo + ": "+ Id + ", ";
                Body += "la cual tiene vigencia de 30 días naturales a partir de la recepción del presente correo.\n\n";
                Body += "Le recordamos que los precios no incluyen IVA ni gastos relacionados al envío ni de instalación.\n\n";
                Body += "Para el envío de la mercancía, es necesario el depósito correspondiente al total de la cotización.\n\n";
                Body += "Agradecemos su confianza, continuamos a sus órdenes.";

                if (txtCorreo.Text.Length > 0 && Archivo != null) {
                    bool Flag = BaseWinBP.EnviarMail("Key.Solutions.Test@gmail.com", txtCorreo.Text, Correo, "", Tipo, Body, 
                        "smtp.gmail.com", "Catcooptest", 587, Archivo, Tipo + ".pdf",true);

                    if (Flag) 
                        RadMessageBox.Show("Correo enviado correctamente", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                    else
                        RadMessageBox.Show("Ocurrió un error al enviar el correo", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                }
                this.Close();
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al enviar el correo\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
                throw;
            }

        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            try {
                this.Close();
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al cerrar la pantalla\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }

        }
    }
}
