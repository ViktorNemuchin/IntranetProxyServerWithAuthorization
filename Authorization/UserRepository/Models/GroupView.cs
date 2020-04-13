using System;
namespace Repositories.UserRepository.Models
{
    public class GroupView
    { 
        public Guid GroupViewId { get; set; }
        public string GroupName { get; set; }
        public Boolean IsRole { get; set; }
    }
}
