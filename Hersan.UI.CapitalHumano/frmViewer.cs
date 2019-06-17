using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace Hersan.UI.CapitalHumano
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
