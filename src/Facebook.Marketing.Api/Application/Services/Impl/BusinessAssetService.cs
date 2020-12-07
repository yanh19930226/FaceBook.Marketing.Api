using FaceBook.Marketing.SDK;
using FaceBook.Marketing.SDK.Models;
using FaceBook.Marketing.SDK.Models.BusinessAssets.AdAccounts;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Facebook.Marketing.Api.Application.Services.Impl
{
    public class BusinessAssetService : IBusinessAssetService
    {
        private FaceBookClient _client;

        private readonly Appsettings _settings;

        public BusinessAssetService(FaceBookClient client, IOptions<Appsettings> options)
        {
            _client = client;
            _settings = options.Value;

        }

        public async Task<FacebookResult<PageResponse<List<AssetAdAccountResponse>>>> GetAssetAdAccountPageList(string businessId)
        {
            //var userToken = "EAAFzPk75z0ABAKEtQLZBvFgwXRlkuQnLtfX4deTYvh4I25NVKXMJlZCOKDbbT110mUqBA05uzxdznUs6ZBsoMVn1kbmr9titrK4efaijM72BsAa1zcnLzoAXvg638BS7KswqZCn8UATUaBTZAKKDdzQjGbEqVHfxwG4FKYZAhYWA7PtQ8KZCZBFt";

            var userToken = _settings.Facebook.Token;

            var request = new AssetAdAccountResquest(businessId, userToken);

            return await _client.GetAsync(request);
        }
    }
}
