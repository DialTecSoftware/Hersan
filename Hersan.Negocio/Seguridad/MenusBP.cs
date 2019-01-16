using Hersan.Datos.Seguridad;
using Hersan.Entidades.Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hersan.Negocio.Seguridad
{
    public class MenusBP
    {
        /// <summary>
        /// Obtiene el menu asignado al usuario
        /// </summary>
        /// <returns></returns>
        public List<Entidades.Seguridad.MenusBE> ObtenerMenuUsuario(string Usuario, int Empresa)
        {
            return new MenusDA().ObtenerMenuUsuario(Usuario, Empresa);
        }

        /// <summary>
        /// Obtiene el menu por rol
        /// </summary>
        /// <returns></returns>
        public List<MenusBE> ObtenerMenuRol(int Rol,  int Padre, int Menu)
        {
            return new MenusDA().ObtenerMenuRol(Rol, Padre, Menu);
        }

        ///// <summary>
        ///// Guarda la asinagción de permisos en el menu al rol seleccionado
        ///// </summary>
        ///// <param name="lstMnu">listado de menus</param>
        ///// <param name="Rol">Rol a asignar</param>
        ///// <param name="Aplicacion">Aplicacion del menu</param>
        //public int GuardaMenuRol(List<MenusBE> lstMnu, int Rol, int Menu)
        //{
        //    return new MenusDA().GuardaMenuRol(lstMnu, Rol, Menu);
        //}

        /// <summary>
        /// Obtiene el listado de procesos por menu
        /// </summary>
        /// <returns></returns>
        //public List<ProcesosMenuBE> ObtenerProcesosMenu(int Rol, int Aplicacion)
        //{
        //    return new MenusDA().ObtenerProcesosMenu(Rol, Aplicacion);
        //}


        /// <summary>
        /// Actualizar Menu_Rol Seleccionado
        /// </summary>
        /// <returns></returns>
        public int GuardaMenuRol(System.Data.DataTable oTabla)
        {
            return new MenusDA().GuardaMenuRol(oTabla);

            //int IdMenu = 0;
            //int IdPadre = 0;
            //int IdPrimog = 0;
            //int oItemID = 0;
            //bool oItemActivo = false;
            //List<MenusBE> oList = new List<MenusBE>();
            //List<MenusBE> oListH = new List<MenusBE>();
            //List<MenusBE> oListTEMPH = new List<MenusBE>();
            //try
            //{
            //    foreach (MenusBE oItem in lstMnu)
            //    {
            //        //Actualiza el Registro Seleccionado
            //        oItemID = oItem.ID;
            //        oItemActivo = oItem.Activo;

            //        oList = new MenusDA().ObtenerMenuRol(Rol, oItem.ID, 0);

            //        IdMenu = oItem.ID;
            //        if (oItemActivo == true) { 
            //            new MenusDA().GuardaMenuRol(lstMnu, Rol, Menu);
            //        } else {                     
            //            new MenusDA().EliminaMenuRol(Rol, IdMenu);
            //        }

            //        //Si oItem.Activo = true (Seleccionado) , selecciona los Padres
            //        if (oItemActivo == true)
            //        {
            //            IdPadre = 0;
            //            oListH = new MenusDA().ObtenerMenuRol(Rol, 0, oItem.IDPadre);
            //            if (oListH.Count > 0 && oItem.IDPadre > 0)
            //            {
            //                foreach (MenusBE oItemP in oListH)
            //                {
            //                    IdPadre = oItemP.IDPadre;
            //                    IdPrimog = oItemP.ID;
            //                    oListTEMPH = new List<MenusBE>();
            //                    MenusBE objTempP = new MenusBE();
            //                    objTempP.ID = oItemP.ID;
            //                    objTempP.IDPadre = oItemP.IDPadre;
            //                    objTempP.Menu = oItemP.Menu;
            //                    objTempP.PuedeAgregar = false;
            //                    objTempP.PuedeEditar = false;
            //                    objTempP.PuedeEliminar = false;
            //                    oListTEMPH.Add(objTempP);
            //                    new MenusDA().GuardaMenuRol(oListTEMPH, Rol, Menu);
            //                }
            //                oListH = new MenusDA().ObtenerMenuRol(Rol, 0, IdPadre);
            //                if (oListH.Count > 0 && IdPadre > 0)
            //                {
            //                    foreach (MenusBE oItemP in oListH)
            //                    {
            //                        oListTEMPH = new List<MenusBE>();
            //                        MenusBE objTempP = new MenusBE();
            //                        objTempP.ID = oItemP.ID;
            //                        objTempP.IDPadre = oItemP.IDPadre;
            //                        objTempP.Menu = oItemP.Menu;
            //                        objTempP.PuedeAgregar = false;
            //                        objTempP.PuedeEditar = false;
            //                        objTempP.PuedeEliminar = false;
            //                        //objTempP.proceso = new ProcesosMenuBE();
            //                        //objTempP.proceso.ID = oItem.proceso.ID;
            //                        oListTEMPH.Add(objTempP);
            //                        new MenusDA().GuardaMenuRol(oListTEMPH, Rol, Menu);
            //                        break;
            //                    }
            //                }
            //            }

            //        }
            //        // Fin de actualizacion de Lo Padres

            //        //Actualiza los dependientes en descendente

            //        foreach (MenusBE oItemT in oList)
            //        {
            //            if (oList.Count > 0)
            //            {
            //                oListH = new MenusDA().ObtenerMenuRol(Rol, oItemT.ID, 0);
            //                IdMenu = oItemT.ID;
            //                if (oItemActivo == true)
            //                {
            //                    oListTEMPH = new List<MenusBE>();
            //                    MenusBE objTempH = new MenusBE();
            //                    objTempH.ID = oItemT.ID;
            //                    objTempH.IDPadre = oItemT.IDPadre;
            //                    objTempH.Menu = oItemT.Menu;
            //                    objTempH.PuedeAgregar = oItem.PuedeAgregar;
            //                    objTempH.PuedeEditar = oItem.PuedeEditar;
            //                    objTempH.PuedeEliminar = oItem.PuedeEliminar;
            //                    //objTempH.proceso = new ProcesosMenuBE();
            //                    //objTempH.proceso.ID = oItem.proceso.ID;
            //                    oListTEMPH.Add(objTempH);
            //                    new MenusDA().GuardaMenuRol(oListTEMPH, Rol, Menu);
            //                }
            //                else
            //                {
            //                    new MenusDA().EliminaMenuRol(Rol, IdMenu);
            //                }

            //                foreach (MenusBE oItemH in oListH)
            //                {
            //                    if (oListH.Count > 0)
            //                    {
            //                        IdMenu = oItemH.ID;
            //                        if (oItemActivo == true)
            //                        {
            //                            oListTEMPH = new List<MenusBE>();
            //                            MenusBE objTempH = new MenusBE();
            //                            objTempH.ID = oItemH.ID;
            //                            objTempH.IDPadre = oItemH.IDPadre;
            //                            objTempH.Menu = oItemH.Menu;
            //                            objTempH.PuedeAgregar = oItem.PuedeAgregar;
            //                            objTempH.PuedeEditar = oItem.PuedeEditar;
            //                            objTempH.PuedeEliminar = oItem.PuedeEliminar;
            //                            //objTempH.proceso = new ProcesosMenuBE();
            //                            //objTempH.proceso.ID = oItem.proceso.ID;
            //                            oListTEMPH.Add(objTempH);
            //                            new MenusDA().GuardaMenuRol(oListTEMPH, Rol, Menu);
            //                        }
            //                        else
            //                        {
            //                            new MenusDA().EliminaMenuRol(Rol, IdMenu);
            //                        }
            //                    }
            //                }
            //            }


            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}

        }

        public List<MenusBE> ObtenerMenus()
        {
            return new MenusDA().ObtenerMenus();
        }

        public List<MenusBE> MenusPadre_Combo()
        {
            return new MenusDA().MenusPadre_Combo();
        }

        public int Menu_Guardar(MenusBE obj)
        {
            return new MenusDA().Menu_Guardar(obj);
        }
    }
}
