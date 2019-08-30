using Hersan.Entidades.CapitalHumano;
using Hersan.Entidades.Nomina;
using Hersan.Negocio;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Telerik.WinControls;

namespace Hersan.UI.Nomina
{
    public partial class frmPrestamos : Telerik.WinControls.UI.RadForm
    {
        #region Variables
        WCF_Nomina.Hersan_NominaClient oNomina;
        WCF_CHumano.Hersan_CHumanoClient oCHUmano;
        List<SemanasBE> oList = new List<SemanasBE>();
        List<PrestamosDetalleBE> oPrestamo;
        List<EmpleadosBE> oEmpleados = new List<EmpleadosBE>();
        int NumPagos = 0;
        int Semana = 0;
        decimal Importe = 0;
        decimal Tasa = 0;
        decimal ImpPago = 0;
        #endregion

        public frmPrestamos()
        {
            InitializeComponent();
        }
        private void frmPrestamos_Load(object sender, EventArgs e)
        {            
            try {
                System.Threading.Tasks.Task task = new System.Threading.Tasks.Task(() => { CargaSemanas(); });
                task.RunSynchronously();

                task = new System.Threading.Tasks.Task(() => { CargaEmpleados(); });
                task.RunSynchronously();

                ObtenerParametros();                 
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
            oNomina = new WCF_Nomina.Hersan_NominaClient();
            int Result = 0;
            try {                
                try {
                    if(RadMessageBox.Show("Esta acción generará el prestamo para el empleado\nDesea continuar...?", this.Text, MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.No) {
                        return;
                    } 

                    System.Data.DataTable oData = BaseWinBP.ToDataTable(oPrestamo);
                    if (ValidarCampos()) {
                        if (dgGrid.RowCount == 0) {
                            btnGenerar_Click(new object(), new EventArgs());
                        }

                        PrestamosBE obj = new PrestamosBE();
                        obj.Empleado.Id = int.Parse(cboEmpleados.SelectedValue.ToString());
                        obj.Tasa = decimal.Parse(txtTasa.Text);
                        obj.ImporteTotal = decimal.Parse(txtImporte.Text);
                        obj.NoPagos = (txtPagos.Enabled == true ? int.Parse(txtPagos.Text) : 0);
                        obj.ImportePago = decimal.Parse(txtPago.Text);
                        obj.SemanaAplica = int.Parse(cboSemana.Text);
                        obj.Estatus = "VIGENTE";
                        obj.DatosUsuario.IdUsuarioCreo = BaseWinBP.UsuarioLogueado.ID;

                        Result = oNomina.NOM_Prestamos_Guardar(obj, oData);
                        if (Result == 0) {
                            RadMessageBox.Show("Ocurrió un error al generar el préstamo",this.Text, MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                        } else {
                            RadMessageBox.Show("Se ha generado el préstamo No. " + Result.ToString() , this.Text, MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                            LimpiarCampos();
                        }
                    }
                } catch (Exception ex) {
                    RadMessageBox.Show("Ocurrió un error al guardar el préstamo\n"+ ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
                } finally { oNomina = null; }

                
            } catch (Exception ex) {
                throw ex;
            }
        }
        private void btnGenerar_Click(object sender, EventArgs e)
        {
            try {
                GenerarTablaAmortizacion();
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al generar la tabla de amortización\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try {

            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al imprimir\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
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
        private void txtPagos_ValueChanged(object sender, EventArgs e)
        {
            try {
                CalcularImportePago();
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al calcular el importe del pago\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void txtImporte_ValueChanged(object sender, EventArgs e)
        {
            try {
                CalcularImportePago();
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al calcular el importe del pago\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void cboSemana_SelectedIndexChanged(object sender, EventArgs e)
        {
            try {
                //CALCULO DE PAGOS
                decimal Semanas = oList.FindAll(item => item.Semana > int.Parse(cboSemana.Text)).Count;
                txtPagos.Maximum = Semanas;
                txtPagos.Value = Semanas;
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al seleccionar la semana\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void cboEmpleados_SelectedValueChanged(object sender, EventArgs e)
        {
            try {
                if (cboEmpleados.SelectedValue != null) 
                    txtImporte.Maximum = oEmpleados.Find(item => item.Id == int.Parse(cboEmpleados.SelectedValue.ToString())).Ahorro;
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al seleccionar el empleado\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }

        private void ObtenerParametros()
        {
            oNomina = new WCF_Nomina.Hersan_NominaClient();
            try {
                txtTasa.Text = oNomina.Nom_Parametros_Obtener().Interes.ToString();
            } catch (Exception ex) {
                throw ex;
            } finally { oNomina = null; }
        }
        private void LimpiarCampos()
        {
            try {
                txtId.Text = "0";
                txtImporte.Value = txtImporte.Minimum;
                txtPago.Text = "0";
                txtPagos.Value = txtPagos.Minimum;                
                cboEmpleados.SelectedIndex = 0;
                cboSemana.SelectedIndex = 0;
                dgGrid.DataSource = null;
            } catch (Exception ex) {
                throw ex;
            }
        }
        private void CargaSemanas()
        {
            oNomina = new WCF_Nomina.Hersan_NominaClient();
            List<SemanasBE> oAux = new List<SemanasBE>();
            try {
                oAux = oNomina.NOM_Semanas_Obtener(DateTime.Today.Year);
                oList = oAux.FindAll(item => item.Termina >= DateTime.Today && item.DatosUsuario.Estatus == true && item.Termina.Year == DateTime.Today.Year);

                cboSemana.ValueMember = "Id";
                cboSemana.DisplayMember = "Semana";
                cboSemana.DataSource = oList;
            } catch (Exception ex) {
                throw ex;
            } finally { oNomina = null; }
        }
        private void CargaEmpleados()
        {
            oCHUmano = new WCF_CHumano.Hersan_CHumanoClient();
            try {
                oEmpleados = oCHUmano.CHU_Empleados_Combo();
                cboEmpleados.ValueMember = "Id";
                cboEmpleados.DisplayMember = "Numero";
                cboEmpleados.DataSource = oEmpleados;
            } catch (Exception ex) {
                throw ex;
            } finally { oCHUmano = null; }
        }
        private bool ValidarCampos()
        {
            return true;
            //try {
            //    string msg = string.Empty;
            //    LimpiarErrores();

            //    if ((txtImporte.Text.Trim() == "") | (txtImporte.Text == "0")) {
            //        errorProvider1.SetError(txtImporte, "Ingrese el Importe del Préstamo");
            //        txtImporte.Focus();
            //        msg = "- Ingrese el Importe del Préstamo " + Environment.NewLine;
            //    }

            //    //if (txtPagos.Text == "0")
            //    //{
            //    //    errorProvider1.SetError(txtPagos, "Ingrese el Número de Pagos");
            //    //    txtPagos.Focus();
            //    //    msg = "- Ingrese el Número de Pagos " + Environment.NewLine;
            //    //}

            //    if (!msg.Equals(string.Empty)) {
            //        RadMessageBox.Show(msg, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            //        return false;
            //    }

            //    return true;
            //} catch (Exception ex) {
            //    throw ex;
            //}

        }
        private void GenerarTablaAmortizacion()
        {
            int i = 0;
            decimal Saldo = 0;

            oPrestamo = new List<PrestamosDetalleBE>();

            try {
                if (ValidarCampos()) {

                    NumPagos = int.Parse(txtPagos.Value.ToString());
                    Semana = oList.Find(item=> item.Id > int.Parse(cboSemana.SelectedValue.ToString())).Semana;
                    Importe = txtImporte.Value;
                    Tasa = decimal.Parse(txtTasa.Text.ToString());
                    ImpPago = decimal.Parse(txtPago.Text);
                    Saldo = Importe;

                    for (i = 1; i <= NumPagos; i++) {
                        PrestamosDetalleBE obj = new PrestamosDetalleBE();
                        obj.NoPago = i;
                        obj.Semana = CalcularSemana(Semana, i - 1);
                        obj.Fecha = oList.Find(item => item.Semana == obj.Semana).Inicia;
                        obj.Capital = Saldo;
                        obj.ImportePago = ImpPago;
                        obj.Interes= (Saldo * Tasa) / 100;
                        obj.Abono = ImpPago - obj.Interes;
                        Saldo = Saldo - obj.Abono;
                        obj.Saldo = Saldo;
                        obj.Estatus = "VIGENTE";

                        oPrestamo.Add(obj);
                    }

                    oPrestamo[NumPagos - 1].ImportePago = ImpPago + (oPrestamo[NumPagos - 2].Saldo - oPrestamo[NumPagos - 1].Abono);
                    oPrestamo[NumPagos - 1].Abono = (ImpPago - oPrestamo[NumPagos - 1].Interes) + (oPrestamo[NumPagos - 2].Saldo - oPrestamo[NumPagos - 1].Abono);
                    oPrestamo[NumPagos - 1].Saldo = 0;

                    dgGrid.DataSource = oPrestamo;
                }

            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrío un error al generar la tabla de amortizaciones\n"+ ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private int CalcularSemana(int Semana, int Incremento)
        {
            int Anio = 0;
            int SumAnio = 0;
            int Sem = 0;
            int Sobra = 0;
            int Resultado = Semana;

            if (Incremento > 0) {

                //Se incrementa la semana en el número correspondiente              
                Sem = int.Parse(Semana.ToString().Substring(4, 2));
                Sem = Sem + Incremento;

                //Se valida que sea menor o igual a 53 el numero de Semana
                if (Sem > 53) {
                    SumAnio = System.Math.DivRem(Sem, 53, out Sobra);

                    //Incrementar el año
                    Anio = int.Parse(Semana.ToString().Substring(0, 4)) + SumAnio;
                    //Incrementar la semana                    
                    Sem = Sem - (53 * SumAnio);

                    //En caso de que la semana sea igual a 0 reasignar anio y semana
                    if (Sem == 0) {
                        Anio = int.Parse(Semana.ToString().Substring(0, 4)) + SumAnio - 1;
                        Sem = 53;
                    }

                    Resultado = int.Parse(Anio.ToString() + Sem.ToString().PadLeft(2, '0'));
                } else {
                    Resultado = Semana + Incremento;
                }
            }

            return Resultado;
        }
        private void CalcularImportePago()
        {
            double tasa = 0;
            double dividendo = 0;
            int Potencia = 0;
            double divisor = 0;

            try {
                if ((txtImporte.Value !=0 ) && (txtPagos.Value != 0)) {
                    if (txtImporte.Value > 0 && txtPagos.Value > 0) {
                        tasa = double.Parse(txtTasa.Text.ToString()) / 100;
                        dividendo = double.Parse(txtImporte.Value.ToString()) * tasa;
                        Potencia = int.Parse(txtPagos.Value.ToString()) * -1;
                        divisor = 1 - (System.Math.Pow((1 + tasa), Potencia));

                        txtPago.Text = (dividendo / divisor).ToString("#,0.00");
                    }
                }
                if (txtImporte.Value == 0 || txtPagos.Value == 0) {
                    txtPago.Text = "0.00";
                } else if ((int.Parse(txtPagos.Value.ToString()) == 0) || txtImporte.Value == 0) {
                    txtPago.Text = "0.00";
                }

                dgGrid.DataSource = null;
            } catch (Exception ex) {
                throw ex;
            }

        }
        private void ImprimirPrestamo()
        {
            //frmViewer frm = new frmViewer();
            //try {
            //    if (dgGrid.RowCount > 0) {
            //        frm.iReport = new Reportes.rptPrestamos();
            //        //Preview.iReport.SetDataSource(oTable.ToDataTable(lstPrestamo));
            //        frm.iReport.SetDataSource(BaseWinBP.ToDataTable(oPrestamo));
            //        frm.ShowDialog();
            //    } else {
            //        RadMessageBox.Show("Debe generar la tabla de amortización para imprimir", this.Text, MessageBoxButtons.OK, RadMessageIcon.Exclamation);
            //    }
            //} catch (Exception ex) {
            //    RadMessageBox.Show("Ocurrió un error al imprimir el préstamo\n"+ ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            //}

        }
    }
}
