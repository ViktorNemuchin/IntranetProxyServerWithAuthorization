using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebApiRouter.Services
{
    public interface IGeneralRequestMethodService<T> where T: IBaseService
    {
        public Task<IActionResult> SetGeneralRequest(string successMimeType, string errorMimeType, T service);
    }
    public class GeneralRequestMethodService<T>:ControllerBase, IGeneralRequestMethodService<T>  where T: IBaseService
    {
        private IHttpContextAccessor _contextAccessor;
        public GeneralRequestMethodService(IHttpContextAccessor contextAccessor) 
        {
            _contextAccessor = contextAccessor;
        }
        public async Task<IActionResult> SetGeneralRequest(string successMimeType, string errorMimeType, T service) 
        {
            var response = await service.AbstractClient(successMimeType,errorMimeType);
            object result = response.Content.ReadAsStreamAsync().Result;
            if (!response.IsSuccessStatusCode)
            {
                _contextAccessor.HttpContext.Response.Headers.Add("Content-Type", errorMimeType);
                return StatusCode((int)response.StatusCode, result);
            }
            _contextAccessor.HttpContext.Response.Headers.Add("Content-Type", successMimeType);
            return Ok(result);
        }
    }
}
