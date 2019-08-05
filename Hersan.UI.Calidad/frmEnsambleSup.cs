using Hersan.Entidades.Calidad;
using Hersan.Entidades.Catalogos;
using Hersan.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace Hersan.UI.Calidad
{
    public partial class frmEnsambleSup : Telerik.WinControls.UI.RadForm
    {
        #region Variables        
        WCF_Catalogos.Hersan_CatalogosClient oCatalogos;
        WCF_Ensamble.Hersan_EnsambleClient oEnsamble;        
        List<TipoProductoBE> oTipo;
        List<EnsambleParametrosBE> oList;
        List<EnsambleParametrosDetalleBE> oDetalle = new List<EnsambleParametrosDetalleBE>();
        private List<ReflejantesBE> oReflejantes = new List<ReflejantesBE>();
        List<string> oMaquinas = new List<string>();
        bool Flag = true;
        #endregion

        public frmEnsambleSup()
        {
            InitializeComponent();
        }
        private void frmEnsambleSup_Load(object sender, EventArgs e)
        {
            try {
                this.WindowState = FormWindowState.Normal;
                this.StartPosition = FormStartPosition.CenterScreen;

                oMaquinas.Add("S1");
                oMaquinas.Add("S8");
                ((Telerik.WinControls.UI.GridViewComboBoxColumn)this.gvDatos.Columns["Maquina"]).DataSource = oMaquinas;

                CargarProductos();
                CargaCarcasas();
                CargaReflejantes();
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al cargar la pantalla\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try {
                CargaGrid();
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
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            oEnsamble = new WCF_Ensamble.Hersan_EnsambleClient();
            try {

                if (RadMessageBox.Show("Desea guardar los datos...?", this.Text, MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.Yes) {
                    EnsambleParametrosBE obj = new EnsambleParametrosBE();
                    obj.OP = txtOP.Text;
                    obj.Lista = txtLista.Text.Trim().Length != 0 ? int.Parse(txtLista.Text) : 0;
                    obj.Producto.Id = int.Parse(cboProducto.SelectedValue.ToString());
                    obj.Carcasa.Id = int.Parse(cboCarcasa.SelectedValue.ToString());
                    obj.Reflex1.Id = cboReflejante1.SelectedValue == null ? 0 : int.Parse(cboReflejante1.SelectedValue.ToString());
                    obj.Reflex2.Id = cboReflejante2.SelectedValue == null ? 0 : int.Parse(cboReflejante2.SelectedValue.ToString());
                    obj.DatosUsuario.IdUsuarioCreo = BaseWinBP.UsuarioLogueado.ID;

                    if (oEnsamble.PRO_Ensamble_Parametros_Guardar(obj, CrearTablasAuxiliares()) == 0) {
                        RadMessageBox.Show("Ocurrió un error al guardar la informacion", this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
                    } else {
                        RadMessageBox.Show("Información guardada correctamente", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                        CargaGrid();
                    }
                }
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al guardar los datos\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally {
                oEnsamble = null;
            }
        }
        private void txtOP_Leave(object sender, EventArgs e)
        {
            try {
                CargaGrid();
            } catch (Exception ex) {
                throw ex;
            }
        }
        private void txtLista_KeyPress(object sender, KeyPressEventArgs e)
        {
            try {
                if (!BaseWinBP.isNumero(e.KeyChar))
                    e.Handled = true;
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al capturar el dato\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void txtLista_KeyDown(object sender, KeyEventArgs e)
        {

        }
        private void gvDatos_CellEndEdit(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try {
                if (e.RowIndex >= 0) {
                    if (bool.Parse(gvDatos.Rows[e.RowIndex].Cells["Estatus"].Value.ToString()) == true)
                        gvDatos.Rows[e.RowIndex].Cells["Estatus"].Value = false;
                }
            } catch (Exception ex) {
                throw ex;
            }
        }
        private void cboProducto_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            //try {
            //    if (Flag) {
            //        if (cboProducto.SelectedValue != null)
            //            CargaGrid();
            //    }
            //} catch (Exception ex) {
            //    throw ex;
            //}
        }
        private void Contol_KeyDown(object sender, KeyEventArgs e)
        {
            try {
                if (e.KeyData == Keys.Enter) {
                    SendKeys.Send("{TAB}");
                }
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error en la captura\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }

        private void CargarProductos()
        {
            oCatalogos = new WCF_Catalogos.Hersan_CatalogosClient();
            try {
                oTipo = oCatalogos.ENS_TipoProducto_Combo(0);
                cboProducto.DisplayMember = "Nombre";
                cboProducto.ValueMember = "Id";
                cboProducto.DataSource = oTipo;
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
        private void CargaGrid()
        {
            oEnsamble = new WCF_Ensamble.Hersan_EnsambleClient();
            oDetalle.Clear();
            try {
                Flag = false;
                EnsambleParametrosBE obj = new EnsambleParametrosBE();
                obj.OP = txtOP.Text;
                obj.Lista = txtLista.Text.Trim().Length != 0 ? int.Parse(txtLista.Text) : 0;

                oList = oEnsamble.PRO_Ensamble_Parametros_Obtener(obj);                

                if (oList.Count > 0) {                    
                    oDetalle = oList[0].Detalle;

                    txtId.Text = oList[0].Id.ToString();
                    cboProducto.SelectedValue = oList[0].Producto.Id;
                    cboCarcasa.SelectedValue = oList[0].Carcasa.Id;
                    cboReflejante1.SelectedValue = oList[0].Reflex1.Id;
                    cboReflejante2.SelectedValue = oList[0].Reflex2.Id;
                }
                gvDatos.DataSource = null;
                gvDatos.DataSource = oDetalle;
            } catch (Exception ex) {
                throw ex;
            } finally {
                oEnsamble = null;
                Flag = true;
            }
        }
        private DataTable CrearTablasAuxiliares()
        {
            DataTable oData;

            try {
                oData = new System.Data.DataTable("Datos");
                oData.Columns.Add("IdDetalle");
                oData.Columns.Add("IdParametro");
                oData.Columns.Add("Maquina");
                oData.Columns.Add("Presion");
                oData.Columns.Add("Energia");
                oData.Columns.Add("Colapso");
                oData.Columns.Add("Tiempo");
                oData.Columns.Add("Planeada");
                oData.Columns.Add("Real");
                oData.Columns.Add("Comentarios");
                
                CargarTablas(ref oData);
            } catch (Exception ex) {
                throw ex;
            }
            return oData;
        }
        private void CargarTablas(ref DataTable oData)
        {
            try {
                foreach (var item in oDetalle) {
                    DataRow oRow = oData.NewRow();
                    oRow["IdDetalle"] = item.Id;
                    oRow["IdParametro"] = item.IdParametro;
                    oRow["Maquina"] = item.Maquina;
                    oRow["Presion"] = item.Presion;
                    oRow["Energia"] = item.Energia;
                    oRow["Colapso"] = item.Colapso;
                    oRow["Tiempo"] = item.Tiempo;
                    oRow["Planeada"] = item.Planeada;
                    oRow["Real"] = item.Real;
                    oRow["Comentarios"] = item.Comentarios;
                  
                    oData.Rows.Add(oRow);
                }
            } catch (Exception ex) {
                throw ex;
            }
        }
    }
}
