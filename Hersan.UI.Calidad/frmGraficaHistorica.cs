using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace Hersan.UI.Calidad
{
    public partial class frmGraficaHistorica : Telerik.WinControls.UI.RadForm
    {
        public bool Ensamble { get; set; }

        public frmGraficaHistorica()
        {
            InitializeComponent();
        }
        private void btnHistograma_Click(object sender, EventArgs e)
        {
            try {
                frmHistograma frm = new frmHistograma();
                frm.Ensamble = Ensamble;
                frm.Historica = !Ensamble;
                frm.Inicial = dtDesde.Value.Year.ToString() + dtDesde.Value.Month.ToString().PadLeft(2, '0') + dtDesde.Value.Day.ToString().PadLeft(2, '0');
                frm.Final = dtHasta.Value.Year.ToString() + dtHasta.Value.Month.ToString().PadLeft(2, '0') + dtHasta.Value.Day.ToString().PadLeft(2, '0');
                frm.Ensamble = Ensamble;
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowDialog();
                this.Close();
            } catch (Exception ex) {
                throw ex;
            }
        }
        private void btnSeries_Click(object sender, EventArgs e)
        {
            try {
                frmGraficaControl frm = new frmGraficaControl();
                frm.Inicial = dtDesde.Value.Year.ToString() + dtDesde.Value.Month.ToString().PadLeft(2, '0') + dtDesde.Value.Day.ToString().PadLeft(2, '0');
                frm.Final = dtHasta.Value.Year.ToString() + dtHasta.Value.Month.ToString().PadLeft(2, '0') + dtHasta.Value.Day.ToString().PadLeft(2, '0');
                frm.Series = true;
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowDialog();
                this.Close();
            } catch (Exception ex) {
                throw ex;
            }
        }
        private void dtDesde_ValueChanged(object sender, EventArgs e)
        {
            try {
                this.dtHasta.MinDate = dtDesde.Value;
            } catch (Exception ex) {
                throw ex;
            }
        }
    }
}
