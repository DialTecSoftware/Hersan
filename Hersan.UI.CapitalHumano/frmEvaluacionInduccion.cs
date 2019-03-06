using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace Hersan.UI.CapitalHumano
{
    public partial class frmEvaluacionInduccion : Telerik.WinControls.UI.RadForm
    {
      
       public frmEvaluacionInduccion()
        {
            InitializeComponent();
        }

        private void frmEvaluacionInduccion_Load(object sender, EventArgs e)
        {
            try {

                lblfecha.Text = DateTime.Now.ToLongDateString();
                Cargar_Cuestionario();

            } catch (Exception) {

                throw;
            }
        }

        private void Imprimir_Archivo()
        {
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "PDF file|*.pdf", ValidateNames = true }) {
                if (sfd.ShowDialog() == DialogResult.OK) {
                    iTextSharp.text.Document doc = new iTextSharp.text.Document(PageSize.A4.Rotate());
                    try {
                        iTextSharp.text.pdf.PdfWriter.GetInstance(doc, new FileStream(sfd.FileName, FileMode.Create));
                        doc.Open();
                        doc.Add(new iTextSharp.text.Paragraph(radPanel1.Text));
                       
                    } catch (Exception ex) {
                        MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    } finally {
                        doc.Close();
                    }
                }
            }


        }
        
        private void CalcularResultado()
        {
            try {

                decimal res = 0;
            int result = 0;
            IList<GridViewRowInfo> gridRows = new List<GridViewRowInfo>();
            foreach (GridViewRowInfo rowInfo in gvDatos.ChildRows) {
                bool isChecked4 = Convert.ToBoolean(rowInfo.Cells["Valor4"].Value);
                bool isChecked3 = Convert.ToBoolean(rowInfo.Cells["Valor3"].Value);
                bool isChecked2 = Convert.ToBoolean(rowInfo.Cells["Valor2"].Value);
                bool isChecked1 = Convert.ToBoolean(rowInfo.Cells["Valor1"].Value);
                if (isChecked4 == true) {
                    result = result + 4;
                    gridRows.Add(rowInfo);

                }
                if (isChecked3 == true) {
                    result = result + 3;
                    gridRows.Add(rowInfo);

                }
                if (isChecked2 == true) {
                    result = result + 2;
                    gridRows.Add(rowInfo);

                }
                if (isChecked1 == true) {
                    result = result + 1;
                    gridRows.Add(rowInfo);

                } else {
                    result = result + 0;
                }
                     res = result;
            }
            RadMessageBox.Show("Hey:" + result);
                lblCalif.Text = "" + (res * 10) / 76 + "/10";
                
            } catch (Exception) {

                throw;
            }

        }


        private void Cargar_Cuestionario()
        {

            gvDatos.ColumnCount = 5;
            gvDatos.Columns[0].Name = "Preguntas";


            //gvDatos.Rows[2].Cells[3].Value = "true";

            string[] row = new string[] { "1.- Organigrama" };
            gvDatos.Rows.Add(row);
            row = new string[] { "2.- Visión" };
            gvDatos.Rows.Add(row);
            row = new string[] { "3.- Misión" };
            gvDatos.Rows.Add(row);
            row = new string[] { "4.- Objetivos de la empresa" };
            gvDatos.Rows.Add(row);
            row = new string[] { "5.- Políticas de la empresa" };
            gvDatos.Rows.Add(row);
            row = new string[] { "6.- Contrato laboral" };
            gvDatos.Rows.Add(row);
            row = new string[] { "7.- Funciones y responsabilidades de tu cargon" };
            gvDatos.Rows.Add(row);
            row = new string[] { "8.- Derechos y deberes del trabajador" };
            gvDatos.Rows.Add(row);
            row = new string[] { "9.- Reglamento interior de la empresaVisión" };
            gvDatos.Rows.Add(row);
            row = new string[] { "10.- Riesgos a los que están expuestos" };
            gvDatos.Rows.Add(row);
            row = new string[] { "11.- Trabajos de alto riego" };
            gvDatos.Rows.Add(row);
            row = new string[] { "12.- Generalidades sobre Seguridad Social" };
            gvDatos.Rows.Add(row);

        }

      

        private void gvDatos_ValueChanged(object sender, EventArgs e)
        {
            GridDataCellElement cell = sender as GridDataCellElement;
            if (cell != null && ((GridViewDataColumn)cell.ColumnInfo).FieldName == "Bool") {
                this.gvDatos.BeginUpdate();
                foreach (GridViewDataRowInfo row in this.gvDatos.Rows) {
                    if (row != this.gvDatos.CurrentRow) {
                        row.Cells["Bool"].Value = false;
                    }
                }
                this.gvDatos.EndUpdate();
            }



        }

        private void commandBarButton1_Click(object sender, EventArgs e)
        {

                try {
                    CalcularResultado();
                //Imprimir_Archivo();


                } catch (Exception) {

                    throw;
                }

        }
        

       
    }
}
