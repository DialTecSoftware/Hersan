using Hersan.Entidades.Ensamble;
using Hersan.Negocio;
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
    public partial class frmAgenteCliente : Telerik.WinControls.UI.RadForm
    {
        WCF_Catalogos.Hersan_CatalogosClient oCatalogos;
        WCF_Ensamble.Hersan_EnsambleClient oEnsamble;
        List<ClientesBE> oList = new List<ClientesBE>();

        public frmAgenteCliente()
        {
            InitializeComponent();
        }
        private void frmAgenteCliente_Load(object sender, EventArgs e)
        {
            try {
                CargaAgentes();
                CargaClientes();
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al cargar la pantalla\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            oEnsamble = new WCF_Ensamble.Hersan_EnsambleClient();
            ClientesBE obj = new ClientesBE();
            string Clientes = string.Empty;
            try {
                
                foreach (var item in lstClientes.Items) {
                    if (item.CheckState == Telerik.WinControls.Enumerations.ToggleState.On) {
                        Clientes += item.Value.ToString() + ",";
                    }
                }

                if (Clientes.Length == 0) {
                    RadMessageBox.Show("Debe Seleccionar al menos un cliente por asociar", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                    return;
                }

                if (RadMessageBox.Show("Desea asignar el agente...?", this.Text, MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.Yes) {

                    obj.Nombre = Clientes;
                    obj.Agente.Id = int.Parse(cboAgentes.SelectedValue.ToString());
                    obj.DatosUsuario.IdUsuarioCreo = BaseWinBP.UsuarioLogueado.ID;
                    obj.DatosUsuario.Estatus = true;
                    

                    int Result = oEnsamble.ABC_ClientesAgente_Guardar(obj);
                    if (Result == 0) {
                        RadMessageBox.Show("Ocurrió un error al asignar los clientes al agente", this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
                    } else {
                        RadMessageBox.Show("Clientes asignados correctamente al agente", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                        cboAgentes.SelectedIndex = -1;
                        CargaClientes();
                        cboAgentes.SelectedIndex = 0;
                    }
                }
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al guardar los datos\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally {
                obj = null;
                oEnsamble = null;
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            oEnsamble = new WCF_Ensamble.Hersan_EnsambleClient();
            ClientesBE obj = new ClientesBE();
            string Clientes = string.Empty;
            try {
                oList.ForEach(item => {
                    if (item.Sel == true) {
                        Clientes += item.Id.ToString() + ",";
                    }
                });

                if (Clientes.Length == 0) {
                    RadMessageBox.Show("Debe Seleccionar al menos un cliente a des-asociar", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                    return;
                }

                if (RadMessageBox.Show("Desea des-asignar los clientes seleccionados...?", this.Text, MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.Yes) {
                    obj.Nombre = Clientes;
                    obj.Agente.Id = int.Parse(cboAgentes.SelectedValue.ToString());
                    obj.DatosUsuario.IdUsuarioCreo = BaseWinBP.UsuarioLogueado.ID;
                    obj.DatosUsuario.Estatus = false;

                    int Result = oEnsamble.ABC_ClientesAgente_Guardar(obj);
                    if (Result == 0) {
                        RadMessageBox.Show("Ocurrió un error al des-asignar los clientes al agente", this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
                    } else {
                        RadMessageBox.Show("Clientes des-asignados correctamente al agente", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                        cboAgentes.SelectedIndex = -1;
                        CargaClientes();
                        cboAgentes.SelectedIndex = 0;
                    }
                }
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al guardar los datos\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally {
                obj = null;
                oEnsamble = null;
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
        private void cboAgentes_SelectedIndexChanged(object sender, EventArgs e)
        {
            oEnsamble = new WCF_Ensamble.Hersan_EnsambleClient();
            try {
                if(cboAgentes.SelectedValue != null) {
                    gvDatos.DataSource = null;
                    oList = oEnsamble.ABC_ClientesAgente_Combo(int.Parse(cboAgentes.SelectedValue.ToString()));
                    gvDatos.DataSource = oList;
                }
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al seleccionar el agente\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally {
                oEnsamble = null;
            }
        }

        private void CargaAgentes()
        {
            oCatalogos = new WCF_Catalogos.Hersan_CatalogosClient();
            try {
                cboAgentes.ValueMember = "Id";
                cboAgentes.DisplayMember = "Nombre";
                cboAgentes.DataSource = oCatalogos.ABC_Agentes_Obtener();
            } catch (Exception ex) {
                throw ex;
            } finally {
                oCatalogos = null;
            }
        }
        private void CargaClientes()
        {
            oEnsamble = new WCF_Ensamble.Hersan_EnsambleClient();
            try {
                lstClientes.ValueMember = "Id";
                lstClientes.DisplayMember = "Nombre";
                lstClientes.DataSource = oEnsamble.ABC_ClientesAgente_Combo(0);
            } catch (Exception ex) {
                throw ex;
            } finally {
                oEnsamble = null;
            }
        }
       
    }
}
