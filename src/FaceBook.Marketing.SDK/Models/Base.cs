using System;
using System.Collections.Generic;
using System.Text;

namespace FaceBook.Marketing.SDK.Models
{
    public abstract class BaseRequest<T,K>
    {
        public BaseRequest(K parameter, string token)
        {
            Token = token;
            this.Parameter = parameter;
        }
        public string Token { get; set; }
        /// <summary>
        /// 请求参数
        /// </summary>
        public K Parameter { get; set; }
        /// <summary>
        /// 请求地址
        /// </summary>
        public abstract string Url { get; }
        /// <summary>
        /// 返回字段
        /// </summary>
        public T ResponseFileds { get; set; }
    }

    public class BaseResponse
    {

    }

    public  class Paging
    {
        public Cursors cursors { get; set; }

        public string next { get; set; }
    }
    public class Cursors
    {
        public string before { get; set; }
        public string after { get; set; }

    }
    public class Summary
    {

    }
}
