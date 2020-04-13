using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Db.Authorization.Model;
using System.Threading.Tasks;
using Repositories.UserRepository.Models;
using Repositories.UserRepository;
using System.Linq;
using UserRightsValidation.Declare;

namespace UserRightsValidation
{
    /// <summary>
    /// Класс handler'а для проверки прав доступа к методу/действию контроллера для аттрибута [Permission(rihghtModule, rightObject, rightOperator)]
    /// </summary>
    public class PermissionHandler: AuthorizationHandler<PermissionRequirement>
    {
        private readonly IUserToken _user;

        public PermissionHandler(IUserToken user) 
        {
            _user = user;
        }
        /// <summary>
        /// Переопределяемый метод для проверки уровня доступа к методу/действию контроллера.
        /// </summary>
        /// <param name="context">Контекст авторизации пользователя()</param>
        /// <param name="requirement"></param>
        /// <returns>
        /// Если пользователь имеет необходимые права для доступа, вызывает AuthorizationHandlerContext.succeed. 
        /// В случае когда у пользователя нет доступа, возваращет Task.FromResulr(0) - без вызоваAuthorizationHandlerContext.succeed.    
        /// </returns>
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
        {
            if (!context.User.HasClaim(c => c.Type == HandlerConstantString.ClaimsForAttributeScheme))
            {
                return Task.FromResult(0);
            }
            var userId = Guid.Parse(context.User.FindFirst(c => c.Type == HandlerConstantString.ClaimsForAttributeScheme).Value);
            var userRights = _user.GetAllUserRights(userId);
            UserRight right = userRights.Result
                .FirstOrDefault(ml=>ml.Module == requirement.RightModule && ml.Object == requirement.RightObject &&  ml.Operator == requirement.RightOperator);
            if (right != null)
            {
                context.Succeed(requirement);
            }
            return Task.FromResult(0);
        }
    }
}
