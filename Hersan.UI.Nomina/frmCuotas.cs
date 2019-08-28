using Hersan.Entidades.Nomina;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.Data;

namespace Hersan.UI.Nomina
{
    public partial class frmCuotas : Telerik.WinControls.UI.RadForm
    {
        WCF_Nomina.Hersan_NominaClient oNomina;
        List<CuotasBE> oList = new List<CuotasBE>();

        public frmCuotas()
        {
            InitializeComponent();
        }
        private void frmCuotas_Load(object sender, EventArgs e)
        {
            try {
                GroupDescriptor grupo = new GroupDescriptor();
                grupo.GroupNames.Add("Id", ListSortDirection.Ascending);
                grupo.GroupNames.Add("Nombre", ListSortDirection.Ascending);
                gvDatos.GroupDescriptors.Add(grupo);

                CargaGrid();
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

        private void CargaGrid()
        {
            oNomina = new WCF_Nomina.Hersan_NominaClient();
            try {
                oList = oNomina.NOM_Cuotas_Obtener();
                gvDatos.DataSource = oList;
            } catch (Exception ex) {
                throw ex;
            }
        }
    }
}
