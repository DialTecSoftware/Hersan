using Hersan.Entidades.Seguridad;
using Hersan.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls;

namespace Hersan.UI.Principal
{
    public partial class Principal : Telerik.WinControls.UI.RadForm
    {
        public Principal()
        {
            InitializeComponent();
            try {
                /* Llamada a pantalla de Logueo */
                Form frm = new Hersan.UI.Seguridad.frmLogin();
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK) {                    
                    cargaMenuPrincipal();                    
                } else {
                    this.Close();
                }                
            }
            catch (Exception ex){
                throw ex;
            }
        }
        private void cargaMenuPrincipal()
        {
            lblUsuario.Text = "Usuario: " + BaseWinBP.UsuarioLogueado.Nombre.Replace('.', ' ');
            lblPerfil.Text = "Perfil: " + BaseWinBP.UsuarioLogueado.Rol.Nombre;            
            
            ToolStripMenuItem menu, submenu, item;
            //Filtramos todos los menu principales y lo recorremos
            var temp = BaseWinBP.ListadoMenu.FindAll(delegate(MenusBE p){
                return p.IDPadre == 0;
            });

            foreach (MenusBE mnu in temp) {
                //Filtramos todos los grupos de menu o submenu y lo recorremos
                var tempBar = BaseWinBP.ListadoMenu.FindAll(delegate(MenusBE p)
                {
                    return p.IDPadre.Equals(mnu.ID);
                });

                //Menu Principal
                menu = new ToolStripMenuItem();
                menu.Text = mnu.Menu;
                menu.Tag = mnu.ID.ToString();
                foreach (MenusBE mnuBar in tempBar) {
                    //Filtramos las opciones para cada grupo y las recorremos
                    var tempBoton = BaseWinBP.ListadoMenu.FindAll(delegate(MenusBE p)
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
                    var temp = BaseWinBP.ListadoMenu.FirstOrDefault(p => p.ID.ToString().Equals(id));

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
    }
}
