using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiRouter.Models
{
    /// <summary>
    /// Конфигурационный класс приложения
    /// </summary>
    public class UrlConfig
    {
        /// <summary>
        /// Адрес к исходному Api 
        /// </summary>
        public string TestUrl { get; set; }

        /// <summary>
        /// Адрес к Api аутентификации
        /// </summary>
        public string AuthenticateUrl { get; set; }

        /// <summary>
        /// Адрес для CORS
        /// </summary>
        public string OriginUrl { get; set; }


    }
    /// <summary>
    /// Класс модели JWT токена
    /// </summary>
    public class AppSettings
    {
        /// <summary>
        /// Секретное слово
        /// </summary>
        public string Secret { get; set; }

        /// <summary>
        /// Наблюдатель
        /// </summary>
        public string Audience { get; set; }

        /// <summary>
        /// Издатель
        /// </summary>
        public string Issuer { get; set; }
    }
}
