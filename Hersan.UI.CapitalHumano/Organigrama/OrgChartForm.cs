using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;
using Telerik.WinControls;
using Telerik.WinControls.UI;


namespace Hersan.UI.CapitalHumano
{
    public partial class OrgChartForm : Telerik.WinControls.UI.RadForm
    {
        #region Variables
        CapitalHumano.WCF_Catalogos.Hersan_CatalogosClient oCatalogo;        
        public readonly RadToggleButtonElement toggleCollapseButton;
        private const int LastLevel = 3;
        private Telerik.Windows.Diagrams.Core.Point topPoint = new Telerik.Windows.Diagrams.Core.Point(200, 200);
        internal static Telerik.Windows.Diagrams.Core.TreeLayoutSettings currentLayoutSettings;
        private Color[] groupColor = new Color[] { Color.FromArgb(49, 49, 49), Color.FromArgb(47, 153, 69), Color.FromArgb(36, 159, 217), Color.FromArgb(49, 189, 117) };
        public string Nombre;
        public string Nom;
        #endregion

        protected override void OnLoad(EventArgs e)
        {
            OrgContainerShape sh = new OrgContainerShape();
            base.OnLoad(e);

            this.InitializeDiagram();

        }
        private void OrgChartForm_Load(object sender, EventArgs e)
        {
            OrgContainerShape sh = new OrgContainerShape();
            sh.ToggleCollapseButton.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;

        }
        private void btnColapse_Click(object sender, EventArgs e)
        {
            try {
                Application.Restart();
                OrgContainerShape sh = new OrgContainerShape();

                sh.Colapsar();

            } catch (Exception) {

                throw;
            }

        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            try {
                this.Close();

            } catch (Exception ex) {
                RadMessageBox.Show("Ocurió un error al cerrar la pantalla" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);

            }
        }
        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            try {
                base.OnLoad(e);

                this.InitializeDiagram();
            } catch (Exception) {

                throw;
            }

        }
        private void orgTeam_IsCollapsedChanged(object sender, Telerik.WinControls.UI.Diagrams.RoutedEventArgs e)
        {
            this.radDiagram1.SetLayout(Telerik.Windows.Diagrams.Core.LayoutType.Tree, currentLayoutSettings);
        }
        private OrgContainerShape CreateNode(XElement element, OrgContainerShape parentNode)
        {
            OrgContainerShape orgTeam = new OrgContainerShape() {
                Name = Nom = element.Attribute("Depto").Value,

            };

            orgTeam.ToggleCollapseButton.ImagePrimitive.Visibility = Telerik.WinControls.ElementVisibility.Hidden;

            orgTeam.Text = orgTeam.Name;
            orgTeam.Tag = Nombre = element.Attribute("Name").Value;
            orgTeam.Path = parentNode == null ? orgTeam.Name : string.Format("{0}|{1}", parentNode.Path, orgTeam.Name);
            currentLayoutSettings.Roots.Add(orgTeam);
            if (parentNode != null) {
                RadDiagramConnection connection = new RadDiagramConnection();
                connection.ConnectionType = Telerik.Windows.Diagrams.Core.ConnectionType.Polyline;
                connection.Source = parentNode;
                connection.Target = orgTeam;

                this.radDiagram1.AddConnection(connection);

            }

            var teamMembers = this.GetTeamMembers(element, orgTeam);
            var position = new Telerik.Windows.Diagrams.Core.Point(10, 50);

            int memberCount = 0;
            foreach (var member in teamMembers) {
                this.radDiagram1.AddShape(member);
                orgTeam.Items.Add(member);
                member.Position = position;
                position.X += member.Width + 20;
                if (++memberCount % 2 == 0) {
                    position = new Telerik.Windows.Diagrams.Core.Point(10, position.Y + member.Height + 10);
                }
            }

            orgTeam.IsCollapsedChanged += this.orgTeam_IsCollapsedChanged;
            return orgTeam;
        }
        private ObservableCollection<RadDiagramShape> GetTeamMembers(XContainer element, OrgContainerShape team)
        {
            //XElement data = XElement.Load(@"C:\Temp\Hersan.xml");
            XElement data = XElement.Load(Directory.GetCurrentDirectory() + "\\Hersan.xml");

            var members = new ObservableCollection<RadDiagramShape>();
            foreach (var xmlNodeMember in data.Elements("Element")) {
                RadDiagramShape member = this.CreateMemberShape(team, Nombre);
                members.Add(member);
            }

            return members;
        }
        private RadDiagramShape CreateMemberShape(OrgContainerShape team, string xmlNodeMember)
        {
            RadDiagramShape member = new RadDiagramShape();
            member.IsConnectorsManipulationEnabled = false;
            member.ForeColor = Color.White;
            member.IsRotationEnabled = false;
            member.IsResizingEnabled = false;
            member.Shape = new Telerik.WinControls.RoundRectShape(0);
            member.BackColor = Color.LightBlue;
            member.Width = 190;
            member.Height = 50;
            member.Tag = team;
            //member.Name = xmlNodeMember.ToString();
            member.DiagramShapeElement.TextAlignment = ContentAlignment.MiddleLeft;
            member.DiagramShapeElement.ImageLayout = ImageLayout.None;
            member.DiagramShapeElement.Padding = new System.Windows.Forms.Padding(5, 2, 2, 0);
            //member.DiagramShapeElement.Image = this.GetImageFromResource(member.Name);
            member.DiagramShapeElement.ImageAlignment = ContentAlignment.MiddleLeft;
            member.DiagramShapeElement.TextImageRelation = TextImageRelation.ImageBeforeText;
            member.DiagramShapeElement.TextWrap = false;
            member.Text = string.Format(" {0}\n {1}", member.Name, xmlNodeMember.ToString());
            return member;
        }

        private void PopulateWithData()
        {
            XElement dataXml = XElement.Load(Directory.GetCurrentDirectory() + "\\Hersan.xml");
            IEnumerable<XElement> employees = dataXml.Elements();

            foreach (XElement element in dataXml.Elements("Element")  ) {
                OrgContainerShape node = this.CreateNode(element, null);
                node.BaseColor = Color.IndianRed;
                this.radDiagram1.AddShape(node);
                currentLayoutSettings.Roots.Add(node);
                this.GetSubNodes(element, node, 2);
                node.IsCollapsed = true;
            }
        }
        public OrgChartForm()
        {
            this.InitializeComponent();
        }
        private void CargaDocumento()
        {
            oCatalogo = new WCF_Catalogos.Hersan_CatalogosClient();
            try {
                Byte[] Archivo = oCatalogo.CHU_OrganigramaXML_Obtener(0);
                if (Archivo != null) {
                    System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
                    string xml = System.Text.Encoding.UTF8.GetString(Archivo);
                    doc.LoadXml(xml);
                    doc.Save(Directory.GetCurrentDirectory() + "\\Hersan.xml");
                }
            } catch (Exception ex) {
                RadMessageBox.Show("Ocurrió un error al cargar los datos del organigrama:\n" + ex.Message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void InitializeDiagram()
        {
            CargaDocumento();
            OrgContainerShape org = new OrgContainerShape();
            this.WindowState = FormWindowState.Maximized;

            this.ApplyThemeRecursively(this.Controls);
            this.radDiagram1.BackColor = System.Drawing.Color.White;
            this.radDiagram1.ForeColor = System.Drawing.Color.Black;
            this.radDiagram1.IsInformationAdornerVisible = false;
            this.radDiagram1.ActiveTool = Telerik.Windows.Diagrams.Core.MouseTool.PanTool;
            this.radDiagram1.IsSnapToGridEnabled = false;
            this.radDiagram1.IsSnapToItemsEnabled = false;
            this.radDiagram1.RouteConnections = false;
            this.radDiagram1.RoutingService.Router = new Telerik.Windows.Diagrams.Core.OrgTreeRouter() { TreeLayoutType = Telerik.Windows.Diagrams.Core.TreeLayoutType.TreeDown };
            this.radDiagram1.RoutingService.AutoUpdate = true;
            this.radDiagram1.RouteConnections = true;
            this.radDiagram1.BackgroundGrid.Visibility = Telerik.WinControls.ElementVisibility.Hidden;
            this.radDiagram1.BackgroundPageGrid.Visibility = Telerik.WinControls.ElementVisibility.Hidden;
            this.radDiagram1.IsSettingsPaneEnabled = false;
            currentLayoutSettings = new Telerik.Windows.Diagrams.Core.TreeLayoutSettings() {
                HorizontalSeparation = 80d,
                VerticalSeparation = 60d,
                UnderneathVerticalTopOffset = 50d,
                UnderneathHorizontalOffset = 130d,
                UnderneathVerticalSeparation = 40d,
                VerticalDistance = 10d,
            };

            this.PopulateWithData();


            this.radDiagram1.Zoom = 0.8;
            this.radDiagram1.DiagramElement.HorizontalScrollbar.Value = 250;
            this.radDiagram1.DiagramElement.VerticalScrollbar.Value = 100;
            this.radDiagram1.SetLayout(Telerik.Windows.Diagrams.Core.LayoutType.Tree, currentLayoutSettings);



        }
        void ApplyThemeRecursively(Control.ControlCollection controls)
        {
            foreach (Control control in controls) {
                RadControl radControl = control as RadControl;
                if (radControl != null) {
                    radControl.ThemeName = this.ThemeName;
                }

                this.ApplyThemeRecursively(control.Controls);
            }
        }
        private ObservableCollection<OrgContainerShape> GetSubNodes(XContainer element, OrgContainerShape parent, int level)
        {
            var nodes = new ObservableCollection<OrgContainerShape>();
            List<XElement> elements = new List<XElement>(element.Elements("Element"));
            if (elements.Count == 0) {
                return nodes;
            }


            foreach (var subElement in elements) {
                OrgContainerShape node = this.CreateNode(subElement, parent);
                node.ShowCollapseButton = level < 4;
                if (node.Path.ToString()!="") {
                    node.BaseColor = Color.IndianRed;
                }
               

                this.radDiagram1.AddShape(node);

                this.GetSubNodes(subElement, node, level + 1);
                nodes.Add(node);
                node.IsCollapsed = true;
            }

            return nodes;
        }

    }
}
