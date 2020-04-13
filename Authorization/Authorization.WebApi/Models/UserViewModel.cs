using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace Authorization.WebApi.Models
{
    /// <summary>
    /// Класс поьзователя для представления внештним сервисам
    /// </summary>
    public class UserViewModel
    {
        /// <summary>
        /// Логин
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// Токен
        /// </summary>
        public string Token { get; set; }
    }
}
