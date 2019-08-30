using Hersan.Entidades.Nomina;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace Hersan.UI.Nomina
{
    public partial class frmIncidencias : Telerik.WinControls.UI.RadForm
    {
        WCF_Nomina.Hersan_NominaClient oNomina;
        List<SemanasBE> oSemanas = new List<SemanasBE>();
        List<IncidenciasBE> oList = new List<IncidenciasBE>();
        List<FonacotBE> oFonacot = new List<FonacotBE>();

        public frmIncidencias()
        {
            InitializeComponent();
        }
        private void FrmIncidencias_Load(object sender, EventArgs e)
        {
            try {
                CargaSemanas();
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al cargar la pantalla\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            try {
                CargaDatos();
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al cargar la pantalla\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            oNomina = new WCF_Nomina.Hersan_NominaClient();
            try {
                if (oList.FindAll(item=> item.Semana.Semana == int.Parse(cboSemana.Text)).Count == 0) {
                    if (RadMessageBox.Show("Desea guardar las incidencias de la semana...?", this.Text, MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.Yes) {
                        oList.ForEach(item => item.Semana.Semana = int.Parse(cboSemana.Text));
                        int Result = oNomina.NOM_Incidencias_Guardar(oList, oFonacot);
                        if (Result == 0)
                            RadMessageBox.Show("Ocurrió un error al guardar las incidencias", this.Text, MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                        else {
                            RadMessageBox.Show("Incidencias guardadas correctamente", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                            CargaDatos();
                        }
                    }
                } else
                    RadMessageBox.Show("Las incidencias ya se encuentran guardadas y no pueden modificarse", this.Text, MessageBoxButtons.OK, RadMessageIcon.Exclamation);
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al guardar las incidencias\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally { oNomina = null; }
        }
        private void BtnBorrar_Click(object sender, EventArgs e)
        {
            try {
                gvDatos.DataSource = null;
                oList.RemoveAll(item => item.Sel == true);
                gvDatos.DataSource = oList;
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al borrar los registros\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void Btnimportar_Click(object sender, EventArgs e)
        {
            OpenFileDialog oDialog = new OpenFileDialog();
            try {
                if(oList.FindAll(item => item.Semana.Semana == int.Parse(cboSemana.Text)).Count > 0) {
                    RadMessageBox.Show("Las incidencias ya se encuentran guardadas y no pueden modificarse", this.Text, MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                    return;
                }

                oDialog.InitialDirectory = "";
                oDialog.Filter = "csv files (*.csv)|*.csv";
                oDialog.RestoreDirectory = true;

                if(oFonacot.Count > 0)
                    if(RadMessageBox.Show("Ya se ha cargado el archivo de fonacot\nDesea cargarlo de nuevo...?",this.Text, MessageBoxButtons.YesNo,RadMessageIcon.Question) == DialogResult.No)
                        return;

                if (oDialog.ShowDialog() == DialogResult.OK) {
                    oFonacot.Clear();
                    LeerCSV(oDialog.FileName);
                    if(oFonacot.Count > 0) {                        
                        oList.ForEach(item => {
                            var aux = oFonacot.Find(x => x.CLAVE_EMPLEADO == item.Empleado.Numero && x.NO_SS == item.Empleado.Expedientes.Documentos.IMSS);
                            if (aux != null) {
                                item.Fonacot = true;
                            }else
                                item.Fonacot = false;
                        });
                        RadMessageBox.Show("Archivo cargado correctamente", this.Text, MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                    }
                }

                gvDatos.DataSource = null;
                gvDatos.DataSource = oList;                
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al cargar el archivo\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
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
        private void CboSemana_SelectedIndexChanged(object sender, EventArgs e)
        {
            try {
                CargaDatos();
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al seleccionar la semana\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }

        private void CargaSemanas()
        {
            oNomina = new WCF_Nomina.Hersan_NominaClient();
            List<SemanasBE> oAux = new List<SemanasBE>();
            try {
                oSemanas = oNomina.NOM_Semanas_Obtener(DateTime.Today.Year);

                cboSemana.ValueMember = "Id";
                cboSemana.DisplayMember = "Semana";
                cboSemana.DataSource = oSemanas;

                if (oSemanas.Count > 0) {
                    oAux = oSemanas.FindAll(item => item.Termina >= DateTime.Today && item.DatosUsuario.Estatus == true && item.Termina.Year == DateTime.Today.Year);
                    cboSemana.SelectedValue = oSemanas.Find(item => item.Id == oAux[0].Id).Id;
                }
            } catch (Exception ex) {
                throw ex;
            } finally { oNomina = null; }
        }
        private void CargaDatos()
        {
            oNomina = new WCF_Nomina.Hersan_NominaClient();
            try {
                oList = oNomina.NOM_Incidencias_Obtener(int.Parse(cboSemana.Text));
                gvDatos.DataSource = oList;
            } catch (Exception ex) {
                throw ex;
            } finally {
                oNomina = null;
            }
         }
        private void LeerCSV(string filename)
        {

            try {
                using (StreamReader sr = new StreamReader(filename)) {
                    string line = sr.ReadLine();
                    var value = line.Split(',');
                    string[] Cols = value.Select(x => x.ToString()).ToArray();//Columns
                    FonacotBE Obj;

                    while (!sr.EndOfStream) {
                        //value = sr.ReadLine().Split(',');
                        //string[] Rowresult = value.Select(x => x.ToString()).ToArray();//Values
                        string[] Rows = sr.ReadLine().Split(',').Select(x => x.ToString()).ToArray();//Values
                        Obj = new FonacotBE(); //1-7, 9, 11
                        for (int j = 1; j < Rows.Count() - 3; j++) {
                            Obj.ANIO_EMISION = int.Parse(Rows[1].ToString());
                            Obj.MES_EMISION = int.Parse(Rows[2].ToString());
                            Obj.NO_FONACOT = Rows[3].ToString();
                            Obj.RFC = Rows[4].ToString();
                            Obj.NO_SS = Rows[5].ToString();
                            Obj.Nombre = Rows[6].ToString();
                            Obj.CLAVE_EMPLEADO = int.Parse(Rows[7].ToString());
                            Obj.RETENCION_MENSUAL = decimal.Parse(Rows[9].ToString());
                            Obj.RETENCION_REAL = decimal.Parse(Rows[11].ToString());
                        }
                        Obj.Semanas = 0;
                        Obj.Descuento = Obj.RETENCION_MENSUAL / 4;

                        oFonacot.Add(Obj);
                    }
                }
            } catch (Exception ex) {
                throw ex;
            }
        }

    }
}
