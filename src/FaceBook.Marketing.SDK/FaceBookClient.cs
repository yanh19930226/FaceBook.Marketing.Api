using FaceBook.Marketing.SDK.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace FaceBook.Marketing.SDK
{
    public class FaceBookClient
    {
        public HttpClient _client { get; }
        private readonly string _clientId;
        private readonly string _clientSecret;
        private readonly string _redirectUri;

        public FaceBookClient(HttpClient client,string clientId, string clientSecret,string redirectUri)
        {
            //client.BaseAddress = new Uri("https://graph.facebook.com/v9.0/");
            _client = client;
            _clientId = clientId;
            _clientSecret = clientSecret;
            _redirectUri = redirectUri;
        }

        #region Private

        private  string Encode(string value)
        {
            return HttpUtility.UrlEncode(value, Encoding.UTF8);
        }


        private PropertyInfo[] GetPropertyInfoArray<T,K,V>(BaseRequest<T, K,V> request)
        {
            PropertyInfo[] props = null;
            try
            {
                Type type = typeof(K);
                object obj = Activator.CreateInstance(type);
                props = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            }
            catch (Exception ex)
            { }
            return props;
        }


        private class JsonContent : StringContent
        {
            public JsonContent(object obj) :
            base(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json")
            { }
        }

        /// <summary>
        /// 构造参数字典
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private Dictionary<string, string> ToDictionary(object obj)
        {
            if (null == obj)
            {
                return null;
            }

            Dictionary<string, string> map = new Dictionary<string, string>();

            Type t = obj.GetType(); // 获取对象对应的类， 对应的类型

            PropertyInfo[] pi = t.GetProperties(BindingFlags.Public | BindingFlags.Instance); // 获取当前type公共属性

            foreach (PropertyInfo p in pi)
            {
                MethodInfo m = p.GetGetMethod();

                if (m != null && m.IsPublic)
                {
                    // 进行判NULL处理 
                    if (m.Invoke(obj, new object[] { }) != null)
                    {
                        if (m.ReturnType == typeof(string))
                        {
                            map.Add(p.Name, (string)m.Invoke(obj, new object[] { })); // 向字典添加元素
                        }
                        else
                        {
                            map.Add(p.Name, JsonConvert.SerializeObject(m.Invoke(obj, new object[] { }))); // 向字典添加元素
                        }
                    }
                }
            }
            return map;
        }

        /// <summary>
        /// 构造键值参数字符串UTF-8
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        private  string ConcatQueryString(Dictionary<string, string> parameters)
        {
            if (null == parameters)
            {
                return null;
            }
            StringBuilder sb = new StringBuilder();

            foreach (var entry in parameters)
            {
                string key = entry.Key;
                string val = entry.Value;

                sb.Append(Encode(key));
                if (val != null)
                {
                    sb.Append("=").Append(Encode(val));
                }
                sb.Append("&");
            }

            int strIndex = sb.Length;
            if (parameters.Count > 0)
                sb.Remove(strIndex - 1, 1);
            return sb.ToString();
        }

        /// <summary>
        /// url组成
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="queries"></param>
        /// <returns></returns>
        private string ComposeUrl(string endpoint,Dictionary<string,string>parameters)
        {
            Dictionary<string, string> mapQueries = parameters;
            StringBuilder urlBuilder = new StringBuilder("");
            urlBuilder.Append(endpoint);
            if (-1 == urlBuilder.ToString().IndexOf('?'))
            {
                urlBuilder.Append("?");
            }
            else if (!urlBuilder.ToString().EndsWith("?"))
            {
                urlBuilder.Append("&");
            }
            string query = ConcatQueryString(mapQueries);
            string url = urlBuilder.Append(query).ToString();
            if (url.EndsWith("?") || url.EndsWith("&"))
            {
                url = url.Substring(0, url.Length - 1);
            }
            return url;
        }

        #endregion

        /// <summary>
        /// Get方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<FacebookResult<V>> GetAsync<T, K, V>(BaseRequest<T, K,V> request)
        {
            var url = "";

            FacebookResult<V> result = new FacebookResult<V>();

            #region 构建请求地址

            _client.DefaultRequestHeaders.Clear();

            _client.DefaultRequestHeaders.Add("Authorization", "Bearer " + request.Token);

            var filedsStr = "?fields=";

            var props=GetPropertyInfoArray<T, K,V>(request);

            filedsStr+=props.Select(p=>p.Name).Aggregate((x, y) => x + "," + y);

            var parameterDic = ToDictionary(request.Parameter);

            var paraStr=ConcatQueryString(parameterDic);

            if (string.IsNullOrEmpty(paraStr)==false)
            {
                url = "https://graph.facebook.com/v9.0/" + request.Url + filedsStr +"&"+ paraStr;
            }
            else
            {
                url = "https://graph.facebook.com/v9.0/" + request.Url + filedsStr;
            }
           

            #endregion

            var httpResponse = await _client.GetAsync(url);

            var content = await httpResponse.Content.ReadAsStringAsync();

            V obj = JsonConvert.DeserializeObject<V>(content);

            if (httpResponse.StatusCode != HttpStatusCode.OK)
            {
                result.Failed(httpResponse.StatusCode.ToString());
            }
            else
            {
                result.Success(httpResponse.StatusCode.ToString());
            }
            result.Result = obj;

            return await Task.FromResult(result);
        }
        /// <summary>
        /// Post方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<FacebookResult<T>> PostAsync<T, K, V>(BaseRequest<T, K, V> request)
        {
            FacebookResult<T> result = new FacebookResult<T>();

            _client.DefaultRequestHeaders.Clear();

            _client.DefaultRequestHeaders.Add("Authorization", "Bearer " + request.Token);

            var url = "";

            var filedsStr = "?fields=";

            var props = GetPropertyInfoArray<T, K, V>(request);

            filedsStr += props.Select(p => p.Name).Aggregate((x, y) => x + "," + y);

            url = "https://graph.facebook.com/v9.0/" + request.Url + filedsStr;

            var httpResponse = await _client.PostAsync(url, new JsonContent(new { request.Parameter }));

            var content = await httpResponse.Content.ReadAsStringAsync();

            T obj = JsonConvert.DeserializeObject<T>(content);

            if (httpResponse.StatusCode != HttpStatusCode.OK)
            {
                result.Failed(httpResponse.StatusCode.ToString());
            }
            else
            {
                result.Success(httpResponse.StatusCode.ToString());
            }
            result.Result = obj;

            return await Task.FromResult(result);
        }
        ///// <summary>
        ///// Delete方法
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <typeparam name="K"></typeparam>
        ///// <param name="request"></param>
        ///// <returns></returns>
        //public async Task<FacebookResult<T>>DeleteAsync<T,K>(BaseRequest<T, K> request)
        //{

        //    FacebookResult<T> result = new FacebookResult<T>();

        //    return await Task.FromResult(result);
        //}

    }
}
