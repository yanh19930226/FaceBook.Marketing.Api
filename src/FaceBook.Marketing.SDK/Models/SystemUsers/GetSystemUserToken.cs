using System;
using System.Collections.Generic;
using System.Text;

namespace FaceBook.Marketing.SDK.Models.SystemUsers
{
    public class GetSystemUserTokenRequest : BaseRequest<GetSystemUserTokenParameter, GetSystemUserTokenResponse, GetSystemUserTokenResponse>
    {
        public GetSystemUserTokenRequest(string AppScopedSystemUserId, string userToken, GetSystemUserTokenParameter parameter) :base(userToken, parameter)
        {
            AppScopedSystemUserId = AppScopedSystemUserId;
        }
        public string AppScopedSystemUserId { get; set; }
        public override string Url => throw new NotImplementedException();
    }
    public class GetSystemUserTokenParameter
    {
        public string business_app { get; set; }
        public string appsecret_proof { get; set; }
        public string scope { get; set; }
        public string access_token { get; set; }
    }

    public class GetSystemUserTokenResponse
    {
        public string access_token { get; set; }
    }
}
