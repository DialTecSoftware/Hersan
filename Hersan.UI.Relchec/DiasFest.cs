using Hersan.Entidades.Relchec;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.Data;
using Hersan.Negocio;

namespace Hersan.UI.Relchec
{
    public partial class DiasFest : Form
    {

        WCF_CHumano.Hersan_CHumanoClient oCHumano;
        List<DiasFestBE> oList = new List<DiasFestBE>();
        public DiasFest()
        {
            InitializeComponent();
        }
        private void LimpiarCampos()
        {
            try
            {
                txtNombre.Text = string.Empty;
                radDateTimePicker1.Value = DateTime.Today;
                txtId.Text = "-1";

            }
            catch (Exception ex)
            {
                RadMessageBox.Show("Ocurrio un error al limpiar los campos\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void CargarDatos()
        {
            oCHumano = new WCF_CHumano.Hersan_CHumanoClient();
            try
            {
                oList = oCHumano.ABCDiasFest_Obtener();

                gvDatos.DataSource = oList;
                txtId.Text = "0";
            }
            catch (Exception ex)
            {
                RadMessageBox.Show("Ocurrio un error al cargar los Dias Festivos\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
            finally
            {
                oCHumano = null;
            }
        }
        private bool ValidarCampos()
        {
            bool Flag = true;
            try
            {
                Flag = txtNombre.Text.Trim().Length == 0 ? false : true;
                Flag = txtId.Text.Trim().Length == 0 ? false : true;
                Flag = radDateTimePicker1.Text.Trim().Length == 0 ? false : true;

                return Flag;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void gvDatos_CurrentRowChanged(object sender, Telerik.WinControls.UI.CurrentRowChangedEventArgs e)
        {
            try
            {
                if (gvDatos.RowCount > 0 && e.CurrentRow.ChildRows.Count == 0)
                {

                    txtId.Text = e.CurrentRow.Cells["Id"].Value.ToString();
                    txtNombre.Text = e.CurrentRow.Cells["Nombre"].Value.ToString();
                    radDateTimePicker1.Value = Convert.ToDateTime(e.CurrentRow.Cells["dia"].Value.ToString());
                    chkstatus.Checked = bool.Parse(e.CurrentRow.Cells["Estatus"].Value.ToString());
                }
            }
            catch (Exception ex)
            {
                RadMessageBox.Show("Ocurrio un error al seleccionar el registro\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }

        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                RadMessageBox.Show("Ocurrio un error al cerrar la pantalla\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }

        
        private void DiasFest_Load(object sender, EventArgs e)
        {
            try
            {
                CargarDatos();
                radDateTimePicker1.Value = DateTime.Today;
              
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                RadMessageBox.Show("Ocurrio un error al cerrar la pantalla\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            oCHumano = new WCF_CHumano.Hersan_CHumanoClient();
            DiasFestBE obj = new DiasFestBE();
            try
            {
                if (chkstatus.Checked)
                {
                    if (RadMessageBox.Show("Esta acción dará de baja el Dias Festivo\nDesea continuar...?", this.Text, MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.Yes)
                    {
                        obj.Id = int.Parse(txtId.Text);
                        obj.Nombre = txtNombre.Text;
                        obj.dia = radDateTimePicker1.Value;
                        obj.DatosUsuario.Estatus = false;
                        //obj.DatosUsuario.IdUsuarioCreo = BaseWinBP.UsuarioLogueado.ID;
                        obj.DatosUsuario.IdUsuarioCreo = 1;


                        int Result = oCHumano.ABCDiasFest_Actualizar(obj);
                        if (Result == 0)
                        {
                            RadMessageBox.Show("Ocurrió un error al modificar los datos", this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
                        }
                        else
                        {
                            RadMessageBox.Show("Información actualizada correctamente", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                            LimpiarCampos();
                            CargarDatos();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                RadMessageBox.Show("Ocurrio un error al dar de baja el Dia Festivo\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
            finally
            {
                oCHumano = null;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            oCHumano = new WCF_CHumano.Hersan_CHumanoClient();
            DiasFestBE obj = new DiasFestBE();
            try
            {
                if (!ValidarCampos())
                {
                    RadMessageBox.Show("Debe capturar todos los datos para continuar", this.Text, MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                    return;
                }
                if (oList.FindAll(item => item.Nombre.Trim() == txtNombre.Text.Trim()).Count > 0 && int.Parse(txtId.Text) == 0)

                {
                    RadMessageBox.Show("El Dia Festivo capturado ya existe, no es posible guardar", this.Text, MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                    LimpiarCampos();
                    return;
                }

                if (RadMessageBox.Show("Desea guardar los datos capturados...?", this.Text, MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.Yes)
                {
                    char pad = '0';

                    obj.Id = int.Parse(txtId.Text);
                    obj.Nombre = txtNombre.Text;
                    //  obj.dia = radDateTimePicker1.Value.Year+"-" + radDateTimePicker1.Value.Month.ToString().PadLeft(2, pad) + "-" + radDateTimePicker1.Value.Day.ToString().PadLeft(2, pad);
                    obj.dia = radDateTimePicker1.Value;
                    obj.DatosUsuario.Estatus = chkstatus.Checked;
                    //obj.DatosUsuario.IdUsuarioCreo = BaseWinBP.UsuarioLogueado.ID;
                    obj.DatosUsuario.IdUsuarioCreo = 1;

                    //PROCESO DE GUARDADO Y ACTUALIZACION
                    if (txtId.Text == "-1")
                    {
                        int Result = oCHumano.ABCDiasFest_Guarda(obj);
                        if (Result == 0)
                        {
                            RadMessageBox.Show("Ocurrió un error al guardar el Horario", this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
                        }
                        else
                        {
                            RadMessageBox.Show("Dia Festivo guardado correctamente", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                            LimpiarCampos();
                            CargarDatos();
                        }
                    }
                    else
                    {
                        int Result = oCHumano.ABCDiasFest_Actualizar(obj);
                        if (Result == 0)
                        {
                            RadMessageBox.Show("Ocurrió un error al actualizar los datos", this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
                        }
                        else
                        {
                            RadMessageBox.Show("Información actualizada correctamente", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                            LimpiarCampos();
                            CargarDatos();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                RadMessageBox.Show("Ocurrió un error al actualizar la información\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
            finally
            {
                oCHumano = null;
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    LimpiarCampos();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

   
    }
}
