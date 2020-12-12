using FaceBook.Marketing.SDK;
using FaceBook.Marketing.SDK.Models;
using FaceBook.Marketing.SDK.Models.AdAccounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Facebook.Marketing.Api.Application.Services
{
    public interface IAdAccountService
    {


        /// <summary>
        ///获取自己广告账户
        /// </summary>
        /// <param name="businessId"></param>
        /// <returns></returns>
        Task<FacebookResult<PageResponse<List<OwnedAdAccountResponse>>>> GetOwnedAdAccount(string businessId);
        /// <summary>
        ///获取客户广告账户
        /// </summary>
        /// <param name="businessId"></param>
        /// <returns></returns>
        Task<FacebookResult<PageResponse<List<ClientAdAccountResponse>>>> GetClientAdAccount(string businessId);

        /// <summary>
        /// 根据Id获取广告账户
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        Task<FacebookResult<AdAccountResponse>> GetAdAccountById(string accountId);
        /// <summary>
        /// 根据广告账户获取分析
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        Task<FacebookResult<PageResponse<List<AdAccountInsightResponse>>>> GetAdAccountInsightById(string accountId);

    }
}
