using System;
using System.Collections.Generic;
using System.Text;

namespace FaceBook.Marketing.SDK.Models.AdAccounts
{
    public class ClientAdAccountRequest : BaseRequest<string, ClientAdAccountResponse, PageResponse<List<ClientAdAccountResponse>>>
    {
        public ClientAdAccountRequest(string BusinessId, string userToken, string parameter = null) : base(userToken, parameter)
        {
            this.BusinessId = BusinessId;
        }

        public string BusinessId { get; set; }

        public override string Url => this.BusinessId+ "/client_ad_accounts";
    }

    public class ClientAdAccountResponse
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
