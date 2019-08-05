using Hersan.Entidades.Seguridad;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Hersan.Negocio
{
    public class BaseWinBP
    {
        public const string Sistema = "Hersan";
        //public const string RegRFC = @"/^[a-zA-Z]{3,4}(\d{6})((\D|\d){2,3})?$/";
        public const string RegRFC = @"^([A - Z\s]{4})\d{6}([A - Z\w]{3})$";
        public const string RegCURP = @" /[a-zA-Z]{4,4}[0-9]{6}[a-zA-Z]{6,6}[0-9]{2}/";

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
                if (_listadoMenu == null) {
                    _listadoMenu = new List<MenusBE>();
                }
                return _listadoMenu;
            }
            set {
                _listadoMenu = value;
            }
        }

        public static bool EnviarMail(string emisor, string destinatario, string asunto, string CuerpoMsg, string smtp, string user, string pwd, int port)
        {
            try {

                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient(smtp);
                mail.From = new MailAddress(emisor);
                mail.To.Add(destinatario);
                mail.Subject = asunto;
                mail.Body = CuerpoMsg;
                mail.IsBodyHtml = true;
                SmtpServer.Port = port;
                SmtpServer.Credentials = new System.Net.NetworkCredential(user, pwd);
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);
                return true;
            } catch {
                return false;
            }

        }

        public static bool EnviarMail(string emisor, string destinatario, string asunto, string CuerpoMsg, string smtp, string pwd, int port)
        {
            bool Flag = false;
            try {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient(smtp);
                mail.From = new MailAddress(emisor);
                mail.To.Add(destinatario);
                mail.Subject = asunto;
                mail.Body = CuerpoMsg;
                mail.IsBodyHtml = true;
                SmtpServer.Port = port;
                SmtpServer.Credentials = new System.Net.NetworkCredential(emisor, pwd);
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);
                Flag = true;
            } catch (Exception ex) {
                Flag = false;
                throw ex;
            }
            return Flag;
        }

        public static bool EnviarMail(string emisor, string destinatario, string asunto, string CuerpoMsg, string smtp, string pwd, int port, bool ssl)
        {
            bool Flag = false;
            try {

                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient(smtp);
                mail.From = new MailAddress(emisor);
                mail.To.Add(destinatario);
                mail.Subject = asunto;
                mail.Body = CuerpoMsg;
                mail.IsBodyHtml = true;
                SmtpServer.Port = port;
                SmtpServer.Credentials = new System.Net.NetworkCredential(emisor, pwd);
                SmtpServer.EnableSsl = ssl;
                SmtpServer.Send(mail);
                Flag = true;
            } catch (Exception ex) {
                Flag = false;
                throw ex;
            }
            return Flag;
        }

        public static bool EnviarMail(string emisor, string destinatario, string asunto, string CuerpoMsg, string smtp, string pwd, int port, Stream adjunto, string NombreAdjunto, bool ssl)
        {
            try {
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
            } catch {
                return false;
            }
        }

        public static bool EnviarMail(string emisor, string destinatario, string Copia, string asunto, string CuerpoMsg, string smtp, string pwd, int port, Stream adjunto, string NombreAdjunto, bool ssl)
        {
            try {
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
            } catch {
                return false;
            }
        }

        public static bool EnviarMail(string emisor, string destinatario, string Copia, string Bcc, string asunto, string CuerpoMsg, string smtp, string pwd, int port, Stream adjunto, string NombreAdjunto, bool ssl)
        {
            try {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient(smtp);
                mail.Attachments.Add(new Attachment(adjunto, NombreAdjunto));
                mail.From = new MailAddress(emisor);
                mail.To.Add(destinatario);
                if (Copia != "") mail.CC.Add(Copia);
                if (Bcc != "")  mail.Bcc.Add(Bcc);
                mail.Subject = asunto;
                mail.Body = CuerpoMsg;
                SmtpServer.Port = port;
                SmtpServer.Credentials = new System.Net.NetworkCredential(emisor, pwd);
                SmtpServer.EnableSsl = ssl;
                SmtpServer.Send(mail);

                return true;
            } catch {
                return false;
            }
        }

        public static bool isNumero(Char c)
        {
            bool num = false;
            try {
                if ((c >= '0' && c <= '9') || c == 8) {
                    num = true;
                }
            } catch {
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
            try {
                System.Globalization.CultureInfo cc = System.Threading.Thread.CurrentThread.CurrentCulture;
                if (char.IsNumber(c) || c == 8 || c.ToString() == cc.NumberFormat.NumberDecimalSeparator || c.ToString() == cc.NumberFormat.NegativeSign)
                    num = false;
                else
                    num = true;
            } catch {
                num = false;
            }
            return num;
        }

        public static bool isRegularExpresion(string Cadena, string ExpReg)
        {
            bool flag = false;
            try {
                if (Regex.IsMatch(Cadena, ExpReg)) {
                    flag = true;
                } else
                    flag = false;

            } catch {
                flag = false;
            }
            return flag;
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
            try {
                br.Read(bytes, 0, bytes.Length);
                // base64 es la cadena en donde se guarda el arreglo de bytes ya convertido
                sBase64 = Convert.ToBase64String(bytes);
                return sBase64;
            } catch {
                return null;
            } finally {
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
            try {
                bytes = Convert.FromBase64String(Archivo);
                bw.Write(bytes);
                return sImagenTemporal;
            } catch {
                return null;
            } finally {
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
            using (Aes encryptor = Aes.Create()) {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream()) {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write)) {
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
            using (Aes encryptor = Aes.Create()) {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream()) {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write)) {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }
    }

    public class ConvertImage
    {

        public static byte[] FileToByteArray(string _FileName)
        {
            byte[] _Buffer = null;

            try {
                // Open file for reading
                FileStream _FileStream = new System.IO.FileStream(_FileName, System.IO.FileMode.Open, System.IO.FileAccess.Read);

                //attach filestream to binary reader
                BinaryReader _BinaryReader = new System.IO.BinaryReader(_FileStream);

                //get total byte length of the file
                long _TotalBytes = new System.IO.FileInfo(_FileName).Length;

                //read entire file into buffer
                _Buffer = _BinaryReader.ReadBytes((int)_TotalBytes);

                //close file reader
                _FileStream.Close();
                _FileStream.Dispose();
                _BinaryReader.Close();

            } catch (Exception ex) {
                throw ex;
            }

            return _Buffer;
        }

        public static string ByteArrayToFile(string _FileName, byte[] _ByteArray)
        {
            try {
                string tmpFile = _FileName;
                //  Open file for reading
                System.IO.FileStream _FileStream = new System.IO.FileStream(tmpFile, System.IO.FileMode.Create, System.IO.FileAccess.Write);
                //  Writes a block of bytes to this stream using data from a byte array.
                _FileStream.Write(_ByteArray, 0, _ByteArray.Length);
                //  close file stream

                _FileStream.Close();
                return tmpFile;
            } catch (Exception _Exception) {
                //  Error
                // WriteErrorLogFile("ErrorLogFIleDS", "Error General", "Archivo: " & _FileName & "Error: " & _Exception.Message, "")
                throw _Exception;
                // Console.WriteLine("Exception caught in process: {0}", _Exception.ToString())
            }

        }

        public static Bitmap ByteToImage(byte[] blob)
        {
            MemoryStream mStream = new MemoryStream();
            byte[] pData = blob;
            mStream.Write(pData, 0, Convert.ToInt32(pData.Length));
            Bitmap bm = new Bitmap(mStream, false);
            mStream.Dispose();
            return bm;

        }

        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }

    }
}