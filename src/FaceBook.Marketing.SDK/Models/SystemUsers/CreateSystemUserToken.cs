using System;
using System.Collections.Generic;
using System.Text;

namespace FaceBook.Marketing.SDK.Models.SystemUsers
{
    public class CreateSystemUserTokenRequest : BaseRequest<CreateSystemUserTokenParameter, CreateSystemUserTokenResponse, CreateSystemUserTokenResponse>
    {
        public CreateSystemUserTokenRequest(string AppScopedSystemUserId, string userToken, CreateSystemUserTokenParameter parameter) :base(userToken, parameter)
        {
            AppScopedSystemUserId = AppScopedSystemUserId;
        }
        public string AppScopedSystemUserId { get; set; }
        public override string Url => this.AppScopedSystemUserId+"/access_tokens";
    }
    public class CreateSystemUserTokenParameter
    {
        public string business_app { get; set; }
        public string appsecret_proof { get; set; }
        public string scope { get; set; }
        public string access_token { get; set; }
    }

    public class CreateSystemUserTokenResponse
    {
        public string access_token { get; set; }
    }
}
