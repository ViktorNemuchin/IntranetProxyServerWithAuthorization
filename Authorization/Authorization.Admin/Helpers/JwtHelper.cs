using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Authorization.Admin.Models;
namespace Authorization.Admin.Helpers
{
    public class JwtHelper
    {
        /// <summary>
        /// Создание токена
        /// </summary>
        /// <param name="user">Пользователь</param>
        /// <param name="issuer">Поставщик</param>
        /// <param name="authority">Получатель</param>
        /// <param name="symSec">Ключ</param>
        /// <param name="daysValid">Срок действия</param>
        /// <returns></returns>
        public async Task<string> CreateJwtAsync(
            UserForClaimsGenerationModel user,
            string issuer,
            string authority,
            string symSec,
            int daysValid)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var claims = await CreateClaimsIdentities(user);

            // Создание JWToken
            var token = tokenHandler.CreateJwtSecurityToken(issuer: issuer,
                audience: authority,
                subject: claims,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddDays(daysValid),
                signingCredentials:
                new SigningCredentials(
                    new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(symSec)),
                    SecurityAlgorithms.HmacSha256Signature));

            return tokenHandler.WriteToken(token);
        }
        /// <summary>
        /// Добавление ИД и логина пользователя к Claim'ам токена 
        /// </summary>
        /// <param name="user">Пользователь</param>
        /// <returns></returns>
        private Task<ClaimsIdentity> CreateClaimsIdentities(UserForClaimsGenerationModel user)
        {
            var claimsIdentity = new ClaimsIdentity();

            claimsIdentity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()));
            claimsIdentity.AddClaim(new Claim(ClaimTypes.Name, user.UserName));

            return Task.FromResult(claimsIdentity);
        }
    }
}
