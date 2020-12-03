using System;
using System.Collections.Generic;
using System.Text;

namespace FaceBook.Marketing.SDK.Models.AdAccounts
{
    public class AdAccountInsightRequest : BaseRequest<AdAccountResponse, string>
    {
        public AdAccountInsightRequest(string adAccountId, string userToken, string parameter = null) : base(parameter, userToken)
        {
            this.AdAccountId = adAccountId;
        }
        public string AdAccountId { get; set; }
        public override string Url => "/insights";
    }

    public class AdAccountInsightParameter
    {
        public string level { get; set; }
        public string metrics { get; set; }
        public string limit { get; set; }
    }

    //fields=impressions,clicks,ctr,ad_name,adset_name,cpc,cpm,cpp,campaign_name,ad_id,adset_id,
    //    account_id,spend,account_name&level=campaign&metrics=ctr&limit=10
    public class AdAccountInsightResponse
    {
        public string impressions { get; set; }
        public string clicks { get; set; }
        public string ctr { get; set; }
        public string ad_name { get; set; }
        public string adset_name { get; set; }
        public string cpc { get; set; }
        public string cpm { get; set; }
        public string cpp { get; set; }
        public string campaign_name { get; set; }
        public string ad_id { get; set; }
        public string adset_id { get; set; }
        public string account_id { get; set; }
        public string spend { get; set; }
        public string account_name { get; set; }
    }
}
