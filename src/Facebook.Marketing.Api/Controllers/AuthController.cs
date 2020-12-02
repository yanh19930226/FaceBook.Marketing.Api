using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Facebook.Marketing.Api.Application.Services;
using FaceBook.Marketing.SDK;
using FaceBook.Marketing.SDK.Models.AuthTokens;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

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

        private readonly IAuthService _authService;

        public AuthController(IAuthService authService, IOptions<Appsettings> options)
        {
            _authService = authService;

            _settings = options.Value;
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
            return await _authService.GetTokenUserAsync(code);
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
