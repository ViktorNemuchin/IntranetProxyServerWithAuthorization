using Db.Authorization.Model;
using Repositories.UserRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authorization.Admin.Services.Interface
{

    public interface IAdminService
    {
        /// <summary>
        /// Получение набора прав по модулю
        /// </summary>
        /// <param name="module">Идентификатор модуля</param>
        /// <returns></returns>
        Task<List<Right>> GetAllRights(int module);
        /// <summary>
        /// Получение набора прав по модулю и объекту
        /// </summary>
        /// <param name="module">Идентификатор модуля</param>
        /// <param name="rightObject">Идентификатор объекта</param>
        /// <returns></returns>
        Task<List<Right>> GetAllRights(int module, int RightObject);
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
        Task<User> GetUser(Guid userId);
        /// <summary>
        /// Получить список всех пользователей
        /// </summary>
        /// <returns></returns>
        Task<List<UserExtended>> GetAllUsersAsync();
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
        Task AddRight(int module, int rightObject, int rightOperator);
        /// <summary>
        /// Сохранить изменения
        /// </summary>
        /// <returns></returns>
        Task SaveChanges();

    }
}
