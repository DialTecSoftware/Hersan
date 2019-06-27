using Hersan.Entidades.Inyeccion;
using Hersan.Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Telerik.WinControls;

namespace Hersan.UI.Calidad
{
    public partial class frmInyeccion : Telerik.WinControls.UI.RadForm
    {
        WCF_Catalogos.Hersan_CatalogosClient oCatalogos;
        WCF_Ensamble.Hersan_EnsambleClient oEnsamble;
        
        List<InyeccionDetalleBE> oList = new List<InyeccionDetalleBE>();

        public frmInyeccion()
        {
            InitializeComponent();
        }
        private void frmInyeccion_Load(object sender, EventArgs e)
        {
            try {
                Colores();
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al cargar la pantalla\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            oEnsamble = new WCF_Ensamble.Hersan_EnsambleClient();
            try {
                if (txtOP.Text.Trim().Length > 0 && cboColores.SelectedValue != null) {

                    if (RadMessageBox.Show("Desea guardar los cambios...?", this.Text, MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.Yes) {

                        InyeccionBE Obj = new InyeccionBE();
                        Obj.OP = txtOP.Text;
                        Obj.Color.Nombre = cboColores.SelectedValue.ToString();
                        Obj.IdUsuario = BaseWinBP.UsuarioLogueado.ID;

                        int Result = oEnsamble.PRO_Inyeccion_Guardar(Obj, CrearTablasAuxiliares());
                        if (Result == 0) {
                            RadMessageBox.Show("Ocurrió un error al guardar la informacion", this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
                        } else {
                            RadMessageBox.Show("Información guardada correctamente", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                            CargaGrid();
                        }
                    }
                } else {
                    RadMessageBox.Show("Debe capturar la OP y Seleccionar el color para continuar", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                }
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al guardar los datos\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
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
        private void txtOP_Leave(object sender, EventArgs e)
        {
            try {
                CargaGrid();
            } catch (Exception ex) {
                throw ex;
            }
        }
        private void txtOP_KeyPress(object sender, KeyPressEventArgs e)
        {
            try {
                if (!BaseWinBP.isNumero(e.KeyChar)) {
                    e.Handled = true;
                }
            } catch (Exception ex) {
                throw ex;
            }
        }
        private void cboColores_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try {
                CargaGrid();
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al cargar los datos\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }


        private void Colores()
        {
            oCatalogos = new WCF_Catalogos.Hersan_CatalogosClient();
            try {
                cboColores.DisplayMember = "Nombre";
                cboColores.ValueMember = "Nombre";
                cboColores.DataSource = oCatalogos.ABC_Colores_Combo();
            } catch (Exception ex) {
                throw ex;
            }
        }
        private void CargaGrid()
        {
            oEnsamble = new WCF_Ensamble.Hersan_EnsambleClient();
            try {
                gvDatos.DataSource = null;

                InyeccionBE Obj = new InyeccionBE();
                Obj.OP = txtOP.Text;
                Obj.Color.Nombre = cboColores.SelectedValue.ToString();
                oList = oEnsamble.PRO_Inyeccion_Obtener(Obj);

                gvDatos.DataSource = oList;

            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al cargar los datos\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            } finally {
                oEnsamble = null;
            }
        }
        private DataTable CrearTablasAuxiliares()
        {
            DataTable oData;

            try {
                oData = new DataTable("Detalle");
                oData.Columns.Add("IdInyeccion");
                oData.Columns.Add("Fecha");
                oData.Columns.Add("Lista");
                oData.Columns.Add("Turno");
                oData.Columns.Add("Piezas");
                oData.Columns.Add("Virgen");
                oData.Columns.Add("Remolido");
                oData.Columns.Add("Master");
                oData.Columns.Add("Inicio");
                oData.Columns.Add("Fin");
                oData.Columns.Add("CAV1");
                oData.Columns.Add("CAV2");
                oData.Columns.Add("CAV3");
                oData.Columns.Add("CAV4");
                oData.Columns.Add("CAV5");
                oData.Columns.Add("CAV6");
                oData.Columns.Add("CAV7");
                oData.Columns.Add("CAV8");
                
                CargarTablas(ref oData);

            } catch (Exception ex) {
                throw ex;
            }
            return oData;
        }
        private void CargarTablas(ref DataTable oData)
        {
            try {
                foreach (var item in oList) {
                    DataRow oRow = oData.NewRow();
                    oRow["IdInyeccion"] = item.Id;
                    oRow["Fecha"] = item.Fecha.Year.ToString()+ item.Fecha.Month.ToString().PadLeft(2,'0') + item.Fecha.Day.ToString().PadLeft(2,'0');
                    oRow["Lista"] = item.Lista;
                    oRow["Turno"] = item.Turno;
                    oRow["Piezas"] = item.Piezas;
                    oRow["Virgen"] = item.Virgen;
                    oRow["Remolido"] = item.Remolido;
                    oRow["Master"] = item.Master;
                    oRow["Inicio"] = item.Inicio;
                    oRow["Fin"] = item.Fin;
                    oRow["CAV1"] = item.Cav1;
                    oRow["CAV2"] = item.Cav2;
                    oRow["CAV3"] = item.Cav3;
                    oRow["CAV4"] = item.Cav4;
                    oRow["CAV5"] = item.Cav5;
                    oRow["CAV6"] = item.Cav6;
                    oRow["CAV7"] = item.Cav7;
                    oRow["CAV8"] = item.Cav8;

                    oData.Rows.Add(oRow);
                }

            } catch (Exception ex) {
                throw ex;
            }
        }

    }
}
