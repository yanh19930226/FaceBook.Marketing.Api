using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Facebook.Marketing.Api
{
    public class Appsettings
    {
        public FacebooklConfig Facebook { get; set; }


        public class FacebooklConfig
        {
            public bool IsDev { get; set; }
            public string ClientId { get; set; }
            public string ClientSecret { get; set; }
            public string RedirectUri { get; set; }

            public string Token { get; set; }
        }
    }
}
