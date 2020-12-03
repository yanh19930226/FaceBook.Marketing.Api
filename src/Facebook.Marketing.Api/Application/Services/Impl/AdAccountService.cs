using FaceBook.Marketing.SDK;
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
            var userToken = "EAAFzPk75z0ABAFs0EHHXEPhdzQNTNt7FGHUHa9YO8gwkyGKINnXFMaduTBYcZAta39rNc5EsiilLQX5dQY22WKh62sDcDfKRyYXvk7rjX3zEsARos9aA9c4DhFBNZBDODtcz5B1AwjMQdmm8JchZAOcZCDZBquIXKWHhXFOjVewRZAOvevpeWf0svM4uMuX04mAFmlv4SHr86ehR9yvh0StgGzOLpITLkh6IWUWqmTZCjjuju7kel09";

            var request = new AdAccountRequest(accountId, userToken);

            return await _client.GetAsync(request);
        }

        public async Task<FacebookResult<AdAccountResponse>> GetAdAccountInsightById(string accountId)
        {
            var userToken = "EAAFzPk75z0ABAFs0EHHXEPhdzQNTNt7FGHUHa9YO8gwkyGKINnXFMaduTBYcZAta39rNc5EsiilLQX5dQY22WKh62sDcDfKRyYXvk7rjX3zEsARos9aA9c4DhFBNZBDODtcz5B1AwjMQdmm8JchZAOcZCDZBquIXKWHhXFOjVewRZAOvevpeWf0svM4uMuX04mAFmlv4SHr86ehR9yvh0StgGzOLpITLkh6IWUWqmTZCjjuju7kel09";

            var request = new AdAccountRequest(accountId, userToken);

            return await _client.GetAsync(request);
        }

    }
}
