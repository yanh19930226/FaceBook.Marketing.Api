using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Facebook.Marketing.Api.Controllers
{
    public class BusinessToBusinessController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
