using FaceBook.Marketing.SDK;
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
        /// 根据Id获取广告账户
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        Task<FacebookResult<AdAccountResponse>> GetAdAccountById(string accountId);

    }
}
