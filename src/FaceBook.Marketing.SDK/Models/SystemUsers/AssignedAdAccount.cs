using System;
using System.Collections.Generic;
using System.Text;

namespace FaceBook.Marketing.SDK.Models.SystemUsers
{
    public class AssignedAdAccountRequest : BaseRequest<string, AssignedAdAccountResponse, PageResponse<List<AssignedAdAccountResponse>>>
    {
        public AssignedAdAccountRequest(string BusinessScopeUserId, string SystemUserToken, string parameter=null) : base(SystemUserToken, parameter)
        {
            this.BusinessScopeUserId = BusinessScopeUserId;
        }
        public string BusinessScopeUserId { get; set; }

        public override string Url => this.BusinessScopeUserId+ "/assigned_ad_accounts";
    }

    public class AssignedAdAccountResponse
    {
        public string id { get; set; }
        public string name { get; set; }

    }
}
