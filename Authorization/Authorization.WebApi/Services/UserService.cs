using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Authorization.WebApi.Helpers;
using Db.Authorization.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Repositories.UserRepository;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Repositories.UserRepository.Models;
using Authorization.WebApi.Models;


namespace Authorization.WebApi.Services
{
    public interface IUserService
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

    /// <summary>
    /// Сервис аутентификации
    /// </summary>
    public class UserService : IUserService
    {
        private static IUserToken _users;

        private readonly AppSettings _appSettings;

        public UserService(IOptions<AppSettings> appSettings, IUserToken userToken)
        {
            _appSettings = appSettings.Value;
            _users = userToken;
        }
        /// <summary>
        /// Аутентификация пользователя
        /// </summary>
        /// <param name="username">Логин</param>
        /// <param name="password">Пароль</param>
        /// <returns></returns>
        public async Task<UserViewModel> Authenticate(string userName, string password)
        {
            var helper = new JwtHelper();
            var userHelper = new DomainUserHelper();
            var domainUser = userHelper.User(userName, password, _appSettings.Domain).Result;
            if (domainUser == null)
                return null;

            var user = await _users.GetUser(domainUser.Guid.Value);
            var userForToken = userHelper.UserForToken(domainUser);
            var token = await helper.CreateJwtAsync(userForToken, _appSettings.Issuer, _appSettings.Audience, _appSettings.Secret, _appSettings.DaysValid);


            if (user == null)
            {
                await _users.AddUser(domainUser, token);
            }
            else 
            {
                await _users.PutToken(domainUser.Guid.Value, token);
            }
            await _users.SaveChanges();
            UserViewModel userView = userHelper.UserToSend(userForToken, token);
            return userView;
        }



        
        /// <summary>
        /// Получение всех прав пользователя
        /// </summary>
        /// <param name="userId">Идентификационнный номер пользователя</param>
        /// <returns></returns>
        public async Task<List<UserRightView>> GetAllUserRights(Guid userId)
        {
            return await _users.GetAllUserRightsOut(userId);
        }



        
    }
}