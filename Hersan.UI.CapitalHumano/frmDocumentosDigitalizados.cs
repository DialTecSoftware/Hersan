﻿using Hersan.Entidades.CapitalHumano;
using Hersan.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace Hersan.UI.CapitalHumano
{
    public partial class frmDocumentosDigitalizados : Telerik.WinControls.UI.RadForm
    {
        #region Variables
        public int IdExpediente { get; set; }
        WCF_Catalogos.Hersan_CatalogosClient oCatalogos;
        OpenFileDialog oDialog = new OpenFileDialog();
        CapitalHumano.WCF_CHumano.Hersan_CHumanoClient oCHumano;
        private List<DigitalizadosDetalleBE> oList = new List<DigitalizadosDetalleBE>();
        private DigitalizadosDetalleBE oDetalle;
        ExpedientesDatosPersonales oDatosPersonales;
        string path = string.Empty;
        bool Flag;
       
        string filePath = string.Empty;
        List<ExpedientesBE> oExpediente = new List<ExpedientesBE>();
        #endregion
        public frmDocumentosDigitalizados()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
        private bool ValidarCampos()
        {
            bool Flag = true;
            try {
                Flag = txtApellidos.Text.Trim().Length == 0 ? false : true;
                Flag = txtNombres.Text.Trim().Length == 0 ? false : true;
                Flag = txtNoEmp.Text.Trim().Length == 0 ? false : true;
                return Flag;
            } catch (Exception ex) {
                throw ex;
            }
        }

        private void LimpiarCampos()
        {
            txtApellidos.Text = string.Empty;
            txtId.Text = "0";
            txtNoEmp.Text = string.Empty;
            txtIdExp.Text = string.Empty;
            txtNombres.Text = string.Empty;
            gvDatos.DataSource=null;

        }
        private void ActualizaGrid()
        {
            try {
                gvDatos.DataSource = null;
                gvDatos.DataSource = oList.FindAll(item => item.DatosUsuario.Estatus == true);
            } catch (Exception ex) {
                throw ex;
            }
        }
        private void GuardarArchivo()
        {
            try {

                if (filePath != path)
                    oList.ForEach(item => {
                        path = item.RutaArchivo;
                        filePath = oDialog.FileName;
                        System.IO.File.Copy(filePath, path, true);
                    });
                                 
                } catch (Exception) {

                throw;
            }
        }
        private void CargaDocumentos()
        {
            oCatalogos = new WCF_Catalogos.Hersan_CatalogosClient();
            try {
                cboDocs.DisplayMember = "Nombre";
                cboDocs.ValueMember = "Id";
                cboDocs.DataSource = oCatalogos.ABCDocumentos_Combo();
            } catch (Exception ex) {
                throw ex;
            } finally {
                oCatalogos = null;
            }
        }
        private void CargaExpediente(int IdExpediente)
        {
            oCHumano = new WCF_CHumano.Hersan_CHumanoClient();

            try {
                oExpediente = oCHumano.CHU_Expedientes_Obtener(IdExpediente);
                if (oExpediente.Count > 0) {

                    //  SE CARGA EL EXPEDIENTE
                    txtIdExp.Text = IdExpediente.ToString();

                    ExpedientesDatosPersonales oAux = new ExpedientesDatosPersonales();
                    oAux.IdExpediente = int.Parse(txtIdExp.Text);
                    var Item = oCHumano.CHU_ExpedientesDatosPersonales_Consultar(oAux);

                    if (Item.Count > 0) {
                        txtApellidos.Text = Item[0].APaterno + " " + Item[0].AMaterno;
                        txtNombres.Text = Item[0].Nombres;
                        txtNoEmp.Text = Item[0].Empleados.Id.ToString();
                    }
                }
            } catch (Exception) {

                throw;
            }
        }

        private void CargarGrid()
        {
            oCHumano = new WCF_CHumano.Hersan_CHumanoClient();
            oList.Clear();
            Flag = false;

            try {
                if (txtIdExp.Text != null && txtNoEmp.Text != null) {
                    DataSet oAux = oCHumano.CHU_Digitalizados_Obtener(int.Parse(txtIdExp.Text), int.Parse(txtNoEmp.Text));
                    if (oAux.Tables.Count > 0) {

                        /* EDUCACIÓN */
                        if (oAux.Tables[0].Rows.Count > 0) {
                            txtId.Text = oAux.Tables[0].Rows[0]["DIG_Id"].ToString();
                        }

                            foreach (DataRow oRow in oAux.Tables[0].Rows) {
                            oList.Add(new DigitalizadosDetalleBE() {
                                Id = int.Parse(oRow["DIG_Id"].ToString()),
                                IdTipo = int.Parse(oRow["DOC_Id"].ToString()),
                                Tipo = oRow["DOC_Nombre"].ToString(),
                                RutaArchivo = oRow["DDT_RutaArchivo"].ToString(),

                            });
                        }
                    }
                }

                ActualizaGrid();

            } catch (Exception ex) {
                throw ex;
            } finally {
                Flag = true;
            }
        }


        private void btnNuevo_Click(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int IdExpediente = 0;
            try {
                frmExpedienteConsulta ofrm = new frmExpedienteConsulta();
                ofrm.WindowState = FormWindowState.Normal;
                ofrm.StartPosition = FormStartPosition.CenterScreen;
                ofrm.MaximizeBox = false;
                ofrm.MinimizeBox = false;
                ofrm.ShowDialog();
                IdExpediente = ofrm.IdExpediente;


                if (IdExpediente > 0) {
                    LimpiarCampos();
                    CargaExpediente(IdExpediente);
                    CargarGrid();
                }
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al realiza la búsqueda\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }

        private void frmDocumentosDigitalizados_Load(object sender, EventArgs e)
        {
            try {
                CargaDocumentos();

            } catch (Exception) {

                throw;
            }
        }


        private void btnSalir_Click(object sender, EventArgs e)
        {
            try {
                this.Close();
            } catch (Exception) {

                throw;
            }
        }

        private void CargarArchivo_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;


            try {
                if (txtNoEmp.Text == string.Empty && txtIdExp.Text == string.Empty ) {
                    RadMessageBox.Show("Debe de seleccionar un expediente antes de seleciona...\n", this.Text, MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                    return;
                }

                oDialog.InitialDirectory = "";
                oDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                oDialog.FilterIndex = 2;
                oDialog.RestoreDirectory = true;

                if (oDialog.ShowDialog() == DialogResult.OK) {

                    //Get the path of specified file
                  
                    filePath = oDialog.FileName;
                    string archivo=  System.IO.Path.GetFileName(filePath);
                    //= filePath.Substring(filePath.LastIndexOf(@"/"));
                    path = @"C:\Temp\Greg\" + txtIdExp.Text + "_" +archivo; 
                    txtArchivo.Text = path;


                  
                }

            } catch (Exception) {

                throw;
            }
        }

        private void txtArchivo_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnVerArchivo_Click(object sender, EventArgs e)
        {
            try {
                if (gvDatos.RowCount > 0) {
                    oList.ForEach(item => {
                        if (item.Sel == true)
                            BaseWinBP.AbrirArchivo(item.RutaArchivo);

                    });
                }
            } catch (Exception ex) {

                RadMessageBox.Show("Ocurió un error al abrir el archivo\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }

        private void btnAddPariente_Click(object sender, EventArgs e)
        {
            oDetalle = new DigitalizadosDetalleBE();
            try {
                if (oList.FindAll(item => item.RutaArchivo == txtArchivo.Text).Count == 0) {
                    oDetalle.Sel = false;
                    oDetalle.IdTipo = int.Parse(cboDocs.SelectedValue.ToString());
                    oDetalle.Tipo = cboDocs.SelectedItem.Text;
                    oDetalle.RutaArchivo = txtArchivo.Text;

                    oList.Add(oDetalle);
                    ActualizaGrid();
                    txtArchivo.Text=string.Empty;

                } else {
                    RadMessageBox.Show("No es posible agregar un documeto que ya existe en la lista", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                }
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al agregar la selección\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }

        private void btnQuitarItem_Click(object sender, EventArgs e)
        {
            try {
                if (txtId.Text == "0")
                    oList.RemoveAll(item => item.Sel == true);
                else
                    oList.ForEach(item => {
                        if (item.Sel == true)
                            item.DatosUsuario.Estatus = false;
                    });

                ActualizaGrid();
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al cargar la pantalla\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }

        private void commandBarButton2_Click(object sender, EventArgs e)
        {
            try {
                if (txtId.Text == "0")
                    oList.Clear();
                else
                    oList.ForEach(item => item.DatosUsuario.Estatus = false);

                ActualizaGrid();
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al cargar la pantalla\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            oCHumano = new WCF_CHumano.Hersan_CHumanoClient();
            DataTable oData = new DataTable("Datos");

            try {
                if (!ValidarCampos()) {
                    RadMessageBox.Show("Debe capturar todos los datos para continuar", this.Text, MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                    return;
                }

                oData.Columns.Add("Id");
                oData.Columns.Add("Tipo");
                oData.Columns.Add("Ruta");
                oData.Columns.Add("Estatus");

                DigitalizadosBE obj = new DigitalizadosBE();
                oList.ForEach(item => {
                    obj.Id = txtId.Text.Trim().Length > 0 ? int.Parse(txtId.Text) : 0;
                    obj.Expedientes.Id = int.Parse(txtIdExp.Text);
                    obj.Empleados.Id = int.Parse(txtNoEmp.Text);
                    obj.DatosUsuario.IdUsuarioCreo = BaseWinBP.UsuarioLogueado.ID;

                    #region Carga Detalle
                    DataRow oRow = oData.NewRow();

                    oRow["Tipo"] = item.IdTipo;
                    oRow["Ruta"] = item.RutaArchivo;
                    oRow["Estatus"] = item.DatosUsuario.Estatus;

                    oData.Rows.Add(oRow);
                    #endregion
                });

                /* ALTA DE PERFIL */
                if (int.Parse(txtId.Text) == 0) {
                    int Result = oCHumano.CHU_Digitalizados_Guardar(obj, oData);
                    if (Result != 0) {
                        GuardarArchivo();
                        RadMessageBox.Show("Documento guardado correctamente", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                    } else {
                        RadMessageBox.Show("Ocurrió un error al guardar el documento", this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
                    }
                } else {
                    int Result = oCHumano.CHU_Digitalizados_Actualiza(obj, oData);
                    if (Result != 0) {
                        RadMessageBox.Show("Documneto actualizado correctamente", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                        GuardarArchivo();
                    } else {
                        RadMessageBox.Show("Ocurrió un error al actualizar el documento", this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
                    }

                }
                LimpiarCampos();
                
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al guardar el documento\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally {
                oCHumano = null;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            oCHumano = new WCF_CHumano.Hersan_CHumanoClient();
            try {
                if (txtId.Text != "0") {
                    if (RadMessageBox.Show("Desea eliminar los documentos para el empleado seleccionado...?", this.Text, MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.Yes) {
                        int Result = oCHumano.CHU_Digitalizados_Elimina(int.Parse(txtId.Text), BaseWinBP.UsuarioLogueado.ID);
                        if (Result != 0) {
                            RadMessageBox.Show("Documentos eliminados correctamente", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                        } else {
                            RadMessageBox.Show("Ocurrió un error al eliminar los documentos", this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
                        }
                    }
                }
                LimpiarCampos();
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al eliminar los documentos\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally {
                oCHumano = null;
            }
        }
    }
}

