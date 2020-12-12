using FaceBook.Marketing.SDK;
using FaceBook.Marketing.SDK.Models;
using FaceBook.Marketing.SDK.Models.SystemUsers;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Facebook.Marketing.Api.Application.Services.Impl
{
    public class SystemUserService : ISystemUserService
    {

        private FaceBookClient _client;

        private readonly Appsettings _settings;

        public SystemUserService(FaceBookClient client, IOptions<Appsettings> options)
        {
            _client = client;
            _settings = options.Value;

        }
        public Task<FacebookResult<CreateSystemUserResponse>> CreateSystemUser()
        {
            throw new NotImplementedException();
        }

        public async Task<FacebookResult<PageResponse<List<AssignedAdAccountResponse>>>> GetAssignedAdAccounts(string businessScopeUserId)
        {

            var userToken = _settings.Facebook.SystemUserToken;

            var request = new AssignedAdAccountRequest(businessScopeUserId, userToken);

            return await _client.GetAsync(request);

        }

        public async Task<FacebookResult<SystemUserInstallAppResponse>> SystemUserInstallApp(string businessScopeUserId,string appId)
        {
            var userToken = _settings.Facebook.Token;

            var request = new SystemUserInstallAppRequest(businessScopeUserId, userToken, new SystemUserInstallAppParameter { business_app = appId, access_token= userToken });

            return await _client.GetAsync(request);
        }

        public Task<FacebookResult<CreateSystemUserTokenResponse>> CreateSystemUserToken(string businessScopeUserId, string appId)
        {
            throw new NotImplementedException();
        }
    }
}
