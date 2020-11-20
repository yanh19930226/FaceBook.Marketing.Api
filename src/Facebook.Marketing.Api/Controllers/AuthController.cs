using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Facebook.Marketing.Api.Controllers
{

    /// <summary>
    /// 登入认证
    /// </summary>
    [Route("Api/Auth")]
    [ApiController]
    public class AuthController : Controller
    {
        /// <summary>
        /// 登入认证测试
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
