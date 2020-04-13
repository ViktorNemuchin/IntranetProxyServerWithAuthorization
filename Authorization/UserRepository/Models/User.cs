using System;
using System.Collections.Generic;
using System.Text;
using Db.Authorization.Model;

namespace Repositories.UserRepository.Models
{
    /// <summary>
    /// Класс описывающий пользователя
    /// </summary>
    public class User   
    {
        /// <summary>
        /// Id пользователя
        /// </summary>
        public Guid UserId { get; set; }
        /// <summary>
        /// Логин Пользователя
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// Пароль пользователя
        /// </summary>
        public string UserPassword { get; set; }
        ///// <summary>
        ///// Роль пользователя
        ///// </summary>
        //public Role Role { get; set; }
        /// <summary>
        /// Токе пользователя
        /// </summary>
        public string Token { get; set; }

        ///// <summary>
        ///// Группы пользователя
        ///// </summary>
        //public List<Group> Groups { get; set; }
    }
}
