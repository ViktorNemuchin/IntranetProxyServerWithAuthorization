using Db.Authorization.Model;
using Repositories.UserRepository;
using Repositories.UserRepository.Models;
using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Threading.Tasks;
using Authorization.Admin.Services.Interface;

namespace Authorization.Admin.Services.Implementation

{
    public class AdminService : IAdminService
    {
        private static IUserToken _users;
        public AdminService(IUserToken users)
        {
            _users = users;
        }
        public async Task<List<Right>> GetAllRights(int module) => await _users.GetAllRights((RightModule)module);
        public async Task<List<Right>> GetAllRights(int module, int rightObject) => await _users.GetAllRights((RightModule)module, (RightObject)rightObject);
        public async Task<List<GroupView>> GetAllGroups() => await _users.GetAllGroups();
        public async Task<DetailedGroupView> GetGroupById(Guid groupId) => await _users.GetGroupById(groupId);

        public async Task<List<GroupView>> GetAllUserGroups(Guid userId) => await _users.GetAllUserGroups(userId);
        public async Task<User> GetUser(Guid userId) => await _users.GetUser(userId);

        public async Task<List<UserExtended>> GetAllUsersAsync() => await _users.GetAllUsersAsync();

        public async Task AddGroupToUser(Guid userId, Guid groupId) => await _users.AddGroupToUser(userId, groupId);
        public async Task AddRightToGroup(Guid rightId, Guid groupId) => await _users.AddRightToGroup(rightId, groupId);

        public async Task AddRight(int module, int rightObject, int rightOperator)
        {
            var right = new UserRightView
            {
                Module = (RightModule)module,
                Object = (RightObject)rightObject,
                Operator = (RightOperator)rightOperator
            };
            await _users.AddRight(right);
        }
        public async Task SaveChanges() => await _users.SaveChanges(); 


    }
}
