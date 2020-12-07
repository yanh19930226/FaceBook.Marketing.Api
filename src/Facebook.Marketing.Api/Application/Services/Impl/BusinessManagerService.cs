using FaceBook.Marketing.SDK;
using FaceBook.Marketing.SDK.Models;
using FaceBook.Marketing.SDK.Models.BusinessManagers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Facebook.Marketing.Api.Application.Services.Impl
{
    public class BusinessManagerService : IBusinessManagerService
    {
        private FaceBookClient _client;

        public BusinessManagerService(FaceBookClient client)
        {
            _client = client;

        }
        public async Task<FacebookResult<BusinessManagerInfoResponse>> GetBusinessManagerById(string businessId)
        {
            var userToken = "EAAFzPk75z0ABALZABIiAv743ok5bsZBHLo0Fyfcv8t0kRLbh0hV8ez3iSZBTEu0UijPmBVKTLGj1gEsMy7pYhIZCFzsQ11wGdjIQFkjkapfSpKgXz5oZBZAE1vzb0h2lyYSRdZAmeEbI9I7bHM0TNrZC66WfRjUp9tltYacnicZBgnAN8ZAwrpe1iOXMnCKLsNZAZAAjv1KqnbH3fpQEyBpnaDDytQVBy8nx5GsU8LrwriuZAyDrWzovFzkz3HaoRcuvAIW0ZD";

            var request = new BusinessManagerInfoRequest(businessId, userToken);

            return await _client.GetAsync(request);
        }

        public async Task<FacebookResult<PageResponse<List<BusinessManagerPageResponse>>>> GetBusinessManagerList()
        {
            var userToken = "EAAFzPk75z0ABALZABIiAv743ok5bsZBHLo0Fyfcv8t0kRLbh0hV8ez3iSZBTEu0UijPmBVKTLGj1gEsMy7pYhIZCFzsQ11wGdjIQFkjkapfSpKgXz5oZBZAE1vzb0h2lyYSRdZAmeEbI9I7bHM0TNrZC66WfRjUp9tltYacnicZBgnAN8ZAwrpe1iOXMnCKLsNZAZAAjv1KqnbH3fpQEyBpnaDDytQVBy8nx5GsU8LrwriuZAyDrWzovFzkz3HaoRcuvAIW0ZD";

            var request = new BusinessManagerPageRequest(userToken);

            return await _client.GetAsync(request);
        }

        public async Task<FacebookResult<PageResponse<List<BusinessUserResponse>>>> GetBusinessManagerUsers(string businessId, BusinessUserEnum BusinessUserEnum)
        {
            var userToken = "EAAFzPk75z0ABALZABIiAv743ok5bsZBHLo0Fyfcv8t0kRLbh0hV8ez3iSZBTEu0UijPmBVKTLGj1gEsMy7pYhIZCFzsQ11wGdjIQFkjkapfSpKgXz5oZBZAE1vzb0h2lyYSRdZAmeEbI9I7bHM0TNrZC66WfRjUp9tltYacnicZBgnAN8ZAwrpe1iOXMnCKLsNZAZAAjv1KqnbH3fpQEyBpnaDDytQVBy8nx5GsU8LrwriuZAyDrWzovFzkz3HaoRcuvAIW0ZD";

            var request = new BusinessUserRequest(businessId, BusinessUserEnum,userToken);

            return await _client.GetAsync(request);
        }

        public async Task<FacebookResult<BusinessManagerInfoResponse>> UpdateBusinessManagerById(string businessId)
        {
            var userToken = "EAAFzPk75z0ABAK03lOOYtD5UHZC47qG718M0Rh2B94fnrXsEYDFpEROYpY068tC3bnrLnDI0Rp575cvKRy3keUENHApfVu5qsp7AXjIwA5QMgXAn00KrvToX8S3fdisDtXGC3v7OewLn5QmCjjXhOQpbop0k4RkK2yZBZAurssoKOVOMdy9eNgOcGjKdmAxCFNZCK5q8r4hEGE6apmGlhGJxd7LaeI7ZCvqEKprNfV6Vm6RyHLIqi8UTZCQUZAv35sZD";

            var request = new BusinessManagerUpdateRequest(businessId,userToken,new BusinessManagerUpdateRequestParameter { name="今天我算好孩子了吗"});

            return await _client.GetAsync(request);
        }
    }
}
