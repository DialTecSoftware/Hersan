using Hersan.Entidades.APT;
using Hersan.Entidades.Catalogos;
using Hersan.Negocio;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
        private void CboFamilias_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            oCatalogos = new WCF_Catalogos.Hersan_CatalogosClient();
            try {
                if (cboFamilias.SelectedValue != null) {
                    cboTipo.DisplayMember = "Nombre";
                    cboTipo.ValueMember = "Id";
                    cboTipo.DataSource = oCatalogos.ENS_TipoProducto_Combo(int.Parse(cboFamilias.SelectedValue.ToString()));
                }
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al seleccionar la familia\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally {
                oCatalogos = null;
            }
        }

        private void CargaAlmacenes()
        {
            oEnsamble = new WCF_Ensamble.Hersan_EnsambleClient();
            try {
                Task<List<AlmacenPTBE>> Aux = oEnsamble.APT_Almacenes_ComboAsync(BaseWinBP.UsuarioLogueado.Empresa.Id);
                Aux.Wait();

                cboAlmacen.ValueMember = "Id";
                cboAlmacen.DisplayMember = "Nombre";
                cboAlmacen.DataSource = Aux.Result;
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
                Task<List<FamiliasBE>> Aux = oCatalogos.ENS_Familias_ComboAsync(0);
                Aux.Wait();

                oFamilias = Aux.Result;
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
