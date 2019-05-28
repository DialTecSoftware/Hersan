using System;

namespace Hersan.UI.Ensamble
{
    public partial class frmViewer : Telerik.WinControls.UI.RadForm
    {
        public enum Modo
        {
            Ver = 0,
            Imprimir = 1
        }
        public Modo VerImprimir;

        public frmViewer()
        {
            InitializeComponent();
        }
        private void frmViewer_Load(object sender, EventArgs e)
        {
            try {
                rptViewer.ReportSource = iReport;

                if (VerImprimir == Modo.Ver)
                    rptViewer.Show();
                else
                    rptViewer.PrintReport();

            } catch (Exception ex) {
                throw ex;
            }
        }
    }
}
