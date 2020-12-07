using FaceBook.Marketing.SDK;
using FaceBook.Marketing.SDK.Models;
using FaceBook.Marketing.SDK.Models.BusinessAssetGroups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Facebook.Marketing.Api.Application.Services
{
    public interface IBusinessAssetGroupService
    {
        Task<FacebookResult<PageResponse<List<BusinessAssetGroupResponse>>>> GetBusinessAssetGroupList(string businessId);
    }
}
