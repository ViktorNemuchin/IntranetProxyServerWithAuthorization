using System;
using System.Collections.Generic;
using System.Text;

namespace Db.Authorization.Model
{
    /// <summary>
    /// Класс описывающий группу
    /// </summary>
    public class Group
    {
       /// <summary>
       /// Id группы
       /// </summary>
        public Guid GroupId { get; set; }
        /// <summary>
        /// Наименование группы
        /// </summary>
        public string GroupName { get; set; }
        /// <summary>
        /// Набор прав группы
        /// </summary>
        public  List<GroupRight> GroupRights { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public  List<UserExtendedGroup> UserExtendedGroups { get; set; } 

    }
}
