using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Db.Authorization.Model;

namespace UserRightsValidation
{
    /// <summary>
    /// Класс атрибута доступа к контроллеру 
    /// </summary>
    public class ModuleAttribute: AuthorizeAttribute
    {
        private RightModule module;
       /// <summary>
       /// Конструктор клвсса доступа к контроллеру  
       /// </summary>
       /// <param name="module">Имя контроллера</param>
        public ModuleAttribute(RightModule module)
        {
            Module = module;
        }

        public RightModule Module
        {
            get
            {
                return module;
            }
            set
            {
                module = value;
                Policy = $"{"Module"}.{value.ToString()}";
            }
        }
    }
}
