using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Facebook.Marketing.Api.Application.Services;
using FaceBook.Marketing.SDK;
using FaceBook.Marketing.SDK.Models;
using FaceBook.Marketing.SDK.Models.BusinessManagers;
using Microsoft.AspNetCore.Mvc;

namespace Facebook.Marketing.Api.Controllers
{

    /// <summary>
    /// 商务平台管理
    /// </summary>
    [Route("Api/AdAccounts")]
    [ApiController]
    public class BusinessManagerController : Controller
    {
        private readonly IBusinessManagerService _service;

        public BusinessManagerController(IBusinessManagerService service)
        {
            _service = service;
        }
        /// <summary>
        /// 获取商务管理平台列表
        /// </summary>
        /// <param name="businessId">商务管理平台Id</param>
        /// <returns></returns>
        [Route("GetBusinessManagerPageList")]
        [HttpGet]
        public async Task<FacebookResult<PageResponse<List<BusinessManagerPageResponse>>>> GetBusinessManagerPageList()
        {
            //怎么获取登入用户的商户管理平台Id

            //获取登入用户的商户管理平台列表
            //获取登入用户的商户管理平台的系统管理员用户
            //使用登入用户的商户管理平台的系统用户调用接口

            var res = await _service.GetBusinessManagerList();

            return res;

        }
        /// <summary>
        /// Id获取商务管理平台
        /// </summary>
        /// <param name="businessId">商务管理平台Id</param>
        /// <returns></returns>
        [Route("GetBusinessManagerById")]
        [HttpGet]
        public async Task<FacebookResult<BusinessManagerInfoResponse>> GetBusinessManagerById(string businessId)
        {

            var res = await _service.GetBusinessManagerById(businessId);

            return res;

        }
        /// <summary>
        /// Id修改商务管理平台
        /// </summary>
        /// <param name="businessId">商务管理平台Id</param>
        /// <returns></returns>
        [Route("UpdateBusinessManagerById")]
        [HttpGet]
        public async Task<FacebookResult<BusinessManagerInfoResponse>> UpdateBusinessManagerById(string businessId)
        {

            var res = await _service.UpdateBusinessManagerById(businessId);

            return res;

        }

        /// <summary>
        /// 邀请用户加入商务管理平台
        /// </summary>
        /// <param name="businessId">商务管理平台Id</param>
        /// <returns></returns>
        [Route("InviteUserToBusinessManager")]
        [HttpGet]
        public async Task<FacebookResult<BusinessManagerInfoResponse>> InviteUserToBusinessManager(string businessId)
        {

            var res = await _service.UpdateBusinessManagerById(businessId);

            return res;

        }
        /// <summary>
        /// 获取商务管理平台用户
        /// </summary>
        /// <param name="businessId">商务管理平台Id</param>
        /// <param name="BusinessUserEnum">用户类型</param>
        /// <returns></returns>
        [Route("GetAllBusinessUsers")]
        [HttpGet]
        public async Task<FacebookResult<PageResponse<List<BusinessUserResponse>>>> GetAllBusinessUsers(string businessId, BusinessUserEnum BusinessUserEnum= BusinessUserEnum.BusinessUser)
        {

            var res = await _service.GetBusinessManagerUsers(businessId, BusinessUserEnum);

            return res;

        }
        /// <summary>
        /// 修改商务管理平台用户角色(TODO)
        /// </summary>
        /// <param name="businessId">商务管理平台Id</param>
        /// <returns></returns>
        [Route("UpdateBusinessUserRole")]
        [HttpPost]
        public async Task<FacebookResult<ListResponse<BusinessUserResponse>>> UpdateBusinessUserRole(string businessId, BusinessUserEnum BusinessUserEnum)
        {

            var res = await _service.GetBusinessManagerUsers(businessId, BusinessUserEnum);

            return null;

        }
        /// <summary>
        /// 删除商务管理平台用户(TODO)
        /// </summary>
        /// <param name="businessId">商务管理平台Id</param>
        /// <returns></returns>
        [Route("DeleteBusinessUser")]
        [HttpPost]
        public async Task<FacebookResult<ListResponse<BusinessUserResponse>>> DeleteBusinessUser(string businessId, BusinessUserEnum BusinessUserEnum)
        {

            var res = await _service.GetBusinessManagerUsers(businessId, BusinessUserEnum);

            return null;

        }
    }
}