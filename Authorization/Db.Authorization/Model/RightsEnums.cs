using System;
using System.Collections.Generic;
using System.Text;

namespace Db.Authorization.Model
{
    /// <summary>
    /// Эньюмератор модуля для права доступа
    /// </summary>
       public enum RightModule 
        {
           /// <summary>
           /// Нет прав
           /// </summary>
            None,
            /// <summary>
            /// МИнтос
            /// </summary>
            Mintos,
            /// <summary>
            /// Sms сервис
            /// </summary>
            SmsService,
            /// <summary>
            /// По займ
            /// </summary>
            Crm
        }

        /// <summary>
        /// Список возможных операций
        /// </summary>
        public enum RightOperator 
        {
           /// <summary>
           /// Нет прав
           /// </summary>
            None,
            /// <summary>
            /// Создать
            /// </summary>
            Create,
            /// <summary>
            /// Удалить
            /// </summary>
            Delete,
            /// <summary>
            /// Получить
            /// </summary>
            Get,
            /// <summary>
            /// Обновить
            /// </summary>
            Update
        }
        /// <summary>
        /// Список прав для работы с объектами
        /// </summary>
        public enum RightObject
        {

           /// <summary>
           /// Нет прав
           /// </summary>
            None,
            /// <summary>
            /// Займ
            /// </summary>
            Loan,
            /// <summary>
            /// Задача
            /// </summary>
            Task,
            /// <summary>
            /// Клиент
            /// </summary>
            Customer,
            /// <summary>
            /// Платеж
            /// </summary>
            Payment
        }
    
}
