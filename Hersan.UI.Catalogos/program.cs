using Hersan.UI.CapitalHumano;
using System;
using System.Windows.Forms;


namespace Hersan.UI.Catalogos {
    static class Program {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmSolicitudPersonal());
        }
    }
}
