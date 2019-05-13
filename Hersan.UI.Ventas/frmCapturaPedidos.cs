using Hersan.Entidades.Ensamble;
using Hersan.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.Data;
using Telerik.WinControls.UI;

namespace Hersan.UI.Ensamble
{
    public partial class frmCapturaPedidos : Telerik.WinControls.UI.RadForm
    {
        #region Variables
        WCF_Ensamble.Hersan_EnsambleClient oEnsamble;
        private List<PedidosBE> oCotiza = new List<PedidosBE>();
        #endregion

        public frmCapturaPedidos()
        {
            InitializeComponent();
        }
        private void frmCapturaPedidos_Load(object sender, EventArgs e)
        {
            try {
                /* GRUPO POR TIPO Y ENTIDAD */
                GroupDescriptor tipo = new GroupDescriptor();
                tipo.GroupNames.Add("Tipo", ListSortDirection.Ascending);
                tipo.GroupNames.Add("Entidad", ListSortDirection.Ascending);
                this.gvDatos.GroupDescriptors.Add(tipo);

                /* SUMA DE TOTALES */
                GridViewSummaryItem summaryItem = new GridViewSummaryItem("Total", "{0:C2}", GridAggregateFunction.Sum);
                GridViewSummaryRowItem summaryRowItem = new GridViewSummaryRowItem();
                summaryRowItem.Add(summaryItem);
                this.gvDatos.SummaryRowsBottom.Add(summaryRowItem);

                this.gvDatos.MasterTemplate.ShowTotals = true;
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al cargar la pantalla\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            oEnsamble = new WCF_Ensamble.Hersan_EnsambleClient();
            try {
                if(gvDatos.RowCount == 0) {
                    RadMessageBox.Show("Es necesario seleccionar una cotizacio.", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                    return;
                }

                if (RadMessageBox.Show("Desea generar el pedido de la cotización seleccionada...?", this.Text, MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.No)
                    return;

                PedidosBE obj = new PedidosBE();
                obj.Id = int.Parse(txtId.Text);
                obj.Cliente.Id = int.Parse(txtClave.Text);
                obj.Pedido = true;
                obj.DatosUsuario.IdUsuarioModif = BaseWinBP.UsuarioLogueado.ID;
                obj.DatosUsuario.Estatus = true;

                int Result = oEnsamble.ENS_Cotizacion_Actualizar(obj, CrearTablasAuxiliares());
                if (Result != 0) {
                    RadMessageBox.Show("Pedido generado correctamente, con folio: " + Result.ToString(), this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                    LimpiarCampos();
                } else {
                    RadMessageBox.Show("Ocurrió un error al generar el pedido", this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
                }
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al generar el pedido\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally {
                oEnsamble = null;
            }
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            frmCotizacionesBuscar ofrm = new frmCotizacionesBuscar();
            try {
                ofrm.WindowState = FormWindowState.Normal;
                ofrm.StartPosition = FormStartPosition.CenterScreen;
                ofrm.MaximizeBox = false;
                ofrm.MinimizeBox = false;
                ofrm.ShowDialog();
                int IdCotiza = ofrm.Id;

                if (IdCotiza > 0) {
                    LimpiarCampos();
                    CargarCotizacion(IdCotiza);
                }

            } catch (Exception ex) {
                throw ex;
            } finally {
                ofrm.Dispose();
                ofrm = null;
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

        private DataTable CrearTablasAuxiliares()
        {
            DataTable oData;

            try {
                oData = new DataTable("Detalle");
                oData.Columns.Add("COD_Id");
                oData.Columns.Add("COT_Id");
                oData.Columns.Add("COD_Tipo");
                oData.Columns.Add("COD_Id_ProdServ");
                oData.Columns.Add("ACC_Id");
                oData.Columns.Add("COD_Reflejantes");
                oData.Columns.Add("COD_Cantidad");
                oData.Columns.Add("COD_Precio");

                CargarTablas(ref oData);

            } catch (Exception ex) {
                throw ex;
            }
            return oData;
        }
        private void CargarTablas(ref DataTable oData)
        {
            try {
                string aux;

                foreach (var item in oCotiza[0].Detalle) {
                    DataRow oRow = oData.NewRow();
                    oRow["COD_Id"] = item.Id;
                    oRow["COT_Id"] = int.Parse(txtId.Text);
                    oRow["COD_Tipo"] = item.Tipo;
                    oRow["COD_Id_ProdServ"] = item.Producto.Id;
                    if (item.Tipo == "PRODUCTO") {
                        aux = string.Empty;
                        item.Reflejantes.ForEach(x => {
                            aux += x.Id.ToString() + ",";
                        });
                        oRow["COD_Reflejantes"] = aux;
                        oRow["ACC_Id"] = item.Accesorios.Id;
                    } else {
                        oRow["COD_Reflejantes"] = string.Empty;
                    }
                    oRow["COD_Cantidad"] = item.Cantidad;
                    oRow["COD_Precio"] = item.Precio;

                    oData.Rows.Add(oRow);
                }

            } catch (Exception ex) {
                throw ex;
            }
        }
        private void CargarCotizacion(int IdCotiza)
        {
            oEnsamble = new WCF_Ensamble.Hersan_EnsambleClient();
            try {
                oCotiza = oEnsamble.ENS_Cotizacion_Obtener(IdCotiza);
                if (oCotiza.Count > 0) {
                    txtId.Text = oCotiza[0].Id.ToString();
                    txtClave.Text = oCotiza[0].Cliente.Id.ToString();
                    txtNombre.Text = oCotiza[0].Cliente.Nombre.ToString();
                    txtFecha.Text = oCotiza[0].DatosUsuario.FechaCreacion.ToShortDateString();

                    gvDatos.DataSource = oCotiza[0].Detalle; 
                }

            } catch (Exception ex) {
                throw ex;
            } finally {
                oEnsamble = null;
            }
        }
        private void LimpiarCampos()
        {
            try {
                oCotiza.Clear();
                txtId.Text = "0";
                txtClave.Clear();
                txtNombre.Clear();
                txtFecha.Clear();
                txtAgente.Clear();
                gvDatos.DataSource = null;

            } catch (Exception ex) {
                throw ex;
            }
        }
    }
}
