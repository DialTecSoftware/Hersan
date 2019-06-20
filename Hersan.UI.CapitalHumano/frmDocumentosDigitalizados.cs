using Hersan.Entidades.CapitalHumano;
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
        WCF_CHumano.Hersan_CHumanoClient oCHumano;

        OpenFileDialog oDialog = new OpenFileDialog();
        private List<DigitalizadosDetalleBE> oList = new List<DigitalizadosDetalleBE>();        

        string path = string.Empty;
        string directory = string.Empty;       
        string filePath = string.Empty;
        #endregion

        public frmDocumentosDigitalizados()
        {
            InitializeComponent();
        }        
        private void frmDocumentosDigitalizados_Load(object sender, EventArgs e)
        {
            try {
                txtIdExp.Text = IdExpediente.ToString();
                CargaDocumentos();
                CargarGrid();
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al mostrar la pantalla\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            oCHumano = new WCF_CHumano.Hersan_CHumanoClient();
            try {
                if (oList.Count == 0) {
                    RadMessageBox.Show("Debe agregar al menos un documento para continuar", this.Text, MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                    return;
                }

                #region Carga Detalle
                DataTable oData = new DataTable("Datos");

                oData.Columns.Add("Id");
                oData.Columns.Add("Tipo");
                oData.Columns.Add("Ruta");
                oData.Columns.Add("Estatus");

                oList.ForEach(item => {
                    
                    DataRow oRow = oData.NewRow();

                    oRow["Tipo"] = item.Documento.Id;
                    oRow["Ruta"] = item.NombreArchivo;
                    oRow["Estatus"] = item.DatosUsuario.Estatus;

                    oData.Rows.Add(oRow);                    
                });

                #endregion

                int Result = oCHumano.CHU_Digitalizados_Guardar(int.Parse(txtIdExp.Text), oData, BaseWinBP.UsuarioLogueado.ID, oList);
                if (Result != 0) {
                    RadMessageBox.Show("Documentos guardados correctamente", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                    this.Close();
                } else
                    RadMessageBox.Show("Ocurrió un error al guardar los documentos", this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
                
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al guardar los documentos\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally {
                oCHumano = null;
            }
        }
        private void CargarArchivo_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;

            try {
                oDialog.InitialDirectory = "";
                oDialog.Filter = "pdf files (*.pdf)|*.pdf|All files (*.*)|*.*";
                oDialog.FilterIndex = 2;
                oDialog.RestoreDirectory = true;

                if (oDialog.ShowDialog() == DialogResult.OK) {
                    string archivo=  System.IO.Path.GetFileName(oDialog.FileName);
                    txtArchivo.Text = archivo;
                    directory = @"C:\Temp\" + txtIdExp.Text;
                    path = directory + @"\" + archivo;
                }
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al seleccionar el archivo\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void btnVerArchivo_Click(object sender, EventArgs e)
        {
            try {
                if (oList.FindAll(item => item.Sel == true).Count == 0) {
                    RadMessageBox.Show("No hay ningun archivo seleccionado", this.Text, MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                    return;
                }

                BinaryWriter Writer = null;

                oList.ForEach(item => {
                    if (item.Sel == true) {
                        if (item.Archivo != null) {
                            Writer = new BinaryWriter(File.OpenWrite(Directory.GetCurrentDirectory() + "\\" + item.NombreArchivo));
                            Writer.Write(item.Archivo);
                            Writer.Flush();
                            Writer.Close();

                            BaseWinBP.AbrirArchivo(Directory.GetCurrentDirectory() + "\\" + item.NombreArchivo);
                        } else
                            BaseWinBP.AbrirArchivo(item.RutaOriginal);
                    }

                });                    
            } catch (Exception ex) {

                RadMessageBox.Show("Ocurió un error al abrir el archivo\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void btnAddPariente_Click(object sender, EventArgs e)
        {
            try {
                if (txtArchivo.Text == "") {
                    RadMessageBox.Show("Selecciona un archivo antes de continuar", this.Text, MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                    return;
                }
                            
                if (oList.FindAll(item => item.Documento.Id == int.Parse(cboDocs.SelectedValue.ToString()) && item.DatosUsuario.Estatus == true).Count == 0) {
                    DigitalizadosDetalleBE oDetalle = new DigitalizadosDetalleBE();

                    oDetalle.Sel = false;
                    oDetalle.Documento.Id = int.Parse(cboDocs.SelectedValue.ToString());
                    oDetalle.Documento.Nombre = cboDocs.SelectedItem.Text;
                    oDetalle.RutaArchivo = path;
                    oDetalle.NombreArchivo= System.IO.Path.GetFileName(oDialog.FileName);
                    oDetalle.RutaOriginal = oDialog.FileName;
                    oDetalle.Archivo = ConvertImage.FileToByteArray(oDialog.FileName);

                    oList.Add(oDetalle);

                    ActualizaGrid();
                    txtArchivo.Text=string.Empty;
                } else {
                    RadMessageBox.Show("No es posible agregar un tipo de documento o un archivo  que ya existe en la lista", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                }
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al agregar el archivo\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void btnQuitarItem_Click(object sender, EventArgs e)
        {
            try {
                if (oList.FindAll(item => item.Sel == true).Count > 0) {
                    if (RadMessageBox.Show("Esta acción eliminara los elementos seleccionados\nDesea continuar...?", this.Text, MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.No)
                        return;
                } else {
                    RadMessageBox.Show("No hay documentos seleccionados", this.Text, MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                    return;
                }

                oList.ForEach(item => {
                    if (item.Sel == true)
                        item.DatosUsuario.Estatus = false;
                });
                //oList.RemoveAll(item => item.DatosUsuario.Estatus == false);

                ActualizaGrid();
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al quitar los documentos\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void btnTodos_Click(object sender, EventArgs e)
        {
            try {
                if (oList.Count > 0) {
                    if (RadMessageBox.Show("Esta acción eliminara todos los elementos\nDesea continuar...?", this.Text, MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.No)
                        return;
                } else {
                    RadMessageBox.Show("No se han agregado documentos", this.Text, MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                    return;
                }

                oList.ForEach(item => item.DatosUsuario.Estatus = false);
                //oList.RemoveAll(item => item.DatosUsuario.Estatus == false);

                ActualizaGrid();
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al quitar los documentos\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            try {
                this.Close();
            } catch (Exception) {
                RadMessageBox.Show("Ocurrió un error al cerrar la pantalla", this.Text, MessageBoxButtons.OK, RadMessageIcon.Exclamation);
            }
        }

        private void ActualizaGrid()
        {
            try {
                gvDatos.DataSource = null;
                gvDatos.DataSource = oList.FindAll(Item => Item.DatosUsuario.Estatus == true);
            } catch (Exception ex) {
                throw ex;
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
        private void CargarGrid()
        {
            oCHumano = new WCF_CHumano.Hersan_CHumanoClient();
            try {
                gvDatos.DataSource = null;
                oList = oCHumano.CHU_Digitalizados_Obtener(int.Parse(txtIdExp.Text));
                gvDatos.DataSource = oList;
            } catch (Exception ex) {
                throw ex;
            } finally {
                oCHumano = null;
            }
        }
    }
}

