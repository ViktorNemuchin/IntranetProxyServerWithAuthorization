using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using System.Threading;
using System;
using System.Collections.Generic;
using System.Text;
using Repositories.UserRepository;
using Repositories.UserRepository.Models;
using System.Linq;
using UserRightsValidation.Declare;



namespace UserRightsValidation
{
    /// <summary>
    /// Класс handler'а для проверки прав доступа к контроллеру для аттрибута [Module(module)]
    /// </summary>
    public class ModuleHandler : AuthorizationHandler<ModuleRequirement>
    {
        private readonly IUserToken _user;
        public ModuleHandler(IUserToken user ) 
        {
            _user = user;
        }

        /// <summary>
        /// Переопределяемый метод для проверки уровня доступа к контроллеру. 
        /// </summary>
        /// <param name="context">Контекст авторизации пользователя.</param>
        /// <param name="requirement">Требования к проверке доступа пользователя к контроллеру.</param>
        /// <returns>
        /// Если пользователь имеет необходимые права для доступа, вызывает AuthorizationHandlerContext.succeed. 
        /// В случае когда у пользователя нет доступа, возваращет Task.FromResulr(0) - без вызоваAuthorizationHandlerContext.succeed.
        /// </returns>
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ModuleRequirement requirement)
        {
            
            if (!context.User.HasClaim(c => c.Type == HandlerConstantString.ClaimsForAttributeScheme)) 
            {
                return Task.FromResult(0);
            }
            var userId = Guid.Parse(context.User.FindFirst(c => c.Type == HandlerConstantString.ClaimsForAttributeScheme).Value);
            var userRights = _user.GetAllUserRightsOut(userId);
            UserRightView right = userRights.Result.FirstOrDefault(ml => ml.Module == requirement.Module);
            if(right != null) 
            {
                context.Succeed(requirement);
            }
            return Task.FromResult(0);
        }

    }

}
