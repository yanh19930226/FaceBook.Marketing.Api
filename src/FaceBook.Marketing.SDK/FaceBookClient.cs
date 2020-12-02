using FaceBook.Marketing.SDK.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

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
            client.BaseAddress = new Uri("https://graph.facebook.com/v9.0/");
            _client = client;
            _clientId = clientId;
            _clientSecret = clientSecret;
            _redirectUri = redirectUri;
        }
        
        private class JsonContent : StringContent
        {
            public JsonContent(object obj) :
            base(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json")
            { }
        }
        /// <summary>
        /// Get方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<FacebookResult<T>> GetAsync<T, K>(BaseRequest<T, K> request)
        {

            var url = "";

            FacebookResult<T> result = new FacebookResult<T>();

            //if (request.Request == RequestEnum.Refresh)
            //{

            //}

            //if (request.Request == RequestEnum.User)
            //{

            //    url = request.Url + "?client_id=" + _clientId + "&redirect_uri=" + _redirectUri+"&client_secret=" + _clientSecret +"&code="+request.Code;

            //}

            //if (request.Request == RequestEnum.App)
            //{

            //    url = request.Url+ "?client_id="+ _clientId + "&client_secret="+ _clientSecret+ "&grant_type=client_credentials&redirect_uri="+ _redirectUri;

            //}

            //if (request.Request == RequestEnum.Api)
            //{

            //}

            var httpResponse = await _client.GetAsync(url);

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
        /// <summary>
        /// Post方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<FacebookResult<T>> PostAsync<T, K>(BaseRequest<T, K> request)
        {
            FacebookResult<T> result = new FacebookResult<T>();

            var url = request.Url;

            var httpResponse = await _client.PostAsync(url, new JsonContent(new { request.Data }));

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

    }
}
