using System;
using System.Collections.Generic;
using System.Text;

namespace Db.Authorization.Model
{
    public class RoleRightRole
    {
        public Guid RoleRightId { get; set; }
        public RoleRight RoleRight { get; set; }
        public Guid RoleId { get; set; }
        public Role Role { get; set; }
    }
}
