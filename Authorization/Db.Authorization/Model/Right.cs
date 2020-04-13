using System;
using System.Collections.Generic;
using System.Text;

namespace Db.Authorization.Model
{
    public class Right:BaseRight
    {
        public Guid RightId { get; set; }
        //public List <GroupRight> GroupRights{ get; set; }
        //public List<RoleRight> RoleRights { get; set; }
    }
}
