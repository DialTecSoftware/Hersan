using Hersan.Entidades.Catalogos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace Hersan.UI.Catalogos
{
    public partial class frmDepartamentos : Telerik.WinControls.UI.RadForm
    {
        WCF_Catalogos.Hersan_CatalogosClient oCatalogos = new WCF_Catalogos.Hersan_CatalogosClient();

        public frmDepartamentos()
        {
            InitializeComponent();
        }
        private void frmDepartamentos_Load(object sender, EventArgs e)
        {
            try {
                CargarDatos();
            } catch (Exception ex) {

                throw ex;
            }
        }
        private void gvDatos_Click(object sender, EventArgs e)
        {

        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {

        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //DepartamentosBE obj = new DepartamentosBE();
            //try {
            //    obj.Nombre = txtNombre.Text;
            //    obj.Abrev = txtAbrev.Text;

            //    int Result = oCatalogos.ABCDepartamentos_Guardar(obj);
            //    if(Result == 0) {
            //        RadMessageBox.Show();
            //    }else
            //        RadMessageBox.Show();
            //} catch (Exception ex) {
            //    throw ex;
            //}
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            try {
                this.Close();
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrio un error al cerrar la pantalla\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }

        private void CargarDatos()
        {
            try {
                gvDatos.DataSource = oCatalogos.ABCDepartamentos_Obtener();
            } catch (Exception ex) {
                throw ex;
            }
        }

        private void radPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
