using System;
using Microsoft.AspNetCore.Authorization;
using Db.Authorization.Model;

namespace UserRightsValidation
{/// <summary>
/// Класс создания атрубта разрешения доступа к методу контроллера
/// </summary>
    public class PermissionAttribute:AuthorizeAttribute
    {
        private string name;
        /// <summary>
        /// Конструктор атрибута метода контроллера для назначения 
        /// </summary>
        /// <param name="rightModule">Модуль, </param>
        /// <param name="rightObject">Объект(клиент, договор, займ)</param>
        /// <param name="rightOperator">Действие(сооздать, коппировать, удалить)</param>
        public PermissionAttribute(RightModule rightModule, RightObject rightObject, RightOperator rightOperator)
        {
            Names = $"{ rightModule}.{rightObject}.{rightOperator}";
        }

        public string Names
        {
            get
            {

                return name;
            }
            set
            {
                name = value;
                Policy = $"{"Permission"}.{value.ToString()}";
            }
        }
    }
}
