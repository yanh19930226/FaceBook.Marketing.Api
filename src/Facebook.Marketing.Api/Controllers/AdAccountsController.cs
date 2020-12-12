using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Facebook.Marketing.Api.Application.Services;
using FaceBook.Marketing.SDK;
using FaceBook.Marketing.SDK.Models;
using FaceBook.Marketing.SDK.Models.AdAccounts;
using Microsoft.AspNetCore.Mvc;

namespace Facebook.Marketing.Api.Controllers
{

    /// <summary>
    /// 广告账户管理
    /// </summary>
    [Route("Api/AdAccounts")]
    [ApiController]
    public class AdAccountsController : Controller
    {
        private readonly IAdAccountService _service;

        public AdAccountsController(IAdAccountService service)
        {
            _service = service;
        }
        /// <summary>
        /// 根据Id获取广告账户
        /// </summary>
        /// <param name="adAccountId">广告账户Id</param>
        /// <returns></returns>
        [Route("GetAdAccountById")]
        [HttpGet]
        public async Task<FacebookResult<AdAccountResponse>>GetAdAccountById(string adAccountId)
        {

            var res=await _service.GetAdAccountById(adAccountId);

            return res;

        }
        /// <summary>
        /// 获取自己广告账户
        /// </summary>
        /// <param name="businessId">商务管理平台Id</param>
        /// <returns></returns>
        [Route("GetOwnedAdAccount")]
        [HttpGet]
        public async Task<FacebookResult<AdAccountResponse>> GetOwnedAdAccount(string businessId)
        {

            //var res = await _service.GetOwnedAdAccount(businessId);

            //return res;

            return null;

        }

        /// <summary>
        /// 获取自己广告账户
        /// </summary>
        /// <param name="businessId">商务管理平台Id</param>
        /// <returns></returns>
        [Route("GetClientAdAccount")]
        [HttpGet]
        public async Task<FacebookResult<PageResponse<List<ClientAdAccountResponse>>>> GetClientAdAccount(string businessId)
        {

            var res = await _service.GetClientAdAccount(businessId);

            return res;

        }


        /// <summary>
        /// 根据Id获取广告账户分析
        /// </summary>
        /// <param name="adAccountId">广告账户Id</param>
        /// <returns></returns>
        [Route("GetAdAccountInsightById")]
        [HttpGet]
        public async Task<FacebookResult<PageResponse<List<AdAccountInsightResponse>>>> GetAdAccountInsightById(string adAccountId)
        {

            var res = await _service.GetAdAccountInsightById(adAccountId);

            return res;

        }
    }
}
