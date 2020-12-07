using System;
using System.Collections.Generic;
using System.Text;

namespace FaceBook.Marketing.SDK.Models.BusinessAssetGroups
{

    public class BusinessAssetGroupRequest : BaseRequest<string, BusinessAssetGroupResponse, PageResponse<List<BusinessAssetGroupResponse>>>
    {
        public BusinessAssetGroupRequest(string businessId, string userToken, string parameter = null) : base(userToken, parameter)
        {
            this.BusinessId = businessId;
        }

        public string BusinessId { get; set; }
        public override string Url => throw new NotImplementedException();
    }
    public class BusinessAssetGroupResponse
    {
        public string id { get; set; }
        public string name { get; set; }

    }
}
