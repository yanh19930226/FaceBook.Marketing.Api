using System;
using System.Collections.Generic;
using System.Text;

namespace FaceBook.Marketing.SDK.Models.BusinessManagers
{

    #region PageRequest
    public class BusinessManagerPageRequest : BaseRequest<string, BusinessManagerPageResponse, PageResponse<List<BusinessManagerPageResponse>>>
    {
        public BusinessManagerPageRequest(string userToken, string parameter = null) : base(userToken, parameter)
        {
        }

        public override string Url => "me/businesses";
    }
    public class BusinessManagerPageResponse
    {
        public long id { get; set; }
        public string name { get; set; }
        public string timezone_id { get; set; }
        public string update_time { get; set; }
        public string creation_time { get; set; }
        public string business_city { get; set; }
        public string business_name { get; set; }
        public PageInfo primary_page { get; set; }
    }
    public class PageInfo
    {
        public string category { get; set; }
        public string name { get; set; }
        public long id { get; set; }
    }
    #endregion


    #region InfoRequest
    public class BusinessManagerInfoRequest : BaseRequest<string, BusinessManagerInfoResponse, BusinessManagerInfoResponse>
    {
        public BusinessManagerInfoRequest(string businessId, string userToken, string parameter = null) : base(userToken, parameter)
        {
            this.BusinessId = businessId;
        }

        public string BusinessId { get; set; }


        public override string Url => this.BusinessId;
    }

    public class BusinessManagerInfoResponse
    {
        public long id { get; set; }
        public string name { get; set; }
        public string created_time { get; set; }
    }
    #endregion

    public class BusinessManagerUpdateRequest : BaseRequest<BusinessManagerUpdateRequestParameter, BusinessManagerInfoResponse, BusinessManagerInfoResponse>
    {
        public BusinessManagerUpdateRequest(string businessId, string userToken, BusinessManagerUpdateRequestParameter parameter) : base(userToken, parameter)
        {
            this.BusinessId = businessId;
        }

        public string BusinessId { get; set; }


        public override string Url => this.BusinessId;
    }
    public class BusinessManagerUpdateRequestParameter
    {
        public string name { get; set; }
    }
}
