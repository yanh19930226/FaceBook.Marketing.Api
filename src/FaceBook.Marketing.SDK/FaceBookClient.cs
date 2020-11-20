using System;
using System.Collections.Generic;
using System.Text;

namespace FaceBook.Marketing.SDK
{
    public class FaceBookClient
    {
        private readonly string _apiKey;
        private readonly string _secretKey;

        public FaceBookClient(string apiKey,string secretKey)
        {
            _apiKey = apiKey;
            _secretKey = secretKey;
        }
    }
}
