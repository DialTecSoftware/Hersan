using Hersan.Entidades.Catalogos;
using Hersan.Entidades.Ensamble;
using Hersan.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.Data;
using Telerik.WinControls.UI;

namespace Hersan.UI.Ensamble
{
    public partial class frmAltaProducto : Telerik.WinControls.UI.RadForm
    {
        #region Variables
        WCF_Catalogos.Hersan_CatalogosClient oCatalogos;
        WCF_Ensamble.Hersan_EnsambleClient oEnsamble;
        List<FamiliasBE> oFamilia = new List<FamiliasBE>();
        List<TipoProductoBE> oTipo = new List<TipoProductoBE>();
        List<ProductosCombinacion> oList = new List<ProductosCombinacion>();
        List<ProductoEnsambleBE> oProducto = new List<ProductoEnsambleBE>();

        byte[] Imagen;
        string Colores = string.Empty;
        string Reflejantes = string.Empty;
        string Accesorios = string.Empty;
        #endregion

        public frmAltaProducto()
        {
            InitializeComponent();
        }
        private void frmAltaProducto_Load(object sender, EventArgs e)
        {
            try {
                #region Grupo
                GroupDescriptor Tipo = new GroupDescriptor();
                Tipo.GroupNames.Add("Tipo", ListSortDirection.Ascending);
                this.gvResult.GroupDescriptors.Add(Tipo);
                #endregion

                txtCodigo.Clear();

                CargarEntidades();
                CargaColores();
                CargarReflejantes();
                CargaAccesorios();
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al cargar la pantalla\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try {

            } catch (Exception ex) {
                throw ex;
            }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            oEnsamble = new WCF_Ensamble.Hersan_EnsambleClient();            
            int Result = 0;
            try {

                if (!ValidarCampos()) {
                    RadMessageBox.Show("Debe capturar todos los datos para continuar", this.Text, MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                    return;
                }

                if (RadMessageBox.Show("Desea guardar la información capturada...?", this.Text, MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.No)
                    return;

                /* ALTA DE FICHA TÉCNICA */
                if (int.Parse(txtId.Text) == 0) {
                    Result = oEnsamble.ENS_ProductosFicha_Guardar(CrearTablasAuxiliares(), Imagen, Colores, Reflejantes, Accesorios, BaseWinBP.UsuarioLogueado.ID);
                    if (Result != 0) {
                        RadMessageBox.Show("Ficha técnica guardada correctamente", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                    } else {
                        RadMessageBox.Show("Ocurrió un error al guardar la ficha", this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
                    }
                } else {
                    Result = oEnsamble.ENS_ProductosFicha_Actualizar(CrearTablasAuxiliares(), Imagen, Colores, Reflejantes, Accesorios, BaseWinBP.UsuarioLogueado.ID,true);
                    if (Result != 0) {
                        RadMessageBox.Show("Ficha técnica actualizada correctamente", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                    } else {
                        RadMessageBox.Show("Ocurrió un error al actualizar la ficha", this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
                    }
                }
                if (Result != 0) {
                    LimpiarCampos();
                }
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al guardar la ficha\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally {
                oEnsamble = null;
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            oEnsamble = new WCF_Ensamble.Hersan_EnsambleClient();
            try {
                if (int.Parse(txtId.Text) > 0) {
                    if (RadMessageBox.Show("Desea eliminar la ficha actual...?", this.Text, MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.Yes) {
                        if (oEnsamble.ENS_ProductosFicha_Actualizar(CrearTablasAuxiliares(), Imagen, Colores, Reflejantes, Accesorios, BaseWinBP.UsuarioLogueado.ID, false) > 0) {
                            RadMessageBox.Show("Ficha técnica eliminada correctamente", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                            LimpiarCampos();
                        } else
                            RadMessageBox.Show("Ocurrió un error al eliminar la ficha", this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
                    }
                }
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al eliminar la ficha\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally {
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
        private void btnImagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog oDialog = new OpenFileDialog();
            try {
                oDialog.Filter = "Archivos jpg (*.jpg)|*.jpg";
                oDialog.Title = "Imagen de Producto";

                if (oDialog.ShowDialog() == DialogResult.OK) {
                    System.IO.FileInfo oFile = new System.IO.FileInfo(oDialog.FileName);

                    if (oFile.Length > 200000)
                        RadMessageBox.Show("La imagen debe no debe ser mayor a 200Kb", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                    else {
                        Imagen = ConvertImage.FileToByteArray(oDialog.FileName);
                        picFoto.Image = ConvertImage.ByteToImage(Imagen);
                    }
                }
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al cargar la fotografía del expediente\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void txtCantidad_ValueChanged(object sender, EventArgs e)
        {
            //oCatalogos = new WCF_Catalogos.Hersan_CatalogosClient();
            //int Count = 0;
            ////string Props = string.Empty;
            ////string[] fields;

            //try {
            //    Count = (gvResult.Columns.Count - 1) + 1;

            //    /* SE GENERAN LAS COLUMNAS DINAMICAS */
            //    if (int.Parse(txtCantidad.Value.ToString()) > (gvResult.Columns.Count - 1)) {
            //        GridViewComboBoxColumn col;
            //        while (int.Parse(txtCantidad.Value.ToString()) >= Count) {
            //            col = new GridViewComboBoxColumn {
            //                DataSource = oCatalogos.ENS_Reflejantes_Combo(),
            //                DisplayMember = "Tipo",
            //                ValueMember = "Id",
            //                FieldName = "Id",
            //                HeaderText = "Reflejante " + Count.ToString(),
            //                Name = "Reflejante" + Count.ToString(),
            //                Width = 200
            //            };

                        
            //            Count += 1;
            //            gvResult.Columns.Add(col);

            //        }
            //    } else {
            //        //SE AGREGA LA COLUMNA DE ID REFEJANTE
            //        Tabla.Columns.RemoveAt(Count - 1);
            //        gvResult.Columns.RemoveAt(Count - 1);
            //    }

            //    #region DYNAMIC PROPERTIES
            //    //foreach (GridViewDataColumn Col in gvResult.Columns) {
            //    //    Props += Col.Name + ",";
            //    //}

            //    //fields = Props.Substring(0, Props.Length - 1).Split(',');

            //    //foreach (string field in fields) {
            //    //    if (field.Length > 1) {
            //    //        formData.Add(field, null);
            //    //    }
            //    //}
            //    //oList.Add(formData);
            //    #endregion

            //    //gvResult.DataSource = oList;

            //    if (gvResult.ColumnCount == 1)
            //        gvResult.DataSource = null;
            //} catch (Exception ex) {
            //    throw ex;
            //} finally {
            //    oCatalogos = null;
            //}
        }
        private void cboEntidad_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            oCatalogos = new WCF_Catalogos.Hersan_CatalogosClient();
            try {
                if (cboEntidad.Items.Count > 0 && cboEntidad.SelectedValue != null) {
                    oFamilia = oCatalogos.ENS_Familias_Combo(int.Parse(cboEntidad.SelectedValue.ToString()));
                    cboFamilia.ValueMember = "Id";
                    cboFamilia.DisplayMember = "Nombre";
                    cboFamilia.DataSource = oFamilia;
                }
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al seleccionar la entidad\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally {
                oCatalogos = null;
            }
        }
        private void cboFamilia_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            oCatalogos = new WCF_Catalogos.Hersan_CatalogosClient();
            try {
                if (cboFamilia.Items.Count > 0 && cboFamilia.SelectedValue != null) {
                    txtCodigo.Text = oFamilia.Find(item => item.Id == int.Parse(cboFamilia.SelectedValue.ToString())).Clave;

                    oTipo = oCatalogos.ENS_TipoProducto_Combo(int.Parse(cboFamilia.SelectedValue.ToString()));
                    cboTipo.DisplayMember = "Nombre";
                    cboTipo.ValueMember = "Id";
                    cboTipo.DataSource = oTipo;
                }
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al seleccionar la familia\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally {
                oCatalogos = null;
            }
        }
        private void cboTipo_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            oEnsamble = new WCF_Ensamble.Hersan_EnsambleClient();
            try {

                if (cboTipo.Items.Count > 0 && cboTipo.SelectedValue != null) {
                    txtCodigo.Text = oFamilia.Find(item => item.Id == int.Parse(cboFamilia.SelectedValue.ToString())).Clave + " - " +
                        oTipo.Find(Item => Item.Id == int.Parse(cboTipo.SelectedValue.ToString())).Clave;

                    CargarFicha();
                }
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al seleccionar el Tipo de producto\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally {
                oEnsamble = null;
            }
        }
        private void lstCarcasa_ItemCheckedChanged(object sender, ListViewItemEventArgs e)
        {
            try {
                gvResult.DataSource = null;

                if (e.Item.CheckState== Telerik.WinControls.Enumerations.ToggleState.Off) {
                    oList.RemoveAll(item => item.Id == int.Parse(e.Item.Value.ToString()) && item.Tipo == "CARCASA");
                } else {
                    ProductosCombinacion obj = new ProductosCombinacion();
                    obj.Id = int.Parse(e.Item.Value.ToString());
                    obj.Tipo = "CARCASA";
                    obj.Concepto = e.Item.Text;

                    oList.Add(obj);
                }

                gvResult.DataSource = oList;
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al seleccionar la carcasa\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void lstReflejantes_ItemCheckedChanged(object sender, ListViewItemEventArgs e)
        {
            try {
                gvResult.DataSource = null;

                if (e.Item.CheckState == Telerik.WinControls.Enumerations.ToggleState.Off) {
                    oList.RemoveAll(item => item.Id == int.Parse(e.Item.Value.ToString()) && item.Tipo == "REFLEJANTE");
                } else {
                    ProductosCombinacion obj = new ProductosCombinacion();
                    obj.Id = int.Parse(e.Item.Value.ToString());
                    obj.Tipo = "REFLEJANTE";
                    obj.Concepto = e.Item.Text;

                    oList.Add(obj);
                }

                gvResult.DataSource = oList;
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al seleccionar el reflejante\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void Decimal_KeyPress(object sender, KeyPressEventArgs e)
        {
            try {
                if (BaseWinBP.isDecimal(e.KeyChar))
                    e.Handled = true;
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error en la captura\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void txtPiezas_KeyPress(object sender, KeyPressEventArgs e)
        {
            try {
                if (!BaseWinBP.isNumero(e.KeyChar))
                    e.Handled = true;
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error en la captura\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }


        private void CargarEntidades()
        {
            oCatalogos = new WCF_Catalogos.Hersan_CatalogosClient();
            try {
                cboEntidad.ValueMember = "Id";
                cboEntidad.DisplayMember = "Nombre";
                cboEntidad.DataSource = oCatalogos.Entidades_Combo(BaseWinBP.UsuarioLogueado.Empresa.Id);
            } catch (Exception ex) {
                throw ex;
            } finally {
                oCatalogos = null;
            }
        }
        private void CargaColores()
        {
            oCatalogos = new WCF_Catalogos.Hersan_CatalogosClient();
            try {
                lstCarcasa.DisplayMember = "Nombre";
                lstCarcasa.ValueMember = "Id";
                lstCarcasa.DataSource = oCatalogos.ABC_Colores_Combo();
            } catch (Exception ex) {
                throw ex;
            } finally {
                oCatalogos = null;
            }
        }
        private void CargarReflejantes()
        {
            oCatalogos = new WCF_Catalogos.Hersan_CatalogosClient();
            try {
                lstReflejantes.DisplayMember = "Tipo";
                lstReflejantes.ValueMember = "Id";
                lstReflejantes.DataSource = oCatalogos.ENS_Reflejantes_Combo();
            } catch (Exception ex) {
                throw ex;
            } finally {
                oCatalogos = null;
            }
        }
        private void CargaAccesorios()
        {
            oCatalogos = new WCF_Catalogos.Hersan_CatalogosClient();
            try {
                lstAccesorios.DisplayMember = "Nombre";
                lstAccesorios.ValueMember = "Id";
                lstAccesorios.DataSource = oCatalogos.ENS_Accesorios_Combo();
            } catch (Exception ex) {
                throw ex;
            } finally {
                oCatalogos = null;
            }
        }
        private bool ValidarCampos()
        {
            bool Flag = true;
            try {
                Flag = cboFamilia.SelectedValue == null ? false : true;
                if (Flag) {
                    Flag = cboTipo.SelectedValue == null ? false : true;
                    if (Flag) {
                        Flag = int.Parse(txtCantidad.Value.ToString()) == 0 ? false : true;
                        if (Flag) {
                            Flag = gvResult.RowCount == 0 ? false : true;
                            if (Flag) {
                                Flag = lstAccesorios.CheckedItems.Count == 0 ? false : true;
                                if (Flag) {
                                    Flag = int.Parse(txtCantAcce.Value.ToString()) == 0 ? false : true;
                                    if (!Flag)
                                        return Flag;
                                } else
                                    return Flag;
                            } else
                                return Flag;
                        } else
                            return Flag;
                    } else
                        return Flag;
                } else
                    return Flag;

                return Flag;
            } catch (Exception ex) {
                throw ex;
            }
        }
        private void LimpiarCampos()
        {
            try {
                oList.Clear();
                txtId.Text = "0";

                cboEntidad.SelectedIndex = 0;
                cboTipo.DataSource = null;
                txtCodigo.Clear();
                txtAlto.Text = "0";
                txtAncho.Text = "0";
                txtCantAcce.Value = 0;
                txtCantidad.Value = 0;
                txtCircun.Text = "0";
                txtDiam.Text = "0";
                txtLargo.Text = "0";
                txtPeso.Text = "0";
                txtPiezas.Text = "0";
                txtRuta.Text = "";
                lstAccesorios.CheckedItems.Clear();
                lstCarcasa.CheckedItems.Clear();
                lstReflejantes.CheckedItems.Clear();
                gvResult.DataSource = null;
                picFoto.Image = null;
                
            } catch (Exception ex) {
                throw ex;
            }
        }
        private void CargarFicha()
        {
            oEnsamble = new WCF_Ensamble.Hersan_EnsambleClient();
            try {
                ProductoEnsambleBE obj = new ProductoEnsambleBE();
                //obj.Id = int.Parse(txtId.Text);
                obj.Entidad.Id = int.Parse(cboEntidad.SelectedValue.ToString());
                obj.Familia.Id = int.Parse(cboFamilia.SelectedValue.ToString());
                obj.Producto.Id = int.Parse(cboTipo.SelectedValue.ToString());                

                oProducto = oEnsamble.ENS_ProductosFicha_Obtener(obj);
                if(oProducto.Count > 0) {
                    /*SE LIMPIAN LOS ITEMS SELECCIONADOS */
                    lstCarcasa.CheckedItems.Clear();
                    lstAccesorios.CheckedItems.Clear();
                    lstReflejantes.CheckedItems.Clear();

                    txtId.Text = oProducto[0].Id.ToString();
                    txtCantidad.Value = oProducto[0].Reflejantes;
                    txtCantAcce.Value = oProducto[0].CantAccesorios;
                    txtAlto.Text = oProducto[0].Dimensiones.Alto.ToString();
                    txtAncho.Text = oProducto[0].Dimensiones.Ancho.ToString();
                    txtCircun.Text = oProducto[0].Dimensiones.Cirunferencia.ToString();
                    txtDiam.Text = oProducto[0].Dimensiones.Diametro.ToString();
                    txtLargo.Text = oProducto[0].Dimensiones.Largo.ToString();
                    txtPeso.Text = oProducto[0].Dimensiones.Peso.ToString();
                    txtPiezas.Text = oProducto[0].Dimensiones.Empaque.ToString();
                    txtRuta.Text = oProducto[0].Dimensiones.RutaImagen;
                    chkEstatus.Checked = oProducto[0].DatosUsuario.Estatus;

                    oProducto[0].Detalle.ForEach(aux => {
                        if (aux.Tipo == "CARCASA") {
                            foreach (var x in lstCarcasa.Items) {
                                if (x.Value.ToString() == aux.Id.ToString())
                                    x.CheckState = Telerik.WinControls.Enumerations.ToggleState.On;
                            }
                        } else {
                            if (aux.Tipo == "REFLEJANTE") {
                                foreach (var x in lstReflejantes.Items) {
                                    if (x.Value.ToString() == aux.Id.ToString())
                                        x.CheckState = Telerik.WinControls.Enumerations.ToggleState.On;
                                }
                            } else {
                                foreach (var x in lstAccesorios.Items) {
                                    if (x.Value.ToString() == aux.Id.ToString())
                                        x.CheckState = Telerik.WinControls.Enumerations.ToggleState.On;
                                }
                            }
                        }
                    });

                    if (oProducto[0].Foto != null) {
                        Imagen = oProducto[0].Foto;
                        picFoto.Image = ConvertImage.ByteToImage(Imagen);
                    } else {
                        picFoto.Image = null;
                    }
                } else {
                    oList.Clear();
                    txtId.Text = "0";

                    txtAlto.Text = "0";
                    txtAncho.Text = "0";
                    txtCantAcce.Value = 0;
                    txtCantidad.Value = 0;
                    txtCircun.Text = "0";
                    txtDiam.Text = "0";
                    txtLargo.Text = "0";
                    txtPeso.Text = "0";
                    txtPiezas.Text = "0";
                    txtRuta.Text = "";
                    lstAccesorios.CheckedItems.Clear();
                    lstCarcasa.CheckedItems.Clear();
                    lstReflejantes.CheckedItems.Clear();
                    gvResult.DataSource = null;
                    picFoto.Image = null;
                }
            } catch (Exception ex) {
                throw ex;
            } finally {
                oEnsamble = null;
            }
        }
        private DataSet CrearTablasAuxiliares()
        {
            DataSet oDataset = new DataSet();
            DataTable oData;

            try {
                #region TABLA DE ENCABEZADO
                oData = new DataTable("Ficha");
                oData.Columns.Add("Id");
                oData.Columns.Add("ENT_Id");
                oData.Columns.Add("FAM_Id");
                oData.Columns.Add("TPR_ID");
                oData.Columns.Add("PFI_Reflejantes");
                oData.Columns.Add("PFI_Accesorios");

                oDataset.Tables.Add(oData);
                #endregion

                #region TABLA DE DIMENSIONES
                oData = new DataTable("Dimensiones");
                oData.Columns.Add("PFI_Id");
                oData.Columns.Add("PFD_Alto");
                oData.Columns.Add("PFD_Largo");
                oData.Columns.Add("PFD_Ancho");
                oData.Columns.Add("PFD_Circunferencia");
                oData.Columns.Add("PFD_Diametro");
                oData.Columns.Add("PFD_Empaque");
                oData.Columns.Add("PFD_Peso");
                oData.Columns.Add("PFD_RutaImagen");

                oDataset.Tables.Add(oData);
                #endregion

                CargarTablas(ref oDataset);

            } catch (Exception ex) {
                throw ex;
            }
            return oDataset;
        }
        private void CargarTablas(ref DataSet oData)
        {
            try {                
                #region CARGA DATOS ENCABEZADO
                DataRow oRow = oData.Tables["Ficha"].NewRow();
                oRow["Id"] = int.Parse(txtId.Text);
                oRow["ENT_Id"] = int.Parse(cboEntidad.SelectedValue.ToString());
                oRow["FAM_Id"] = int.Parse(cboFamilia.SelectedValue.ToString());
                oRow["TPR_ID"] = int.Parse(cboTipo.SelectedValue.ToString());
                oRow["PFI_Reflejantes"] = int.Parse(txtCantidad.Value.ToString());
                oRow["PFI_Accesorios"] = int.Parse(txtCantAcce.Value.ToString());

                oData.Tables["Ficha"].Rows.Add(oRow);
                #endregion

                #region CARGA DIMENSIONES
                oRow = oData.Tables["Dimensiones"].NewRow();
                oRow["PFI_Id"] = int.Parse(txtId.Text);
                oRow["PFD_Alto"] = txtAlto.Text;
                oRow["PFD_Largo"] = txtLargo.Text;
                oRow["PFD_Ancho"] = txtAncho.Text;
                oRow["PFD_Circunferencia"] = txtCircun.Text;
                oRow["PFD_Diametro"] = txtDiam.Text;
                oRow["PFD_Empaque"] = txtPiezas.Text;
                oRow["PFD_Peso"] = txtPeso.Text;
                //oRow["PFD_RutaImagen"] = txtRuta.Text;

                oData.Tables["Dimensiones"].Rows.Add(oRow);

                #endregion

                #region Colores
                Colores = string.Empty;
                foreach (var item in lstCarcasa.Items) {
                    if (item.CheckState == Telerik.WinControls.Enumerations.ToggleState.On) {
                        Colores += item.Value.ToString() + ",";
                    }
                }
                #endregion

                #region Reflejantes
                Reflejantes = string.Empty;
                foreach (var item in lstReflejantes.Items) {
                    if (item.CheckState == Telerik.WinControls.Enumerations.ToggleState.On) {
                        Reflejantes += item.Value.ToString() + ",";
                    }
                }
                #endregion

                #region Accesorios
                Accesorios = string.Empty;
                foreach (var item in lstAccesorios.Items) {
                    if (item.CheckState == Telerik.WinControls.Enumerations.ToggleState.On) {
                        Accesorios += item.Value.ToString() + ",";
                    }
                }
                #endregion


            } catch (Exception ex) {
                throw ex;
            }
        }

    }
}
