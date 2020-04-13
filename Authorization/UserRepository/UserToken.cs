using System;
using Db.Authorization;
using Db.Authorization.Model;
using Repositories.UserRepository.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using Repositories.UserRepository.Helpers;
using System.DirectoryServices.AccountManagement;

namespace Repositories.UserRepository
{
    public interface IUserToken
    {
        /// <summary>
        /// Получение набора прав по модулю
        /// </summary>
        /// <param name="module">Идентификатор модуля</param>
        /// <returns></returns>
        Task<List<Right>> GetAllRights(RightModule module);
        /// <summary>
        /// Получение набора прав по модулю и объекту
        /// </summary>
        /// <param name="module">Идентификатор модуля</param>
        /// <param name="rightObject">Идентификатор объекта</param>
        /// <returns></returns>
        Task<List<Right>> GetAllRights(RightModule module, RightObject rightObject);
        /// <summary>
        /// Получить группу по его идентификатору
        /// </summary>
        /// <param name="groupId">Ид группы</param>
        /// <returns></returns>
        Task<DetailedGroupView> GetGroupById(Guid groupId);
        /// <summary>
        /// Получить список всех возможных групп
        /// </summary>
        /// <returns></returns>
        Task<List<GroupView>> GetAllGroups();
        /// <summary>
        /// Получить список всех групп для админки
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<List<GroupView>> GetAllUserGroups(Guid userId);
        /// <summary>
        /// Получить права пользователя по его Id <b>для внутренних сервисов</b>.
        /// </summary>
        /// <param name="userId">Id пользователя </param>
        /// <returns></returns>
        Task<List<UserRight>> GetAllUserRights(Guid id);
        Task<List<UserRightView>> GetAllUserRightsOut(Guid id);
        Task<User> GetUser(Guid userId);
        Task<List<UserExtended>> GetAllUsersAsync();
        Task PutToken(Guid id, string token);
        /// <summary>
        /// Добавить группу пользователю по его идентификатору
        /// </summary>
        /// <param name="userId">Идентификатор пользователя</param>
        /// <param name="groupId">Идентификатор группы</param>
        /// <returns></returns>
        Task AddGroupToUser(Guid userId, Guid groupId);
        /// <summary>
        /// Добавить право 
        /// </summary>
        /// <param name="rightView"></param>
        /// <returns></returns>
        /// <summary>
        /// Добавить право в группу по идентификатору права и группы
        /// </summary>
        /// <param name="rightId">Ид права</param>
        /// <param name="groupId">Ид группы</param>
        /// <returns></returns>
        Task AddRightToGroup(Guid rightId, Guid groupId);
        /// <summary>
        /// Добавить правило 
        /// </summary>
        /// <param name="rightView"></param>
        /// <returns></returns>
        Task AddRight(UserRightView rightView);
        /// <summary>
        /// Сохранить изменения
        /// </summary>
        /// <returns></returns>
        Task SaveChanges();

        Task AddUser(UserPrincipal user, string token);

        
    }
    /// <summary>
    /// Класс работы с пользователем
    /// </summary>
    public class UserToken : IUserToken
    {
        private readonly EntitiesContext _context;
        private readonly DbContextOptions<EntitiesContext> _options;
        private readonly UserTokenHelpers _helper;


        public UserToken(
            EntitiesContext context,
            DbContextOptions<EntitiesContext> options
            )
        {
            _options = options;
            _context = context;
            _helper = new UserTokenHelpers();
         
        }
        /// <summary>
        /// Получить все возможные группы
        /// </summary>
        /// <returns></returns>
        public async Task<List<GroupView>> GetAllGroups() 
        {
            var groupsAll = new List<GroupView>();
            var groupsRecieved = await _context.Groups.ToListAsync();
            foreach(var groupRecieved in groupsRecieved) 
            {
                var group = new GroupView()
                {
                    GroupName = groupRecieved.GroupName,
                    GroupViewId = groupRecieved.GroupId,
                    IsRole = false
                };
                groupsAll.Add(group);
            }
            return groupsAll; 
        }
        /// <summary>
        /// Получить список всех групп пользователя для админки
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<List<GroupView>> GetAllUserGroups(Guid userId) 
        {
            List<GroupView> groups = new List<GroupView>();
            if (_context.UsersExtended.Where(ue => ue.UserExtendedId==userId)
                .FirstOrDefault()==null) 
            {
                return groups;
            }
            var role = await _context
                .UsersExtended
                .Where(x => x.UserExtendedId == userId)
                .Select(x => x.Role)
                .FirstOrDefaultAsync();
            if (role != null)
            {
                groups.Add(_helper.GetGroupView(role));
            }
            var userGroups = await _context
                .UserExtendedGroup
                .Where(x => x.UserExtendedId == userId)
                .Select(x => x.Group)
                .ToListAsync();
            if (userGroups.Count != 0) 
            {
                foreach (var userGroup in userGroups) 
                {
                    groups.Add(_helper.GetGroupView(userGroup));
                }
            }
            return groups;
        }
        /// <summary>
        /// Получить группу по его идентификатору
        /// </summary>
        /// <param name="groupId">Ид группы</param>
        /// <returns></returns>
        public async Task<DetailedGroupView> GetGroupById(Guid groupId) 
        {

            var userGroup =  _context.Groups
                .Include(x => x.GroupRights)
                .FirstOrDefault(x => x.GroupId == groupId);
                
            if (userGroup == null) 
            {
                return new DetailedGroupView();
            }
            List<Guid> userRightsIds = _helper.GetRightsFromGroup(userGroup);
            DetailedGroupView group = new DetailedGroupView
            {
                GroupName = userGroup.GroupName,
                UserRights = GetListOfUserRightsById(userRightsIds)
            };
            return group;
        }

        /// <summary>
        /// Получить права пользователя по его Id <b>для внутренних сервисов</b>.
        /// </summary>
        /// <param name="userId">Id пользователя </param>
        /// <returns></returns>
        public async Task<List<UserRight>>GetAllUserRights(Guid id) 
        {
            //var helper = new UserTokenHelpers();
            List<UserRight> userRights = new List<UserRight>();
            List<Guid> userRightsIds = new List<Guid>();
            if (_context.UsersExtended.Where(ue => ue.UserExtendedId == id)
                    .FirstOrDefault() == null)
                {
                    return userRights;
                }

            using (var db = new EntitiesContext(_options)) 
            {
                var role = await db
                .UsersExtended
                .Where(x => x.UserExtendedId == id)
                .Select(x => x.Role.RoleRights)
                .FirstOrDefaultAsync();
                if (role != null)
                {
                    userRightsIds.AddRange(_helper.GetRightsFromRole(role));
                }
            }
            

            using (var db = new EntitiesContext(_options)) 
            {
                var groups = await db.UserExtendedGroup
                    .Where(ug => ug.UserExtendedId == id)
                    .Select(gr => gr.Group)
                    .ToListAsync();
                
                if (groups != null)
                {
                    userRightsIds.AddRange(_helper.GetRightsFromAllGroups(groups));
                }
            }

            using (var db = new EntitiesContext(_options))
            {
                foreach(var rightsId in userRightsIds) 
                {
                    var right = db.Rights.FirstOrDefault(x => x.RightId == rightsId);
                    userRights.Add(_helper.GetUserRight(right));
                }
            } 
                return userRights;
        }
        /// <summary>
        /// Получение набора прав по модулю и объекту
        /// </summary>
        /// <param name="module">Идентификатор модуля</param>
        /// <param name="rightObject">Идентификатор объекта</param>
        /// <returns></returns>
        public async Task<List<Right>> GetAllRights(RightModule module, RightObject rightObject) => await _context.Rights.Where(x => x.Module == module && x.Object == rightObject).ToListAsync();
        /// <summary>
        /// Получение набора прав по модулю
        /// </summary>
        /// <param name="module">Идентификатор модуля</param>
        /// <returns></returns>
        public async Task<List<Right>> GetAllRights(RightModule module) => await _context.Rights.Where(x => x.Module == module).ToListAsync();
        
        /// <summary>
        /// Получение всех прав пользователя <b>для внешних сервисов</b>       
        /// <param name="id">Id пользователя</param>
        /// <returns></returns>
        public async Task<List<UserRightView>> GetAllUserRightsOut(Guid id)
        {
            //var helper = new UserTokenHelpers();
            var userRightsIds = new List<Guid>();
            List <UserRightView> userRights = new List<UserRightView>();
            if (_context.UsersExtended.Where(ue => ue.UserExtendedId == id)
                    .FirstOrDefault() == null)
            {
                return userRights;
            }

            
            
                var role = await _context
                    .UsersExtended
                    .Where(x => x.UserExtendedId == id)
                    .Include(x=>x.Role.RoleRights)
                    .Select(x=>x.Role.RoleRights)
                    .FirstOrDefaultAsync();
                if (role != null)
                {
                    userRightsIds.AddRange(_helper.GetRightsFromRole(role));
                }
                
            
            
                var groups = await _context.UserExtendedGroup
                    .Where(ug => ug.UserExtendedId == id)
                    .Include(g =>g.Group.GroupRights)
                    .Select(gr => gr.Group)
                    .ToListAsync();
                if (groups.Count != 0)
                {
                    userRightsIds.AddRange(_helper.GetRightsFromAllGroups(groups));
                }
                
            

                foreach (var rightsId in userRightsIds)
                {
                    var right = _context.Rights.FirstOrDefault(x => x.RightId == rightsId);
                    UserRightView userRight = new UserRightView
                    {
                        Module = right.Module,
                        Object = right.Object,
                        Operator = right.Operator
                    };
                    userRights.Add(userRight);
                }
            
            return userRights;
        }

       
        /// <summary>
        /// Получить пользователя по имени и паролю пользователя.
        /// </summary>
        /// <param name="login"> Логин </param>
        /// <param name="password">Пароль</param>
        /// <returns></returns>
        public async Task<User> GetUser(Guid userId) 
        {

                var userExtended = await _context.UsersExtended.FirstOrDefaultAsync(x => x.UserExtendedId == userId);
                if (userExtended != null)
                    return new User
                    {
                        UserId = userExtended.UserExtendedId,
                        UserName = userExtended.Login,
                        Token = userExtended.Token
                    };
                return null;
            
          
        } 
        /// <summary>
        /// Получить всех пользователей
        /// </summary>
        /// <returns></returns>
        public async Task <List<UserExtended>> GetAllUsersAsync() => await _context.UsersExtended.ToListAsync();
        /// <summary>
        /// Добавить пользователя
        /// </summary>
        /// <param name="user">Пользователь</param>
        /// <param name="token">Токен пользоват</param>
        /// <returns></returns>
        public async Task AddUser(UserPrincipal user, string token) 
        {

            UserExtended userToAdd = new UserExtended()
            {
                UserExtendedId = user.Guid.Value,
                FirstName = user.GivenName,
                LastName = user.Surname,
                Login = user.SamAccountName,
                Token = token,
                RoleId = DefaultRole()
            };
            await _context.AddAsync<UserExtended>(userToAdd);
        }
        /// <summary>
        /// Обновление токена у пользователя
        /// </summary>
        /// <param name="id">Идентификатор пользователя</param>
        /// <param name="token">Токен</param>
        /// <returns></returns>
        public async Task PutToken(Guid id, string token) 
        {
                try
                {
                    var user = await _context.UsersExtended.Where(ue => ue.UserExtendedId == id).FirstOrDefaultAsync();
                    if (user != null)
                    {
                        user.Token = token;
                        _context.Entry(user).State = EntityState.Modified;
                    }
                }
                catch (Exception ex)
                {
                    throw new NotImplementedException(ex.Message.ToString());
                }            
        }
        /// <summary>
        /// Добавить группу пользователю по его идентификатору
        /// </summary>
        /// <param name="userId">Идентификатор пользователя</param>
        /// <param name="groupId">Идентификатор группы</param>
        /// <returns></returns>
        public async Task AddGroupToUser(Guid userId, Guid groupId) 
        {
            UserExtendedGroup userGroup = new UserExtendedGroup
            {
                GroupId = groupId,
                UserExtendedId = userId
            };
            await _context.AddAsync<UserExtendedGroup>(userGroup);
        }
        /// <summary>
        /// Добавить право 
        /// </summary>
        /// <param name="rightView"></param>
        /// <returns></returns>
        public async Task AddRight(UserRightView rightView) 
        {
            var right = new Right
            {
                Object = rightView.Object,
                Module = rightView.Module,
                Operator = rightView.Operator
            };
            await _context.AddAsync<Right>(right);
        }
        /// <summary>
        /// Добавить право в группу по идентификатору права и группы
        /// </summary>
        /// <param name="rightId">Ид права</param>
        /// <param name="groupId">Ид группы</param>
        /// <returns></returns>
        public async Task AddRightToGroup(Guid rightId, Guid groupId) 
        {

            var groupRight = new GroupRight
            {
                GroupId = groupId,
                RightId = rightId
            };
            await _context.AddAsync<GroupRight>(groupRight);
        }
        /// <summary>
        /// Получение дефолтной роли по умолчанию
        /// </summary>
        /// <returns></returns>
        private Guid DefaultRole()
        {
            
            var role = _context.Roles.Where(x => x.RoleName == "DefaultRole").Include(r => r.RoleRights).FirstOrDefault();
            var roleId = role.RoleId;
            return roleId;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rightsIds"></param>
        /// <returns></returns>
        private List<UserRight> GetListOfUserRightsById(List<Guid> rightsIds) 
        {
            List<UserRight> userRights = new List<UserRight>();
            foreach (var rightsId in rightsIds)
            {
                var right = _context.Rights.FirstOrDefaultAsync(x => x.RightId == rightsId);
                userRights.Add(_helper.GetUserRight(right.Result));
            }
            return userRights;
        }

        private async Task<Group> DefaultGroup() 
        {
            return await _context.Groups.FirstOrDefaultAsync(x => x.GroupName == "DefaultGroup");
        }

        /// <summary>
        /// Сохранить изменения
        /// </summary>
        /// <returns></returns>
        public async Task SaveChanges() 
        {
            await this._context.SaveChangesAsync();
        }

    }
}
