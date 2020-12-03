using System;
using System.Collections.Generic;
using System.Text;

namespace FaceBook.Marketing.SDK.Models.AdAccounts
{
    public class AdAccountRequest : BaseRequest<AdAccountResponse, string>
    {
        public  AdAccountRequest(string adAccountId,string userToken,string parameter = null): base(parameter, userToken)
        {
            this.AdAccountId = adAccountId;
        }
       
        public string AdAccountId { get; set; }

        public override string Url =>"act_"+this.AdAccountId;

    }

    public class AdAccountResponse
    {
        public string id { get; set; }
        public string account_id { get; set; }
        public long account_status { get; set; }
        public string amount_spent { get; set; }
        public string balance { get; set; }
        public string business_city { get; set; }
        public string business_name { get; set; }
    }
}
