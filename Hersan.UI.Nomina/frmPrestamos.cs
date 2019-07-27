﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace Hersan.UI.Nomina
{
    public partial class frmPrestamos : Telerik.WinControls.UI.RadForm
    {
        public frmPrestamos()
        {
            InitializeComponent();
        }
        private void frmPrestamos_Load(object sender, EventArgs e)
        {

        }


        private bool ValidarCampos()
        {
            return false;
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
            //int i = 0;
            //decimal Saldo = 0;

            //lstDet = new List<PrestamoDetBE>();

            //try {
            //    if (ValidarCampos()) {

            //        NumPagos = int.Parse(txtPagos.Text);
            //        Semana = int.Parse(mcbSemana.Text.ToString());
            //        Importe = decimal.Parse(txtImporte.Text);
            //        Tasa = decimal.Parse(mcbTasa.Text.ToString());
            //        ImpPago = decimal.Parse(txtImpPago.Text);
            //        Saldo = Importe;

            //        for (i = 1; i <= NumPagos; i++) {
            //            PrestamoDetBE obj = new PrestamoDetBE();
            //            obj.NumPago = i;
            //            obj.Semana = CalcularSemana(Semana, i - 1);
            //            obj.Capital = Saldo;
            //            obj.ImportePago = ImpPago;
            //            obj.ImporteInteres = (Saldo * Tasa) / 100;
            //            obj.Abono = ImpPago - obj.ImporteInteres;
            //            Saldo = Saldo - obj.Abono;
            //            obj.Saldo = Saldo;
            //            obj.Estatus = "VIGENTE";
            //            lstDet.Add(obj);
            //        }

            //        lstDet[NumPagos - 1].ImportePago = ImpPago + (lstDet[NumPagos - 2].Saldo - lstDet[NumPagos - 1].Abono);
            //        lstDet[NumPagos - 1].Abono = (ImpPago - lstDet[NumPagos - 1].ImporteInteres) + (lstDet[NumPagos - 2].Saldo - lstDet[NumPagos - 1].Abono);
            //        lstDet[NumPagos - 1].Saldo = 0;

            //        dgGrid.DataSource = lstDet;
            //    }

            //} catch (Exception ex) {
            //    //throw ex;
            //    RadMessageBox.Show(ex.Message, this.Text + "Generar Tabla Amortización", MessageBoxButtons.OK, RadMessageIcon.Error);
            //}
        }
        private void GuardarInformacion()
        {

            //frmEspera fe = new frmEspera(this);
            //int Maquila = 0;
            //int Folio = 0;
            //PrestamoBE obj = new PrestamoBE();

            //try {
            //    if (ValidarCampos()) {

            //        if (dgGrid.RowCount == 0) {
            //            //GenerarTablaAmortizacion();                  
            //            btnGenerar_Click(new object(), new EventArgs());
            //        }

            //        Maquila = int.Parse(mcbMaquila.SelectedValue.ToString());

            //        obj.Maquila = new Entidades.Catalogos.MaquiladorBE();
            //        obj.Maquila.ID = Maquila;
            //        obj.Tasa = new TasaBE();
            //        obj.Tasa.IDTasa = (mcbTasa.Enabled == true ? int.Parse(mcbTasa.SelectedValue.ToString()) : 0);
            //        obj.ImporteTotal = decimal.Parse(txtImporte.Text);
            //        obj.NumPagos = (txtPagos.Enabled == true ? int.Parse(txtPagos.Text) : 0);
            //        obj.ImportePago = (txtImpPago.Enabled == true ? decimal.Parse(txtImpPago.Text) : 0);
            //        obj.SemanaAplica = int.Parse(mcbSemana.Text);
            //        obj.Concepto = "";
            //        obj.Estatus = "VIGENTE";
            //        obj.Tipo = int.Parse(cboTipo.SelectedValue.ToString());
            //        obj.Fecha = DateTime.Now; //No se usa en este tipo de prestamo pero si en hormas.
            //        fe.Start();
            //        Folio = oService.GuardarPrestamoMaquila(obj, lstDet, IdUsuario);
            //        if (Folio > 0) {
            //            RadMessageBox.Show("El Préstamo se Guardó con Éxito con el Número de Folio " + Folio.ToString() + ". ", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
            //            LimpiarCampos();
            //            LLenarComboSemanas();
            //        }
            //        fe.Stop();

            //    }
            //} catch (Exception ex) {
            //    RadMessageBox.Show(ex.Message, this.Text + " - Guardar Información", MessageBoxButtons.OK, RadMessageIcon.Error);
            //} finally { fe.Dispose(); }

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

            //double tasa = 0;
            //double dividendo = 0;
            //int Potencia = 0;
            //double divisor = 0;

            ////Tipo de Préstamo Normal
            //if (txtImporte.Enabled && txtPagos.Enabled && txtImpPago.Enabled && mcbTasa.Enabled) {
            //    if ((txtImporte.Text.Trim() != string.Empty) & (txtPagos.Text.Trim() != string.Empty)) {
            //        if ((double.Parse(txtImporte.Text) > 0) & (int.Parse(txtPagos.Text) > 0)) {
            //            tasa = double.Parse(mcbTasa.Text.ToString()) / 100;
            //            dividendo = double.Parse(txtImporte.Text) * tasa;
            //            Potencia = int.Parse(txtPagos.Text.ToString()) * -1;
            //            divisor = 1 - (System.Math.Pow((1 + tasa), Potencia));

            //            txtImpPago.Text = (dividendo / divisor).ToString("#,0.00");
            //        }
            //    }
            //} else
            //    //Tipo de Préstamo tasa Cero
            //    if (txtImporte.Enabled && txtPagos.Enabled && txtImpPago.Enabled && !mcbTasa.Enabled) {
            //    dividendo = (txtImporte.Text.Trim().Length == 0 ? 0 : double.Parse(txtImporte.Text)) / int.Parse(txtPagos.Text.ToString());
            //    txtImpPago.Text = dividendo.ToString("#,0.00");
            //} else {
            //    //Tipo de Préstamo Sin Pago
            //    txtImpPago.Text = "0.00";
            //    txtPagos.Text = "0";
            //}

            //if (txtImporte.Text.Trim() == string.Empty) {
            //    txtImpPago.Text = "0.00";
            //} else if ((int.Parse(txtPagos.Text.ToString()) == 0) | (double.Parse(txtImporte.Text.Trim()) == 0)) {
            //    txtImpPago.Text = "0.00";
            //}

            //dgGrid.DataSource = null;
        }
        private void ImprimirPrestamo()
        {
            //List<PrestamoSelBE> lstPrestamo;
            //SIS4E.Negocio.ListToDataTable oTable = new ListToDataTable(); ;
            //frmReportViewer Preview = new frmReportViewer();

            //frmEspera fEspera = new frmEspera(this);

            //try {
            //    if (dgGrid.RowCount > 0) {
            //        fEspera.Start();
            //        lstPrestamo = oService.ObtenerPrestamoTablaAmortizacion(mcbMaquila.Text, Importe, NumPagos, ImpPago, Semana, Tasa);
            //        Preview.iReport = new Reportes.rptPRE_PrestamoMaquila();
            //        //Preview.iReport.SetDataSource(oTable.ToDataTable(lstPrestamo));
            //        Preview.iReport.SetDataSource(oService.ObtenerPrestamoTablaAmortizacionDT(mcbMaquila.Text, Importe, NumPagos, ImpPago, Semana, Tasa));
            //        fEspera.Stop();
            //        Preview.ShowDialog();
            //    } else {

            //    }
            //} catch (Exception ex) {
            //    RadMessageBox.Show(ex.Message, this.Text + " - Imprimir Préstamo", MessageBoxButtons.OK, RadMessageIcon.Error);
            //}

        }
        private void GenerarTabla(int Tipo)
        {
            //try {
            //    PrestamoDetBE obj = new PrestamoDetBE();
            //    obj.Semana = int.Parse(mcbSemana.Text.ToString());
            //    obj.Capital = decimal.Parse(txtImporte.Text.Trim().Length == 0 ? "0" : txtImporte.Text.Trim());
            //    obj.NumPago = int.Parse(txtPagos.Text);
            //    obj.ImportePago = decimal.Parse(txtImpPago.Text);

            //    lstDet = oService.ObtenerTablaAmortizacion(Tipo, decimal.Parse(mcbTasa.Text.ToString()), obj);
            //    dgGrid.DataSource = lstDet;

            //    if (dgGrid.RowCount == 0)
            //        RadMessageBox.Show("No se ha generado la tabla, revise los valores", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
            //} catch (Exception ex) {
            //    RadMessageBox.Show("Ocurrió un error al generar la tabla" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
            //}
        }

       
    }
}