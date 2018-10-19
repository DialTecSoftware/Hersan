using Hersan.Entidades.Seguridad;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Hersan.Negocio
{
    public class BaseWinBP
    {
        public const string Sistema = "Hersan";

        /// <summary>
        /// Procesos que están en la Base de Datos
        /// </summary>
        public enum Procesos
        {
            Diseño,
            Modelista,
            Producción,
            Implementación,
            Ventas,
            Administración,
            Coordinador,
            Proveedor,
            Maquila,
            Calidad,
            Almacen,
            Etiquetas
        }

        /// <summary>
        /// Variable global para el manejo de los datos del usuario autenticado
        /// </summary>
        private static UsuariosBE _usuarioLogueado;
        public static UsuariosBE UsuarioLogueado {
            get {
                return _usuarioLogueado;
            }
            set {
                _usuarioLogueado = value;
            }
        }

        private static List<MenusBE> _listadoMenu;
        public static List<MenusBE> ListadoMenu {
            get {
                if (_listadoMenu == null)
                {
                    _listadoMenu = new List<MenusBE>();
                }
                return _listadoMenu;
            }
            set {
                _listadoMenu = value;
            }
        }

        public static bool EnviarMail(string emisor, string destinatario, string asunto, string CuerpoMsg, string smtp, string pwd, int port)
        {
            try
            {

                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient(smtp);
                mail.From = new MailAddress(emisor);
                mail.To.Add(destinatario);
                mail.Subject = asunto;
                mail.Body = CuerpoMsg;
                SmtpServer.Port = port;
                SmtpServer.Credentials = new System.Net.NetworkCredential(emisor, pwd);
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);
                return true;
            }
            catch
            {
                return false;
            }

        }

        public static bool EnviarMail(string emisor, string destinatario, string asunto, string CuerpoMsg, string smtp, string pwd, int port, bool ssl)
        {
            bool Flag = false;
            try
            {

                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient(smtp);
                mail.From = new MailAddress(emisor);
                mail.To.Add(destinatario);
                mail.Subject = asunto;
                mail.Body = CuerpoMsg;
                SmtpServer.Port = port;
                SmtpServer.Credentials = new System.Net.NetworkCredential(emisor, pwd);
                SmtpServer.EnableSsl = ssl;
                SmtpServer.Send(mail);
                Flag = true;
            }
            catch (Exception ex)
            {
                Flag = false;
                throw ex;
            }
            return Flag;
        }

        public static bool EnviarMail(string emisor, string destinatario, string asunto, string CuerpoMsg, string smtp, string pwd, int port, Stream adjunto, string NombreAdjunto, bool ssl)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient(smtp);
                mail.Attachments.Add(new Attachment(adjunto, NombreAdjunto));
                mail.From = new MailAddress(emisor);
                mail.To.Add(destinatario);
                mail.Subject = asunto;
                mail.Body = CuerpoMsg;
                SmtpServer.Port = port;
                SmtpServer.Credentials = new System.Net.NetworkCredential(emisor, pwd);
                SmtpServer.EnableSsl = ssl;
                SmtpServer.Send(mail);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool EnviarMail(string emisor, string destinatario, string Copia, string asunto, string CuerpoMsg, string smtp, string pwd, int port, Stream adjunto, string NombreAdjunto, bool ssl)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient(smtp);
                mail.Attachments.Add(new Attachment(adjunto, NombreAdjunto));
                mail.From = new MailAddress(emisor);
                mail.To.Add(destinatario);
                if (Copia != "")
                    mail.Bcc.Add(Copia);
                mail.Subject = asunto;
                mail.Body = CuerpoMsg;
                SmtpServer.Port = port;
                SmtpServer.Credentials = new System.Net.NetworkCredential(emisor, pwd);
                SmtpServer.EnableSsl = ssl;
                SmtpServer.Send(mail);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool isNumero(Char c)
        {
            bool num = false;
            try
            {
                if ((c >= '0' && c <= '9') || c == 8)
                {
                    num = true;
                }
            }
            catch
            {
                num = false;
            }
            return num;
        }

        public static void AbrirArchivoExcel(string file)
        {
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.FileName = "EXCEL.EXE";
            startInfo.Arguments = file;
            System.Diagnostics.Process.Start(startInfo);
        }

        public static bool isDecimal(Char c)
        {
            bool num = false;
            try
            {
                System.Globalization.CultureInfo cc = System.Threading.Thread.CurrentThread.CurrentCulture;
                if (char.IsNumber(c) || c == 8 || c.ToString() == cc.NumberFormat.NumberDecimalSeparator || c.ToString() == cc.NumberFormat.NegativeSign)
                    num = false;
                else
                    num = true;
            }
            catch
            {
                num = false;
            }
            return num;
        }

        /// <summary>
        /// Codifica un archivo en String Base64
        /// </summary>
        /// <param name="Archivo">Ruta y nombre de archivo a codificar</param>
        public static string CodificarArchivo(string Archivo)
        {
            string sBase64 = "";
            // Declaramos fs para tener acceso al archivo residente en la maquina cliente.
            FileStream fs = new FileStream(Archivo, FileMode.Open);
            // Declaramos un Leector Binario para accesar a los datos del archivo pasarlos a un arreglo de bytes
            BinaryReader br = new BinaryReader(fs);
            byte[] bytes = new byte[(int)fs.Length];
            try
            {
                br.Read(bytes, 0, bytes.Length);
                // base64 es la cadena en donde se guarda el arreglo de bytes ya convertido
                sBase64 = Convert.ToBase64String(bytes);
                return sBase64;
            }
            catch
            {
                return null;
            }
            finally
            {
                // Se cierran los archivos para liberar memoria.
                fs.Close();
                fs = null;
                br = null;
                bytes = null;
            }
        }

        /// <summary>
        /// Decodifica un String de Archivo Base64        
        /// </summary>
        /// <param name="Archivo">String con el archivo a decodificar</param>
        /// <param name="Nombre">Nombre y extensión de archivo que será creado</param>
        public static string DecodificarArchivo(string Archivo, string Nombre)
        {
            // Declaramos fs para poder crear un nuevo archivo temporal en la maquina cliente.
            // y memStream para almacenar en memoria la cadena recibida.
            string sImagenTemporal = @"C:\Documentos\" + Nombre;  //Nombre del archivo y su extension
            if (!Directory.Exists(@"C:\Documentos\"))
                Directory.CreateDirectory(@"C:\Documentos\");

            FileStream fs = new FileStream(sImagenTemporal, FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);
            byte[] bytes;
            try
            {
                bytes = Convert.FromBase64String(Archivo);
                bw.Write(bytes);
                return sImagenTemporal;
            }
            catch
            {
                return null;
            }
            finally
            {
                fs.Close();
                bytes = null;
                bw = null;
                Archivo = null;
            }
        }

        public static void AbrirArchivo(string Ruta)
        {
            System.Diagnostics.Process.Start(Ruta);
        }
    }

    //Clase para encriptar, usada en facturacion al guardar archivos en servidor
    public static class DataEncryptor
    {
        public static string Encrypt(string clearText)
        {
            string EncryptionKey = "DialTec_";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }
        public static string Decrypt(string cipherText)
        {
            string EncryptionKey = "DialTec_";
            cipherText = cipherText.Replace(" ", "+");
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }
    }

}
