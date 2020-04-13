using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authorization.WebApi.Models
{
    /// <summary>
    /// Класс модели пользователя для генерации токена
    /// </summary>
    public class UserForClaimsGenerationModel
    {
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public Guid UserId { get; set; }
        /// <summary>
        /// Логин
        /// </summary>
        public string UserName { get; set; }
    }
}
