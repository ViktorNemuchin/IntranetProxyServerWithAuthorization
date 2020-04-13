using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiRouter.Services;
using Microsoft.AspNetCore.Authorization;
using WebApiRouter.Models;
using System.Net.Http;
using System.Text;
using Microsoft.AspNetCore.Cors;
using JsonSerializer = System.Text.Json.JsonSerializer;
using Microsoft.AspNetCore.Authentication;

namespace WebApiRouter.Controllers
{
    /// <summary>
    /// Контроллер аутентификации и получения прав пользователя.
    /// </summary>
    [EnableCors("MyPolicy")]
    [Route("api/user/")]
    [ApiController]
    public class AuthorizationModuleController : ControllerBase
    {
        private readonly IAuthorizationClientService _client;


        public AuthorizationModuleController(IAuthorizationClientService client)
        {
            _client = client;
        }
        #region HttpPost
        /// <summary>
        /// Аутентификация поьзователя
        /// </summary>
        /// <param name="user">Пользователь</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        [Route("authenticate")]
        public async Task<IActionResult> Authenticate()
        {
            //var response = await _client.AbstractClient();
            //HttpContext.Response.Headers.Add("Content-Type", "application/json");
            //var result = response.Content.ReadAsStreamAsync().Result;
            //if (!response.IsSuccessStatusCode)
            //    return new ForbidResult();
            return await _client.AbstractClient();
        }
        #endregion

        #region HttpGet
        /// <summary>
        /// Получение прав поьзователя по токену
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        [Route("getuserright")]
        public async Task<IActionResult> GetAllUserRights()
        {
            //var response = await _client.AbstractClient();
            //HttpContext.Response.Headers.Add("Content-Type", "application/json");
            //var result = response.Content.ReadAsStreamAsync().Result;
            //if (!response.IsSuccessStatusCode)
            //    return BadRequest("У вас нет прав. Свяжитесь с администратоором для их назначения.");
            return await _client.AbstractClient();
        }
        #endregion
    }
}