using System;
using System.Collections.Generic;
using System.Text;

namespace FaceBook.Marketing.SDK.Models.AuthTokens
{
    /// <summary>
    /// 应用Token
    /// </summary>
    public class AppAuthTokenResponse
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
    }
    /// <summary>
    /// 用户Token
    /// </summary>
    public class UserAuthTokenResponse
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public string expires_in { get; set; }
    }
    /// <summary>
    /// 检查Token
    /// </summary>
    public class CheckAuthTokenResponse
    {
        public Data data { get; set; }
    }
    public class Data
    {
        public string app_id { get; set; }
        public string type { get; set; }

        public string application { get; set; }

        public string expires_at { get; set; }
        public string is_valid { get; set; }
        public string issued_at { get; set; }
        public List<string> scopes { get; set; }
        public string user_id { get; set; }
    }

    public class Metadata
    {
        public string sso { get; set; }
    }
}
