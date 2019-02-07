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

namespace Hersan.UI.Catalogos
{
    public partial class frmOrganigrama : Telerik.WinControls.UI.RadForm
    {
        WCF_Catalogos.Hersan_CatalogosClient oCatalogo;
        List<OrganigramaBE> oList = new List<OrganigramaBE>();
        public frmOrganigrama()
        {
            InitializeComponent();
        }

        private void frmOrganigrama_Load(object sender, EventArgs e)
        {

            try {
                txtId.Text = "1";
                ComboPadre();
                ComboPuesto();
                CargarElementos_Organigrama();
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrio un error al cargar la pantalla\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
    
        private void ComboPuesto()
        {
            oCatalogo = new WCF_Catalogos.Hersan_CatalogosClient();
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

        private void ComboPadre()
        {
            oCatalogo = new WCF_Catalogos.Hersan_CatalogosClient();
            try {
                cboPadre.ValueMember = "ID";
                cboPadre.DisplayMember = "Nombre";
                cboPadre.DataSource = oCatalogo.CHUPuestos_Combo();
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al cargar los puestos\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally {
                oCatalogo = null;
            }
        }

        private void LimpiarCampos()
        {
            try {
                txtId.Text = "0";
                cboPuesto.SelectedIndex = -1;
                cboPadre.SelectedIndex = -1;
                cboNivel.SelectedIndex = -1;
               
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrio un error al limpiar los campos\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void CargarElementos_Organigrama()
        {
            oCatalogo = new WCF_Catalogos.Hersan_CatalogosClient();
            try {
                oList = oCatalogo.CHUOrganigrama_Obtener();
                gvDatos.DataSource = oList;
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrio un error al cargar los puestos\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally {
                oCatalogo = null;
            }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            oCatalogo = new WCF_Catalogos.Hersan_CatalogosClient();
            OrganigramaBE obj = new OrganigramaBE();
            try {

                //if (oList.FindAll(item => item.Nombre.Trim() == txtNombre.Text.Trim() && item.Id_puesto == int.Parse(cboPuesto.SelectedValue.ToString())).Count > 0
                //    && int.Parse(txtIdPuesto.Text) == 0) {
                //    RadMessageBox.Show("La información capturada ya existe, no es posible guardar", this.Text, MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                //    LimpiarCampos();
                //    return;
                //}

                if (RadMessageBox.Show("Desea guardar los datos capturados...?", this.Text, MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.Yes) {

                 
                    obj.Nivel = cboNivel.SelectedIndex;
                    obj.Id_padre = int.Parse(cboPadre.SelectedValue.ToString());
                    obj.Id_puesto = int.Parse(cboPuesto.SelectedValue.ToString());

                    //PROCESO DE GUARDADO Y ACTUALIZACION
                    if (txtId.Text == "0") {
                        int Result = oCatalogo.CHUOrganigrama_Guardar(obj);
                        if (Result == 0) {
                            RadMessageBox.Show("Ocurrió un error al guardar un elemento en el organigrama", this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
                        } else {
                            RadMessageBox.Show("Elemento guardado correctamente", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                            LimpiarCampos();
                            CargarElementos_Organigrama();

                        }
                    } else {
                        int Result = oCatalogo.CHUOrganigrama_Actualizar(obj);
                        if (Result == 0) {
                            RadMessageBox.Show("Ocurrió un error al actualizar los datos", this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
                        } else {
                            RadMessageBox.Show("Información actualizada correctamente", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                            LimpiarCampos();
                            CargarElementos_Organigrama();

                        }
                    }
                }
                
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al actualizar la información\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally {
                oCatalogo = null;
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try {
                LimpiarCampos();
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrio un error al limpiar los campos\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            try {
                this.Close();
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrio un error al cerrar la pantalla\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
    }

}
