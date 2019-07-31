using Hersan.Entidades.Nomina;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using Telerik.WinControls;

namespace Hersan.UI.Nomina
{
    public partial class frmSubsidios : Telerik.WinControls.UI.RadForm
    {
        WCF_Nomina.Hersan_NominaClient oNomina;
        List<SubsidiosBE> oList = new List<SubsidiosBE>();

        public frmSubsidios()
        {
            InitializeComponent();
        }
        private void frmSubsidios_Load(object sender, EventArgs e)
        {
            try {
                CargarGrid();
            } catch (Exception ex) {
                throw ex;
            }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {

        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            try {
                this.Close();
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al cerrar la pantalla\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }

        private void CargarGrid()
        {
            oNomina = new WCF_Nomina.Hersan_NominaClient();
            try {
                oList = oNomina.NOM_Subsidios_Obtener();
                gvDatos.DataSource = oList;
            } catch (Exception ex) {
                throw ex;
            } finally {
                oNomina = null;
            }
        }
        private DataTable CrearTablasAuxiliares()
        {
            DataTable oData;

            try {
                oData = new DataTable("Detalle");
                oData.Columns.Add("FAC_Id");
                oData.Columns.Add("FAC_De");
                oData.Columns.Add("FAC_Hasta");
                oData.Columns.Add("FAC_Aguinaldo");
                oData.Columns.Add("FAC_Vacaciones");
                oData.Columns.Add("FAC_Prima");
                oData.Columns.Add("FAC_Factor");

                CargarTablas(ref oData);

            } catch (Exception ex) {
                throw ex;
            }
            return oData;
        }
        private void CargarTablas(ref DataTable oData)
        {
            try {
                foreach (var item in oList) {
                    DataRow oRow = oData.NewRow();
                    oRow["FAC_Id"] = item.Id;
                    oRow["FAC_De"] = item.De;
                    oRow["FAC_Hasta"] = item.Hasta;
                    oRow["FAC_Factor"] = item.Subsidio;

                    oData.Rows.Add(oRow);
                }

            } catch (Exception ex) {
                throw ex;
            }
        }

    }
}
