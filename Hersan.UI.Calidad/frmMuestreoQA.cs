using Hersan.Entidades.Calidad;
using Hersan.Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace Hersan.UI.Calidad
{
    public partial class frmMuestreoQA : Telerik.WinControls.UI.RadForm
    {
        WCF_Ensamble.Hersan_EnsambleClient oEnsamble;
        WCF_Catalogos.Hersan_CatalogosClient oCatalogos;
        List<CalidadResguardoQA> oList = new List<CalidadResguardoQA>();
        List<CalidadResguardoQADetalle> oDetalle = new List<CalidadResguardoQADetalle>();

        public frmMuestreoQA()
        {
            InitializeComponent();
        }
        private void frmMuestreoQA_Load(object sender, EventArgs e)
        {
            try {              
                CargaCarcasas();
                CargaReflejantes();
                CargarProductos();
                LimpiarCampos();
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al cargar la pantalla\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try {
                LimpiarCampos();
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al limpiar los campos\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            oEnsamble = new WCF_Ensamble.Hersan_EnsambleClient();
            try {
                CalidadResguardoQA Obj = new CalidadResguardoQA();
                Obj.Id = int.Parse(txtId.Text);
                Obj.Nombre = txtNombre.Text;
                Obj.Producto.Id = cboProducto.SelectedValue != null ? int.Parse(cboProducto.SelectedValue.ToString()) : 0;
                Obj.Carcasa.Id = cboCarcasa.SelectedValue != null ? int.Parse(cboCarcasa.SelectedValue.ToString()) : 0;
                Obj.Reflex1.Id = cboReflejante1.SelectedValue != null ? int.Parse(cboReflejante1.SelectedValue.ToString()) : 0;
                Obj.Reflex2.Id = cboReflejante2.SelectedValue != null ? int.Parse(cboReflejante2.SelectedValue.ToString()) : 0;
                Obj.Piezas = txtPiezas.Text.Trim().Length == 0 ? 0 : int.Parse(txtPiezas.Text);
                Obj.Fecha = dtFecha.Value.Year.ToString() + dtFecha.Value.Month.ToString().PadLeft(2, '0') + dtFecha.Value.Day.ToString().PadLeft(2, '0');
                Obj.IdUsuario = BaseWinBP.UsuarioLogueado.ID;

                if (int.Parse(txtId.Text) == 0) {
                    int Result = oEnsamble.CAL_ResguardoQA_Guardar(Obj, ObtenerDetalle());
                    if (Result == 0) {
                        RadMessageBox.Show("Ocurrió un error al guardar la informacion", this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
                    } else {
                        RadMessageBox.Show("Información guardada correctamente", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                        txtId.Text = Result.ToString();
                        CargaDatos();
                    }
                } else {
                    int Result = oEnsamble.CAL_ResguardoQA_Actualizar(Obj, ObtenerDetalle());
                    if (Result == 0) {
                        RadMessageBox.Show("Ocurrió un error al guardar la informacion", this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
                    } else {
                        RadMessageBox.Show("Información guardada correctamente", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                        CargaDatos();
                    }
                }
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al guardar los datos\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally {
                oEnsamble = null;
            }
        }
        private void btnGrafica_Click(object sender, EventArgs e)
        {
            try {
                frmFiltrosGraficaQA frm = new frmFiltrosGraficaQA();
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowDialog();
            } catch (Exception ex) {
                throw ex;
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
        private void txtPiezas_KeyPress(object sender, KeyPressEventArgs e)
        {
            try {
                if (!BaseWinBP.isNumero(e.KeyChar))
                    e.Handled = true;
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al capturar el dato\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void cboProducto_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try {
                if (cboProducto.SelectedValue != null)
                    CargaDatos();
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al seleccionar el producto\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void dtFecha_ValueChanged(object sender, EventArgs e)
        {
            try {
                CargaDatos();
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al modificar la fecha\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void gvDatos_ViewCellFormatting(object sender, Telerik.WinControls.UI.CellFormattingEventArgs e)
        {
            try {
                if (e.CellElement is GridRowHeaderCellElement && e.Row is GridViewDataRowInfo) {
                    e.CellElement.Text = (e.CellElement.RowIndex + 1).ToString();
                    e.CellElement.TextImageRelation = TextImageRelation.ImageBeforeText;
                } else {
                    e.CellElement.ResetValue(LightVisualElement.TextImageRelationProperty, ValueResetFlags.Local);
                }
            } catch (Exception ex) {
                throw ex;
            }
        }


        private void LimpiarCampos()
        {
            try {
                foreach (Control ctrl in this.Controls) {
                    if (ctrl is Telerik.WinControls.UI.RadTextBox) {
                        ctrl.Text = "";
                    }
                }
                txtId.Text = "0";
                cboProducto.SelectedIndex = 0;
                cboCarcasa.SelectedIndex = 0;
                cboReflejante1.SelectedIndex = 0;
                cboReflejante2.SelectedIndex = 0;
            } catch (Exception ex) {
                throw ex;
            }
        }
        private void CargarProductos()
        {
            oCatalogos = new WCF_Catalogos.Hersan_CatalogosClient();
            try {
                cboProducto.DisplayMember = "Nombre";
                cboProducto.ValueMember = "Id";
                cboProducto.DataSource = oCatalogos.ENS_TipoProducto_Combo(0);
            } catch (Exception ex) {
                throw ex;
            } finally {
                oCatalogos = null;
            }
        }
        private void CargaCarcasas()
        {
            oCatalogos = new WCF_Catalogos.Hersan_CatalogosClient();
            try {
                cboCarcasa.DisplayMember = "Nombre";
                cboCarcasa.ValueMember = "Id";
                cboCarcasa.DataSource = oCatalogos.ABC_Colores_Combo();
            } catch (Exception ex) {
                throw ex;
            } finally {
                oCatalogos = null;
            }
        }
        private void CargaReflejantes()
        {
            oCatalogos = new WCF_Catalogos.Hersan_CatalogosClient();
            try {
                cboReflejante1.DisplayMember = "Nombre";
                cboReflejante1.ValueMember = "Id";
                cboReflejante1.DataSource = oCatalogos.ABC_Colores_Combo();

                cboReflejante2.DisplayMember = "Nombre";
                cboReflejante2.ValueMember = "Id";
                cboReflejante2.DataSource = oCatalogos.ABC_Colores_Combo();

            } catch (Exception ex) {
                throw ex;
            } finally {
                oCatalogos = null;
            }
        }
        private void CargaDatos()
        {
            oEnsamble = new WCF_Ensamble.Hersan_EnsambleClient();
            try {
                gvDatos.DataSource = null;
                string Fecha = dtFecha.Value.Year.ToString() + dtFecha.Value.Month.ToString().PadLeft(2, '0') + dtFecha.Value.Day.ToString().PadLeft(2, '0');
                oList = oEnsamble.CAL_ResguardoQA_Obtener(int.Parse(cboProducto.SelectedValue.ToString()), Fecha);

                if (oList.Count > 0) {                    
                    txtId.Text = oList[0].Id.ToString();
                    txtNombre.Text = oList[0].Nombre.ToString();
                    txtPiezas.Text = oList[0].Piezas.ToString();
                    //cboProducto.SelectedValue = oList[0].Producto.Id;
                    cboCarcasa.SelectedValue = oList[0].Carcasa.Id;
                    cboReflejante1.SelectedValue = oList[0].Reflex1.Id;
                    cboReflejante2.SelectedValue = oList[0].Reflex2.Id;
                    oDetalle = oList[0].Detalle;
                }

                gvDatos.DataSource = oDetalle;
            } catch (Exception ex) {
                throw ex;
            } finally {
                oEnsamble = null;
            }
        }
        private DataTable ObtenerDetalle()
        {
            try {
                #region Tabla
                DataTable oData = new DataTable("Datos");
                oData.Columns.Add("RDE_Id");
                oData.Columns.Add("RES_Id");
                oData.Columns.Add("Lote");
                oData.Columns.Add("Valor0");
                oData.Columns.Add("Valor1");
                oData.Columns.Add("Valor2");
                oData.Columns.Add("Lista");
                oData.Columns.Add("OP");

                foreach (var item in oDetalle) {
                    DataRow oRow = oData.NewRow();
                    oRow["RDE_Id"] = item.Id;
                    oRow["RES_Id"] = item.IdResguardo;
                    oRow["Lote"] = item.Lote;
                    oRow["Valor0"] = item.Valor0;
                    oRow["Valor1"] = item.Valor1;
                    oRow["Valor2"] = item.Valor2;
                    oRow["Lista"] = item.Lista;
                    oRow["OP"] = item.OP;

                    oData.Rows.Add(oRow);
                }
                #endregion

                return oData;
            } catch (Exception ex) {
                throw ex;
            }

        }

       
    }
}
