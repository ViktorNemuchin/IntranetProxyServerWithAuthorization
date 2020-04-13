using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiRouter.Models
{
    public class UserAuthModel
    {   
            /// <summary>
            /// Логин
            /// </summary>
            public string Username { get; set; }

            /// <summary>
            /// Пароль
            /// </summary>
            public string Password { get; set; }
        
    }
}
