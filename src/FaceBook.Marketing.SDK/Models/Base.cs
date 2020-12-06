using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FaceBook.Marketing.SDK.Models
{
    /// <summary>
    /// 请求说明
    /// </summary>
    /// <typeparam name="T">请求参数</typeparam>
    /// <typeparam name="K">请求返回字段</typeparam>
    /// <typeparam name="V">请求返回格式</typeparam>
    public abstract class BaseRequest<T,K,V>
    {
        public BaseRequest(string token, T parameter)
        {
            Token = token;
            this.Parameter = parameter;
        }
        /// <summary>
        /// 请求Token
        /// </summary>
        public string Token { get; set; }
        /// <summary>
        /// 请求参数
        /// </summary>
        public T Parameter { get; set; }
        /// <summary>
        /// 返回字段
        /// </summary>
        public K ResponseFileds { get; set; }
        /// <summary>
        /// 请求地址
        /// </summary>
        public abstract string Url { get; }
    }
   
    public class PageResponse<K>
    {
        public K data { get; set; }

        public Paging paging { get; set; }
    }

    public class ListResponse<K>
    {
        public K data { get; set; }
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

    #region Json
    //public class DataConvert : JsonConverter
    //{
    //    public override bool CanConvert(Type objectType)
    //    {
    //        return true;
    //    }

    //    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    //    {
    //        try
    //        {
    //            var result = serializer.Deserialize(reader);

    //            if (result.ToString() == "[]")
    //                return null;

    //            return JsonConvert.DeserializeObject(result.ToString(), objectType);
    //        }
    //        catch (Exception ex)
    //        {
    //            return null;
    //        }
    //    }

    //    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    //    {
    //        Console.WriteLine(111);
    //    }
    //} 
    #endregion

}
