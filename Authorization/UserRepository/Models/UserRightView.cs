using Db.Authorization.Model;

namespace Repositories.UserRepository.Models
{
    /// <summary>
    /// Класс описывающий право пользователя для <b>внутренних сервисов</b>
    /// </summary>
    public class UserRightView
    {
        /// <summary>
        /// Модуль, к которому был разрешен доступ  
        /// </summary>
        public RightModule Module { get; set; }
        /// <summary>
        /// Объект к которому разрешен доступ
        /// </summary>
        public RightObject Object { get; set; }
        /// <summary>
        /// Действие с объектом, которое разрешено.
        /// </summary>
        public RightOperator Operator { get; set; }
    }
}
