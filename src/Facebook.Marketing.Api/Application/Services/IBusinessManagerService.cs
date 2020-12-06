using FaceBook.Marketing.SDK;
using FaceBook.Marketing.SDK.Models;
using FaceBook.Marketing.SDK.Models.BusinessManagers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Facebook.Marketing.Api.Application.Services
{
    public interface IBusinessManagerService
    {
        Task<FacebookResult<BusinessManagerInfoResponse>> GetBusinessManagerById(string businessId);
        Task<FacebookResult<PageResponse<List<BusinessUserResponse>>>> GetBusinessManagerUsers(string businessId, BusinessUserEnum BusinessUserEnum);

        Task<FacebookResult<PageResponse<List<BusinessManagerPageResponse>>>> GetBusinessManagerList();
        Task<FacebookResult<BusinessManagerInfoResponse>> UpdateBusinessManagerById(string businessId);

    }
}
