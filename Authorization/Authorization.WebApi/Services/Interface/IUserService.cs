using Authorization.WebApi.Models;
using Repositories.UserRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authorization.WebApi.Services.Interface
{
    interface IUserService
    {

        /// <summary>
        /// Авторизация
        /// </summary>
        /// <param name="username">Пользователь</param>
        /// <param name="password">Пароль</param>
        /// <returns></returns>
        Task<UserViewModel> Authenticate(string username, string password);
        /// <summary>
        /// Получение всех прав
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<List<UserRightView>> GetAllUserRights(Guid userId);
    }
}
