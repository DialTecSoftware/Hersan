using Hersan.Entidades.CapitalHumano;
using Hersan.Entidades.Catalogos;
using Hersan.Negocio;
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
         #region Constantes

        public int IdExpediente { get; set; }
        CapitalHumano.WCF_Catalogos.Hersan_CatalogosClient oCatalogo;
        CapitalHumano.WCF_CHumano.Hersan_CHumanoClient oCHumano;
        List<EvaluacionInduccionBE> oList = new List<EvaluacionInduccionBE>();
        List<PreguntasEvaluacionBE> list = new List<PreguntasEvaluacionBE>();
        EvaluacionInduccionBE eva = new EvaluacionInduccionBE();
        List<EntidadesBE> oEntidades = new List<EntidadesBE>();
        List<ExpedientesBE> oExpediente = new List<ExpedientesBE>();

        #endregion

        private void LimpiarCampos()
        {
         
            txtObservaciones.Text = string.Empty;
            txtNombres.Text = string.Empty;
            txtNoEmp.Text = string.Empty;
            txtId.Text = string.Empty;
            LimpiarRespuestas();
        }

        private bool ValidarCampos()
        {
            bool Flag = true;
            try {
                Flag = txtObservaciones.Text.Trim().Length == 0 ? false : true;


                return Flag;
            } catch (Exception ex) {
                throw ex;
            }
        }
        private void Imprimir_Archivo()
        {
          
        }
       
        private void LimpiarRespuestas()
        {
            try {

                foreach (GridViewRowInfo row in gvDatos.Rows) {
                    row.Cells["Valor4"].Value = row.Cells["Valor3"].Value
                    = row.Cells["Valor2"].Value = row.Cells["Valor1"].Value = false;
                }
            } catch (Exception) {

                throw;
            }
        }

        private void CalcularResultado()
        {
            try {

                int count = 0;
                decimal res = 0;
                decimal result = 0;
                IList<GridViewRowInfo> gridRows = new List<GridViewRowInfo>();
                foreach (GridViewRowInfo rowInfo in gvDatos.ChildRows) {
                    bool isChecked4 = Convert.ToBoolean(rowInfo.Cells["Valor4"].Value);
                    bool isChecked3 = Convert.ToBoolean(rowInfo.Cells["Valor3"].Value);
                    bool isChecked2 = Convert.ToBoolean(rowInfo.Cells["Valor2"].Value);
                    bool isChecked1 = Convert.ToBoolean(rowInfo.Cells["Valor1"].Value);
                    if (isChecked4 == true) {
                        result = result + 4;
                        gridRows.Add(rowInfo);
                        count++;
                    }
                    if (isChecked3 == true) {
                        result = result + 3;
                        gridRows.Add(rowInfo);
                        count++;
                    }
                    if (isChecked2 == true) {
                        result = result + 2;
                        gridRows.Add(rowInfo);
                        count++;
                    }
                    if (isChecked1 == true) {
                        result = result + 1;
                        gridRows.Add(rowInfo);
                        count++;
                    } else {
                        result = result + 0;
                    }
                    res = result * 10 / 76;

                    eva.Count = count;
                    if (eva.Count == 19) {
                        eva.Calificacion = res;
                        
                    }
                }


            } catch (Exception) {

                throw;
            }

        }
        private void CargarPreguntasEvaluacion()
        {
            oCHumano = new WCF_CHumano.Hersan_CHumanoClient();
            try {


                list = oCHumano.CHU_ObtenerPreguntas();
                gvDatos.DataSource = list;
            


            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrio un error al cargar los elementos del dictamen\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally {
                oCHumano = null;
            }
        }
        private DataSet CrearTablasAuxiliares()
        {
            DataSet oDataset = new DataSet();
            DataTable oData;

            try {
                #region TABLA DE ENCABEZADO
                oData = new DataTable("Evaluacion");
                oData.Columns.Add("EVI_Id");
                oData.Columns.Add("EMP_Numero");
                oData.Columns.Add("EVI_Observaciones");
                oData.Columns.Add("EVI_Calificaciones");
                oData.Columns.Add("EVI_idUsuarioCreo");
                oDataset.Tables.Add(oData);
                #endregion

                #region PREGUNTAS
                oData = new DataTable("Respuestass");
                oData.Columns.Add("EVI_Id");
                oData.Columns.Add("REV_Id");
                oData.Columns.Add("REV_Valor1");
                oData.Columns.Add("REV_Valor2");
                oData.Columns.Add("REV_Valor3");
                oData.Columns.Add("REV_Valor4");
                oDataset.Tables.Add(oData);
                 #endregion
            } catch (Exception ex) {
                throw ex;
            }
            return oDataset;
        }


        private void CargaExpediente(int IdExpediente)
        {
            oCHumano = new WCF_CHumano.Hersan_CHumanoClient();

            try {
                oExpediente = oCHumano.CHU_Expedientes_Obtener(IdExpediente);
                if (oExpediente.Count > 0) {

                    //  SE CARGA EL EXPEDIENTE
                    txtId.Text = IdExpediente.ToString();

                    ExpedientesDatosPersonales oAux = new ExpedientesDatosPersonales();
                    oAux.IdExpediente = int.Parse(txtId.Text);
                    var Item = oCHumano.CHU_ExpedientesDatosPersonales_Consultar(oAux);

                    if (Item.Count > 0) {
                        txtApellidos.Text = Item[0].APaterno + " " + Item[0].AMaterno;
                        txtNombres.Text = Item[0].Nombres;
                        txtNoEmp.Text = Item[0].Empleados.Id.ToString();
                    }
                }
            } catch (Exception) {

                throw;
            }
        }




        public frmEvaluacionInduccion()
        {
            InitializeComponent();
        }
        private void frmEvaluacionInduccion_Load(object sender, EventArgs e)
        {
            try {
                lblFecha.Text = DateTime.Now.ToLongDateString();
                //Cargar_Cuestionario();
                CargarPreguntasEvaluacion();
            
              

            } catch (Exception) {

                throw;
            }
        }
        private void Entero_KeyPress(object sender, KeyPressEventArgs e)
        {
            try {
                if (!BaseWinBP.isNumero(e.KeyChar))
                    e.Handled = true;
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error en la captura\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }


        private void txtBusqueda_KeyPress(object sender, KeyPressEventArgs e)
        {
          
        }
        private void gvDatos_CellValueChanged_1(object sender, GridViewCellEventArgs e)
        {
            //e.ColumnIndex >= 1a. Columna con Checkbox)
            if (e.ColumnIndex >= 2) {
                //SE OBTIENE EL VALOR DEL CHECK
                var isChecked = (bool)gvDatos.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
               
                if (isChecked) {

                    foreach (GridViewDataColumn col in gvDatos.Columns) {
                        if (col.Index >= 2 && col.Index != e.ColumnIndex)
                            //SE CAMBIA A FALSE LOS CHECKBOX NO MARCADOS
                            gvDatos.CurrentRow.Cells[col.Index].Value = !isChecked;

                    }

                }

            }

        }



        private void gvDatos2_CurrentRowChanged(object sender, CurrentRowChangedEventArgs e)
        {

         //   if (gvDatos2.RowCount > 0 && e.CurrentRow.ChildRows.Count == 0 ) {
         //       txtNoEmp.Text = e.CurrentRow.Cells["EMP_Num"].Value.ToString();
         //       txtNombres.Text = e.CurrentRow.Cells["EDP_APaterno"].Value.ToString() + " " + e.CurrentRow.Cells["EDP_AMaterno"].Value.ToString() + " "
         //           + e.CurrentRow.Cells["EDP_Nombres"].Value.ToString();
               
         //   } else 

         ///*  if (gvDatos2.RowCount == 0)*/ {
         //       txtNombres.Text = "";
         //       txtNoEmp.Text = "";
         //   }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try {
              
                txtId.Text = "-1";

            } catch (Exception) {

                throw;
            }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            oCatalogo = new CapitalHumano.WCF_Catalogos.Hersan_CatalogosClient();
            oCHumano = new CapitalHumano.WCF_CHumano.Hersan_CHumanoClient();
            EvaluacionInduccionBE obj = new EvaluacionInduccionBE();
            DataSet oData = CrearTablasAuxiliares();
            int Result = 0;
            try {
                CalcularResultado();
                if (!ValidarCampos()) {
                    RadMessageBox.Show("Debe capturar todos los datos para continuar", this.Text, MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                    return;
                }

                if (eva.Count != 19) {
                    RadMessageBox.Show("Debe contestar todas las preguntas para continuar\n" + (19 - eva.Count) + " Pregunta(s) faltante(s)", this.Text, MessageBoxButtons.OK, RadMessageIcon.Exclamation);

                    return;
                }

                if (oList.FindAll(item => item.IdEmpleado == int.Parse(txtNoEmp.Text) ).Count > 0
                   && int.Parse(txtId.Text) == -1) {
                    RadMessageBox.Show("Este empleado ya ha realizado su evaluación, no es posible guardar", this.Text, MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                    LimpiarCampos();
                    return;
                }
                #region Entidades
                obj.Id = int.Parse(txtId.Text);
                obj.IdEmpleado = int.Parse(txtNoEmp.Text);
                obj.Observaciones = txtObservaciones.Text;
                obj.DatosUsuario.IdUsuarioCreo = BaseWinBP.UsuarioLogueado.ID;
                #endregion



                #region Carga Datos Encabezado
                DataRow oRow = oData.Tables["Evaluacion"].NewRow();
                oRow["EVI_Id"] = int.Parse(txtId.Text);
                oRow["EMP_Numero"] = int.Parse(txtNoEmp.Text);
                oRow["EVI_Observaciones"] = txtObservaciones.Text;
                oRow["EVI_Calificaciones"] = int.Parse(txtCalif.Text);
                oRow["EVI_idUsuarioCreo"] = BaseWinBP.UsuarioLogueado.ID;

                oData.Tables["Evaluacion"].Rows.Add(oRow);
                #endregion

                #region Carga Datos Evaluacion           
                list.ForEach(item => {
                     oRow = oData.Tables["Respuestass"].NewRow();
                    //oRow["EVI_Id"] = int.Parse(txtId.Text);
                    oRow["REV_Id"] = item.Id;
                    oRow["REV_Valor1"] = item.Valor1;
                    oRow["REV_Valor2"] = item.Valor2;
                    oRow["REV_Valor3"] = item.Valor3;
                    oRow["REV_Valor4"] = item.Valor4;

                    oData.Tables["Respuestass"].Rows.Add(oRow);

                });
              




                #endregion

                if (txtId.Text == "-1") {
                     Result = oCHumano.CHU_EvaluacionInduccion_Guardar(oData,BaseWinBP.UsuarioLogueado.ID);
                    if (Result == 0) {
                        RadMessageBox.Show("Ocurrió un error al enviar la solicitud de empleo",  this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
                    } else {
                        RadMessageBox.Show("Evaluacion realizda correctamente\n " + Result.ToString() , this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);

                        LimpiarCampos();

                    }
                } else
                   
                    if (txtId.Text == "-") {
                        RadMessageBox.Show("Presiona el buton Nuevo para antes de guradar una nueva evaluación", this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
                   
                }
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrio un error al actualizar la información\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally {

                oCHumano = null;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            try {

                this.Close();
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al cerra la pantalla\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int IdExpediente = 0;
            try {
                frmExpedienteConsulta ofrm = new frmExpedienteConsulta();
                ofrm.WindowState = FormWindowState.Normal;
                ofrm.StartPosition = FormStartPosition.CenterScreen;
                ofrm.MaximizeBox = false;
                ofrm.MinimizeBox = false;
                ofrm.ShowDialog();
                IdExpediente = ofrm.IdExpediente;


                if (IdExpediente > 0) {
                    LimpiarCampos();
                    CargaExpediente(IdExpediente);
                   
                }
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al realiza la búsqueda\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }

        private void lblNum_Click(object sender, EventArgs e)
        {

        }

        private void txtCalif_Validating(object sender, CancelEventArgs e)
        {
            int val = 0;
     if (txtCalif.Text!="")
             val = int.Parse(txtCalif.Text);
            if (val > 10) {
                errorProvider1.SetError(txtCalif, "Debe de ser un valor inferior o igual a 10");
                e.Cancel = true;
            } else
                errorProvider1.Clear();
        }
    }
}

