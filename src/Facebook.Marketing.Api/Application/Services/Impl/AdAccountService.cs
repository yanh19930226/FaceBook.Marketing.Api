using FaceBook.Marketing.SDK;
using FaceBook.Marketing.SDK.Models;
using FaceBook.Marketing.SDK.Models.AdAccounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Facebook.Marketing.Api.Application.Services.Impl
{
    public class AdAccountService : IAdAccountService
    {

        private FaceBookClient _client;

        public AdAccountService(FaceBookClient client)
        {
            _client = client;

        }
        public async Task<FacebookResult<AdAccountResponse>> GetAdAccountById(string accountId)
        {
            var userToken = "EAACw6XEnA5QBABxvlEd491qAbAg8NZB1KGW1fAXkT126u1DaRTRIFmlXkZCRZCKjGGZA1aZBh1R61druAnCtlibN3v6I4FY1tevhAd1j70nj2WI25a25DTTbMbLBt5fqA0pcfECxgfJZChYBYPd7sxcAdMcSNJ0duOxnourL3FFb76rAgJwe1Jp6m0UnFK9eQZD";

            var request = new AdAccountRequest(accountId, userToken);

            return await _client.GetAsync(request);
        }

        public async Task<FacebookResult<BaseResponse<List<AdAccountInsightResponse>>>> GetAdAccountInsightById(string accountId)
        {
            var userToken = "EAACw6XEnA5QBAAZBz5P66k1v85S5cx5bOOXxMXVAPNZCazasfFHHG1TQeEUlwIPxvDblvrWSmAIYDXpNAuzxGksibr6JKdDjtQw27w9t1xdGyW6tDFEZCP6aMYo6KDZAdAMKxiBXfIt6y5ZA0dNhn0qLoh3NhaKgYv4ExZAOUF4DNORZAwGvp1VrO3xYVLFGKfDZCDLZAQ90YcweRo0VsXERxJXHSUwMrgoWLZCoDbx7EQlLthWBBCqxx0NPgrrLni8zsZD";

            var request = new AdAccountInsightRequest(accountId, userToken,new AdAccountInsightParameter { level = "campaign", metrics= "ctr"});

            return await _client.GetAsync(request);
        }

    }
}
