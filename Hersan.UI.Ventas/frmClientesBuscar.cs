using Hersan.Entidades.Ensamble;
using Hersan.Negocio;
using System;
using System.Windows.Forms;
using Telerik.WinControls;

namespace Hersan.UI.Ensamble
{
    public partial class frmClientesBuscar : Telerik.WinControls.UI.RadForm
    {
        WCF_Ensamble.Hersan_EnsambleClient oVentas;
        public int Id { get; set; }

        public frmClientesBuscar()
        {
            InitializeComponent();
        }
        private void frmClientesBuscar_Load(object sender, EventArgs e)
        {
            try {
                cboTipo.SelectedIndex = 0;
                cboEstatus.SelectedIndex = 0;
                
                CargaEntidades();
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al cargar la pantalla\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            oVentas = new WCF_Ensamble.Hersan_EnsambleClient();
            try {
                ClientesBE obj = new ClientesBE();
                obj.Id = int.Parse(txtClave.Text);
                obj.DatosUsuario.FechaCreacion = dtFecha.Checked ? dtFecha.Value : DateTime.Parse("01/01/1900");
                obj.RFC = txtRFC.Text;
                obj.Nombre = txtNombre.Text;

                obj.Ciudad = cboTipo.SelectedItem.Tag.ToString();
                obj.Estado = cboEstatus.SelectedItem.Tag.ToString();

                //var Ent = new ClientesEntidadesBE();
                //Ent.Entidad.Id = int.Parse(cboTipo.SelectedItem.Tag.ToString()));
                //Ent.IdCliente = int.Parse(cboEstatus.SelectedItem.Tag.ToString());
                //obj.Entidades.Add(Ent);
                
                string Entidades = string.Empty;
                foreach (var item in lstEntidades.Items) {
                    if (item.CheckState == Telerik.WinControls.Enumerations.ToggleState.On) {
                        Entidades += item.Value.ToString() + ",";
                    }
                }
                gvDatos.DataSource = oVentas.ABC_Clientes_Buscar(obj, Entidades);
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al cargar los datos\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void btnSelect_Click(object sender, EventArgs e)
        {
            try {
                if (gvDatos.RowCount > 0)
                    /* SE ABRE DESDE LA PANTALLA DE ALTA DE CLIENTES */
                    Id = int.Parse(gvDatos.CurrentRow.Cells["Id"].Value.ToString());
                else
                    Id = 0;

                this.Close();
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al seleccionar el cliente\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
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

        private void CargaEntidades()
        {
            WCF_Catalogos.Hersan_CatalogosClient oCatalogos = new WCF_Catalogos.Hersan_CatalogosClient();
            try {
                lstEntidades.ValueMember = "Id";
                lstEntidades.DisplayMember = "Nombre";
                lstEntidades.DataSource = oCatalogos.Entidades_Combo(BaseWinBP.UsuarioLogueado.Empresa.Id);
            } catch (Exception ex) {
                throw ex;
            } finally {
                oCatalogos = null;
            }
        }
    }
}
