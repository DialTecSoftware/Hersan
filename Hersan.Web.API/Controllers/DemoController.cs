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
    ///[Authorize]
    /// <summary>
    /// 
    /// </summary>
    [RoutePrefix("Demo")]
    public class DemoController : ApiController
    {
        #region Campos y propiedades
        private readonly IDemoBP _Negocio;
        #endregion

        /// <summary>
        /// 
        /// </summary>

        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        /// <param name="parametroServicio"></param>
        public DemoController(IDemoBP parametroServicio)
        {
            _Negocio = parametroServicio;
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        //[Authorize]
        [Route("Usuarios_Obtiene")]
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
