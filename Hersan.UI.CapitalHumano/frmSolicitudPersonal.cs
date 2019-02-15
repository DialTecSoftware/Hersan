using Hersan.Entidades.CapitalHumano;
using Hersan.Entidades.Catalogos;
using Hersan.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net.Mail;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.Data;

namespace Hersan.UI.CapitalHumano
{
    public partial class frmSolicitudPersonal : Telerik.WinControls.UI.RadForm
    {
        CapitalHumano.WCF_Catalogos.Hersan_CatalogosClient oCatalogo;
        CapitalHumano.WCF_CHumano.Hersan_CHumanoClient oCHumano;
        List<SolicitudPersonalBE> oList = new List<SolicitudPersonalBE>();
        List<EntidadesBE> oEntidades = new List<EntidadesBE>();
        BaseWinBP lista = new BaseWinBP();
    

        public frmSolicitudPersonal()
        {
            InitializeComponent();
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
        private void CargarPuestos()
        {
            oCatalogo = new CapitalHumano.WCF_Catalogos.Hersan_CatalogosClient();
            try {
                cboPuesto.ValueMember = "ID";
                cboPuesto.DisplayMember = "Nombre";
                cboPuesto.DataSource = oCatalogo.CHUPuestos_Combo();
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al cargar los puestos\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally {
                oCatalogo = null;
            }
        }
        private void CargarTiposContrato()
        {
            oCatalogo = new CapitalHumano.WCF_Catalogos.Hersan_CatalogosClient();
            try {
                cboTipoCon.ValueMember = "ID";
                cboTipoCon.DisplayMember = "Nombre";
                cboTipoCon.DataSource = oCatalogo.ABCTiposcontrato_Combo();
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al cargar los tipos de contrato\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally {
                oCatalogo = null;
            }
        }
        private bool ValidarCampos()
        {
            bool Flag = true;
            try {
                Flag = txtJustif.Text.Trim().Length == 0? false : true;
                Flag = txtIndicad.Text.Trim().Length == 0 ? false : true;
                Flag = txtSueldo.Text.Trim().Length == 0 ? false : true;

                return Flag;
            } catch (Exception ex) {
                throw ex;
            }
        }
        private void LimpiarCampos()
        {
            oList.Clear();
            txtId.Text = "-1";
            txtIndicad.Text = "";
            txtJustif.Text = "";
            txtSueldo.Text = "0";
            cboEntidad.SelectedIndex = -1;
            cboDepto.SelectedIndex = -1;
            cboTipoCon.SelectedIndex = -1;
            cboPuesto.SelectedIndex = -1;
            
        }

        private void CargarSolicitudes()
        {
            oCHumano = new CapitalHumano.WCF_CHumano.Hersan_CHumanoClient();
            try {
                oList = oCHumano.CHU_SolicitudP_Obtener();
                gvDatos.DataSource = oList;
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrio un error al cargar las solicitudes\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally { oCHumano = null; }
        }


        private void frmSolicitud_Load(object sender, EventArgs e)
        {
            try {
                GroupDescriptor Entidades = new GroupDescriptor();
                Entidades.GroupNames.Add("ENT_Nombre", ListSortDirection.Ascending);
                this.gvDatos.GroupDescriptors.Add(Entidades);

                LimpiarCampos();
                CargarEntidades();
                CargarPuestos();
                CargarTiposContrato();
                CargarSolicitudes();

            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrio un error al cargar la pantalla\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
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

        private void btnSalir_Click(object sender, EventArgs e)
        {
            try {
                this.Close();
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al cerrar la pantalla\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            oCatalogo = new CapitalHumano.WCF_Catalogos.Hersan_CatalogosClient();
            oCHumano = new CapitalHumano.WCF_CHumano.Hersan_CHumanoClient();
            SolicitudPersonalBE obj = new SolicitudPersonalBE();
            try {
                if (!ValidarCampos()) {
                    RadMessageBox.Show("Debe capturar todos los datos para continuar", this.Text, MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                    return;
                }

                if (oList.FindAll(item =>  item.Departamentos.Entidades.Id == int.Parse(cboEntidad.SelectedValue.ToString()) &&  item.Departamentos.Id == int.Parse(cboDepto.SelectedValue.ToString())).Count > 0
                   && int.Parse(txtId.Text) == -1) {
                    RadMessageBox.Show("El departamento capturado ya existe, no es posible guardar", this.Text, MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                    LimpiarCampos();
                    return;
                }
                #region Entidades
                obj.Id = int.Parse(txtId.Text);
                obj.Entidades.Id = int.Parse(cboEntidad.SelectedValue.ToString());
                obj.Puestos.Id = int.Parse(cboPuesto.SelectedValue.ToString());
                obj.Departamentos.Id = int.Parse(cboDepto.SelectedValue.ToString());
                obj.TiposContrato.Id = int.Parse(cboTipoCon.SelectedValue.ToString());
                obj.Sueldo = decimal.Parse(txtSueldo.Text);
                obj.Justificacion = txtJustif.Text;
                obj.Indicadores = txtIndicad.Text;
                obj.DatosUsuario.IdUsuarioCreo = BaseWinBP.UsuarioLogueado.ID;
                #endregion

                #region Correo
                string pwd = "nomames21";
                string smtp = "stmp.gmail.com";
                string emisor = "moisegreg30@gmail.com";
                string destinatario = "moisegreg30@gmail.com";
                string asunto = "Asunto: Solicitud de sustitucion personal("+ DateTime.Now.ToString("dd / MMM / yyy hh: mm:ss") + ") ";
                string CuerpoMsg = "Entidad :"+ cboEntidad.SelectedValue.ToString();
               
                int port = 587;
        
                
              
                  
                #endregion



                //PROCESO DE GUARDADO Y ACTUALIZACION
                if (txtId.Text == "-1") {
                    int Result = oCHumano.CHU_SolicitudP_Guardar(obj);
                    if (Result == 0) {
                        RadMessageBox.Show("Ocurrió un error al enviar la solicitud de empleo", this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
                    } else {
                        RadMessageBox.Show("Solicitud enviada correctamente", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                        LimpiarCampos();
                        CargarSolicitudes();
                        BaseWinBP.EnviarMail(emisor, destinatario, asunto, CuerpoMsg, smtp, pwd, port);
                    }
                } 
                else {
                    oCHumano = new CapitalHumano.WCF_CHumano.Hersan_CHumanoClient();
                    int Result = oCHumano.CHU_SolicitudP_Actualizar(obj);
                    if (Result == 0) {
                        RadMessageBox.Show("Ocurrió un error al actualizar los datos", this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
                    } else {
                        RadMessageBox.Show("Información actualizada correctamente", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                        LimpiarCampos();
                        CargarSolicitudes();
                    }
                }
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrio un error al actualizar la información\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally {
                
                oCHumano = null;
            }
        }

        private void gvDatos_CurrentRowChanged(object sender, Telerik.WinControls.UI.CurrentRowChangedEventArgs e)
        {
            try {

                if (gvDatos.RowCount > 0 && e.CurrentRow.ChildRows.Count == 0) {
                    txtId.Text = e.CurrentRow.Cells["Id"].Value.ToString();
                    txtJustif.Text = e.CurrentRow.Cells["Justificacion"].Value.ToString();
                    txtIndicad.Text = e.CurrentRow.Cells["Indicadores"].Value.ToString();
                    txtSueldo.Text = (e.CurrentRow.Cells["Sueldo"].Value.ToString());
                    cboDepto.SelectedValue =int.Parse (e.CurrentRow.Cells["DEP_Id"].Value.ToString());
                    cboEntidad.SelectedValue = int.Parse(e.CurrentRow.Cells["ENT_Id"].Value.ToString());
                    cboTipoCon.SelectedValue = int.Parse(e.CurrentRow.Cells["TCO_Id"].Value.ToString());
                    cboPuesto.SelectedValue =int.Parse (e.CurrentRow.Cells["PUE_Id"].Value.ToString());
                   

                   
                }
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrio un error al seleccionar el registro\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            oCHumano = new CapitalHumano.WCF_CHumano.Hersan_CHumanoClient();
            SolicitudPersonalBE obj = new SolicitudPersonalBE();
            try {
                //if (chkEstatus.Checked) {
                    if (RadMessageBox.Show("Esta acción dará de baja la solicitud\nDesea continuar...?", this.Text, MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.Yes) {
                        obj.Id = int.Parse(txtId.Text);
                        obj.Entidades.Id = int.Parse(cboEntidad.SelectedValue.ToString());
                        obj.Puestos.Id = int.Parse(cboPuesto.SelectedValue.ToString());
                        obj.Departamentos.Id = int.Parse(cboDepto.SelectedValue.ToString());
                        obj.TiposContrato.Id = int.Parse(cboTipoCon.SelectedValue.ToString());
                        obj.Sueldo = decimal.Parse(txtSueldo.Text);
                        obj.Justificacion = txtJustif.Text;
                        obj.Indicadores = txtIndicad.Text;                   
                        obj.DatosUsuario.Estatus = false;
                        obj.DatosUsuario.IdUsuarioModif = BaseWinBP.UsuarioLogueado.ID;

                        int Result = oCHumano.CHU_SolicitudP_Actualizar(obj);
                        if (Result == 0) {
                            RadMessageBox.Show("Ocurrió un error al modificar los datos", this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
                        } else {
                            RadMessageBox.Show("Información actualizada correctamente", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                            LimpiarCampos();
                            CargarSolicitudes();
                        
                    }
                }
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrio un error al dar de baja la solicitud\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally {
                oCHumano = null;
            }
        }

        private void txtSueldo_KeyPress(object sender, KeyPressEventArgs e)
        {
            try {
                if (BaseWinBP.isDecimal(e.KeyChar)) {
                    e.Handled = true;
                }
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrio un error al capturar la ponderación\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
    }
    }


