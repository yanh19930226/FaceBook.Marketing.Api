using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Facebook.Marketing.Api.Controllers
{

    /// <summary>
    /// 广告
    /// </summary>
    [Route("Api/Marketing")]
    [ApiController]
    public class MarketingController : Controller
    {
        /// <summary>
        /// 广告测试
        /// </summary>
        /// <returns></returns>
        [Route("Test")]
        [HttpGet]
        public IActionResult Test()
        {
            return Ok();
        }
    }
}
