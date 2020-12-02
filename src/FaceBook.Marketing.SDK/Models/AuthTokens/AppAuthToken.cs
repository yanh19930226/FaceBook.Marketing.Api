using System;
using System.Collections.Generic;
using System.Text;

namespace FaceBook.Marketing.SDK.Models.AuthTokens
{
    public class AppAuthTokenRequest : BaseRequest<AppAuthTokenResponse, string>
    {

        public AppAuthTokenRequest(string data=null,string token=null) :base(data,token)
        {

        }

        public override string Url => "access_token";
    }
    

    public class AppAuthTokenResponse
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
    }
}
