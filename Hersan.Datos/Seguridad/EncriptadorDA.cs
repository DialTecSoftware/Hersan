using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Hersan.Datos.Seguridad
{
    public class EncriptadorDA
    {
        RSACryptoServiceProvider rsa;
        const string CONTAINER_NAME = "ContenedorRSA";

        public EncriptadorDA()
        {
            try
            {
                CspParameters cspParams;
                cspParams = new CspParameters(1);   // PROV_RSA_FULL  
                //cspParams.Flags = CspProviderFlags.UseMachineKeyStore;
                cspParams.Flags = CspProviderFlags.UseDefaultKeyContainer;
                cspParams.KeyContainerName = CONTAINER_NAME;
                // Instanciar el algoritmo de cifrado RSA  
                rsa = new RSACryptoServiceProvider(1024, cspParams);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Encripta el dato enviado
        /// </summary>
        /// <param name="Texto">Texto a encriptar</param>
        /// <returns>Texto encriptado</returns>
        public string EncriptarTexto(string Texto)
        {
            try
            {
                if (!Texto.Trim().Equals(string.Empty))
                {
                    // Cargar y asociar la llave pública al proveedor de cifrado  
                    StreamReader reader = new StreamReader(System.AppDomain.CurrentDomain.BaseDirectory + "llave_publica.xml");
                    string publicOnlyKeyXML = reader.ReadToEnd();
                    rsa.FromXmlString(publicOnlyKeyXML);
                    reader.Close();

                    // Convertir el texto a cifrar (plano) a su representación en bytse  
                    byte[] textoPlanoBytes = System.Text.Encoding.UTF8.GetBytes(Texto);
                    // Realizar el proceso de cifrado  
                    byte[] textoCifradoBytes = rsa.Encrypt(textoPlanoBytes, false);
                    // Convertir el mensaje cifrado a su representación en cadena  
                    return Convert.ToBase64String(textoCifradoBytes);
                }
                else
                {
                    return string.Empty;
                }
            }
            catch
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Desencripta el texto encriptado
        /// </summary>
        /// <param name="TextoEncriptado">Texto Encriptado</param>
        /// <returns>Texto Desencriptado</returns>
        public string DesencriptarTexto(string TextoEncriptado)
        {
            try
            {
                if (!TextoEncriptado.Trim().Equals(string.Empty))
                {
                    // Cargar y asociar la llave privada (y pública) al proveedor de cifrado  
                    StreamReader reader = new StreamReader(System.AppDomain.CurrentDomain.BaseDirectory + "llave_privada.xml");
                    string publicPrivateKeyXML = reader.ReadToEnd();
                    rsa.FromXmlString(publicPrivateKeyXML);
                    reader.Close();

                    // Convertir el texto cifrado a su representación en bytse  
                    byte[] textoCifradoBytes = Convert.FromBase64String(TextoEncriptado);
                    // Realizar el proceso de descifrado  
                    byte[] textoPlanoBytes = rsa.Decrypt(textoCifradoBytes, false);
                    // Convertir el mensaje descifrado a su representación en cadena  
                    return System.Text.Encoding.UTF8.GetString(textoPlanoBytes);
                }
                else
                {
                    return string.Empty;
                }
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}
