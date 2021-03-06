﻿using Hersan.Entidades.Seguridad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hersan.Datos.Seguridad
{
    public class MenusDA : BaseDA
    {
        #region Constantes
        const string CONST_USP_USUARIOS_OBTIENEMENUUSUARIO = "SEG_Usuarios_ObtieneMenuUsuario";        
        const string CONST_USP_MENUROL_OBTIENE = "SEG_MenuRol_Obtiene";
        const string CONST_USP_MENUROL_ELIMINA = "SEG_MenuRol_Elimina";
        const string CONST_USP_MENUROL_GUARDA = "SEG_MenuRol_Guarda";
        const string CONST_USP_MENUS_OBTIENE = "SEG_Menus_Obtiene";
        const string CONST_USP_MENUSPADRE_COMBO = "SEG_MenuPadre_Combo";
        const string CONST_USP_MENUSGUARDAR = "SEG_MenusGuardar";
        #endregion

        /// <summary>
        /// Obtiene el menu asignado al usuario
        /// </summary>
        /// <returns></returns>
        public List<MenusBE> ObtenerMenuUsuario(string Usuario)
        {
            try
            {
                List<MenusBE> oList = new List<MenusBE>();
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL")))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_USP_USUARIOS_OBTIENEMENUUSUARIO, conn))
                    {
                        cmd.Parameters.AddWithValue("@Usuario", Usuario);

                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                MenusBE obj = new MenusBE();
                                obj.ID = int.Parse(reader["MEN_IdMenu"].ToString());
                                obj.Menu = reader["MEN_Menu"].ToString();
                                obj.Descripcion = reader["MEN_Descripcion"].ToString();
                                obj.RutaIcono = reader["MEN_UrlIcono"].ToString();
                                obj.IDPadre = int.Parse(reader["MEN_IdPadre"].ToString());
                                obj.UrlMenu = reader["MEN_UrlMenu"].ToString();
                                obj.NombreForma = reader["MEN_NombreForm"].ToString();
                                obj.Orden = int.Parse(reader["MEN_Orden"].ToString());
                                obj.AssemblyDll = reader["MEN_Assembly"].ToString();
                                obj.AssemblyNamespace = reader["MEN_Namespace"].ToString();
                                obj.Activo = bool.Parse(reader["MEN_Estatus"].ToString());
                                //obj.PuedeAgregar = bool.Parse(reader["MNR_Agregar"].ToString());
                                //obj.PuedeEditar = bool.Parse(reader["MNR_Editar"].ToString());
                                //obj.PuedeEliminar = bool.Parse(reader["MNR_Eliminar"].ToString());

                                oList.Add(obj);
                            }
                        }
                    }
                }
                return oList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Obtiene el menu por rol
        /// </summary>
        /// <returns></returns>
        public List<MenusBE> ObtenerMenuRol(int Rol, int Padre, int Menu)
        {
            try
            {
                List<MenusBE> oList = new List<MenusBE>();
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL")))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_USP_MENUROL_OBTIENE, conn))
                    {                        
                        cmd.Parameters.AddWithValue("@IdRol", Rol);
                        cmd.Parameters.AddWithValue("@IdPadre", Padre);
                        cmd.Parameters.AddWithValue("@IdMenu", Menu);                        

                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                MenusBE obj = new MenusBE();
                                obj.ID = int.Parse(reader["MEN_IdMenu"].ToString());
                                obj.Menu = reader["MEN_Menu"].ToString();
                                obj.Auxiliar = obj.Menu;
                                obj.Descripcion = reader["MEN_Descripcion"].ToString();
                                obj.IDPadre = int.Parse(reader["MEN_IdPadre"].ToString());
                                obj.Orden = int.Parse(reader["MEN_Orden"].ToString());                                
                                obj.PuedeAgregar = bool.Parse(reader["Agregar"].ToString());
                                obj.PuedeEditar = bool.Parse(reader["Editar"].ToString());
                                obj.PuedeEliminar = bool.Parse(reader["Eliminar"].ToString());
                                obj.Asignado = bool.Parse(reader["Asignado"].ToString());

                                oList.Add(obj);
                            }
                        }
                    }
                }
                return oList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Guarda la asinagción de permisos en el menu al rol seleccionado
        /// </summary>
        /// <param name="lstMnu">listado de menus</param>
        /// <param name="Rol">Rol a asignar</param>
        /// <param name="Menu">Aplicacion del menu</param>
        public int GuardaMenuRol(DataTable oTabla)
        {
            int Result = 0;
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_USP_MENUROL_GUARDA, conn)) {
                        cmd.Parameters.AddWithValue("@Tabla", oTabla);

                        cmd.CommandType = CommandType.StoredProcedure;
                        Result = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
                return Result;
            } catch (Exception ex) {
                throw ex;
            }
        }

        //public List<ProcesosMenuBE> ObtenerProcesosMenu(int Rol, int Aplicacion)
        //{
        //    try
        //    {
        //        List<ProcesosMenuBE> oList = new List<ProcesosMenuBE>();
        //        using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL")))
        //        {
        //            conn.Open();
        //            using (SqlCommand cmd = new SqlCommand(CONST_USP_PROCESOS_OBTIENE, conn))
        //            {
        //                int param = 0;
        //                cmd.Parameters.Add(new SqlParameter("@IdAplicacion", SqlDbType.Int));
        //                cmd.Parameters.Add(new SqlParameter("@IdRol", SqlDbType.Int));
        //                cmd.Parameters[param++].Value = Aplicacion;
        //                cmd.Parameters[param++].Value = Rol;

        //                cmd.CommandType = CommandType.StoredProcedure;

        //                using (SqlDataReader reader = cmd.ExecuteReader())
        //                {
        //                    while (reader.Read())
        //                    {
        //                        ProcesosMenuBE obj = new ProcesosMenuBE();
        //                        obj.ID = int.Parse(reader["ID"].ToString());
        //                        obj.Proceso = reader["Proceso"].ToString();

        //                        //obj.IDAsignado = int.Parse(reader["ProcesoAsignado"].ToString());
        //                        //obj.IdMenu = int.Parse(reader["MNR_IdMenu"].ToString());
        //                        oList.Add(obj);
        //                    }
        //                }
        //            }
        //        }
        //        return oList;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        /// <summary>
        /// Elimina Aplicacion del Rol
        /// </summary>
        /// <param name="lstMnu">listado de menus</param>
        /// <param name="Rol">Rol a asignar</param>
        /// <param name="Aplicacion">Aplicacion del menu</param>
        public int EliminaMenuRol(int Rol, int Menu)
        {
            int Result = 0;
            try{
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL")))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_USP_MENUROL_ELIMINA, conn))
                    {
                        cmd.Parameters.AddWithValue("@IdRol", Rol);
                        cmd.Parameters.AddWithValue("@Menu", Menu);
                        cmd.CommandType = CommandType.StoredProcedure;

                        Result = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Result;
        }

        public List<MenusBE> ObtenerMenus()
        {
            try {
                List<MenusBE> oList = new List<MenusBE>();
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_USP_MENUS_OBTIENE, conn)) {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                MenusBE obj = new MenusBE();
                                obj.ID = int.Parse(reader["MEN_IdMenu"].ToString());
                                obj.Menu = reader["MEN_Menu"].ToString();
                                obj.Auxiliar = reader["Padre"].ToString();
                                obj.Descripcion = reader["MEN_Descripcion"].ToString();
                                obj.IDPadre = int.Parse(reader["MEN_IdPadre"].ToString());
                                obj.Orden = int.Parse(reader["MEN_Orden"].ToString());

                                oList.Add(obj);
                            }
                        }
                    }
                }
                return oList;
            } catch (Exception ex) {
                throw ex;
            }
        }

        public List<MenusBE> MenusPadre_Combo()
        {
            try {
                List<MenusBE> oList = new List<MenusBE>();
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_USP_MENUSPADRE_COMBO, conn)) {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                MenusBE obj = new MenusBE();
                                obj.ID = int.Parse(reader["MEN_IdMenu"].ToString());
                                obj.Menu = reader["MEN_Menu"].ToString();
                                obj.Orden = int.Parse(reader["MEN_Orden"].ToString());

                                oList.Add(obj);
                            }
                        }
                    }
                }
                return oList;
            } catch (Exception ex) {
                throw ex;
            }
        }

        public int Menu_Guardar(MenusBE obj)
        {
            int Result = 0;
            try {
                using (SqlConnection conn = new SqlConnection(RecuperarCadenaDeConexion("coneccionSQL"))) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(CONST_USP_MENUSGUARDAR, conn)) {
                        cmd.Parameters.AddWithValue("@Menu", obj.Menu);
                        cmd.Parameters.AddWithValue("@Descrip", obj.Descripcion);
                        cmd.Parameters.AddWithValue("@IdPadre", obj.IDPadre);
                        cmd.Parameters.AddWithValue("@Orden", obj.Orden);
                        cmd.Parameters.AddWithValue("@Form", obj.NombreForma);
                        cmd.Parameters.AddWithValue("@Ensamblado", obj.AssemblyDll);
                        cmd.Parameters.AddWithValue("@NameSpace", obj.AssemblyNamespace);

                        cmd.CommandType = CommandType.StoredProcedure;
                        Result = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
                return Result;
            } catch (Exception ex) {
                throw ex;
            }
        }
    }
}
