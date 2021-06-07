using System;
using System.Collections.Generic;
using System.Text;

namespace FaceBook.Marketing.SDK.Models.Users
{
    public class UserAdAccountRequest : BaseRequest<UserAdAccountParameter, UserAdAccountResponse, PageResponse<List<UserAdAccountResponse>>>
    {
        public UserAdAccountRequest(string userToken, UserAdAccountParameter parameter) : base(userToken, parameter)
        {

        }
        public override string Url => "me/adaccounts";
    }

    public class UserAdAccountParameter : PageParameter
    {

    }

    public class UserAdAccountResponse
    {
        public string id { get; set; }
        public string name { get; set; }
        public string account_id { get; set; }
        public int account_status { get; set; }
        public string amount_spent { get; set; }
        public string balance { get; set; }
        public string currency { get; set; }
        public int disable_reason { get; set; }
        public string media_agency { get; set; }
    }
}
