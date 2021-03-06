﻿using System;
using System.Linq;
using System.Windows.Forms;
using Telerik.WinControls.Themes;

namespace EstructuraOrganizacional
{
    static class Program
    {
        public static string themeName = "";
        public static string exampleName = "";
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //we need this to load the needed references from other directory (for the standalone QSF)
            AppDomain.CurrentDomain.AssemblyResolve += MyResolveEventHandler;

            if (args.Length >= 1)
                Program.themeName = args[0];
            if (args.Length >= 2)
                Program.exampleName = args[1];


            //LoadThemes();
            //Form form;
            //if (Program.exampleName != "OrgChart")
            //{
            //    form = Activator.CreateInstance(System.Reflection.Assembly.GetExecutingAssembly().GetType("DiagramFirstLook.Form1")) as Form;
            //}
            //else
            //{
            //    form = Activator.CreateInstance(System.Reflection.Assembly.GetExecutingAssembly().GetType("DiagramOrganizationChart.OrgChartForm")) as Form;
            //}
            ////Load the themes so the form can start with the QSF theme


            //run the manually created instance. This is needed as otherwise the static types of the assemblies will be needed prior we get here
            Application.Run(new OrgChartForm());
        }

        private static System.Reflection.Assembly MyResolveEventHandler(object sender, ResolveEventArgs args)
        {
            string strTempAssmbPath = "";
            string neededAssembly = args.Name.Substring(0, args.Name.IndexOf(",")) + ".dll";
            System.Reflection.Assembly objExecutingAssemblies = System.Reflection.Assembly.GetExecutingAssembly();

            foreach (System.Reflection.AssemblyName strAssmbName in objExecutingAssemblies.GetReferencedAssemblies()) {
                string currentAssembly = strAssmbName.FullName.Substring(0, strAssmbName.FullName.IndexOf(",")) + ".dll";

                if (currentAssembly == neededAssembly) {
                    strTempAssmbPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), args.Name.Substring(0, args.Name.IndexOf(",")) + ".dll");

                    if (!System.IO.File.Exists(strTempAssmbPath)) // we are in the case of QSF as exe, so the Path is different
                    {
                        strTempAssmbPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "..\\..\\..\\..\\bin\\ReleaseTrial\\");
                        strTempAssmbPath = System.IO.Path.Combine(strTempAssmbPath, neededAssembly);
                    }
                    break;
                }
            }

            System.Reflection.Assembly myAssembly = null;

            if (!string.IsNullOrEmpty(strTempAssmbPath)) {
                myAssembly = System.Reflection.Assembly.LoadFrom(strTempAssmbPath);
            }
            return myAssembly;
        }

        private static void LoadThemes()
        {
            
        }
    }

    public class OrgChart
    {
    }
}
