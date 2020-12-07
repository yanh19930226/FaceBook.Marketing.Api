using FaceBook.Marketing.SDK;
using FaceBook.Marketing.SDK.Models;
using FaceBook.Marketing.SDK.Models.BusinessAssets.AdAccounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Facebook.Marketing.Api.Application.Services
{
    public interface IBusinessAssetService
    {
        Task<FacebookResult<PageResponse<List<AssetAdAccountResponse>>>> GetAssetAdAccountPageList(string businessId);
    }
}
