using System;
using System.Collections.Generic;
using System.Text;

namespace FaceBook.Marketing.SDK.Models
{
    public abstract class BaseRequest<T,K>
    {
        public BaseRequest(K data, string token)
        {
            Token = token;
            this.Data = data;
        }
        public abstract string Url { get; }
        public string Token { get; set; }
        public K Data { get; set; }
    }

    public class BaseResponse
    {

    }
}
