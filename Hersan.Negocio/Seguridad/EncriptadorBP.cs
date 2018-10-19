using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hersan.Negocio.Seguridad
{
    public class EncriptadorBP
    {
        /// <summary>
        /// Encripta el dato enviado
        /// </summary>
        /// <param name="Texto">Texto a encriptar</param>
        /// <returns>Texto encriptado</returns>
        public string EncriptarTexto(string Texto)
        {
            return new EncriptadorDA().EncriptarTexto(Texto);
        }

        /// <summary>
        /// Desencripta el texto encriptado
        /// </summary>
        /// <param name="TextoEncriptado">Texto Encriptado</param>
        /// <returns>Texto Desencriptado</returns>
        public string DesencriptarTexto(string TextoEncriptado)
        {
            return new EncriptadorDA().DesencriptarTexto(TextoEncriptado);
        }
    }
}
