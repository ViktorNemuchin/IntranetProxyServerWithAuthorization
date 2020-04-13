using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.UserRepository.Models
{
    public class DetailedGroupView
    {
        public string GroupName { get; set; }
        public List<UserRight> UserRights { get; set; }

    }
}
