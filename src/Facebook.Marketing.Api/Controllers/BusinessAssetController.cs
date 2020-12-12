using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Facebook.Marketing.Api.Application.Services;
using FaceBook.Marketing.SDK;
using FaceBook.Marketing.SDK.Models;
using FaceBook.Marketing.SDK.Models.BusinessAssets.AdAccounts;
using Microsoft.AspNetCore.Mvc;

namespace Facebook.Marketing.Api.Controllers
{
    /// <summary>
    /// 资产管理
    /// </summary>
    [Route("Api/BusinessAsset")]
    [ApiController]
    public class BusinessAssetController : Controller
    {
        private readonly IBusinessAssetService _service;
        public BusinessAssetController(IBusinessAssetService service)
        {
            _service = service;
        }
        /// <summary>
        /// 获取商务管理广告账户
        /// </summary>
        /// <param name="businessId">商务管理平台Id</param>
        /// <returns></returns>
        [Route("GetBusinessManagerPageList")]
        [HttpGet]
        public async Task<FacebookResult<PageResponse<List<AssetAdAccountResponse>>>> GetBusinessManagerPageList(string businessId)
        {

            var res = await _service.GetAssetAdAccountPageList(businessId);

            return res;

        }
        /// <summary>
        ///创建广告账户(TODO)
        /// </summary>
        /// <param name="businessId">商务管理平台Id</param>
        /// <returns></returns>
        [Route("CreateAdAccount")]
        [HttpGet]
        public async Task<FacebookResult<PageResponse<List<AssetAdAccountResponse>>>> CreateAdAccount(string businessId)
        {

            var res = await _service.GetAssetAdAccountPageList(businessId);

            return res;

        }
        /// <summary>
        ///删除广告账户(TODO)
        /// </summary>
        /// <param name="businessId">商务管理平台Id</param>
        /// <returns></returns>
        [Route("DeleteAdAccount")]
        [HttpGet]
        public async Task<FacebookResult<PageResponse<List<AssetAdAccountResponse>>>>DeleteAdAccount(string businessId)
        {

            var res = await _service.GetAssetAdAccountPageList(businessId);

            return res;

        }




    }
}
