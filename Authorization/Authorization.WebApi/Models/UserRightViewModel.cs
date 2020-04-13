using Db.Authorization.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authorization.WebApi.Models
{
    public class UserRightViewModel
    {
        public RightModule Module { get; set; }
        public RightObject Object { get; set; }
        public RightOperator Operator { get; set; }
    }
}
