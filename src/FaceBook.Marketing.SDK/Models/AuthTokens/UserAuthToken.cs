using System;
using System.Collections.Generic;
using System.Text;

namespace FaceBook.Marketing.SDK.Models.AuthTokens
{
    public class UserAuthTokenRequest : BaseRequest<UserAuthTokenResponse, UserAuthTokenRequestParameter>
    {
        public UserAuthTokenRequest(UserAuthTokenRequestParameter data, string token=null) :base(data,token)
        {

        }
        public override string Url => "oauth/access_token?code="+this.Data.code;
    }
    public class UserAuthTokenRequestParameter
    {
        public string code { get; set; }
        
    }

    public class UserAuthTokenResponse
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public string expires_in { get; set; }
    }
}
