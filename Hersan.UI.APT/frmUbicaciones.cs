using Hersan.Entidades.APT;
using Hersan.Entidades.Catalogos;
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
using Telerik.WinControls.UI;

namespace Hersan.UI.APT
{
    public partial class frmUbicaciones : Telerik.WinControls.UI.RadForm
    {
        #region Variables
        WCF_Ensamble.Hersan_EnsambleClient oEnsamble;
        private List<ProductoEnsambleBE> oProductos = new List<ProductoEnsambleBE>();
        #endregion

        public frmUbicaciones()
        {
            InitializeComponent();
        }
        private void FrmUbicaciones_Load(object sender, EventArgs e)
        {
            try {
                GroupDescriptor Grupo = new GroupDescriptor();
                Grupo.GroupNames.Add("Almacen", ListSortDirection.Ascending);
                this.gvDatos.GroupDescriptors.Add(Grupo);

                System.Threading.Tasks.Task task = new System.Threading.Tasks.Task(() => { CargaAlmacenes(); });
                task.RunSynchronously();

                task = new System.Threading.Tasks.Task(() => { CargaProductos(); });
                task.RunSynchronously();

                CargarDatos();
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al cargar la pantalla\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }        
        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            try {
                LimpiarCampos();
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al limpiar la pantalla\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            oEnsamble = new WCF_Ensamble.Hersan_EnsambleClient();
            UbicacionesBE obj = new UbicacionesBE();
            try {
                if(RadMessageBox.Show("Se guardará la ubicación del producto\nDesea continuar...?",this.Text, MessageBoxButtons.YesNo,RadMessageIcon.Question) == DialogResult.No) {
                    return;
                }

                foreach (GridViewRowInfo oRow in gvDatos.Rows) {
                    if (oRow.Cells["IdAlmacen"].Value.ToString() == cboAlmacen.SelectedValue.ToString()
                        && oRow.Cells["IdProducto"].Value.ToString() == cboTipo.SelectedValue.ToString()
                        && oRow.Cells["IdCarcasa"].Value.ToString() == cboColores.SelectedValue.ToString()
                        //&& oRow.Cells["IdReflejante"].Value.ToString() == cboReflejantes.SelectedValue.ToString()
                        && int.Parse(txtId.Text) == 0) {
                        RadMessageBox.Show("El Producto capturado ya tiene ubicación asignada", this.Text, MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                        LimpiarCampos();
                        return;
                    }
                }

                obj.Id = int.Parse(txtId.Text);
                obj.Almacen.Id = int.Parse(cboAlmacen.SelectedValue.ToString());
                obj.Producto.Id = int.Parse(cboTipo.SelectedValue.ToString());
                obj.Carcasa.Id = int.Parse(cboColores.SelectedValue.ToString());
                foreach(var item in cboReflejantes.CheckedItems) {
                    obj.Reflejante.Nombre += item.Value.ToString() + ",";
                }
                obj.Rack = cboRack.Text;
                obj.Fila = int.Parse(spFila.Value.ToString());
                obj.Columna = int.Parse(spColumna.Value.ToString());
                obj.Minimo = decimal.Parse(spMin.Value.ToString());
                obj.Maximo = decimal.Parse(spMax.Value.ToString());
                obj.DatosUsuario.Estatus = chkEstatus.Checked;
                obj.DatosUsuario.IdUsuarioCreo = BaseWinBP.UsuarioLogueado.ID;

                //PROCESO DE GUARDADO Y ACTUALIZACION
                if (txtId.Text == "0") {
                    int Result = oEnsamble.APT_Ubicacion_Guardar(obj);
                    if (Result == 0) {
                        RadMessageBox.Show("Ocurrió un error al guardar la ubicación del producto", this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
                    } else {
                        RadMessageBox.Show("Producto asignado a la ubicación correctamente", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                        LimpiarCampos();
                        CargarDatos();
                    }
                } else {
                    int Result = oEnsamble.APT_Ubicacion_Actualizar(obj);
                    if (Result == 0) {
                        RadMessageBox.Show("Ocurrió un error al actualizar los datos", this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
                    } else {
                        RadMessageBox.Show("Información actualizada correctamente", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                        LimpiarCampos();
                        CargarDatos();
                    }
                }
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al actualizar la información\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally {
                oEnsamble = null;
            }
        }
        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            oEnsamble = new WCF_Ensamble.Hersan_EnsambleClient();
            UbicacionesBE obj = new UbicacionesBE();
            try {
                if (chkEstatus.Checked) {
                    if (RadMessageBox.Show("Esta acción dará de baja la ubicación del producto\nDesea continuar...?", this.Text, MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.Yes) {
                        obj.Id = int.Parse(txtId.Text);
                        obj.Rack = cboRack.Text;
                        obj.Fila = int.Parse(spFila.Value.ToString());
                        obj.Columna = int.Parse(spColumna.Value.ToString());
                        obj.Minimo = decimal.Parse(spMin.Value.ToString());
                        obj.Maximo = decimal.Parse(spMax.Value.ToString());
                        obj.DatosUsuario.IdUsuarioModif = BaseWinBP.UsuarioLogueado.ID;
                        obj.DatosUsuario.Estatus = false;

                        if (oEnsamble.APT_Ubicacion_Actualizar(obj) == 0) {
                            RadMessageBox.Show("Ocurrió un error al modificar los datos", this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
                        } else {
                            RadMessageBox.Show("Información actualizada correctamente", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                            LimpiarCampos();
                            CargarDatos();
                        }
                    }
                }
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrio un error al dar de baja el tipo de producto\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally {
                oEnsamble = null;
            }
        }
        private void BtnSalir_Click(object sender, EventArgs e)
        {
            try {
                this.Close();
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al cerrar la pantalla\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }        
        private void CboTipo_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            oEnsamble = new WCF_Ensamble.Hersan_EnsambleClient();
            try {
                if (cboTipo.SelectedValue != null) {
                    var Ficha = oProductos.Find(item => item.Producto.Id == int.Parse(cboTipo.SelectedValue.ToString()));
                    /* COLORES DE CARCASA */
                    cboColores.DisplayMember = "Nombre";
                    cboColores.ValueMember = "Id";
                    cboColores.DataSource = oEnsamble.ENS_CarcasasCotizacion_Combo(Ficha.Id);
                    
                    /* REFLEJANTES */
                    cboReflejantes.DisplayMember = "Nombre";
                    cboReflejantes.ValueMember = "Id";
                    cboReflejantes.DataSource = oEnsamble.ENS_ReflejanteCotizacion_Combo(Ficha.Id);
                }
            } catch (Exception ex) {
                throw ex;
            } finally {
                oEnsamble = null;
            }
        }
        private void GvDatos_CurrentRowChanged(object sender, Telerik.WinControls.UI.CurrentRowChangedEventArgs e)
        {
            try {
                if (gvDatos.RowCount > 0 && e.CurrentRow.ChildRows.Count == 0) {
                    txtId.Text = e.CurrentRow.Cells["Id"].Value.ToString();
                    cboTipo.SelectedValue = int.Parse(e.CurrentRow.Cells["IdProducto"].Value.ToString());
                    cboColores.SelectedValue = int.Parse(e.CurrentRow.Cells["IdCarcasa"].Value.ToString());
                    foreach (var item in e.CurrentRow.Cells["Reflejante"].Value.ToString().Split('-')) {
                        cboReflejantes.Items[cboReflejantes.FindString(item)].Checked = true;
                    }
                    cboRack.Text = e.CurrentRow.Cells["Rack"].Value.ToString();
                    spFila.Value = decimal.Parse(e.CurrentRow.Cells["Fila"].Value.ToString());
                    spColumna.Value = decimal.Parse(e.CurrentRow.Cells["Columna"].Value.ToString());
                    spMin.Value = decimal.Parse(e.CurrentRow.Cells["Minimo"].Value.ToString());
                    spMax.Value = decimal.Parse(e.CurrentRow.Cells["Maximo"].Value.ToString());
                    chkEstatus.Checked = bool.Parse(e.CurrentRow.Cells["Estatus"].Value.ToString());
                }
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrio un error al seleccionar el registro\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
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
        private void LimpiarCampos()
        {
            try {
                txtId.Text = "0";
                cboAlmacen.SelectedIndex = 0;
                cboTipo.SelectedIndex = 0;
                cboReflejantes.CheckedItems.Clear();
                cboRack.Text = "A";
                chkEstatus.Checked = true;
                spFila.Value = 1;
                spColumna.Value = 1;
                spMin.Value = 1;
                spMax.Value = 1;
            } catch (Exception ex) {
                throw ex;
            }
        }
        private void CargarDatos()
        {
            oEnsamble = new WCF_Ensamble.Hersan_EnsambleClient();
            try {
                gvDatos.DataSource = oEnsamble.APT_Ubicacion_Obtener();
            } catch (Exception ex) {
                throw ex;
            } finally {
                oEnsamble = null;
            }
        }

    }
}
