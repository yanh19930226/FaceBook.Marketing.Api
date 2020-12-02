using FaceBook.Marketing.SDK;
using FaceBook.Marketing.SDK.Models.AuthTokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Facebook.Marketing.Api.Application.Services.Impl
{
    //public class AuthService : IAuthService
    //{
    //    private FaceBookClient _client;

    //    public AuthService(FaceBookClient client)
    //    {
    //        _client = client;

    //    }

    //    public async Task<FacebookResult<AppAuthTokenResponse>> GetTokenAppAsync()
    //    {
    //        var request = new AppAuthTokenRequest();

    //        request.Request = RequestEnum.App;

    //        var res = await _client.GetAsync(request);

    //        return res;
    //    }

    //    public async Task<FacebookResult<UserAuthTokenResponse>> GetTokenUserAsync(string code)
    //    {
    //        var request = new UserAuthTokenRequest(code);

    //        request.Request = RequestEnum.User;

    //        var res = await _client.GetAsync(request);

    //        return res;
    //    }

    //    public async Task<FacebookResult<CheckAuthTokenResponse>> GetCheckAuthTokenAsync(string code)
    //    {
    //        //ToDo: 从数据库中获取input_token和access_token

    //        var request = new CheckAuthTokenRequest(new CheckAuthTokenParameter { input_token = code, access_token=code },code);

    //        request.Request = RequestEnum.User;

    //        var res = await _client.GetAsync(request);

    //        return res;
    //    }
    //}
}
