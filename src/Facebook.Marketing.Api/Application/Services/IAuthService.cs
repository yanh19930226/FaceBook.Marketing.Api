using FaceBook.Marketing.SDK;
using FaceBook.Marketing.SDK.Models.AuthTokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Facebook.Marketing.Api.Application.Services
{
    public interface IAuthService
    {
        /// <summary>
        /// 获取应用Token
        /// </summary>
        /// <returns></returns>
        Task<FacebookResult<AppAuthTokenResponse>> GetTokenAppAsync();
        /// <summary>
        /// 获取用户Token
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        Task<FacebookResult<UserAuthTokenResponse>> GetTokenUserAsync(string code);
        /// <summary>
        /// 检查Token
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        Task<FacebookResult<CheckAuthTokenResponse>> GetCheckAuthTokenAsync(string code);
        /// <summary>
        /// 刷新用户Token
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        //Task<FacebookResult<AuthTokenResponse>> GetRefreshTokenUserAsync();
    }
}
