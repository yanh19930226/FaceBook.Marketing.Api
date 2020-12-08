using System;
using System.Collections.Generic;
using System.Text;

namespace FaceBook.Marketing.SDK.Models.SystemUsers
{
    public class SystemUserInstallAppRequest : BaseRequest<SystemUserInstallAppParameter, SystemUserInstallAppResponse, SystemUserInstallAppResponse>
    {
        public SystemUserInstallAppRequest(string BusinessScopeUserId, string userToken, SystemUserInstallAppParameter parameter) : base(userToken, parameter)
        {
            BusinessScopeUserId = BusinessScopeUserId;
        }
        public string BusinessScopeUserId { get; set; }
        public override string Url => this.BusinessScopeUserId+"/applications";
    }

    public class SystemUserInstallAppParameter
    {
        public string access_token { get; set; }
        public string business_app { get; set; }
    }

    public class SystemUserInstallAppResponse
    {
        public bool success { get; set; }
    }
}
