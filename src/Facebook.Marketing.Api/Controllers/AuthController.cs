using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Facebook.Marketing.Api.Application.Services;
using FaceBook.Marketing.SDK;
using FaceBook.Marketing.SDK.Models.AuthTokens;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Facebook.Marketing.Api.Controllers
{

    /// <summary>
    /// 权限认证管理
    /// </summary>
    [ApiController]
    [AllowAnonymous]
    [Route("Api/Auth")]
    public class AuthController : Controller
    {
        private readonly Appsettings _settings;

        public HttpClient _client { get; }

        private readonly IAuthService _authService;

        public AuthController(IAuthService authService, IOptions<Appsettings> options, HttpClient client)
        {
            _authService = authService;

            _settings = options.Value;

            _client = client;
        }
        /// <summary>
        /// 获取应用AccessToken
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("AppAccessToken")]
        public async Task<FacebookResult<AppAuthTokenResponse>> GetTokenAppAsync()
        {

            return await _authService.GetTokenAppAsync();

        }
        /// <summary>
        /// 获取登入Facebook链接
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetFacebookLoginUrl")]
        public FacebookResult<string> GetAllegroLoginUrl()
        {
            var res = new FacebookResult<string>();

            var uri = "https://www.facebook.com/v9.0/dialog/oauth?client_id=" + _settings.Facebook.ClientId + "&redirect_uri=" + _settings.Facebook.RedirectUri+ "&response_type=code";

            res.Success(uri, FacebookResultCode.Succeed.ToString());

            return res;
        }
        /// <summary>
        /// 获取用户Token
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("UserAccessToken")]
        public async Task<FacebookResult<UserAuthTokenResponse>> GetTokenUserAsync(string code)
        {

            var res = new FacebookResult<UserAuthTokenResponse>();

            var uri = "https://www.facebook.com/v9.0/oauth/access_token?client_id=" + _settings.Facebook.ClientId + "&redirect_uri=" + _settings.Facebook.RedirectUri + "&client_secret=" + _settings.Facebook.ClientSecret+ "&code=" + code;

            var httpResponse = await _client.GetAsync(uri);

            var content = await httpResponse.Content.ReadAsStringAsync();

            UserAuthTokenResponse obj = JsonConvert.DeserializeObject<UserAuthTokenResponse>(content);

            if (httpResponse.StatusCode != HttpStatusCode.OK)
            {
                res.Failed(httpResponse.StatusCode.ToString());
            }
            else
            {
                res.Success(httpResponse.StatusCode.ToString());
            }
            res.Result = obj;

            return res;
            //return await _authService.GetTokenUserAsync(code);
        }
        /// <summary>
        /// 检查Token
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("CheckToken")]
        public async Task<FacebookResult<CheckAuthTokenResponse>> GetCheckAuthTokenAsync(string code)
        {
            return await _authService.GetCheckAuthTokenAsync(code);
        }
    }
}
