using Hersan.Entidades.Catalogos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace Hersan.UI.Ensamble
{
    public partial class frmPedidosConsulta : Telerik.WinControls.UI.RadForm
    {
        WCF_Catalogos.Hersan_CatalogosClient oCatalogos;
        WCF_Ensamble.Hersan_EnsambleClient oEnsamble;

        public frmPedidosConsulta()
        {
            InitializeComponent();
        }
        private void frmPedidosConsulta_Load(object sender, EventArgs e)
        {
            try {
                dtInicial.Value = DateTime.Today;
                dtInicial.Checked = false;
                dtFinal.Enabled = dtInicial.Checked;

                CargaAgentes();
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al cargar la pantalla\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            oEnsamble = new WCF_Ensamble.Hersan_EnsambleClient();
            try {
                string Inicial = !dtInicial.Checked ? "19000101" : dtInicial.Value.Year.ToString() + dtInicial.Value.Month.ToString().PadLeft(2, '0')
                    + dtInicial.Value.Day.ToString().PadLeft(2, '0');
                string Final = !dtInicial.Checked ? "29000101" : dtFinal.Value.Year.ToString() + dtFinal.Value.Month.ToString().PadLeft(2, '0')
                        + dtFinal.Value.Day.ToString().PadLeft(2, '0');

                gvDatos.DataSource = oEnsamble.ENS_Pedido_Consulta(int.Parse(cboAgentes.SelectedValue.ToString()), int.Parse(txtId.Text), Inicial, Final);

                if (gvDatos.RowCount == 0) {
                    gvDetalle.DataSource = null;
                    RadMessageBox.Show("No se encontraron pedidos con los criterios seleccionados.", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                }
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al cargar los pedidos\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try {
                if (gvDatos.RowCount > 0)
                    Reporte(false);
                else
                    RadMessageBox.Show("No ha seleccionado un pedido", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al mostrar el reporte\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void btnEnviar_Click(object sender, EventArgs e)
        {
            try {
                if (gvDatos.RowCount > 0) {
                    frmCotizacionCorreo frm = new frmCotizacionCorreo();
                    frm.Correo = gvDatos.CurrentRow.Cells["Correo1"].Value.ToString() + "," + gvDatos.CurrentRow.Cells["Correo2"].Value.ToString();
                    frm.Archivo = Reporte(true);
                    frm.Id = gvDatos.CurrentRow.Cells["Id"].Value.ToString();
                    frm.Tipo = "Pedido";

                    frm.StartPosition = FormStartPosition.CenterParent;
                    frm.ShowDialog();
                } else
                    RadMessageBox.Show("No ha seleccionado un pedido", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al enviar el correo\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
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
        private void dtInicial_ValueChanged(object sender, EventArgs e)
        {
            try {
                dtFinal.Enabled = dtInicial.Checked;
                dtFinal.MinDate = dtInicial.Value;
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al seleccionar la fecha\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void gvDatos_CurrentRowChanged(object sender, Telerik.WinControls.UI.CurrentRowChangedEventArgs e)
        {
            oEnsamble = new WCF_Ensamble.Hersan_EnsambleClient();
            try {
                if (gvDatos.RowCount > 0)
                    gvDetalle.DataSource = oEnsamble.ENS_Cotizacion_ReporteDetalle(int.Parse(gvDatos.CurrentRow.Cells["Id"].Value.ToString()));

            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al seleccionar el pedido\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }

        private void CargaAgentes()
        {
            oCatalogos = new WCF_Catalogos.Hersan_CatalogosClient();
            try {
                List<AgentesBE> oList = new List<AgentesBE>();
                oList = oCatalogos.ABC_Agentes_Combo();
                oList.Add(new AgentesBE { Id = 0, Clave = "TODO", Nombre = "TODOS", Comision = 0 });

                cboAgentes.ValueMember = "Id";
                cboAgentes.DisplayMember = "Nombre";
                cboAgentes.DataSource = oList;

                cboAgentes.SelectedIndex = oList.Count - 1;
            } catch (Exception ex) {
                throw ex;
            } finally {
                oCatalogos = null;
            }
        }
        private Stream Reporte(bool Correo)
        {
            oEnsamble = new WCF_Ensamble.Hersan_EnsambleClient();
            Stream archivo = null;
            try {
                frmViewer frm = new frmViewer();
                frm.iReport = new Reportes.rptCotizacion();

                frm.iReport.SetDataSource(oEnsamble.ENS_Cotizacion_Reporte(int.Parse(gvDatos.CurrentRow.Cells["Id"].Value.ToString())));
                frm.iReport.Subreports["Detalle"].SetDataSource(oEnsamble.ENS_Cotizacion_ReporteDetalle(int.Parse(gvDatos.CurrentRow.Cells["Id"].Value.ToString())));

                if (Correo) {
                    archivo = frm.iReport.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                } else {
                    //MOSTRAR EN PANTALLA
                    frm.WindowState = FormWindowState.Maximized;
                    frm.ShowDialog();
                }
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al mostrar el reporte\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally {
                oEnsamble = null;
            }
            return archivo;
        }

    }
}
