using FaceBook.Marketing.SDK;
using FaceBook.Marketing.SDK.Models;
using FaceBook.Marketing.SDK.Models.AdAccounts;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Facebook.Marketing.Api.Application.Services.Impl
{
    public class AdAccountService : IAdAccountService
    {

        private FaceBookClient _client;

        private readonly Appsettings _settings;

        public AdAccountService(FaceBookClient client, IOptions<Appsettings> options)
        {
            _client = client;
            _settings = options.Value;

        }
        public async Task<FacebookResult<AdAccountResponse>> GetAdAccountById(string accountId)
        {

            var userToken = _settings.Facebook.Token;

            var request = new AdAccountRequest(accountId, userToken);

            return await _client.GetAsync(request);
        }




        public async Task<FacebookResult<PageResponse<List<AdAccountInsightResponse>>>> GetAdAccountInsightById(string accountId)
        {

            var userToken = _settings.Facebook.SystemUserToken;

            var request = new AdAccountInsightRequest(accountId, userToken,new AdAccountInsightParameter { level = "account", metrics= "ctr",time_range = new TimeRange()
            {
                since = "2020-11-15",
                until = "2020-12-29"
            }});

            return await _client.GetAsync(request);
        }

        public async Task<FacebookResult<PageResponse<List<OwnedAdAccountResponse>>>> GetOwnedAdAccount(string businessId)
        {
            var userToken = _settings.Facebook.Token;

            var request = new OwnedAdAccountRequest(businessId, userToken);

            return await _client.GetAsync(request);
        }

        public async Task<FacebookResult<PageResponse<List<ClientAdAccountResponse>>>> GetClientAdAccount(string businessId)
        {
            var userToken = _settings.Facebook.Token;

            var request = new ClientAdAccountRequest(businessId, userToken);

            return await _client.GetAsync(request);
        }

        public List<UserAdAccountResponse> GetUserAdAccountsLoop(string token, PageParameter page, List<UserAdAccountResponse> result)
        {
            try
            {
                var userAdAccountsResponse = this.GetUserAddAcounts(token, page).Result.Result;

                var userAdAccounts = userAdAccountsResponse.data;
                if (userAdAccounts != null)
                {
                    foreach (var item in userAdAccounts)
                    {
                        result.Add(item);
                    }

                    //分页获取
                    if (string.IsNullOrEmpty(userAdAccountsResponse.paging.next) == false)
                    {
                        page.after = userAdAccountsResponse.paging.cursors.after;
                        GetUserAdAccountsLoop(token, page, result);
                    }
                }
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex.Message);
                throw;
            }
            return result;
        }

        public async Task<FacebookResult<PageResponse<List<UserAdAccountResponse>>>> GetUserAddAcounts(string userToken, PageParameter page)
        {

            var request = new UserAdAccountRequest(userToken, new UserAdAccountParameter()
            {
                after = page.after,
                before = page.before,
                limit = page.limit,
                pretty = page.pretty
            });

            return await _client.GetAsync(request);
        }


    }
}
