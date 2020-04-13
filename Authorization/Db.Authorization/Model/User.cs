using System;
using System.Threading.Tasks;

namespace Db.Authorization.Model
{
    public class User
    {
        public Guid UserId { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string Token { get; set; }


    }
}
