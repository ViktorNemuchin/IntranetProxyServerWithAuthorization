using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Db.Authorization.Model;

namespace UserRightsValidation
{
    /// <summary>
    /// Класс описывающий требования для политики безопасности доступа в контроллер.
    /// </summary>
    public class ModuleRequirement:IAuthorizationRequirement
    {
        public ModuleRequirement(RightModule module) 
        {
            Module = module;
        }
     
        public RightModule Module;
    }


}
