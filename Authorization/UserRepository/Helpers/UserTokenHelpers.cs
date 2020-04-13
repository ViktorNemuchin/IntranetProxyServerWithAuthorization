using System;
using System.Collections.Generic;
using Repositories.UserRepository.Models;
using Db.Authorization.Model;

namespace Repositories.UserRepository.Helpers
{
    /// <summary>
    /// Helper для репозитория UserToken
    /// </summary>
    public class UserTokenHelpers
    {
        /// <summary>
        /// Метод получения списка прав из роли пользователя <b>для внутренних сервисов</b>
        /// </summary>
        /// <param name="role">Роль пользователя</param>
        /// <returns></returns>
        public List<Guid> GetRightsFromRole(List<RoleRight> roleRights)
        {
            var rights = new List<Guid>();

            foreach (RoleRight roleRight in roleRights)
            {
                rights.Add(roleRight.RightId);
            }
            return rights;
        }


        /// <summary>
        /// Получения списка прав пользователя из группы <b> для внутренних сервисов</b>
        /// </summary>
        /// <param name="group">Группа пользователя</param>
        /// <returns></returns>
        public List<Guid> GetRightsFromGroup(Group group)
        {
            var rights = new List<Guid>();
            List<GroupRight> groupRights = group.GroupRights;
            foreach (GroupRight groupRight in groupRights)
            {
                rights.Add(groupRight.RightId);
            }
            return rights;
        }

        /// <summary>
        /// Сведение всех списков прав из групп в один <b> для внутренних сервисов</b>
        /// </summary>
        /// <param name="groups">Список групп</param>
        /// <returns></returns>
        public List<Guid> GetRightsFromAllGroups(List<Group> groups)
        {
            var rights = new List<Guid>();

            foreach (Group group in groups)
            {
                rights.AddRange(GetRightsFromGroup(group));
            }
            return rights;
        }
        public GroupView GetGroupView(Role role) =>

            new GroupView
            {
                GroupName = role.RoleName,
                GroupViewId = role.RoleId,
                IsRole = true
            };

        public GroupView GetGroupView(Group group) =>
            new GroupView
            {
                GroupName = group.GroupName,
                GroupViewId = group.GroupId,
                IsRole = false
            };

        public UserRight GetUserRight(Right right) => new UserRight
        {
            UserRightId = right.RightId,
            Module = right.Module,
            Object = right.Object,
            Operator = right.Operator
        };
           
        
          

    }
}
