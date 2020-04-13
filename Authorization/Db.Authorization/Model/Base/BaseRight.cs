using System;
using System.Collections.Generic;
using System.Text;

namespace Db.Authorization.Model
{
    /// <summary>
    /// Базовый класс права
    /// </summary>
    public class BaseRight
    {
        /// <summary>
        /// Разрешенеие для модуля
        /// </summary>
        public RightModule Module { get; set; }
        /// <summary>
        /// Разрешение для объекта
        /// </summary>
        public RightObject Object { get; set; }
        /// <summary>
        /// Разрешение для операции
        /// </summary>
        public RightOperator Operator { get; set; }
    }
}
