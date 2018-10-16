using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SIAC.Entidades.Seguridad;
using SIAC.UI.Base;
using Telerik.WinControls;

namespace Hersan.UI.Principal
{
    public partial class Principal : Telerik.WinControls.UI.RadForm
    {
        public Principal(bool isTrial)
        {
            InitializeComponent();

            try {
                /* Llamada a pantalla de Logueo */
                Form frm = new SIAC.UI.Seguridad.frmLogin(isTrial);
                frm.ShowDialog();

                if (frm.DialogResult == DialogResult.OK) {
                    /* Llamanda a pantalla de Periodos */
                    Form aux = new SIAC.UI.Tools.frmPeriodo();
                    aux.ShowDialog();
                    if (aux.DialogResult == DialogResult.OK)
                        cargaMenuPrincipal();
                    else
                        this.Close();
                } else {
                    this.Close();
                }
            } catch (Exception ex){
                throw ex;
            }
        }
        private void cargaMenuPrincipal()
        {
            lblUsuario.Text = "Usuario: " + BaseWin.UsuarioLogueado.nombreCompleto.Replace('.', ' ');
            lblPerfil.Text = "Perfil: " + BaseWin.UsuarioLogueado.Rol.Nombre;
            lblPeriodo.Text = "Periodo de Trabajo: " + BaseWin.Periodo.Mes.ToString() + " - " + BaseWin.Periodo.Anio.ToString();
            
            ToolStripMenuItem menu, submenu, item;
            //Filtramos todos los menu principales y lo recorremos
            var temp = BaseWin.ListadoMenu.FindAll(delegate(MenusBE p){
                return p.IDPadre == 0;
            });

            foreach (MenusBE mnu in temp) {
                //Filtramos todos los grupos de menu o submenu y lo recorremos
                var tempBar = BaseWin.ListadoMenu.FindAll(delegate(MenusBE p)
                {
                    return p.IDPadre.Equals(mnu.ID);
                });

                //Menu Principal
                menu = new ToolStripMenuItem();
                menu.Text = mnu.Menu;
                menu.Tag = mnu.ID.ToString();
                foreach (MenusBE mnuBar in tempBar) {
                    //Filtramos las opciones para cada grupo y las recorremos
                    var tempBoton = BaseWin.ListadoMenu.FindAll(delegate(MenusBE p)
                    {
                        return p.IDPadre.Equals(mnuBar.ID);
                    });

                    //SubMenu
                    submenu = new ToolStripMenuItem();
                    if (tempBoton != null && tempBoton.Count > 0) {
                        submenu.Text = mnuBar.Menu;
                        submenu.Tag = mnuBar.ID.ToString();

                        //Item                        
                        foreach (MenusBE mnuBoton in tempBoton) {
                            item = new ToolStripMenuItem();
                            item.Text = mnuBoton.Menu;
                            item.Tag = mnuBoton.ID.ToString();
                            submenu.DropDownItems.Add(item);

                            item.Click += new System.EventHandler(menu_Click);
                        }
                        menu.DropDownItems.Add(submenu);
                    } else {
                        submenu.Text = mnuBar.Menu;
                        submenu.Tag = mnuBar.ID.ToString();
                        menu.DropDownItems.Add(submenu);

                        submenu.Click += new System.EventHandler(menu_Click);
                    }
                }
                //Por cada menu padre generamos un Menu 
                mnMenu.Items.Add(menu);
            }
        }            
        private void menu_Click(object sender, EventArgs e)
        {
            try {
                string id = ((ToolStripMenuItem)sender).Tag.ToString();

                if (id != "0") {
                    var temp = BaseWin.ListadoMenu.FirstOrDefault(p => p.ID.ToString().Equals(id));

                    if (temp != null) {
                        if (!EstaAbiertoFormulario(temp.NombreForma)) {
                            if (!temp.AssemblyDll.Equals(string.Empty) && !temp.AssemblyNamespace.Equals(string.Empty)) {
                                System.Reflection.Assembly testAssembly = System.Reflection.Assembly.LoadFile(Application.StartupPath + @"\" + temp.AssemblyDll);
                                Type obj = testAssembly.GetType(temp.AssemblyNamespace);
                                object calcInstance = Activator.CreateInstance(obj);

                                if (temp.NombreForma != "frmLogin") {
                                    Form frm = ((Form)calcInstance);
                                    frm.MdiParent = this;
                                    frm.Name = temp.NombreForma;
                                    frm.WindowState = FormWindowState.Maximized;
                                    frm.Tag = temp.ID.ToString();
                                    frm.Show();
                                } else {
                                    if (Application.OpenForms.Count > 1) {
                                        if (Telerik.WinControls.RadMessageBox.Show("Hay pantalla abiertas, desea continuar...?", this.Text, MessageBoxButtons.YesNo, Telerik.WinControls.RadMessageIcon.Question) == System.Windows.Forms.DialogResult.Yes) {
                                            Application.Restart();
                                        }
                                    }else
                                        Application.Restart();
                                }
                            }
                        }
                    }
                } else {
                    this.Dispose(true);
                }
            } catch (Exception ex) {
                throw ex;
            }
        }
        private bool EstaAbiertoFormulario(string str)
        {
            bool isOpen = false;
            foreach (Form frm in this.MdiChildren) {
                if (frm.Name == str) {
                    frm.Activate();
                    frm.WindowState = FormWindowState.Maximized;
                    isOpen = true;
                    break;
                }
            }

            return isOpen;
        }
        private void ValidaRegistro()
        {
            try {
                /* Se obtiene el Valor de registro */
                Tools.Registro obj = new Tools.Registro();
                /* Validar que el registro sea correcto */
                if (BaseWin.ValidaRegistro() != obj.ObtenerRegistro() && BaseWin.ValidaRegistro() != string.Empty) {
                    RadMessageBox.Show("El registro no es correcto, reporte al administrador", this.Text, MessageBoxButtons.YesNo, RadMessageIcon.Question);
                    this.Close();
                }
            } catch (Exception ex) {                
                throw ex;
            }
        }
    }
}
