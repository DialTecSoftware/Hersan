using Hersan.Entidades.Ensamble;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Telerik.WinControls;

namespace Hersan.UI.APT
{
    public partial class frmOrdenCompra : Telerik.WinControls.UI.RadForm
    {
        #region Variables
        WCF_Ensamble.Hersan_EnsambleClient oEnsamble;
        private List<ProductoEnsambleBE> oProductos = new List<ProductoEnsambleBE>();
        #endregion

        public frmOrdenCompra()
        {
            InitializeComponent();
        }
        private void FrmOrdenCompra_Load(object sender, EventArgs e)
        {
            try {
                CargaProductos();
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al cargar la pantalla\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void BtnGuardar_Click(object sender, EventArgs e)
        {

        }
        private void BtnEliminar_Click(object sender, EventArgs e)
        {

        }
        private void BtnEnviar_Click(object sender, EventArgs e)
        {

        }
        private void BtnSalir_Click(object sender, EventArgs e)
        {
            try {
                this.Close();
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al cerrar la pantalla\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void SpOC_KeyDown(object sender, KeyEventArgs e)
        {

        }
        private void CboTipo_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            oEnsamble = new WCF_Ensamble.Hersan_EnsambleClient();
            try {
                if (cboTipo.SelectedValue != null) {
                    var Ficha = oProductos.Find(item => item.Producto.Id == int.Parse(cboTipo.SelectedValue.ToString()));
                    if (Ficha != null) {
                        /* COLORES DE CARCASA */
                        cboColores.DisplayMember = "Nombre";
                        cboColores.ValueMember = "Id";
                        cboColores.DataSource = oEnsamble.ENS_CarcasasCotizacion_Combo(Ficha.Id);

                        /* REFLEJANTES */
                        cboReflejantes.DisplayMember = "Nombre";
                        cboReflejantes.ValueMember = "Id";
                        cboReflejantes.DataSource = oEnsamble.ENS_ReflejanteCotizacion_Combo(Ficha.Id);

                        txtCavidades.Text = Ficha.Reflejantes.ToString();
                    } else {
                        RadMessageBox.Show("El producto seleccionado no existe o está incompletos", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                        cboTipo.SelectedIndex = 0;
                    }
                }
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al seleccionar el producto\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally {
                oEnsamble = null;
            }
        }
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try {

            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al agregar el producto a la Orden de Compra\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }


        private void CargaProductos()
        {
            oEnsamble = new WCF_Ensamble.Hersan_EnsambleClient();
            try {
                oProductos = oEnsamble.ENS_ProductosCotizacion_Combo(true, "");
                cboTipo.DisplayMember = "Producto.Nombre";
                cboTipo.ValueMember = "Id";
                cboTipo.DataSource = oProductos;

                if (oProductos.Count > 0)
                    cboTipo.SelectedIndex = 0;
            } catch (Exception ex) {
                throw ex;
            } finally {
                oEnsamble = null;
            }
        }
    }
}
