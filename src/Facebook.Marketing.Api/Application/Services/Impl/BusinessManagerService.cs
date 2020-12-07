using FaceBook.Marketing.SDK;
using FaceBook.Marketing.SDK.Models;
using FaceBook.Marketing.SDK.Models.BusinessManagers;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Facebook.Marketing.Api.Application.Services.Impl
{
    public class BusinessManagerService : IBusinessManagerService
    {
        private FaceBookClient _client;

        private readonly Appsettings _settings;

        public BusinessManagerService(FaceBookClient client, IOptions<Appsettings> options)
        {
            _client = client;
            _settings = options.Value;

        }
        public async Task<FacebookResult<BusinessManagerInfoResponse>> GetBusinessManagerById(string businessId)
        {

             var userToken = _settings.Facebook.Token;

             var request = new BusinessManagerInfoRequest(businessId, userToken);

             return await _client.GetAsync(request);
        }

        public async Task<FacebookResult<PageResponse<List<BusinessManagerPageResponse>>>> GetBusinessManagerList()
        {

            var userToken = _settings.Facebook.Token;

            var request = new BusinessManagerPageRequest(userToken);

            return await _client.GetAsync(request);
        }

        public async Task<FacebookResult<PageResponse<List<BusinessUserResponse>>>> GetBusinessManagerUsers(string businessId, BusinessUserEnum BusinessUserEnum)
        {
            var userToken = _settings.Facebook.Token;

            var request = new BusinessUserRequest(businessId, BusinessUserEnum,userToken);

            return await _client.GetAsync(request);
        }

        public async Task<FacebookResult<BusinessManagerInfoResponse>> UpdateBusinessManagerById(string businessId)
        {
            var userToken = _settings.Facebook.Token;

            var request = new BusinessManagerUpdateRequest(businessId,userToken,new BusinessManagerUpdateRequestParameter { name="今天我算好孩子了吗"});

            return await _client.GetAsync(request);
        }
    }
}
