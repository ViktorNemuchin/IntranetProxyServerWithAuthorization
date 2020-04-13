using System;
using System.Collections.Generic;
using System.Text;


namespace Db.Authorization.Model
{
    /// <summary>
    /// Класс описывающий права входящие в роль
    /// </summary>
    public class RoleRight
    {
        /// <summary>
        /// Id прва для роли
        /// </summary>
        public Guid RoleRightId {get; set;}
        public Guid RightId {get; set;}
        public Role Role {get; set;}
        public Guid RoleId{ get; set;}
    }
}
