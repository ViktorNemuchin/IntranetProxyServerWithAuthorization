using System;
using System.Collections.Generic;

namespace Db.Authorization.Model
{
    /// <summary>
    /// Роль
    /// </summary>
    public class Role
    {
        /// <summary>
        /// Id роли
        /// </summary>
        public Guid RoleId { get; set; }

        /// <summary>
        /// Название роли
        /// </summary>
        public string RoleName { get; set; }
        /// <summary>
        /// Список пользователи
        /// </summary>
        public List<UserExtended> User { get; set; }
        /// <summary>
        /// Список прав для этой роли
        /// </summary>
        public List<RoleRight> RoleRights { get; set; }

    }
}
