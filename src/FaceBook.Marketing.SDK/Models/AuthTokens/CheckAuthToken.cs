using System;
using System.Collections.Generic;
using System.Text;

namespace FaceBook.Marketing.SDK.Models.AuthTokens
{
    public class CheckAuthTokenRequest : BaseRequest<CheckAuthTokenResponse, CheckAuthTokenParameter>
    {
        public CheckAuthTokenRequest(CheckAuthTokenParameter data, string token) :base(data,token)
        {

        }
        public override string Url => "/debug_token?input_token="+this.Data.input_token+"&access_token="+this.Data.access_token;
    }

    public class CheckAuthTokenParameter
    {
        public string input_token { get; set; }
        public string access_token { get; set; }

    }

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
