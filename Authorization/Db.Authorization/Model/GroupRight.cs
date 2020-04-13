using System;
using System.Collections.Generic;
using System.Text;

namespace Db.Authorization.Model
{
    /// <summary>
    /// Класс описывающий права входящие в группу
    /// </summary>
    public class GroupRight
    {
        /// <summary>
        /// Id права
        /// </summary>
        public Guid GroupRightId { get; set; }
        public Guid RightId { get; set; }
        public Guid GroupId { get; set; }
        public Group Group { get; set; }
    }
}
