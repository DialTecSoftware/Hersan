using Hersan.Entidades.Relchec;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using ZKSoftwareAPI;
using Hersan.Entidades.CapitalHumano;
using Hersan.Entidades.Catalogos;

namespace Hersan.UI.Relchec
{
    public partial class FrmTrabajadorHorario : Telerik.WinControls.UI.RadForm
    {
        WCF_CHumano.Hersan_CHumanoClient oCHumano;
        List<TrabajadorHorarioBE> oList = new List<TrabajadorHorarioBE>();
        ZKSoftware dispositivo = new ZKSoftware(Modelo.X628C);
        List<HorariosBE> hList = new List<HorariosBE>();
        List<EmpleadosBE> EList = new List<EmpleadosBE>();

        public FrmTrabajadorHorario()
        {
            InitializeComponent();
        }

        private void LimpiarCampos()
        {
            try
            {
                cboEmpleados.SelectedIndex = -1;
                cboHorarios.SelectedIndex=-1;
                txtId.Text = "-1";

            }
            catch (Exception ex)
            {
                RadMessageBox.Show("Ocurrio un error al limpiar los campos\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }

        private void FrmTrabajadorHorario_Load(object sender, EventArgs e)
        {
            try
            {
               CargarDatos();
               CargaEMpleados();
               CargaHorarios();

            }
            catch (Exception)
            {

                throw;
            }

        }
        private bool ValidarCampos()
        {
            bool Flag = true;
            try
            {
                Flag = txtId.Text.Trim().Length == 0 ? false : true;
                Flag = cboHorarios.Text.Trim().Length == 0 ? false : true;
                Flag = cboEmpleados.Text.Trim().Length == 0 ? false : true;
                
             

                return Flag;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarDatos()
        {
            oCHumano = new WCF_CHumano.Hersan_CHumanoClient();
            try
            {
                oList = oCHumano.ABCTrabajadorHorarios_Obtener();

                gvDatos.DataSource = oList;
            }
            catch (Exception ex)
            {
                RadMessageBox.Show("Ocurrio un error al cargar los Datos\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
            finally
            {
                oCHumano = null;
            }
        }
               
        private void Conectar()       
         {
            if (!dispositivo.DispositivoConectar("192.168.1.220", 2, true)) 
            {
                RadMessageBox.Show(dispositivo.ERROR);
            }
            
         }
        private void Desconectar()
        {
            dispositivo.DispositivoDesconectar();
        }

        private void AgregarUsuario(int numeroCredencial, String Nombre, Permiso permiso, int IndexHuella, string b64Huella)
        {
            if (!dispositivo.UsuarioAgregar(numeroCredencial, Nombre, permiso, IndexHuella, b64Huella))
            {
                MessageBox.Show(dispositivo.ERROR);
            }
        }
        private void GuardaUsuario(object sender, EventArgs e)
        {
            Conectar();
            AgregarUsuario(123,"Gregory Moise",Permiso.UsuarioNormal, 0, "122");
             Desconectar();
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

        private void CargaEMpleados()
        {
            oCHumano = new WCF_CHumano.Hersan_CHumanoClient();
            try
            {
                EList = oCHumano.CHU_EMPLEADOS_COMBO();
                cboEmpleados.DisplayMember = "Expedientes.DatosPersonales.Nombres";
                cboEmpleados.ValueMember = "Numero";
                cboEmpleados.DataSource = EList;

                if (cboEmpleados != null)
                    cboEmpleados.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oCHumano = null;
            }
        }
        private void CargaHorarios()
        {
            oCHumano = new WCF_CHumano.Hersan_CHumanoClient();
            try
            {
                hList = oCHumano.ABC_HORARIOS_COMBO();
                cboHorarios.DisplayMember = "Nombre";
                cboHorarios.ValueMember = "Id";
                cboHorarios.DataSource = hList;

                if (cboHorarios != null)
                    cboHorarios.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oCHumano = null;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            oCHumano = new WCF_CHumano.Hersan_CHumanoClient();
            TrabajadorHorarioBE obj = new TrabajadorHorarioBE();
            try
            {
                if (chkstatus.Checked)
                {
                    if (RadMessageBox.Show("Esta acción dará de baja el Horario al Trabajador\nDesea continuar...?", this.Text, MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.Yes)
                    {
                        obj.Id = int.Parse(txtId.Text);
                        obj.Empleados.Numero = int.Parse(cboEmpleados.SelectedValue.ToString());
                        obj.Horarios.Id = int.Parse(cboHorarios.SelectedValue.ToString());
                        obj.DatosUsuario.Estatus = false;
                        //obj.DatosUsuario.IdUsuarioCreo = BaseWinBP.UsuarioLogueado.ID;
                        obj.DatosUsuario.IdUsuarioCreo = 1;


                        int Result = oCHumano.ABCTrabajadorHorario_Actualizar(obj);
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            oCHumano = new WCF_CHumano.Hersan_CHumanoClient();
            TrabajadorHorarioBE obj = new TrabajadorHorarioBE();
            try
            {
           
                if (RadMessageBox.Show("Desea guardar los datos capturados...?", this.Text, MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.Yes)
                {
                    obj.Id = int.Parse(txtId.Text);
                    obj.Empleados.Numero = int.Parse(cboEmpleados.SelectedValue.ToString()); 
                    obj.Horarios.Id = int.Parse(cboHorarios.SelectedValue.ToString());
                    obj.DatosUsuario.Estatus = chkstatus.Checked;
                    //obj.DatosUsuario.IdUsuarioCreo = BaseWinBP.UsuarioLogueado.ID;
                    obj.DatosUsuario.IdUsuarioCreo = 1;

                    //PROCESO DE GUARDADO Y ACTUALIZACION
                    if (txtId.Text == "-1")
                    {
                        int Result = oCHumano.ABCTrabajadorHorario_Guarda(obj);
                        if (Result == 0)
                        {
                            RadMessageBox.Show("Ocurrió un error al Asignarle Horario al Trabajador", this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
                        }
                        else
                        {
                            RadMessageBox.Show("Horario Asignado correctamente", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                            LimpiarCampos();
                            CargarDatos();
                            GuardaUsuario();

                        }
                    }
                    else
                    {
                        int Result = oCHumano.ABCTrabajadorHorario_Actualizar(obj);
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
        private void gvDatos_CurrentRowChanged(object sender, Telerik.WinControls.UI.CurrentRowChangedEventArgs e)
        {
            try
            {
                if (gvDatos.RowCount > 0)
                {

                    txtId.Text = e.CurrentRow.Cells["Id"].Value.ToString();
                    cboEmpleados.SelectedValue = int.Parse(e.CurrentRow.Cells["Numero"].Value.ToString());
                    cboHorarios.SelectedValue = int.Parse(e.CurrentRow.Cells["IdHorarios"].Value.ToString());
                    chkstatus.Checked = bool.Parse(e.CurrentRow.Cells["Estatus"].Value.ToString());
                }
            }
            catch (Exception ex)
            {
                RadMessageBox.Show("Ocurrio un error al seleccionar el registro\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }

    }


}
