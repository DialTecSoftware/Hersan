using Hersan.Entidades.Ensamble;
using Hersan.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.Data;

namespace Hersan.UI.Ensamble
{
    public partial class frmPrecios : Telerik.WinControls.UI.RadForm
    {
        WCF_Ensamble.Hersan_EnsambleClient oEnsamble;
        WCF_Catalogos.Hersan_CatalogosClient oCatalogos;
        List<PreciosBE> oList = new List<PreciosBE>();

        public frmPrecios()
        {
            InitializeComponent();
        }
        private void frmPrecios_Load(object sender, EventArgs e)
        {
            try {
                #region Grupos
                GroupDescriptor Entidades = new GroupDescriptor();
                Entidades.GroupNames.Add("Entidad", ListSortDirection.Ascending);
                this.gvDatos.GroupDescriptors.Add(Entidades);

                GroupDescriptor Familia = new GroupDescriptor();
                Familia.GroupNames.Add("Familia", ListSortDirection.Ascending);
                this.gvDatos.GroupDescriptors.Add(Familia);
                #endregion

                LimpiarCampos();
                CargaMonedas();
                CargarDatos();
            } catch (Exception ex) {
                throw ex;
            }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            oEnsamble = new WCF_Ensamble.Hersan_EnsambleClient();
            DataTable oData;
            DataRow oRow;
            try {
                if (cboMonedas.SelectedValue != null) {
                    if (RadMessageBox.Show("Desea guardar los cambios...?", this.Text, MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.Yes) {

                        #region Carga de Datos            
                        oData = new DataTable("Precios");
                        oData.Columns.Add("PRE_Id");
                        oData.Columns.Add("TPR_Id");
                        oData.Columns.Add("PRE_Precio");
                        oData.Columns.Add("PRE_CantVolumen");
                        oData.Columns.Add("PRE_Volumen");
                        oData.Columns.Add("PRE_CantMayoreo");
                        oData.Columns.Add("PRE_Mayoreo");
                        oData.Columns.Add("PRE_AAA");
                        oData.Columns.Add("PRE_ExWorks");

                        oList.ForEach(item => {
                            if (item.Precio > 0) {
                                oRow = oData.NewRow();
                                oRow["PRE_Id"] = item.Id;
                                oRow["TPR_Id"] = item.Producto.Id;
                                oRow["PRE_Precio"] = decimal.Parse(item.Precio.ToString());
                                oRow["PRE_CantVolumen"] = int.Parse(item.CantidadVol.ToString());
                                oRow["PRE_Volumen"] = decimal.Parse(item.Volumen.ToString());
                                oRow["PRE_CantMayoreo"] = int.Parse(item.CantidadMay.ToString());
                                oRow["PRE_Mayoreo"] = decimal.Parse(item.Mayoreo.ToString());
                                oRow["PRE_AAA"] = decimal.Parse(item.AAA.ToString());
                                oRow["PRE_ExWorks"] = decimal.Parse(item.ExWorks.ToString());

                                oData.Rows.Add(oRow);
                            }
                        });
                        #endregion

                        //PROCESO DE GUARDADO Y ACTUALIZACION
                        int Result = oEnsamble.ENS_Precios_Guardar(oData, cboMonedas.SelectedValue.ToString(), BaseWinBP.UsuarioLogueado.ID);
                        if (Result == 0) {
                            RadMessageBox.Show("Ocurrió un error al guardar los precios", this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
                        } else {
                            RadMessageBox.Show("Precios guardados correctamente", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                            LimpiarCampos();
                            CargarDatos();
                        }
                    }
                } else {
                    RadMessageBox.Show("Debe seleccionar una moneda", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                }
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al guardar los datos\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally {
                oEnsamble = null;
                oData = null;
                oRow = null;
            }
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try {
                CargarDatos();
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al cargar la información\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            try {
                this.Close();
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al cerrar la pantalla\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void cboMonedas_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try {
                if (cboMonedas.SelectedValue != null) {
                    CargarDatos();
                }
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrio un error al seleccionar la moneda\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void gvDatos_CurrentRowChanged(object sender, Telerik.WinControls.UI.CurrentRowChangedEventArgs e)
        {
            try {
                if (gvDatos.RowCount > 0 && e.CurrentRow.ChildRows.Count == 0) {
                    txtId.Text = e.CurrentRow.Cells["Id"].Value.ToString();
                    txtProdId.Text = e.CurrentRow.Cells["IdProducto"].Value.ToString();
                    txtCodigo.Text = e.CurrentRow.Cells["Codigo"].Value.ToString();
                    txtPrecio.Text = e.CurrentRow.Cells["Precio"].Value.ToString();
                    txtPzasVolumen.Text = e.CurrentRow.Cells["PzasVol"].Value.ToString();
                    txtVolumen.Text = e.CurrentRow.Cells["Volumen"].Value.ToString();
                    txtPzasMayoreo.Text = e.CurrentRow.Cells["PzasMay"].Value.ToString();
                    txtMayoreo.Text = e.CurrentRow.Cells["Mayoreo"].Value.ToString();
                    txt3A.Text = e.CurrentRow.Cells["AAA"].Value.ToString();
                    txtExWorks.Text = e.CurrentRow.Cells["ExWorks"].Value.ToString();
                }
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrio un error al seleccionar el registro\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void Decimal(object sender, KeyPressEventArgs e)
        {
            try {
                if (BaseWinBP.isDecimal(e.KeyChar))
                    e.Handled = true;
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al capturar el precio\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }

        private void LimpiarCampos()
        {
            try {
                txtId.Text = "0";
                txtProdId.Text = "0";
                txtCodigo.Clear();
                txtPrecio.Text = "0.00";
                txtVolumen.Text = "0.00";
                txtMayoreo.Text = "0.00";
                txt3A.Text = "0.00";
                if(cboMonedas.Items.Count >0)
                    cboMonedas.SelectedIndex = 0;
            } catch (Exception ex) {
                throw ex;
            }
        }
        private void CargarDatos()
        {
            oEnsamble = new WCF_Ensamble.Hersan_EnsambleClient();
            try {
                gvDatos.DataSource = null;

                oList = oEnsamble.ENS_Precios_Obtener(cboMonedas.SelectedValue.ToString());
                gvDatos.DataSource = oList;
            } catch (Exception ex) {
                throw ex;
            } finally {
                oEnsamble = null;
            }
        }
        private void CargaMonedas()
        {
            oCatalogos = new WCF_Catalogos.Hersan_CatalogosClient();
            try {
                cboMonedas.ValueMember = "Moneda";
                cboMonedas.DisplayMember = "Moneda";
                cboMonedas.DataSource = oCatalogos.ABC_Monedas_Combo();
            } catch (Exception ex) {
                throw ex;
            } finally {
                oCatalogos = null;
            }
        }

       
    }
}
