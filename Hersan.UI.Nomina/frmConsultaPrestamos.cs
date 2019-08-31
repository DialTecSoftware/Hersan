using Hersan.Entidades.CapitalHumano;
using Hersan.Entidades.Nomina;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI.Export;

namespace Hersan.UI.Nomina
{
    public partial class frmConsultaPrestamos : Telerik.WinControls.UI.RadForm
    {
        #region Variables        
        WCF_Nomina.Hersan_NominaClient oNomina;
        WCF_CHumano.Hersan_CHumanoClient oCHUmano;
        List<SemanasBE> oList = new List<SemanasBE>();
        List<PrestamosBE> oPrestamo = new List<PrestamosBE>();
        List<PrestamosDetalleBE> oDetalle = new List<PrestamosDetalleBE>();
        List<EmpleadosBE> oEmpleados = new List<EmpleadosBE>();
        #endregion

        public frmConsultaPrestamos()
        {
            InitializeComponent();
        } 
        private void FrmConsultaPrestamos_Load(object sender, EventArgs e)
        {
            try {
                CargaEmpleados();
                CargaSemanas();
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al cargar la pantalla\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            oNomina = new WCF_Nomina.Hersan_NominaClient();            
            try {
                PrestamosBE item = new PrestamosBE();
                item.Empleado.Id = int.Parse(cboEmpleados.SelectedValue.ToString());
                item.SemanaAplica = int.Parse(cboDesde.Text);
                item.NoPagos = int.Parse(cboHasta.Text);
                item.Id = int.Parse(spFolio.Value.ToString());
                item.Empleado.NumeroCuenta = opVigente.IsChecked ? "VIGENTE" : opPagado.IsChecked ? "PAGADO" : "";

                oPrestamo = oNomina.NOM_Prestamos_Consulta(item);
                oDetalle.Clear();
                oPrestamo.ForEach(Item => {
                    oDetalle.AddRange(Item.Detalle.FindAll(x => x.Id > 0));
                });

                gvDatos.MasterTemplate.DataSource = oPrestamo;
                gvDatos.Templates[0].DataSource = oDetalle;
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al cargar los préstamos\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void BtnExportar_Click(object sender, EventArgs e)
        {
            try {
                if (gvDatos.RowCount > 0) {
                    if (RadMessageBox.Show("El listado se exportará en formato de excel, desea continuar...?", this.Text, MessageBoxButtons.YesNo) == DialogResult.Yes) {
                        SaveFileDialog saveFile = new SaveFileDialog();
                        saveFile.Filter = "Excel|*.xls";
                        saveFile.Title = "Guardar Archivo";
                        saveFile.ShowDialog();

                        if (saveFile.FileName != "") {
                            var exportar = new ExportToExcelML(gvDatos);
                            exportar.ExportVisualSettings = true;
                            exportar.HiddenColumnOption = HiddenOption.DoNotExport;
                            exportar.ExportHierarchy = true;
                            exportar.FileExtension = "xls";
                            exportar.SheetName = "Préstamos";
                            exportar.RunExport(saveFile.FileName);
                        }

                        RadMessageBox.Show("Archivo exportado correctamente", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                    }
                }
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al exportar los préstamos\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void BtnSalir_Click(object sender, EventArgs e)
        {
            try {
                this.Close();
            } catch (Exception ex) {
                throw ex;
            }
        }
        private void CboDesde_SelectedIndexChanged(object sender, EventArgs e)
        {
            try {
                cboHasta.ValueMember = "Id";
                cboHasta.DisplayMember = "Semana";
                cboHasta.DataSource = oList.FindAll(item => item.Semana >= int.Parse(cboDesde.Text));
            } catch (Exception ex) {
                throw ex;
            }
        }

        private void CargaSemanas()
        {
            oNomina = new WCF_Nomina.Hersan_NominaClient();
            List<SemanasBE> oAux = new List<SemanasBE>();
            try {
                oList = oNomina.NOM_Semanas_Obtener(DateTime.Today.Year);                

                cboDesde.ValueMember = "Id";
                cboDesde.DisplayMember = "Semana";
                cboDesde.DataSource = oList;

                if (oList.Count > 0) {
                    oAux = oList.FindAll(item => item.Termina >= DateTime.Today && item.DatosUsuario.Estatus == true && item.Termina.Year == DateTime.Today.Year);
                    cboDesde.SelectedValue = oList.Find(item => item.Id == oAux[0].Id).Id;
                }
            } catch (Exception ex) {
                throw ex;
            } finally { oNomina = null; }
        }
        private void CargaEmpleados()
        {
            oCHUmano = new WCF_CHumano.Hersan_CHumanoClient();
            EmpleadosBE obj = new EmpleadosBE();
            try {
                obj.Id = 0;
                obj.Numero = 0;
                obj.Expedientes.DatosPersonales.Nombres = "TODOS";

                oEmpleados = oCHUmano.CHU_Empleados_Combo();
                oEmpleados.Add(obj);

                cboEmpleados.ValueMember = "Id";
                cboEmpleados.DisplayMember = "Numero";
                cboEmpleados.DataSource = oEmpleados;

                cboEmpleados.SelectedValue = 0;
            } catch (Exception ex) {
                throw ex;
            } finally { oCHUmano = null; }
        }

    }
}
