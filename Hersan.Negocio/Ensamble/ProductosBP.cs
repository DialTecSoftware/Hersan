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
            string Name = RutaImagen + IdProducto.ToString() + ".jpg";
            try {

                Writer = new BinaryWriter(File.OpenWrite(Name));

                Writer.Write(Imagen);
                Writer.Flush();
                Writer.Close();

            } catch (Exception ex) {
                throw new Exception("Error al intentar guardar el archivo.", ex);
            }
        }
        private Byte[] ObtenerImagen(int IdProducto)
        {
            byte[] Foto;
            string Imagen = RutaImagen + IdProducto.ToString() + ".jpg"; ;
            try {
                if (File.Exists(Imagen)) {
                    Foto = ConvertImage.FileToByteArray(Imagen);
                } else {
                    Foto = null;
                }
            } catch (Exception ex) {
                throw new Exception("Error al intentar obtener el archivo.", ex);
            }
            return Foto;
        }

        public int ENS_ProductosFicha_Guardar(System.Data.DataSet Tablas, byte[] Imagen, string Colores, string Reflejantes, string Accesorios, int IdUsuario)
        {
            try {
                Tablas.Tables["Dimensiones"].Rows[0]["PFD_RutaImagen"] = RutaImagen;
                int IdProducto = new ProductosDA().ENS_ProductosFicha_Guardar(Tablas, Colores, Reflejantes, Accesorios, IdUsuario);
                
                if (IdProducto > 0 && Imagen != null) {
                    GuardarImagen(IdProducto, Imagen);
                }
                return IdProducto;
            } catch (Exception ex) {
                throw ex;
            }            
        }
        public int ENS_ProductosFicha_Actualizar(DataSet Tablas, byte[] Imagen, string Colores, string Reflejantes, string Accesorios, int IdUsuario, bool Estatus)
        {
            Tablas.Tables["Dimensiones"].Rows[0]["PFD_RutaImagen"] = RutaImagen;

            int IdProducto = new ProductosDA().ENS_ProductosFicha_Actualizar(Tablas, Colores, Reflejantes, Accesorios, IdUsuario, Estatus);

            if (IdProducto > 0 && Imagen != null) {
                GuardarImagen(IdProducto, Imagen);
            }

            return IdProducto;
        }
        public List<ProductoEnsambleBE> ENS_ProductosFicha_Obtener(ProductoEnsambleBE obj)
        {
            try {
                List<ProductoEnsambleBE> oList = new ProductosDA().ENS_ProductosFicha_Obtener(obj);
                oList.ForEach(item => {
                    if (item.Dimensiones.RutaImagen.Trim().Length > 0)
                        item.Foto = ObtenerImagen(item.Id);
                });

                return oList;
            } catch (Exception ex) {
                throw ex;
            }
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
