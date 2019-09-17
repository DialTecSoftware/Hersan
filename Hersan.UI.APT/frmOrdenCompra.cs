using Hersan.Entidades.APT;
using Hersan.Entidades.Catalogos;
using Hersan.Entidades.Ensamble;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls;

namespace Hersan.UI.APT
{
    public partial class frmOrdenCompra : Telerik.WinControls.UI.RadForm
    {
        #region Variables
        WCF_Ensamble.Hersan_EnsambleClient oEnsamble;
        private List<ProductoEnsambleBE> oProductos = new List<ProductoEnsambleBE>();
        private List<OrdenCompraDetalleBE> oDetalle = new List<OrdenCompraDetalleBE>();
        private List<ReflejantesBE> oReflex = new List<ReflejantesBE>();
        #endregion

        public frmOrdenCompra()
        {
            InitializeComponent();
        }
        private void FrmOrdenCompra_Load(object sender, EventArgs e)
        {
            try {
                dtFecha.MinDate = DateTime.Today.AddDays(2);
                dtFecha.Value = DateTime.Today;

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
                        Task<List<ColoresBE>> Car = oEnsamble.ENS_CarcasasCotizacion_ComboAsync(Ficha.Id);
                        cboColores.DisplayMember = "Nombre";
                        cboColores.ValueMember = "Id";
                        cboColores.DataSource = Car.Result;

                        /* REFLEJANTES */
                        Task<List<ReflejantesBE>> Aux = oEnsamble.ENS_ReflejanteCotizacion_ComboAsync(Ficha.Id);
                        oReflex = Aux.Result;
                        cboReflejantes.DisplayMember = "Nombre";
                        cboReflejantes.ValueMember = "Id";
                        cboReflejantes.DataSource = oReflex;

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
            oEnsamble = new WCF_Ensamble.Hersan_EnsambleClient();
            string IdComp = string.Empty;
            string Tipo = string.Empty;
            string Reflex = string.Empty;
            try {
                if (cboTipo.SelectedValue != null && cboColores.SelectedValue != null && cboReflejantes.CheckedItems.Count > 0) {
                    gvDatos.DataSource = null;

                    OrdenCompraDetalleBE obj = new OrdenCompraDetalleBE();
                    obj.Producto.Producto.Id = int.Parse(cboTipo.SelectedValue.ToString());
                    obj.Producto.Producto.Nombre = cboTipo.Text;
                    obj.Carcasa.Id = int.Parse(cboColores.SelectedValue.ToString());
                    obj.Carcasa.Nombre = cboColores.Text;

                    foreach (var item in cboReflejantes.CheckedItems) {
                        IdComp += item.Value.ToString() + ",";
                        Tipo = oReflex.Find(x => x.Tipo == item.Text.Split('-')[0].ToString().Trim()).Tipo;
                        Reflex += oReflex.Find(x => x.Id == int.Parse(item.Value.ToString())).Color.Nombre + "-";
                    }
                    Task<string> Aux = oEnsamble.ENS_CodigoProducto_ObtenerAsync(obj.Producto.Producto.Id, obj.Carcasa.Id, IdComp);
                    obj.Producto.Codigo = Aux.Result;
                    obj.Sugerido = int.Parse(spSugerido.Value.ToString());
                    obj.Solicitado = int.Parse(spSolicitado.Value.ToString());
                    
                    obj.Producto.Producto.Familia.Clave = IdComp;
                    obj.Producto.Producto.Familia.Entidad.Nombre = Tipo;
                    obj.Producto.Producto.Familia.Nombre = Reflex.Substring(0,Reflex.Length-1);

                    oDetalle.Add(obj);
                }
                gvDatos.DataSource = oDetalle;
                cboReflejantes.CheckedItems.Clear();

            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al agregar el producto a la Orden de Compra\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally { oEnsamble = null; }
        }
        private void CboReflejantes_ItemCheckedChanged(object sender, Telerik.WinControls.UI.RadCheckedListDataItemEventArgs e)
        {
            try {
                if (cboReflejantes.CheckedItems.Count > int.Parse(txtCavidades.Text)) {
                    RadMessageBox.Show("Sólo puede seleccionar " + txtCavidades.Text + " Reflejante(s).", this.Text, MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                    e.Item.Checked = false;
                }
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrio un error al seleccionar el reflejante\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void BtnQuitar_Click(object sender, EventArgs e)
        {
            try {
                if (oDetalle.FindAll(item => item.Sel == true).Count > 0) {
                    if (RadMessageBox.Show("Esta acción eliminara los elementos seleccionados\nDesea continuar...?", this.Text, MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.No)
                        return;
                } else {
                    RadMessageBox.Show("No hay productos seleccionados", this.Text, MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                    return;
                }

                if (spOC.Value == 0)
                    oDetalle.RemoveAll(item => item.Sel == true);
                else {
                    oDetalle.ForEach(item => {
                        if (item.Sel == true)
                            item.DatosUsuario.Estatus = false;
                    });
                    oDetalle.RemoveAll(item => item.DatosUsuario.Estatus == false);
                }

                ActualizaGrid();
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al quitar el producto\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void BtnTodos_Click(object sender, EventArgs e)
        {
            try {
                if (oDetalle.Count > 0) {
                    if (RadMessageBox.Show("Esta acción eliminara todos los elementos\nDesea continuar...?", this.Text, MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.No)
                        return;
                } else {
                    RadMessageBox.Show("No se han agregado productos", this.Text, MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                    return;
                }

                if (spOC.Value == 0)
                    oDetalle.Clear();
                else {
                    oDetalle.ForEach(item => item.DatosUsuario.Estatus = false);
                    oDetalle.RemoveAll(item => item.DatosUsuario.Estatus == false);
                }

                ActualizaGrid();
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al eliminar los productos\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }


        private void CargaProductos()
        {
            oEnsamble = new WCF_Ensamble.Hersan_EnsambleClient();
            try {
                Task<List<ProductoEnsambleBE>> Aux = oEnsamble.ENS_ProductosCotizacion_ComboAsync(true, "");
                Aux.Wait();
                oProductos = Aux.Result;
                
                cboTipo.DisplayMember = "Producto.Nombre";
                cboTipo.ValueMember = "Producto.Id";
                cboTipo.DataSource = oProductos;

                if (oProductos.Count > 0)
                    cboTipo.SelectedIndex = 0;
            } catch (Exception ex) {
                throw ex;
            } finally {
                oEnsamble = null;
            }
        }
        private void ActualizaGrid()
        {
            try {
                gvDatos.DataSource = null;
                gvDatos.DataSource = oDetalle.FindAll(item => item.DatosUsuario.Estatus == true);
            } catch (Exception ex) {
                throw ex;
            }
        }
    }
}
