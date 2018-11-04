using Hersan.Negocio.Demo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Hersan.Web.API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [RoutePrefix("Padre")]
    public class PadreController : ApiController
    {
        #region Campos y propiedades
        private readonly IPadreBP _Negocio;
        #endregion

        ///// <summary>
        ///// 
        ///// </summary>
        //public UsuariosController()
        //{

        //}

        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        /// <param name="parametroServicio"></param>
        public PadreController(IPadreBP parametroServicio)
        {
            _Negocio = parametroServicio;
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        //[Authorize]
        [Route("Obtiene_Familia")]
        [HttpGet]
        public async Task<HttpResponseMessage> UsuariosObtiene()
        {
            var result = await _Negocio.Usuarios_Obtiene();
            if (result != null) {
                return Request.CreateResponse(HttpStatusCode.OK, result);
            } else {
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
        }
    }
}
