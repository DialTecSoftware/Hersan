using Hersan.Entidades.Ensamble;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace Hersan.UI.APT
{
    public partial class frmInventario : Telerik.WinControls.UI.RadForm
    {
        WCF_Catalogos.Hersan_CatalogosClient oCatalogos;
        WCF_Ensamble.Hersan_EnsambleClient oEnsamble;
        private List<ProductoEnsambleBE> oProductos = new List<ProductoEnsambleBE>();


        public frmInventario()
        {
            InitializeComponent();
        }
        private void frmInventario_Load(object sender, EventArgs e)
        {
            try {

                CargaProductos();
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al cargar la pantalla\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
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
                if (e.Item.Checked) {
                    CargaCarcasas(int.Parse(e.Item.Value.ToString()));
                }
            } catch (Exception ex) {
                throw ex;
            }
        }


        private void CargaProductos()
        {
            oEnsamble = new WCF_Ensamble.Hersan_EnsambleClient();
            try {
                oProductos = oEnsamble.ENS_ProductosCotizacion_Combo(true, "PESOS");
                cboProductos.DisplayMember = "Producto.Nombre";
                cboProductos.ValueMember = "Producto.Id";
                cboProductos.DataSource = oProductos;

                if (oProductos.Count > 0)
                    cboProductos.SelectedIndex = 0;
            } catch (Exception ex) {
                throw ex;
            } finally {
                oEnsamble = null;
            }
        }
        private void CargaCarcasas(int IdProducto)
        {
            oEnsamble = new WCF_Ensamble.Hersan_EnsambleClient();
            oCatalogos = new WCF_Catalogos.Hersan_CatalogosClient();
            try {
                if (cboProductos.SelectedValue != null) {
                    var Ficha = oProductos.Find(item => item.Producto.Id == IdProducto);
                    
                    /* COLORES DE CARCASA */
                    cboCarcasa.DisplayMember = "Nombre";
                    cboCarcasa.ValueMember = "Id";
                    cboCarcasa.DataSource = oEnsamble.ENS_CarcasasCotizacion_Combo(Ficha.Id);

                    /* REFLEJANTES */
                    cboReflejante.DisplayMember = "Nombre";
                    cboReflejante.ValueMember = "Id";
                    cboReflejante.DataSource = oEnsamble.ENS_ReflejanteCotizacion_Combo(Ficha.Id);
                }
            } catch (Exception ex) {
                throw ex;
            } finally {
                oEnsamble = null;
                oCatalogos = null;
            }
        }

       
    }
}
