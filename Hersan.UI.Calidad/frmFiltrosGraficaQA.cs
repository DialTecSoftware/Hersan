using Hersan.Entidades.Calidad;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace Hersan.UI.Calidad
{
    public partial class frmFiltrosGraficaQA : Telerik.WinControls.UI.RadForm
    {
        WCF_Catalogos.Hersan_CatalogosClient oCatalogos;
        WCF_Ensamble.Hersan_EnsambleClient oEnsamble;

        public frmFiltrosGraficaQA()
        {
            InitializeComponent();
        }
        private void frmFiltrosGraficaQA_Load(object sender, EventArgs e)
        {
            try {
               dtDesde.Value = DateTime.Today;

               CargaCarcasas();
               CargaReflejantes();
               CargarProductos();
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al cargar la pantalla\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void btnHistograma_Click(object sender, EventArgs e)
        {
            oEnsamble = new WCF_Ensamble.Hersan_EnsambleClient();
            try {
                CalidadResguardoQA Obj = new CalidadResguardoQA();
                Obj.Producto.Id = int.Parse(cboProducto.SelectedValue.ToString());
                Obj.Carcasa.Id = int.Parse(cboCarcasa.SelectedValue.ToString());
                Obj.Reflex1.Id = int.Parse(cboReflejante1.SelectedValue.ToString());
                Obj.Reflex2.Id = cboReflejante2.SelectedValue != null ? int.Parse(cboReflejante2.SelectedValue.ToString()) : 0;
                string Inicial = dtDesde.Value.Year.ToString() + dtDesde.Value.Month.ToString().PadLeft(2,'0') + dtDesde.Value.Day.ToString().PadLeft(2, '0');
                string Final = dtHasta.Value.Year.ToString() + dtHasta.Value.Month.ToString().PadLeft(2, '0') + dtHasta.Value.Day.ToString().PadLeft(2, '0');

                List<CalidadResguardoQADetalle> oList = oEnsamble.CAL_ResguardoQA_Grafica(Obj, Inicial, Final);
                if (oList.Count > 0) {
                    frmGraficaQA frm = new frmGraficaQA();
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.oList = oList;
                    frm.ShowDialog();
                    this.Close();
                } else {
                    RadMessageBox.Show("No existen datos a graficar con los criterios seleccionados", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                }
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrio un error al cargar las gráficas\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally {
                oEnsamble = null;
            }
        }
        private void dtDesde_ValueChanged(object sender, EventArgs e)
        {
            try {
                this.dtHasta.MinDate = dtDesde.Value;
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

    }
}
