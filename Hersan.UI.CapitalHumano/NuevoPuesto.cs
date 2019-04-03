﻿using Hersan.Entidades.CapitalHumano;
using Hersan.Entidades.Catalogos;
using Hersan.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace Hersan.UI.CapitalHumano
{
    public partial class frmNuevoPuesto : Telerik.WinControls.UI.RadForm
    {
        CapitalHumano.WCF_Catalogos.Hersan_CatalogosClient oCatalogo;
        CapitalHumano.WCF_CHumano.Hersan_CHumanoClient oCHumano;
        List<NuevoPuestoBE> oList = new List<NuevoPuestoBE>();
        List<EntidadesBE> oEntidades = new List<EntidadesBE>();
        BaseWinBP lista = new BaseWinBP();

        public frmNuevoPuesto()
        {
            InitializeComponent();
        }
        
        private void LimpiarCampos()
        {
            oList.Clear();
            txtId.Text = "-1";
            txtNombre.Text = "";
            cboNivel.SelectedIndex = 0;
            txtJustif.Text = "";
            txtSueldo.Text = "0";
            cboEntidad.SelectedIndex = 0;
            cboDepto.SelectedIndex = 0;
            txtIndicadores.Text = "";
            txtJustif.Text = "";
            txtNecesidades.Text = "";
            txtObjetivos.Text = "";
            txtPrestaciones.Text = "";
            txtPuestos.Text = "";
            txtResultados.Text = "";
            txtSueldo.Text = "0";
        }
        private void CargarEntidades()
        {
            oCatalogo = new CapitalHumano.WCF_Catalogos.Hersan_CatalogosClient();
            try {
                oEntidades = oCatalogo.Entidades_Combo(BaseWinBP.UsuarioLogueado.Empresa.Id);
                oEntidades.Add(new EntidadesBE { Id = 0, Nombre = "TODAS" });
                cboEntidad.ValueMember = "Id";
                cboEntidad.DisplayMember = "Nombre";
                cboEntidad.DataSource = oEntidades;

            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al cargar las entidades\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally {
                oCatalogo = null;
            }
        }
        private void CargarDeptos()
        {
            oCatalogo = new CapitalHumano.WCF_Catalogos.Hersan_CatalogosClient();
            try {
                cboDepto.ValueMember = "Id";
                cboDepto.DisplayMember = "Nombre";
                if (cboEntidad.Items.Count > 0 && cboEntidad.SelectedValue != null) {
                    cboDepto.DataSource = oCatalogo.ABCDepartamentos_Combo(int.Parse(cboEntidad.SelectedValue.ToString()));
                } else {
                    cboDepto.DataSource = null;
                }
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al cargar los departamentos\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally {
                oCatalogo = null;
            }
        }

        private void CargarNuevosPuestos()
        {
            oCHumano = new CapitalHumano.WCF_CHumano.Hersan_CHumanoClient();
            try {
                oList = oCHumano.CHU_NuevoPuesto_Obtener(BaseWinBP.UsuarioLogueado.ID);
                gvDatos.DataSource = oList;
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrio un error al cargar los puestos\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally { oCHumano = null; }
        }

        private void frmNuevoPuesto_Load(object sender, EventArgs e)
        {
            try {
                CargarDeptos();
                CargarEntidades();
                CargarNuevosPuestos();

            } catch (Exception) {

                throw;
            }
        }

        private bool ValidarCampos()
        {
            bool Flag = true;
            try {
                Flag = txtJustif.Text.Trim().Length == 0 ? false : true;
                Flag = txtIndicadores.Text.Trim().Length == 0 ? false : true;
                Flag = txtSueldo.Text.Trim().Length == 0 ? false : true;
                Flag = txtNecesidades.Text.Trim().Length == 0 ? false : true;
                Flag = txtObjetivos.Text.Trim().Length == 0 ? false : true;
                Flag = txtPrestaciones.Text.Trim().Length == 0 ? false : true;
                Flag = txtPuestos.Text.Trim().Length == 0 ? false : true;
                Flag = txtResultados.Text.Trim().Length == 0 ? false : true;


                return Flag;
            } catch (Exception ex) {
                throw ex;
            }
        }

        private void cboEntidad_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try {
                CargarDeptos();
            } catch (Exception ex) {
                throw ex;
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
            oCatalogo = new CapitalHumano.WCF_Catalogos.Hersan_CatalogosClient();
            oCHumano = new CapitalHumano.WCF_CHumano.Hersan_CHumanoClient();
            NuevoPuestoBE obj = new NuevoPuestoBE();
            try {
                if (!ValidarCampos()) {
                    RadMessageBox.Show("Debe capturar todos los datos para continuar", this.Text, MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                    return;
                }

                if (oList.FindAll(item => item.Departamentos.Entidades.Id == int.Parse(cboEntidad.SelectedValue.ToString()) && item.Departamentos.Id == int.Parse(cboDepto.SelectedValue.ToString())).Count > 0
                   && int.Parse(txtId.Text) == -1) {
                    RadMessageBox.Show("El departamento capturado ya existe, no es posible guardar", this.Text, MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                    LimpiarCampos();
                    return;
                }
                #region Entidades
                obj.Id = int.Parse(txtId.Text);
                obj.Entidades.Id = int.Parse(cboEntidad.SelectedValue.ToString());
                obj.Departamentos.Id = int.Parse(cboDepto.SelectedValue.ToString());
                obj.Nombre = txtNombre.Text;
                obj.Objetivos = txtObjetivos.Text;
                obj.PuestosCargo = txtPuestos.Text;
                obj.Prestaciones = txtPrestaciones.Text;
                obj.Necesidades = txtNecesidades.Text;
                obj.Ocupantes = int.Parse(cboNivel.SelectedItem.ToString());
                obj.Resultados = txtResultados.Text;
                obj.Sueldo = decimal.Parse(txtSueldo.Text);
                obj.Justificacion = txtJustif.Text;
                obj.Indicadores = txtIndicadores.Text;
                obj.DatosUsuario.IdUsuarioCreo = BaseWinBP.UsuarioLogueado.ID;
                #endregion

                #region Correo
                string pwd = "Catcooptest";
                string smtp = "smtp.GMAIL.com";
                string emisor = "Key.Solutions.Test@gmail.com";
                string destinatario = "gregory.moise@dialtec.com.mx";
               string CuerpoMsg = "¡¡Favor de revisar el sistema para consultar la nueva solicitud y hacer las continuaciones necesarias!!";

                int port = 587;

                #endregion


                if (txtId.Text == "-1") {
                    int Result = oCHumano.CHU_NuevoPuesto_Guardar(obj);
                    if (Result == 0) {
                        RadMessageBox.Show("Ocurrió un error al enviar la solicitud de empleo", this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
                    } else {
                        RadMessageBox.Show("Solicitud enviada correctamente", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                        LimpiarCampos();
                        CargarNuevosPuestos();
                        string asunto = "Nueva Propuesta de Apertura de Puesto(" + DateTime.Now.ToString("dd / MMM / yyy hh: mm:ss") + ") ";
                        BaseWinBP.EnviarMail(emisor, destinatario, asunto, CuerpoMsg, smtp, pwd, port);
                    }
                } else {
                    oCHumano = new CapitalHumano.WCF_CHumano.Hersan_CHumanoClient();
                    int Result = oCHumano.CHU_NuevoPuesto_Actualizar(obj);
                    if (Result == 0) {
                        RadMessageBox.Show("Ocurrió un error al actualizar los datos", this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
                    } else {
                        RadMessageBox.Show("Información actualizada correctamente", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                        LimpiarCampos();
                        CargarNuevosPuestos();
                        string asunto = "Actualizacion  Propuesta de Apertura de Puesto(" + DateTime.Now.ToString("dd / MMM / yyy hh: mm:ss") + ") ";
                        BaseWinBP.EnviarMail(emisor, destinatario, asunto, CuerpoMsg, smtp, pwd, port);
                    }
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
                RadMessageBox.Show("Ocurrió un error al cerrar la pantalla\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }

        private void gvDatos_CurrentRowChanged(object sender, Telerik.WinControls.UI.CurrentRowChangedEventArgs e)
        {
            try {

                if (gvDatos.RowCount > 0 && e.CurrentRow.ChildRows.Count == 0) {
                    txtId.Text = e.CurrentRow.Cells["Id"].Value.ToString();
                    txtJustif.Text = e.CurrentRow.Cells["Justificacion"].Value.ToString();
                    txtNombre.Text = e.CurrentRow.Cells["Nombre"].Value.ToString();
                    txtIndicadores.Text = e.CurrentRow.Cells["Indicadores"].Value.ToString();
                    txtSueldo.Text = (e.CurrentRow.Cells["Sueldo"].Value.ToString());
                    cboDepto.SelectedValue = int.Parse(e.CurrentRow.Cells["DEP_Id"].Value.ToString());
                    cboEntidad.SelectedValue = int.Parse(e.CurrentRow.Cells["ENT_Id"].Value.ToString());
                    cboNivel.SelectedValue = (e.CurrentRow.Cells["Ocupantes"].Value.ToString());
                   txtResultados.Text= (e.CurrentRow.Cells["Resultados"].Value.ToString());
                    txtObjetivos.Text = (e.CurrentRow.Cells["Objetivos"].Value.ToString());
                    txtPrestaciones.Text = e.CurrentRow.Cells["Prestaciones"].Value.ToString();
                    txtNecesidades.Text = (e.CurrentRow.Cells["Necesidades"].Value.ToString());
                    txtPuestos.Text = (e.CurrentRow.Cells["PuestosCargo"].Value.ToString());
                }
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrio un error al seleccionar el registro\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            oCHumano = new CapitalHumano.WCF_CHumano.Hersan_CHumanoClient();
            NuevoPuestoBE obj = new NuevoPuestoBE();
            try {
                //if (chkEstatus.Checked) {
                if (RadMessageBox.Show("Esta acción dará de baja la proposición de un nuevo puesto\nDesea continuar...?", this.Text, MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.Yes) {
                    obj.Id = int.Parse(txtId.Text);
                    obj.Entidades.Id = int.Parse(cboEntidad.SelectedValue.ToString());
                    obj.Departamentos.Id = int.Parse(cboDepto.SelectedValue.ToString());
                    obj.Nombre = txtNombre.Text;
                    obj.Objetivos = txtObjetivos.Text;
                    obj.PuestosCargo = txtPuestos.Text;
                    obj.Prestaciones = txtPrestaciones.Text;
                    obj.Necesidades = txtNecesidades.Text;
                    obj.Ocupantes = cboNivel.SelectedIndex;
                    obj.Resultados = txtResultados.Text;
                    obj.Sueldo = decimal.Parse(txtSueldo.Text);
                    obj.Justificacion = txtJustif.Text;
                    obj.Indicadores = txtIndicadores.Text;
                    obj.DatosUsuario.IdUsuarioCreo = BaseWinBP.UsuarioLogueado.ID;
                    obj.DatosUsuario.Estatus=false;

                    int Result = oCHumano.CHU_NuevoPuesto_Actualizar(obj);
                    if (Result == 0) {
                        RadMessageBox.Show("Ocurrió un error al modificar los datos", this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
                    } else {
                        RadMessageBox.Show("Información actualizada correctamente", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                        LimpiarCampos();
                        CargarNuevosPuestos();

                    }
                }
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrio un error al dar de baja la proposición\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally {
                oCHumano = null;
            }
        }
    }
}