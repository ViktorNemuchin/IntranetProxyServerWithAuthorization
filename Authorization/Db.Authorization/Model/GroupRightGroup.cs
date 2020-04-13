using System;
using System.Collections.Generic;
using System.Text;

namespace Db.Authorization.Model
{
    public class GroupRightGroup
    {
        public Guid GroupRightId { get; set; }
        public GroupRight GroupRight { get; set; }
        public Guid GroupId { get; set; }
        public Group Group {get; set;}
    }
}
