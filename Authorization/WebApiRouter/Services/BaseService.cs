using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebApiRouter.Models;

namespace WebApiRouter.Services
{
    /// <summary>
    /// Класс базового сервиса Http клиента
    /// </summary>
    public interface IBaseService
    {
        public Task<IActionResult> AbstractClient();
    }
    public class BaseService: ControllerBase, IBaseService
    {
        private readonly HttpClient _client;
        private readonly IHttpContextAccessor _accessor;
        private readonly UrlConfig _options;
        
        /// <summary>
        /// Конструктор базового сервиса Http клиента
        /// </summary>
        /// <param name="client">Http клиент</param>
        /// <param name="accessor">Текущий Http клиент</param>
        /// <param name="options">Конфигурация подключения клиента</param>
        public BaseService(HttpClient client, 
                           IHttpContextAccessor accessor,
                           IOptionsMonitor<UrlConfig> options) 
        {
            _client = client;
            _accessor = accessor;
            _options = options.CurrentValue;
        }
        /// <summary>
        /// Реализация проброса Http запроса  
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> AbstractClient()
        {
            var url = _accessor.HttpContext.Request.Path.Value.ToString();
            var separator = new Char[] { '/' };
            var count = url.IndexOf(separator[0], 1) + 1;
            var requestUrl = url.Remove(0, count);
            var method = _accessor.HttpContext.Request.Method;
            return method switch
            {
                "GET" => await GetResponse(requestUrl),
                "POST" => await PostResponse(CreateContent(), requestUrl),
                "PUT" => await PutResponse(CreateContent(), requestUrl),
                "DELETE" => await DeleteResponse(requestUrl),
                 _ => null 
            };
        }

        /// <summary>
        /// Метод получения тела запроса.
        /// </summary>
        /// <returns>Http контент.</returns>
        private HttpContent CreateContent()
        {
            using StreamContent streamContent = new StreamContent(_accessor.HttpContext.Request.Body);
            var contentTypeArray = _accessor.HttpContext.Request.ContentType.Split(";");
            var contentType = contentTypeArray[0];
            var requestBody = streamContent.ReadAsStringAsync();
            HttpContent content = new StringContent(requestBody.Result, Encoding.UTF8, contentType);
            return content;
        }

        /// <summary>
        /// Обработка и прокидывание Get запросов. 
        /// </summary>
        /// <param name="url">URL запроса</param>
        /// <returns>Ответ endpoint'а</returns>
        private async Task<IActionResult> GetResponse(string url)
        {
            SetToken();
            var result = await _client.GetAsync(url);
            _client.Dispose();

            return SetResponse(result);
        }

        /// <summary>
        /// Обработка и прокидывание Post запросов.
        /// </summary>
        /// <param name="content"></param>
        /// <param name="url">URL запроса</param>
        /// <returns>Ответ endpoint'а</returns>
        private async Task<IActionResult> PostResponse(HttpContent content, string url)
        {
            SetToken();
            var result = await _client.PostAsync(url, content);
            _client.Dispose();
            return SetResponse(result);
        }

        /// <summary>
        /// Обработка и прокидывание Put запросов.
        /// </summary>
        /// <param name="content"></param>
        /// <param name="url">URL запроса</param>
        /// <returns>Ответ endpoint'а</returns>
        private async Task<IActionResult> PutResponse(HttpContent content, string url)
        {
            SetToken();
            var result = await _client.PutAsync(url, content);
            _client.Dispose();
            return SetResponse(result);
        }

        private async Task<IActionResult> DeleteResponse(string url) 
        {
            SetToken();
            var result = await _client.DeleteAsync(url);
            _client.Dispose();
            return SetResponse(result);
        }
        /// <summary>
        /// Получение токена из текущего Http контекста
        /// </summary>
        /// <returns>Текущий токен</returns>
        public Task<String> GetToken()
        {
            var token = _accessor.HttpContext.GetTokenAsync("access_token");
            return token;
        }
        /// <summary>
        /// Формирование ретранслтруемого Http ответа
        /// </summary>
        /// <param name="result">Ответ полученный от Http клиента</param>
        /// <returns>Ответ на  Http запрос</returns>
        private ObjectResult SetResponse(HttpResponseMessage result) 
        {
            var issueResponse = StatusCode((int)result.StatusCode, result.Content.ReadAsStreamAsync().Result);
            issueResponse.ContentTypes.Add(result.Content.Headers.ContentType.MediaType);
            return issueResponse;
        }
        /// <summary>
        /// Проверяет, если в запросе присутствует токен добавляет его с запросу HttpClient'а
        /// </summary>
        private  void SetToken() 
        {
            var token = GetToken().Result;
            if (token != null)
                _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

        }
    }
}
