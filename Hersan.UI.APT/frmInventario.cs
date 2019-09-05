using Hersan.Entidades.Catalogos;
using Hersan.Negocio;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Telerik.WinControls;

namespace Hersan.UI.APT
{
    public partial class frmInventario : Telerik.WinControls.UI.RadForm
    {
        WCF_Catalogos.Hersan_CatalogosClient oCatalogos;
        WCF_Ensamble.Hersan_EnsambleClient oEnsamble;
        private List<FamiliasBE> oFamilias = new List<FamiliasBE>();

        public frmInventario()
        {
            InitializeComponent();
        }
        private void frmInventario_Load(object sender, EventArgs e)
        {
            try {
                CargaAlmacenes();
                CargaFamilias();
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al cargar la pantalla\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }
        private void btnImprimir_Click(object sender, EventArgs e)
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
        private void cboProductos_ItemCheckedChanged(object sender, Telerik.WinControls.UI.RadCheckedListDataItemEventArgs e)
        {
            try {
                if (cboFamilias.CheckedItems.Count == 1) {
                    if (e.Item.Checked) {

                    }
                }
            } catch (Exception ex) {
                throw ex;
            }
        }

        private void CargaAlmacenes()
        {
            oEnsamble = new WCF_Ensamble.Hersan_EnsambleClient();
            try {
                cboAlmacen.ValueMember = "Id";
                cboAlmacen.DisplayMember = "Nombre";
                cboAlmacen.DataSource = oEnsamble.APT_Almacenes_Combo(BaseWinBP.UsuarioLogueado.Empresa.Id);
            } catch (Exception ex) {
                throw ex;
            } finally {
                oEnsamble = null;
            }
        }
        private void CargaFamilias()
        {
            oCatalogos = new WCF_Catalogos.Hersan_CatalogosClient();
            try {
                oFamilias = oCatalogos.ENS_Familias_Combo(0);
                cboFamilias.DisplayMember = "Nombre";
                cboFamilias.ValueMember = "Id";
                cboFamilias.DataSource = oFamilias;

            } catch (Exception ex) {
                throw ex;
            } finally {
                oCatalogos = null;
            }
        }
       
    }
}
