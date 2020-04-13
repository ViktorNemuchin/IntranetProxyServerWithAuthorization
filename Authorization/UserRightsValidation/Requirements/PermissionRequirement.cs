using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Db.Authorization.Model;

namespace UserRightsValidation
{
    /// <summary>
    /// Класс описывающий требования для политики безопасности доступа в метод/действие контроллера.   
    /// </summary>
    public class PermissionRequirement: IAuthorizationRequirement
    {

        /// <summary>
        /// Класс описывающий требования для политики безопасности доступа в метод/действие контроллера.
        /// </summary>
        /// <param name="rightModule">Значение RightModule enum для проверки прав доступа к контроллеру. </param>
        /// <param name="rightObject">Значение RightObject enum для проверки прав доступа к работе с объектом.</param>
        /// <param name="rightOperator">Значение RightOperator enum для проверки прав доступа к выполнению текущей операции</param>
        public PermissionRequirement(RightModule rightModule, RightObject rightObject, RightOperator rightOperator)
        {
            RightModule = rightModule;
            RightObject = rightObject;
            RightOperator = rightOperator;
        }

        public RightObject RightObject;
        public RightOperator RightOperator;
        public RightModule RightModule;
    }
}
