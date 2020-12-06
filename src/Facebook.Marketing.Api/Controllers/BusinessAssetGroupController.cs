using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Facebook.Marketing.Api.Application.Services;
using FaceBook.Marketing.SDK;
using FaceBook.Marketing.SDK.Models;
using FaceBook.Marketing.SDK.Models.BusinessAssetGroups;
using Microsoft.AspNetCore.Mvc;

namespace Facebook.Marketing.Api.Controllers
{
    /// <summary>
    /// 资产组管理
    /// </summary>
    [ApiController]
    [Route("Api/BusinessAssetGroup")]
    public class BusinessAssetGroupController : Controller
    {
        private readonly IBusinessAssetGroupService _service;

        public BusinessAssetGroupController(IBusinessAssetGroupService service)
        {
            _service = service;
        }
        /// <summary>
        /// 获取资产组列表
        /// </summary>
        /// <param name="businessId"></param>
        /// <returns></returns>
        [Route("GetBusinessAssetGroupList")]
        [HttpGet]
        public async Task<FacebookResult<PageResponse<List<BusinessAssetGroupResponse>>>> GetBusinessAssetGroupList(string businessId)
        {

            var res = await _service.GetBusinessAssetGroupList(businessId);

            return res;

        }
        /// <summary>
        /// 获取资产组列表
        /// </summary>
        /// <param name="businessId"></param>
        /// <returns></returns>
        [Route("GetBusinessAssetGroupById")]
        [HttpGet]
        public async Task<FacebookResult<PageResponse<List<BusinessAssetGroupResponse>>>> GetBusinessAssetGroupById(string businessId)
        {

            var res = await _service.GetBusinessAssetGroupList(businessId);

            return res;

        }
    }
}