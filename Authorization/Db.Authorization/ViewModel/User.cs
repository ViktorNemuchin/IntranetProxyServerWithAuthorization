using System;
using Db.Authorization.Model;
using System.Collections.Generic;
using System.Text;

namespace Db.Authorization.ViewModel
{
    public class User
    {
        public Guid UserID { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public Role Role { get; set; }
        public string Token { get; set; } 
        public List<Group> Groups { get; set; }
    }
}
