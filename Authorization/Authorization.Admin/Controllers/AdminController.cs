using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Authorization.Admin.Services.Interface;

namespace Authorization.Admin.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }
        #region HttpGet
        public async Task<IActionResult> GetAllRights(int module)
        {
            try
            {
                var result = await _adminService.GetAllRights(module);
                return Ok(result);
            }
            catch (TaskCanceledException ex)
            {
                return BadRequest(ex.Message);
            }

        }
        public async Task<ActionResult> GetAllRights(int module, int rightObject) 
        {
            try
            {
                var result = await _adminService.GetAllRights(module,rightObject);
                return Ok(result);
            }
            catch (TaskCanceledException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public async Task<ActionResult>GetGroupById(Guid groupId) 
        {
            try
            {
                var result = await _adminService.GetGroupById(groupId);
                return Ok(result);
            }
            catch (TaskCanceledException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public async Task<ActionResult>GetAllUserGroups(Guid userId) 
        {
            try
            {
                var result = await _adminService.GetAllUserGroups(userId);
                return Ok(result);
            }
            catch (TaskCanceledException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public async Task<ActionResult> GetAllGroups() 
        {
            try 
            {
                var result = await _adminService.GetAllGroups();
                return Ok(result);
            }
            catch (TaskCanceledException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        public async Task<ActionResult> GetAllUsers() 
        {
            try
            {
                var result = await _adminService.GetAllUsersAsync();
                return Ok(result);
            }
            catch (TaskCanceledException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        public async Task<ActionResult> GetUser(Guid userId) 
        {
            try
            {
                var result = await _adminService.GetUser(userId);
                return Ok(result);
            }
            catch (TaskCanceledException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion
        #region HttpPost
        public async Task<ActionResult> AddGroupToUser(Guid userId, Guid groupId) 
        {
            try
            {
                await _adminService.AddGroupToUser(userId, groupId);
                return Ok();
            }
            catch (TaskCanceledException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        public async Task<ActionResult> AddRightToGroup(Guid rightId, Guid groupId) 
        {
            try
            {
                await _adminService.AddRightToGroup(rightId, groupId);
                return Ok();
            }
            catch (TaskCanceledException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        public async Task<ActionResult> AddRight(int module, int rightObject, int rightOperator) 
        {
            try
            {
                await _adminService.AddRight(module, rightObject, rightOperator);
                return Ok();
            }
            catch (TaskCanceledException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion
    }
}
