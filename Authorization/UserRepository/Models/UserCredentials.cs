using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.UserRepository.Models
{
    /// <summary>
    /// Класс опписывающий учетные данные пользователя
    /// </summary>
    public class UserCredentials
    {
        /// <summary>
        /// Логин
        /// </summary>
        public string User { get; }
        /// <summary>
        /// Пароль
        /// </summary>
        public string Password { get; }
    }
}
