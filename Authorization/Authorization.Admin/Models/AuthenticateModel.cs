using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Authorization.WebApi.Models
{
    /// <summary>
    /// Класс пользователя для аутентификации
    /// </summary>
    public class AuthenticateModel
    {
        /// <summary>
        /// Логин
        /// </summary>
        [Required]

        public string Username { get; set; }
        /// <summary>
        /// Пароль
        /// </summary>
        [Required]
        public string Password { get; set; }
    }
}
