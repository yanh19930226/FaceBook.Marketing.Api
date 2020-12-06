using System;
using System.Collections.Generic;
using System.Text;

namespace FaceBook.Marketing.SDK.Models.AdAccounts
{
    public class AdAccountInsightRequest : BaseRequest<AdAccountInsightParameter, AdAccountInsightResponse,PageResponse<List<AdAccountInsightResponse>>>
    {
        public AdAccountInsightRequest(string adAccountId, string userToken, AdAccountInsightParameter parameter) : base(userToken, parameter)
        {
            this.AdAccountId = adAccountId;
        }
        public string AdAccountId { get; set; }
        public override string Url => "act_" + this.AdAccountId+"/insights";
    }

    public class AdAccountInsightParameter
    {
        public string level { get; set; }
        public string metrics { get; set; }
        //public long limit { get; set; }
        public TimeRange time_range { get; set; }
    }
    public class AdAccountInsightResponse
    {
        public string account_currency { get; set; }
        public string spend { get; set; }
        public string social_spend { get; set; }
        public string account_id { get; set; }
        public string account_name { get; set; }
        public string ad_id { get; set; }
        public string ad_name { get; set; }
        public string adset_id { get; set; }
        public string adset_name { get; set; }
        public string impressions { get; set; }
        public string clicks { get; set; }
        public string ctr { get; set; }
        public string cpc { get; set; }
        public string cpm { get; set; }
        public string cpp { get; set; }
        public string created_time { get; set; }
        public string date_start { get; set; }
        public string date_stop { get; set; }
    }


    public class TimeRange
    {
        public string since { get; set; }
        public string until { get; set; }
    }
}
