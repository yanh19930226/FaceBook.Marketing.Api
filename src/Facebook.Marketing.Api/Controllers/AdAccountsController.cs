using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Facebook.Marketing.Api.Controllers
{

    /// <summary>
    /// 广告账户管理
    /// </summary>
    [Route("Api/AdAccounts")]
    [ApiController]
    public class AdAccountsController : Controller
    {
        /// <summary>
        /// 广告账户测试
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
