using Hersan.Datos.Ensamble;
using Hersan.Entidades.Catalogos;
using Hersan.Entidades.Ensamble;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;

namespace Hersan.Negocio.Ensamble
{
    public class ProductosBP
    {
        private string RutaImagen = @ConfigurationManager.AppSettings["RutaImagen"];

        private void GuardarImagen(int IdProducto, Byte[] Imagen)
        {
            BinaryWriter Writer = null;
            string DominioRed = "";
            string UsuarioRed = "cuidado"; string PasswordRed = "Cloud.2018";
            string Name = RutaImagen + IdProducto.ToString() + ".jpg";
            try {

                //string[] userPass = new FacturacionDA().obtenerUserPassFTP();
                ////array de una dimension solo contiene mensaje de error
                //if (userPass.Length == 1) {
                //    result = userPass[0];
                //    return result;
                //}

                ///Desencriptamos usuario y password
                //UsuarioRed = DataEncryptor.Decrypt(userPass[0]);
                //PasswordRed = DataEncryptor.Decrypt(userPass[1]);

                Impersonar.Impersonate(DominioRed, UsuarioRed, PasswordRed);

                // Create a new stream to write to the file
                Writer = new BinaryWriter(File.OpenWrite(Name));

                // Writer raw data                
                Writer.Write(Imagen);
                Writer.Flush();
                Writer.Close();

            } catch (Exception ex) {
                throw new Exception("Error al intentar guardar el archivo.", ex);
            } finally {
                //Imper.Undo();
            }
        }
        private Byte[] ObtenerImagen(int IdProducto)
        {
            byte[] Foto;
            string Imagen = RutaImagen + IdProducto.ToString() + ".jpg"; ;
            try {
                string DominioRed = "";
                string UsuarioRed = "cuidado"; string PasswordRed = "Cloud.2018";

                Impersonar.Impersonate(DominioRed, UsuarioRed, PasswordRed);
                Foto = ConvertImage.FileToByteArray(Imagen);

            } catch (Exception ex) {
                throw new Exception("Error al intentar guardar el archivo.", ex);
            }
            return Foto;
        }

        public int ENS_ProductosFicha_Guardar(System.Data.DataSet Tablas, string Colores, string Reflejantes, string Accesorios, int IdUsuario)
        {
            return new ProductosDA().ENS_ProductosFicha_Guardar(Tablas, Colores, Reflejantes, Accesorios, IdUsuario);
        }
        public int ENS_ProductosFicha_Actualizar(DataSet Tablas, string Colores, string Reflejantes, string Accesorios, int IdUsuario, bool Estatus)
        {
            return new ProductosDA().ENS_ProductosFicha_Actualizar(Tablas, Colores, Reflejantes, Accesorios, IdUsuario, Estatus);
        }
        public List<ProductoEnsambleBE> ENS_ProductosFicha_Obtener(ProductoEnsambleBE obj)
        {
            return new ProductosDA().ENS_ProductosFicha_Obtener(obj);
        }
        public List<ProductoEnsambleBE> ENS_ProductosCotizacion_Combo(bool Nacional, string Moneda)
        {
            return new ProductosDA().ENS_ProductosCotizacion_Combo(Nacional, Moneda);
        }
        public List<ColoresBE> ENS_CarcasasCotizacion_Combo(int IdFicha)
        {
            return new ProductosDA().ENS_CarcasasCotizacion_Combo(IdFicha);
        }
        public List<ReflejantesBE> ENS_ReflejanteCotizacion_Combo(int IdFicha)
        {
            return new ProductosDA().ENS_ReflejanteCotizacion_Combo(IdFicha);
        }
    }
}
