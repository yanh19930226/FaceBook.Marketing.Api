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

            var userToken = _settings.Facebook.Token;

            var request = new AdAccountInsightRequest(accountId, userToken,new AdAccountInsightParameter { level = "campaign", metrics= "ctr"});

            return await _client.GetAsync(request);
        }

    }
}
