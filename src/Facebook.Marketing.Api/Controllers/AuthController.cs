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

        public AuthController( IOptions<Appsettings> options)
        {
            _settings = options.Value;
        }
        /// <summary>
        /// 获取应用AccessToken
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetTokenAppAsync")]
        public async Task<FacebookResult<AppAuthTokenResponse>> GetTokenAppAsync()
        {
            var _client = new HttpClient();

            var res = new FacebookResult<AppAuthTokenResponse>();

            var uri = "https://graph.facebook.com/v9.0/oauth/access_token?client_id=" + _settings.Facebook.ClientId  + "&client_secret=" + _settings.Facebook.ClientSecret + "&grant_type=client_credentials&redirect_uri=" + _settings.Facebook.RedirectUri;

            var httpResponse = await _client.GetAsync(uri);

            var content = await httpResponse.Content.ReadAsStringAsync();

            AppAuthTokenResponse obj = JsonConvert.DeserializeObject<AppAuthTokenResponse>(content);

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

            //var uri = "https://www.facebook.com/v9.0/dialog/oauth?client_id=" + _settings.Facebook.ClientId + "&redirect_uri=" + _settings.Facebook.RedirectUri + "&response_type=code";

            var uri = "https://www.facebook.com/v9.0/dialog/oauth?client_id=" + _settings.Facebook.ClientId + "&redirect_uri=" + _settings.Facebook.RedirectUri + "&scope=ads_management,ads_read,email,public_profile" + "&response_type=code";

            res.Success(uri, FacebookResultCode.Succeed.ToString());

            return res;
        }
        /// <summary>
        /// 根据授权码获取用户Token
        /// </summary>
        /// <param name="code">授权码</param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetTokenUserAsync")]
        public async Task<FacebookResult<UserAuthTokenResponse>> GetTokenUserAsync(string code)
        {

            var _client = new HttpClient();

            var res = new FacebookResult<UserAuthTokenResponse>();

            var uri = "https://graph.facebook.com/v9.0/oauth/access_token?client_id=" + _settings.Facebook.ClientId + "&redirect_uri=" + _settings.Facebook.RedirectUri + "&client_secret=" + _settings.Facebook.ClientSecret + "&code=" + code;

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

        }
        /// <summary>
        /// 用户短期Token换取用户长期Token
        /// </summary>
        /// <param name="userToken">用户短期Token</param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetLongTokenUserAsync")]
        public async Task<FacebookResult<UserAuthTokenResponse>> GetLongTokenUserAsync(string userToken)
        {

            var _client = new HttpClient();

            var res = new FacebookResult<UserAuthTokenResponse>();

            var uri = "https://graph.facebook.com/v9.0/oauth/access_token?grant_type=fb_exchange_token&client_id=" + _settings.Facebook.ClientId  + "&client_secret=" + _settings.Facebook.ClientSecret + "&fb_exchange_token=" + userToken;

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

        }

        /// <summary>
        /// 检查Token
        /// </summary>
        /// <param name="needToCheckToken">要检查的Token</param>
        /// <param name="appToken">应用Token</param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetCheckAuthTokenAsync")]
        public async Task<FacebookResult<CheckAuthTokenResponse>> GetCheckAuthTokenAsync(string needToCheckToken,string appToken)
        {
            var _client = new HttpClient();

            var res = new FacebookResult<CheckAuthTokenResponse>();

            var uri = "https://graph.facebook.com/v9.0/debug_token?input_token=" + needToCheckToken + "&access_token=" + appToken;

            var httpResponse = await _client.GetAsync(uri);

            var content = await httpResponse.Content.ReadAsStringAsync();

            CheckAuthTokenResponse obj = JsonConvert.DeserializeObject<CheckAuthTokenResponse>(content);

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
        }
    }
}
