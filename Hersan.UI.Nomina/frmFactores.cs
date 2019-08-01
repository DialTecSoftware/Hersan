using Hersan.Entidades.Nomina;
using Hersan.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace Hersan.UI.Nomina
{
    public partial class frmFactores : Telerik.WinControls.UI.RadForm
    {
        WCF_Nomina.Hersan_NominaClient oNomina;
        List<FactoresBE> oList = new List<FactoresBE>();

        public frmFactores()
        {
            InitializeComponent();
        }
        private void frmFactores_Load(object sender, EventArgs e)
        {
            try {
                CargarGrid();
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al cargar la pantalla\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
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
            //oNomina = new WCF_Nomina.Hersan_NominaClient();
            //try {
            //    if (RadMessageBox.Show("Desea guardar los cambios...?", this.Text, MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.Yes) {
            //        //int Result = oNomina.PRO_Inyeccion_Guardar(Obj);
            //        if (Result == 0) {
            //            RadMessageBox.Show("Ocurrió un error al guardar la informacion", this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            //        } else {
            //            RadMessageBox.Show("Información guardada correctamente", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
            //            CargarGrid();
            //        }
            //    } else 
            //        RadMessageBox.Show("Debe capturar la OP y Seleccionar el color para continuar", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                
            //} catch (Exception ex) {
            //    RadMessageBox.Show("Ocurrió un error al guardar los datos\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            //} finally {
            //    oNomina = null;
            //}
        }


        private void CargarGrid()
        {
            oNomina = new WCF_Nomina.Hersan_NominaClient();
            try {
                oList = oNomina.Nom_Factores_Obtener();
                gvDatos.DataSource = oList;
            } catch (Exception ex) {
                throw ex;
            } finally {
                oNomina = null;
            }
        }
        private DataTable CrearTablasAuxiliares()
        {
            DataTable oData;

            try {
                oData = new DataTable("Detalle");
                oData.Columns.Add("FAC_Id");
                oData.Columns.Add("FAC_De");
                oData.Columns.Add("FAC_Hasta");
                oData.Columns.Add("FAC_Aguinaldo");
                oData.Columns.Add("FAC_Vacaciones");
                oData.Columns.Add("FAC_Prima");
                oData.Columns.Add("FAC_Factor");

                CargarTablas(ref oData);

            } catch (Exception ex) {
                throw ex;
            }
            return oData;
        }
        private void CargarTablas(ref DataTable oData)
        {
            try {
                foreach (var item in oList) {
                    DataRow oRow = oData.NewRow();
                    oRow["FAC_Id"] = item.Id;
                    oRow["FAC_De"] = item.De;
                    oRow["FAC_Hasta"] = item.Hasta;
                    oRow["FAC_Aguinaldo"] = item.Aguinaldo;
                    oRow["FAC_Vacaciones"] = item.Vacaciones;
                    oRow["FAC_Prima"] = item.Prima;
                    oRow["FAC_Factor"] = item.Factor;
                
                    oData.Rows.Add(oRow);
                }

            } catch (Exception ex) {
                throw ex;
            }
        }

    }
}
