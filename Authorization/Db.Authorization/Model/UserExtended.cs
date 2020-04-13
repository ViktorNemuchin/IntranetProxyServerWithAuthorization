using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Db.Authorization.Model
{
    public class UserExtended
    {
        /// <summary>
        /// Уникальный идентификатор пользователя / Unique user identifier
        /// </summary>
        public Guid UserExtendedId { get; set; }
        
        /// <summary>
        /// Имя пользователя / User's first name
        /// </summary>
        public string FirstName { get; set; }
        
        /// <summary>
        /// Фамилия пользователя / User's Surname
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        ///  Логин
        /// </summary>
        public string Login { get; set; }
        ///// <summary>
        ///// Пароль
        ///// </summary>
        //public string Password { get; set; }
        /// <summary>
        /// Токен
        /// </summary>
        public string Token { get; set; }


        /// <summary>
        ///  Роль присваеваемая пользователю при создании / Initial user role 
        /// </summary>
        public Role Role {get; set;}
        /// <summary>
        /// FK для роли
        /// </summary>
        public Guid RoleId { get; set; }

        /// <summary>
        /// Рабочие группы, в которых состоит полльзователь / List of working groups which the user belongs to.  
        /// </summary>
        public List<UserExtendedGroup> UserExtendedGroups { get; set; }

    }

}
