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
                txtMinEnt.Text = "0";
                txtHorEnt.Text = "0";
                txtMinSal.Text = "0";
                txtHorSal.Text = "0";
                txtHorSalCom.Text = "0";
                txtMinSalCom.Text = "0";
                txtHorEntcom.Text = "0";
                txtMinEntCom.Text = "0";
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
                Flag = txtHorEnt.Text.Trim().Length == 0 ? false : true;
                Flag = txtMinEnt.Text.Trim().Length == 0 ? false : true;
                Flag = txtHorSal.Text.Trim().Length == 0 ? false : true;
                Flag = txtMinEnt.Text.Trim().Length == 0 ? false : true;
                Flag = txtHorSalCom.Text.Trim().Length == 0 ? false : true;
                Flag = txtMinSalCom.Text.Trim().Length == 0 ? false : true;
                Flag = txtHorEntcom.Text.Trim().Length == 0 ? false : true;
                Flag = txtMinEntCom.Text.Trim().Length == 0 ? false : true;
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
                        obj.HoraEnt = int.Parse(txtHorEnt.Text);
                        obj.MinutoEnt = int.Parse(txtMinEnt.Text);
                        obj.HoraSalida = int.Parse(txtHorSal.Text);
                        obj.MinutoSalida = int.Parse(txtMinSal.Text);
                        obj.HorSalComida = int.Parse(txtHorSalCom.Text);
                        obj.MinSalComida = int.Parse(txtMinSalCom.Text);
                        obj.HorEntComida = int.Parse(txtHorEntcom.Text);
                        obj.MinEntComida = int.Parse(txtMinEntCom.Text);
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
                    txtHorEnt.Text = e.CurrentRow.Cells["HoraEnt"].Value.ToString();
                    txtMinEnt.Text = e.CurrentRow.Cells["MinutoEnt"].Value.ToString();
                    txtHorSal.Text = e.CurrentRow.Cells["HoraSalida"].Value.ToString();
                    txtMinSal.Text = e.CurrentRow.Cells["MinutoSalida"].Value.ToString();
                    txtHorSalCom.Text = e.CurrentRow.Cells["HorSalComida"].Value.ToString();
                    txtMinSalCom.Text = e.CurrentRow.Cells["MinSalComida"].Value.ToString();
                    txtHorEntcom.Text = e.CurrentRow.Cells["HorEntComida"].Value.ToString();
                    txtMinEntCom.Text = e.CurrentRow.Cells["MinEntComida"].Value.ToString();
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
                    obj.HoraEnt = int.Parse(txtHorEnt.Text);
                    obj.MinutoEnt = int.Parse(txtMinEnt.Text);
                    obj.HoraSalida = int.Parse(txtHorSal.Text);
                    obj.MinutoSalida = int.Parse(txtMinSal.Text);
                    obj.HorSalComida = int.Parse(txtHorSalCom.Text);
                    obj.MinSalComida = int.Parse(txtMinSalCom.Text);
                    obj.HorEntComida = int.Parse(txtHorEntcom.Text);
                    obj.MinEntComida = int.Parse(txtMinEntCom.Text);
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
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
