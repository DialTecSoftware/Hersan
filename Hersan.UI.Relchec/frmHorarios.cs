using Hersan.Entidades.Catalogos;
using Hersan.Entidades.Relchec;
using Hersan.Entidades.CapitalHumano;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.Data;
using Hersan.Negocio;

namespace Hersan.UI.Relchec
{
    public partial class frmHorarios : Telerik.WinControls.UI.RadForm
    {
        WCF_CHumano.Hersan_CHumanoClient oCHumano;
        List<HorariosBE> oList = new List<HorariosBE>();
      

        public frmHorarios()
        {
            InitializeComponent();
        }


        private void LimpiarCampos()
        {
            try
            {
               txtNombre.Text = string.Empty;
                radHoraEnt.Value = DateTime.Now;
                radHoraSal.Value = DateTime.Now;
                radHorEntComida.Value = DateTime.Now;
                radHorSalComida.Value = DateTime.Now;
                txttolerancia.Text = "0";
                chkstatus.Checked = false;
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
                oList = oCHumano.ABCHorarios_Obtener();

                gvDatos.DataSource = oList;
            }
            catch (Exception ex)
            {
                RadMessageBox.Show("Ocurrio un error al cargar los Horarios\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
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
                Flag = radHoraEnt.Text.Trim().Length == 0 ? false : true;
                Flag = radHoraSal.Text.Trim().Length == 0 ? false : true;
                Flag = radHorEntComida.Text.Trim().Length == 0 ? false : true;
                Flag = radHorSalComida.Text.Trim().Length == 0 ? false : true;
                Flag = txttolerancia.Text.Trim().Length == 0 ? false : true;

                return Flag;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            oCHumano = new WCF_CHumano.Hersan_CHumanoClient();
            HorariosBE obj = new HorariosBE();
            try
            {
                if (chkstatus.Checked)
                {
                    if (RadMessageBox.Show("Esta acción dará de baja el Horario\nDesea continuar...?", this.Text, MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.Yes)
                    {
                        obj.Id = int.Parse(txtId.Text);
                        obj.Nombre = txtNombre.Text;
                        obj.HoraEnt = radHoraEnt.Value.Value.TimeOfDay.ToString();
                        obj.HoraSalida = radHoraSal.Value.Value.TimeOfDay.ToString();
                        obj.HorSalComida = radHorSalComida.Value.Value.TimeOfDay.ToString();
                        obj.HorEntComida = radHorEntComida.Value.Value.TimeOfDay.ToString();
                        obj.Tolerancia = int.Parse(txttolerancia.Text);
                        obj.DatosUsuario.Estatus = false;
                        //obj.DatosUsuario.IdUsuarioCreo = BaseWinBP.UsuarioLogueado.ID;
                        obj.DatosUsuario.IdUsuarioCreo = 1;


                        int Result = oCHumano.ABCHorarios_Actualizar(obj);
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
                RadMessageBox.Show("Ocurrio un error al dar de baja el Horario\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
            finally
            {
                oCHumano = null;
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
                    radHoraEnt.Value = Convert.ToDateTime(e.CurrentRow.Cells["HoraEnt"].Value.ToString());
                    radHoraSal.Value = Convert.ToDateTime(e.CurrentRow.Cells["HoraSalida"].Value.ToString());
                    radHorEntComida.Value = Convert.ToDateTime(e.CurrentRow.Cells["HorSalComida"].Value.ToString());
                    radHorSalComida.Value = Convert.ToDateTime(e.CurrentRow.Cells["HorEntComida"].Value.ToString());
                    txttolerancia.Text = e.CurrentRow.Cells["Tolerancia"].Value.ToString();
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

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            oCHumano = new WCF_CHumano.Hersan_CHumanoClient();
            HorariosBE obj = new HorariosBE();
            try
            {
                if (!ValidarCampos())
                {
                    RadMessageBox.Show("Debe capturar todos los datos para continuar", this.Text, MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                    return;
                }
                if (oList.FindAll(item => item.Nombre.Trim() == txtNombre.Text.Trim()).Count > 0 && int.Parse(txtId.Text) == 0)

                {
                    RadMessageBox.Show("El Horario capturado ya existe, no es posible guardar", this.Text, MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                    LimpiarCampos();
                    return;
                }

                if (RadMessageBox.Show("Desea guardar los datos capturados...?", this.Text, MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.Yes)
                {
                    obj.Id = int.Parse(txtId.Text);
                    obj.Nombre = txtNombre.Text;
                    obj.HoraEnt = radHoraEnt.Value.Value.TimeOfDay.ToString();
                    obj.HoraSalida = radHoraSal.Value.Value.TimeOfDay.ToString();
                    obj.HorSalComida = radHorSalComida.Value.Value.TimeOfDay.ToString();
                    obj.HorEntComida = radHorEntComida.Value.Value.TimeOfDay.ToString();
                    obj.Tolerancia = int.Parse(txttolerancia.Text);
                    obj.DatosUsuario.Estatus = chkstatus.Checked;
                    //obj.DatosUsuario.IdUsuarioCreo = BaseWinBP.UsuarioLogueado.ID;
                    obj.DatosUsuario.IdUsuarioCreo = 1;

                    //PROCESO DE GUARDADO Y ACTUALIZACION
                    if (txtId.Text == "-1")
                    {
                        int Result = oCHumano.ABCHorarios_Guarda(obj);
                        if (Result == 0)
                        {
                            RadMessageBox.Show("Ocurrió un error al guardar el Horario", this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
                        }
                        else
                        {
                            RadMessageBox.Show("Horario guardado correctamente", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                            LimpiarCampos();
                            CargarDatos();
                        }
                    }
                    else
                    {
                        int Result = oCHumano.ABCHorarios_Actualizar(obj);
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
            try
            {
                LimpiarCampos();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void frmHorarios_Load(object sender, EventArgs e)
        {
            try
            {
                CargarDatos();
                radHoraEnt.Value = DateTime.Now;
                radHoraSal.Value = DateTime.Now;
                radHorEntComida.Value = DateTime.Now;
                radHorSalComida.Value = DateTime.Now;
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
