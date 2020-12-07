using System;
using System.Collections.Generic;
using System.Text;

namespace FaceBook.Marketing.SDK.Models.BusinessAssets.AdAccounts
{
    public class AssetAdAccountResquest : BaseRequest<string, AssetAdAccountResponse, PageResponse<List<AssetAdAccountResponse>>>
    {
        public AssetAdAccountResquest(string businessId, string userToken, string parameter=null) : base(userToken, parameter)
        {
            this.BusinessId = businessId;
        }
        public string BusinessId { get; set; }
        public override string Url => this.BusinessId + "/owned_ad_accounts";
    }
    public class AssetAdAccountResponse
    {
        public string id { get; set; }
        public string name { get; set; }

        public string access_type { get; set; }
    }
}
