using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using WebApiRouter.Models;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Http;

namespace WebApiRouter.Services
{
    /// <summary>
    /// Интерфейс сервиса для реализации Http клиента для проброса запроса для Модуля Mintos
    /// </summary>
    public interface IAuthorizationClientService:IBaseService
    {
    }
    public class AuthorizationClientService:BaseService, IAuthorizationClientService
    {
        private HttpClient _client;
        private UrlConfig _options;
        private IHttpContextAccessor _accessor;
        public AuthorizationClientService(HttpClient client, IOptionsMonitor<UrlConfig> options, IHttpContextAccessor accessor)
            :base(client, accessor, options) 
        {
            _options = options.CurrentValue;
            _client = client;
            _accessor = accessor;
            _client.BaseAddress = new Uri(_options.AuthenticateUrl);
            _client.DefaultRequestHeaders.Add("Accept","*/*");
        }

        

        
    }
}
