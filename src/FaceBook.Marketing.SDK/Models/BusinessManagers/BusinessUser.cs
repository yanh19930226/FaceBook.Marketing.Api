using System;
using System.Collections.Generic;
using System.Text;

namespace FaceBook.Marketing.SDK.Models.BusinessManagers
{
    public class BusinessUserRequest : BaseRequest<string, BusinessUserResponse,PageResponse<List<BusinessUserResponse>>>
    {
        public BusinessUserRequest(string businessId, BusinessUserEnum BusinessUserEnum,string userToken, string parameter=null):base(userToken, parameter)
        {
            this.BusinessId = businessId;
            this.BusinessUserEnum = BusinessUserEnum;
        }

        public string BusinessId { get; set; }

        public BusinessUserEnum BusinessUserEnum { get; set; }
        public override string Url => RequestUrl(this.BusinessUserEnum);

        private string RequestUrl(BusinessUserEnum BusinessUserEnum)
        {
            var RequestUrl = "";
            switch (BusinessUserEnum)
            {
                case BusinessUserEnum.BusinessUser:
                    RequestUrl = this.BusinessId + "/business_users";
                    break;
                case BusinessUserEnum.SystemUser:
                    RequestUrl = this.BusinessId + "/system_users";
                    break;
                case BusinessUserEnum.PendingUser:
                    RequestUrl = this.BusinessId + "/pending_users";
                    break;
                default:
                    break;
            }
            return RequestUrl;
        }
    }

    public class BusinessUserResponse
    {
        public string id { get; set; }
        public string name { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string title { get; set; }
        public string role { get; set; }
        public string email { get; set; }
    }
}
