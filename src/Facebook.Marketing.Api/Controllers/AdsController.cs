using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Facebook.Marketing.Api.Controllers
{
    /// <summary>
    /// 广告管理
    /// </summary>
    [Route("Api/Ads")]
    [ApiController]
    public class AdsController : Controller
    {
        /// <summary>
        /// 广告测试
        /// </summary>
        /// <returns></returns>
        [Route("Test")]
        [HttpGet]
        public IActionResult Index()
        {
            return Ok();
        }
    }
}
