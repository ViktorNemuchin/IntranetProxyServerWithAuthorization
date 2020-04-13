using System;
using System.Collections.Generic;
using System.Text;

namespace Db.Authorization.Model
{
    public class UserExtendedGroup
    {
        public Guid UserExtendedId { get; set; }
        public UserExtended User { get; set; }
        public Guid GroupId { get; set; }
        public Group Group { get; set; }
    }
}
