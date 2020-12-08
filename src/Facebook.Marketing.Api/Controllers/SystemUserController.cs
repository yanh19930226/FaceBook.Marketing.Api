using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Facebook.Marketing.Api.Application.Services;
using FaceBook.Marketing.SDK;
using FaceBook.Marketing.SDK.Models;
using FaceBook.Marketing.SDK.Models.SystemUsers;
using Microsoft.AspNetCore.Mvc;

namespace Facebook.Marketing.Api.Controllers
{
    /// <summary>
    /// 系统用户管理
    /// </summary>
    [Route("Api/AdAccounts")]
    [ApiController]
    public class SystemUserController : Controller
    {
        private readonly ISystemUserService _service;

        public SystemUserController(ISystemUserService service)
        {
            _service = service;
        }
        /// <summary>
        /// 创建系统管理员
        /// </summary>
        /// <returns></returns>
        [Route("CreateSystemUser")]
        [HttpPost]
        public async Task<FacebookResult<CreateSystemUserResponse>> CreateSystemUser()
        {

            var res = await _service.CreateSystemUser();

            return null;

        }
        /// <summary>
        /// 系统用户安装应用
        /// </summary>
        /// <returns></returns>
        [Route("SystemUserInstallApp")]
        [HttpPost]
        public async Task<FacebookResult<SystemUserInstallAppResponse>> SystemUserInstallApp(string businessScopeUserId,string AppId)
        {

            var res = await _service.SystemUserInstallApp(businessScopeUserId, AppId);

            return res;

        }
        /// <summary>
        /// 生成系统用户口令
        /// </summary>
        /// <returns></returns>
        [Route("GetSystemUserToken")]
        [HttpPost]
        public async Task<FacebookResult<CreateSystemUserResponse>> GetSystemUserToken()
        {

            var res = await _service.CreateSystemUser();

            return null;

        }
        /// <summary>
        /// 获取系统用户权限(Pending)
        /// </summary>
        /// <returns></returns>
        [Route("GetSystemUserPermission")]
        [HttpPost]
        public async Task<FacebookResult<CreateSystemUserResponse>> GetSystemUserPermission()
        {

            var res = await _service.CreateSystemUser();

            return null;

        }
        /// <summary>
        /// 系统用户分配广告账户
        /// </summary>
        /// <returns></returns>
        [Route("SystemUserAdAccount")]
        [HttpPost]
        public async Task<FacebookResult<CreateSystemUserResponse>> SystemUserAdAccount()
        {

            var res = await _service.CreateSystemUser();

            return null;

        }
        /// <summary>
        /// 系统用户分配主页
        /// </summary>
        /// <returns></returns>
        [Route("SystemUserPage")]
        [HttpPost]
        public async Task<FacebookResult<CreateSystemUserResponse>> SystemUserPage()
        {

            var res = await _service.CreateSystemUser();

            return null;

        }
        /// <summary>
        /// 获取系统用户的管理的广告账户
        /// </summary>
        /// <param name="businessScopeUserId"></param>
        /// <returns></returns>
        [Route("GetAssignedAdAccounts")]
        [HttpGet]
        public async Task<FacebookResult<PageResponse<List<AssignedAdAccountResponse>>>> GetAssignedAdAccounts(string businessScopeUserId)
        {

            var res = await _service.GetAssignedAdAccounts(businessScopeUserId);

            return res;

        }
        /// <summary>
        /// 获取系统用户的管理的主页
        /// </summary>
        /// <param name="businessScopeUserId"></param>
        /// <returns></returns>
        [Route("GetAssignedPages")]
        [HttpGet]
        public async Task<FacebookResult<PageResponse<List<AssignedAdAccountResponse>>>> GetAssignedPages(string businessScopeUserId)
        {

            var res = await _service.GetAssignedAdAccounts(businessScopeUserId);

            return res;

        }
    }
}