using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;
using Authorization.WebApi.Helpers;
using Authorization.WebApi.Services;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Moq;
using Repositories.UserRepository;
using Repositories.UserRepository.Models;
using Xunit;

namespace AuthorizationTests
{
    public class JwtTokenTest
    {
        private const string Key = "TopSecret123456789123456789";
        private const string Issuer = "https://dobrozaim.ru/";
        private const string Audience = "https://dobrozaim.ru/";
        private IUserService _userService;
        private User _user;
        
        /// <summary>
        /// Конструктор
        /// </summary>
        public JwtTokenTest()
        {
            // В создаем фейкового пользователя.
            _user = new User { UserId = new Guid("94784168-e3b2-47c2-9564-d05a8aced599"), UserName = "admin", UserPassword = "admin" };

            // Переопределяем Метов возврата пользователя из бд.
            var _userToken = new Mock<IUserToken>();
            _userToken.Setup(r => r.GetUser(It.IsAny<Guid>())).Returns((string x, string y) =>
                Task.FromResult(_user.UserName.Contains(x) ? _user : null));

            // Создаем Экземпляр сервиса для аунтификации
            IOptions<AppSettings> appSettings = new OptionsWrapper<AppSettings>(new AppSettings { Secret = Key, Audience = Audience, Issuer = Issuer});
            this._userService = new UserService(appSettings, _userToken.Object);
        }

        /// <summary>
        /// Проверка верификации токена
        /// </summary>
        [Fact]
        public void CheckVerified_Token_ReturnTrue()
        {
            //Arrange
            var tokenHandler = new JwtSecurityTokenHandler();
            var validationParameters = new TokenValidationParameters()
            {
                ValidateLifetime = true,
                ValidateAudience = true,
                ValidateIssuer = true,  
                ValidIssuer = Issuer,
                ValidAudience = Audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Key))
            };

            //Act
            var token = _userService.Authenticate(_user.UserName, _user.UserPassword).Result.Token;
            tokenHandler.ValidateToken(token, validationParameters, out var validatedToken);
            
            //Assert
            Assert.NotNull(validatedToken);
        }

        /// <summary>
        /// Проверка на неправильного пользователя
        /// </summary>
        [Fact]
        public void CheckGenerationForeignUser_Token_ReturnNull()
        {
            var res = _userService.Authenticate($"{_user.UserName}123456", _user.UserPassword).Result;
            Assert.Null(res);
        }
    }
}
