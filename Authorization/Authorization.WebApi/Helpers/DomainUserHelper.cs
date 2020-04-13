using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.DirectoryServices.AccountManagement;
using System.DirectoryServices.Protocols;
using Authorization.WebApi.Models;
using System.Net;

namespace Authorization.WebApi.Helpers
{
    public class DomainUserHelper
    {
       /// <summary>
       /// Проверка учетных данных пользователя в системе доменной авторизации 
       /// </summary>
       /// <param name="userName">Имя пользователя</param>
       /// <param name="password">Пароль</param>
       /// <param name="domain"> Домен для доменной авторизации</param>
       /// <returns></returns>
        public async Task<UserPrincipal> User(string userName, string password, string domain)
        {
            if (!IsAuthenticated(userName, password, domain))
                return null;
            var pc = new PrincipalContext(ContextType.Domain, domain, null, ContextOptions.Negotiate);
            var userPrincipal = UserPrincipal.FindByIdentity(pc, IdentityType.UserPrincipalName, userName+"@"+domain);
               return userPrincipal;
        }
        private Boolean IsAuthenticated(string username, string password, string domain)
        {
            Boolean authenticated = false;
            using (LdapConnection connection = new LdapConnection(domain))
            {
                try
                {
                    username = username + "@" + domain;
                    connection.AuthType = AuthType.Basic;
                    connection.SessionOptions.ProtocolVersion = 3;
                    var credential = new NetworkCredential(username, password);
                    connection.Bind(credential);
                    authenticated = true;
                    return authenticated;
                }
                catch (LdapException)
                {
                    return authenticated;
                }
                finally
                {
                    connection.Dispose();
                }
            }
        }
        /// <summary>
        /// Информция о пользователе для создания JWT токена 
        /// </summary>
        /// <param name="user">Пользователь(тип возвращающийся домаенной авторизацией)</param>
        /// <returns></returns>
        public UserForClaimsGenerationModel UserForToken(UserPrincipal user) 
        {
            return new UserForClaimsGenerationModel()
            {
                UserId = user.Guid.Value,
                UserName = user.SamAccountName
            };   
        }

        /// <summary>
        /// Возвращает информацию о пользователе клиенту
        /// </summary>
        /// <param name="user">Пользователь</param>
        /// <returns></returns>
        public UserViewModel UserToSend(UserForClaimsGenerationModel user, string token)
        {
            UserViewModel userView = new UserViewModel
            {
                UserName = user.UserName,
                Token = token
            };
            return userView;
        }
    }
}
